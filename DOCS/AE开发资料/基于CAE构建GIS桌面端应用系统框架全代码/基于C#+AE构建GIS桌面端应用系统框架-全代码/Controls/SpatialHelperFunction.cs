using System;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using System.Windows.Forms;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;





namespace Controls
{
	/// <summary>
	/// SpatialHelperFunction 的摘要说明。
	/// </summary>
	public class SpatialHelperFunction
	{
		public SpatialHelperFunction()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//添加自定义
		public void dotDensityAnalysis(string inputShpPath,string outputRasterPath)
		{

			
		
		}

		public IGeometry GetIntersection(IGeometry pGeom,IPolyline pOther)
		{

			IClone pClone;

			pClone=pGeom.SpatialReference as IClone;

			if(pClone!=pOther.SpatialReference)
			{

				try
				{
					pOther.Project(pClone as ISpatialReference);
				}
				catch(Exception e)
				{
					MessageBox.Show(e.Message);

				}


			
			}//end of if


			ITopologicalOperator pTopoOp;

			pTopoOp=pOther as ITopologicalOperator;

			pTopoOp.Simplify();

			pTopoOp=pGeom as ITopologicalOperator;

			IGeometry pResultGeom=pTopoOp.Intersect(pGeom,esriGeometryDimension.esriGeometry0Dimension);


			return null;

		
		}


		public static void ExportActiveView(IActiveView pActiveView ,string strImagePath)
		{
			IExporter pExporter;
			IEnvelope pEnv;
			tagRECT rectExpFrame;
			int hdc;
			short dpi;

			pExporter=new JpegExporterClass();

			pEnv=new EnvelopeClass();

			//Setup the exporter
			rectExpFrame = pActiveView.ExportFrame;

			pEnv.PutCoords(rectExpFrame.left,rectExpFrame.top,rectExpFrame.right,rectExpFrame.bottom);

			dpi=96;

			pExporter.PixelBounds=pEnv;

			pExporter.ExportFileName=strImagePath;

			pExporter.Resolution=dpi;

			hdc=pExporter.StartExporting();

			pActiveView.Output(hdc,dpi,ref rectExpFrame,null,null);

			pExporter.FinishExporting();




		}
		 

		//not finished
		
		public static void BurstFindValves()
		{
			// run a FindPath between 2 flags, create a polyline from the results
			//需要desktop，放弃

			/*
						INetworkAnalysisExt pNetAnalysisExt;
						INetworkAnalysisExtFlags pNetAnalysisExtFlags;
						INetworkAnalysisExtBarriers pNetAnalysisExtBarriers;
						INetworkAnalysisExtResults pNetAnalysisExtResults;
						*/

			string valvelayername = "Water Fixtures";
			string waterlinelayername = "Water Lines";
			string waternetworkname = "Water_Network";

			INetworkCollection pNetworkCollection; 
			IFeatureDataset pFeatureDataSet;
			
			IWorkspaceFactory pWSF=new SdeWorkspaceFactoryClass();
			IPropertySet pPropset=new PropertySetClass();

			IFeatureWorkspace pFeatureWorkspace=pWSF.Open(pPropset,0) as IFeatureWorkspace;

			INetwork pNetwork;


			IGeometricNetwork pGeometricNetwork;

			pFeatureDataSet = pFeatureWorkspace.OpenFeatureDataset("datasetName");

			pNetworkCollection=pFeatureDataSet as INetworkCollection;

			pGeometricNetwork=pNetworkCollection.get_GeometricNetworkByName("networkname");
			
			pNetwork=pGeometricNetwork.Network;



			IEdgeFlagDisplay pEdgeFlagDisplay;
			IFlagDisplay pFlagDisplay;
			IEdgeFlag pEdgeFlag;
			INetFlag pNetFlag;

			//创建一个flag
			pEdgeFlag=new EdgeFlagClass();

			pNetFlag=pEdgeFlag as INetFlag;











			
			
			IFeatureLayer pFeatLayerValves;
			IFeatureLayer pFeatLayerWaterLines;

			


            
			UID pID=new UIDClass();
		}


