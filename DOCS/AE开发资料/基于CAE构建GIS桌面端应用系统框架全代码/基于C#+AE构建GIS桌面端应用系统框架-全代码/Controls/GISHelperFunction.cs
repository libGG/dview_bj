



using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.esriSystem;
using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;



//using ESRI.ArcGIS.
//using ESRI.ArcGIS.Geodatabase;

namespace MyFunction
{

	/// <summary>
	/// 一组常用的GIS功能
	/// </summary>
	public  class GISHelperFunction
	
	{
		
		/// <summary>
		/// 将网络数据添加到地图中
		/// </summary>
		/// <param name="dataPath">网络数据路径</param>
		/// <param name="_mapControl">地图控件</param>
		/// <param name="_pNAContext">INAContext</param>
		/// <param name="cmbCost">获取网络数据集里面的代价字段</param>
		/// <param name="isRoute">是否使用route</param>
		public void loadNetworkData(string dataPath,AxMapControl _mapControl,ref INAContext _pNAContext,ComboBox cmbCost,bool isRoute)
		{

				     
			IFeatureWorkspace pFWorkspace;
            
			INetworkDataset pNetworkDataset;
			
			INetworkAttribute pNetworkAttribute;

			int i;

			IFeatureClass pInputFClass;
			
			//打开workspace
			pFWorkspace=OpenWorkspace(dataPath) as IFeatureWorkspace;

			//打开network Dataset

			pNetworkDataset=OpenNetworkDataset(pFWorkspace as IWorkspace,"Streets_nd");

			if(isRoute==false)
			_pNAContext=CreateSolverContext(pNetworkDataset);
			else
				_pNAContext=CreateRouteSolverContext(pNetworkDataset);

			// Get Cost Attributes
			for(i=0;i<pNetworkDataset.AttributeCount;i++)
			{

				//get the attribute of the network dataset
                			    
				pNetworkAttribute=pNetworkDataset.get_Attribute(i);
				//if it is a cost attribute,add it to combo box

				if(pNetworkAttribute.UsageType==esriNetworkAttributeUsageType.esriNAUTCost)
				{
					cmbCost.Items.Add(pNetworkAttribute.Name);

				
				}

			


			}
			cmbCost.SelectedIndex=0;

			

			if(isRoute==false)
			{
				pInputFClass = pFWorkspace.OpenFeatureClass("BayAreaIncident");
				LoadNANetworkLocations("Incidents",pInputFClass, 100,ref _pNAContext);
			}
			else
			{
			
			}


			
			pInputFClass = pFWorkspace.OpenFeatureClass("BayAreaLocations");
			if(isRoute==false)
			{
				LoadNANetworkLocations("Facilities", pInputFClass, 100,ref _pNAContext);
			}
			else
			{
				LoadNANetworkLocations("Stops", pInputFClass, 100,ref _pNAContext);
			
			}
			

			
			//'Create Layer for Network Dataset and add to ArcMap
			
			ILayer pLayer;
			INetworkLayer pNetworkLayer=new NetworkLayerClass();

			pNetworkLayer.NetworkDataset = pNetworkDataset;

			pLayer = pNetworkLayer as ILayer;

			pLayer.Name = "Network Dataset";

			_mapControl.AddLayer(pLayer,0);

			//Create a Network Analysis Layer and add to ArcMap

			
			INALayer pNALayer=_pNAContext.Solver.CreateLayer(_pNAContext);
			pLayer = pNALayer as ILayer;
			pLayer.Name = _pNAContext.Solver.DisplayName;
			_mapControl.AddLayer(pLayer,0);
			

		}

		
		public IWorkspace OpenWorkspace(string strGDBName)
		{
			IWorkspace pWorkSpace;
		
			IWorkspaceFactory pWorkspaceFactory=new ShapefileWorkspaceFactoryClass();
		
			pWorkSpace=pWorkspaceFactory.OpenFromFile(strGDBName,0);

			return pWorkSpace;

       
		}

	   
		/// <summary>
		/// 打开workspace中的网络数据集
		/// </summary>
		/// <param name="pWorkspace">一个workspace，workspace可以是shape,access,sde</param>
		/// <param name="sNDSName">要打开的网络数据集名字</param>
		/// <returns>返回INetworkDataset接口</returns>
		
