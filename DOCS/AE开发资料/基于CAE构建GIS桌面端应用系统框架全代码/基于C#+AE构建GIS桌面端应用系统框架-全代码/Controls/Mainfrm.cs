/*
 Copyright ２００６-２００７ ESRI中国（北京）有限公司

 All rights reserved under the copyright laws of the China.

 You may freely redistribute and use this sample code, with or without modification.

 Disclaimer: THE SAMPLE CODE IS PROVIDED "AS IS" AND ANY EXPRESS OR IMPLIED 
 WARRANTIES, INCLUDING THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
 FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL ESRI OR 
 CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
 OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
 SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 INTERRUPTION) SUSTAINED BY YOU OR A THIRD PARTY, HOWEVER CAUSED AND ON ANY 
 THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT ARISING IN ANY 
 WAY OUT OF THE USE OF THIS SAMPLE CODE, EVEN IF ADVISED OF THE POSSIBILITY OF 
 SUCH DAMAGE.

 For additional information contact: Environmental Systems Research Institute, Inc.

 
 成都市提督街８８号２６０６室

 四川, 中国，６１００１６

 Email: chenxd@esrichina-bj.cn
*/
using System;
using System.Windows.Forms;
using rpaulo.toolbar;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Analyst3D; 
using ESRI.ArcGIS.Controls;
 
using ESRI.ArcGIS.Utility;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.ADF.CATIDs;
using System.Runtime.InteropServices;

