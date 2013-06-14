using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controls
{
	/// <summary>
	/// frmRasterSpline 的摘要说明。
	/// </summary>
	public class frmRasterSpline : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxInputData;
		private System.Windows.Forms.Button btnOpenSourceData;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxZValueField;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxSplineType;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtWeightValue;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPointNum;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtCellSize;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtOutputPath;
		private System.Windows.Forms.Button btnSaveRasterPath;
		private System.Windows.Forms.Button btnGO;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private MainFrm pMainFrm=null;
		public frmRasterSpline(MainFrm _pMainFrm)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRasterSpline));
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxInputData = new System.Windows.Forms.ComboBox();
			this.btnOpenSourceData = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxZValueField = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxSplineType = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtWeightValue = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPointNum = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCellSize = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtOutputPath = new System.Windows.Forms.TextBox();
			this.btnSaveRasterPath = new System.Windows.Forms.Button();
			this.btnGO = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "输入点数据：";
			// 
			// comboBoxInputData
			// 
			this.comboBoxInputData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxInputData.Location = new System.Drawing.Point(112, 14);
			this.comboBoxInputData.Name = "comboBoxInputData";
			this.comboBoxInputData.Size = new System.Drawing.Size(120, 20);
			this.comboBoxInputData.TabIndex = 1;
			// 
			// btnOpenSourceData
			// 
			this.btnOpenSourceData.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSourceData.Image")));
			this.btnOpenSourceData.Location = new System.Drawing.Point(248, 12);
			this.btnOpenSourceData.Name = "btnOpenSourceData";
			this.btnOpenSourceData.Size = new System.Drawing.Size(24, 24);
			this.btnOpenSourceData.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Z值字段：";
			// 
			// comboBoxZValueField
			// 
			this.comboBoxZValueField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxZValueField.Location = new System.Drawing.Point(112, 44);
			this.comboBoxZValueField.Name = "comboBoxZValueField";
			this.comboBoxZValueField.Size = new System.Drawing.Size(120, 20);
			this.comboBoxZValueField.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "样条类型：";
			// 
			// comboBoxSplineType
			// 
			this.comboBoxSplineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSplineType.Location = new System.Drawing.Point(112, 74);
			this.comboBoxSplineType.Name = "comboBoxSplineType";
			this.comboBoxSplineType.Size = new System.Drawing.Size(120, 20);
			this.comboBoxSplineType.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "权重：";
			// 
			// txtWeightValue
			// 
			this.txtWeightValue.Location = new System.Drawing.Point(112, 104);
			this.txtWeightValue.Name = "txtWeightValue";
			this.txtWeightValue.Size = new System.Drawing.Size(120, 21);
			this.txtWeightValue.TabIndex = 8;
			this.txtWeightValue.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "点数：";
			// 
			// txtPointNum
			// 
			this.txtPointNum.Location = new System.Drawing.Point(112, 134);
			this.txtPointNum.Name = "txtPointNum";
			this.txtPointNum.Size = new System.Drawing.Size(120, 21);
			this.txtPointNum.TabIndex = 10;
			this.txtPointNum.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 166);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "象素大小：";
			// 
			// txtCellSize
			// 
			this.txtCellSize.Location = new System.Drawing.Point(112, 164);
			this.txtCellSize.Name = "txtCellSize";
			this.txtCellSize.Size = new System.Drawing.Size(120, 21);
			this.txtCellSize.TabIndex = 12;
			this.txtCellSize.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 196);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "输出栅格位置：";
			// 
			// txtOutputPath
			// 
			this.txtOutputPath.Location = new System.Drawing.Point(112, 194);
			this.txtOutputPath.Name = "txtOutputPath";
			this.txtOutputPath.Size = new System.Drawing.Size(120, 21);
			this.txtOutputPath.TabIndex = 14;
			this.txtOutputPath.Text = "";
			// 
			// btnSaveRasterPath
			// 
			this.btnSaveRasterPath.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRasterPath.Image")));
			this.btnSaveRasterPath.Location = new System.Drawing.Point(248, 192);
			this.btnSaveRasterPath.Name = "btnSaveRasterPath";
			this.btnSaveRasterPath.Size = new System.Drawing.Size(24, 24);
			this.btnSaveRasterPath.TabIndex = 15;
			// 
			// btnGO
			// 
			this.btnGO.Location = new System.Drawing.Point(96, 232);
			this.btnGO.Name = "btnGO";
			this.btnGO.Size = new System.Drawing.Size(80, 24);
			this.btnGO.TabIndex = 16;
			this.btnGO.Text = "GO!";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(192, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "Destroy";
			// 
			// frmRasterSpline
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnGO);
			this.Controls.Add(this.btnSaveRasterPath);
			this.Controls.Add(this.txtOutputPath);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtCellSize);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtPointNum);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtWeightValue);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBoxSplineType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBoxZValueField);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOpenSourceData);
			this.Controls.Add(this.comboBoxInputData);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRasterSpline";
			this.Text = "样条插值";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
