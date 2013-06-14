using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.TOCControl;
using ESRI.ArcGIS.ToolbarControl;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.NetworkAnalyst;

namespace Controls
{
	/// <summary>
	/// frmRoute 的摘要说明。
	/// </summary>
	public class frmRoute : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox chkOneWay;
		private System.Windows.Forms.ComboBox cmbCost;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private MainFrm pMainFrm=null;
		MyFunction.GISHelperFunction pGISHelper=null;
		private System.Windows.Forms.CheckBox chkMainRoad;
		INAContext m_pNAContext=null;

		public frmRoute(MainFrm _pMainFrm)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			pMainFrm=_pMainFrm;
			pGISHelper=new MyFunction.GISHelperFunction();
		

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.chkOneWay = new System.Windows.Forms.CheckBox();
			this.cmbCost = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.chkMainRoad = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chkOneWay
			// 
			this.chkOneWay.Checked = true;
			this.chkOneWay.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOneWay.Location = new System.Drawing.Point(16, 64);
			this.chkOneWay.Name = "chkOneWay";
			this.chkOneWay.TabIndex = 7;
			this.chkOneWay.Text = "使用单向路径";
			// 
			// cmbCost
			// 
			this.cmbCost.Location = new System.Drawing.Point(136, 24);
			this.cmbCost.Name = "cmbCost";
			this.cmbCost.Size = new System.Drawing.Size(128, 20);
			this.cmbCost.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 5;
			this.label1.Text = "代价字段:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(152, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 8;
			this.button1.Text = "查找路径";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chkMainRoad
			// 
			this.chkMainRoad.Location = new System.Drawing.Point(136, 67);
			this.chkMainRoad.Name = "chkMainRoad";
			this.chkMainRoad.Size = new System.Drawing.Size(104, 21);
			this.chkMainRoad.TabIndex = 9;
			this.chkMainRoad.Text = "使用主干道";
			// 
			// frmRoute
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(280, 165);
			this.Controls.Add(this.chkMainRoad);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chkOneWay);
			this.Controls.Add(this.cmbCost);
			this.Controls.Add(this.label1);
			this.Name = "frmRoute";
			this.Text = "查找最优路径";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmRoute_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmRoute_Load(object sender, System.EventArgs e)
		{
			string currentPath=System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			currentPath=currentPath+"\\..\\..\\Network";
			currentPath=@"C:\\Program Files\\ArcGIS\\DeveloperKit\\samples\\data\\networkanalyst";
			//currentPath=@"G:\\Research_Project\\C#DEMO\\CSharp\Network";
			//currentPath=@"E:\\PPT\\培训PPT\\C#DEMO\\CSharp\\Network";


			pGISHelper.loadNetworkData(currentPath,pMainFrm.getMapControl(),ref m_pNAContext,cmbCost,true);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			 bool IsPartialSolution;
			
			IGPMessages pGPMessages=new GPMessagesClass();

             IsPartialSolution = m_pNAContext.Solver.Solve(m_pNAContext, pGPMessages, null);
			if(IsPartialSolution==false){
			  //查找成功
				

			}

			 IGeoDataset pGDS;
             IEnvelope pEnv;

			pGDS=m_pNAContext.NAClasses.get_ItemByName("Routes") as IGeoDataset;
			pEnv = pGDS.Extent;
			pEnv.Expand(1.1, 1.1,true);
			
			pMainFrm.getMapControl().Extent = pEnv;
  
           pMainFrm.getMapControl().Refresh();




		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