		public INetworkDataset OpenNetworkDataset(IWorkspace pWorkspace,string sNDSName)
		{


			INetworkDataset pNetworkDataset=null;

			IWorkspaceExtensionManager pWorkspaceExtensionManager;

			IWorkspaceExtension pWorkspaceExtension;

			int i,count;

			IDatasetContainer2 pDatasetContainer2;

			//Get Workspace Extension

			pWorkspaceExtensionManager=pWorkspace as IWorkspaceExtensionManager;

			count = pWorkspaceExtensionManager.ExtensionCount;

			for(i=0;i<count;i++)
			{
		  
				pWorkspaceExtension=pWorkspaceExtensionManager.get_Extension(i);
			
				if(pWorkspaceExtension.Name=="Network Dataset")
				{

					pDatasetContainer2=pWorkspaceExtension as IDatasetContainer2;
					//pDatasetContainer2.get_DatasetByName(
				
					pNetworkDataset=pDatasetContainer2.get_DatasetByName(esriDatasetType.esriDTNetworkDataset, sNDSName) as INetworkDataset;

		
				}
			}

			return pNetworkDataset;
	
	
		}
		/*
		'*********************************************************************************
		' Create NASolver and NAContext
		'*********************************************************************************
		*/
		public INAContext CreateSolverContext(INetworkDataset pNetDataset)
		{


			IDENetworkDataset pDENDS;
			
			pDENDS=GetDENetworkDataset(pNetDataset);


			INASolver pNASolver;
			INAContextEdit pContextEdit;

			//NAClosestFacilitySolver is a network analyst solver to find a set of closest facilities from a set of incidents

			pNASolver=new NAClosestFacilitySolver();
			
			pContextEdit=pNASolver.CreateContext(pDENDS,pNASolver.Name) as INAContextEdit;
			
			pContextEdit.Bind(pNetDataset,new GPMessagesClass());



			return pContextEdit as INAContext;




		
		}//end of the function CreateSolverContext

		//DENetworkDataset is a light weight object that holds information about a network dataset

		public IDENetworkDataset GetDENetworkDataset(INetworkDataset pNetDataset)
		{
			
			IDatasetComponent pDSComponent;
			pDSComponent=pNetDataset as IDatasetComponent;
			return pDSComponent.DataElement as IDENetworkDataset;


		
		}

		//LoadNANetworkLocations
		public void LoadNANetworkLocations(string strNAClassName,IFeatureClass pInputFC,double SnapTolerance,ref INAContext m_pNAContext)
		{

			INAClass pNAClass;
			INamedSet pClasses;
			//get The collection of classes associated with the analysis
			pClasses = m_pNAContext.NAClasses;

			/*
			for(int ii=0;ii<pClasses.Count;ii++)
			{
				MessageBox.Show(pClasses.get_Name(ii));

			
			}
			*/
			
			pNAClass = pClasses.get_ItemByName(strNAClassName) as INAClass;

			//Remove all items added to the class (for example, stops or incidents).
			pNAClass.DeleteAllRows();

			// Create a NAClassLoader and set the snap tolerance (meters unit)
			//NAClassLoader to populate stop locations from a point feature class.

			INAClassLoader pLoader=new NAClassLoaderClass();

			pLoader.Locator = m_pNAContext.Locator;
			
			if( SnapTolerance > 0)
			{
				pLoader.Locator.SnapTolerance = SnapTolerance;

			}
			pLoader.NAClass = pNAClass;

			//Create field map to automatically map fields from input class to naclass
			INAClassFieldMap pFieldMap=new NAClassFieldMapClass();

			//pFieldMap.CreateMapping pNAClass.ClassDefinition, pInputFC.Fields;

			pFieldMap.CreateMapping(pNAClass.ClassDefinition,pInputFC.Fields);

			pLoader.FieldMap=pFieldMap;

			int rowsIn=0,rowsLocated=0;

			pLoader.Load(pInputFC.Search(null,true) as ICursor,null,ref rowsIn,ref rowsLocated);

	
		}

		/*
		 * '*********************************************************************************
			' Set Solver Settings
			'*********************************************************************************
		 * */

		public void SetSolverSettings(ref INAContext _m_pNAContext,int CutOffVal,int facCount,string costField,bool isOneWay,bool isHierarchy)
		{
			//Set Route specific Settings
			INASolver pSolver;
			INAClosestFacilitySolver pCFSolver;
			INASolverSettings pSolverSettings;
            
			//得到这个resover
  
			pSolver = _m_pNAContext.Solver;

			pCFSolver=pSolver as INAClosestFacilitySolver;
			  
			//一定要设置为空，如果设置成0会查不出来
			if(CutOffVal==0)
				pCFSolver.DefaultCutoff=null;
			else
				pCFSolver.DefaultCutoff=CutOffVal;
			  

			pCFSolver.DefaultTargetFacilityCount=facCount;

			pCFSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineTrueShapeWithMeasure;

			pCFSolver.TravelDirection=esriNATravelDirection.esriNATravelDirectionToFacility;

			pSolverSettings=pSolver as INASolverSettings;

			//set the impedance attribute

			pSolverSettings.ImpedanceAttributeName=costField;

			//Set the OneWay Restriction if necessary

			IStringArray restrictions;
			restrictions = pSolverSettings.RestrictionAttributeNames;
			restrictions.RemoveAll();
			if(isOneWay==true)
				restrictions.Add("oneway");
			pSolverSettings.RestrictionAttributeNames=restrictions;

			/*
			 *  'Restrict UTurns
			 * */
			pSolverSettings.RestrictUTurns =esriNetworkForwardStarBacktrack.esriNFSBNoBacktrack;

			//IgnoreInvalidLocations allows the network analyst solvers to ignore locations that have not snapped to a network edge
			pSolverSettings.IgnoreInvalidLocations=true;

			// Set the Hierachy attribute

			if(isHierarchy==true)
			{
				
				pSolverSettings.UseHierarchy=true;
				pSolverSettings.HierarchyAttributeName = "hierarchy";
				pSolverSettings.HierarchyLevelCount = 3;
                
				pSolverSettings.set_MaxValueForHierarchy(1,1);
				pSolverSettings.set_NumTransitionToHierarchy(1,9);

				pSolverSettings.set_MaxValueForHierarchy(2,2);
				pSolverSettings.set_NumTransitionToHierarchy(2,9);


			
			} 
			else
				pSolverSettings.UseHierarchy=false;


			// Do not forget to update the context after you set your impedance
			pSolver.UpdateContext(_m_pNAContext, GetDENetworkDataset(_m_pNAContext.NetworkDataset),new GPMessagesClass());

		
		
		}

