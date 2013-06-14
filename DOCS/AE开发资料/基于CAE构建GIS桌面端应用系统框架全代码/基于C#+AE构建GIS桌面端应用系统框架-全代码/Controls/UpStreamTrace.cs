using System;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Utility.CATIDs;



namespace Controls
{
	/// <summary>
	/// UpStreamTrace,��Geometric Network�������ݷ�����������2005.10.8��Z8�г��ϡ�
	/// </summary>
	
	[ClassInterface(ClassInterfaceType.None)]
    [Guid("a7d0f155-5885-4698-a0f5-803cda75afcc")]



	public sealed class UpStreamTrace:BaseTool
	{
		
		private IHookHelper m_HookHelper;
		//find the nearest network element to a given point. 
		ITraceFlowSolverGEN ipTraceFlowSolver;

		IPointToEID mPointToEID;

		INetSolver ipNetSolver;

		IGeometricNetwork pGeometricNetwork;

		INetwork ipNetwork;

		IPoint pt;


		
		public UpStreamTrace()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			m_HookHelper=new HookHelperClass();
			base.m_caption = "���ݷ���";
			base.m_category = "CustomCommands";
			base.m_message = "�������";
			base.m_name = "CustomCommands_sloverPath";
			base.m_toolTip = "���ݷ���";

		}




		public override void OnClick()
		{
			
		}

		public override void OnCreate(object hook)
		{
			m_HookHelper.Hook=hook;

		}

		public override void OnMouseDown(int Button, int Shift, int X, int Y)
		{
			try
			{
				pt=m_HookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X,Y);
				setUpstreamJunctionFlag(pt);
			}
			catch(Exception e){
				MessageBox.Show(e.Message);
			}
		}

		private void openGeoNetwork(){
			string fpath=@"C:\ArcGIS91_Demos\Sewer9\data\sewer3.mdb";
			IFeatureWorkspace pFWS=Utility.openPDB(fpath);
			IFeatureDataset pFdataset=pFWS.OpenFeatureDataset("urban");
			INetworkCollection pNetworkCollection=pFdataset as INetworkCollection;
			//�õ�Sewer Network����TRACE
			pGeometricNetwork=pNetworkCollection.get_GeometricNetworkByName("Sewer_Network");
		
		}

		
		private void setUpstreamJunctionFlag(IPoint pPoint){

			try
			{

				if(pGeometricNetwork==null){
					openGeoNetwork();

				}

				IEnumNetEID m_ipEnumNetEID_Junctions,m_ipEnumNetEID_Edges;//����������������Junctions��Edges

				ipNetwork=pGeometricNetwork.Network;

				/*
				IMarkerSymbol pMarkerSym=SpatialHelperFunction.FindMarkerSym("Civic.ServerStyle", "Default", "Pin Flag Square");
				if(pMarkerSym==null){
					MessageBox.Show("�޷�ȡ��Symbol");
					return;
				}

				IRgbColor pRGBColor=Utility.getRGBColor(255, 0, 0);
			
				pMarkerSym.Color=pRGBColor;
				pMarkerSym.Size=26;
				pMarkerSym.XOffset=10;
				pMarkerSym.YOffset=10;
				//�޷�ʹ�� IFlagDisplay��ֻ�� INetworkAnalysisExtFlags�ſ���ʹ��IFlagDisplay

				Utility.drawPointToGraphicLayer(m_HookHelper.ActiveView,pPoint,pMarkerSym);
				*/
				

				int pJunctionID;
				IPoint pLocation;
				int iUserClassID,iUserID,iUserSubID;
				INetElements ipNetElements;

				ipNetElements = ipNetwork as INetElements; //�õ�network�����е�Elements

				mPointToEID=new PointToEIDClass();
				
				//��������GeometricNetwork
				mPointToEID.GeometricNetwork=pGeometricNetwork;

				//��������ֵ
				mPointToEID.SnapTolerance=m_HookHelper.ActiveView.Extent.Envelope.Width/100;

				//����Source Map
				mPointToEID.SourceMap=m_HookHelper.ActiveView.FocusMap;

				//�õ������JunctionID
				mPointToEID.GetNearestJunction(pPoint,out pJunctionID,out pLocation);

				//Each element in a logical network has a unique element ID (EID). 
				ipNetElements.QueryIDs(pJunctionID,esriElementType.esriETJunction,out iUserClassID,out iUserID,out iUserSubID);

				//�õ�����Junction��ID

				//�޷�ʹ�� IFlagDisplay��ֻ�� INetworkAnalysisExtFlags�ſ���ʹ��IFlagDisplay

				INetFlag ipNetFlag=new JunctionFlagClass();

				ipNetFlag.UserClassID=iUserClassID;

				ipNetFlag.UserID=iUserID;

				ipNetFlag.UserSubID=iUserSubID;



				IJunctionFlag [] pArrayJFlag=new IJunctionFlag[1];

				pArrayJFlag[0]=ipNetFlag as IJunctionFlag;

				ipTraceFlowSolver=new TraceFlowSolverClass() as ITraceFlowSolverGEN;

				//get the inetsolver interface
				ipNetSolver=ipTraceFlowSolver as INetSolver;

				ipNetSolver.SourceNetwork=pGeometricNetwork.Network;



				

				ipTraceFlowSolver.PutJunctionOrigins(ref pArrayJFlag);

				ipTraceFlowSolver.TraceIndeterminateFlow=false;

				object[] totalCost=new object[1];
				

				//ipTraceFlowSolver.FindSource(esriFlowMethod.esriFMUpstream,esriShortestPathObjFn.esriSPObjFnMinSum,out m_ipEnumNetEID_Junctions,out m_ipEnumNetEID_Edges,1,ref totalCost);

				ipTraceFlowSolver.FindFlowElements(esriFlowMethod.esriFMUpstream,
					esriFlowElements.esriFEEdges,
					out m_ipEnumNetEID_Junctions,
					out m_ipEnumNetEID_Edges);


				SpatialHelperFunction.pathToPolyline(pGeometricNetwork,m_HookHelper.ActiveView,m_ipEnumNetEID_Edges);
				
				

				//ipTraceFlowSolver.FindFlowEndElements(esriFlowMethod.esriFMUpstream,esriFlowElements.esriFEJunctionsAndEdges,out m_ipEnumNetEID_Junctions,out m_ipEnumNetEID_Edges);

				m_HookHelper.ActiveView.Refresh();
			}
			catch(Exception e){
				MessageBox.Show(e.Message);
			
			}



			



            			
		
		
		}



		


	}
}
