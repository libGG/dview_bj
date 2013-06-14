using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controls
{
	/// <summary>
	/// frmShortestPath 的摘要说明。
	/// </summary>
	public class frmShortestPath : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnGO;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox comboBoxSourceData;
		private System.Windows.Forms.Button btnOpenSourceData;
		private System.Windows.Forms.ComboBox comboBoxCostDisRs;
		private System.Windows.Forms.Button btnOpenCostDis;
		private System.Windows.Forms.ComboBox comboBoxCostDirRs;
		private System.Windows.Forms.Button btnOpenCostDir;
		private System.Windows.Forms.ComboBox comboBoxPathType;
		private System.Windows.Forms.TextBox txtSavePath;
		private System.Windows.Forms.Button btnSave;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
 private MainFrm pMainFrm=null;
		public frmShortestPath(MainFrm _pMainFrm)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			pMainFrm=_pMainFrm;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShortestPath));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSourceData = new System.Windows.Forms.ComboBox();
            this.btnOpenSourceData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCostDisRs = new System.Windows.Forms.ComboBox();
            this.btnOpenCostDis = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCostDirRs = new System.Windows.Forms.ComboBox();
            this.btnOpenCostDir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPathType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "最短路径到：";
            // 
            // comboBoxSourceData
            // 
            this.comboBoxSourceData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSourceData.Location = new System.Drawing.Point(104, 14);
            this.comboBoxSourceData.Name = "comboBoxSourceData";
            this.comboBoxSourceData.Size = new System.Drawing.Size(136, 20);
            this.comboBoxSourceData.TabIndex = 1;
            // 
            // btnOpenSourceData
            // 
            this.btnOpenSourceData.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSourceData.Image")));
            this.btnOpenSourceData.Location = new System.Drawing.Point(256, 12);
            this.btnOpenSourceData.Name = "btnOpenSourceData";
            this.btnOpenSourceData.Size = new System.Drawing.Size(32, 24);
            this.btnOpenSourceData.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "费用距离栅格：";
            // 
            // comboBoxCostDisRs
            // 
            this.comboBoxCostDisRs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCostDisRs.Location = new System.Drawing.Point(104, 46);
            this.comboBoxCostDisRs.Name = "comboBoxCostDisRs";
            this.comboBoxCostDisRs.Size = new System.Drawing.Size(136, 20);
            this.comboBoxCostDisRs.TabIndex = 4;
            // 
            // btnOpenCostDis
            // 
            this.btnOpenCostDis.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenCostDis.Image")));
            this.btnOpenCostDis.Location = new System.Drawing.Point(256, 44);
            this.btnOpenCostDis.Name = "btnOpenCostDis";
            this.btnOpenCostDis.Size = new System.Drawing.Size(32, 24);
            this.btnOpenCostDis.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "费用方向栅格：";
            // 
            // comboBoxCostDirRs
            // 
            this.comboBoxCostDirRs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCostDirRs.Location = new System.Drawing.Point(104, 78);
            this.comboBoxCostDirRs.Name = "comboBoxCostDirRs";
            this.comboBoxCostDirRs.Size = new System.Drawing.Size(136, 20);
            this.comboBoxCostDirRs.TabIndex = 7;
            // 
            // btnOpenCostDir
            // 
            this.btnOpenCostDir.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenCostDir.Image")));
            this.btnOpenCostDir.Location = new System.Drawing.Point(256, 76);
            this.btnOpenCostDir.Name = "btnOpenCostDir";
            this.btnOpenCostDir.Size = new System.Drawing.Size(32, 24);
            this.btnOpenCostDir.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "道路类型：";
            // 
            // comboBoxPathType
            // 
            this.comboBoxPathType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPathType.Location = new System.Drawing.Point(104, 110);
            this.comboBoxPathType.Name = "comboBoxPathType";
            this.comboBoxPathType.Size = new System.Drawing.Size(136, 20);
            this.comboBoxPathType.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "输出特征类：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(104, 142);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(136, 21);
            this.txtSavePath.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(256, 140);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 24);
            this.btnSave.TabIndex = 13;
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(120, 184);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(72, 24);
            this.btnGO.TabIndex = 14;
            this.btnGO.Text = "GO！";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(208, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Destroy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmShortestPath
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(304, 222);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxPathType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpenCostDir);
            this.Controls.Add(this.comboBoxCostDirRs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOpenCostDis);
            this.Controls.Add(this.comboBoxCostDisRs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenSourceData);
            this.Controls.Add(this.comboBoxSourceData);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShortestPath";
            this.Text = "最短路径计算";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
	}
}
