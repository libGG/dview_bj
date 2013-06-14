using System;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
//using ESRI.ArcGIS.Utility.BaseClasses;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Geodatabase;



namespace Controls
{
	/// <summary>
	/// moveFeatureTool 的摘要说明。
	/// </summary>
	[ClassInterface(ClassInterfaceType.None)]
    [Guid("becc360e-b9f6-4a79-81b5-7096fe8aa8aa")]


	public sealed class moveFeatureTool:BaseTool
	{
		
		private IHookHelper m_HookHelper;
		private int currentX=0,currentY=0;
		
		public moveFeatureTool()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			base.m_caption = "移动要素";
			base.m_category = "CustomCommands";
			base.m_message = "MoveFeature";
			base.m_name = "CustomCommands_identify";
			base.m_toolTip = "移动要素";

			m_HookHelper= new HookHelperClass();



		}

		public override void OnMouseDown(int Button, int Shift, int X, int Y)
		{
			//MessageBox.Show("移动要素");
			//pFeature.h

			


		}

		public override void OnCreate(object hook)
		{
			m_HookHelper.Hook=hook;


		}

		public override bool Enabled
		{
			get
			{
				if(m_HookHelper.FocusMap.SelectionCount>0){
					return true;
				
				}
				else return false;

			}
		}


		public override void OnMouseMove(int Button, int Shift, int X, int Y)
		{
			
			if(Button!=1) return;

			if(currentX==0){
			  currentX=X;
			}

			if(currentY==0) currentY=Y;

			try
			{
			

				if(((X-currentX)>5)||((Y-currentY)>5))
				{
					ISelection pSelection;
					IEnumFeature pEnumFeature;
					pSelection=m_HookHelper.FocusMap.FeatureSelection;
					ITransform2D pTF2D;
					IGeometry pGeom;

					IActiveView pViewer=m_HookHelper.ActiveView;
					IGraphicsContainer pGC=pViewer as IGraphicsContainer;
					IElement pElement;//=new PolygonElementClass() as IElement;
					IPolygon pPoly;
					pEnumFeature=pSelection as IEnumFeature;
					pEnumFeature.Reset();
					IFeature pFeature=pEnumFeature.Next();
					while(pFeature!=null)
					{
						pGeom=pFeature.Shape;
						pTF2D=pGeom as ITransform2D;
						pTF2D.Move(X-currentX,Y-currentY);
						pFeature.Shape=pGeom;

						
						pPoly=new PolygonClass();
						pPoly=pFeature.ShapeCopy as IPolygon;

						pElement=new PolygonElementClass() as IElement;

						pElement.Geometry=pPoly;

						pGC.DeleteAllElements();

						pGC.AddElement(pElement,0);

						//pViewer as igeogra
					
					
						pFeature=pEnumFeature.Next();
                    
				
					}//end of while
					 currentX=X;
					 currentY=Y;
					pViewer.Refresh();
			
				}//end of if
			}
			catch(Exception e){
				MessageBox.Show(e.InnerException+e.Message);
			
			}

			
		}




 
	}
}
