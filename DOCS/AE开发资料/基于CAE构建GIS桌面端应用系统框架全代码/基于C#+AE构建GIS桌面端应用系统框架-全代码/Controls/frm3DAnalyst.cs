using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
namespace Controls
{
    public partial class frm3DAnalyst : Form
    {
        public frm3DAnalyst()
        {
            InitializeComponent();
        }
        public IScene Get3DScene()
        {
            return axSceneControl1.Scene;
        }
        private void axSceneControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ISceneControlEvents_OnMouseDownEvent e)
        {
            IPoint pPoint = null;
            object objOwner = null;
            object objObject = null;

            axSceneControl1.SceneGraph.Locate(axSceneControl1.SceneViewer, e.x, e.y, esriScenePickMode.esriScenePickGeography, true, out pPoint, out objOwner, out objObject);
        

            ITextElement pTextElement = new TextElementClass();
            pTextElement.Text = "dddddd";
            
            IGraphicsContainer3D pGCon3D = axSceneControl1.Scene.BasicGraphicsLayer as IGraphicsContainer3D;
            IElement  pElement = new MarkerElementClass();
            IMarkerElement pPointElement = pElement as MarkerElementClass;
            ILineElement pLineElement = pElement as ILineElement;
            ISimpleLineSymbol pLSymbol = new SimpleLineSymbolClass();
            ISimpleMarkerSymbol pMSym = new SimpleMarkerSymbolClass();
            IColor pFromColor = new RgbColorClass();
            IRgbColor pRgbColor = pFromColor as IRgbColor;
            pRgbColor.Red = 255;
            pRgbColor.Green = 0;
            pRgbColor.Blue = 0;
            pMSym.Size = 10;
            pMSym.Color = pFromColor;
            pMSym.Style = esriSimpleMarkerStyle.esriSMSDiamond;
            pPointElement.Symbol = pMSym;
            pLSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            pElement.Geometry = pPoint;
      
         
            pGCon3D.AddElement(pElement as IElement );
            axSceneControl1.Scene.SceneGraph.RefreshViewers();
            IDisplay3D pIDisplay3D = axSceneControl1.Scene.SceneGraph as IDisplay3D ;
            pIDisplay3D.FlashLocation(pPoint);
        }

        private void frm3DAnalyst_Load(object sender, EventArgs e)
        {
            axToolbarControl1.SetBuddyControl(axSceneControl1.Object);
            axTOCControl1.SetBuddyControl(axSceneControl1.Object);
            string progID;

            progID = "esriControlToolsGeneric.ControlsSceneFlyTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControlToolsGeneric.ControlsSceneFullExtentCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);


            progID = "esriControlToolsGeneric.ControlsSceneNarrowFOVCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);


            progID = "esriControlToolsGeneric.ControlsSceneNavigateTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);


            progID = "esriControlToolsGeneric.ControlsSceneOpenDocCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);


            progID = "esriControlToolsGeneric.ControlsScenePanTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);


            progID = "esriControlToolsGeneric.ControlsSceneZoomInOutTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControlToolsGeneric.ControlsSceneZoomInOutTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControlToolsGeneric.ControlsSceneZoomInTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);


            progID = "esriControlToolsGeneric.ControlsSceneZoomOutTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
        }
    }
}