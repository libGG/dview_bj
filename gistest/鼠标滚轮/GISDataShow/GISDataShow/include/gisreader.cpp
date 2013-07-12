#include "StdAfx.h"
#include "GISReader.h"
CColorTable::CColorTable()
{
}
CColorTable::~CColorTable()
{
}
int CColorTable::GetCount()
{
	return els.GetSize();
}
int CColorTable::GetR(int index)
{
	return els.GetAt(index).r;
}
int CColorTable::GetG(int index)
{
	return els.GetAt(index).g;
}
int CColorTable::GetB(int index)
{
	return els.GetAt(index).b;
}

CReaderEnvi::CReaderEnvi()
{
    
}
CReaderEnvi::~CReaderEnvi()
{

}
void CReaderEnvi::InitialEnvi()
{
    GDALAllRegister();
	OGRRegisterAll();
	CFilePath pPath;
	CString Dir=pPath.GetCurrentDir();
	pPath.SetFilePath(Dir);
	CPLSetConfigOption("GDAL_DATA", pPath.GetDir()+"\\Proj"); 
}
CRasterReader::CRasterReader()
{
	poDataset=NULL;
	pColorTable=NULL;
	LoadedRect=CRect(-1,-1,-1,-1);
}
CRasterReader::~CRasterReader()
{
	if(poDataset!=NULL) delete poDataset;
	if(pColorTable!=NULL) delete pColorTable;
}
bool CRasterReader::OpenRaster(CString PathName)
{
    ErrorInfo="";
	NotifyRasterOpening();
	if(poDataset!=NULL) delete poDataset;
    poDataset=(GDALDataset*)GDALOpen(PathName,GA_ReadOnly);
	if(poDataset==NULL)
	{
       nXSize=nYSize=BandCount=0;
	   ErrorInfo="读取栅格数据失败!";
	   return false;
	}

    GDALDriver * driver=poDataset->GetDriver ();
    const char* papszMetadata=GDALGetDriverShortName((GDALDriverH)poDataset);  
	CString sMeta=(CString)papszMetadata;
    
	//int index=sMeta.Find("hdf");
    //if(index<0)
        //index=sMeta.Find("HDF");
	 //if(index)
    //{
        char ** SUBDATASETS = GDALGetMetadata( (GDALDatasetH)poDataset, "SUBDATASETS" );
        if( CSLCount(SUBDATASETS) > 0 )
        {
            for(int  i = 0; SUBDATASETS[i] != NULL; i++ )
			{
                 CString tmpstr=CString(SUBDATASETS[i]);
			}
			
			
			for(int  i = 0; SUBDATASETS[i] != NULL; i++ )
            {
                if(i%2==0)
                {
                    CString tmpstr=CString(SUBDATASETS[i]);
                    tmpstr=tmpstr.Right(tmpstr.GetLength()-tmpstr.Find("=")-1);
                    GDALDataset * tmpdt=(GDALDataset *) GDALOpen(tmpstr.GetBuffer(tmpstr.GetLength()), GA_ReadOnly);
                    int Count=tmpdt->GetRasterCount();
					GDALRasterBand*pBand=tmpdt->GetRasterBand(1);
					float*pData=new float[tmpdt->GetRasterXSize()];
                    CPLErr pErr=pBand->RasterIO(GF_Read,0,0,tmpdt->GetRasterXSize(),1,pData,tmpdt->GetRasterXSize(),1,GDT_Float32,0, 0);
                    delete []pData;
					nXSize=tmpdt->GetRasterXSize();
	                nYSize=tmpdt->GetRasterYSize();
                    delete tmpdt;


                }            
            }
        }
        else
        {
            int bandCount=poDataset->GetRasterCount();
            if(bandCount>0)
            {
                	
            }
        }
   // }
    

	nXSize=poDataset->GetRasterXSize();
	nYSize=poDataset->GetRasterYSize();
	poDataset->GetGeoTransform( adfGeoTransform );
	if(adfGeoTransform[5]>0) 
	{
		adfGeoTransform[3]=adfGeoTransform[3]+adfGeoTransform[5]*nYSize;
		adfGeoTransform[5]=-adfGeoTransform[5];
	}
	BandCount=poDataset->GetRasterCount();
    if(BandCount==0) return false;
	lpszPathName=PathName;
	return true;
}
int CRasterReader:: GetBandCountFromPath(CString PathName)
{
    GDALDataset*poDataset=(GDALDataset*)GDALOpen(PathName,GA_ReadOnly);
	if(poDataset==NULL)
	{
        return 0;
	}
	int BandCount=poDataset->GetRasterCount();
	delete poDataset;
	return BandCount;
}
int CRasterReader::GetCols()
{
	return nXSize;
}
int CRasterReader::GetRows()
{
	return nYSize;
}
int CRasterReader::GetBandCount()
{
	return BandCount;
}
OGRSpatialReference*CRasterReader::GetSpatialRef()
{
	ErrorInfo="";
	if(poDataset==NULL)
	{
		ErrorInfo="请先通过OpenRaster读取栅格数据!";
		return NULL;
	}
	const char*info=poDataset->GetProjectionRef();
	CString sInfo=info;
	char*inf=sInfo.GetBuffer(sInfo.GetLength());
    pSpatial.importFromWkt(&inf);
	return &pSpatial;
}
bool CRasterReader::GetExtent(double&XMin,double&YMin,double&XMax,double&YMax)
{
     ErrorInfo="";
	 if(poDataset==NULL)
	 {
		ErrorInfo="请先通过OpenRaster读取栅格数据!";
		return NULL;
	 }
	 XMin=adfGeoTransform[0];
	 YMin=adfGeoTransform[3]+adfGeoTransform[5]*nYSize;
	 XMax=adfGeoTransform[0]+nXSize*adfGeoTransform[1];
	 YMax=adfGeoTransform[3];
	 return true;
}
bool CRasterReader::GetBandData(int band,int&formerbufx,int&formerbufy,float**data)
{
    ErrorInfo="";
	if(poDataset==NULL)
	{
		ErrorInfo="请先通过OpenRaster读取栅格数据!";
		return false;
	}
	GDALRasterBand *poBand;
    poBand=poDataset->GetRasterBand(band);
	if(*data==NULL)
	   *data = (float *) CPLMalloc(sizeof(float)*nXSize*sizeof(float)*nYSize);
	else if((formerbufx!=nXSize)&&(formerbufy!=nYSize))
	{
        CPLFree(*data);
		*data=NULL;
		*data = (float *) CPLMalloc(sizeof(float)*nXSize*sizeof(float)*nYSize);
	}
	formerbufx=nXSize;
	formerbufy=nYSize;
	LoadedRect=CRect(0,0,nXSize,nYSize);
    if(poBand->RasterIO(GF_Read, 0, 0, nXSize, nYSize,*data,nXSize, nYSize, GDT_Float32,0, 0 )!=CE_None )
	{
		ErrorInfo="读取波段数据失败!";
		return false;
	}
    return true;
}
bool CRasterReader::GetBandData(int band,int fromx,int fromy,int width,int height,int bufx,int bufy,int&formerbufx,int&formerbufy,float**data)
{
    ErrorInfo="";
	if(poDataset==NULL)
	{
		ErrorInfo="请先通过OpenRaster读取栅格数据!";
		return false;
	}
	GDALRasterBand *poBand;
    poBand=poDataset->GetRasterBand(band);
	if(*data==NULL)
	   *data = (float *) CPLMalloc(sizeof(float)*bufx*sizeof(float)*bufy);
	else if((formerbufx!=bufx)||(formerbufy!=bufy))
	{
        CPLFree(*data);
		*data=NULL;
		*data = (float *) CPLMalloc(sizeof(float)*bufx*sizeof(float)*bufy);
	} 
    formerbufx=bufx;
	formerbufy=bufy;
	LoadedRect=CRect(fromx,fromy,fromx+width,fromy+height);
	if(poBand->RasterIO(GF_Read, fromx, fromy, width, height,*data,bufx,bufy, GDT_Float32,0, 0 )!=CE_None )
	{
		ErrorInfo="读取波段数据失败!";
		return false;
	}
    return true;
}
long CRasterReader::GetPixelCol(double x)
{
	int px=(x-adfGeoTransform[0])/adfGeoTransform[1];
	if(x<adfGeoTransform[0])
	{
	   return px-1;
	}
	return px;
}
long CRasterReader::GetPixelRow(double y)
{
    int py=(y-adfGeoTransform[3])/adfGeoTransform[5];
	if(adfGeoTransform[3]<y)
	{
	   return py-1;
	}
	return py;
}
long CRasterReader::GetPixelRealCol(double x)
{
    return (x-adfGeoTransform[0])/adfGeoTransform[1];
}
long CRasterReader::GetPixelRealRow(double y)
{
    return (y-adfGeoTransform[3])/adfGeoTransform[5];
}
float CRasterReader::GetPixelCenterX(long rx)
{
    return adfGeoTransform[0]+rx*adfGeoTransform[1]+adfGeoTransform[1]/2;
}
float CRasterReader::GetPixelCenterY(long ry)
{
    return adfGeoTransform[3]+ry*adfGeoTransform[5]+adfGeoTransform[5]/2;
}
float CRasterReader::GetMapX(float rx)
{
	return adfGeoTransform[0]+rx*adfGeoTransform[1];
}
float CRasterReader::GetMapY(float ry)
{
    return adfGeoTransform[3]+ry*adfGeoTransform[5];
}
double CRasterReader::GetCellSize()
{
	return fabs(adfGeoTransform[1]);
}
double CRasterReader::GetLeft()
{
	return adfGeoTransform[0];
}
double CRasterReader::GetBottom()
{
    return adfGeoTransform[3]+adfGeoTransform[5]*nYSize;
}
CColorTable*CRasterReader::GetColorTable(int band)
{
    if(pColorTable!=NULL) delete pColorTable;
    pColorTable=NULL;
	ErrorInfo="";
	if(poDataset==NULL)
	{
		ErrorInfo="请先通过OpenRaster读取栅格数据!";
		return NULL;
	}
    GDALRasterBand  *poBand;
    poBand=poDataset->GetRasterBand(band);
	GDALColorTable*gct=poBand->GetColorTable();
	if(gct==NULL) return NULL;
    pColorTable=new CColorTable;
	int Size=gct->GetColorEntryCount();
	for(int k=0;k<Size;k++)
	{
		GDALColorEntry gce;
        gct->GetColorEntryAsRGB(k,&gce);
        RGBColor nc;
		nc.r=gce.c1;
		nc.g=gce.c2;
		nc.b=gce.c3;
		pColorTable->els.Add(nc);
	}
	return pColorTable;
}
CString CRasterReader::GetErrorInfo()
{
    return ErrorInfo;
}
CGrayRasterReader::CGrayRasterReader()
{
    CurrentBand=-1;
	data=NULL;
	BuffXSize=0;
	BuffYSize=0;
}
CGrayRasterReader::~CGrayRasterReader()
{
    if(data!=NULL) CPLFree(data);
}
void CGrayRasterReader::NotifyRasterOpening()
{
    if(data!=NULL) CPLFree(data);
	data=NULL;
    CurrentBand=-1;
}
bool CGrayRasterReader::LoadBandData(int band)
{
	if((band==CurrentBand)&&(BuffXSize==nXSize)&&(BuffYSize==nYSize)&&(LoadedRect==CRect(0,0,nXSize,nYSize))) return true;
	CurrentBand=-1;
	if(!GetBandData(band,BuffXSize,BuffYSize,&data)) return false;
	CurrentBand=band;
    return true;
}
bool CGrayRasterReader::LoadBandData(int band,int fromx,int fromy,int width,int height,int bufx,int bufy)
{
    if((band==CurrentBand)&&(BuffXSize==bufx)&&(BuffYSize==bufy)&&(LoadedRect==CRect(fromx,fromy,fromx+width,fromy+height))) return true;
	CurrentBand=-1;
	if(!GetBandData(band,fromx,fromy,width,height,bufx,bufy,BuffXSize,BuffYSize,&data)) return false;
	CurrentBand=band;
    return true;
}
float*CGrayRasterReader::GetGrayBandData()
{ 
    return data;
}
CRGBRasterReader::CRGBRasterReader()
{
    for(int k=0;k<3;k++) CurrentBand[k]=-1;
    rdata=NULL;gdata=NULL;bdata=NULL;
	for(int k=0;k<3;k++)
	{
		BuffXSize[k]=0;
		BuffYSize[k]=0;
	}
}
CRGBRasterReader::~CRGBRasterReader()
{
    if(rdata!=NULL) CPLFree(rdata);
    if(gdata!=NULL) CPLFree(gdata);
	if(bdata!=NULL) CPLFree(bdata);
}
void CRGBRasterReader::NotifyRasterOpening()
{
    if(rdata!=NULL) CPLFree(rdata);
    if(gdata!=NULL) CPLFree(gdata);
	if(bdata!=NULL) CPLFree(bdata);
    rdata=NULL;gdata=NULL;bdata=NULL;
    for(int k=0;k<3;k++) CurrentBand[k]=-1;
}
bool CRGBRasterReader::LoadBandData(int*band)
{
	for(int k=0;k<3;k++) CurrentBand[k]=-1;
	if(!GetBandData(band[0],BuffXSize[0],BuffYSize[0],&rdata)) return false;
    if(!GetBandData(band[1],BuffXSize[1],BuffYSize[1],&gdata)) return false;
	if(!GetBandData(band[2],BuffXSize[2],BuffYSize[2],&bdata)) return false;
	for(int k=0;k<3;k++) CurrentBand[k]=band[k];
    return true;
}
bool CRGBRasterReader::LoadBandData(int*band,int fromx,int fromy,int width,int height,int bufx,int bufy)
{
    for(int k=0;k<3;k++) CurrentBand[k]=-1;
	if(!GetBandData(band[0],fromx,fromy,width,height,bufx,bufy,BuffXSize[0],BuffYSize[0],&rdata)) return false;
    if(!GetBandData(band[1],fromx,fromy,width,height,bufx,bufy,BuffXSize[1],BuffYSize[1],&gdata)) return false;
	if(!GetBandData(band[2],fromx,fromy,width,height,bufx,bufy,BuffXSize[2],BuffYSize[2],&bdata)) return false;
	for(int k=0;k<3;k++) CurrentBand[k]=band[k];
    return true;
}
float*CRGBRasterReader::GetRBandData()
{ 
    return rdata;
}
float*CRGBRasterReader::GetGBandData()
{ 
    return gdata;
}
float*CRGBRasterReader::GetBBandData()
{ 
    return bdata;
}
CVectorReader::CVectorReader()
{
    poDS=NULL;
	poLayer=NULL;
	pSpatial=NULL;
	poFeature=NULL;
}
CVectorReader::~CVectorReader()
{
	if(poFeature!=NULL) OGRFeature::DestroyFeature(poFeature);
	if(poDS!=NULL) OGRDataSource::DestroyDataSource(poDS);
}
bool CVectorReader::OpenVector(CString PathName)
{
    if(poFeature!=NULL) OGRFeature::DestroyFeature(poFeature);
	if(poDS!=NULL) OGRDataSource::DestroyDataSource(poDS);
	poDS=NULL;
	poLayer=NULL;
	lpszPathName=PathName;
	ErrorInfo="";
	pSpatial=NULL;
	FieldNames.RemoveAll();
	FieldTypes.RemoveAll();
	FieldWidths.RemoveAll();
	FieldPrecisions.RemoveAll();
	poDS = OGRSFDriverRegistrar::Open(PathName, FALSE );
    if( poDS == NULL )
    {
        ErrorInfo="打开矢量文件失败";
        return false;
    }
	CFilePath pPath(lpszPathName);
    poLayer=poDS->GetLayerByName(pPath.GetFileNameNoExa());
	if(poLayer==NULL)
	{
        if(poDS!=NULL) OGRDataSource::DestroyDataSource(poDS);
	    poDS=NULL;
        ErrorInfo="打开矢量文件失败";
        return false;
	}
	poLayer->ResetReading();
    OGRFeatureDefn*poFDefn = poLayer->GetLayerDefn();
	pSpatial=poLayer->GetSpatialRef();
    int Count=poFDefn->GetFieldCount();
	for(int k=0;k<Count;k++)
	{
		OGRFieldDefn*pDef=poFDefn->GetFieldDefn(k);
		FieldNames.Add(pDef->GetNameRef());
		FieldTypes.Add(pDef->GetType());
		FieldWidths.Add(pDef->GetWidth());
		FieldPrecisions.Add(pDef->GetPrecision());
	}
	return true;
}
OGRSpatialReference*CVectorReader::GetSpatialRef()
{
	return pSpatial;
}
GeometryType CVectorReader::GetShapeType()
{
    ErrorInfo="";
	if(poLayer==NULL) 
	{
		ErrorInfo="无合法的矢量文件";
		return gUnknown;
	}
	OGRFeatureDefn*poFDefn = poLayer->GetLayerDefn();
    OGRwkbGeometryType type=poFDefn->GetGeomType();
	switch(type)
	{
	case wkbPoint :
		return gPoint;
	case wkbMultiPoint :
		return gPoints;
	case wkbLineString:
		return gPolyline;
	case wkbPolygon:
		return gPolygon;
	case wkbMultiPolygon:
		return gMultiPolygon;
	case wkbGeometryCollection:
		return gCollection;
	default:
		return gUnknown;
	}
	return gUnknown;
}
bool CVectorReader::SetSpatialFilterRect(double dfMinX, double dfMinY, double dfMaxX, double dfMaxY)
{
    ErrorInfo="";
	if(poLayer==NULL) 
	{
		ErrorInfo="无合法的矢量文件";
		return false;
	}
	if(poFeature!=NULL) OGRFeature::DestroyFeature(poFeature);
	poFeature=NULL;
	poLayer->SetSpatialFilterRect(dfMinX,dfMinY,dfMaxX,dfMaxY);
	poLayer->ResetReading();
	return true;
}
bool CVectorReader::GetExtent(double&XMin,double&YMin,double&XMax,double&YMax)
{
	ErrorInfo="";
	if(poLayer==NULL) 
	{
		ErrorInfo="无合法的矢量文件";
		return false;
	}
	OGREnvelope pEnv;
	poLayer->GetExtent(&pEnv);
	XMin=pEnv.MinX;
	YMin=pEnv.MinY;
	XMax=pEnv.MaxX;
	YMax=pEnv.MaxY;
	return true;
}
bool CVectorReader::ResetReadering()
{
	if(poLayer==NULL) 
	{
		ErrorInfo="无合法的矢量文件";
		return false;
	}
    poLayer->ResetReading();
	ErrorInfo="";
	return true;
}
bool CVectorReader::MoveNext()
{
    if(poFeature!=NULL) OGRFeature::DestroyFeature(poFeature);
	poFeature=NULL;
	poFeature=poLayer->GetNextFeature();
	return (poFeature!=NULL);
}
bool CVectorReader::Move(long index)
{
    if(poFeature!=NULL) OGRFeature::DestroyFeature(poFeature);
	poFeature=NULL;
	poLayer->ResetReading();
	if(index>0) poLayer->SetNextByIndex(index-1);
	poFeature=poLayer->GetNextFeature();
	return (poFeature!=NULL);
}
OGRGeometry*CVectorReader::GetCurrentOrginFeatureShape()
{
    return poFeature->GetGeometryRef();
}
CGeometryDef*CVectorReader::GetCurrentFeatureShape()
{
    CGeometryFactory pf;
	if(poFeature->GetGeometryRef()==NULL) return NULL;
	return pf.CreateGeometry(poFeature->GetGeometryRef());
}
CString CVectorReader::GetCurrentFieldValueAsString(int iField)
{
    return poFeature->GetFieldAsString(iField);
}
bool CVectorReader::GetFeatureCount(long&Count)
{
    if(poLayer==NULL) 
	{
		ErrorInfo="无合法的矢量文件";
		return false;
	}
	ErrorInfo="";
	Count=poLayer->GetFeatureCount();
	return true;
}
long CVectorReader::GetFieldCount()
{
	return FieldNames.GetSize();
}
CString CVectorReader::GetFieldName(long index)
{
	return FieldNames.GetAt(index);
}
OGRFieldType CVectorReader::GetFieldType(long index)
{
	return FieldTypes.GetAt(index);
}
int CVectorReader::GetFieldWidth(long index)
{
	return FieldWidths.GetAt(index);
}
int CVectorReader::GetFieldPrecision(long index)
{
	return FieldPrecisions.GetAt(index);
}
CString CVectorReader::GetErrorInfo()
{
	return ErrorInfo;
}
