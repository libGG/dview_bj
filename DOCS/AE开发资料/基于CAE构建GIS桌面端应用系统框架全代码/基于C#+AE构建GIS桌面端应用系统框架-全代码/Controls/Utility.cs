using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.Carto;

using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Utility;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.Analyst3D;
//using ESRI.ArcGIS.MapControl;

namespace Controls
{
	/// <summary>
	/// Utility 的摘要说明。
	/// </summary>
	public class Utility
	{
        private static IArray m_SewerElevStructArray;

		public Utility()
		{
			//
			// TODO: 在此处添加构造函数逻辑
            
			//
		}
         
		
		//打开shape文件


		public static IFeatureClass  OpenFeatureClassFromShapefile(string sPath,string sShapeName)

		{

			IFeatureClass rltFClass=null;
			IWorkspaceFactory pWSFact;
			IWorkspace pWS;
            IFeatureWorkspace pFWS;



  
			try
			{
				pWSFact=new ShapefileWorkspaceFactoryClass();
				pWS=pWSFact.OpenFromFile(sPath,0);
				pFWS = pWS as IFeatureWorkspace;
				rltFClass=pFWS.OpenFeatureClass(sShapeName);


			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
				return null;
			}

			return rltFClass;

	
		
		}
        //打开工作区间
        public static IWorkspace OpenWorkspace(string strWorkspaceName)
        {
            IWorkspaceFactory workspaceFactory;
            workspaceFactory = new ShapefileWorkspaceFactory();
            return workspaceFactory.OpenFromFile(strWorkspaceName, 0);
        }
        //打开网络数据集
        public static INetworkDataset OpenNetworkDataset(IWorkspace workspace, string strNDSName)
        {
            IWorkspaceExtensionManager workspaceExtensionManager;
            IWorkspaceExtension workspaceExtension;
            IDatasetContainer2 datasetContainer2;
            INetworkDataset pNetDataset;
            // Get Workspace Extension
            workspaceExtensionManager = workspace as IWorkspaceExtensionManager;
            int count = workspaceExtensionManager.ExtensionCount;
            for (int i = 0; i < count; i++)
            {
                workspaceExtension = workspaceExtensionManager.get_Extension(i);
                if (workspaceExtension.Name.Equals("Network Dataset"))
                {
                    datasetContainer2 = workspaceExtension as IDatasetContainer2;
                    pNetDataset= datasetContainer2.get_DatasetByName(esriDatasetType.esriDTNetworkDataset, strNDSName) as INetworkDataset;
                    return pNetDataset;
                }
            }
            return null;
        }
        //打开几何网络数据集
        public static IGeometricNetwork openGeoNetwork(string sPath, string sFeatDatasetName, string sNetDataName)
        {
            //string fpath = @"C:\ArcGIS91_Demos\Sewer9\data\sewer3.mdb";
            
            IFeatureWorkspace pFWS = Utility.openPDB(sPath);
            IFeatureDataset pFdataset = pFWS.OpenFeatureDataset(sFeatDatasetName);
            INetworkCollection pNetworkCollection = pFdataset as INetworkCollection;
            //得到Sewer Network进行TRACE
            IGeometricNetwork pGeometricNetwork = pNetworkCollection.get_GeometricNetworkByName(sNetDataName);
            return pGeometricNetwork;
        }
        //获得ＤＥ网络数据集
        public static IDENetworkDataset GetDENetworkDataset(INetworkDataset networkDataset)
        {
            //QI from the Network Dataset to the DatasetComponent
            IDatasetComponent dsComponent;
            dsComponent = networkDataset as IDatasetComponent;

            //Get the Data Element
            return dsComponent.DataElement as IDENetworkDataset;
        }
        //创建解决器上下文
        public static INAContext CreateSolverContext(INetworkDataset networkDataset,string ServiceType)
        {
            //Get the Data Element
            IDENetworkDataset deNDS = GetDENetworkDataset(networkDataset);

            INASolver naSolver=null;
            switch (ServiceType)
            {
                case "路线":
                    naSolver = new NARouteSolverClass();
                    break;
                case "服务":
                    naSolver = new NAServiceAreaSolverClass();
                    break;
                case "设施":
                    naSolver = new NAClosestFacilitySolverClass();
                    break;
                case "费用":
                    naSolver = new NAODCostMatrixSolverClass();
                    break;
            }
             
            INAContextEdit contextEdit = naSolver.CreateContext(deNDS, naSolver.Name) as INAContextEdit;
            contextEdit.Bind(networkDataset, new GPMessagesClass());
            return contextEdit as INAContext;
        }
		public static IWorkspace setRasterWorkspace(string sPath)
		{

			 IWorkspaceFactory pWSF;
			 pWSF=new RasterWorkspaceFactoryClass() as IWorkspaceFactory;
			// if(pWSF.IsWorkspace(sPath)){

 			  return pWSF.OpenFromFile(sPath, 0) as IWorkspace;

			  //}
			//else
			//	 return null;

				  
		}
        //设置特征转换栅格分析环境
        public static IConversionOp SetFeatToRasterAnalysisEnv(string rasterpath, double cellsize, IFeatureLayer pFeatLayer)
        {
            object Missing = Type.Missing;
            IWorkspace pWorkspace = Utility.setRasterWorkspace(rasterpath);
            IConversionOp pConversionOp = new RasterConversionOpClass();
            IRasterAnalysisEnvironment pRsEnv = pConversionOp as IRasterAnalysisEnvironment;
            pRsEnv.OutWorkspace = pWorkspace;
            //装箱操作
            object objCellSize = cellsize;

            pRsEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref objCellSize);

