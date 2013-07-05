// CutImage.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
//#include "gdal.h"
//
//
//int _tmain(int argc, _TCHAR* argv[])
//{
//	
//	return 0;
//}

#include "gdal_priv.h"
#include "cpl_conv.h" //for CPLMalloc()
//#include "ogr_spatialref.h"
#include "gdal_alg.h"
#include "gdalwarper.h"
#include "gdal.h"
#include "ConsoleProcess.h"
#include "ogr_geometry.h"
#include "ogr_api.h"
#include "ogrsf_frmts.h"


class CutlineTransformer : public OGRCoordinateTransformation
{
public:

    void         *hSrcImageTransformer;

    virtual OGRSpatialReference *GetSourceCS() { return NULL; }
    virtual OGRSpatialReference *GetTargetCS() { return NULL; }

    virtual int Transform( int nCount, 
                           double *x, double *y, double *z = NULL ) {
        int nResult;

        int *pabSuccess = (int *) CPLCalloc(sizeof(int),nCount);
        nResult = TransformEx( nCount, x, y, z, pabSuccess );
        CPLFree( pabSuccess );

        return nResult;
    }

    virtual int TransformEx( int nCount, 
                             double *x, double *y, double *z = NULL,
                             int *pabSuccess = NULL ) {
        return GDALGenImgProjTransform( hSrcImageTransformer, TRUE, 
                                        nCount, x, y, z, pabSuccess );
    }
};

/************************************************************************/
/*                            LoadCutline()                             */
/*                                                                      */
/*      Load blend cutline from OGR datasource.                         */
/************************************************************************/

int
LoadCutline( const char *pszCutlineDSName, const char *pszCLayer, 
             const char *pszCWHERE, const char *pszCSQL, 
             void **phCutlineRet )

{
//#ifndef OGR_ENABLED
//    CPLError( CE_Failure, CPLE_AppDefined, 
//              "Request to load a cutline failed, this build does not support OGR features./n" );
//    return 1;
//#else // def OGR_ENABLED
//    OGRRegisterAll();

/* -------------------------------------------------------------------- */
/*      Open source vector dataset.                                     */
/* -------------------------------------------------------------------- */
    OGRDataSourceH hSrcDS;

    //hSrcDS = OGROpen( pszCutlineDSName, FALSE, NULL );//
	hSrcDS = OGRSFDriverRegistrar::Open(pszCutlineDSName, FALSE );
    if( hSrcDS == NULL )
        return 1;

/* -------------------------------------------------------------------- */
/*      Get the source layer                                            */
/* -------------------------------------------------------------------- */
    OGRLayerH hLayer = NULL;

    if( pszCSQL != NULL )
         hLayer = OGR_DS_ExecuteSQL( hSrcDS, pszCSQL, NULL, NULL );
	    //hLayer = OGR_DS_ExecuteSQL(hSrcDS,"select * from cutline where size = 100",NULL ,NULL);
    else if( pszCLayer != NULL )
        hLayer = OGR_DS_GetLayerByName( hSrcDS, pszCLayer );
    else
        hLayer = OGR_DS_GetLayer( hSrcDS, 0 );

    if( hLayer == NULL )
    {
        fprintf( stderr, "Failed to identify source layer from datasource./n" );
        return 1;
    }

/* -------------------------------------------------------------------- */
/*      Apply WHERE clause if there is one.                             */
/* -------------------------------------------------------------------- */
    if( pszCWHERE != NULL )
        OGR_L_SetAttributeFilter( hLayer, pszCWHERE );

/* -------------------------------------------------------------------- */
/*      Collect the geometries from this layer, and build list of       */
/*      burn values.                                                    */
/* -------------------------------------------------------------------- */
    OGRFeatureH hFeat;
    OGRGeometryH hMultiPolygon = OGR_G_CreateGeometry( wkbMultiPolygon );

    OGR_L_ResetReading( hLayer );
    
    while( (hFeat = OGR_L_GetNextFeature( hLayer )) != NULL )
    {
        OGRGeometryH hGeom = OGR_F_GetGeometryRef(hFeat);

        if( hGeom == NULL )
        {
            fprintf( stderr, "ERROR: Cutline feature without a geometry./n" );
            return 1;
        }
        
        OGRwkbGeometryType eType = wkbFlatten(OGR_G_GetGeometryType( hGeom ));

        if( eType == wkbPolygon )
            OGR_G_AddGeometry( hMultiPolygon, hGeom );
        else if( eType == wkbMultiPolygon )
        {
            int iGeom;

            for( iGeom = 0; iGeom < OGR_G_GetGeometryCount( hGeom ); iGeom++ )
            {
                OGR_G_AddGeometry( hMultiPolygon, 
                                   OGR_G_GetGeometryRef(hGeom,iGeom) );
            }
        }
        else
        {
            fprintf( stderr, "ERROR: Cutline not of polygon type./n" );
            return 1;
        }

        OGR_F_Destroy( hFeat );
    }

    if( OGR_G_GetGeometryCount( hMultiPolygon ) == 0 )
    {
        fprintf( stderr, "ERROR: Did not get any cutline features./n" );
        return 1;
    }

/* -------------------------------------------------------------------- */
/*      Ensure the coordinate system gets set on the geometry.          */
/* -------------------------------------------------------------------- */
    OGR_G_AssignSpatialReference(
        hMultiPolygon, OGR_L_GetSpatialRef(hLayer) );

    *phCutlineRet = (void *) hMultiPolygon;

/* -------------------------------------------------------------------- */
/*      Cleanup                                                         */
/* -------------------------------------------------------------------- */
    if( pszCSQL != NULL )
        OGR_DS_ReleaseResultSet( hSrcDS, hLayer );

    OGR_DS_Destroy( hSrcDS );
//#endif
}