		public static IGeometricNetwork  getNetworkByName(IFeatureDataset pFeaDataset)
		{

			return null;

		
		}

		
		public static void initNetwork(IFeatureDataset pFeaDataset,IMap pMap,out IGeometricNetwork m_ipGeometricNetwork)
		{

			INetworkCollection pNetworkCollection; 
			//IGeometricNetwork m_ipGeometricNetwork;
			INetwork pNetwork;
			IFeatureClassContainer ipFeatureClassContainer;
			IFeatureClass ipFeatureClass;
			IFeatureLayer ipFeatureLayer;
			IDataset pDataset;

			//get the network collection
			pNetworkCollection=pFeaDataset as INetworkCollection;

			if(pNetworkCollection.GeometricNetworkCount==0) 
			{
				MessageBox.Show("数据中没有网络");
				m_ipGeometricNetwork=null;
				return;
			}

			m_ipGeometricNetwork=pNetworkCollection.get_GeometricNetworkByName("Water_Network");

			

			//m_ipGeometricNetwork.

			

			

			//Use the INetwork interface when you want to query the network for general information 
			//such as the status of the network or the number of edges in your network. 

			pNetwork=m_ipGeometricNetwork.Network;

			//Add each of the Feature Classes in this Geometric Network as a map Layer

			ipFeatureClassContainer=pNetworkCollection as IFeatureClassContainer;

			if(ipFeatureClassContainer.ClassCount==0)
			{
				MessageBox.Show("没有网络featureClass");
				m_ipGeometricNetwork=null;
				return;			
			}

			for(int ii=0;ii<ipFeatureClassContainer.ClassCount;ii++)
			{

				ipFeatureClass=ipFeatureClassContainer.get_Class(ii);

				

				pDataset=ipFeatureClass as IDataset;

				

				if(pDataset.Name=="water_arc"||pDataset.Name.Equals("water_point")||pDataset.Name.Equals("Water_Network_Junctions"))
				{

					ipFeatureLayer=new FeatureLayerClass();

					ipFeatureLayer.FeatureClass=ipFeatureClass;

					ipFeatureLayer.Name=pDataset.Name;

					pMap.AddLayer(ipFeatureLayer);
				}
			
			}



			











		
		}

		public static void SlovePath()
		{
			
			

		
		}

		public static IMarkerSymbol FindMarkerSym(string stylename, string stylecategory, string symname){

			//查找Symbol无法实现，StyleGallery属于Desktop

			IStyleGallery pStyGall;
			IStyleGalleryStorage pStyGallStor;
			IStyleGalleryItem pStyGallItem;
			
			IMarkerSymbol pMrkSym=null;
			IEnumStyleGalleryItem pEnumStyGallItm;
			string pStylePath=null;
			pStyGall=new ServerStyleGalleryClass();

			pStyGallStor=pStyGall as IStyleGalleryStorage;

			try
			{
				
				pStylePath=pStyGallStor.DefaultStylePath+"Civic.ServerStyle";

				pStyGallStor.TargetFile=pStylePath;
			
				//pStyGallStor.AddFile(pStylePath);

				//pStyGall.LoadStyle(pStylePath,""); 看来不能使用LoadStyle，出现未指定的错误

				pStyGallStor.AddFile(pStylePath);

						

				pEnumStyGallItm = pStyGall.get_Items("Marker Symbols",stylename,stylecategory);

				pEnumStyGallItm.Reset();
				//Make sure it contains markers
				pStyGallItem = pEnumStyGallItm.Next() as IStyleGalleryItem;

				//if(pStyGallItem==null) {MessageBox.Show("没有指定的Symbol");return null;}

				//pEnumStyGallItm.Reset();
				//Make sure it contains markers
				//pStyGallItem = pEnumStyGallItm.Next() as IStyleGalleryItem;

				while(pStyGallItem!=null)
				{

					if(pStyGallItem.Name.Equals(symname))
					{
						pMrkSym=pStyGallItem.Item as IMarkerSymbol;
						break;
				
					}

				
					pStyGallItem = pEnumStyGallItm.Next() as IStyleGalleryItem;

			
				}

				return pMrkSym;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
				return null;
			
			}
			finally{
				pStyGallStor.RemoveFile(pStylePath);
				 pStyGall=null;
				 pStyGallStor=null;
				 pStyGallItem=null;
				 pEnumStyGallItm=null;
			
			}


			


		
			//return null;




	
	}

		public static void pathToPolyline(IGeometricNetwork pGeometricNetwork,IActiveView pActiveView,IEnumNetEID pEnumNetEID_Edges)
		{

			
			try
			{

				IEIDHelper piEIDHelper=new EIDHelperClass();

				piEIDHelper.GeometricNetwork=pGeometricNetwork;

				piEIDHelper.OutputSpatialReference=pActiveView.FocusMap.SpatialReference;

				piEIDHelper.ReturnFeatures=true;

				IPolyline mPolyline=new PolylineClass();
                
				mPolyline.SpatialReference=pActiveView.FocusMap.SpatialReference;

				IEIDInfo ipEIDInfo;

				IEnumEIDInfo piEnumEIDInfo;

				IGeometry ipGeometry=null;

				piEnumEIDInfo=piEIDHelper.CreateEnumEIDInfo(pEnumNetEID_Edges);

				IGeometryCollection pGeoCollection=mPolyline as IGeometryCollection;
				
				piEnumEIDInfo.Reset();

				object objMiss=Type.Missing;

				for(int ii=0;ii<piEnumEIDInfo.Count;ii++)
				{
				
					ipEIDInfo=piEnumEIDInfo.Next();
				
					ipGeometry=ipEIDInfo.Feature.Shape;

					if(ipGeometry!=null)
						Utility.drawPolyline(pActiveView,ipGeometry as IPolyline);
			
				}

				//return ipGeometry as IPolyline;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			
			}
			finally
			{
				
				
			}

			


		
		}

	}
}
