using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
//using ESRI.ArcGIS.TOCControl;
//using ESRI.ArcGIS.ToolbarControl;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Controls;
//using ESRI.ArcGIS.NE

namespace Controls
{
	/// <summary>
	/// frmClosestFacility 的摘要说明。
	/// </summary>
	public class frmClosestFacility : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbCost;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFacilityCount;
		private System.Windows.Forms.CheckBox chkOneWay;
		private System.Windows.Forms.CheckBox chkHierachy;
		private System.Windows.Forms.Button btnGO;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCutOff;

		private MainFrm pMainFrm=null;
		MyFunction.GISHelperFunction pGISHelper=null;

		INAContext m_pNAContext=null;


		public frmClosestFacility(MainFrm _pMainFrm)
		{
			//
			// Windows 窗体设计器支持所必需的
			//

			pMainFrm=_pMainFrm;
			pGISHelper=new MyFunction.GISHelperFunction();
			InitializeComponent();

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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCost = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFacilityCount = new System.Windows.Forms.TextBox();
            this.chkOneWay = new System.Windows.Forms.CheckBox();
            this.chkHierachy = new System.Windows.Forms.CheckBox();
            this.btnGO = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCutOff = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "代价字段:";
            // 
            // cmbCost
            // 
            this.cmbCost.Location = new System.Drawing.Point(144, 24);
            this.cmbCost.Name = "cmbCost";
            this.cmbCost.Size = new System.Drawing.Size(128, 20);
            this.cmbCost.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "目标设施数量:";
            // 
            // txtFacilityCount
            // 
            this.txtFacilityCount.Location = new System.Drawing.Point(144, 64);
            this.txtFacilityCount.Name = "txtFacilityCount";
            this.txtFacilityCount.Size = new System.Drawing.Size(128, 21);
            this.txtFacilityCount.TabIndex = 3;
            this.txtFacilityCount.Text = "1";
            // 
            // chkOneWay
            // 
            this.chkOneWay.Checked = true;
            this.chkOneWay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOneWay.Location = new System.Drawing.Point(32, 136);
            this.chkOneWay.Name = "chkOneWay";
            this.chkOneWay.Size = new System.Drawing.Size(104, 24);
            this.chkOneWay.TabIndex = 4;
            this.chkOneWay.Text = "使用单向路径";
            // 
            // chkHierachy
            // 
            this.chkHierachy.Location = new System.Drawing.Point(152, 136);
            this.chkHierachy.Name = "chkHierachy";
            this.chkHierachy.Size = new System.Drawing.Size(104, 24);
            this.chkHierachy.TabIndex = 5;
            this.chkHierachy.Text = "使用继承";
            this.chkHierachy.CheckedChanged += new System.EventHandler(this.chkHierachy_CheckedChanged);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(136, 192);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 6;
            this.btnGO.Text = "查找";
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "CutOff Count";
            // 
            // txtCutOff
            // 
            this.txtCutOff.Location = new System.Drawing.Point(144, 96);
            this.txtCutOff.Name = "txtCutOff";
            this.txtCutOff.Size = new System.Drawing.Size(128, 21);
            this.txtCutOff.TabIndex = 8;
            // 
            // frmClosestFacility
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(320, 237);
            this.Controls.Add(this.txtCutOff);
            this.Controls.Add(this.txtFacilityCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.chkHierachy);
            this.Controls.Add(this.chkOneWay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCost);
            this.Controls.Add(this.label1);
            this.Name = "frmClosestFacility";
            this.Text = "查找最近设施";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmClosestFacility_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void chkHierachy_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void frmClosestFacility_Load(object sender, System.EventArgs e)

		{
			string currentPath=System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			currentPath=currentPath+"\\..\\..\\Network";
			//currentPath=@"C:\\Program Files\\ArcGIS\\DeveloperKit\\samples\\data\\networkanalyst";
			currentPath=@"G:\\Research_Project\\C#DEMO\\CSharp\Network";
			//currentPath=@"E:\\PPT\\培训PPT\\C#DEMO\\CSharp\\Network";


			pGISHelper.loadNetworkData(currentPath,pMainFrm.getMapControl(),ref m_pNAContext,cmbCost,false);

		}

		

		private void btnGO_Click(object sender, System.EventArgs e)
		{
			int facilityCount=0,cutOffVal=0;

			if(txtFacilityCount.Text.Length>0)
				facilityCount=Convert.ToInt32(txtFacilityCount.Text);

			if(txtCutOff.Text.Length>0)
				cutOffVal=Convert.ToInt32(txtCutOff.Text);

			pGISHelper.SetSolverSettings(ref m_pNAContext,cutOffVal,facilityCount,cmbCost.Text,chkOneWay.Checked,chkHierachy.Checked);

			
			IGPMessages pGPMessages=new GPMessagesClass();

			IGPMessage pGPMessage=null;

			if(m_pNAContext.Solver.Solve(m_pNAContext, pGPMessages, null)==false){

				for(int ii=0;ii<pGPMessages.Count;ii++)
				{
					pGPMessage=pGPMessages.GetMessage(ii);
				
					MessageBox.Show(pGPMessage.Description);
				}

				pGISHelper.GetCFOutput("CFRoutes",ref m_pNAContext);

			
			}

			  
  //'Zoom to the extent of the route
        IGeoDataset pGDS;
        IEnvelope pEnv;
  
         pGDS = m_pNAContext.NAClasses.get_ItemByName("CFRoutes") as IGeoDataset;
		

         pEnv = pGDS.Extent;
			if(!pEnv.IsEmpty)
			{
				 pEnv.Expand(1.1, 1.1, true);
				 pMainFrm.getMapControl().Extent = pEnv;
			 }


			pMainFrm.getMapControl().Refresh();




		}

	}//end of the class
} //end of the namespace