		// Get the Impedance Cost form the CFRoute Class Output

		public void GetCFOutput(string strNAClass,ref INAContext _m_pNAContext )
		{
			int IncidentID;
			int FacilityID;
			int FacilityRank;
			ICursor pCursor;
			IRow pRow;

			ITable ptable;
            
			ptable=_m_pNAContext.NAClasses.get_ItemByName(strNAClass) as ITable;
			//ptable=_m_pNAContext.NAClasses.get_Item(3) as ITable;
			//ptable.ToString

			

			
			//    for(int ii=0;ii<4;ii++)
			//	MessageBox.Show(_m_pNAContext.NAClasses.get_Name(ii));

			if(ptable==null)
			{
				return;
			}
			
			if(ptable.RowCount(null)>0)
			{

				pCursor = ptable.Search(null, false);
				pRow = pCursor.NextRow();
				while(pRow!=null)
				{
					IncidentID = Convert.ToInt32(pRow.get_Value(ptable.FindField("IncidentID")).ToString());
					FacilityID =Convert.ToInt32(pRow.get_Value(ptable.FindField("FacilityID")).ToString());
					FacilityRank = Convert.ToInt32(pRow.get_Value(ptable.FindField("FacilityRank")).ToString());
					pRow=pCursor.NextRow();
				
				}

			
			}

		
		}



		//the rest of the class if for the best route

		/*
		 * '*********************************************************************************
			  ' Set Route Solver Settings
		   '*********************************************************************************
		 * */

		public void SetSolverSettings(ref INAContext pContext , string sImpedanceName,bool bOneWay ,bool bUseHierarchy)
		{
			
			INASolver pSolver;
            
			pSolver = pContext.Solver;
             
			INARouteSolver pRteSolver=pSolver as INARouteSolver;

			pRteSolver.OutputLines =esriNAOutputLineType.esriNAOutputLineTrueShapeWithMeasure;
			pRteSolver.CreateTraversalResult = true;
			pRteSolver.UseTimeWindows = false;
			pRteSolver.FindBestSequence = false;
			pRteSolver.PreserveFirstStop = false;
			pRteSolver.PreserveLastStop = false;


			//Set generic Solver settings
			// set the impedance attribute
			INASolverSettings pSolverSettings=pSolver as INASolverSettings;
            
			pSolverSettings.ImpedanceAttributeName = sImpedanceName;

			// Set the OneWay Restriction if necessary

			IStringArray restrictions;
			restrictions = pSolverSettings.RestrictionAttributeNames;
			restrictions.RemoveAll();
			if(bOneWay==true)
				restrictions.Add("oneway");
			pSolverSettings.RestrictionAttributeNames=restrictions;

			/*
			 *  'Restrict UTurns
			 * */
			pSolverSettings.RestrictUTurns =esriNetworkForwardStarBacktrack.esriNFSBNoBacktrack;

			//IgnoreInvalidLocations allows the network analyst solvers to ignore locations that have not snapped to a network edge
			pSolverSettings.IgnoreInvalidLocations=true;


			if(bUseHierarchy==true)
			{
				
				pSolverSettings.UseHierarchy=true;
				pSolverSettings.HierarchyAttributeName = "hierarchy";
				pSolverSettings.HierarchyLevelCount = 3;
                
				pSolverSettings.set_MaxValueForHierarchy(1,1);
				pSolverSettings.set_NumTransitionToHierarchy(1,9);

				pSolverSettings.set_MaxValueForHierarchy(2,2);
				pSolverSettings.set_NumTransitionToHierarchy(2,9);


			
			} 
			else
				pSolverSettings.UseHierarchy=false;


			// Do not forget to update the context after you set your impedance
			pSolver.UpdateContext(pContext, GetDENetworkDataset(pContext.NetworkDataset),new GPMessagesClass());

    
				   
		}
    
		public INAContext CreateRouteSolverContext(INetworkDataset pNetDataset)
		{
			
			INAContextEdit pContextEdit;
			IDENetworkDataset pDENDS= GetDENetworkDataset(pNetDataset);
			INASolver pNASolver=(new NARouteSolverClass()) as INASolver;

			pContextEdit = pNASolver.CreateContext(pDENDS, "Route") as INAContextEdit;

			pContextEdit.Bind(pNetDataset,new GPMessagesClass());



			return pContextEdit as INAContext;
			
			


		}


	}	//end of class

	

} //end of namespace