/************************************************************************/
/*                      TransformCutlineToSource()                      */
/*                                                                      */
/*      Transform cutline from its SRS to source pixel/line coordinates.*/
/************************************************************************/
void TransformCutlineToSource( GDALDatasetH hSrcDS, void *hCutline,
                          char ***ppapszWarpOptions, char **papszTO_In )

{
    OGRGeometryH hMultiPolygon = OGR_G_Clone( (OGRGeometryH) hCutline );
    char **papszTO = CSLDuplicate( papszTO_In );

/* -------------------------------------------------------------------- */
/*      Checkout that SRS are the same.                                 */
/* -------------------------------------------------------------------- */
    OGRSpatialReferenceH  hRasterSRS = NULL;
    const char *pszProjection = NULL;

    if( GDALGetProjectionRef( hSrcDS ) != NULL 
        && strlen(GDALGetProjectionRef( hSrcDS )) > 0 )
        pszProjection = GDALGetProjectionRef( hSrcDS );
    else if( GDALGetGCPProjection( hSrcDS ) != NULL )
        pszProjection = GDALGetGCPProjection( hSrcDS );

    if( pszProjection != NULL )
    {
        hRasterSRS = OSRNewSpatialReference(NULL);
        if( OSRImportFromWkt( hRasterSRS, (char **)&pszProjection ) != CE_None )
        {
            OSRDestroySpatialReference(hRasterSRS);
            hRasterSRS = NULL;
        }
    }

    OGRSpatialReferenceH hCutlineSRS = OGR_G_GetSpatialReference( hMultiPolygon );
    if( hRasterSRS != NULL && hCutlineSRS != NULL )
    {
        /* ok, we will reproject */
    }
    else if( hRasterSRS != NULL && hCutlineSRS == NULL )
    {
        fprintf(stderr,
                "Warning : the source raster dataset has a SRS, but the cutline features/n"
                "not.  We assume that the cutline coordinates are expressed in the destination SRS./n"
                "If not, cutline results may be incorrect./n");
    }
    else if( hRasterSRS == NULL && hCutlineSRS != NULL )
    {
        fprintf(stderr,
                "Warning : the input vector layer has a SRS, but the source raster dataset does not./n"
                "Cutline results may be incorrect./n");
    }

    if( hRasterSRS != NULL )
        OSRDestroySpatialReference(hRasterSRS);

/* -------------------------------------------------------------------- */
/*      Extract the cutline SRS WKT.                                    */
/* -------------------------------------------------------------------- */
    if( hCutlineSRS != NULL )
    {
        char *pszCutlineSRS_WKT = NULL;

        OSRExportToWkt( hCutlineSRS, &pszCutlineSRS_WKT );
        papszTO = CSLSetNameValue( papszTO, "DST_SRS", pszCutlineSRS_WKT );
        CPLFree( pszCutlineSRS_WKT );
    }
	/* -------------------------------------------------------------------- */
/*      Transform the geometry to pixel/line coordinates.               */
/* -------------------------------------------------------------------- */
    CutlineTransformer oTransformer;

    /* The cutline transformer will *invert* the hSrcImageTransformer */
    /* so it will convert from the cutline SRS to the source pixel/line */
    /* coordinates */
    oTransformer.hSrcImageTransformer = 
        GDALCreateGenImgProjTransformer2( hSrcDS, NULL, papszTO );

    CSLDestroy( papszTO );

    if( oTransformer.hSrcImageTransformer == NULL )
        //return 1;

    OGR_G_Transform( hMultiPolygon, 
                     (OGRCoordinateTransformationH) &oTransformer );

    GDALDestroyGenImgProjTransformer( oTransformer.hSrcImageTransformer );

/* -------------------------------------------------------------------- */
/*      Convert aggregate geometry into WKT.                            */
/* -------------------------------------------------------------------- */
    char *pszWKT = NULL;

    OGR_G_ExportToWkt( hMultiPolygon, &pszWKT );
    OGR_G_DestroyGeometry( hMultiPolygon );

    *ppapszWarpOptions = CSLSetNameValue( *ppapszWarpOptions, 
                                          "CUTLINE", pszWKT );
    CPLFree( pszWKT );
}



