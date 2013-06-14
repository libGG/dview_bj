using System;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;

namespace Controls
{
	/// <summary>
	/// slovePathTool 的摘要说明。
	/// </summary>
	
	[ClassInterface(ClassInterfaceType.None)]
    [Guid("c7810d3f-5c07-4d23-a084-4a06d07776da")]

	public sealed class slovePathTool:BaseTool
	{
		private IHookHelper m_HookHelper;
		//find the nearest network element to a given point. 
		private IPointToEID m_ipPointToEID;

		private StatusBar pStatusBar;

		IGeometricNetwork m_ipGeometricNetwork;

		IPoint point;
		
		IPointCollection mPointArray;

		ITraceFlowSolver ipTraceFlowSolver;

		INetSolver ipNetSolver;

		IEnumNetEID m_ipEnumNetEID_Junctions,m_ipEnumNetEID_Edges;

		public void setGNetwork(IGeometricNetwork _mNetwork){

			m_ipGeometricNetwork=_mNetwork;

		
		}

		public slovePathTool(StatusBar _pStatusBar)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			pStatusBar=_pStatusBar;

			base.m_caption = "查找路径";
			base.m_category = "CustomCommands";
			base.m_message = "pathFinder";
			base.m_name = "CustomCommands_sloverPath";
			base.m_toolTip = "查找路径";


			m_HookHelper=new HookHelperClass();
		// set up the IPointToEID ...
           
		}

		public override void OnCreate(object hook)
		{
			m_HookHelper.Hook=hook;

		}

		public override void OnClick()
		{
			
		}

		public override void OnMouseDown(int Button, int Shift, int X, int Y)
			
		{
			//3是Ctrl键
			if(Shift==2)  return;
				
			if(mPointArray==null){
				mPointArray=new MultipointClass();
			
			}
			object obMissing=Type.Missing;
			
			point = m_HookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);

