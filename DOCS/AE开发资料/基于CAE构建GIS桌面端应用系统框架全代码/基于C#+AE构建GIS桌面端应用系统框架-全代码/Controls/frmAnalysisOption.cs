using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
//using ESRI.ArcGIS.MapControl; 
using ESRI.ArcGIS.Controls;
namespace Controls
{
	/// <summary>
	/// frmAnalysisOption 的摘要说明。
	/// </summary>
	public class frmAnalysisOption : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.TabPage tabExtent;
		private System.Windows.Forms.TabPage tabCellSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox txtWorkPath;
		private System.Windows.Forms.ComboBox cmbDefaultSource;
		private System.Windows.Forms.Button btnSetWorkPath;
		private System.Windows.Forms.Button btnSetDataSource;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnOpenDataSource;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button btnOpenExtent;
		private System.Windows.Forms.ComboBox cmbAnalysisExtent;
		private System.Windows.Forms.TextBox txtExtentTop;
		private System.Windows.Forms.TextBox txtExtentLeft;
		private System.Windows.Forms.TextBox txtExtentRight;
		private System.Windows.Forms.TextBox txtExtentBottom;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnOpenCell;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtCellSize;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtRowNumber;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtNumber;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private MainFrm pMainFrm=null;
		private System.Windows.Forms.ComboBox cmbRasterCell;
		private System.Collections.Hashtable m_LayersIndex;
	 