bool Projection2ImageRowCol(double *adfGeoTransform, double dProjX, double dProjY, int &iCol, int &iRow)
{
	try
	{
		double dTemp = adfGeoTransform[1]*adfGeoTransform[5] - adfGeoTransform[2]*adfGeoTransform[4];
		double dCol = 0.0, dRow = 0.0;
		dCol = (adfGeoTransform[5]*(dProjX - adfGeoTransform[0]) - 
			adfGeoTransform[2]*(dProjY - adfGeoTransform[3])) / dTemp + 0.5;
		dRow = (adfGeoTransform[1]*(dProjY - adfGeoTransform[3]) - 
			adfGeoTransform[4]*(dProjX - adfGeoTransform[0])) / dTemp + 0.5;

		iCol = static_cast<int>(dCol);
		iRow = static_cast<int>(dRow);
		return true;
	}
	catch(...)
	{
		return false;
	}
}

bool ImageRowCol2Projection(double *adfGeoTransform, int iCol, int iRow, double &dProjX, double &dProjY)
{
	//adfGeoTransform[6]  数组adfGeoTransform保存的是仿射变换中的一些参数，分别含义见下
	//adfGeoTransform[0]  左上角x坐标 
	//adfGeoTransform[1]  东西方向分辨率
	//adfGeoTransform[2]  旋转角度, 0表示图像 "北方朝上"
	//adfGeoTransform[3]  左上角y坐标 
	//adfGeoTransform[4]  旋转角度, 0表示图像 "北方朝上"
	//adfGeoTransform[5]  南北方向分辨率

	try
	{
		dProjX = adfGeoTransform[0] + adfGeoTransform[1] * iCol + adfGeoTransform[2] * iRow;
		dProjY = adfGeoTransform[3] + adfGeoTransform[4] * iCol + adfGeoTransform[5] * iRow;
		return true;
	}
	catch(...)
	{
		return false;
	}
}