			mPointArray.AddPoint(point,ref obMissing,ref obMissing);
			
			
		}

		public override bool Enabled
		{
			get
			{
				if(m_HookHelper.ActiveView.FocusMap.LayerCount>0) return true;
				else return false;
			}
		}

		public override void OnDblClick()
		{
			//双击屏幕
			try
			{
				
				IScreenDisplay pScreenDisplay;

				pScreenDisplay=m_HookHelper.ActiveView.ScreenDisplay;

				ILineSymbol ipLineSymbol=new CartographicLineSymbolClass();
				ipLineSymbol.Width = 5;

				if(slovePath()==false) return;

				pathToPolyline();
				

				//if(ipPolyResult!=null)
				//{

				//	Utility.drawPolyline(m_HookHelper.ActiveView,ipPolyResult);

				//	pScreenDisplay.StartDrawing(0,(short)esriScreenCache.esriNoScreenCache);

				//	pScreenDisplay.DrawPolyline(ipPolyResult);

				//	pScreenDisplay.FinishDrawing();
				//}
			}
			catch(Exception e){
				MessageBox.Show(e.Message);
			}


		}



		private bool slovePath()
		{

			try
			{
				
				double costLength=0;
				m_ipPointToEID = new PointToEIDClass(); 
				m_ipPointToEID.SourceMap=m_HookHelper.ActiveView.FocusMap;
				m_ipPointToEID.GeometricNetwork = m_ipGeometricNetwork;
				m_ipPointToEID.SnapTolerance=m_HookHelper.ActiveView.Extent.Envelope.Width/100;

			
				INetwork ipNetwork;

				INetElements ipNetElements;
				INetFlag ipNetFlag;

				//IEdgeFlag ipEdgeFlag;

				IEdgeFlag [] EdgeFlagArray;

				int pEdgeID;
				IPoint pLocation;
				double dblEdgePercent;
				int iUserClassID,iUserID,iUserSubID;

				// look up the EID for the current point  (this will populate intEdgeID and dblEdgePercent)
			
				ipTraceFlowSolver=new TraceFlowSolverClass() as ITraceFlowSolver;

				//get the inetsolver interface
				ipNetSolver=ipTraceFlowSolver as INetSolver;

				ipNetwork=m_ipGeometricNetwork.Network;

				//set the net solver's source network
				ipNetSolver.SourceNetwork=ipNetwork;
	        
				//make edge flags from the points
				//the INetElements interface is needed to get UserID, UserClassID,
				//and UserSubID from an element id

				EdgeFlagArray=new IEdgeFlag[mPointArray.PointCount];
				ipNetElements = ipNetwork as INetElements;


				for(int ii=0;ii<mPointArray.PointCount;ii++)
				{
					

					ipNetFlag = new EdgeFlagClass();

					point=mPointArray.get_Point(ii);

				

					m_ipPointToEID.GetNearestEdge(point,out pEdgeID,out pLocation,out dblEdgePercent);

					//iUserClassID是featureclass ID,userID是objectID,userSubID
					ipNetElements.QueryIDs(pEdgeID,esriElementType.esriETEdge,out iUserClassID,out iUserID,out iUserSubID);

					ipNetFlag.UserClassID=iUserClassID;

					ipNetFlag.UserID=iUserID;

					ipNetFlag.UserSubID=iUserSubID;

					EdgeFlagArray[ii]=ipNetFlag as IEdgeFlag;

					//MessageBox.Show(iUserID.ToString());

				}

				//添加到TraceFlowSolver中
				ITraceFlowSolverGEN pTFSolverGEN=ipTraceFlowSolver as ITraceFlowSolverGEN;
				pTFSolverGEN.PutEdgeOrigins(ref EdgeFlagArray);

				

				//get the INetSchema interface
				INetSchema ipNetSchema = ipNetwork as INetSchema;
			
				INetWeight ipNetWeight = ipNetSchema.get_Weight(0);

				//MessageBox.Show(ipNetWeight.WeightName);

				INetSolverWeights ipNetSolverWeights=ipTraceFlowSolver as INetSolverWeights;

				//来回使用同一个权重

				

				ipNetSolverWeights.FromToEdgeWeight=ipNetWeight;

				ipNetSolverWeights.ToFromEdgeWeight=ipNetWeight;

		

				object [] totalCost=new object[mPointArray.PointCount-1];

				

			

				pTFSolverGEN.FindPath(esriFlowMethod.esriFMConnected,
					esriShortestPathObjFn.esriSPObjFnMinSum,
					out m_ipEnumNetEID_Junctions,
					out m_ipEnumNetEID_Edges,
					mPointArray.PointCount-1,ref totalCost);
				//MessageBox.Show(totalCost[0].ToString());

				

				

				for(int ii=0;ii<totalCost.Length;ii++){
					costLength+=(double)(totalCost[ii]);
					}
				pStatusBar.Panels[0].Text="水管长度:"+costLength.ToString();
					return true;
			}
			catch(Exception e){
				MessageBox.Show(e.Message);
				return false;
			
			}

			
		}


		private void pathToPolyline(){

			
			try
			{

				IEIDHelper piEIDHelper=new EIDHelperClass();

				piEIDHelper.GeometricNetwork=m_ipGeometricNetwork;

				piEIDHelper.OutputSpatialReference=m_HookHelper.ActiveView.FocusMap.SpatialReference;

				piEIDHelper.ReturnFeatures=true;

				IPolyline mPolyline=new PolylineClass();
                
				mPolyline.SpatialReference=m_HookHelper.ActiveView.FocusMap.SpatialReference;

				IEIDInfo ipEIDInfo;

				IEnumEIDInfo piEnumEIDInfo;

				IGeometry ipGeometry=null;

				piEnumEIDInfo=piEIDHelper.CreateEnumEIDInfo(m_ipEnumNetEID_Edges);

				IGeometryCollection pGeoCollection=mPolyline as IGeometryCollection;
				
				piEnumEIDInfo.Reset();

				object objMiss=Type.Missing;

				for(int ii=0;ii<piEnumEIDInfo.Count;ii++)
				{
				
					ipEIDInfo=piEnumEIDInfo.Next();
				
					ipGeometry=ipEIDInfo.Feature.Shape;

					if(ipGeometry!=null)
						Utility.drawPolyline(m_HookHelper.ActiveView,ipGeometry as IPolyline);
			
				}

				//return ipGeometry as IPolyline;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			
			}
			finally{
			mPointArray=null;
			m_ipEnumNetEID_Junctions=null;
			m_ipEnumNetEID_Edges=null;
			}

			


		
		}


	}
}