		public frmAnalysisOption(MainFrm _pMainFrm)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAnalysisOption));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.btnSetDataSource = new System.Windows.Forms.Button();
			this.btnSetWorkPath = new System.Windows.Forms.Button();
			this.cmbDefaultSource = new System.Windows.Forms.ComboBox();
			this.txtWorkPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabExtent = new System.Windows.Forms.TabPage();
			this.btnOpenExtent = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtExtentBottom = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtExtentRight = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtExtentLeft = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtExtentTop = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnOpenDataSource = new System.Windows.Forms.Button();
			this.cmbAnalysisExtent = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabCellSize = new System.Windows.Forms.TabPage();
			this.txtNumber = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtRowNumber = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtCellSize = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.btnOpenCell = new System.Windows.Forms.Button();
			this.cmbRasterCell = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tabControl1.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabExtent.SuspendLayout();
			this.tabCellSize.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabGeneral);
			this.tabControl1.Controls.Add(this.tabExtent);
			this.tabControl1.Controls.Add(this.tabCellSize);
			this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(384, 288);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 0;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.checkBox1);
			this.tabGeneral.Controls.Add(this.groupBox1);
			this.tabGeneral.Controls.Add(this.btnSetDataSource);
			this.tabGeneral.Controls.Add(this.btnSetWorkPath);
			this.tabGeneral.Controls.Add(this.cmbDefaultSource);
			this.tabGeneral.Controls.Add(this.txtWorkPath);
			this.tabGeneral.Controls.Add(this.label2);
			this.tabGeneral.Controls.Add(this.label1);
			this.tabGeneral.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.tabGeneral.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tabGeneral.Location = new System.Drawing.Point(4, 21);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Size = new System.Drawing.Size(376, 263);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "总体";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(32, 224);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(128, 24);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "错误提示";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(32, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(312, 120);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "空间分析坐标系";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(16, 80);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(288, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "与当前视图中的栅格具有同样的空间参考坐标系";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 32);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(288, 24);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "与输入的第一个栅格数据具有同样的坐标参考系";
			// 
			// btnSetDataSource
			// 
			this.btnSetDataSource.Image = ((System.Drawing.Image)(resources.GetObject("btnSetDataSource.Image")));
			this.btnSetDataSource.Location = new System.Drawing.Point(263, 53);
			this.btnSetDataSource.Name = "btnSetDataSource";
			this.btnSetDataSource.Size = new System.Drawing.Size(32, 23);
			this.btnSetDataSource.TabIndex = 5;
			// 
			// btnSetWorkPath
			// 
			this.btnSetWorkPath.Image = ((System.Drawing.Image)(resources.GetObject("btnSetWorkPath.Image")));
			this.btnSetWorkPath.Location = new System.Drawing.Point(264, 13);
			this.btnSetWorkPath.Name = "btnSetWorkPath";
			this.btnSetWorkPath.Size = new System.Drawing.Size(32, 23);
			this.btnSetWorkPath.TabIndex = 4;
			this.btnSetWorkPath.Click += new System.EventHandler(this.btnSetWorkPath_Click);
			// 
			// cmbDefaultSource
			// 
			this.cmbDefaultSource.Location = new System.Drawing.Point(127, 54);
			this.cmbDefaultSource.Name = "cmbDefaultSource";
			this.cmbDefaultSource.Size = new System.Drawing.Size(121, 20);
			this.cmbDefaultSource.TabIndex = 3;
			// 
			// txtWorkPath
			// 
			this.txtWorkPath.Location = new System.Drawing.Point(127, 14);
			this.txtWorkPath.Name = "txtWorkPath";
			this.txtWorkPath.Size = new System.Drawing.Size(121, 21);
			this.txtWorkPath.TabIndex = 2;
			this.txtWorkPath.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "默认数据源：";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "工作目录：";
			// 
			// tabExtent
			// 
			this.tabExtent.Controls.Add(this.btnOpenExtent);
			this.tabExtent.Controls.Add(this.comboBox2);
			this.tabExtent.Controls.Add(this.label8);
			this.tabExtent.Controls.Add(this.txtExtentBottom);
			this.tabExtent.Controls.Add(this.label7);
			this.tabExtent.Controls.Add(this.txtExtentRight);
			this.tabExtent.Controls.Add(this.label6);
			this.tabExtent.Controls.Add(this.txtExtentLeft);
			this.tabExtent.Controls.Add(this.label5);
			this.tabExtent.Controls.Add(this.txtExtentTop);
			this.tabExtent.Controls.Add(this.label4);
			this.tabExtent.Controls.Add(this.btnOpenDataSource);
			this.tabExtent.Controls.Add(this.cmbAnalysisExtent);
			this.tabExtent.Controls.Add(this.label3);
			this.tabExtent.Location = new System.Drawing.Point(4, 21);
			this.tabExtent.Name = "tabExtent";
			this.tabExtent.Size = new System.Drawing.Size(376, 263);
			this.tabExtent.TabIndex = 1;
			this.tabExtent.Text = "范围";
			// 
			// btnOpenExtent
			// 
			this.btnOpenExtent.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenExtent.Image")));
			this.btnOpenExtent.Location = new System.Drawing.Point(296, 228);
			this.btnOpenExtent.Name = "btnOpenExtent";
			this.btnOpenExtent.Size = new System.Drawing.Size(32, 24);
			this.btnOpenExtent.TabIndex = 13;
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(120, 230);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(152, 20);
			this.comboBox2.TabIndex = 12;
			this.comboBox2.Text = "comboBox2";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 232);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 16);
			this.label8.TabIndex = 11;
			this.label8.Text = "捕捉范围到：";
			// 
			// txtExtentBottom
			// 
			this.txtExtentBottom.Location = new System.Drawing.Point(144, 182);
			this.txtExtentBottom.Name = "txtExtentBottom";
			this.txtExtentBottom.Size = new System.Drawing.Size(112, 21);
			this.txtExtentBottom.TabIndex = 10;
			this.txtExtentBottom.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(120, 184);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 16);
			this.label7.TabIndex = 9;
			this.label7.Text = "下";
			// 
			// txtExtentRight
			// 
			this.txtExtentRight.Location = new System.Drawing.Point(240, 128);
			this.txtExtentRight.Name = "txtExtentRight";
			this.txtExtentRight.Size = new System.Drawing.Size(112, 21);
			this.txtExtentRight.TabIndex = 8;
			this.txtExtentRight.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(216, 130);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 16);
			this.label6.TabIndex = 7;
			this.label6.Text = "右";
			// 
			// txtExtentLeft
			// 
			this.txtExtentLeft.Location = new System.Drawing.Point(56, 128);
			this.txtExtentLeft.Name = "txtExtentLeft";
			this.txtExtentLeft.Size = new System.Drawing.Size(112, 21);
			this.txtExtentLeft.TabIndex = 6;
			this.txtExtentLeft.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 130);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "左";
			// 
			// txtExtentTop
			// 
			this.txtExtentTop.Location = new System.Drawing.Point(144, 70);
			this.txtExtentTop.Name = "txtExtentTop";
			this.txtExtentTop.Size = new System.Drawing.Size(112, 21);
			this.txtExtentTop.TabIndex = 4;
			this.txtExtentTop.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(120, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "上";
			// 
			// btnOpenDataSource
			// 
			this.btnOpenDataSource.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDataSource.Image")));
			this.btnOpenDataSource.Location = new System.Drawing.Point(296, 20);
			this.btnOpenDataSource.Name = "btnOpenDataSource";
			this.btnOpenDataSource.Size = new System.Drawing.Size(32, 24);
			this.btnOpenDataSource.TabIndex = 2;
			// 
			// cmbAnalysisExtent
			// 
			this.cmbAnalysisExtent.Location = new System.Drawing.Point(120, 22);
			this.cmbAnalysisExtent.Name = "cmbAnalysisExtent";
			this.cmbAnalysisExtent.Size = new System.Drawing.Size(152, 20);
			this.cmbAnalysisExtent.TabIndex = 1;
			this.cmbAnalysisExtent.SelectedIndexChanged += new System.EventHandler(this.cmbAnalysisExtent_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "分析范围：";
			// 
			// tabCellSize
			// 
			this.tabCellSize.Controls.Add(this.txtNumber);
			this.tabCellSize.Controls.Add(this.label12);
			this.tabCellSize.Controls.Add(this.txtRowNumber);
			this.tabCellSize.Controls.Add(this.label11);
			this.tabCellSize.Controls.Add(this.txtCellSize);
			this.tabCellSize.Controls.Add(this.label10);
			this.tabCellSize.Controls.Add(this.btnOpenCell);
			this.tabCellSize.Controls.Add(this.cmbRasterCell);
			this.tabCellSize.Controls.Add(this.label9);
			this.tabCellSize.Location = new System.Drawing.Point(4, 21);
			this.tabCellSize.Name = "tabCellSize";
			this.tabCellSize.Size = new System.Drawing.Size(376, 263);
			this.tabCellSize.TabIndex = 2;
			this.tabCellSize.Text = "分辨率";
			// 
			// txtNumber
			// 
			this.txtNumber.Location = new System.Drawing.Point(136, 150);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new System.Drawing.Size(120, 21);
			this.txtNumber.TabIndex = 8;
			this.txtNumber.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(32, 152);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(88, 16);
			this.label12.TabIndex = 7;
			this.label12.Text = "数量：";
			// 
			// txtRowNumber
			// 
			this.txtRowNumber.Location = new System.Drawing.Point(136, 110);
			this.txtRowNumber.Name = "txtRowNumber";
			this.txtRowNumber.Size = new System.Drawing.Size(120, 21);
			this.txtRowNumber.TabIndex = 6;
			this.txtRowNumber.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(32, 112);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 16);
			this.label11.TabIndex = 5;
			this.label11.Text = "行数：";
			// 
			// txtCellSize
			// 
			this.txtCellSize.Location = new System.Drawing.Point(136, 70);
			this.txtCellSize.Name = "txtCellSize";
			this.txtCellSize.Size = new System.Drawing.Size(120, 21);
			this.txtCellSize.TabIndex = 4;
			this.txtCellSize.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(32, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 16);
			this.label10.TabIndex = 3;
			this.label10.Text = "大小：";
			// 
			// btnOpenCell
			// 
			this.btnOpenCell.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenCell.Image")));
			this.btnOpenCell.Location = new System.Drawing.Point(272, 28);
			this.btnOpenCell.Name = "btnOpenCell";
			this.btnOpenCell.Size = new System.Drawing.Size(32, 24);
			this.btnOpenCell.TabIndex = 2;
			// 
			// cmbRasterCell
			// 
			this.cmbRasterCell.Location = new System.Drawing.Point(136, 30);
			this.cmbRasterCell.Name = "cmbRasterCell";
			this.cmbRasterCell.Size = new System.Drawing.Size(120, 20);
			this.cmbRasterCell.TabIndex = 1;
			this.cmbRasterCell.SelectedIndexChanged += new System.EventHandler(this.cmbRasterCell_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(32, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 16);
			this.label9.TabIndex = 0;
			this.label9.Text = "分析分辨率：";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(184, 304);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "确定";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(288, 304);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmAnalysisOption
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(384, 342);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAnalysisOption";
			this.Text = "空间分析参数设置";
			this.Load += new System.EventHandler(this.frmAnalysisOption_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabExtent.ResumeLayout(false);
			this.tabCellSize.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			pMainFrm.SAoption.RasterCellSize=Convert.ToDouble(txtCellSize.Text);
			pMainFrm.SAoption.AnalysisExtentLeft=Convert.ToDouble(txtExtentLeft.Text);
			pMainFrm.SAoption.AnalysisExtentRight=Convert.ToDouble(txtExtentRight.Text);
			pMainFrm.SAoption.AnalysisExtentBottom=Convert.ToDouble(txtExtentBottom.Text);
			pMainFrm.SAoption.AnalysisExtentTop=Convert.ToDouble(txtExtentTop.Text);
  
		}

		private void btnSetWorkPath_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog1=new FolderBrowserDialog();
			folderBrowserDialog1.Description="设置默认的空间分析结果输出保存路径";
			folderBrowserDialog1.ShowNewFolderButton=true;
			if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
			{
				txtWorkPath.Text=folderBrowserDialog1.SelectedPath;
			}
		}

		private void frmAnalysisOption_Load(object sender, System.EventArgs e)
		{
			m_LayersIndex = new Hashtable();
			PopulateComboWithMapLayers(cmbDefaultSource,m_LayersIndex);	
			PopulateComboWithMapLayers(cmbAnalysisExtent,m_LayersIndex);	
			PopulateComboWithMapLayers(cmbRasterCell,m_LayersIndex);
			
			txtWorkPath.Text=pMainFrm.SAoption.AnalysisPath;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		private void PopulateComboWithMapLayers(ComboBox Layers, System.Collections.Hashtable LayersIndex)
		{
			Layers.Items.Clear();
			LayersIndex.Clear();

			ILayer aLayer;
			AxMapControl axMap=pMainFrm.getMapControl();
			for (int i=0; i <= axMap.LayerCount-1; i++)
			{
				// Get the layer name and add to combo
				aLayer = axMap.get_Layer(i);
				if (aLayer.Valid == true)
				{						 
						Layers.Items.Add(aLayer.Name);
						LayersIndex.Add(Layers.Items.Count-1,aLayer);					 
				}
			}
		}

		private void cmbAnalysisExtent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ILayer pLyr;
			IEnvelope pEnv;
			AxMapControl axMap=pMainFrm.getMapControl();
			for (int i=0; i <= axMap.LayerCount-1; i++)
			{
				pLyr = axMap.get_Layer(i);
				if(pLyr.Name==cmbAnalysisExtent.SelectedItem.ToString())
				{
					
					if (pLyr.Valid == true)
					{						 
						pEnv=pLyr.AreaOfInterest;		
						txtExtentLeft.Text=pEnv.XMin.ToString();
						txtExtentRight.Text=pEnv.XMax.ToString();
						txtExtentTop.Text=pEnv.YMax.ToString();
						txtExtentBottom.Text=pEnv.YMin.ToString();
					}
				}
			}
			 
		}
		//获得栅格象素分辨率大小
		private double GetRasterCellSize(string LayerName)
		{ 			
			double dCellSize=0;
			AxMapControl axMap=pMainFrm.getMapControl();
			for (int i=0; i <= axMap.LayerCount-1; i++)
			{
				ILayer pLyr=axMap.get_Layer(i);
				if(pLyr!=null)
				{
					if(pLyr is IRasterLayer)
					{
						if(pLyr.Name==LayerName)
						{
							IRasterLayer pRlyr=pLyr as IRasterLayer ;
							IRaster pRaster=pRlyr.Raster;
							IRasterProps pRasterProp=pRaster as IRasterProps ;
							dCellSize=(pRasterProp.MeanCellSize().X+pRasterProp.MeanCellSize().Y)/2;	
						}
					}
				}				
			}
			return dCellSize;
			
		}

		private void cmbRasterCell_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtCellSize.Text=GetRasterCellSize(cmbRasterCell.SelectedItem.ToString()).ToString();
		}

		 
	}
}