/**
* @brief AOI截图(GDAL)
* @param pszInFile        	输入文件的路径
* @param pszOutFile        	截图后输出文件的路径
* @param pszAOIFile        	AOI文件路径
* @param pszSQL            	指定AOI文件中的属性字段值来裁剪
* @param pBandInex        	指定裁剪的波段，默认为NULL，表示裁剪所有波段
* @param piBandCount    	指定裁剪波段的个数，同上一个参数同时使用
* @param iBuffer        	指定AOI文件外扩范围，默认为0，表示不外扩
* @param pszFormat        	截图后输出文件的格式
* @param pProgress        	进度条指针
* @return 成功返回
*/ 
int CutImageByAOIGDAL(const char* pszInFile, const char* pszOutFile, const char* pszAOIFile, const char* pszSQL, 
    int *pBandInex, int *piBandCount, int iBuffer, const char* pszFormat/*, LT_Progress *pProgress*/)
{
    /*if(pProgress != NULL)
    {
        pProgress->SetProgressCaption("AOI裁剪");
        pProgress->SetProgressTip("开始裁剪图像...");
    }*/

    GDALAllRegister();
    void *hCutline = NULL;//hCutLine

	int iRev=LoadCutline( pszAOIFile, "", "", pszSQL, &hCutline );

	//int iRev=LoadCutline( pszAOIFile, "cutline", pszSQL, NULL, &hCutline );  


    GDALDataset * pSrcDS = (GDALDataset*) GDALOpen(pszInFile, GA_ReadOnly);
    if (pSrcDS == NULL)
    {
        /*if (pProgress != NULL)
            pProgress->SetProgressTip("输入的栅格文件不能打开，请检查文件是否存在！");*/

        return -3;
    }
    
    int iBandCount = pSrcDS->GetRasterCount();
    const char* pszWkt = pSrcDS->GetProjectionRef();
    GDALDataType dT = pSrcDS->GetRasterBand(1)->GetRasterDataType();

    double adfGeoTransform[6] = {0};
    double newGeoTransform[6] = {0};

    pSrcDS->GetGeoTransform(adfGeoTransform);
    memcpy(newGeoTransform, adfGeoTransform, sizeof(double)*6);

    int *pSrcBand = NULL;
    int iNewBandCount = iBandCount;
    if (pBandInex != NULL && piBandCount != NULL)
    {
        int iMaxBandIndex = pBandInex[0];
        for (int i=1; i<*piBandCount; i++)
        {
            if (iMaxBandIndex < pBandInex[i])
                iMaxBandIndex = pBandInex[i];
        }

        if (iMaxBandIndex > iBandCount)
        {
            //if (pProgress != NULL)
            //    pProgress->SetProgressTip("输入的波段序号没有指定的波段数！");

            GDALClose((GDALDatasetH) pSrcDS);
            return -4;
        }

        iNewBandCount = *piBandCount;
        pSrcBand = new int[iNewBandCount];
        for (int i=0; i<iNewBandCount; i++)
            pSrcBand[i] = pBandInex[i];
    }
    else
    {
        pSrcBand = new int[iNewBandCount];
        for (int i=0; i<iNewBandCount; i++)
            pSrcBand[i] = i+1;
    }

    OGRGeometryH hGeometry = (OGRGeometryH) hCutline;
    OGRGeometryH hMultiPoly = NULL;
    if (iBuffer > 0)
    {
        double dDistance = ABS(adfGeoTransform[1]*iBuffer);
        hMultiPoly = OGR_G_Buffer(hGeometry, dDistance, 30);
        OGR_G_AssignSpatialReference(hMultiPoly, OGR_G_GetSpatialReference(hGeometry));
        OGR_G_DestroyGeometry(hGeometry);
    }
    else
        hMultiPoly = hGeometry;

    OGREnvelope eRect;
    OGR_G_GetEnvelope(hMultiPoly, &eRect);

    int iNewWidth = 0, iNewHeigh = 0;
    int iBeginRow = 0, iBeginCol = 0;

    newGeoTransform[0] = eRect.MinX;
    newGeoTransform[3] = eRect.MaxY;

    iNewWidth = static_cast<int>((eRect.MaxX -eRect.MinX) / ABS(adfGeoTransform[1]));
    iNewHeigh = static_cast<int>((eRect.MaxY -eRect.MinY) / ABS(adfGeoTransform[5]));

    Projection2ImageRowCol(adfGeoTransform, newGeoTransform[0], newGeoTransform[3], iBeginCol, iBeginRow);
    ImageRowCol2Projection(adfGeoTransform, iBeginCol, iBeginRow, newGeoTransform[0], newGeoTransform[3]);

    GDALDriver *pDriver = GetGDALDriverManager()->GetDriverByName(pszFormat);
    if (pDriver == NULL)
    {
        //if (pProgress != NULL)
        //    pProgress->SetProgressTip("不能创建指定类型的文件！");

        GDALClose((GDALDatasetH) pSrcDS);
        return -3;
    }

    GDALDataset* pDstDS = pDriver->Create(pszOutFile, iNewWidth, iNewHeigh, iNewBandCount, dT, NULL);
    if (pDstDS == NULL)
    {
        //if (pProgress != NULL)
        //    pProgress->SetProgressTip("创建文件失败！");

        GDALClose((GDALDatasetH) pSrcDS);
        return -1;
    }

    pDstDS->SetGeoTransform(newGeoTransform);
    pDstDS->SetProjection(pszWkt);

    void *hTransformArg, *hGenImgProjArg=NULL;
    char **papszTO = NULL;
    /* -------------------------------------------------------------------- */
    /*      Create a transformation object from the source to               */
    /*      destination coordinate system.                                  */
    /* -------------------------------------------------------------------- */
    hTransformArg = hGenImgProjArg = 
        GDALCreateGenImgProjTransformer2( pSrcDS, (GDALDatasetH)pDstDS, papszTO );

    if( hTransformArg == NULL )
    {
        //if (pProgress != NULL)
        //    pProgress->SetProgressTip("创建投影失败，请检查输入参数！");

        GDALClose((GDALDatasetH) pSrcDS);
        GDALClose((GDALDatasetH) pDstDS);

        //RELEASE(pSrcBand);
		delete pSrcBand;
        return -4;
    }

    GDALTransformerFunc pfnTransformer = GDALGenImgProjTransform;
    GDALWarpOptions *psWO = GDALCreateWarpOptions();

    psWO->papszWarpOptions = CSLDuplicate(NULL);
    psWO->eWorkingDataType = dT;
    psWO->eResampleAlg = GRA_Bilinear ;

    psWO->hSrcDS = (GDALDatasetH) pSrcDS;
    psWO->hDstDS = (GDALDatasetH) pDstDS;

    psWO->pfnTransformer = pfnTransformer;
    psWO->pTransformerArg = hTransformArg;

    psWO->pfnProgress = NULL;//GDALProgress
    psWO->pProgressArg = NULL;//pProgress

    psWO->nBandCount = iNewBandCount;
    psWO->panSrcBands = (int *) CPLMalloc(iNewBandCount*sizeof(int));
    psWO->panDstBands = (int *) CPLMalloc(iNewBandCount*sizeof(int));
    for (int i=0; i<iNewBandCount; i++)
    {
        psWO->panSrcBands[i] = pSrcBand[i];
        psWO->panDstBands[i] = i+1;
    }

    //RELEASE(pSrcBand);
	delete pSrcBand;
    
    psWO->hCutline = (void*) hMultiPoly;
    TransformCutlineToSource((GDALDatasetH) pSrcDS, (void*)hMultiPoly, &(psWO->papszWarpOptions), papszTO );

    GDALWarpOperation oWO;
    if (oWO.Initialize(psWO) != CE_None)
    {
        GDALClose((GDALDatasetH) pSrcDS);
        GDALClose((GDALDatasetH) pDstDS);

        return -4;
    }

    oWO.ChunkAndWarpImage(0, 0, iNewWidth, iNewHeigh);

    GDALDestroyGenImgProjTransformer(psWO->pTransformerArg);
    GDALDestroyWarpOptions( psWO );
    GDALClose((GDALDatasetH) pSrcDS);
    GDALClose((GDALDatasetH) pDstDS);

    //if(pProgress != NULL)
    //    pProgress->SetProgressTip("图像裁剪完成！");

    return 0;
}


int main()
{
    //注册文件格式
    GDALAllRegister();
	OGRRegisterAll();
CPLSetConfigOption("GDAL_DATA", "E:\\work\\dview_bj\\CutImage\\CutImage\\data"); 
    
    const char* pszAOIFile = "C:\\cutdata\\cutline.shp";
	const char* pszInFile="C:\\cutdata\\wasia(tif).tif";
	const char* pszOutFile="C:\\cutdata\\cuted.tif";
	//const char* 
	//OGRDataSource *poDS = OGRSFDriverRegistrar::Open(pszAOIFile, FALSE );

	//CutImageByAOIGDAL(const char* pszInFile, const char* pszOutFile, const char* pszAOIFile, const char* pszSQL, 
	//    int *pBandInex, int *piBandCount, int iBuffer, const char* pszFormat
	//CutImageByAOIGDAL(pszInFile,pszOutFile, pszAOIFile,"size = 100",NULL,NULL,0,"GTiff");
	CutImageByAOIGDAL(pszInFile,pszOutFile, pszAOIFile,"select * from cutline where size = 100",NULL,NULL,0,"GTiff");
	getchar();//"select * from cutline where size = 100"
}