namespace Controls
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    ///  
    public delegate void OnExtentUpdatingHandler(object sender, Newleaf.ExtentUpdatedEventArgs e);
    public class MainFrm : System.Windows.Forms.Form
    {
        private static LicenseInitializer m_AOLicenseInitializer = new LicenseInitializer();
        
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);

        }

        #endregion
        #endregion

        private OnExtentUpdatingHandler m_ExtentUpdatedHandler;

        private const int WM_ENTERSIZEMOVE = 0x231;
        private const int WM_EXITSIZEMOVE = 0x232;

        private int ggj = 0;

        //private IToolbarMenu m_ToolbarMenu = new ToolbarMenuClass();					//The popup menu
        private IEnvelope m_Envelope;													//The envelope drawn on the MapControl
        private System.Object m_FillSymbol;													//The symbol used to draw the envelope on the MapControl
        private ITransformEvents_VisibleBoundsUpdatedEventHandler visBoundsUpdatedE;	//The PageLayoutControl's focus map events	
        //private ICustomizeDialog m_CustomizeDialog = new CustomizeDialogClass();		//The CustomizeDialog used by the ToolbarControl
        //private ICustomizeDialogEvents_OnStartDialogEventHandler startDialogE;			//The CustomizeDialog start event
        //	private ICustomizeDialogEvents_OnCloseDialogEventHandler closeDialogE;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem23;
        private System.Windows.Forms.MenuItem menuItem25;
        private System.Windows.Forms.MenuItem menuItem27;
        private System.Windows.Forms.MenuItem menuItem28;
        private System.Windows.Forms.MenuItem menuItem29;
        private System.Windows.Forms.MenuItem menuItem30;
        private System.Windows.Forms.MenuItem menuItem31;
        private slovePathTool tSP;
        private System.Windows.Forms.MenuItem menuItem36;
        private System.Windows.Forms.MenuItem menuItem37;
        private System.Windows.Forms.MenuItem menuItem38;
        private System.Windows.Forms.MenuItem menuItem39;
        private System.Windows.Forms.MenuItem menuItem40;
        private System.Windows.Forms.MenuItem menuItem12;
        public SpatialAnalysisOption SAoption;
        public ModPublicClass modPublicClass;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarBtnNewMxd;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton toolBarBtnOpenMxd;
        private System.Windows.Forms.ToolBarButton toolBarBtnSeperator;
        private System.Windows.Forms.ToolBarButton toolBarBtnUndo;
        private System.Windows.Forms.ToolBarButton toolBarBtnRedo;
        private System.Windows.Forms.ToolBarButton toolBarBtnSeperator2;
        private System.Windows.Forms.ToolBarButton toolBarBtnAddData;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarBtnZoomIn;
        private System.Windows.Forms.ToolBarButton toolBarBtnZoomOut;
        private System.Windows.Forms.ToolBarButton toolBarBtnPan;
        private System.Windows.Forms.ToolBarButton toolBarBtnFull;
        private System.Windows.Forms.ToolBarButton toolBarBFixZoomIn;
        private System.Windows.Forms.ToolBarButton toolBarBtnFixZoomOut;
        private System.Windows.Forms.ToolBarButton toolBarBtnBack;
        private System.Windows.Forms.ToolBarButton toolBarBtnTo;
        private System.Windows.Forms.ToolBarButton toolBarBtnRSelect;
        private System.Windows.Forms.ToolBarButton toolBarBtnQuery;
        private System.Windows.Forms.ToolBarButton toolBarBtnFind;
        private System.Windows.Forms.ToolBarButton toolBarBtnMeasure;
        private System.Windows.Forms.ToolBarButton toolBarBtnSave;

        private ILayer currentLayer;
        private System.Windows.Forms.ToolBarButton toolBarBtnSelRectangle;
        private System.Windows.Forms.ToolBarButton toolBarBtnSelLine;
        private System.Windows.Forms.ToolBarButton toolBarBtnSelEcllipse;
        private System.Windows.Forms.ToolBarButton toolBarBtnSelPolygon;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private string m_BasicOperationTool;//标识当前所选择的工具名称
        private IPoint m_pStartPoint = null;//开始量测时第一个鼠标点
        private ILineSymbol m_pLineSymbol = null;//量测的线符号
        private ITextSymbol m_pTextSymbol = null;//量测的文本符号
        private IPoint m_pTextPoint = null;
        private IPolyline m_pLinePolyline = null;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem menuItem34;
        private System.Windows.Forms.MenuItem menuItem41;
        private System.Windows.Forms.MenuItem menuItem42;
        private System.Windows.Forms.MenuItem menuItem43;
        private System.Windows.Forms.MenuItem menuItem44;
        private System.Windows.Forms.MenuItem menuItem45;
        private System.Windows.Forms.MenuItem menuItem46;
        private System.Windows.Forms.MenuItem menuItem47;
        private System.Windows.Forms.MenuItem menuItem48;
        private System.Windows.Forms.MenuItem menuItem49;
        private System.Windows.Forms.MenuItem menuItem50;
        private System.Windows.Forms.MenuItem menuItem51;
        private System.Windows.Forms.MenuItem menuItem52;
        private System.Windows.Forms.MenuItem menuItem53;
        private System.Windows.Forms.MenuItem menuItem54;
        private System.Windows.Forms.MenuItem menuItem55;
        private System.Windows.Forms.MenuItem menuItem56;
        private System.Windows.Forms.MenuItem menuItem57;
        private System.Windows.Forms.MenuItem menuItem58;
        private System.Windows.Forms.MenuItem menuItem59;
        private System.Windows.Forms.MenuItem menuItem60;
        private System.Windows.Forms.MenuItem menuItem61;
        private SplitContainer splitContainer1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private bool m_bInUse;
        //鹰眼实现涉及的变量
        private RectangleElementClass m_AOI;
        private IFillSymbol m_pFillSymbol;
        private IFillSymbol m_pSelectedSymbol;
        private MenuItem menuItem13;
        private MenuItem menuItem14;
        private AxMapControl axMapControl2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ToolBarButton toolBarButton3;
        private ToolBarButton toolBarButtonOpen;
        private ToolBarButton toolBarButton6;
        private ToolBarButton toolBarButtonAdd;
        private ToolBarButton toolBarButtonMove;
        private ToolBarButton toolBarButtonSolve;
        private ToolBarButton toolBarButtonWin;
        private ContextMenu contextMenu2;
        private MenuItem menuItem21;
        private MenuItem menuItem22;
        private MenuItem menuItem24;
        private MenuItem menuItem26;
        private MenuItem menuItem32;
        private MenuItem menuItem33;
        private ToolBar toolBar2;
        private ToolBarButton toolBarButton4;
        //
        ToolBarManager _toolBarManager;
        private ContextMenu contextMenu3;
        private MenuItem menuItem35;
        //网络分析
        // Reference to Network Analyst Environment
        private IEngineNetworkAnalystEnvironment m_naEnv;
        // Reference to NAWindow.  Need to hold on to reference for events to work.
        private IEngineNAWindow m_naWindow;
        private int iClosetFCount = 1;
        private int iClosetRCount = 1;
        private string m_sNAName;
        private TreeNode m_NetNodeSelected;
        public INAContext m_NAContext;
        public INetworkDataset m_pNetDataset;
        private MenuItem menuItem62;
        private MenuItem menuItem63;
        private MenuItem menuItem64;
        private MenuItem menuItem65;
        private MenuItem menuItem66;
        public string strNetAnalystContext;
        private MenuItem menuItem67;
        private MenuItem menuItem68;
        //几何网络分析
        IGeometricNetwork pGeoNetwork;
        private IArray pNetFlagArray;
        private MenuItem menuItem69;
        private MenuItem menuItem70;
        private MenuItem menuItem71;
        private AxToolbarControl axToolbarControl1;
        private MenuItem menuItem72;
        private AxLicenseControl axLicenseControl1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private TreeView treeViewListItem;
        private ComboBox comboBoxNetList;
        private Button buttonNetSetting;//剖面分析
        private int iProfilePoint = 0;
        public MainFrm()
        {
            //
            // Required for Windows Form Designer support
            //
            SAoption = new SpatialAnalysisOption("c:\\temp");
            IMapDocument pMapDocument = new MapDocumentClass();

            modPublicClass = new ModPublicClass(pMapDocument, @"D:\PPT\培训PPT\CSHARPDEMO\CSharp\data", "data.mxd");
            InitializeComponent();
            m_AOI = new RectangleElementClass();
            IElementProperties property = m_AOI as IElementProperties;
            property.Name = "Map_AOI";

            ResetFillSymbol();
            //控制工具条
            _toolBarManager = new ToolBarManager(this, this);


            // The control Text property is used to draw the bar name while floating
            // and on view/hide menu.

            toolBar1.Text = "基本工具";
            toolBar2.Text = "网络分析工具条";
             
            // Add toolbar (default position)
            _toolBarManager.AddControl(toolBar1, DockStyle.Top);

            _toolBarManager.AddControl(toolBar2, DockStyle.None);
            _toolBarManager.AddControl(axToolbarControl1, DockStyle.None);
            pNetFlagArray = new ArrayClass();

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem36 = new System.Windows.Forms.MenuItem();
            this.menuItem37 = new System.Windows.Forms.MenuItem();
            this.menuItem38 = new System.Windows.Forms.MenuItem();
            this.menuItem39 = new System.Windows.Forms.MenuItem();
            this.menuItem40 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem34 = new System.Windows.Forms.MenuItem();
            this.menuItem41 = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this.menuItem46 = new System.Windows.Forms.MenuItem();
            this.menuItem47 = new System.Windows.Forms.MenuItem();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem49 = new System.Windows.Forms.MenuItem();
            this.menuItem52 = new System.Windows.Forms.MenuItem();
            this.menuItem50 = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this.menuItem53 = new System.Windows.Forms.MenuItem();
            this.menuItem54 = new System.Windows.Forms.MenuItem();
            this.menuItem55 = new System.Windows.Forms.MenuItem();
            this.menuItem56 = new System.Windows.Forms.MenuItem();
            this.menuItem57 = new System.Windows.Forms.MenuItem();
            this.menuItem58 = new System.Windows.Forms.MenuItem();
            this.menuItem59 = new System.Windows.Forms.MenuItem();
            this.menuItem60 = new System.Windows.Forms.MenuItem();
            this.menuItem61 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem69 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem64 = new System.Windows.Forms.MenuItem();
            this.menuItem65 = new System.Windows.Forms.MenuItem();
            this.menuItem67 = new System.Windows.Forms.MenuItem();
            this.menuItem70 = new System.Windows.Forms.MenuItem();
            this.menuItem68 = new System.Windows.Forms.MenuItem();
            this.menuItem72 = new System.Windows.Forms.MenuItem();
            this.menuItem71 = new System.Windows.Forms.MenuItem();
            this.menuItem66 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem62 = new System.Windows.Forms.MenuItem();
            this.menuItem63 = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarBtnNewMxd = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnOpenMxd = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSave = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSeperator = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnUndo = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnRedo = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSeperator2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnAddData = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnZoomIn = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnZoomOut = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnPan = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnFull = new System.Windows.Forms.ToolBarButton();
            this.toolBarBFixZoomIn = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnFixZoomOut = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnBack = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnTo = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnRSelect = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnQuery = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnFind = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnMeasure = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSelRectangle = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSelLine = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSelEcllipse = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSelPolygon = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeViewListItem = new System.Windows.Forms.TreeView();
            this.comboBoxNetList = new System.Windows.Forms.ComboBox();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.toolBar2 = new System.Windows.Forms.ToolBar();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonOpen = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonAdd = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonMove = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSolve = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonWin = new System.Windows.Forms.ToolBarButton();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.contextMenu3 = new System.Windows.Forms.ContextMenu();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.buttonNetSetting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 429);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(960, 22);
            this.statusBar1.TabIndex = 11;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 300;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 436;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem20,
            this.menuItem11,
            this.menuItem18,
            this.menuItem8,
            this.menuItem64,
            this.menuItem6});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem17,
            this.menuItem31,
            this.menuItem30,
            this.menuItem25,
            this.menuItem27,
            this.menuItem28,
            this.menuItem29,
            this.menuItem5});
            this.menuItem1.Text = "文件";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "连接SDE";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "打开Raster";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "打开Shape文件";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 3;
            this.menuItem17.Text = "打开Tin";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 4;
            this.menuItem31.Text = "打开Geometric Network";
            this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 5;
            this.menuItem30.Text = "-";
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 6;
            this.menuItem25.Text = "在dataset中创建featureClass";
            this.menuItem25.Click += new System.EventHandler(this.menuItem25_Click);
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 7;
            this.menuItem27.Text = "-";
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 8;
            this.menuItem28.Text = "导出到JPEG文件";
            this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 9;
            this.menuItem29.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 10;
            this.menuItem5.Text = "退出";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 1;
            this.menuItem20.Text = "编辑";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem36,
            this.menuItem15,
            this.menuItem16,
            this.menuItem43,
            this.menuItem52,
            this.menuItem50,
            this.menuItem51,
            this.menuItem53,
            this.menuItem54,
            this.menuItem55,
            this.menuItem56,
            this.menuItem57,
            this.menuItem58,
            this.menuItem61,
            this.menuItem12,
            this.menuItem69});
            this.menuItem11.Text = "空间分析";
            // 
            // menuItem36
            // 
            this.menuItem36.Index = 0;
            this.menuItem36.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem37,
            this.menuItem38,
            this.menuItem39,
            this.menuItem40});
            this.menuItem36.Text = "距离";
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 0;
            this.menuItem37.Text = "直线";
            this.menuItem37.Click += new System.EventHandler(this.menuItem37_Click);
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 1;
            this.menuItem38.Text = "分配";
            this.menuItem38.Click += new System.EventHandler(this.menuItem38_Click);
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 2;
            this.menuItem39.Text = "费用权重";
            this.menuItem39.Click += new System.EventHandler(this.menuItem39_Click);
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 3;
            this.menuItem40.Text = "最短路径";
            this.menuItem40.Click += new System.EventHandler(this.menuItem40_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "密度分析";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 2;
            this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem34,
            this.menuItem41,
            this.menuItem42});
            this.menuItem16.Text = "栅格插值";
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 0;
            this.menuItem34.Text = "反距离权重";
            this.menuItem34.Click += new System.EventHandler(this.menuItem34_Click_1);
            // 
            // menuItem41
            // 
            this.menuItem41.Index = 1;
            this.menuItem41.Text = "样条插值";
            this.menuItem41.Click += new System.EventHandler(this.menuItem41_Click);
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 2;
            this.menuItem42.Text = "克吕格";
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 3;
            this.menuItem43.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem44,
            this.menuItem45,
            this.menuItem46,
            this.menuItem47,
            this.menuItem48,
            this.menuItem49});
            this.menuItem43.Text = "表面分析";
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 0;
            this.menuItem44.Text = "等值线";
            this.menuItem44.Click += new System.EventHandler(this.menuItem44_Click);
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 1;
            this.menuItem45.Text = "坡度";
            this.menuItem45.Click += new System.EventHandler(this.menuItem45_Click);
            // 
            // menuItem46
            // 
            this.menuItem46.Index = 2;
            this.menuItem46.Text = "方向";
            this.menuItem46.Click += new System.EventHandler(this.menuItem46_Click);
            // 
            // menuItem47
            // 
            this.menuItem47.Index = 3;
            this.menuItem47.Text = "山体阴影";
            this.menuItem47.Click += new System.EventHandler(this.menuItem47_Click);
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 4;
            this.menuItem48.Text = "通视";
            this.menuItem48.Click += new System.EventHandler(this.menuItem48_Click);
            // 
            // menuItem49
            // 
            this.menuItem49.Index = 5;
            this.menuItem49.Text = "填挖方";
            this.menuItem49.Click += new System.EventHandler(this.menuItem49_Click);
            // 
            // menuItem52
            // 
            this.menuItem52.Index = 4;
            this.menuItem52.Text = "-";
            // 
            // menuItem50
            // 
            this.menuItem50.Index = 5;
            this.menuItem50.Text = "象素统计";
            this.menuItem50.Click += new System.EventHandler(this.menuItem50_Click);
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 6;
            this.menuItem51.Text = "临近统计";
            // 
            // menuItem53
            // 
            this.menuItem53.Index = 7;
            this.menuItem53.Text = "区域统计";
            // 
            // menuItem54
            // 
            this.menuItem54.Index = 8;
            this.menuItem54.Text = "-";
            // 
            // menuItem55
            // 
            this.menuItem55.Index = 9;
            this.menuItem55.Text = "栅格分类";
            // 
            // menuItem56
            // 
            this.menuItem56.Index = 10;
            this.menuItem56.Text = "-";
            // 
            // menuItem57
            // 
            this.menuItem57.Index = 11;
            this.menuItem57.Text = "计算器";
            this.menuItem57.Click += new System.EventHandler(this.menuItem57_Click);
            // 
            // menuItem58
            // 
            this.menuItem58.Index = 12;
            this.menuItem58.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem59,
            this.menuItem60});
            this.menuItem58.Text = "数据转换";
            // 
            // menuItem59
            // 
            this.menuItem59.Index = 0;
            this.menuItem59.Text = "特征转栅格";
            this.menuItem59.Click += new System.EventHandler(this.menuItem59_Click);
            // 
            // menuItem60
            // 
            this.menuItem60.Index = 1;
            this.menuItem60.Text = "栅格转特征";
            this.menuItem60.Click += new System.EventHandler(this.menuItem60_Click);
            // 
            // menuItem61
            // 
            this.menuItem61.Index = 13;
            this.menuItem61.Text = "-";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 14;
            this.menuItem12.Text = "参数设置";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click_1);
            // 
            // menuItem69
            // 
            this.menuItem69.Index = 15;
            this.menuItem69.Text = "初始化环境";
            this.menuItem69.Click += new System.EventHandler(this.menuItem69_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 3;
            this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem19});
            this.menuItem18.Text = "3D分析";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 0;
            this.menuItem19.Text = "显示TIN";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 4;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem10,
            this.menuItem13,
            this.menuItem14});
            this.menuItem8.Text = "网络分析";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.Text = "最近设施查找";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.Text = "最优路径查找";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.Text = "-";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 3;
            this.menuItem14.Text = "网络分析工具";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem64
            // 
            this.menuItem64.Index = 5;
            this.menuItem64.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem65,
            this.menuItem67,
            this.menuItem70,
            this.menuItem68,
            this.menuItem72,
            this.menuItem71,
            this.menuItem66});
            this.menuItem64.Text = "Utility网络分析";
            // 
            // menuItem65
            // 
            this.menuItem65.Index = 0;
            this.menuItem65.Text = "水管和阀门关停";
            this.menuItem65.Click += new System.EventHandler(this.menuItem65_Click);
            // 
            // menuItem67
            // 
            this.menuItem67.Index = 1;
            this.menuItem67.Text = "上朔追踪";
            this.menuItem67.Click += new System.EventHandler(this.menuItem67_Click);
            // 
            // menuItem70
            // 
            this.menuItem70.Index = 2;
            this.menuItem70.Text = "管线维护视频监控";
            this.menuItem70.Click += new System.EventHandler(this.menuItem70_Click);
            // 
            // menuItem68
            // 
            this.menuItem68.Index = 3;
            this.menuItem68.Text = "剖面分析";
            this.menuItem68.Click += new System.EventHandler(this.menuItem68_Click);
            // 
            // menuItem72
            // 
            this.menuItem72.Index = 4;
            this.menuItem72.Text = "弹出剖面图";
            this.menuItem72.Click += new System.EventHandler(this.menuItem72_Click);
            // 
            // menuItem71
            // 
            this.menuItem71.Index = 5;
            this.menuItem71.Text = "工程绘图";
            this.menuItem71.Click += new System.EventHandler(this.menuItem71_Click);
            // 
            // menuItem66
            // 
            this.menuItem66.Index = 6;
            this.menuItem66.Text = "初始化环境";
            this.menuItem66.Click += new System.EventHandler(this.menuItem66_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 6;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7});
            this.menuItem6.Text = "帮助";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "关于";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "图像文件 (*.BMP;*.JPG;*.GIF,*.TIF)|*.BMP;*.JPG;*.GIF,*.tif|Shape文件(*.shp)|*.SHP|所有文件 " +
                "(*.*)|*.*";
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem23,
            this.menuItem62,
            this.menuItem63});
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 0;
            this.menuItem23.Text = "移除该层";
            this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
            // 
            // menuItem62
            // 
            this.menuItem62.Index = 1;
            this.menuItem62.Text = "符号化";
            this.menuItem62.Click += new System.EventHandler(this.menuItem62_Click);
            // 
            // menuItem63
            // 
            this.menuItem63.Index = 2;
            this.menuItem63.Text = "地图提示";
            this.menuItem63.Click += new System.EventHandler(this.menuItem63_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarBtnNewMxd,
            this.toolBarBtnOpenMxd,
            this.toolBarBtnSave,
            this.toolBarBtnSeperator,
            this.toolBarBtnUndo,
            this.toolBarBtnRedo,
            this.toolBarBtnSeperator2,
            this.toolBarBtnAddData,
            this.toolBarButton1,
            this.toolBarBtnZoomIn,
            this.toolBarBtnZoomOut,
            this.toolBarBtnPan,
            this.toolBarBtnFull,
            this.toolBarBFixZoomIn,
            this.toolBarBtnFixZoomOut,
            this.toolBarBtnBack,
            this.toolBarBtnTo,
            this.toolBarBtnRSelect,
            this.toolBarBtnQuery,
            this.toolBarBtnFind,
            this.toolBarBtnMeasure,
            this.toolBarButton2,
            this.toolBarBtnSelRectangle,
            this.toolBarBtnSelLine,
            this.toolBarBtnSelEcllipse,
            this.toolBarBtnSelPolygon});
            this.toolBar1.Divider = false;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(960, 26);
            this.toolBar1.TabIndex = 17;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarBtnNewMxd
            // 
            this.toolBarBtnNewMxd.ImageIndex = 0;
            this.toolBarBtnNewMxd.Name = "toolBarBtnNewMxd";
            // 
            // toolBarBtnOpenMxd
            // 
            this.toolBarBtnOpenMxd.ImageIndex = 1;
            this.toolBarBtnOpenMxd.Name = "toolBarBtnOpenMxd";
            // 
            // toolBarBtnSave
            // 
            this.toolBarBtnSave.ImageIndex = 18;
            this.toolBarBtnSave.Name = "toolBarBtnSave";
            // 
            // toolBarBtnSeperator
            // 
            this.toolBarBtnSeperator.Name = "toolBarBtnSeperator";
            this.toolBarBtnSeperator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarBtnUndo
            // 
            this.toolBarBtnUndo.ImageIndex = 3;
            this.toolBarBtnUndo.Name = "toolBarBtnUndo";
            // 
            // toolBarBtnRedo
            // 
            this.toolBarBtnRedo.ImageIndex = 4;
            this.toolBarBtnRedo.Name = "toolBarBtnRedo";
            // 
            // toolBarBtnSeperator2
            // 
            this.toolBarBtnSeperator2.Name = "toolBarBtnSeperator2";
            this.toolBarBtnSeperator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarBtnAddData
            // 
            this.toolBarBtnAddData.ImageIndex = 5;
            this.toolBarBtnAddData.Name = "toolBarBtnAddData";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarBtnZoomIn
            // 
            this.toolBarBtnZoomIn.ImageIndex = 6;
            this.toolBarBtnZoomIn.Name = "toolBarBtnZoomIn";
            // 
            // toolBarBtnZoomOut
            // 
            this.toolBarBtnZoomOut.ImageIndex = 7;
            this.toolBarBtnZoomOut.Name = "toolBarBtnZoomOut";
            // 
            // toolBarBtnPan
            // 
            this.toolBarBtnPan.ImageIndex = 8;
            this.toolBarBtnPan.Name = "toolBarBtnPan";
            // 
            // toolBarBtnFull
            // 
            this.toolBarBtnFull.ImageIndex = 9;
            this.toolBarBtnFull.Name = "toolBarBtnFull";
            // 
            // toolBarBFixZoomIn
            // 
            this.toolBarBFixZoomIn.ImageIndex = 11;
            this.toolBarBFixZoomIn.Name = "toolBarBFixZoomIn";
            // 
            // toolBarBtnFixZoomOut
            // 
            this.toolBarBtnFixZoomOut.ImageIndex = 10;
            this.toolBarBtnFixZoomOut.Name = "toolBarBtnFixZoomOut";
            // 
            // toolBarBtnBack
            // 
            this.toolBarBtnBack.ImageIndex = 12;
            this.toolBarBtnBack.Name = "toolBarBtnBack";
            // 
            // toolBarBtnTo
            // 
            this.toolBarBtnTo.ImageIndex = 13;
            this.toolBarBtnTo.Name = "toolBarBtnTo";
            // 
            // toolBarBtnRSelect
            // 
            this.toolBarBtnRSelect.ImageIndex = 14;
            this.toolBarBtnRSelect.Name = "toolBarBtnRSelect";
            this.toolBarBtnRSelect.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarBtnQuery
            // 
            this.toolBarBtnQuery.ImageIndex = 15;
            this.toolBarBtnQuery.Name = "toolBarBtnQuery";
            // 
            // toolBarBtnFind
            // 
            this.toolBarBtnFind.ImageIndex = 16;
            this.toolBarBtnFind.Name = "toolBarBtnFind";
            // 
            // toolBarBtnMeasure
            // 
            this.toolBarBtnMeasure.ImageIndex = 17;
            this.toolBarBtnMeasure.Name = "toolBarBtnMeasure";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarBtnSelRectangle
            // 
            this.toolBarBtnSelRectangle.ImageIndex = 19;
            this.toolBarBtnSelRectangle.Name = "toolBarBtnSelRectangle";
            // 
            // toolBarBtnSelLine
            // 
            this.toolBarBtnSelLine.ImageIndex = 21;
            this.toolBarBtnSelLine.Name = "toolBarBtnSelLine";
            // 
            // toolBarBtnSelEcllipse
            // 
            this.toolBarBtnSelEcllipse.ImageIndex = 20;
            this.toolBarBtnSelEcllipse.Name = "toolBarBtnSelEcllipse";
            // 
            // toolBarBtnSelPolygon
            // 
            this.toolBarBtnSelPolygon.ImageIndex = 22;
            this.toolBarBtnSelPolygon.Name = "toolBarBtnSelPolygon";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "openNetworkWindow.bmp");
            this.imageList1.Images.SetKeyName(24, "AddNetFlags.bmp");
            this.imageList1.Images.SetKeyName(25, "moveNetFalgs.bmp");
            this.imageList1.Images.SetKeyName(26, "Solve.bmp");
            this.imageList1.Images.SetKeyName(27, "openwindow.bmp");
            this.imageList1.Images.SetKeyName(28, "openNetSeetingWin.bmp");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 26);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axLicenseControl1);
            this.splitContainer1.Panel2.Controls.Add(this.axToolbarControl1);
            this.splitContainer1.Panel2.Controls.Add(this.toolBar2);
            this.splitContainer1.Panel2.Controls.Add(this.axMapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(960, 403);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 18;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 226);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(196, 177);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axMapControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(188, 152);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "鹰眼";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // axMapControl2
            // 
            this.axMapControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl2.Location = new System.Drawing.Point(3, 3);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(182, 146);
            this.axMapControl2.TabIndex = 1;
            this.axMapControl2.OnFullExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnFullExtentUpdatedEventHandler(this.axMapControl2_OnFullExtentUpdated);
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            this.axMapControl2.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(this.axMapControl2_OnAfterDraw);
            this.axMapControl2.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl2_OnMouseUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(188, 152);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "网络分析";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewListItem);
            this.groupBox1.Controls.Add(this.comboBoxNetList);
            this.groupBox1.Controls.Add(this.buttonNetSetting);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 146);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // treeViewListItem
            // 
            this.treeViewListItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeViewListItem.Location = new System.Drawing.Point(3, 46);
            this.treeViewListItem.Name = "treeViewListItem";
            this.treeViewListItem.Size = new System.Drawing.Size(176, 97);
            this.treeViewListItem.TabIndex = 4;
            this.treeViewListItem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewListItem_AfterSelect);
            this.treeViewListItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewListItem_MouseDown);
            // 
            // comboBoxNetList
            // 
            this.comboBoxNetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNetList.FormattingEnabled = true;
            this.comboBoxNetList.Location = new System.Drawing.Point(3, 20);
            this.comboBoxNetList.Name = "comboBoxNetList";
            this.comboBoxNetList.Size = new System.Drawing.Size(146, 20);
            this.comboBoxNetList.TabIndex = 0;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(196, 226);
            this.axTOCControl1.TabIndex = 0;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(112, 53);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 20;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(20, 103);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(645, 28);
            this.axToolbarControl1.TabIndex = 19;
            // 
            // toolBar2
            // 
            this.toolBar2.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar2.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton3,
            this.toolBarButton6,
            this.toolBarButtonOpen,
            this.toolBarButton4,
            this.toolBarButtonAdd,
            this.toolBarButtonMove,
            this.toolBarButtonSolve,
            this.toolBarButtonWin});
            this.toolBar2.Divider = false;
            this.toolBar2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar2.DropDownArrows = true;
            this.toolBar2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolBar2.ImageList = this.imageList1;
            this.toolBar2.Location = new System.Drawing.Point(294, 51);
            this.toolBar2.Name = "toolBar2";
            this.toolBar2.ShowToolTips = true;
            this.toolBar2.Size = new System.Drawing.Size(300, 34);
            this.toolBar2.TabIndex = 1;
            this.toolBar2.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBar2.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar2_ButtonClick);
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.DropDownMenu = this.contextMenu2;
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.toolBarButton3.Text = "网络分析";
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem21,
            this.menuItem22,
            this.menuItem24,
            this.menuItem26,
            this.menuItem32,
            this.menuItem33});
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 0;
            this.menuItem21.Text = "最优路线";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 1;
            this.menuItem22.Text = "服务区域";
            this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 2;
            this.menuItem24.Text = "最近设施";
            this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 3;
            this.menuItem26.Text = "费用矩阵";
            this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click_1);
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 4;
            this.menuItem32.Text = "-";
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 5;
            this.menuItem33.Text = "选项";
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonOpen
            // 
            this.toolBarButtonOpen.ImageIndex = 23;
            this.toolBarButtonOpen.Name = "toolBarButtonOpen";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonAdd
            // 
            this.toolBarButtonAdd.ImageIndex = 24;
            this.toolBarButtonAdd.Name = "toolBarButtonAdd";
            // 
            // toolBarButtonMove
            // 
            this.toolBarButtonMove.ImageIndex = 25;
            this.toolBarButtonMove.Name = "toolBarButtonMove";
            // 
            // toolBarButtonSolve
            // 
            this.toolBarButtonSolve.ImageIndex = 26;
            this.toolBarButtonSolve.Name = "toolBarButtonSolve";
            // 
            // toolBarButtonWin
            // 
            this.toolBarButtonWin.ImageIndex = 27;
            this.toolBarButtonWin.Name = "toolBarButtonWin";
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(760, 403);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl1_OnMouseUp);
            // 
            // contextMenu3
            // 
            this.contextMenu3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem35});
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 0;
            this.menuItem35.Text = "装载数据";
            this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click);
            // 
            // buttonNetSetting
            // 
            this.buttonNetSetting.ImageIndex = 28;
            this.buttonNetSetting.ImageList = this.imageList1;
            this.buttonNetSetting.Location = new System.Drawing.Point(152, 20);
            this.buttonNetSetting.Name = "buttonNetSetting";
            this.buttonNetSetting.Size = new System.Drawing.Size(27, 21);
            this.buttonNetSetting.TabIndex = 1;
            this.buttonNetSetting.UseVisualStyleBackColor = true;
            this.buttonNetSetting.Click += new System.EventHandler(this.buttonNetSetting_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(960, 451);
            this.ContextMenu = this.contextMenu1;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "MainFrm";
            this.Text = "ArcGIS Engine .Net 演示中心";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ESRI License Initializer generated code.
             m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngine },
             new esriLicenseExtensionCode[] { esriLicenseExtensionCode.esriLicenseExtensionCode3DAnalyst, esriLicenseExtensionCode.esriLicenseExtensionCodeNetwork, esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst });
            Application.Run(new MainFrm());
            //ESRI License Initializer generated code.
            //Do not make any call to ArcObjects after ShutDownApplication()
           // m_AOLicenseInitializer.ShutdownApplication();
        }
       
  

        public ILayer getCurrentLayer()
        {
            return currentLayer;


        }

        public void setCurrentLayer(ILayer pLayer)
        {
            this.currentLayer = pLayer;


        }
        private void UpdateUI()
        {
            axMapControl2.Refresh(esriViewDrawPhase.esriViewForeground, m_AOI, Type.Missing);
        }
        private void ResetFillSymbol()
        {
            #region FillSymbol

            m_pFillSymbol = new SimpleFillSymbol();

            IRgbColor rgb = new RgbColorClass();
            rgb.NullColor = true;
            rgb.Transparency = 0;

            IRgbColor lineColor = new RgbColorClass();
            lineColor.Red = 192;
            lineColor.Green = 50;
            lineColor.Blue = 50;
            lineColor.Transparency = 100;

            ISimpleLineSymbol line = new SimpleLineSymbolClass();
            line.Style = esriSimpleLineStyle.esriSLSSolid;
            line.Width = 1.5F;
            line.Color = lineColor;

            m_pFillSymbol.Color = rgb;
            m_pFillSymbol.Outline = line;

            IFillShapeElement fillSymbol = m_AOI as IFillShapeElement;
            fillSymbol.Symbol = m_pFillSymbol;

            #endregion

            #region SelectedSymbol

            m_pSelectedSymbol = new SimpleFillSymbol();

            IRgbColor rgb2 = new RgbColorClass();
            rgb2.Red = 215;
            rgb2.Green = 215;
            rgb2.Blue = 100;
            rgb2.Transparency = 10;
            rgb2.UseWindowsDithering = true;

            IRgbColor lineColor2 = new RgbColorClass();
            lineColor2.Red = 192;
            lineColor2.Green = 50;
            lineColor2.Blue = 50;
            lineColor2.Transparency = 100;

            ISimpleLineSymbol line2 = new SimpleLineSymbolClass();
            line2.Style = esriSimpleLineStyle.esriSLSSolid;
            line2.Width = 1.5F;
            line2.Color = lineColor2;

            m_pSelectedSymbol.Color = rgb2;
            m_pSelectedSymbol.Outline = line2;

            #endregion
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            //Set label editing to manual
            axTOCControl1.LabelEdit = esriTOCControlEdit.esriTOCControlManual;
            //identifyCommand.Identify idCommand=new identifyCommand.Identify();
            //idCommand.setStatsBar(statusBar1);
            string strMxdFileName = Application.StartupPath + @"\..\..\..\Data\Network\data.mxd";
            if (axMapControl1.CheckMxFile(strMxdFileName) == true)
            {
                axMapControl1.LoadMxFile(strMxdFileName, null, null);
                axMapControl2.LoadMxFile(strMxdFileName, null, null);
                if (CheckNetWorkExtension(Application.StartupPath + @"\..\..\..\Data\Network\Network") == true)
                {
                    toolBarButtonOpen.Enabled = true;
                    toolBarButtonSolve.Enabled = false;
                    EnableNetworkMenu(false);
                }
                else
                {
                    toolBarButtonOpen.Enabled = false;
                    toolBarButtonSolve.Enabled = false;
                    EnableNetworkMenu(false);
                }
            }
            else
            {
                MessageBox.Show("所选择的文档视图文件不存在,请重新指定!", "错误提示");
            }
            // Initialize naEnv variables
            m_naEnv = new EngineNetworkAnalystEnvironmentClass();
            m_naEnv.ZoomToResultAfterSolve = false;
            m_naEnv.ShowAnalysisMessagesAfterSolve = (int)(esriEngineNAMessageType.esriEngineNAMessageTypeInformative | esriEngineNAMessageType.esriEngineNAMessageTypeWarning);
            //m_naWindow = m_naEnv.NAWindow;

            //overviewControl1.SetBuddyMapControl(axMapControl1);
            axTOCControl1.SetBuddyControl(axMapControl1);
            IElement element = m_AOI as IElement;
            axMapControl2.Extent = axMapControl2.FullExtent;
            element.Geometry = axMapControl1.Extent.Envelope;
            m_AOI.SpatialReference = axMapControl1.SpatialReference;
            axMapControl2.SpatialReference = axMapControl1.SpatialReference;
            UpdateUI();


            this.WindowState = FormWindowState.Normal;
        }
        //检查工作区间是否属于网络分析
        private bool CheckNetWorkExtension(string strWorkspace)
        {
            IFeatureWorkspace pFeatWS = Utility.OpenWorkspace(strWorkspace) as IFeatureWorkspace;
            INetworkDataset pNetDataset = Utility.OpenNetworkDataset(pFeatWS as IWorkspace, "streets_nd");
            if (pNetDataset != null)
            {
                //  m_NAContext = Utility.CreateSolverContext(pNetDataset, "设施");
                m_pNetDataset = pNetDataset;
                return true;
            }
            else
            {
                return false;
            }
        }
        //网络分析菜单和按钮的开关控制
        private void EnableNetworkMenu(bool b)
        {
            menuItem21.Enabled = b;
            menuItem22.Enabled = b;
            menuItem24.Enabled = b;
            menuItem26.Enabled = b;

            toolBarButtonAdd.Enabled = b;
            toolBarButtonMove.Enabled = b;
            //toolBarButtonSolve.Enabled = b;
            toolBarButtonWin.Enabled = b;
        }
        private void OnVisibleBoundsUpdated(IDisplayTransformation sender, bool sizeChanged)
        {
            //Set the extent to the new visible extent
            m_Envelope = sender.VisibleBounds;
            //Refresh the MapControl's foreground phase
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Release COM objects
            ESRI.ArcGIS.Utility.COMSupport.AOUninitialize.Shutdown();
        }

        private void axTOCControl1_OnEndLabelEdit(object sender, ESRI.ArcGIS.TOCControl.ITOCControlEvents_OnEndLabelEditEvent e)
        {
            //If the new label is an empty string then prevent the edit
            string newLabel = e.newLabel;
            if (newLabel.Trim() == "")
            {
                e.canEdit = false;
            }
        }

        private void axMapControl1_OnAfterDraw(object sender, ESRI.ArcGIS.MapControl.IMapControlEvents2_OnAfterDrawEvent e)
        {
            if (m_Envelope == null)
            {
                return;
            }

            //If the foreground phase has drawn			
            esriViewDrawPhase viewDrawPhase = (esriViewDrawPhase)e.viewDrawPhase;
            if (viewDrawPhase == esriViewDrawPhase.esriViewForeground)
            {
                IGeometry geometry = m_Envelope;
                axMapControl1.DrawShape(geometry, ref m_FillSymbol);
            }
        }


        protected override void OnNotifyMessage(System.Windows.Forms.Message m)
        {

            base.OnNotifyMessage(m);

            if (m.Msg == WM_ENTERSIZEMOVE)
            {
                axMapControl1.SuppressResizeDrawing(true, 0);

            }
            else if (m.Msg == WM_EXITSIZEMOVE)
            {
                axMapControl1.SuppressResizeDrawing(false, 0);

            }
        }
        //退出
        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        //打开栅格数据文件
        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            //add raster to the layer
            AddRasterData();

        }

        private void AddRasterData()
        {

            try
            {
                IRasterLayer pRasterLayer;
                pRasterLayer = new RasterLayerClass();
                String rasterFileName, rasterDirName;
                IRasterWorkspace pRWS;//=new ESRI.ArcGIS.DataSourcesRaster.RasterWorkspaceClass();

                IWorkspaceFactory pWSF;//=new ESRI.ArcGIS.DataSourcesRaster.WorkspaceFactoryClass();
                IRaster pRaster;
                IRasterDataset pRasterDataset;

                IWorkspace pWS;
                String rawFileName;
                int startX, endX;
                //IRasterLayer pRasterLayer;


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    rasterFileName = openFileDialog1.FileName;
                    statusBar1.Text = rasterFileName;

                    rasterDirName = rasterFileName.Substring(0, rasterFileName.LastIndexOf("\\"));

                    startX = rasterFileName.LastIndexOf("\\");
                    endX = rasterFileName.Length;


                    rawFileName = rasterFileName.Substring(startX + 1, endX - startX - 1);
                    //sDirName =sRequest.Substring(sRequest.IndexOf("/"), sRequest.LastIndexOf("/")-3);


                    //pRWS=new RasterWorkspaceClass();
                    pWSF = new RasterWorkspaceFactoryClass();

                    pWS = pWSF.OpenFromFile(rasterDirName, 0);


                    pRWS = pWS as IRasterWorkspace;

                    pRasterDataset = pRWS.OpenRasterDataset(rawFileName);

                    pRaster = pRasterDataset.CreateDefaultRaster();

                    pRasterLayer.CreateFromRaster(pRaster);

                    axMapControl1.AddLayer(pRasterLayer as ILayer, 0);


                }

            }
            catch (Exception e)
            {

            }


        }

        private void menuItem9_Click(object sender, System.EventArgs e)
        {

            frmClosestFacility fCloseF = new frmClosestFacility(this);
            fCloseF.Show();

        }

        public TreeView getTreeViewControl()
        {
            return treeViewListItem;
        }
        public ESRI.ArcGIS.Controls.AxMapControl getMapControl()
        {
            return axMapControl1;
        }
        public ESRI.ArcGIS.Controls.AxMapControl getOverviewControl()
        {
            return axMapControl2;
        }

        public ESRI.ArcGIS.Controls.AxTOCControl getTocControl()
        {
            return axTOCControl1;

        }

        private void menuItem10_Click(object sender, System.EventArgs e)
        {
            frmRoute fRoute = new frmRoute(this);
            fRoute.Show();
        }

        //打开SHAPE数据文件
        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.FilterIndex = 2;
            string fname = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = openFileDialog1.FileName;
            }

            if (fname != null)
            {
                string pathToWorkspace = System.IO.Path.GetDirectoryName(fname);
                string shapefileName = System.IO.Path.GetFileNameWithoutExtension(fname);
                IDataset pDataset;

                IFeatureClass pFClass = Utility.OpenFeatureClassFromShapefile(pathToWorkspace, shapefileName);

                IFeatureLayer pLayer = new FeatureLayerClass();

                pLayer.FeatureClass = pFClass;

                pDataset = pFClass as IDataset;

                pLayer.Name = pDataset.Name;

                this.axMapControl1.AddLayer(pLayer, 0);

            }
        }
        //打开TIN数据文件
        private void menuItem17_Click(object sender, System.EventArgs e)
        {
            //
            string dirName;
            ILayer pLayer;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                dirName = folderBrowserDialog1.SelectedPath;

                pLayer = Utility.openTinLayer(dirName);

                if (pLayer != null)
                {
                    axMapControl1.AddLayer(pLayer, 0);

                }

            }
        }

        private void menuItem19_Click(object sender, System.EventArgs e)
        {


            //frm3DAnalyst fSence = new frm3DAnalyst();
            //IScene pScene = fSence.Get3DScene();
            //for (int ii = 0; ii < axMapControl1.LayerCount; ii++)
            //{
            //    ILayer pLayer = axMapControl1.get_Layer(ii);
            //    pScene.AddLayer(pLayer, true);

            //}

            //fSence.Show();
            frmGlobeControl frmGlobeControl1 = new frmGlobeControl();
            frmGlobeControl1.Show();
        }

        private void menuItem23_Click(object sender, System.EventArgs e)
        {
            //remove the current layer

            string lyrName = currentLayer.Name;
            int lyrIndex;
            lyrIndex = Utility.getLyrIndexByName(this.axMapControl1, lyrName);

            if (lyrIndex != -1)
                axMapControl1.DeleteLayer(lyrIndex);

            this.axTOCControl1.Update();
        }
        //连接SDE数据库
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            //Utility.connectToSDE();
            frmAddSDEData frmAddSDEData1 = new frmAddSDEData(this);
            frmAddSDEData1.Show();
        }
        //在数据集中创建特征
        private void menuItem25_Click(object sender, System.EventArgs e)
        {
            Utility.CreateFClassInPDB(@"C:\ArcGIS\ArcTutor\BuildingaGeodatabase\Montgomery.mdb");
        }

        private void menuItem26_Click(object sender, System.EventArgs e)
        {
            ISelection pSelection;
            IMap pMap;
            IEnumFeature pEnumF;
            IFeature pFeature;

            IActiveView pActiveView = axMapControl1.ActiveView;
            IGraphicsContainer iGC = pActiveView as IGraphicsContainer;

            pMap = axMapControl1.ActiveView.FocusMap;

            if (pMap.SelectionCount != 2)
            {
                MessageBox.Show("请选择两个要素"); return;

            }
            pSelection = pMap.FeatureSelection;


            pEnumF = pSelection as IEnumFeature;

            pFeature = pEnumF.Next();

            IGeometry pGeomIn = pFeature.Shape;

            pFeature = pEnumF.Next();

            IGeometry pGeomOther = pFeature.Shape;

            IGeometry rltGeom;
            //pGeomIn.SpatialReference=pFLayer.SpatialReference;
            if (pGeomIn.SpatialReference != pGeomOther.SpatialReference) MessageBox.Show("空间参考不同");

            rltGeom = Utility.SymmetricDiff(pGeomIn, pGeomOther);
            if (rltGeom == null)
            {
                MessageBox.Show("没有difference");
                return;
            }

            IElement inputEle = new PolygonElementClass();

            inputEle.Geometry = rltGeom;

            iGC.AddElement(inputEle, 0);

            pActiveView.Refresh();
        }
        //输出地图为JPEG格式文件
        private void menuItem28_Click(object sender, System.EventArgs e)
        {
            //测试，导出到c:\test.jpg
            //SpatialHelperFunction
            ///Utility
            string filePath = @"c:\\test.jpg";
            try
            {
                SpatialHelperFunction.ExportActiveView(this.axMapControl1.ActiveView, filePath);
                MessageBox.Show("当前地图已经导出到 " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        //打开几何网络
        private void menuItem31_Click(object sender, System.EventArgs e)
        {
            //打开geometric network;
            string fpath = @"C:\ArcGIS91_Demos\Sewer9\data\sewer3.mdb";
            IFeatureWorkspace pFWS = Utility.openPDB(fpath);
            IFeatureDataset pFdataset = pFWS.OpenFeatureDataset("urban");
            IGeometricNetwork pGeoNetwork;
            SpatialHelperFunction.initNetwork(pFdataset, this.axMapControl1.Map, out pGeoNetwork);
            tSP.setGNetwork(pGeoNetwork);
        }
        /*
		private void menuItem33_Click(object sender, System.EventArgs e)
		{
			//初始化网络分析环境，包括打开sewer.mxd文件，设置Layer Definition
			string strPath=@"C:\ArcGIS91_Demos\Sewer9\Start.mxd";
			if(this.axMapControl1.CheckMxFile(strPath)==false){
				MessageBox.Show("无法载入文件");
				return;
			}
			
			this.axMapControl1.LoadMxFile(strPath,0,Type.Missing);
			this.axMapControl1.ActiveView.FocusMap.DelayDrawing(true);
			IFeatureLayerDefinition pFeatLayerDef;
			IFeatureLayer pFeatLayer;
			IFeatureLayer pFeatLayer2;
			int lyrIndex=Utility.getLyrIndexByName(this.axMapControl1,"Sewer Fixtures");
			if(lyrIndex==-1) return;
			pFeatLayer=this.axMapControl1.get_Layer(lyrIndex) as IFeatureLayer;
			pFeatLayer.Selectable=true;
			pFeatLayer.Visible=true;
			
			pFeatLayerDef=pFeatLayer as IFeatureLayerDefinition;
			pFeatLayerDef.DefinitionExpression="[NODE_TYPE] = 'MH'";

			IEnvelope pEnv;
			pEnv =new EnvelopeClass();
			pEnv.XMin = 561855;
			pEnv.YMin = 42376;
			pEnv.XMax = 563299;
			pEnv.YMax = 43783;
			this.axMapControl1.ActiveView.Extent = pEnv;
			ILayer pLayer;
			
			pLayer=this.axMapControl1.get_Layer(Utility.getLyrIndexByName(this.axMapControl1,"Parcels"));
			pLayer.Visible=true;
			Utility.setLegendVisiblity(pLayer,true);

			pLayer=this.axMapControl1.get_Layer(Utility.getLyrIndexByName(this.axMapControl1,"Roads"));
			pLayer.Visible=true;
			Utility.setLegendVisiblity(pLayer,true);

			pLayer=this.axMapControl1.get_Layer(Utility.getLyrIndexByName(this.axMapControl1,"Sewer Lines"));
			pLayer.Visible=true;
			Utility.setLegendVisiblity(pLayer,true);
			this.axMapControl1.ActiveView.FocusMap.DelayDrawing(false);

			this.axMapControl1.ActiveView.Refresh();

			this.axTOCControl1.Update();
				
		}
        */
        private void menuItem34_Click(object sender, System.EventArgs e)
        {
            SpatialHelperFunction.FindMarkerSym(null, null, null);
        }

        //private void menuItem35_Click(object sender, System.EventArgs e)
        //{
        //    (this.axMapControl1.ActiveView as IGraphicsContainer).DeleteAllElements();

        //    this.axMapControl1.ActiveView.Refresh();
        //}
        //空间分析
        //距离分析
        //直线距离函数演示
        private void menuItem37_Click(object sender, System.EventArgs e)
        {
            frmStraightLineDis fSLD = new frmStraightLineDis(this);
            fSLD.Show();
        }
        //空间分析
        //距离分析
        //费用权重距离函数演示
        private void menuItem39_Click(object sender, System.EventArgs e)
        {
            frmCostWeightLineDis fCostW = new frmCostWeightLineDis(this);
            fCostW.Show();
        }
        //空间分析
        //距离分析
        //空间分析参数选项设置
        private void menuItem12_Click_1(object sender, System.EventArgs e)
        {
            frmAnalysisOption frmAOption = new frmAnalysisOption(this);
            frmAOption.Show();
        }
        //空间分析
        //密度分析
        private void menuItem15_Click(object sender, System.EventArgs e)
        {

            frmDensity frmDensity1 = new frmDensity(this);
            frmDensity1.Show();
        }
        private void menuItem40_Click(object sender, System.EventArgs e)
        {
            frmShortestPath frmShortestPath1 = new frmShortestPath(this);
            frmShortestPath1.Show();
        }
        //空间分析
        //反距离权重插值
        private void menuItem34_Click_1(object sender, System.EventArgs e)
        {
            frmRasterIDW frmRasterIDW1 = new frmRasterIDW(this);
            frmRasterIDW1.Show();
        }
        //空间分析
        //样条插值

        private void menuItem41_Click(object sender, System.EventArgs e)
        {
            frmRasterSpline frmRasterSpline1 = new frmRasterSpline(this);
            frmRasterSpline1.Show();

        }
        //private void overviewControl1_ExtentUpdatingEvent(object sender, Newleaf.ExtentUpdatedEventArgs e)
        //{
        //	axMapControl1.Extent = e.Envelope;
        //	axMapControl1.Refresh();
        //}
        //点击工具条时选择相应的按钮
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            IExtentStack pExtentStack = null;
            IEnvelope objEnvelope = null;
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0://选择新建文档视图
                    Utility.NewMxdDocument(this);
                    break;
                case 1://打开文档视图
                    Utility.OpenMxdDocument(this);
                    IElement element = m_AOI as IElement;
                    axMapControl2.Extent = axMapControl2.FullExtent;
                    element.Geometry = axMapControl1.Extent.Envelope;
                    m_AOI.SpatialReference = axMapControl1.SpatialReference;
                    axMapControl2.SpatialReference = axMapControl1.SpatialReference;
                    UpdateUI();
                    break;
                case 2://保存文档视图
                    Utility.SaveMxdDocument(this);
                    break;
                case 7://添加本地数据库文件
                    Utility.AddFeatureLayer(this);
                    break;
                case 9://放大工具
                    m_BasicOperationTool = "isZoomIn";
                    axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomIn;
                    break;
                case 10://缩小工具
                    m_BasicOperationTool = "isZoomOut";
                    axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomOut;
                    break;
                case 11://平移工具
                    m_BasicOperationTool = "isZoomPan";
                    axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPan;
                    break;
                case 12://全屏工具
                    m_BasicOperationTool = "isZoomFull";
                    axMapControl1.Extent = axMapControl1.FullExtent;
                    axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoom;
                    break;
                case 13://固定放大工具
                    objEnvelope = axMapControl1.Extent;
                    objEnvelope.Expand(0.2, 0.2, true);
                    axMapControl1.Extent = objEnvelope;
                    break;
                case 14://固定缩小工具

                    objEnvelope = axMapControl1.Extent;
                    objEnvelope.Expand(2, 2, true);
                    axMapControl1.Extent = objEnvelope;
                    break;
                case 15://回滚视图
                    pExtentStack = axMapControl1.ActiveView.ExtentStack;
                    if (pExtentStack.CanUndo())
                        pExtentStack.Undo();
                    axMapControl1.Refresh();
                    break;
                case 16://前滚视图
                    pExtentStack = axMapControl1.ActiveView.ExtentStack;
                    if (pExtentStack.CanRedo())
                        pExtentStack.Redo();
                    axMapControl1.Refresh();
                    break;
                case 18://点选工具
                    m_BasicOperationTool = "isQuery";
                    axMapControl1.MousePointer = esriControlsMousePointer.esriPointerIdentify;
                    break;
                case 19://通过属性查询
                    frmFind frmFind1 = new frmFind(this);
                    frmFind1.ShowDialog();
                    break;
                case 20://测量工具
                    m_BasicOperationTool = "isMeasure";
                    //axMapControl1.MousePointer=esriControlsMousePointer.esriPointerArrowQuestion;					
                    break;
                case 22://拉矩形框查询选择
                    m_BasicOperationTool = "isSelRectangle";
                    break;
                case 23://拉直线查询选择
                    m_BasicOperationTool = "isSelLine";
                    break;
                case 24://拉椭圆形查询选择
                    m_BasicOperationTool = "isSelEcllipse";
                    break;
                case 25://拉多边形查询选择
                    m_BasicOperationTool = "isSelPolygon";
                    break;

            }

        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IEnvelope objEnvelope = null;

            IPoint pPoint = null;
            IActiveView pActiveView = axMapControl1.ActiveView.FocusMap as IActiveView;
            pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
            frmPointQuery frmPointQuery1 = new frmPointQuery();
            switch (m_BasicOperationTool)
            {
                case "isZoomIn":
                    objEnvelope = axMapControl1.TrackRectangle();
                    axMapControl1.Extent = objEnvelope;
                    break;
                case "isZoomOut":
                    objEnvelope = axMapControl1.TrackRectangle();
                    double mapWidth = objEnvelope.Width;
                    double mapHeight = objEnvelope.Height;
                    double x1 = pPoint.X;
                    double x2 = pPoint.X + mapWidth;
                    double y1 = pPoint.Y;
                    double y2 = pPoint.Y - mapHeight * 2;
                    objEnvelope.XMax = x2 + mapWidth * 2;
                    objEnvelope.XMin = x1 - mapWidth * 2;
                    objEnvelope.YMax = y2 - mapHeight * 2;
                    objEnvelope.YMin = y1 + mapHeight * 2;
                    axMapControl1.Extent = objEnvelope;
                    break;
                case "isZoomPan":
                    axMapControl1.Pan();
                    break;
                case "isQuery":
                    IDisplayTransformation pDT = axMapControl1.ActiveView.ScreenDisplay.DisplayTransformation;
                    pPoint = pDT.ToMapPoint(e.x, e.y);

                    frmPointQuery1.userControl11.SetQueryFeature(axMapControl1.Map, pPoint);
                    frmPointQuery1.ShowDialog();
                    break;
                case "isMeasure":
                    m_bInUse = true;
                    m_pStartPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y); ;
                    break;
                case "isSelRectangle":
                    objEnvelope = axMapControl1.TrackRectangle();
                    frmPointQuery1.userControl11.SetQueryFeatureByRect(axMapControl1.Map, objEnvelope);
                    frmPointQuery1.ShowDialog();
                    break;
                case "isSelLine":
                    objEnvelope = axMapControl1.TrackLine().Envelope;
                    frmPointQuery1.userControl11.SetQueryFeatureByRect(axMapControl1.Map, objEnvelope);
                    frmPointQuery1.ShowDialog();
                    break;
                case "isSelEcllipse":
                    objEnvelope = axMapControl1.TrackCircle().Envelope;
                    frmPointQuery1.userControl11.SetQueryFeatureByRect(axMapControl1.Map, objEnvelope);
                    frmPointQuery1.ShowDialog();
                    break;
                case "isSelPolygon":
                    objEnvelope = axMapControl1.TrackPolygon().Envelope;
                    frmPointQuery1.userControl11.SetQueryFeatureByRect(axMapControl1.Map, objEnvelope);
                    frmPointQuery1.ShowDialog();
                    break;
                case "AddNetworkPoint":
                    break;
                case "isFindWaterValve":
                    BurstSetEdgeFlag(pPoint);
                    break;
                case "isUpstreamTrace":
                    Utility.UpStreamTrace(this, pPoint, pGeoNetwork);
                    break;
                case "isProfileAnalysis":

                    Utility.ProfileSetJunctionFlag(this, ref pNetFlagArray, pPoint, pGeoNetwork);
                    break;
                case "isSewerTvSurvey":

                    break;

            }
        }

        //为几何网络设置边的Flag
        private void BurstSetEdgeFlag(IPoint pPoint)
        {
            //
            try
            {
                INetElements pNetElements = pGeoNetwork.Network as INetElements;
                IPointToEID pPtToEID = new PointToEIDClass();
                IPoint pNewPt;
                int iUserClassID;
                int iUserID;
                int iUserSubID;
                double dPercent;
                int eid;
                pPtToEID.SourceMap = axMapControl1.ActiveView.FocusMap;
                pPtToEID.GeometricNetwork = pGeoNetwork;
                pPtToEID.SnapTolerance = axMapControl1.ActiveView.Extent.Envelope.Width / 100;
                pPtToEID.GetNearestEdge(pPoint, out eid, out pNewPt, out dPercent);
                if (pNewPt == null)
                {
                    MessageBox.Show("没有查找相临近的边");
                }
                else
                {
                    pNetElements.QueryIDs(eid, esriElementType.esriETEdge, out iUserClassID, out iUserID, out iUserSubID);
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
                    pFlagDisplay.Geometry = pNewPt;
                    pFlagDisplay.FeatureClassID = iUserClassID;
                    pFlagDisplay.FID = iUserID;
                    pFlagDisplay.SubID = iUserSubID;

                    //绘制该点
                    IScreenDisplay pScreenDisplay = axMapControl1.ActiveView.ScreenDisplay;
                    pScreenDisplay.StartDrawing(pScreenDisplay.hDC, 0);
                    pScreenDisplay.SetSymbol(pMarkerSym as ISymbol);
                    pScreenDisplay.DrawPoint(pNewPt as IGeometry);
                    pScreenDisplay.FinishDrawing();
                    BurstFindValves(pFlagDisplay);
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }

        }
        //查找阀门
        private void BurstFindValves(IFlagDisplay pFlagDisplay)
        {
            try
            {
                INetwork pNetwork = pGeoNetwork.Network;
                IFeatureLayer pValveFeatLayer = Utility.FindFeatLayer("Water Fixtures", this);
                IFeatureLayer pWaterLineFeatLyr = Utility.FindFeatLayer("Water Lines", this);
                //得到EdgeFlag
                IEdgeFlag pEdgeFlag = new EdgeFlagClass();
                INetFlag pNetFlag = pEdgeFlag as INetFlag;
                pNetFlag.UserClassID = pFlagDisplay.FeatureClassID;
                pNetFlag.UserID = pFlagDisplay.FID;
                //获得阀门的光标
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = "PWF_TYPE_CODE = 1";
                IFeatureSelection pValveFeatSelection = pValveFeatLayer as IFeatureSelection;
                pValveFeatSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                //设置所选择的阀们为SelectionSetBarriers
                ISelectionSetBarriers pSelSetBarriers = new SelectionSetBarriersClass();
                int FeatClassID = pValveFeatLayer.FeatureClass.FeatureClassID;
                IEnumIDs pEnumIDs = pValveFeatSelection.SelectionSet.IDs;
                pEnumIDs.Reset();
                int FeatID = pEnumIDs.Next();
                while (FeatID > 0)
                {
                    pSelSetBarriers.Add(FeatClassID, FeatID);
                    FeatID = pEnumIDs.Next();
                }
                //创建TraceFlowSolver
                ITraceFlowSolver pTraceFlowSolver = new TraceFlowSolverClass() as ITraceFlowSolver;

                INetSolver pNetSolver = pTraceFlowSolver as INetSolver;
                pNetSolver.SourceNetwork = pNetwork;
                pNetSolver.SelectionSetBarriers = pSelSetBarriers;
                pTraceFlowSolver.PutEdgeOrigins(1, ref pEdgeFlag);
                //从跟踪过程中获得结果
                IEnumNetEID pResultJenction;
                IEnumNetEID pResultsEdges;
                IEnumNetEID ptmpEnumNetEID = null;
                pTraceFlowSolver.FindFlowEndElements(esriFlowMethod.esriFMConnected, esriFlowElements.esriFEJunctions, out pResultJenction, out ptmpEnumNetEID);
                pTraceFlowSolver.FindFlowElements(esriFlowMethod.esriFMConnected, esriFlowElements.esriFEEdges, out ptmpEnumNetEID, out pResultsEdges);
                int lEID;
                int iUserClassID;
                int iUserID;
                int iUserSubID;
                INetElements pNetElements = pGeoNetwork.Network as INetElements;
                pResultJenction.Reset();
                IFeature pFeature;
                pValveFeatSelection.Clear();
                for (int j = 0; j <= pResultJenction.Count - 1; j++)
                {
                    lEID = pResultJenction.Next();
                    pNetElements.QueryIDs(lEID, esriElementType.esriETJunction, out iUserClassID, out iUserID, out iUserSubID);
                    pFeature = pValveFeatLayer.FeatureClass.GetFeature(iUserID);
                    pValveFeatSelection.Add(pFeature);
                    // MessageBox.Show(iUserClassID.ToString()+","+iUserID.ToString()+","+iUserSubID.ToString());
                }
                IFeatureSelection pLinesFeatSelection = pWaterLineFeatLyr as IFeatureSelection;
                pLinesFeatSelection.Clear();
                for (int i = 0; i <= pResultsEdges.Count - 1; i++)
                {
                    lEID = pResultsEdges.Next();
                    pNetElements.QueryIDs(lEID, esriElementType.esriETEdge, out iUserClassID, out iUserID, out iUserSubID);
                    pFeature = pWaterLineFeatLyr.FeatureClass.GetFeature(iUserID);
                    pLinesFeatSelection.Add(pFeature);
                }

                //创建新的符号用于渲染选取的结果
                IMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbolClass();
                IRgbColor pRGBColor = new RgbColorClass();
                pRGBColor.Red = 12;
                pRGBColor.Green = 250;
                pRGBColor.Blue = 233;
                pMarkerSymbol.Size = 14;
                pMarkerSymbol.Color = pRGBColor;
                pValveFeatSelection.SelectionSymbol = pMarkerSymbol as ISymbol;
                pValveFeatSelection.SelectionColor = pRGBColor as IColor;
                pValveFeatSelection.SelectionChanged();

                IRgbColor pRGBColor2 = new RgbColorClass();
                pRGBColor2.Red = 230;
                pRGBColor2.Green = 230;
                pRGBColor2.Blue = 0;
                pLinesFeatSelection.SelectionColor = pRGBColor2;
                pLinesFeatSelection.SelectionChanged();
                axMapControl1.ActiveView.Refresh();
                ICursor pCursor = null;
                pValveFeatSelection.SelectionSet.Search(null, false, out pCursor);
                IFeatureCursor pFeatCursor = pCursor as IFeatureCursor;
                IArray pArray = new ArrayClass();
                pFeature = pFeatCursor.NextFeature();
                while (pFeature != null)
                {
                    pArray.Add(pFeature);
                    pFeature = pFeatCursor.NextFeature();
                }
                pFeature = pWaterLineFeatLyr.FeatureClass.GetFeature(pFlagDisplay.FID);
                frmBurstReport frmBurstReport1 = new frmBurstReport(this, pValveFeatLayer, pWaterLineFeatLyr, pArray, pFeature);
                frmBurstReport1.Show();

            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }
        }
        ////////////////////////////////////////////////////////
        //
        private void LoadAddedNetworkPoint(string strNetworkName, IPointCollection pPointCol)
        {
            //IFeatureClass pFeatClass = new FeatureClassClass;
            //IFeatureBuffer pFeatBuffer = pFeatClass.CreateFeatureBuffer();
            //IFeatureCursor pFeatCursor = pFeatClass.Insert(true);
            //IFeature pFeat = pFeatBuffer as IFeature;
            //for (int i = 0; i <= pPointCol.PointCount - 1; i++)
            //{
            //    IPoint pPoint = pPointCol.get_Point(i);
            //    pFeat.Shape = pPoint;
            //    object q = pFeatCursor.InsertFeature(pFeatBuffer);
            //}
            //pFeatCursor.Flush();

        }
        private IPolyline GetSmashedLine(IScreenDisplay pDisplay, ISymbol pSymbol, IPoint pPoint, IPolyline pPolyline)
        {
            IPolygon pBoundry = new PolygonClass();
            pSymbol.QueryBoundary(pDisplay.hDC, pDisplay.DisplayTransformation, pPoint, pBoundry);
            ITopologicalOperator pTopo = pBoundry as ITopologicalOperator;
            IPolyline pIntersect = pTopo.Intersect(pPolyline, esriGeometryDimension.esriGeometry1Dimension) as IPolyline;
            pTopo = pPolyline as ITopologicalOperator;
            return pTopo.Difference(pIntersect) as IPolyline;

        }


        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {

            IActiveView pActiveView = axMapControl1.ActiveView.FocusMap as IActiveView;
            IPoint pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
            object Missing = Type.Missing;
            switch (m_BasicOperationTool)
            {
                case "isMeasure":
                    if (!m_bInUse)
                        break;
                    bool bFirstTime = false;
                    if (m_pLineSymbol == null)
                        bFirstTime = true;
                    pActiveView.ScreenDisplay.StartDrawing(pActiveView.ScreenDisplay.hDC, -1);
                    if (bFirstTime == true)
                    {
                        IRgbColor pRgbColor = new RgbColorClass();
                        m_pLineSymbol = new SimpleLineSymbolClass();
                        m_pLineSymbol.Width = 2;
                        pRgbColor.Red = 223;
                        pRgbColor.Green = 223;
                        pRgbColor.Blue = 223;
                        m_pLineSymbol.Color = pRgbColor;
                        ISymbol pSymbol = m_pLineSymbol as ISymbol;
                        pSymbol.ROP2 = esriRasterOpCode.esriROPXOrPen;
                        //设置文本符号
                        m_pTextSymbol = new TextSymbolClass();
                        m_pTextSymbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHACenter;
                        m_pTextSymbol.VerticalAlignment = esriTextVerticalAlignment.esriTVACenter;
                        m_pTextSymbol.Size = 16;
                        pSymbol = m_pTextSymbol as ISymbol;
                        stdole.IFontDisp fnt = (stdole.IFontDisp)new stdole.StdFontClass();
                        fnt.Name = "Arial";
                        fnt.Size = Convert.ToDecimal(20);
                        m_pTextSymbol.Font = fnt;
                        pSymbol.ROP2 = esriRasterOpCode.esriROPXOrPen;
                        //创建点以画文本
                        m_pTextPoint = new PointClass();
                    }
                    else
                    {
                        pActiveView.ScreenDisplay.SetSymbol(m_pTextSymbol as ISymbol);
                        pActiveView.ScreenDisplay.DrawText(m_pTextPoint, m_pTextSymbol.Text);
                        pActiveView.ScreenDisplay.SetSymbol(m_pLineSymbol as ISymbol);
                        if (m_pLinePolyline.Length > 0)
                            pActiveView.ScreenDisplay.DrawPolyline(m_pLinePolyline);
                    }
                    //在起点到终点之间绘制线并设置文本的角度
                    ILine pLine = new LineClass();
                    pLine.PutCoords(m_pStartPoint, pPoint);
                    double angle = pLine.Angle;
                    angle = angle * (180 / 3.1415926);
                    if ((angle > 90) || (angle < 180))
                        angle = angle + 180;
                    if ((angle < 0) || (angle > -90))
                        angle = angle - 180;
                    if ((angle < -90) || (angle > -180))
                        angle = angle - 180;
                    if (angle > 180)
                        angle = angle - 180;
                    //为了绘制文本，获得文本的距离，角度和点
                    double deltaX = pPoint.X - m_pStartPoint.X;
                    double deltaY = pPoint.Y - m_pStartPoint.Y;
                    m_pTextPoint.X = m_pStartPoint.X + deltaX / 2;
                    m_pTextPoint.Y = m_pStartPoint.Y + deltaY / 2;
                    m_pTextSymbol.Angle = angle;
                    int distance = Convert.ToInt32(Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY)));
                    m_pTextSymbol.Text = "[" + distance.ToString() + "]";
                    //绘制文本
                    pActiveView.ScreenDisplay.SetSymbol(m_pTextSymbol as ISymbol);
                    pActiveView.ScreenDisplay.DrawText(m_pTextPoint, m_pTextSymbol.Text);
                    //获得多段线
                    IPolyline pPolyline = new PolylineClass();
                    ISegmentCollection pSegColl = pPolyline as ISegmentCollection;
                    pSegColl.AddSegment(pLine as ISegment, ref Missing, ref Missing);
                    m_pLinePolyline = GetSmashedLine(pActiveView.ScreenDisplay, m_pTextSymbol as ISymbol, m_pTextPoint, pPolyline);
                    //绘制多边形
                    pActiveView.ScreenDisplay.SetSymbol(m_pLineSymbol as ISymbol);
                    if (m_pLinePolyline.Length > 0)
                    {
                        pActiveView.ScreenDisplay.DrawPolyline(m_pLinePolyline);
                    }
                    pActiveView.ScreenDisplay.FinishDrawing();
                    break;
            }
        }

        private void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (m_BasicOperationTool == "isMeasure")
            {
                m_bInUse = false;
                if (m_pLineSymbol != null)
                {
                    IActiveView pActiveView = axMapControl1.ActiveView.FocusMap as IActiveView;
                    pActiveView.ScreenDisplay.StartDrawing(pActiveView.ScreenDisplay.hDC, -1);
                    pActiveView.ScreenDisplay.SetSymbol(m_pTextSymbol as ISymbol);
                    pActiveView.ScreenDisplay.DrawText(m_pTextPoint, m_pTextSymbol.Text);
                    pActiveView.ScreenDisplay.SetSymbol(m_pLineSymbol as ISymbol);
                    if (m_pLinePolyline.Length > 0)
                        pActiveView.ScreenDisplay.DrawPolyline(m_pLinePolyline);
                    pActiveView.ScreenDisplay.FinishDrawing();
                    m_pTextSymbol = null;
                    m_pTextPoint = null;
                    m_pLinePolyline = null;
                    m_pLineSymbol = null;
                }
            }
        }

        private void menuItem7_Click(object sender, System.EventArgs e)
        {
            frmAbout frmAbout1 = new frmAbout();
            frmAbout1.Show();
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                IBasicMap map = new MapClass();
                ILayer layer = new FeatureLayerClass();
                object other = new object();
                object index = new object();
                esriTOCControlItem item = new esriTOCControlItem();

                try
                {
                    axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

                }
                catch (Exception eX)
                {
                    MessageBox.Show(eX.Message);

                }

                if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {

                    if (layer != null)
                    {
                        this.setCurrentLayer(layer);

                    }

                }
            }
        }
        //以下是鹰眼的拖拽功能实现代码
        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            IElement element = m_AOI as IElement;
            element.Geometry = e.newEnvelope as IGeometry;

            UpdateUI();
        }
        private bool HitTest(IEnvelope envelope, IPoint point)
        {
            if (envelope.XMin < point.X && envelope.XMax > point.X && envelope.YMin < point.Y && envelope.YMax > point.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool HitTest(IEnvelope envelope, double x, double y)
        {
            if (envelope.XMin < x && envelope.XMax > x && envelope.YMin < y && envelope.YMax > y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                IElement element = m_AOI as IElement;
                IEnvelope envelope = element.Geometry.Envelope as IEnvelope;

                if (HitTest(envelope, e.mapX, e.mapY))
                {
                    IFillShapeElement fillSymbol = m_AOI as IFillShapeElement;

                    fillSymbol.Symbol = m_pSelectedSymbol;

                    IPoint point = new PointClass();
                    point.PutCoords(e.mapX, e.mapY);
                    envelope.CenterAt(point);

                    m_AOI.Geometry = envelope;

                    UpdateUI();
                }
            }
        }

        private void axMapControl2_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {
            object obj = m_AOI.Symbol;
            axMapControl2.DrawShape(m_AOI.Geometry, ref obj);
        }

        private void axMapControl2_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IElement element = m_AOI as IElement;
                IEnvelope envelope = element.Geometry.Envelope as IEnvelope;

                if (HitTest(envelope, e.mapX, e.mapY))
                {
                    IPoint point = new PointClass();
                    point.PutCoords(e.mapX, e.mapY);
                    envelope.CenterAt(point);

                    m_AOI.Geometry = envelope;

                    this.UpdateUI();
                }
            }
        }

        private void axMapControl2_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 1)
            {
                IFillShapeElement fillSymbol = m_AOI as IFillShapeElement;
                fillSymbol.Symbol = m_pFillSymbol;
                IElement element = m_AOI as IElement;
                IEnvelope envelope = element.Geometry.Envelope as IEnvelope;

                IPoint point = new PointClass();
                point.PutCoords(e.mapX, e.mapY);
                envelope.CenterAt(point);

                m_AOI.Geometry = envelope;

                UpdateUI();
                Newleaf.ExtentUpdatedEventArgs args = new Newleaf.ExtentUpdatedEventArgs(envelope);
                OnExtentUpdating(args);


            }
        }


        private void OnExtentUpdating(Newleaf.ExtentUpdatedEventArgs e)
        {
            if (e != null)
            {
                axMapControl1.Extent = e.Envelope;
                axMapControl1.Refresh();
            }
        }
        private void axMapControl2_OnFullExtentUpdated(object sender, IMapControlEvents2_OnFullExtentUpdatedEvent e)
        {
            IElement element = m_AOI as IElement;

            if (element != null)
            {
                element.Geometry = axMapControl2.Extent.Envelope;
            }
        }
        //空间分析
        //表面栅格计算－等值线
        private void menuItem44_Click(object sender, EventArgs e)
        {
            frmContour frmContour1 = new frmContour(this);
            frmContour1.Show();
        }
        //空间分析
        //表面栅格计算－坡度
        private void menuItem45_Click(object sender, EventArgs e)
        {
            frmSlope frmSlope1 = new frmSlope(this);
            frmSlope1.Show();
        }
        //空间分析
        //象素统计计算
        private void menuItem50_Click(object sender, EventArgs e)
        {
            frmCellStatistic frmCellStatistic1 = new frmCellStatistic(this);
            frmCellStatistic1.Show();
        }
        //空间分析
        //栅格计算器
        private void menuItem57_Click(object sender, EventArgs e)
        {
            frmRasterCalculate frmRasterCalculate1 = new frmRasterCalculate(this);
            frmRasterCalculate1.Show();
        }
        //空间分析
        //特征转换为栅格
        private void menuItem59_Click(object sender, EventArgs e)
        {
            frmFeatureToRaster frmFeatureToRaster1 = new frmFeatureToRaster(this);
            frmFeatureToRaster1.Show();
        }
        //空间分析
        //栅格转换为特征
        private void menuItem60_Click(object sender, EventArgs e)
        {
            frmRasterToFeature frmRasterToFeature1 = new frmRasterToFeature(this);
            frmRasterToFeature1.Show();
        }
        //空间分析
        //表面分析－计算方向栅格
        private void menuItem46_Click(object sender, EventArgs e)
        {
            frmAspect frmAspect1 = new frmAspect(this);
            frmAspect1.Show();
        }
        //空间分析
        //表面分析－计算山体阴影栅格
        private void menuItem47_Click(object sender, EventArgs e)
        {
            frmHillShade frmHillShade1 = new frmHillShade(this);
            frmHillShade1.Show();
        }
        //空间分析
        //表面分析－计算通视分析栅格
        private void menuItem48_Click(object sender, EventArgs e)
        {
            frmViewshed frmViewshed1 = new frmViewshed(this);
            frmViewshed1.Show();

        }
        //空间分析
        //表面分析－计算填挖方量
        private void menuItem49_Click(object sender, EventArgs e)
        {
            frmCutFill frmCutFill1 = new frmCutFill(this);
            frmCutFill1.Show();
        }
        //空间分析
        //距离分析－计算分配栅格
        private void menuItem38_Click(object sender, EventArgs e)
        {
            frmAllocation frmAllocation1 = new frmAllocation(this);
            frmAllocation1.Show();
        }

        //打开网络分析工具条
        private void menuItem14_Click(object sender, EventArgs e)
        {
            ToolBarDockHolder holder = _toolBarManager.GetHolder("网络分析");
            _toolBarManager.ShowControl(holder.Control, !holder.Control.Visible);
        }

        private void toolBar2_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar2.Buttons.IndexOf(e.Button))
            {
                case 2:
                    EnableNetworkMenu(true);
                    tabControl1.SelectTab(1);
                    break;
                case 6:
                    NetworkSolve();
                    break;
                case 4:
                    m_BasicOperationTool = "AddNetworkPoint";
                    axMapControl1.MousePointer = esriControlsMousePointer.esriPointerArrow;
                    break;

            }
        }
        //开始进行网络分析计算
        private void NetworkSolve()
        {
            try
            {
                IGPMessages gpMessages = new GPMessagesClass();
                IFeatureClass pFeatCls = null;
                IGeoDataset geoDataset = null;
                if (!m_NAContext.Solver.Solve(m_NAContext, gpMessages, null))
                {
                    for (int i = 0; i <= m_NAContext.NAClasses.Count - 1; i++)
                    {
                        string sName = m_NAContext.NAClasses.get_Name(i);                      
                        if (sName == "Routes")
                        {
                            geoDataset = m_NAContext.NAClasses.get_ItemByName("Routes") as IGeoDataset;
                            pFeatCls = geoDataset as IFeatureClass;
                           // LoadNANetworkLocations("Routes", pFeatCls, 5000);
                        }
                        if (sName == "CFRoutes")
                        {
                            geoDataset = m_NAContext.NAClasses.get_ItemByName("CFRoutes") as IGeoDataset;
                            pFeatCls = geoDataset as IFeatureClass;
                        }
                        
                    }                    
                    
                    IEnvelope pEnvelope = geoDataset.Extent;
                    if (!pEnvelope.IsEmpty)
                        pEnvelope.Expand(1.1, 1.1, true);
                    axMapControl1.Extent = pEnvelope;
                    axMapControl1.Refresh();
                }
                else
                {
                    if (gpMessages != null)
                    {
                        for (int i = 0; i < gpMessages.Count; i++)
                        {
                            switch (gpMessages.GetMessage(i).Type)
                            {

                                case esriGPMessageType.esriGPMessageTypeError:
                                    MessageBox.Show("Error " + gpMessages.GetMessage(i).ErrorCode.ToString() + " " + gpMessages.GetMessage(i).Description);
                                    break;
                                case esriGPMessageType.esriGPMessageTypeWarning:
                                    MessageBox.Show("Warning " + gpMessages.GetMessage(i).Description);
                                    break;
                                default:
                                    MessageBox.Show("Information " + gpMessages.GetMessage(i).Description);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
        }
        //装载网络分析元素的位置
        private void LoadNANetworkLocations(string strNAClassName, IFeatureClass inputFC, double snapTolerance)
        {
            INAClass naClass;
            INamedSet classes;
            classes = m_NAContext.NAClasses;
            naClass = classes.get_ItemByName(strNAClassName) as INAClass;

            // delete existing Locations except if that a barriers
            naClass.DeleteAllRows();

            // Create a NAClassLoader and set the snap tolerance (meters unit)
            INAClassLoader classLoader = new NAClassLoader();
            classLoader.Locator = m_NAContext.Locator;
            if (snapTolerance > 0) classLoader.Locator.SnapTolerance = snapTolerance;
            classLoader.NAClass = naClass;

            //Create field map to automatically map fields from input class to naclass
            INAClassFieldMap fieldMap;
            fieldMap = new NAClassFieldMap();
            fieldMap.CreateMapping(naClass.ClassDefinition, inputFC.Fields);
            classLoader.FieldMap = fieldMap;

            //Load Network Locations
            int rowsIn = 0;
            int rowsLocated = 0;
            IFeatureCursor featureCursor = inputFC.Search(null, true);
            classLoader.Load((ICursor)featureCursor, null, ref rowsIn, ref rowsLocated);
        }
        //网络分析
        //生成新的求取最近服务区域的条件
        private void menuItem22_Click(object sender, EventArgs e)
        {

        }
        //网络分析
        //生成新的求取最近设施的条件
        private void menuItem24_Click(object sender, EventArgs e)
        {
            treeViewListItem.Nodes.Clear();
            comboBoxNetList.Items.Clear();
            m_NAContext = Utility.CreateSolverContext(m_pNetDataset, "设施");
            m_sNAName = "设施";
            TreeNode node1;
            node1 = treeViewListItem.Nodes.Add("设施");
            node1 = treeViewListItem.Nodes.Add("事故");
            node1 = treeViewListItem.Nodes.Add("路线");
            node1 = treeViewListItem.Nodes.Add("障碍");
            string strClosetF = "最临近服务设施" + iClosetFCount.ToString();
            comboBoxNetList.Items.Add(strClosetF);
            comboBoxNetList.Text = strClosetF;
            iClosetFCount += 1;
            strNetAnalystContext = "临近设施";
           
            AxMapControl axMap = getMapControl();
            //axMap.AddLayer(layer, 0);

            //Create a Network Analysis Layer and add to ArcMap
            INALayer naLayer = m_NAContext.Solver.CreateLayer(m_NAContext);
            ILayer layer = naLayer as ILayer;
            layer.Name = m_NAContext.Solver.DisplayName;
            axMap.AddLayer(layer, 0);
        }



        private void treeViewListItem_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                treeViewListItem.ContextMenu = contextMenu3;
            }
        }
        //网络分析—装载数据
        private void menuItem35_Click(object sender, EventArgs e)
        {
             

            // Show the Property Page form for Network Analyst
            frmLoadNetworkData loadLocations = new frmLoadNetworkData(this, m_NetNodeSelected);
            loadLocations.Show();
        }

        private void treeViewListItem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_NetNodeSelected = e.Node;
            if (e.Node.Text == "路线")
                menuItem35.Enabled = false;
            else
                menuItem35.Enabled = true;
        }
        //网络分析
        //计算最短路径
        private void menuItem21_Click(object sender, EventArgs e)
        {
            treeViewListItem.Nodes.Clear();
            comboBoxNetList.Items.Clear();
            m_NAContext = Utility.CreateSolverContext(m_pNetDataset, "路线");
            m_sNAName = "路线";
            TreeNode node1;            
            node1 = treeViewListItem.Nodes.Add("事故");
            node1 = treeViewListItem.Nodes.Add("Routes","路线");
            node1 = treeViewListItem.Nodes.Add("障碍");
            string strClosetR = "最短路线" + iClosetRCount.ToString();
            comboBoxNetList.Items.Add(strClosetR);
            comboBoxNetList.Text = strClosetR;
            iClosetRCount += 1;
            strNetAnalystContext = "最短路线";
            //

            //Create Layer for Network Dataset and add to ArcMap
            //ILayer layer;
            //INetworkLayer networkLayer;
            //networkLayer = new NetworkLayerClass();
            //networkLayer.NetworkDataset = m_pNetDataset;
            //layer = networkLayer as ILayer;
            //layer.Name = "Network Dataset";
            AxMapControl axMap = getMapControl();
            //axMap.AddLayer(layer, 0);

            //Create a Network Analysis Layer and add to ArcMap
            INALayer naLayer = m_NAContext.Solver.CreateLayer(m_NAContext);
            ILayer layer = naLayer as ILayer;
            layer.Name = m_NAContext.Solver.DisplayName;
            axMap.AddLayer(layer, 0);
        }

        private void menuItem26_Click_1(object sender, EventArgs e)
        {

        }
        //设置网络分析参数
        private void buttonNetSetting_Click(object sender, EventArgs e)
        {
            if (m_sNAName == "设施")
            {
                frmNetAnalystSetting frmNetAnalystSetting1 = new frmNetAnalystSetting(this);
                frmNetAnalystSetting1.Show();
            }
            if (m_sNAName == "路线")
            {
                frmCRNetASetting frmCRNetASetting1 = new frmCRNetASetting(this);
                frmCRNetASetting1.Show();
            }

        }
        public ToolBarButton returnToolbarButton()
        {
            return toolBarButtonSolve;
        }

        //符号化
        private void menuItem62_Click(object sender, EventArgs e)
        {
            if (this.currentLayer is IFeatureLayer)
            {
                IFeatureLayer pFeatLayer = this.currentLayer as IFeatureLayer;
                frmSymbolSet frmSymbolSet1 = new frmSymbolSet(this, pFeatLayer);
                frmSymbolSet1.Show();
            }
        }
        //动态显示地图的提示信息
        private void menuItem63_Click(object sender, EventArgs e)
        {
            string strLayerName = currentLayer.Name;
            frmSetLayerTips frmSetLayerTips1 = new frmSetLayerTips(this, strLayerName);
            frmSetLayerTips1.Show();
        }

        //初始化Utility网络分析地图环境资源
        private void LegendVisible(ILayer pLayer, bool IsVisible)
        {
            ILegendInfo pLegendInfo = pLayer as ILegendInfo;
            for (int i = 0; i <= pLegendInfo.LegendGroupCount - 1; i++)
            {
                ILegendGroup pLegendGrp = pLegendInfo.get_LegendGroup(i);
                pLegendGrp.Visible = IsVisible;
            }

        }
        private void SetLayersForApp(IArray LayerNameArray)
        {
            ILayer pLayer;
            bool found;
            found = false;
            for (int i = 0; i <= axMapControl1.LayerCount - 1; i++)
            {
                if (axMapControl1.get_Layer(i) is IFeatureLayer)
                {
                    pLayer = axMapControl1.get_Layer(i);
                    for (int j = 0; j < LayerNameArray.Count; j++)
                    {
                        //MessageBox.Show(LayerNameArray.get_Element(i).ToString());
                        if (pLayer.Name == LayerNameArray.get_Element(j).ToString())
                        {
                            pLayer.Visible = true;
                            LegendVisible(pLayer, true);
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        pLayer.Visible = false;
                        LegendVisible(pLayer, false);
                    }
                    found = false;
                }
            }
        }
        private void InitializeMap(string sDataPath)
        {
            IArray layerNameArray = new ArrayClass();
            layerNameArray.Add("Parcels");
            layerNameArray.Add("Roads");
            layerNameArray.Add("Ocean");
            SetLayersForApp(layerNameArray);
            IEnvelope pEnv = new EnvelopeClass();
            pEnv.XMin = 555957;
            pEnv.YMin = 39874;
            pEnv.XMax = 563539;
            pEnv.YMax = 45522;
            IActiveView pActiveView = axMapControl1.ActiveView.FocusMap as IActiveView;
            pActiveView.Extent = pEnv;
            pActiveView.Refresh();

        }
        //进行Utility网络分析之前，首先要初始化数据环境
        private void menuItem66_Click(object sender, EventArgs e)
        {
            string sUtilityNetPath;
            sUtilityNetPath = Application.StartupPath + @"\..\..\..\Data\Sewer9\Start.mxd";
            if (axMapControl1.CheckMxFile(sUtilityNetPath) == true)
            {
                axMapControl1.LoadMxFile(sUtilityNetPath, null, null);
                axMapControl2.LoadMxFile(sUtilityNetPath, null, null);
            }
            else
            {
                MessageBox.Show("所选择的文档视图文件不存在,请重新指定!", "错误提示");
            }
            IElement element = m_AOI as IElement;
            axMapControl2.Extent = axMapControl2.FullExtent;
            element.Geometry = axMapControl1.Extent.Envelope;
            m_AOI.SpatialReference = axMapControl1.SpatialReference;
            axMapControl2.SpatialReference = axMapControl1.SpatialReference;
            UpdateUI();
        }
        //清除设施管理中所有的操作
        //设施管理
        public void CleanUpApp()
        {
            IMap pMap = axMapControl1.ActiveView.FocusMap;
            pMap.ClearSelection();//清除任何被选择的数据集合
            //获得网络分析扩展

        }
        //水管和阀门关闭影响分析

        private void menuItem65_Click(object sender, EventArgs e)
        {
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            m_BasicOperationTool = "isFindWaterValve";
            IMap pMap = axMapControl1.ActiveView.FocusMap;
            pMap.DelayDrawing(true);
            CleanUpApp();
            //清除设施管理中所有的操作
            IEnvelope pEnv = new EnvelopeClass();
            pEnv.XMin = 555594;
            pEnv.YMin = 46225;
            pEnv.XMax = 557748;
            pEnv.YMax = 47624;
            axMapControl1.ActiveView.Extent = pEnv;
            //打开该功能涉及到的图层
            IArray pLayerNameArray = new ArrayClass();
            pLayerNameArray.Add("Water Fixtures");
            pLayerNameArray.Add("Water Lines");
            pLayerNameArray.Add("Parcels");
            pLayerNameArray.Add("Roads");
            SetLayersForApp(pLayerNameArray);
            //为Water fixtures设置特征图层定义
            IFeatureLayer pFeatLayer = Utility.FindFeatLayer("Water Fixtures", this);
            IFeatureLayerDefinition pFeatLayerDef = pFeatLayer as IFeatureLayerDefinition;
            pFeatLayerDef.DefinitionExpression = "[PWF_TYPE] = 1";
            //设置选择图层
            for (int i = 0; i <= pMap.LayerCount - 1; i++)
            {
                if (pMap.get_Layer(i) is IFeatureLayer)
                {
                    pFeatLayer = pMap.get_Layer(i) as IFeatureLayer;
                    if (pFeatLayer.Name == "Water Fixtures" || pFeatLayer.Name == "Water Lines")
                        pFeatLayer.Selectable = true;
                    else
                        pFeatLayer.Selectable = false;
                }
            }
            //获得指定的几何网络
            string sUtilityNetPath;
            sUtilityNetPath = Application.StartupPath + @"\..\..\..\Data\Sewer9\data\sewer3.mdb";
            pGeoNetwork = Utility.openGeoNetwork(sUtilityNetPath, "urban", "Water_Network");
            pMap.DelayDrawing(false);
            axMapControl1.ActiveView.Refresh();

        }
        //Utility分析工具
        //上朔追踪分析/////////////////////////////////////////////////////////////////
        private void menuItem67_Click(object sender, EventArgs e)
        {
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            m_BasicOperationTool = "isUpstreamTrace";
            IMap pMap = axMapControl1.ActiveView.FocusMap;
            pMap.DelayDrawing(true);
            CleanUpApp();
            //清除设施管理中所有的操作
            IEnvelope pEnv = new EnvelopeClass();
            pEnv.XMin = 561855;
            pEnv.YMin = 42376;
            pEnv.XMax = 563299;
            pEnv.YMax = 43783;
            axMapControl1.ActiveView.Extent = pEnv;
            //打开该功能涉及到的图层
            IArray pLayerNameArray = new ArrayClass();
            pLayerNameArray.Add("Sewer Fixtures");
            pLayerNameArray.Add("Sewer Lines");
            pLayerNameArray.Add("Parcels");
            pLayerNameArray.Add("Roads");
            SetLayersForApp(pLayerNameArray);
            //为Water fixtures设置特征图层定义
            IFeatureLayer pFeatLayer = Utility.FindFeatLayer("Sewer Fixtures", this);
            IFeatureLayerDefinition pFeatLayerDef = pFeatLayer as IFeatureLayerDefinition;
            pFeatLayerDef.DefinitionExpression = "[NODE_TYPE] = 'MH'";
            //设置选择图层
            for (int i = 0; i <= pMap.LayerCount - 1; i++)
            {
                if (pMap.get_Layer(i) is IFeatureLayer)
                {
                    pFeatLayer = pMap.get_Layer(i) as IFeatureLayer;
                    if (pFeatLayer.Name == "Sewer Fixtures" || pFeatLayer.Name == "Sewer Lines" || pFeatLayer.Name == "Parcels")
                        pFeatLayer.Selectable = true;
                    else
                        pFeatLayer.Selectable = false;
                }
            }
            //获得指定的几何网络
            string sUtilityNetPath;
            sUtilityNetPath = Application.StartupPath + @"\..\..\..\Data\Sewer9\data\sewer3.mdb";
            pGeoNetwork = Utility.openGeoNetwork(sUtilityNetPath, "urban", "Sewer_Network");
            pMap.DelayDrawing(false);
            axMapControl1.ActiveView.Refresh();
        }
        //管线设施剖面分析
        private void menuItem68_Click(object sender, EventArgs e)
        {
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            m_BasicOperationTool = "isProfileAnalysis";
            IMap pMap = axMapControl1.ActiveView.FocusMap;
            pMap.DelayDrawing(true);
            CleanUpApp();
            //清除设施管理中所有的操作
            IEnvelope pEnv = new EnvelopeClass();
            pEnv.XMin = 561900;
            pEnv.YMin = 42450;
            pEnv.XMax = 563800;
            pEnv.YMax = 43676;
            axMapControl1.ActiveView.Extent = pEnv;
            //打开该功能涉及到的图层
            IArray pLayerNameArray = new ArrayClass();
            pLayerNameArray.Add("Sewer Fixtures");
            pLayerNameArray.Add("Sewer Lines");
            pLayerNameArray.Add("Parcels");
            pLayerNameArray.Add("Roads");
            SetLayersForApp(pLayerNameArray);
            //为Water fixtures设置特征图层定义
            IFeatureLayer pFeatLayer = Utility.FindFeatLayer("Sewer Fixtures", this);
            IFeatureLayerDefinition pFeatLayerDef = pFeatLayer as IFeatureLayerDefinition;
            pFeatLayerDef.DefinitionExpression = "[NODE_TYPE] = 'MH'";
            IFeatureLayer pFeatLayer2 = Utility.FindFeatLayer("Sewer Lines", this);
            pFeatLayerDef = pFeatLayer2 as IFeatureLayerDefinition;
            pFeatLayerDef.DefinitionExpression = "[LINE_TYPE] = 'MG'";
            //设置选择图层
            for (int i = 0; i <= pMap.LayerCount - 1; i++)
            {
                if (pMap.get_Layer(i) is IFeatureLayer)
                {
                    pFeatLayer2 = pMap.get_Layer(i) as IFeatureLayer;
                    if (pFeatLayer2.Name == "Sewer Fixtures")
                        pFeatLayer2.Selectable = true;
                    else
                        pFeatLayer2.Selectable = false;
                }
            }
            //获得指定的几何网络
            string sUtilityNetPath;
            sUtilityNetPath = Application.StartupPath + @"\..\..\..\Data\Sewer9\data\sewer3.mdb";
            pGeoNetwork = Utility.openGeoNetwork(sUtilityNetPath, "urban", "Sewer_Network");
            pMap.DelayDrawing(false);
            axMapControl1.ActiveView.Refresh();
        }
        //初始化空间分析数据环境
        private void menuItem69_Click(object sender, EventArgs e)
        {
            string sUtilityNetPath;
            sUtilityNetPath = Application.StartupPath + @"\..\..\..\Data\Spatial\spatial.mxd";
            if (axMapControl1.CheckMxFile(sUtilityNetPath) == true)
            {
                axMapControl1.LoadMxFile(sUtilityNetPath, null, null);
                axMapControl2.LoadMxFile(sUtilityNetPath, null, null);
            }
            else
            {
                MessageBox.Show("所选择的文档视图文件不存在,请重新指定!", "错误提示");
            }
            IElement element = m_AOI as IElement;
            axMapControl2.Extent = axMapControl2.FullExtent;
            element.Geometry = axMapControl1.Extent.Envelope;
            m_AOI.SpatialReference = axMapControl1.SpatialReference;
            axMapControl2.SpatialReference = axMapControl1.SpatialReference;
            UpdateUI();
        }
        //管线维护视频监视
        private void menuItem70_Click(object sender, EventArgs e)
        {
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            m_BasicOperationTool = "isSewerTvSurvey";
            IMap pMap = axMapControl1.ActiveView.FocusMap;
            pMap.DelayDrawing(true);
            CleanUpApp();
            //清除设施管理中所有的操作


            //打开该功能涉及到的图层
            IArray pLayerNameArray = new ArrayClass();
            pLayerNameArray.Add("Sewer TV Surveys");
            pLayerNameArray.Add("Sewer Lines");
            pLayerNameArray.Add("Parcels");
            pLayerNameArray.Add("Roads");
            pLayerNameArray.Add("Ocean");
            SetLayersForApp(pLayerNameArray);
            //为Water fixtures设置特征图层定义
            IFeatureLayer pFeatLayer = Utility.FindFeatLayer("Sewer TV Surveys", this);
            IGeoDataset pGeodataset = pFeatLayer as IGeoDataset;
            IEnvelope pEnv = pGeodataset.Extent;
            pEnv.Expand(1.05, 1.05, true);
            axMapControl1.ActiveView.Extent = pEnv;
            //设置选择图层
            for (int i = 0; i <= pMap.LayerCount - 1; i++)
            {
                if (pMap.get_Layer(i) is IFeatureLayer)
                {
                    pFeatLayer = pMap.get_Layer(i) as IFeatureLayer;
                    if (pFeatLayer.Name == "Sewer Lines" || pFeatLayer.Name == "Sewer TV Surveys" || pFeatLayer.Name == "TV Survey Events")
                        pFeatLayer.Selectable = true;
                    else
                        pFeatLayer.Selectable = false;
                }
            }
            //获得指定的几何网络
            //string sUtilityNetPath;
            // sUtilityNetPath = Application.StartupPath + @"\..\..\..\Data\Sewer9\data\sewer3.mdb";
            //pGeoNetwork = Utility.openGeoNetwork(sUtilityNetPath, "urban", "Sewer_Network");
            Utility.TVScansHatchRoutes(this);

            pMap.DelayDrawing(false);
            axMapControl1.ActiveView.Refresh();

        }
        //调用工程地图
        private void menuItem71_Click(object sender, EventArgs e)
        {
            IMap pMap = axMapControl1.ActiveView.FocusMap;
            pMap.DelayDrawing(true);
            CleanUpApp();
            //设置地图范围
            IEnvelope pEnv = new EnvelopeClass();
            pEnv.XMin = 559166;
            pEnv.YMin = 39389;
            pEnv.XMax = 560403;
            pEnv.YMax = 41333;
            axMapControl1.ActiveView.Extent = pEnv;
            //打开应用的图层
            IArray pLayerNameArray = new ArrayClass();
            pLayerNameArray.Add("Street Centerlines");
            pLayerNameArray.Add("Street Project");
            pLayerNameArray.Add("Parcels");
            pLayerNameArray.Add("Elevation");
            pLayerNameArray.Add("Roads");
            pLayerNameArray.Add("Hillshade");
            SetLayersForApp(pLayerNameArray);
            //刷新屏幕
            pMap.DelayDrawing(false);
            axMapControl1.ActiveView.Refresh();
            //显示窗体
            frmUtilityImageMap frmUtilityImageMap1 = new frmUtilityImageMap();
            frmUtilityImageMap1.Show();
        }

        private void menuItem72_Click(object sender, EventArgs e)
        {
            frmDrawProfile frmDrawProfile1 = new frmDrawProfile(null) ;
            frmDrawProfile1.Show();
        }

       

        //
    }
}