            IEnvelope pEnv = new EnvelopeClass();
            pEnv.XMin = pFeatLayer.AreaOfInterest.XMin;
            pEnv.XMax = pFeatLayer.AreaOfInterest.XMax;
            pEnv.YMin = pFeatLayer.AreaOfInterest.YMin;
            pEnv.YMax = pFeatLayer.AreaOfInterest.YMax;
            object objExtent = pEnv;
            pRsEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref objExtent, ref Missing);
            return pConversionOp;
        }
        //设置栅格坡度分析环境
        public static ISurfaceOp SetRasterSurfaceAnalysisEnv(string rasterpath, double cellsize)
        {
            object Missing = Type.Missing;
            IWorkspace pWorkspace;
            pWorkspace = Utility.setRasterWorkspace(rasterpath);
            ISurfaceOp pSurfaceOp = new RasterSurfaceOpClass();
            IRasterAnalysisEnvironment pEnv = pSurfaceOp as IRasterAnalysisEnvironment;

            pEnv.OutWorkspace = pWorkspace;

            //装箱操作
            object objCellSize = cellsize;

            pEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref objCellSize);
            pEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvMaxOf, ref Missing, ref Missing);
            return pSurfaceOp;
        }

        //设置栅格插值分析环境
        public static IInterpolationOp SetRasterInterpolationAnalysisEnv(string rasterpath,double cellsize,IFeatureLayer pFeatLayer)
        {
            object Missing = Type.Missing;				  
			IWorkspace pWorkspace=Utility.setRasterWorkspace(rasterpath);
			IInterpolationOp pInterpolationOp =new  RasterInterpolationOpClass();
			IRasterAnalysisEnvironment pRsEnv =pInterpolationOp as IRasterAnalysisEnvironment;
			pRsEnv.OutWorkspace=pWorkspace;
			//装箱操作
			object objCellSize=cellsize;

			pRsEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue,ref objCellSize);
			
			IEnvelope pEnv=new EnvelopeClass();
			pEnv.XMin=pFeatLayer.AreaOfInterest.XMin;
			pEnv.XMax=pFeatLayer.AreaOfInterest.XMax;
			pEnv.YMin=pFeatLayer.AreaOfInterest.YMin;
			pEnv.YMax=pFeatLayer.AreaOfInterest.YMax;
			object objExtent=pEnv;
			pRsEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue,ref objExtent,ref Missing);
            return pInterpolationOp;
        }
		//设置栅格密度分析环境
		public static IDensityOp SetRasterDensityAnalysisEnv(string rasterpath,double cellsize,IFeatureLayer pFeatLayer)
		{
			object Missing = Type.Missing;				  
			IWorkspace pWorkspace=Utility.setRasterWorkspace(rasterpath);
			IDensityOp pDensityOp =new RasterDensityOpClass();
			IRasterAnalysisEnvironment pRsEnv =pDensityOp as IRasterAnalysisEnvironment;
			pRsEnv.OutWorkspace=pWorkspace;
			//装箱操作
			object objCellSize=cellsize;

			pRsEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue,ref objCellSize);
			
			IEnvelope pEnv=new EnvelopeClass();
			pEnv.XMin=pFeatLayer.AreaOfInterest.XMin;
			pEnv.XMax=pFeatLayer.AreaOfInterest.XMax;
			pEnv.YMin=pFeatLayer.AreaOfInterest.YMin;
			pEnv.YMax=pFeatLayer.AreaOfInterest.YMax;
			object objExtent=pEnv;
			pRsEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue,ref objExtent,ref Missing);
			return pDensityOp;

		}
		//设置栅格距离分析环境
		public static IDistanceOp SetRasterDisAnalysisEnv(string rasterpath,double cellSize,IFeatureLayer pFeatLayer)
		{
			object Missing = Type.Missing;	
			IWorkspace pWorkspace;
			pWorkspace=Utility.setRasterWorkspace(rasterpath);
			IDistanceOp pDistranceOp=new  RasterDistanceOpClass();
			
			IRasterAnalysisEnvironment pRsEnv= pDistranceOp as IRasterAnalysisEnvironment;

			pRsEnv.OutWorkspace=pWorkspace;
		 	
			//装箱操作
			object objCellSize=cellSize;

			pRsEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue,ref objCellSize);
            IEnvelope pEnv=new EnvelopeClass();
			pEnv.XMin=pFeatLayer.AreaOfInterest.XMin;
			pEnv.XMax=pFeatLayer.AreaOfInterest.XMax;
			pEnv.YMin=pFeatLayer.AreaOfInterest.YMin;
			pEnv.YMax=pFeatLayer.AreaOfInterest.YMax;
			object objExtent=pEnv;
			pRsEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue,ref objExtent,ref Missing);
			return pDistranceOp;

		}
		//删除临时栅格数据文件
		public static void DeleteFile(string sDir,string sName)
		{
			
			IRasterWorkspace pRsWorkspace=setRasterWorkspace(sDir) as IRasterWorkspace ;
			IRasterDataset pRD=OpenRasterDataset(sDir,sName);
			if(pRD!=null)
			{
				IDataset pDS=pRD as IDataset;
				pDS.Delete();
			}
		}
        //删除特征数据文件
        public static void DelFeatureFile(string sDir, string sName)
        {
            IFeatureClass pFeatCls = OpenFeatureClassFromShapefile(sDir, sName);
            if (pFeatCls != null)
            {
                IDataset dataset =  pFeatCls as IDataset;
                dataset.Delete();
            }

        }
		//打开栅格数据集
		public static IRasterDataset OpenRasterDataset(string sDir,string sName)
		{
			try
			{
				IRasterDataset pRSD=null;
				IWorkspaceFactory pWSF=new RasterWorkspaceFactoryClass();
				if(pWSF.IsWorkspace(sDir))
				{
					IWorkspace pWS=pWSF.OpenFromFile(sDir,0);
					IRasterWorkspace pRsWs=pWS as IRasterWorkspace;
					pRSD= pRsWs.OpenRasterDataset(sName);
				}
				return pRSD;
			}
			catch(Exception e)
			{
				
				return null;
			}
		}
		public static void ConvertRasterToRsDataset(string sPath,IRaster pRaster,string sOutName)
		{
            try
            {
                IWorkspaceFactory pWSF = new RasterWorkspaceFactoryClass();
                if (pWSF.IsWorkspace(sPath) == false)
                    return;
                IWorkspace pRWS = pWSF.OpenFromFile(sPath, 0);
                if (File.Exists(sPath + "\\" + sOutName + ".img") == true)
                    File.Delete(sPath + "\\" + sOutName + ".img");
                //IRasterDescriptor pRasterDes = new RasterDescriptorClass();
                //pRasterDes.Create(pRaster, null, "Value");
                IRasterBandCollection pRasBandCol = pRaster as IRasterBandCollection;
                //DeleteFile(sPath,sOutName);
                IDataset pDS = pRasBandCol.SaveAs(sOutName+".img", pRWS, "IMAGINE Image");
                ITemporaryDataset pRsGeo = pDS as ITemporaryDataset;
                if (pRsGeo.IsTemporary())
                    pRsGeo.MakePermanent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);


            }

		}
	    public static void ConvertShape2Raster(string fullPathToShape, double inCellSize, string outRasterName){

		//可以用这个方法得到文件名的路径
		string pathToWorkspace = System.IO.Path.GetDirectoryName(fullPathToShape) ;
		string shapefileName = System.IO.Path.GetFileNameWithoutExtension(fullPathToShape);

		
		IFeatureClass pFClass=OpenFeatureClassFromShapefile(pathToWorkspace,shapefileName);

		IGeoDataset geoDataset = (IGeoDataset) pFClass ;

		IWorkspace pWSpace=setRasterWorkspace(pathToWorkspace);
        


		// Create raster conversion operator and set up analysis environment,
  
		// then use it to make the output raster.
		IConversionOp rasterConversionOp = new RasterConversionOpClass() ;

		try
		{

			// Again, an interface that has to be present on the object.
			IRasterAnalysisEnvironment rasterAnalysisEnvironment = (IRasterAnalysisEnvironment) rasterConversionOp ;
				
			rasterAnalysisEnvironment.OutWorkspace = pWSpace ;

			esriRasterEnvSettingEnum envType = esriRasterEnvSettingEnum.esriRasterEnvValue ;
			System.Object inCellSizeObj = inCellSize ;
			rasterAnalysisEnvironment.SetCellSize(envType, ref inCellSizeObj) ;

			IEnvelope rasterExtent = geoDataset.Extent ;

			// SetExtent can take an Envelope or another Raster as the
			// second parameter, C# does this by passing the generic Object with 
			// the keyword "ref" in front.  Same for the Raster to be used for
			// the grid cell registration - which in this case is null, i.e. a void*
			System.Object inExtent = rasterExtent ;
			System.Object inSnapRaster = 0 ;
			rasterAnalysisEnvironment.SetExtent(envType, ref inExtent, ref inSnapRaster) ;
			
		}
		catch(Exception ex)
		{
		 
		}

		rasterConversionOp.ToRasterDataset(geoDataset, "TIFF", pWSpace, outRasterName);


					




		
		}

		public static IGeoDataset  openRasterfromFile(string fullPath){

			string pathToWorkspace = System.IO.Path.GetDirectoryName(fullPath) ;
			string rasterfileName = System.IO.Path.GetFileName(fullPath);

			IRasterWorkspace pRWS;//=new ESRI.ArcGIS.DataSourcesRaster.RasterWorkspaceClass();
			
			IWorkspaceFactory pWSF;//=new ESRI.ArcGIS.DataSourcesRaster.WorkspaceFactoryClass();

			IWorkspace pWS;

			IRasterDataset pRasterDataset;
			IRaster pRaster;
			IRasterLayer pRasterLayer=new RasterLayerClass();

			//pRWS=new RasterWorkspaceClass();
			pWSF=new RasterWorkspaceFactoryClass();


				
			pWS=pWSF.OpenFromFile(pathToWorkspace,0);

				
			pRWS=pWS as IRasterWorkspace;

			pRasterDataset=pRWS.OpenRasterDataset(rasterfileName);

			pRaster=pRasterDataset.CreateDefaultRaster();
			
			//pRasterLayer.CreateFromRaster(pRaster);

			return pRaster as IGeoDataset;




		
		}

		public static IRgbColor getRGBColor(int red,int green,int blue)
		{

			IRgbColor pColor=new RgbColorClass();
			pColor.Red=red;
			pColor.Green=green;
			pColor.Blue=blue;
			return pColor;
		
		}

		public static IGeoDataset smoothRaster(IGeoDataset m_GeoIn){

			INeighborhoodOp nbOp;
            IRasterAnalysisEnvironment pEnv;
            nbOp=(new RasterNeighborhoodOpClass()) as INeighborhoodOp;
			pEnv = nbOp as IRasterAnalysisEnvironment;
			
			IGeoDataset m_GeoOut=null;

			object Missing=Type.Missing;


		
			double cellSize=1;
			
			//装箱操作
			object objCellSize=cellSize;
			try
			{

				pEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue,ref objCellSize);
			
				pEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvMaxOf,ref Missing,ref Missing);

				IRasterNeighborhood pNB=new RasterNeighborhoodClass();

				pNB.SetDefault();

			
				//pGeoOut = pop.FocalStatistics(m_GeoIn, esriGeoAnalysisStatsMean, pNB, True);

				m_GeoOut=nbOp.FocalStatistics(m_GeoIn,esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsMean,pNB,true);
			}
			catch(Exception e){
				MessageBox.Show(e.Message);
				
			
			}


			return m_GeoOut;

	
		}

		public static ILayer openTinLayer(string fullPath){

			
			ITinWorkspace pTinWorkspace;
			IWorkspace pWS;
			IWorkspaceFactory pWSFact=new TinWorkspaceFactoryClass();

			ITinLayer pTinLayer=new TinLayerClass();

			string pathToWorkspace = System.IO.Path.GetDirectoryName(fullPath) ;
			string tinName = System.IO.Path.GetFileName(fullPath);
			ITin pTin;

			pWS=pWSFact.OpenFromFile(pathToWorkspace,0);
			pTinWorkspace=pWS as ITinWorkspace;

			if(pTinWorkspace.get_IsTin(tinName))
			{
				pTin=pTinWorkspace.OpenTin(tinName);

				pTinLayer.Dataset=pTin;

				pTinLayer.ClearRenderers();

				return pTinLayer as ILayer;


			}
			else{
				MessageBox.Show("该目录不包含Tin文件");
				return null;
			
			}

		
		}


		
		public static void createShapeFile(String folderName,String shapeName){
			
			if(folderName==""||shapeName=="") return;

			string shapeFieldName="shape";

			try
			{

				IFeatureWorkspace pFWS = null;
				IWorkspaceFactory pWorkspaceFactory = null;
				pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
				//if(pWorkspaceFactory.IsWorkspace(folderName)==false) return;

				pFWS=pWorkspaceFactory.OpenFromFile(folderName,0) as IFeatureWorkspace;	
			
				IFields pFields = null;
				IFieldsEdit pFieldsEdit = null;
				pFields = new FieldsClass();
				pFieldsEdit=pFields as IFieldsEdit;

				IField pField = null;
				IFieldEdit pFieldEdit = null;

				//Make the shape field it will need a geometry definition, with a spatial reference
				pField=new FieldClass();
				pFieldEdit=pField as IFieldEdit;

				pFieldEdit.Name_2=shapeFieldName;
				pFieldEdit.Type_2=esriFieldType.esriFieldTypeGeometry;

				IGeometryDef pGeomDef = null;
				IGeometryDefEdit pGeomDefEdit = null;
				pGeomDef = new GeometryDefClass();

				pGeomDefEdit =pGeomDef as IGeometryDefEdit;

				pGeomDefEdit.GeometryType_2=esriGeometryType.esriGeometryPolygon;

				pGeomDefEdit.SpatialReference_2=new UnknownCoordinateSystemClass();

				pFieldEdit.GeometryDef_2=pGeomDefEdit;
				pFieldsEdit.AddField(pField);


				//Add another miscellaneous text field
				pField = new FieldClass();
				pFieldEdit = pField as IFieldEdit;
				pFieldEdit.Length_2=30;
				pFieldEdit.Name_2="TextField";
				pFieldEdit.Type_2=esriFieldType.esriFieldTypeString;
				pFieldsEdit.AddField(pField);

				IFeatureClass pFeatClass = null;
				pFeatClass = pFWS.CreateFeatureClass(shapeName,  pFields, null, null,esriFeatureType.esriFTSimple, shapeFieldName, "");
				
				MessageBox.Show("名为"+shapeName+"的shape文件创建成功");
			}
			catch(Exception e){
				MessageBox.Show(e.Message);
			
			}
		}


		public static int getLyrIndexByName(AxMapControl pMapCtrl,string lyrName){
			ILayer pLayer;
			String fName;
			for(int ii=0;ii<pMapCtrl.LayerCount;ii++){

				pLayer=pMapCtrl.get_Layer(ii);

				fName=pLayer.Name;
				if(fName.Equals(lyrName)){
					return ii;
				
				}

			
			}
			return -1;
		
		}

		public static void drawPointToGraphicLayer(IActiveView pActiveView,IPoint pGeom,IMarkerSymbol pSym){
			try
			{
				IGraphicsContainer iGC=pActiveView as IGraphicsContainer;
				
				IElement pEle;
				IMarkerElement pLE;
				if(pGeom!=null)
				{
					pEle=new MarkerElementClass() as IElement;
					pLE=pEle as IMarkerElement;
					pLE.Symbol=pSym;
					pEle.Geometry=pGeom;
					iGC.AddElement(pEle,0);
			
				}

				pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics,Type.Missing,pActiveView.Extent);
		
			}
			
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		
		}

		public static void drawPolyline(IActiveView pActiveView,IPolyline pGeom){
			try{
				IGraphicsContainer iGC=pActiveView as IGraphicsContainer;
				ILineSymbol ipLineSymbol=new CartographicLineSymbolClass();
				ipLineSymbol.Width = 5;
                IRgbColor pRgbColor=new RgbColorClass();
                pRgbColor.Red=255;
                pRgbColor.Green=0;
                pRgbColor.Blue=0;
                ipLineSymbol.Color = pRgbColor as IColor;
				IElement pEle;
				ILineElement pLE;
				if(pGeom!=null)
				{
					pEle=new LineElementClass() as IElement;
					pLE=pEle as ILineElement;
					pLE.Symbol=ipLineSymbol;
					pEle.Geometry=pGeom;
					iGC.AddElement(pEle,0);
			
				}

				pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics,Type.Missing,pActiveView.Extent);
		
			}
			
			catch(Exception e){
				MessageBox.Show(e.Message);
			}
		}


		public static void drawPolygon(IActiveView pActiveView){
			IGraphicsContainer iGC=pActiveView as IGraphicsContainer;
		
			IRubberBand pRubberPoly=new RubberPolygonClass();

			IScreenDisplay pScreenDisp=pActiveView.ScreenDisplay;

			IGeometry pGeom;

			pGeom=pRubberPoly.TrackNew(pScreenDisp,null);

			IPolygon pPoly=pGeom as IPolygon;

			IElement pEle;

			if(pPoly!=null){

				pEle=new PolygonElementClass() as IElement;

				pEle.Geometry=pPoly;

				iGC.AddElement(pEle,0);
				
			
			}

			pActiveView.Refresh();

		
		}

		public static IFeatureWorkspace openPDB(string filePath){
			try
			{
				IWorkspaceFactory pWSF=new AccessWorkspaceFactoryClass();
				IFeatureWorkspace pFWS;
				IPropertySet pPropset=new PropertySetClass();
				pPropset.SetProperty("DATABASE",filePath);
				pFWS=pWSF.Open(pPropset,0) as IFeatureWorkspace;

				return pFWS;

			}
			catch(Exception e){
				MessageBox.Show(e.Message);
				return null;
			
			}

		
		}

		public static void CreateFClassInPDB(string filePath){

			string shapeFieldName="shape";

			IFeatureWorkspace pFWS;

			try
			{
			
				
				pFWS=openPDB(filePath);
				//IEnumDataset pDatasets;

				//pDatasets=pWS.get_Datasets(esriDatasetType.esriDTFeatureDataset);
				IFeatureDataset pFeatureDataset=pFWS.OpenFeatureDataset("Water");
				//MessageBox.Show(pFeatureDataset.Name);

			
			//	IDataset pDataset=pDatasets.Next();

			//	IFeatureDataset pFeatureDataset=pDataset as IFeatureDataset;
				IGeoDataset pGeoDataset=pFeatureDataset as IGeoDataset;
			



				IFields pFields = null;
				IFieldsEdit pFieldsEdit = null;
				pFields = new FieldsClass();
				pFieldsEdit=pFields as IFieldsEdit;
				pFieldsEdit.FieldCount_2=2;

				IField pField = null;
				IFieldEdit pFieldEdit = null;

				//Make the shape field it will need a geometry definition, with a spatial reference
				pField=new FieldClass();
				pFieldEdit=pField as IFieldEdit;

				pFieldEdit.Name_2=shapeFieldName;
				pFieldEdit.Type_2=esriFieldType.esriFieldTypeGeometry;

				IGeometryDef pGeomDef = null;
				IGeometryDefEdit pGeomDefEdit = null;
				pGeomDef = new GeometryDefClass();

				pGeomDefEdit =pGeomDef as IGeometryDefEdit;

				pGeomDefEdit.GeometryType_2=esriGeometryType.esriGeometryPolygon;

				pGeomDefEdit.SpatialReference_2=pGeoDataset.SpatialReference;//get the spatial reference


				pFieldEdit.GeometryDef_2=pGeomDefEdit;
				//pFieldsEdit.AddField(pField);
				pFieldsEdit.set_Field(0,pField);
				


				//Add another miscellaneous text field
				pField = new FieldClass();
				pFieldEdit = pField as IFieldEdit;
				pFieldEdit.Length_2=30;
				pFieldEdit.Name_2="TextField";
				pFieldEdit.Type_2=esriFieldType.esriFieldTypeString;
				//pFieldsEdit.AddField(pField);
				pFieldsEdit.set_Field(1,pField);


			
			
				//pFeatureDataset.CreateFeatureClass("test",pFields,null,null,esriFeatureType.esriFTSimple,"Shape","");
				 UID pUID;
                 pUID = new UIDClass();
				pUID.Value="esriGeoDatabase.Feature";

    			 //pFeatureDataset.CreateFeatureClass("test",pFields,pUID,null,esriFeatureType.esriFTSimple,"Shape","");
				pFeatureDataset.CreateFeatureClass("test",pFields,pUID,null,esriFeatureType.esriFTSimple,"Shape","");
				 

				MessageBox.Show("创建成功");
			}
			catch(Exception e){
				MessageBox.Show(e.Message);
			
			}


		
		}


		public static IGeometry SymmetricDiff(IGeometry inputGeom,IGeometry otherGeom){
			try
			{
				ITopologicalOperator pTopo=inputGeom as ITopologicalOperator;
				//pTopo.
				return pTopo.SymmetricDifference(otherGeom);
			}
			catch(Exception e){
				MessageBox.Show(e.Message);
				return null;

			
			}


			}
		

		public static void setLegendVisiblity(ILayer pLayer,bool isVisible){
			ILegendInfo pLegendInfo;
			ILegendGroup pLegendGroup;
			pLegendInfo = pLayer as ILegendInfo;
			for(int ii=0;ii<pLegendInfo.LegendGroupCount;ii++){
				pLegendGroup=pLegendInfo.get_LegendGroup(ii);
				pLegendGroup.Visible=isVisible;
				
			}
					
		}
        //为栅格图层数据进行填挖方量着色
        public static IRasterLayer SetCutFillRenderer(IRaster pInRaster, string sField, string sPath)
        {
            IRasterDescriptor pRD = new RasterDescriptorClass();
            pRD.Create(pInRaster, new QueryFilterClass(), sField);
            IReclassOp pReclassOp = new RasterReclassOpClass();
            IGeoDataset pGeodataset = pInRaster as IGeoDataset;
            IRasterAnalysisEnvironment pEnv = pReclassOp as IRasterAnalysisEnvironment;
            IWorkspaceFactory pWSF = new RasterWorkspaceFactoryClass();
            IWorkspace pWS = pWSF.OpenFromFile(sPath, 0);
            pEnv.OutWorkspace = pWS;
            object objSnap = null;
            object objExtent = pGeodataset.Extent;
            pEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref objExtent, ref objSnap);
            pEnv.OutSpatialReference = pGeodataset.SpatialReference;
            IRasterLayer pRLayer = new RasterLayerClass();
            IRasterBandCollection pRsBandCol = pGeodataset as IRasterBandCollection;
            IRasterBand pRasterBand = pRsBandCol.Item(0);
            pRasterBand.ComputeStatsAndHist();
            IRasterStatistics pRasterStatistic = pRasterBand.Statistics;
            double dMaxValue = pRasterStatistic.Maximum;
            double dMinValue = pRasterStatistic.Minimum;

            INumberRemap pNumRemap = new NumberRemapClass();
            pNumRemap.MapRange(dMinValue, 0, -1);
            pNumRemap.MapRange(0, 0, 0);
            pNumRemap.MapRange(0, dMaxValue, 1);
            IRemap pRemap = pNumRemap as IRemap;

            IRaster pOutRaster = pReclassOp.ReclassByRemap(pGeodataset, pRemap, false) as IRaster;
            pRLayer.CreateFromRaster(pOutRaster);

            return pRLayer;	  
        }
        //为栅格图层数据进行通视分析着色
        public static IRasterLayer SetViewShedRenderer(IRaster pInRaster,string sField,string sPath)
        {

            IRasterDescriptor pRD = new RasterDescriptorClass();
            pRD.Create(pInRaster, new QueryFilterClass(), sField);
            IReclassOp pReclassOp = new RasterReclassOpClass();
            IGeoDataset pGeodataset=pInRaster as IGeoDataset;
            IRasterAnalysisEnvironment pEnv = pReclassOp as IRasterAnalysisEnvironment;
            IWorkspaceFactory pWSF=new RasterWorkspaceFactoryClass();
            IWorkspace pWS = pWSF.OpenFromFile(sPath, 0);
            pEnv.OutWorkspace = pWS;
            object objSnap = null;
            object objExtent = pGeodataset.Extent;
            pEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref objExtent, ref objSnap);
            pEnv.OutSpatialReference = pGeodataset.SpatialReference;
            IRasterLayer pRLayer = new RasterLayerClass();
            IRasterBandCollection pRsBandCol = pGeodataset as IRasterBandCollection;
            IRasterBand pRasterBand = pRsBandCol.Item(0);
            pRasterBand.ComputeStatsAndHist();
            IRasterStatistics pRasterStatistic = pRasterBand.Statistics;
            double dMaxValue =  pRasterStatistic.Maximum ;
            double dMinValue =  pRasterStatistic.Minimum ;
    
            INumberRemap pNumRemap = new NumberRemapClass();
            pNumRemap.MapRange(dMinValue, 0, 0);
            pNumRemap.MapRange(0, dMaxValue, 1);
            IRemap pRemap = pNumRemap as IRemap;

            IRaster pOutRaster = pReclassOp.ReclassByRemap(pGeodataset, pRemap, false) as IRaster ;                
            pRLayer.CreateFromRaster(pOutRaster);            

            return pRLayer;	  
                  
        }


		//为栅格图层数据进行拉伸着色
		public static IRasterLayer SetStretchRenderer(IRaster pRaster)
		{
			try
			{
				//创建着色类和QI栅格着色
				IRasterStretchColorRampRenderer pStretchRen=new RasterStretchColorRampRendererClass();
				IRasterRenderer pRasRen=pStretchRen as IRasterRenderer;
				//为着色和更新设置栅格数据
				pRasRen.Raster=pRaster;
				pRasRen.Update();
				//定义起点和终点颜色
				IColor pFromColor=new RgbColorClass();
				IRgbColor pRgbColor=pFromColor as IRgbColor;
				pRgbColor.Red=255;
				pRgbColor.Green=0;
				pRgbColor.Blue=0;
				IColor pToColor=new RgbColorClass();
				pRgbColor=pToColor as IRgbColor;
				pRgbColor.Red=0;
				pRgbColor.Green=255;
				pRgbColor.Blue=0;
				//创建颜色分级
				IAlgorithmicColorRamp pRamp=new AlgorithmicColorRampClass();
				pRamp.Size=255;
				pRamp.FromColor=pFromColor;
				pRamp.ToColor=pToColor;
				bool ok=true;
				pRamp.CreateRamp(out ok);
				//把颜色分级插入着色中并选择一个波段
				pStretchRen.BandIndex=0;
				pStretchRen.ColorRamp=pRamp;
				pRasRen.Update();
				IRasterLayer pRLayer=new RasterLayerClass();
				pRLayer.CreateFromRaster(pRaster);
				pRLayer.Renderer = pStretchRen as IRasterRenderer ;
				return pRLayer;	


			}
			catch(Exception ex)
			{
				
				Console.WriteLine(ex.Message);
				return null;
			}
		}
        //为栅格图层数据按照从最小值到最大值的分类着色
        public static IRasterLayer SetRsLayerClassifiedColor(IRaster pRaster)
        {
            IRasterClassifyColorRampRenderer pClassRen = new RasterClassifyColorRampRendererClass();
            IRasterRenderer pRasRen = pClassRen as RasterClassifyColorRampRendererClass;
            //Set raster for the render and update
            pRasRen.Raster = pRaster;
            pClassRen.ClassCount = 9;
            pRasRen.Update();
            //Create a color ramp to use
            //定义起点和终点颜色
            IColor pFromColor = new RgbColorClass();
            IRgbColor pRgbColor = pFromColor as IRgbColor;
            pRgbColor.Red = 255;
            pRgbColor.Green = 200;
            pRgbColor.Blue = 0;
            IColor pToColor = new RgbColorClass();
            pRgbColor = pToColor as IRgbColor;
            pRgbColor.Red = 0;
            pRgbColor.Green = 0;
            pRgbColor.Blue = 255;
            //创建颜色分级
            IAlgorithmicColorRamp pRamp = new AlgorithmicColorRampClass();
            pRamp.Size = 9;
            pRamp.FromColor = pFromColor;
            pRamp.ToColor = pToColor;
            bool ok = true;
            pRamp.CreateRamp(out ok);
            //获得栅格统计数值
            IRasterBandCollection pRsBandCol = pRaster as IRasterBandCollection;
            IRasterBand pRsBand = pRsBandCol.Item(0);
            pRsBand.ComputeStatsAndHist();
            IRasterStatistics pRasterStatistic = pRsBand.Statistics;
            double dMaxValue = pRasterStatistic.Maximum;
            double dMinValue = pRasterStatistic.Minimum;
            //Create symbol for the classes
            IFillSymbol pFSymbol = new SimpleFillSymbolClass();

            double LabelValue = Convert.ToDouble((dMaxValue-dMinValue) / 9);
            for (int i = 0; i <= pClassRen.ClassCount - 1; i++)
            {
                pFSymbol.Color = pRamp.get_Color(i);
                pClassRen.set_Symbol(i, pFSymbol as ISymbol);
                double h1 = (LabelValue * i) + dMinValue;
                double h2 = (LabelValue * (i + 1)) + dMinValue;
                pClassRen.set_Label(i, h1.ToString() + "～" + h2.ToString());
            }
            //Update the renderer and plug into layer
            pRasRen.Update();
            IRasterLayer pRLayer = new RasterLayerClass();
            pRLayer.CreateFromRaster(pRaster);
            pRLayer.Renderer = pClassRen as IRasterRenderer;
            return pRLayer;		
        }
        //为栅格图层数据进行分类着色
		public static IRasterLayer GetRLayerClassifyColor(IRaster pRaster,double dMaxDis)
		{
			IRasterClassifyColorRampRenderer  pClassRen=new RasterClassifyColorRampRendererClass();
			IRasterRenderer pRasRen=pClassRen as RasterClassifyColorRampRendererClass;
			//Set raster for the render and update
			pRasRen.Raster =pRaster;
			pClassRen.ClassCount=10;
			pRasRen.Update();
			//Create a color ramp to use
			//定义起点和终点颜色
			IColor pFromColor=new RgbColorClass();
			IRgbColor pRgbColor=pFromColor as IRgbColor;
			pRgbColor.Red=255;
			pRgbColor.Green=0;
			pRgbColor.Blue=0;
			IColor pToColor=new RgbColorClass();
			pRgbColor=pToColor as IRgbColor;
			pRgbColor.Red=0;
			pRgbColor.Green=255;
			pRgbColor.Blue=0;
			//创建颜色分级
			IAlgorithmicColorRamp pRamp=new AlgorithmicColorRampClass();
			pRamp.Size=10;
			pRamp.FromColor=pFromColor;
			pRamp.ToColor=pToColor;
			bool ok=true;
			pRamp.CreateRamp(out ok);
			//Create symbol for the classes
			IFillSymbol pFSymbol=new SimpleFillSymbolClass();
		 				 
			double LabelValue=Convert.ToDouble(dMaxDis/6);
			for(int i=0;i<=pClassRen.ClassCount - 1;i++)
			{
				pFSymbol.Color = pRamp.get_Color(i);
				pClassRen.set_Symbol(i,pFSymbol as ISymbol) ;
				double h1=LabelValue*i;
				double h2=LabelValue*(i+1);
				pClassRen.set_Label(i, h1.ToString()+"～"+h2.ToString());
			}
			//Update the renderer and plug into layer
			pRasRen.Update();
			IRasterLayer pRLayer=new RasterLayerClass();
			pRLayer.CreateFromRaster(pRaster);
			pRLayer.Renderer = pClassRen as IRasterRenderer ;
			return pRLayer;		

		}

		//为栅格图层数据进行唯一值着色

		public static IRasterLayer GetRLayerUniqueColor(IRaster pRaster,double dMaxDis)
		{
			try
			{
				IRasterBandCollection pBandCol=pRaster as IRasterBandCollection;
				IRasterBand pBand=pBandCol.Item(0) as IRasterBand ;
			    bool ExistTable;
				ITable pTable=null;
				pBand.HasTable(out ExistTable);
				if(ExistTable==false)
				{
					pTable=pBand.AttributeTable as ITable;
				}
			
				int iNumOfValues=pTable.RowCount(null);
				string sFieldName="Value";
				int iFieldIndex=pTable.FindField(sFieldName);
				IRandomColorRamp pRamp=new RandomColorRampClass();
				pRamp.Size=iNumOfValues;
				pRamp.Seed=100;
				bool a=true;
				pRamp.CreateRamp(out a);
				IFillSymbol pFSymbol=new SimpleFillSymbolClass();
				IRasterUniqueValueRenderer pUVRen=new RasterUniqueValueRendererClass();
				IRasterRenderer pRasRen=pUVRen as IRasterRenderer;
				pRasRen.Raster=pRaster;
				pRasRen.Update();
				pUVRen.HeadingCount=1;
				pUVRen.set_Heading(0,"等级");
				pUVRen.set_ClassCount(0,iNumOfValues);
				pUVRen.Field=sFieldName;
				//开始循环进行着色
				double LabelValue;				 
				double s=Convert.ToDouble(dMaxDis/5);
				IRgbColor pRGBColor=new RgbColorClass();
			 
				for(int i=0;i<iNumOfValues-1;i++)
				{
					IColor pColor=pRamp.get_Color(i);
					IRow pRow=pTable.GetRow(i);
					string sLabel="";
					LabelValue=Convert.ToDouble(pRow.get_Value(iFieldIndex));
					if(LabelValue>=0||LabelValue<=s)
					{
						sLabel="0"+"～"+s.ToString();
						pRGBColor.Red=0;
						pRGBColor.Green=112;
						pRGBColor.Blue=255;
						pColor=pRGBColor as IColor;
					}
					double h1=s*2;
					if(LabelValue>=s||LabelValue<=s*2)
					{
						sLabel=s.ToString()+"～"+h1.ToString();
						pRGBColor.Red=0;
						pRGBColor.Green=112;
						pRGBColor.Blue=255;
						pColor=pRGBColor as IColor;
					}
					double h2=s*3;
					if(LabelValue>=s*2||LabelValue<=s*3)
					{
						sLabel=h1.ToString()+"～"+h2.ToString();
						pRGBColor.Red=0;
						pRGBColor.Green=112;
						pRGBColor.Blue=255;
						pColor=pRGBColor as IColor;
					}
					double h3=s*4;
					if(LabelValue>=s*3||LabelValue<=s*4)
					{
						sLabel=h2.ToString()+"～"+h3.ToString();
						pRGBColor.Red=0;
						pRGBColor.Green=112;
						pRGBColor.Blue=255;
						pColor=pRGBColor as IColor;
					}
					double h4=s*5;
					if(LabelValue>=s*4||LabelValue<=s*5)
					{
						sLabel=h3.ToString()+"～"+h4.ToString();
						pRGBColor.Red=0;
						pRGBColor.Green=112;
						pRGBColor.Blue=255;
						pColor=pRGBColor as IColor;
					}
					pUVRen.AddValue(0,i,LabelValue);
					pUVRen.set_Label(0,i,sLabel);
					
					pFSymbol.Color=pColor;
					pUVRen.set_Symbol(0,i,pFSymbol as ISymbol);

				}
				pRasRen.Update();
				IRasterLayer pRLayer=new RasterLayerClass();
				pRLayer.CreateFromRaster(pRaster);
				pRLayer.Renderer = pUVRen as IRasterRenderer ;
				return pRLayer;		
			}
			catch(Exception ex){
				
				Console.WriteLine(ex.Message);
				return null;
			}
 



			

/*
			//Create classfy renderer and QI RasterRenderer interface
			IRasterClassifyColorRampRenderer  pClassRen=new RasterClassifyColorRampRendererClass();
            IRasterRenderer pRasRen=pClassRen as RasterClassifyColorRampRendererClass;
			//Set raster for the render and update
			pRasRen.Raster =pRaster;
			pClassRen.ClassCount=6;
			pRasRen.Update();
			//Create a color ramp to use
			IAlgorithmicColorRamp pRamp=new AlgorithmicColorRampClass();
			pRamp.Size=6;
            bool a=true;

			pRamp.CreateRamp(out a);
			//Create symbol for the classes
			IFillSymbol pFSymbol=new SimpleFillSymbolClass();
          
			for(int i=0;i<=pClassRen.ClassCount - 1;i++)
			{
				pFSymbol.Color = pRamp.get_Color(i);
				pClassRen.set_Symbol(i,pFSymbol as ISymbol) ;
				pClassRen.set_Label(i, "Class"+ i.ToString());
			}
			 //Update the renderer and plug into layer
			pRasRen.Update();
			IRasterLayer pRLayer=new RasterLayerClass();
			pRLayer.CreateFromRaster(pRaster);
			pRLayer.Renderer = pClassRen as IRasterRenderer ;
			return pRLayer;		
			*/	
		}
		//创建新的地图文档
		public static void NewMxdDocument(MainFrm pMainFrm)
		{
			SaveFileDialog saveFileDialog1 = new  SaveFileDialog();
			saveFileDialog1.Title="选择新建地图文档";
			saveFileDialog1.InitialDirectory="c:\\temp";
			saveFileDialog1.Filter="地图文档(*.mxd, *.mxt, *.pmf)|*.mxd;*.mxt;*.pmf";
			if(saveFileDialog1.ShowDialog()== DialogResult.OK)
			{
				 pMainFrm.modPublicClass.pMapDocument.New(saveFileDialog1.FileName);			 
			}
			AxMapControl axMap=pMainFrm.getMapControl();
            AxMapControl overviewMap = pMainFrm.getOverviewControl();
			if(axMap.CheckMxFile(pMainFrm.modPublicClass.pMapDocument.DocumentFilename )==true)
			{
				axMap.LoadMxFile(pMainFrm.modPublicClass.pMapDocument.DocumentFilename ,null,null);
				 overviewMap.LoadMxFile(pMainFrm.modPublicClass.pMapDocument.DocumentFilename ,null,null);
			}
			else
			{
				MessageBox.Show("所选择的文档视图文件不存在,请重新指定!","错误提示");
			}
			
		}
		//打开已有的地图文档
		public static void OpenMxdDocument(MainFrm pMainFrm)
		{
			OpenFileDialog openFileDialog1=new OpenFileDialog();
			openFileDialog1.Title="打开已有的地图文档";
			openFileDialog1.InitialDirectory="c:\\temp";
			openFileDialog1.Filter="地图文档(*.mxd, *.mxt, *.pmf)|*.mxd;*.mxt;*.pmf";
			if(openFileDialog1.ShowDialog()==DialogResult.OK)
			{
				pMainFrm.modPublicClass.pMapDocument.Open(openFileDialog1.FileName,"");
			}
			AxMapControl axMap=pMainFrm.getMapControl();
            AxMapControl overviewMap = pMainFrm.getOverviewControl();
			if(axMap.CheckMxFile(pMainFrm.modPublicClass.pMapDocument.DocumentFilename )==true)
			{
				axMap.LoadMxFile(pMainFrm.modPublicClass.pMapDocument.DocumentFilename ,null,null);
			 	overviewMap.LoadMxFile(pMainFrm.modPublicClass.pMapDocument.DocumentFilename ,null,null);
			}
			else
			{
				MessageBox.Show("所选择的文档视图文件不存在,请重新指定!","错误提示");
			}
		}
		//保存地图文档
		public static void SaveMxdDocument(MainFrm pMainFrm)
		{
			SaveFileDialog saveFileDialog1 = new  SaveFileDialog();
			saveFileDialog1.Title="选择新建地图文档";
			saveFileDialog1.InitialDirectory="c:\\temp";
			saveFileDialog1.Filter="地图文档(*.mxd, *.mxt, *.pmf)|*.mxd;*.mxt;*.pmf";
			if(saveFileDialog1.ShowDialog()== DialogResult.OK)
			{
				pMainFrm.modPublicClass.pMapDocument.SaveAs(saveFileDialog1.FileName,true,false);			 
			}
			 
		}
        //----------------------上朔分析------------------------
       

        //-----------------///----------------------------------
		//打开特征数据并添加到地图中
		public static void AddFeatureLayer(MainFrm pMainFrm)
		{
			int startX,endX;
			string fileName;
			string shpDir,shpFile;
			object Missing = Type.Missing;	 

			OpenFileDialog openFileDialog1=new OpenFileDialog();
			openFileDialog1.Title="选择要添加的数据文件";
			openFileDialog1.InitialDirectory="c:\\temp";
			openFileDialog1.Filter="特征数据(*.Lyr, *.shp)|*.shp|栅格数据(*.Grid)|*.Grid|图像数据(*.img)|*.img";
			if(openFileDialog1.ShowDialog()==DialogResult.OK)
			{
				fileName=openFileDialog1.FileName;
				shpDir =fileName.Substring(0, fileName.LastIndexOf("\\")); 
				startX=fileName.LastIndexOf("\\");
				endX=fileName.Length;
				shpFile=fileName.Substring(startX+1,endX-startX-1);
                AxMapControl axMap = pMainFrm.getMapControl();
				if(openFileDialog1.FilterIndex==1)
				{
					IFeatureClass pFClass=Utility.OpenFeatureClassFromShapefile(shpDir,shpFile);
					IFeatureLayer pFeatLyr=new FeatureLayerClass();
                    pFeatLyr.FeatureClass=pFClass;
					pFeatLyr.Name=pFClass.AliasName;
					pFeatLyr.Visible=true;
					
					axMap.AddLayer(pFeatLyr,0);
					axMap.Refresh();
				}
                else if (openFileDialog1.FilterIndex == 3)
                {
                    IRasterDataset pRsDataset = Utility.OpenRasterDataset(shpDir, shpFile);
                    IRaster pInRaster=pRsDataset.CreateDefaultRaster();
                    IRasterLayer pRsLayer = new RasterLayerClass();
                    pRsLayer.CreateFromRaster(pInRaster);
                    axMap.AddLayer(pRsLayer, 0);
                    axMap.Refresh();
                }
			}
	

			
		}
        //点选查询
		/* public static void PointQuery(int x,int y)
		{
			AxMapControl axMap=pMainFrm.getMapControl();
			IIdentify pIdentify=null;
			IArray pIDArray=null;
			IFeatureIdentifyObj pFeatIdObj=null;
			IIdentifyObj pIdObj=null;
			IDisplayTransformation pDT=axMap.ActiveView.ScreenDisplay.DisplayTransformation;
			IPoint pPoint=pDT.ToMapPoint(x,y);
			IEnvelope pEnv=pPoint.Envelope;
            pEnv.Expand((pDT.VisibleBounds.Width/(4*Screen.FromPoint(pPoint as IPoint))),
				(pDT.VisibleBounds.Height/(4*Screen.FromPoint(pPoint as IPoint))),false);
 　　　　　
		 
			for(int i=0;i<axMap.LayerCount-1;i++)
			{
				pIdentify=axMap.get_Layer(i);
				pIDArray=pIdentify.Identify(pEnv);
				if(pIDArray!=null)
				{
					for(int j=0;j<pIDArray.Count-1;j++)
					{
						pFeatIdObj=pIDArray.get_Element(j);
						pIdObj=pFeatIdObj as IIdentifyObj;
						IRowIdentifyObject pRowObj=pFeatIdObj as IRowIdentifyObject;
						IFeature pFeature=pRowObj.Row;

					}
				}
			}
			SelectedFeature[] pSelectedFeature=new SelectedFeature[i];
		}
		*/ 
    
		public static IWorkspace connectToSDE(){

			IPropertySet pPropSet=new PropertySetClass();
			pPropSet.SetProperty("Server","techserver" );
			pPropSet.SetProperty("Instance","esri_sde" );
			pPropSet.SetProperty("user","sdedata" );
			pPropSet.SetProperty("password","sdedata" );
			pPropSet.SetProperty("version","sde.DEFAULT" );

			IWorkspaceFactory pFact;
			IWorkspace pWorkspace;
			IFeatureWorkspace pFeatureWorkspace;
			
			/*
			IFields pFields=new FieldsClass();
			IFieldsEdit pFieldsEdit=pFields as IFieldsEdit;

			IField pField1=new FieldClass();
			IFieldEdit pFieldEdit=pField1 as IFieldEdit;

			pFieldEdit.Name_2="test1";
			pFieldEdit.Type_2=esriFieldType.esriFieldTypeInteger;
			pFieldsEdit.AddField(pFieldEdit);
			*/






			try
			{
				pFact=new SdeWorkspaceFactoryClass();
            
				pWorkspace=pFact.Open(pPropSet,0);

				//pFeatureWorkspace=pWorkspace as IFeatureWorkspace;

				//pFeatureWorkspace.CreateTable("CJTEST",pFieldsEdit as IFields,null,null,"");
				
				return pWorkspace;


				
			}
			catch(Exception ex){
				
				Console.WriteLine(ex.Message);
				return null;
			}

		
		}
        //从栅格数据层中获得表面
        public static ISurface GetSurface(ILayer pLayer)
        {
            if (pLayer is ITinLayer)
            {
                ITinLayer pTinLayer = pLayer as ITinLayer;
                ITinAdvanced pTin = pTinLayer.Dataset as ITinAdvanced;
                return pTin as ISurface;
            }
            else
            {
                IRasterLayer pRasterLayer = pLayer as IRasterLayer;
                IRasterBandCollection pRasterBands = pRasterLayer.Raster as IRasterBandCollection;
                IRasterBand pRasterBand = pRasterBands.Item(0);
                IRasterSurface pRasterSurface = new RasterSurfaceClass();
                pRasterSurface.RasterBand = pRasterBand;
                IGeoDataset pGeoDataset = pRasterBand.RasterDataset as IGeoDataset;
                IRasterStatistics pRasterStats = pRasterBand.Statistics;
                return pRasterSurface as ISurface;
            }
            return null;
        }
        //查找栅格数据层
        public static IRasterLayer FindRasterLayer(string sLayerName, MainFrm pMainFrm)
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            IRasterLayer pRasterLyr;
            for (int i = 0; i <= axMap.ActiveView.FocusMap.LayerCount - 1; i++)
            {
                if (axMap.ActiveView.FocusMap.get_Layer(i) is IRasterLayer)
                {
                    pRasterLyr = axMap.ActiveView.FocusMap.get_Layer(i) as IRasterLayer;
                    if (pRasterLyr.Name == sLayerName)
                    {
                        return pRasterLyr;
                    }

                }
            }
            return null;
        }
        //////////////上朔追踪分析////////
        public static IFeatureLayer FindFeatLayer(string sLayerName, MainFrm pMainFrm)
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            IFeatureLayer pFeatLayer;
            for (int i = 0; i <= axMap.ActiveView.FocusMap.LayerCount - 1; i++)
            {
                if (axMap.ActiveView.FocusMap.get_Layer(i) is IFeatureLayer)
                {
                    pFeatLayer = axMap.ActiveView.FocusMap.get_Layer(i) as IFeatureLayer;
                    if (pFeatLayer.Name == sLayerName)
                    {
                        return pFeatLayer;
                    }
                }
            }
            return null;
        }
        public static void UpStreamTrace(MainFrm pMainFrm,IPoint pPoint,IGeometricNetwork pGeoNetwork)
        {
            try
            {
                AxMapControl axMap = pMainFrm.getMapControl();
                //清除地图的选择
                axMap.ActiveView.FocusMap.ClearSelection();
                INetElements pNetElements = pGeoNetwork.Network as INetElements;
                IPointToEID pPtToEID = new PointToEIDClass();
                int pJunctionID=0;
                int iUserClassID;
                int iUserID;
                int iUserSubID;
                IPoint pLocation;
              
                pPtToEID.SourceMap = axMap.ActiveView.FocusMap;
                pPtToEID.GeometricNetwork = pGeoNetwork;
                pPtToEID.SnapTolerance = axMap.ActiveView.Extent.Envelope.Width / 100;
                pPtToEID.GetNearestJunction(pPoint,  out pJunctionID, out pLocation);
                if (pJunctionID == 0)
                {
                    MessageBox.Show("没有查找相临近的点");
                }
                else
                {
                    pNetElements.QueryIDs(pJunctionID, esriElementType.esriETJunction, out iUserClassID, out iUserID, out iUserSubID);
                    INetFlag ipNetFlag = new JunctionFlagClass();
                    ipNetFlag.UserClassID = iUserClassID;
                    ipNetFlag.UserID = iUserID;
                    ipNetFlag.UserSubID = iUserSubID;

                    IMarkerSymbol pMarkerSym = new SimpleMarkerSymbolClass();
                    IRgbColor pRGBColor = new RgbColorClass();
                    pRGBColor.Red = 255;
                    pRGBColor.Green = 0;
                    pRGBColor.Blue = 0;
                    pMarkerSym.Color = pRGBColor;
                    pMarkerSym.Size = 20;
                    //创建新的Flag

                    IEdgeFlagDisplay pEdgeFlagDisplay = new EdgeFlagDisplayClass();
                    IFlagDisplay pFlagDisplay = pEdgeFlagDisplay as IFlagDisplay;
                    pFlagDisplay.Symbol = pMarkerSym as ISymbol;
                    pFlagDisplay.Geometry = pLocation;
                    pFlagDisplay.FeatureClassID = iUserClassID;
                    pFlagDisplay.FID = iUserID;
                    pFlagDisplay.SubID = iUserSubID;

                    //绘制该点
                    IScreenDisplay pScreenDisplay = axMap.ActiveView.ScreenDisplay;
                    pScreenDisplay.StartDrawing(pScreenDisplay.hDC, 0);
                    pScreenDisplay.SetSymbol(pMarkerSym as ISymbol);
                    pScreenDisplay.DrawPoint(pLocation as IGeometry);
                    pScreenDisplay.FinishDrawing();
                    //查找追踪结果
                    FindStreamTraceResult(pMainFrm, ipNetFlag, pGeoNetwork);
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }
        }
        //查找追踪的结果
        public static void FindStreamTraceResult(MainFrm pMainFrm,INetFlag ipNetFlag, IGeometricNetwork pGeoNetwork)
        {
            try
            {
                AxMapControl axMap = pMainFrm.getMapControl();
                IEnumNetEID m_ipEnumNetEID_Junctions, m_ipEnumNetEID_Edges;//用来存放搜索结果的Junctions和Edges
                IJunctionFlag[] pArrayJFlag = new IJunctionFlag[1];
                pArrayJFlag[0] = ipNetFlag as IJunctionFlag;
                ITraceFlowSolverGEN ipTraceFlowSolver = new TraceFlowSolverClass() as ITraceFlowSolverGEN;

                //get the inetsolver interface
                INetSolver ipNetSolver = ipTraceFlowSolver as INetSolver;
                ipNetSolver.SourceNetwork = pGeoNetwork.Network;

                ipTraceFlowSolver.PutJunctionOrigins(ref pArrayJFlag);

                ipTraceFlowSolver.TraceIndeterminateFlow = false;

                object[] totalCost = new object[1];


                //ipTraceFlowSolver.FindSource(esriFlowMethod.esriFMUpstream,esriShortestPathObjFn.esriSPObjFnMinSum,out m_ipEnumNetEID_Junctions,out m_ipEnumNetEID_Edges,1,ref totalCost);

                ipTraceFlowSolver.FindFlowElements(esriFlowMethod.esriFMUpstream,
                    esriFlowElements.esriFEEdges,
                    out m_ipEnumNetEID_Junctions,
                    out m_ipEnumNetEID_Edges);


                SpatialHelperFunction.pathToPolyline(pGeoNetwork, axMap.ActiveView, m_ipEnumNetEID_Edges);
                UpStreamFindParcels(pMainFrm, m_ipEnumNetEID_Edges,pGeoNetwork);
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }
        }
        //上朔追踪查找管线涉及的地块
        public static void UpStreamFindParcels(MainFrm pMainFrm, IEnumNetEID pEnumResultEdges, IGeometricNetwork pGeoNetwork)
        {
            try
            {
                AxMapControl axMap = pMainFrm.getMapControl();
                IFeatureLayer pFeatLayerSewerLines = FindFeatLayer("Sewer Lines", pMainFrm);
                IFeatureLayer pFeatLayerParcels = FindFeatLayer("Parcels", pMainFrm);
                //从所选择的Sewer线特征中创建几何包
               
                IGeometryCollection pGeomBag = new GeometryBagClass();
                object missing = Type.Missing;
                int lEID;
                int iUserClassID;
                int iUserID;
                int iUserSubID;
                INetElements pNetElements = pGeoNetwork.Network as INetElements;
                pEnumResultEdges.Reset();
                IFeature pFeature;

                for (int j = 0; j <= pEnumResultEdges.Count - 1; j++)
                {
                    lEID = pEnumResultEdges.Next();
                    pNetElements.QueryIDs(lEID, esriElementType.esriETEdge, out iUserClassID, out iUserID, out iUserSubID);
                    pFeature = pFeatLayerSewerLines.FeatureClass.GetFeature(iUserID);
                    pGeomBag.AddGeometry(pFeature.Shape, ref missing, ref missing);
                    // MessageBox.Show(iUserClassID.ToString()+","+iUserID.ToString()+","+iUserSubID.ToString());
                }                                
                                //进行空间拓扑叠加操作以用于查找地块信息
                ISpatialFilter pSpatialFilter = new SpatialFilterClass();
                pSpatialFilter.Geometry = pGeomBag as IGeometry ;
                pSpatialFilter.GeometryField = "Shape";
                pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                pSpatialFilter.SearchOrder = esriSearchOrder.esriSearchOrderSpatial;
                                
                
                //获得交叉到的地块信息
                 IFeatureCursor pFeatCursor=pFeatLayerParcels.FeatureClass.Search(pSpatialFilter, false);
                //增加被选择的地块数据到地图的图形图层数据中
                ICompositeGraphicsLayer pComGraphicLayer = new CompositeGraphicsLayerClass();
                ILayer pLayer = pComGraphicLayer as ILayer ;
                pLayer.Name = "受影响的地块";
                IGraphicsContainer pGraphicContainer = pComGraphicLayer as IGraphicsContainer;
                //增加所选择的地块到图形容器中
                ISimpleFillSymbol pSymFill=new SimpleFillSymbolClass();
                IFillSymbol pFillSymbol=pSymFill as IFillSymbol;
                IRgbColor pRgbColor=new RgbColorClass();
                pRgbColor.Red=0;
                pRgbColor.Green=200;
                pRgbColor.Blue=100;
                pFillSymbol.Color=pRgbColor as IColor;
                ICartographicLineSymbol pCartoLine=new CartographicLineSymbolClass();
                IRgbColor pRgbColor2=new RgbColorClass();
                pRgbColor2.Red=100;
                pRgbColor2.Green=200;
                pRgbColor2.Blue=100;
                pCartoLine.Width=2;
                pCartoLine.Color =pRgbColor2 as IColor;
                pFillSymbol.Outline=pCartoLine;
                //创建存放所有地块特征的数组
                IArray pFeatArray = new ArrayClass();
                pFeature=pFeatCursor.NextFeature();
                while (pFeature != null)
                {
                    IElement pPolyElement = new PolygonElementClass();
                    IFillShapeElement pFillShapeElement = pPolyElement as IFillShapeElement;
                    pPolyElement.Geometry = pFeature.Shape;
                    pFillShapeElement.Symbol = pFillSymbol;
                    pGraphicContainer.AddElement(pPolyElement, 0);
                    pFeatArray.Add(pFeature);
                    pFeature = pFeatCursor.NextFeature();
                }
                axMap.AddLayer(pGraphicContainer as ILayer);
                axMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics,null,null);
                frmUpstreamCreateOwnerList frmUpstreamCreateOwnerList1 = new frmUpstreamCreateOwnerList(pMainFrm,pFeatLayerParcels, pFeatArray);
                frmUpstreamCreateOwnerList1.Show();
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }

        }
        
        //////////////////////////////////进行剖面分析前设置交叉点小旗
        public static void ProfileSetJunctionFlag(MainFrm pMainFrm, ref IArray pNetFlagArray,IPoint pPoint, IGeometricNetwork pGeoNetwork)
        {
            
            try
            {
                AxMapControl axMap = pMainFrm.getMapControl();
                //清除地图的选择
                axMap.ActiveView.FocusMap.ClearSelection();
                INetElements pNetElements = pGeoNetwork.Network as INetElements;
                IPointToEID pPtToEID = new PointToEIDClass();
                int pJunctionID = 0;
                int iUserClassID;
                int iUserID;
                int iUserSubID;
                IPoint pLocation;

                pPtToEID.SourceMap = axMap.ActiveView.FocusMap;
                pPtToEID.GeometricNetwork = pGeoNetwork;
                pPtToEID.SnapTolerance = axMap.ActiveView.Extent.Envelope.Width / 100;
                pPtToEID.GetNearestJunction(pPoint, out pJunctionID, out pLocation);
                if (pJunctionID == 0)
                {
                    MessageBox.Show("没有查找相临近的点");
                }
                else
                {
                  
                    pNetElements.QueryIDs(pJunctionID, esriElementType.esriETJunction, out iUserClassID, out iUserID, out iUserSubID);
                    INetFlag ipNetFlag = new JunctionFlagClass();
                    ipNetFlag.UserClassID = iUserClassID;
                    ipNetFlag.UserID = iUserID;
                    ipNetFlag.UserSubID = iUserSubID;

                    IMarkerSymbol pMarkerSym = new SimpleMarkerSymbolClass();
                    IRgbColor pRGBColor = new RgbColorClass();
                    pRGBColor.Red = 255;
                    pRGBColor.Green = 0;
                    pRGBColor.Blue = 0;
                    pMarkerSym.Color = pRGBColor;
                    pMarkerSym.Size = 20;
                    //绘制该点
                    IScreenDisplay pScreenDisplay = axMap.ActiveView.ScreenDisplay;
                    pScreenDisplay.StartDrawing(pScreenDisplay.hDC, 0);
                    pScreenDisplay.SetSymbol(pMarkerSym as ISymbol);
                    pScreenDisplay.DrawPoint(pLocation);
                    pScreenDisplay.FinishDrawing();
                    if (pLocation != null)
                    {
                        pNetFlagArray.Add(ipNetFlag);
                    }
                    if (pNetFlagArray.Count == 2)
                    {

                        //查找追踪结果
                        ProfileFindPath(pMainFrm, pNetFlagArray, pGeoNetwork);
                    }
                }
               
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }

        }
        public static void ProfileFindPath(MainFrm pMainFrm, IArray pNetFlagArray, IGeometricNetwork pGeoNetwork)
        {
            try
            {
                AxMapControl axMap = pMainFrm.getMapControl();
                IEnumNetEID m_ipEnumNetEID_Junctions, m_ipEnumNetEID_Edges;//用来存放搜索结果的Junctions和Edges
                IJunctionFlag[] pArrayJFlag = new IJunctionFlag[2];
                pArrayJFlag[0] = pNetFlagArray.get_Element(0) as IJunctionFlag;
                pArrayJFlag[1] = pNetFlagArray.get_Element(1) as IJunctionFlag;
                ITraceFlowSolverGEN ipTraceFlowSolver = new TraceFlowSolverClass() as ITraceFlowSolverGEN;

                //get the inetsolver interface
                INetSolver ipNetSolver = ipTraceFlowSolver as INetSolver;
                ipNetSolver.SourceNetwork = pGeoNetwork.Network;
                
                ipTraceFlowSolver.PutJunctionOrigins(ref pArrayJFlag);

                ipTraceFlowSolver.TraceIndeterminateFlow = false;

                object[] totalCost = new object[1];


                //ipTraceFlowSolver.FindSource(esriFlowMethod.esriFMUpstream,esriShortestPathObjFn.esriSPObjFnMinSum,out m_ipEnumNetEID_Junctions,out m_ipEnumNetEID_Edges,1,ref totalCost);

                ipTraceFlowSolver.FindPath(esriFlowMethod.esriFMConnected,
                    esriShortestPathObjFn.esriSPObjFnMinMax,
                    out m_ipEnumNetEID_Junctions,
                    out m_ipEnumNetEID_Edges, 1, ref totalCost);
                //清除数组中的交叉点元素
                pNetFlagArray.RemoveAll();
                SpatialHelperFunction.pathToPolyline(pGeoNetwork, axMap.ActiveView, m_ipEnumNetEID_Edges);
  ProfileGetRelatedSewerElevData(pMainFrm,pGeoNetwork,m_ipEnumNetEID_Edges, m_ipEnumNetEID_Junctions  );
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }
        }
        //获得剖面的高程数据
        public static void ProfileGetRelatedSewerElevData(MainFrm pMainFrm,IGeometricNetwork pGeoNetwork, IEnumNetEID pResultEdges, IEnumNetEID pResultJunctions)
        {
            try
            {
                //获得边特征以对应于网络追踪结果
                IArray pSewerElevArray = new ArrayClass();
                IEIDHelper pEIDHelper = new EIDHelperClass();
                pEIDHelper.GeometricNetwork = pGeoNetwork;
                pEIDHelper.ReturnFeatures = true;
                pEIDHelper.ReturnGeometries = true;
                pEIDHelper.PartialComplexEdgeGeometry = true;
                pEIDHelper.AddField("Component_Key2");
                IEnumEIDInfo pEnumEIDInfo = pEIDHelper.CreateEnumEIDInfo(pResultEdges);
                //获得与管线弧段相关的主干线记录
                pEnumEIDInfo.Reset();
                IEIDInfo pEIDInfo = pEnumEIDInfo.Next();
                IFeature pFeature = pEIDInfo.Feature;
                IGeometry pFeatGeo = pEIDInfo.Geometry;
                //从特征中获得关系
                IEnumRelationshipClass pEnumRelationshipCls = pFeature.Class.get_RelationshipClasses(esriRelRole.esriRelRoleOrigin);
                pEnumRelationshipCls.Reset();
                IRelationshipClass pRelationshipCls = pEnumRelationshipCls.Next();
                //获得正确的关系类
                string s="SewerToMainline";
                while (pRelationshipCls != null)
                {
                    if (pRelationshipCls.ForwardPathLabel.ToUpper() == s.ToUpper())
                        break ;
                    else 
                        pRelationshipCls = pEnumRelationshipCls.Next();
                }
                //查询主干管线与每个弧相关的数据，如果是1-1的关系，则只返回一个记录                  
                //  because the arcs are ordered and directional, if the start node is an
                //  fnode then get subsequent tnode's for the rest of the arcs, else if the
                //  start node is a tnode, get subsequent fnode's.  Related data has elev
                //  attributes for up and down stream manhole elevs, so related to from and to node of arc.
                 // get the first junction in the network trace results to determine if the
                 //first junction is a from-node or a to-node for graphing sewer line elev
                if (pRelationshipCls != null)
                {
                    ISet pMainlineRelatedSet;
                    IRow pMainlineRow;
                    IEIDHelper pEIDHelper2 = new EIDHelperClass();
                    pEIDHelper2.GeometricNetwork = pGeoNetwork;
                    pEIDHelper2.ReturnFeatures = true;
                    pEIDHelper2.ReturnGeometries = true;
                    pEIDHelper2.PartialComplexEdgeGeometry = true;
                    IEnumEIDInfo pEnumEIDInfo2 = pEIDHelper2.CreateEnumEIDInfo(pResultJunctions);
                    pEnumEIDInfo2.Reset();
                      //pFeature is the first arc in the network trace results
                      // check the junctions on the first arc to see which is the starting
                      // junction, this determines which sewer elev attribute (ups_elev, dwn_elev)
                      // will be used to calculate the sewer line profile
                    IEdgeFeature pEdgeFeat = pFeature as IEdgeFeature;
                    string strStartAttr;
                    string strMHelevAttr;
                    double lastelev=0;
                    int lastnodeEID;
                    if (pEnumEIDInfo2.Next().EID == pEdgeFeat.FromJunctionEID)
                    {
                       // trace is in the direction of flow, flow goes down hill
                        strStartAttr = "Ups_elev";
                        strMHelevAttr = "Dwn_elev";
                    }
                    else
                    {
                        //trace is in the opposite direction of flow, flow goes up hill
                        strStartAttr = "Dwn_elev";
                        strMHelevAttr = "Ups_elev";
                    }
                     lastnodeEID = pEnumEIDInfo2.Next().EID;
                    // create a polyline from the result junctions, make the polyline in the
                    //direction of the trace, not in the direction of the original arcs/edges
                    IPolyline pPolyline = new PolylineClass();
                    IPointCollection pPointColl = pPolyline as IPointCollection;
                    pEnumEIDInfo2.Reset();
                    object missing=Type.Missing;
                    for (int i = 0; i <= pEnumEIDInfo2.Count - 1; i++)
                    {
                        pPointColl.AddPoint(pEnumEIDInfo2.Next().Geometry as IPoint ,ref missing,ref missing);
                    }
                    ISegmentCollection pSegColl = pPolyline as ISegmentCollection;
                    //简化多段线
                    ITopologicalOperator pTopoOp = pPolyline as ITopologicalOperator;
                    pTopoOp.Simplify();
                    pPolyline.SimplifyNetwork();
                    pPolyline.Densify(50, 0.01);
                    pResultEdges.Reset();
                    pEnumEIDInfo2.Reset();
                    IPolyline pNewSegPolyline;
                    IPolyline pPolyLineFeat;
                    IRelationalOperator pRelOpFeat;
                    ISegmentCollection pNewSegColl;
                    ISegmentCollection pSegmentColl = pPolyline as ISegmentCollection;
                    for (int i = 0; i <= pResultEdges.Count - 1; i++)
                    {
                        pMainlineRelatedSet = pRelationshipCls.GetObjectsRelatedToObject(pFeature);
                        pMainlineRelatedSet.Reset();
                        pMainlineRow = pMainlineRelatedSet.Next() as IRow;
                        pPolyLineFeat = pFeature.Shape as IPolyline;
                        pRelOpFeat = pPolyLineFeat as IRelationalOperator;
                        for (int j = 0; j <= pSegmentColl.SegmentCount - 1; j++)
                        {
                            pNewSegPolyline = new PolylineClass();
                            pNewSegColl = pNewSegPolyline as ISegmentCollection;
                            pNewSegColl.AddSegment(pSegmentColl.get_Segment(j), ref missing, ref missing);
                            if (pRelOpFeat.Contains(pNewSegPolyline as IGeometry))
                            {
                                if (j == 0)
                                {
                                    pSewerElevArray.Add(pMainlineRow.get_Value(pMainlineRow.Fields.FindField(strStartAttr)));
                                    lastelev=Convert.ToDouble(pMainlineRow.get_Value(pMainlineRow.Fields.FindField(strMHelevAttr)));
                                }
                                else
                                {
                                    if (lastelev == Convert.ToDouble(pMainlineRow.get_Value(pMainlineRow.Fields.FindField(strMHelevAttr))))
                                    {
                                       pSewerElevArray.Add(-99);
                                    }
                                    else
                                    {
                                        pSewerElevArray.Add(lastelev);
                                        lastelev = Convert.ToDouble(pMainlineRow.get_Value(pMainlineRow.Fields.FindField(strMHelevAttr)));
                                    }
                                }
                            }
                        }
                       // get the next feature and check to see what direction it's going and
                        //adjust the variables accordingly
                       if(i<pResultEdges.Count-1)
                       {
                           lastnodeEID=pEdgeFeat.ToJunctionEID;
                           pFeature=pEnumEIDInfo.Next().Feature;
                           pEdgeFeat=pFeature as IEdgeFeature;
                           if(pEdgeFeat.FromJunctionEID==lastnodeEID)
                               strMHelevAttr="Dwn_elev";
                           else
                               strMHelevAttr="Ups_elev";

                       }
                       else
                       {
                           pSewerElevArray.Add(pMainlineRow.get_Value(pMainlineRow.Fields.FindField(strMHelevAttr)));

                       }
                    }
                    ProfileCreateGraph(pMainFrm,pPolyline, pSewerElevArray);
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }
        }
        //查看管线测绘视频资料
        public static void TVScansHatchRoutes(MainFrm pMainFrm)
        {
            IFeatureLayer pFeatTVSurveyLayer = Utility.FindFeatLayer("Sewer TV Surveys", pMainFrm);
            //创建文本符号
            ITextSymbol pTxtSymbol = new TextSymbolClass();
            IRgbColor pRgbColor = new RgbColorClass();
            pRgbColor.Red = 255;
            stdole.IFontDisp pFont = (stdole.IFontDisp)new stdole.StdFontClass();
            pFont.Name = "Arial";
            pFont.Bold = true;
            pTxtSymbol.Font = pFont;
            pTxtSymbol.Size = 13;
            pTxtSymbol.Angle = 0;
            pTxtSymbol.Color = pRgbColor as IColor;
            pTxtSymbol.VerticalAlignment = esriTextVerticalAlignment.esriTVACenter;
            pTxtSymbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;
            //使用线符号测试
            ISimpleLineSymbol pHatchSymbol = new SimpleLineSymbolClass();
            pHatchSymbol.Color = pRgbColor as IColor;
            pHatchSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            pHatchSymbol.Width = 2;
            //使用线符号测试小的ＨＡＴＣＨ
            ISimpleLineSymbol pHatchSymbol2 = new SimpleLineSymbolClass();
            pHatchSymbol2.Style = esriSimpleLineStyle.esriSLSSolid;
            pHatchSymbol2.Color = pRgbColor as IColor;

            bool bEnds = true;
            bool bEndsOnly = true;
            double dHatchLen = 5;
            double dTxtInterval = 1;
            double dHatchOffset = 0;
            bool bOverRideMajor = false;
            double dMajorAngle = 0;
            string graphicslayername = "Sewer TV Surveys Graphics Layer";
            HatchDraw(pMainFrm, pHatchSymbol, pHatchSymbol2, pTxtSymbol, pFeatTVSurveyLayer, bEnds, bEndsOnly, dHatchLen, dTxtInterval, dHatchOffset, dMajorAngle, bOverRideMajor, graphicslayername);
            AxMapControl axMap = pMainFrm.getMapControl();
            axMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }
        //绘制ＨＡＴＣＨ
        public static void HatchDraw(MainFrm pMainFrm,ISimpleLineSymbol pHatchSymMajor, ISimpleLineSymbol pHatchSymMinor, ITextSymbol pTxtSym, IFeatureLayer pFeatLayer, bool bEnds, bool bEndsOnly, double dHatchLen, double dTxtInterval, double dHatchOffset, double dMajorAngle, bool bOverRideMajor, string graphicslayername)
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            //设置图形图层为SEWER TV测绘图层
            IFeatureCursor pFeatCursor = pFeatLayer.Search(null, true);
            SetGraphicsLayer(pMainFrm, pFeatLayer.Name, graphicslayername);
            //设置SEWER TV测绘图形图层
            IGraphicsContainer pGraphicsContainer = axMap.ActiveView.FocusMap.ActiveGraphicsLayer as IGraphicsContainer;
            //清除图形图层
            pGraphicsContainer.DeleteAllElements();

            IFeature pFeature = pFeatCursor.NextFeature();
            IPolyline pMajorHatchPL = new PolylineClass();
            IPolyline pMinorHatchPL = new PolylineClass();
            IPolyline pPL;
            IMAware pPLM;
            IMCollection pMColl;
            IGeometryCollection pGeomColl;
            ILineElement pLineElement;
            IElement pElement = null; 
            int cnt;
            IPath pPath;
            string txt;
            double txtlen;
            IPath pTxtPath;
            double angle;
            IPoint pTxtPt;
            ISegmentCollection pSC;
            ISegment pSeg;
            ISegmentM pSegM;
            double m1=0;
            double m2=0;
            IPoint pFromPt;
            IMarkerSymbol pMSym;
            IMask pMask;
            ITextElement pTextElement;
            ISegmentCollection pSegment;
            ISegmentCollection pPolyline;
            while (pFeature != null)
            {
                pPL = pFeature.Shape as IPolyline ;
                pPLM = pPL as IMAware;
                if (pPLM.MAware)
                {
                    if (bEndsOnly)
                    {
                        MakeHatchesEndsOnly(pPL, bEnds, pMajorHatchPL, pMinorHatchPL, dHatchLen, dTxtInterval, dHatchOffset);
                    }
                    else
                    {
                         
                    }
                    // Draw the major hatches if they are lines
                    if (pHatchSymMajor is ILineSymbol)
                    {
                        pLineElement = new LineElementClass();
                        pLineElement.Symbol = pHatchSymMajor ;
                        pElement = pLineElement as IElement;
                        pElement.Geometry = pMajorHatchPL as IGeometry ;
                        pGraphicsContainer.AddElement(pElement, 0);
                    }
                    // Draw the major hatches if they are markers and the text...
                    pGeomColl = pMajorHatchPL as IGeometryCollection;
                    cnt = pGeomColl.GeometryCount - 1;
                    for (int j = 0; j <= cnt; j++)
                    {
                        pPath = pGeomColl.get_Geometry(j) as IPath ;
                        if (bOverRideMajor)
                            angle = dMajorAngle;
                        else
                            angle = GetAngle(pPath) + dMajorAngle;
                        pSC = pPath as ISegmentCollection;
                        pSeg = pSC.get_Segment(0);
                        pSegM = pSeg as ISegmentM;
                        txt = Convert.ToString(Math.Round(m1, 1));
                        txtlen = pTxtSym.Size;
                        angle = GetAngle(pPath as ICurve);
                        if (ShouldFlip(angle))
                        {
                            pTxtPath = MakeTextPath(pPath, txtlen * 2);
                            angle += 180;
                            pTxtSym.RightToLeft = false;
                            pTxtSym.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;
                            pTxtSym.VerticalAlignment = esriTextVerticalAlignment.esriTVACenter;

                        }
                        else
                        {
                            angle = angle;
                            pTxtPath = MakeTextPath(pPath, txtlen);
                            pTxtSym.RightToLeft = false;
                            pTxtSym.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;
                            pTxtSym.VerticalAlignment = esriTextVerticalAlignment.esriTVACenter;
                        }
                        pTxtSym.Angle = angle;
                        //为文本创建MASK，如果没有符号，将作为背景
                        pMask = pTxtSym as IMask;
                        pMask.MaskSize = 2;
                        pMask.MaskStyle = esriMaskStyle.esriMSHalo;

                        pTextElement = new TextElementClass();
                        pTextElement.Symbol = pTxtSym;
                        pTextElement.Text = txt + " ";
                        pElement = pTextElement as IElement ;

                        pSegment = pTxtPath as ISegmentCollection ;
                        pPolyline = new PolylineClass();
                        pPolyline.AddSegmentCollection(pSegment);
                        pElement.Geometry = pPolyline as IGeometry ;
                        pGraphicsContainer.AddElement(pElement, 0);
                    }
                }
                pFeature = pFeatCursor.NextFeature();
            }

        }
        public static void MakeHatchs(IPolyline pPL, bool Ends, IPolyline pMajor, IPolyline pMinor)
        {
            ITopologicalOperator pTopo = pPL as ITopologicalOperator;
            pTopo.Simplify();
            ISegmentCollection pSCMajor = pMajor as ISegmentCollection;
            ISegmentCollection pSCMinor = pMinor as ISegmentCollection;

            IGeometryCollection pGC = pPL as IGeometryCollection;
            IPath pPath;
            IGeometryCollection pSubPL;
            IMSegmentation pPLM;
            object missing=Type.Missing;
            IMAware pMAware;
            double Mmin;
            double Mmax;
            int cnt = pGC.GeometryCount - 1;
            for (int i = 0; i <= cnt - 1; i++)
            {
                pPath = pGC.get_Geometry(i) as IPath ;
                pSubPL = new PolylineClass();
                pSubPL.AddGeometry(pPath as IGeometry, ref missing, ref missing);
                pMAware = pSubPL as IMAware;
                pMAware.MAware = true;
                pPLM = pSubPL as IMSegmentation;
                Mmin = pPLM.MMin;
                Mmax = pPLM.MMax;
           
            }

        }
        public static void MakeHatchesEndsOnly(IPolyline pPL, bool Ends, IPolyline pMajor, IPolyline pMinor, double dHatchLen, double dTxtInterval, double dHatchOffset)
        {
            //简化输入的线
            ITopologicalOperator pTopo = pPL as ITopologicalOperator;
            pTopo.Simplify();
            //我们将在段集合中存储HATCH
            ISegmentCollection pSCMajor = pMajor as ISegmentCollection;
            ISegmentCollection pSCMinor = pMinor as ISegmentCollection;
            
          //Break the polyline into parts here ... Ideally, there should be one part
          //per route. In cases where there is more than one part, and there is no physical
         // separation in the parts, the results can look like they are wrong (i.e. there
            //appears to be text where there should not be).
            IGeometryCollection pGC = pPL as IGeometryCollection;
            int cnt = pGC.GeometryCount - 1;
            object missing=Type.Missing;
            object distances;
            double dist;
            for (int i = 0; i <= pGC.GeometryCount - 1; i++)
            {
                IPath pPath = pGC.get_Geometry(i) as IPath ;
                IGeometryCollection pSubPL = new PolylineClass();
                pSubPL.AddGeometry(pPath, ref missing,ref missing);
                IMAware pMAware = pSubPL as IMAware;
                pMAware.MAware = true;
                IMSegmentation pPLM = pSubPL as IMSegmentation;
                double Mmin = pPLM.MMin;
                double Mmax = pPLM.MMax;
                ISegment pSeg = MakeOneHatch(pSubPL as IPolyline , Mmin, Mmin, 1, dTxtInterval, dHatchLen, dHatchOffset);
                if (pSeg.Length >= ((Math.Abs(dHatchLen) * 0.5) + 0.001))
                    pSCMajor.AddSegment(pSeg,ref  missing,ref missing);
                else
                    pSCMinor.AddSegment(pSeg,ref missing,ref missing);
                distances = pPLM.GetDistancesAtM(false, Mmax);
                IArray pArray = (IArray)distances;
                for (int j = 0; j <= pArray.Count - 1; j++)
                {
                    dist = (double)pArray.get_Element(j);
                    pSeg = MakeOneHatch(pSubPL as IPolyline , dist, Mmax, 1, dTxtInterval, dHatchLen, dHatchOffset);
                    if(pSeg.Length>=(Math.Abs(dHatchLen)*0.5)+0.001)
                    {
                        pSCMajor.AddSegment(pSeg,ref missing,ref missing);
                    }
                    else
                    {
                        pSCMinor.AddSegment(pSeg,ref missing,ref missing);
                    }
                }                
            }
            pMajor.SimplifyNetwork();
            pMinor.SimplifyNetwork();
        }
        public static ISegment MakeOneHatch(IPolyline pSubPL, double dist, double m, double numhatch, double dTxtInterval, double dHatchLen, double dHatchOffset)
        {
            ILine pL = new LineClass();
            int result;
            ISegmentM  pSegM;
            Math.DivRem((int)numhatch, (int)dTxtInterval, out result);
            if (!(result == 0))
            {
                if (dHatchOffset == 0)
                    pSubPL.QueryNormal(esriSegmentExtension.esriNoExtension, dist, false, (dHatchLen * 0.5), pL);
                else if (dHatchOffset > 0)
                    pSubPL.QueryNormal(esriSegmentExtension.esriNoExtension, dist, false, (dHatchLen * 0.5) + dHatchOffset, pL);
                else if (dHatchOffset < 0)
                {
                    pSubPL.ReverseOrientation();
                    pSubPL.QueryNormal(esriSegmentExtension.esriNoExtension, pSubPL.Length - dist, false, dHatchLen + Math.Abs(dHatchOffset), pL);
                    pSubPL.ReverseOrientation();
                }
            }
            ICurve pCurve;

            if (dHatchOffset != 0)
            {
                pL.GetSubcurve(Math.Abs(dHatchOffset), pL.Length,false, out pCurve);
                pSegM = pCurve as ISegmentM;
            }
            else
                pSegM = pL as ISegmentM;
            pSegM.SetMs(m, m);
            return pSegM as ISegment ;
        }
        public static IPath MakeTextPath(IPath pPath, double length)
        {
            try
            {
                double angle = GetAngle(pPath);
                IPoint pPt = pPath.ToPoint;
                IConstructPoint pCP = new PointClass();
                double PI = 3.1415926535897;
                double rad = angle * PI / 180;
                pCP.ConstructAngleDistance(pPt, rad, 1);
                IPoint pNew = pCP as IPoint;

                IPath pNewPath = new PathClass();
                pNewPath.FromPoint = pPt;
                pNewPath.ToPoint = pNew;
                if (ShouldFlip(angle))
                {
                    pNewPath.ReverseOrientation();
                }
                return pNewPath;
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
                return null;
            }
        }
        public static bool ShouldFlip(double angle)
        {
            if (angle <= 90 || angle >= 270)
                return false;
            else
                return true;
        }
        //得到角度
        public static double GetAngle(ICurve pCurve)
        {
            double tmp = 0;
            if (pCurve != null && !pCurve.IsEmpty)
            {
                double PI = 3.1415926535897;
                double dist;
                IPoint pPt1 = pCurve.FromPoint;
                IPoint pPt2 = pCurve.ToPoint;
                ILine pLine = new LineClass();
                pLine.FromPoint = pPt1;
                pLine.ToPoint = pPt2;
                double angle = pLine.Angle;
                 tmp = angle * (180 / PI);
                if (tmp < 0)
                    tmp = 360 - Math.Abs(tmp);
                
            }
            return tmp;
        }
        public static void SetGraphicsLayer(MainFrm pMainFrm,string strFeatLayerName, string strGraphicsLayerName)
        {
            try
            {
                AxMapControl axMap = pMainFrm.getMapControl();
                IGraphicsLayer pGraphicsLayer=null;
                ICompositeGraphicsLayer pComGraphicsLayer;
                ICompositeLayer pComLayer;
                IFeatureLayer pFeatLayer;
                bool found = false;
                if (strGraphicsLayerName.ToUpper() == "<DEFAULT>")
                {
                    pGraphicsLayer = axMap.ActiveView.FocusMap.BasicGraphicsLayer;
                }
                else
                {
                    pComGraphicsLayer = axMap.ActiveView.FocusMap.BasicGraphicsLayer as ICompositeGraphicsLayer ;
                    pComLayer = pComGraphicsLayer as ICompositeLayer;
                    for (int i = 0; i <= pComLayer.Count - 1; i++)
                    {
                        if (pComLayer.get_Layer(i).Name == strGraphicsLayerName)
                        {
                            //layer is found so set it as the graphics layer
                            pGraphicsLayer = pComGraphicsLayer.FindLayer(strGraphicsLayerName);
                            found = true;
                            break;
                        }
                    }
                    //如果是图形图层不能被找到，将创建它
                    if ((found==false)&& strFeatLayerName!="")
                    {
                        pFeatLayer = Utility.FindFeatLayer(strFeatLayerName, pMainFrm);
                        pComGraphicsLayer = axMap.ActiveView.FocusMap.BasicGraphicsLayer as ICompositeGraphicsLayer ;
                        pGraphicsLayer = pComGraphicsLayer.AddLayer(strGraphicsLayerName, pFeatLayer);
                        pGraphicsLayer.UseAssociatedLayerVisibility = true;
                    }
                }
                pGraphicsLayer.Activate(axMap.ActiveView.ScreenDisplay);
                ILayer pLayer = pGraphicsLayer as ILayer;
                axMap.ActiveView.FocusMap.ActiveGraphicsLayer = pLayer;
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }
        }
        //根据多段线和阀门数组创建高程剖面 
        public static void ProfileCreateGraph(MainFrm pMainFrm, IPolyline pPolyline, IArray pSewerElevArray)
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            IZ pPolylineZ = pPolyline as IZ;
            IRasterLayer pRasterLyr = FindRasterLayer("Elevation", pMainFrm);
            //获得表面进行插值
            ISurface pSurface = GetSurface(pRasterLyr);
            //创建Polyline z-ware;
            IZAware pZAwareLineZ = pPolyline as IZAware;
            pZAwareLineZ.ZAware = true;
            //'* work around for InterpolateFromSurface sometimes flipping polyline
            IPoint pPtOrigFrom = pPolyline.FromPoint;
            IPoint pPtOrigTo = pPolyline.ToPoint;
            //添加Z值到多边形上
            pPolylineZ.InterpolateFromSurface(pSurface);
            if (pPolyline.FromPoint.X != pPtOrigFrom.X || pPolyline.FromPoint.Y != pPtOrigFrom.Y)
                pPolyline.ReverseOrientation();
            //添加M值到线上
            IMSegmentation pMSegmentation = pPolyline as IMSegmentation;
            IMAware pMAware = pPolyline as IMAware;
            pMAware.MAware = true;
            pMSegmentation.SetMsAsDistance(false);
            //创建表格
            ITable pTable = ProfileCreateTable();
            int i=0;
            if (pTable != null)
            {
                //在图层列表控件中要确保该表格还不存在，如果存在则删除它
                IStandaloneTableCollection pStandAloneTabColl = axMap.ActiveView.FocusMap as IStandaloneTableCollection;
                for ( i = 0; i<=pStandAloneTabColl.StandaloneTableCount - 1; i++)
                {
                    if (pStandAloneTabColl.get_StandaloneTable(i).Name == "xxprofiletable")
                        pStandAloneTabColl.RemoveStandaloneTable(pStandAloneTabColl.get_StandaloneTable(i));
                }
                //创建一个新的独立表，并把它添加到地图集合中
                IStandaloneTable pStandAloneTab = new StandaloneTableClass();
                pStandAloneTab.Table = pTable;
                pStandAloneTabColl = axMap.ActiveView.FocusMap as IStandaloneTableCollection;
                pStandAloneTabColl.AddStandaloneTable(pStandAloneTab);
                pTable = pStandAloneTab as ITable;
                                //为两个字段设置别名 
                ITableFields pTableFields = pStandAloneTab as ITableFields;
                IFieldInfo pFieldInfo = pTableFields.get_FieldInfo(pTableFields.FindField("Z"));
                pFieldInfo.Alias = "Ground Elevation";
                pFieldInfo = pTableFields.get_FieldInfo(pTableFields.FindField("SewerElev"));
                pFieldInfo.Alias = "Sewer Line Elevation";
                //为表格获得一个插入光标 
                ICursor pCursor=pTable.Insert(true);
                IRowBuffer pRowBuff;
                //
                IPointCollection pPtCollection = pPolyline as IPointCollection;
                IEnumVertex pEnumVertex = pPtCollection.EnumVertices;
                pEnumVertex.Reset();
                IPoint pPT;
                 int iPartIndex;
                int iVertexIndex;
                  i = 0;
                //添加节点XYZ到新表格中
                pEnumVertex.Next(out pPT, out iPartIndex, out iVertexIndex);
                while (pPT != null)
                {
                    pRowBuff = pTable.CreateRowBuffer();
                    pRowBuff.set_Value(pRowBuff.Fields.FindField("X"),pPT.X);
                    pRowBuff.set_Value(pRowBuff.Fields.FindField("Y"),pPT.Y);
                    pRowBuff.set_Value(pRowBuff.Fields.FindField("Z"),pPT.Z);
                    pRowBuff.set_Value( pRowBuff.Fields.FindField("M"),pPT.M);
                    pRowBuff.set_Value(pRowBuff.Fields.FindField("SewerElev"), Convert.ToDouble(pSewerElevArray.get_Element(i)));
                    pCursor.InsertRow(pRowBuff);
                    pEnumVertex.Next(out pPT, out iPartIndex, out iVertexIndex);
                    i = i + 1;
                }
                pCursor.Flush();
                pCursor = null;
                pCursor = pTable.Search(null, false);
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = "SewerElev <> -99";
                ICursor pCursorSewerElev = pTable.Search(pQueryFilter, false);

                pCursor = null;
                pCursor = pTable.Update(null, false);
                pRowBuff = pCursor.NextRow();
                double m = 0;
                double Mmin=0;
                double Mmax=0;
                double deltaM=0;
                double deltaSewerElev=0;
                double sewerelev=0;
                double newZ=0;
                int j = 0;
                double minSewerElev=0;
                double maxSewerElev=0;
                IRow pRowSewerElev;
                while (pRowBuff != null)
                {
                    if (Convert.ToDouble(pRowBuff.get_Value(pRowBuff.Fields.FindField("SewerElev"))) == -99)
                    {
                        m = Convert.ToDouble(pRowBuff.get_Value(pRowBuff.Fields.FindField("M")));
                        newZ = (((m - Mmin) / deltaM) * deltaSewerElev) + sewerelev;
                        pRowBuff.set_Value(pRowBuff.Fields.FindField("SewerElev"), newZ);
                        pCursor.UpdateRow(pRowBuff as IRow);
                    }
                    else
                    {
                        if (j == 0)
                        {
                            pRowSewerElev = pCursorSewerElev.NextRow();
                            minSewerElev = Convert.ToDouble(pRowSewerElev.get_Value(pRowSewerElev.Fields.FindField("SewerElev")));
                            Mmin = Convert.ToDouble(pRowSewerElev.get_Value(pRowSewerElev.Fields.FindField("M")));
                            pRowSewerElev = pCursorSewerElev.NextRow();
                            maxSewerElev = Convert.ToDouble(pRowSewerElev.get_Value(pRowSewerElev.Fields.FindField("SewerElev")));
                            Mmax = Convert.ToDouble(pRowSewerElev.get_Value(pRowSewerElev.Fields.FindField("M")));
                        }
                        else
                        {
                            pRowSewerElev = pCursorSewerElev.NextRow();
                            if (pRowSewerElev != null)
                            {
                                minSewerElev = maxSewerElev;
                                Mmin = Mmax;
                                maxSewerElev =Convert.ToDouble(pRowSewerElev.get_Value(pRowSewerElev.Fields.FindField("SewerElev")));
                                Mmax = Convert.ToDouble(pRowSewerElev.get_Value(pRowSewerElev.Fields.FindField("M")));
                            }
                        }
                        deltaSewerElev = maxSewerElev - minSewerElev;
                        deltaM = Mmax - Mmin;
                        sewerelev = minSewerElev;
                        j = j + 1;
                    }
                    pRowBuff = pCursor.NextRow() as IRowBuffer;
                }
                pCursor.Flush();    
                //从表格中创建图形
                m_SewerElevStructArray = new ArrayClass();
               
                pCursor = null;
                pCursor = pTable.Search(null, false);
                pRowSewerElev = null;
                pRowSewerElev = pCursor.NextRow();
                while (pRowSewerElev != null)
                {
                    clsProfileStruct pProfileDataStruct = new clsProfileStruct();
                    pProfileDataStruct.M = Convert.ToDouble(pRowSewerElev.get_Value(pRowSewerElev.Fields.FindField("M")));
                    pProfileDataStruct.Z = Convert.ToDouble(pRowSewerElev.get_Value(pRowSewerElev.Fields.FindField("Z")));
                    pProfileDataStruct.dSewerElev = Convert.ToDouble(pRowSewerElev.get_Value(pRowSewerElev.Fields.FindField("Sewerelev")));
                    m_SewerElevStructArray.Add(pProfileDataStruct);
                    pRowSewerElev = pCursor.NextRow();
                }

                frmDrawProfile frmDrawProfile1 = new frmDrawProfile(m_SewerElevStructArray);
                frmDrawProfile1.Show();
            }
        }
        //创建空的剖面图绘制表格
        public static ITable ProfileCreateTable()
        {
            //创建字段
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = pFields as IFieldsEdit;
            pFieldsEdit.FieldCount_2= 5;

            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Name_2= "X";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            pFieldEdit.Precision_2 = 20;
            pFieldEdit.Scale_2 = 8;
            pFieldsEdit.set_Field(0, pField);

            pField = new FieldClass();
            pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Name_2 = "Y";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            pFieldEdit.Precision_2 = 20;
            pFieldEdit.Scale_2 = 8;
            pFieldsEdit.set_Field(1,pField);

            pField = new FieldClass();
            pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Name_2 = "Z";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            pFieldEdit.Precision_2 = 20;
            pFieldEdit.Scale_2 = 8;
            pFieldEdit.AliasName_2 = "Ground Elevation";
            pFieldsEdit.set_Field(2,pField);

            pField = new FieldClass();
            pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Name_2 = "M";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeSingle ;
            pFieldEdit.Precision_2 = 10;
            pFieldEdit.Scale_2 = 1;
            pFieldsEdit.set_Field(3,pField);

            pField = new FieldClass();
            pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Name_2 = "SewerElev";
            pFieldEdit.IsNullable_2= true;
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            pFieldEdit.Precision_2 = 20;
            pFieldEdit.Scale_2 = 8;
            pFieldEdit.AliasName_2 = "Sewer Line Elevation";
            pFieldsEdit.set_Field(4, pField);

            ITable pTable = CreateDBFTable("xxprofiletable", "c:\\temp", true, pFields);
           
            return pTable;
            

        }
        //创建DBASE文件
        public static ITable CreateDBFTable(string strName, string strFolder, bool overwrite, IFields pFields)
        {
            IFeatureWorkspace pFWS=null ;
            IWorkspaceFactory pWSF = new ShapefileWorkspaceFactoryClass();
            DirectoryInfo dir = new DirectoryInfo(strFolder);
            FileInfo  fileInfo = new FileInfo(strFolder + @"\" + strName + ".dbf");
            if (dir.Exists)
                pFWS = pWSF.OpenFromFile(strFolder, 0) as IFeatureWorkspace;
            if (fileInfo.Exists)
            {
                if (overwrite)
                    fileInfo.Delete();
                else
                {
                     
                        fileInfo.Delete();      

                }

            }
            IFieldsEdit pFieldsEdit;
            //如果字段集合不能存在，则创建它
            if (pFields == null)
            {
                pFields = new FieldsClass();
                pFieldsEdit = pFields as IFieldsEdit;
                pFieldsEdit.FieldCount_2 = 1;
                IField pField = new FieldClass();
                IFieldEdit  pFieldEdit = pField as IFieldEdit;
                pFieldEdit.Length_2 = 30;
                pFieldEdit.Name_2= "TextField";
                pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldEdit.AliasName_2 = "hi";
                pFieldsEdit.set_Field(0,pField);
            }
            ITable pTable = pFWS.CreateTable(strName, pFields, null, null, "");
            return pTable;

        }
        public static double  ConvertPixelsToMap(double dPixelUnits, IMap pMap)
        {
            
            IActiveView pActiveView = pMap as IActiveView;
            IDisplayTransformation pDT = pActiveView.ScreenDisplay.DisplayTransformation;
            tagRECT deviceRect = pDT.get_DeviceFrame();
            int iPixelExtent = deviceRect.right - deviceRect.left;
            IEnvelope pEnv = pDT.VisibleBounds;
            double realWorldDisplayExtent = pEnv.Width;
            double sizeOfOnePixel = realWorldDisplayExtent / iPixelExtent;
            return dPixelUnits * sizeOfOnePixel;
        }
        //对所选择特征进行闪烁控制
         public static void FlashFeature(IFeature pFeature , IMap pMap  )
         {
            IActiveView pActiveView=pMap as IActiveView;
             pActiveView.ScreenDisplay.StartDrawing(0, -1);
             switch(pFeature.Shape.GeometryType){
                 case esriGeometryType.esriGeometryPolyline:
                     FlashPolyline(pActiveView.ScreenDisplay, pFeature.Shape);
                     break;
                 case esriGeometryType.esriGeometryPolygon:
                     FlashPolygon(pActiveView.ScreenDisplay, pFeature.Shape);
                     break;         
                 case esriGeometryType.esriGeometryPoint:
                     FlashPoint(pActiveView.ScreenDisplay, pFeature.Shape);
                     break;
                 
             }
             pActiveView.ScreenDisplay.FinishDrawing();
         }
        //闪烁点特征类
    　　public static void FlashPoint(IScreenDisplay pDisplay, IGeometry pGeometry)
      {
        
          
        ISimpleMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbolClass();
        pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;

        IRgbColor  pRgbColor = new RgbColorClass();
        pRgbColor.Red=150;
        pRgbColor.Green=100;
        pRgbColor.Blue=100;
        pMarkerSymbol.Color=pRgbColor as IColor ;
        pMarkerSymbol.Outline=true;
        ISymbol pSymbol = pMarkerSymbol as ISymbol;
        pSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
        pDisplay.SetSymbol(pSymbol);
        pDisplay.DrawPoint(pGeometry);  
        Thread.Sleep(300);
        pDisplay.DrawPoint(pGeometry);
      }
    public static void FlashPolyline(IScreenDisplay pDisplay, IGeometry pGeometry)
    {
        
        ISimpleLineSymbol pLineSymbol = new SimpleLineSymbolClass();
        pLineSymbol.Width = 4;
        IRgbColor  pRgbColor = new RgbColorClass();
        pRgbColor.Green = 100;
        pRgbColor.Red=150;
        pRgbColor.Blue = 100;
        pLineSymbol.Color=pRgbColor as IColor ;
        ISymbol pSymbol = pLineSymbol as ISymbol;
        pSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

        pDisplay.SetSymbol(pSymbol);
        pDisplay.DrawPolyline(pGeometry);

        Thread.Sleep(300);
        pDisplay.DrawPolyline(pGeometry);
    }
    public static void FlashPolygon(IScreenDisplay pDisplay  , IGeometry pGeometry)
    { 

        ISimpleFillSymbol pFillSymbol = new SimpleFillSymbolClass();
        

        IRgbColor  pRgbColor =new RgbColorClass();
        pRgbColor.Red=255;
        pRgbColor.Green = 0;
        pRgbColor.Blue=0;
        pFillSymbol.Color=pRgbColor as IColor;
        ISymbol  pSymbol = pFillSymbol as ISymbol;
        //pSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

        pDisplay.SetSymbol(pSymbol);
        pDisplay.DrawPolygon(pGeometry);
        Thread.Sleep(300);
        pDisplay.DrawPolygon(pGeometry);
    }
        
         


	}


}
