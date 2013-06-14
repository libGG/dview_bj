using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.GeoAnalyst;
namespace Controls
{
	/// <summary>
	/// frmRasterIDW 的摘要说明。
	/// </summary>
	public class frmRasterIDW : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBoxVariable;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox comboBoxInPoint;
		private System.Windows.Forms.Button btnOpenSourceData;
		private System.Windows.Forms.ComboBox comboBoxZValueField;
		private System.Windows.Forms.TextBox txtWeightValue;
		private System.Windows.Forms.ComboBox comboBoxSearchRadius;
		private System.Windows.Forms.TextBox txtPointNumbers;
		private System.Windows.Forms.TextBox txtDisMaxValue;
		private System.Windows.Forms.CheckBox chkBarrier;
		private System.Windows.Forms.ComboBox comboBoxBarrier;
		private System.Windows.Forms.Button btnOpenBarrier;
		private System.Windows.Forms.TextBox txtCellSize;
		private System.Windows.Forms.TextBox txtOutputRasterPath;
		private System.Windows.Forms.Button btnSaveRasterPath;
		private System.Windows.Forms.Button btnGO;
		private System.Windows.Forms.Button btnCancel;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
		private MainFrm pMainFrm=null;
        private GroupBox groupBoxFixed;
        private TextBox txtDisValue;
        private Label label10;
        private Label label9;
        private TextBox txtMaxPointNums;
        private bool bDataPath;//判断是否通过打开对话框选择点特征类
        private bool bDataLinePath;//判断是否通过打开对话框选择线障碍特征类
		public frmRasterIDW(MainFrm _pMainFrm)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRasterIDW));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxInPoint = new System.Windows.Forms.ComboBox();
            this.btnOpenSourceData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxZValueField = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWeightValue = new System.Windows.Forms.TextBox();
            this.groupBoxVariable = new System.Windows.Forms.GroupBox();
            this.txtDisMaxValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPointNumbers = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSearchRadius = new System.Windows.Forms.ComboBox();
            this.chkBarrier = new System.Windows.Forms.CheckBox();
            this.comboBoxBarrier = new System.Windows.Forms.ComboBox();
            this.btnOpenBarrier = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCellSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOutputRasterPath = new System.Windows.Forms.TextBox();
            this.btnSaveRasterPath = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxFixed = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisValue = new System.Windows.Forms.TextBox();
            this.txtMaxPointNums = new System.Windows.Forms.TextBox();
            this.groupBoxVariable.SuspendLayout();
            this.groupBoxFixed.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入点数据：";
            // 
            // comboBoxInPoint
            // 
            this.comboBoxInPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInPoint.Location = new System.Drawing.Point(128, 14);
            this.comboBoxInPoint.Name = "comboBoxInPoint";
            this.comboBoxInPoint.Size = new System.Drawing.Size(144, 20);
            this.comboBoxInPoint.TabIndex = 1;
            this.comboBoxInPoint.SelectedIndexChanged += new System.EventHandler(this.comboBoxInPoint_SelectedIndexChanged);
            // 
            // btnOpenSourceData
            // 
            this.btnOpenSourceData.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSourceData.Image")));
            this.btnOpenSourceData.Location = new System.Drawing.Point(296, 12);
            this.btnOpenSourceData.Name = "btnOpenSourceData";
            this.btnOpenSourceData.Size = new System.Drawing.Size(24, 24);
            this.btnOpenSourceData.TabIndex = 2;
            this.btnOpenSourceData.Click += new System.EventHandler(this.btnOpenSourceData_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Z值字段：";
            // 
            // comboBoxZValueField
            // 
            this.comboBoxZValueField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZValueField.Location = new System.Drawing.Point(128, 42);
            this.comboBoxZValueField.Name = "comboBoxZValueField";
            this.comboBoxZValueField.Size = new System.Drawing.Size(144, 20);
            this.comboBoxZValueField.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "权重值：";
            // 
            // txtWeightValue
            // 
            this.txtWeightValue.Location = new System.Drawing.Point(128, 70);
            this.txtWeightValue.Name = "txtWeightValue";
            this.txtWeightValue.Size = new System.Drawing.Size(144, 21);
            this.txtWeightValue.TabIndex = 6;
            // 
            // groupBoxVariable
            // 
            this.groupBoxVariable.Controls.Add(this.txtDisMaxValue);
            this.groupBoxVariable.Controls.Add(this.label6);
            this.groupBoxVariable.Controls.Add(this.txtPointNumbers);
            this.groupBoxVariable.Controls.Add(this.label4);
            this.groupBoxVariable.Location = new System.Drawing.Point(24, 128);
            this.groupBoxVariable.Name = "groupBoxVariable";
            this.groupBoxVariable.Size = new System.Drawing.Size(296, 96);
            this.groupBoxVariable.TabIndex = 7;
            this.groupBoxVariable.TabStop = false;
            this.groupBoxVariable.Text = "搜索半径设置";
            // 
            // txtDisMaxValue
            // 
            this.txtDisMaxValue.Location = new System.Drawing.Point(104, 46);
            this.txtDisMaxValue.Name = "txtDisMaxValue";
            this.txtDisMaxValue.Size = new System.Drawing.Size(144, 21);
            this.txtDisMaxValue.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "距离极值：";
            // 
            // txtPointNumbers
            // 
            this.txtPointNumbers.Location = new System.Drawing.Point(104, 22);
            this.txtPointNumbers.Name = "txtPointNumbers";
            this.txtPointNumbers.Size = new System.Drawing.Size(144, 21);
            this.txtPointNumbers.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "点数：";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "搜索半径类型：";
            // 
            // comboBoxSearchRadius
            // 
            this.comboBoxSearchRadius.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchRadius.Location = new System.Drawing.Point(128, 98);
            this.comboBoxSearchRadius.Name = "comboBoxSearchRadius";
            this.comboBoxSearchRadius.Size = new System.Drawing.Size(144, 20);
            this.comboBoxSearchRadius.TabIndex = 9;
            this.comboBoxSearchRadius.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchRadius_SelectedIndexChanged);
            // 
            // chkBarrier
            // 
            this.chkBarrier.Location = new System.Drawing.Point(24, 236);
            this.chkBarrier.Name = "chkBarrier";
            this.chkBarrier.Size = new System.Drawing.Size(128, 16);
            this.chkBarrier.TabIndex = 10;
            this.chkBarrier.Text = "是否使用障碍线：";
            this.chkBarrier.CheckedChanged += new System.EventHandler(this.chkBarrier_CheckedChanged);
            // 
            // comboBoxBarrier
            // 
            this.comboBoxBarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBarrier.Location = new System.Drawing.Point(144, 234);
            this.comboBoxBarrier.Name = "comboBoxBarrier";
            this.comboBoxBarrier.Size = new System.Drawing.Size(128, 20);
            this.comboBoxBarrier.TabIndex = 11;
            // 
            // btnOpenBarrier
            // 
            this.btnOpenBarrier.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenBarrier.Image")));
            this.btnOpenBarrier.Location = new System.Drawing.Point(296, 232);
            this.btnOpenBarrier.Name = "btnOpenBarrier";
            this.btnOpenBarrier.Size = new System.Drawing.Size(24, 24);
            this.btnOpenBarrier.TabIndex = 12;
            this.btnOpenBarrier.Click += new System.EventHandler(this.btnOpenBarrier_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "象素大小：";
            // 
            // txtCellSize
            // 
            this.txtCellSize.Location = new System.Drawing.Point(128, 262);
            this.txtCellSize.Name = "txtCellSize";
            this.txtCellSize.Size = new System.Drawing.Size(144, 21);
            this.txtCellSize.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(24, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "输出栅格位置：";
            // 
            // txtOutputRasterPath
            // 
            this.txtOutputRasterPath.Location = new System.Drawing.Point(128, 290);
            this.txtOutputRasterPath.Name = "txtOutputRasterPath";
            this.txtOutputRasterPath.Size = new System.Drawing.Size(144, 21);
            this.txtOutputRasterPath.TabIndex = 16;
            // 
            // btnSaveRasterPath
            // 
            this.btnSaveRasterPath.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRasterPath.Image")));
            this.btnSaveRasterPath.Location = new System.Drawing.Point(296, 288);
            this.btnSaveRasterPath.Name = "btnSaveRasterPath";
            this.btnSaveRasterPath.Size = new System.Drawing.Size(24, 24);
            this.btnSaveRasterPath.TabIndex = 17;
            this.btnSaveRasterPath.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSaveRasterPath.Click += new System.EventHandler(this.btnSaveRasterPath_Click);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(120, 328);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(88, 24);
            this.btnGO.TabIndex = 18;
            this.btnGO.Text = "GO!";
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Destroy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBoxFixed
            // 
            this.groupBoxFixed.Controls.Add(this.txtMaxPointNums);
            this.groupBoxFixed.Controls.Add(this.txtDisValue);
            this.groupBoxFixed.Controls.Add(this.label10);
            this.groupBoxFixed.Controls.Add(this.label9);
            this.groupBoxFixed.Location = new System.Drawing.Point(24, 128);
            this.groupBoxFixed.Name = "groupBoxFixed";
            this.groupBoxFixed.Size = new System.Drawing.Size(296, 96);
            this.groupBoxFixed.TabIndex = 20;
            this.groupBoxFixed.TabStop = false;
            this.groupBoxFixed.Text = "搜索半径设置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "距离：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "最大点数：";
            // 
            // txtDisValue
            // 
            this.txtDisValue.Location = new System.Drawing.Point(109, 18);
            this.txtDisValue.Name = "txtDisValue";
            this.txtDisValue.Size = new System.Drawing.Size(144, 21);
            this.txtDisValue.TabIndex = 2;
            // 
            // txtMaxPointNums
            // 
            this.txtMaxPointNums.Location = new System.Drawing.Point(110, 42);
            this.txtMaxPointNums.Name = "txtMaxPointNums";
            this.txtMaxPointNums.Size = new System.Drawing.Size(144, 21);
            this.txtMaxPointNums.TabIndex = 3;
            // 
            // frmRasterIDW
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(343, 358);
            this.Controls.Add(this.groupBoxFixed);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnSaveRasterPath);
            this.Controls.Add(this.txtOutputRasterPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCellSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnOpenBarrier);
            this.Controls.Add(this.comboBoxBarrier);
            this.Controls.Add(this.chkBarrier);
            this.Controls.Add(this.comboBoxSearchRadius);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBoxVariable);
            this.Controls.Add(this.txtWeightValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxZValueField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenSourceData);
            this.Controls.Add(this.comboBoxInPoint);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRasterIDW";
            this.Text = "反距离权重插值";
            this.Load += new System.EventHandler(this.frmRasterIDW_Load);
            this.groupBoxVariable.ResumeLayout(false);
            this.groupBoxVariable.PerformLayout();
            this.groupBoxFixed.ResumeLayout(false);
            this.groupBoxFixed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void btnOpenSourceData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBoxInPoint.Text = openFileDialog1.FileName;
            }
            bDataPath = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOpenBarrier_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBoxBarrier.Text = openFileDialog1.FileName;
            }
            bDataLinePath=true;
        }

        private void btnSaveRasterPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
            saveFileDialog1.Filter = "Grid Files (*.Grid)|*.Grid|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutputRasterPath.Text = saveFileDialog1.FileName;
            } 
        }

        private void comboBoxInPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sLayerName = comboBoxInPoint.Text;
            AxMapControl axMap = pMainFrm.getMapControl();
            IFeatureLayer pFeatLyr = null;

            comboBoxZValueField.Items.Clear();
            comboBoxZValueField.Items.Add("无");
            try
            {
                for (int i = 0; i <= axMap.LayerCount - 1; i++)
                {
                    ILayer pLyr = axMap.get_Layer(i);
                    if (pLyr.Name == sLayerName)
                    {
                        if (pLyr is IFeatureLayer)
                        {
                            pFeatLyr = pLyr as IFeatureLayer;
                            IFeatureClass m_pFeatCls = pFeatLyr.FeatureClass;
                            for (int j = 0; j <= m_pFeatCls.Fields.FieldCount - 1; j++)
                            {
                                if(m_pFeatCls.Fields.get_Field(j).Type==esriFieldType.esriFieldTypeDouble||
                                  m_pFeatCls.Fields.get_Field(j).Type == esriFieldType.esriFieldTypeSingle)
                                comboBoxZValueField.Items.Add(m_pFeatCls.Fields.get_Field(j).Name);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void PopulateComboWithMapLayers(ComboBox Layers, bool bLayer,bool bType)
        {
            Layers.Items.Clear();
            ILayer aLayer;
            AxMapControl axMap = pMainFrm.getMapControl();
            for (int i = 0; i <= axMap.LayerCount - 1; i++)
            {
                // Get the layer name and add to combo
                aLayer = axMap.get_Layer(i);
                if (aLayer.Valid == true)
                {
                    if (bLayer == true)
                    {
                        if (aLayer is IFeatureLayer)
                        {
                            IFeatureLayer pFeatLayer = aLayer as IFeatureLayer;
                            if (bType == false)
                            {
                                if (pFeatLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                                    Layers.Items.Add(aLayer.Name);
                            }
                            else
                            {
                                if (pFeatLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                                    Layers.Items.Add(aLayer.Name);
                            }

                            
                        }
                    }

                }
            }
        }

        private void frmRasterIDW_Load(object sender, EventArgs e)
        {

            PopulateComboWithMapLayers(comboBoxInPoint, true,false );
            PopulateComboWithMapLayers(comboBoxBarrier, true,true );
            comboBoxInPoint.Text = pMainFrm.SAoption.AnalysisPath;
            txtOutputRasterPath.Text = pMainFrm.SAoption.AnalysisPath;
            txtCellSize.Text = pMainFrm.SAoption.RasterCellSize.ToString();
            comboBoxSearchRadius.Items.Add("固定");
            comboBoxSearchRadius.Items.Add("变化");
            comboBoxSearchRadius.Text = "变化";
            groupBoxVariable.Visible = true;
            groupBoxFixed.Visible = false;
            comboBoxBarrier.Enabled = false;
            btnOpenBarrier.Enabled = false;
            comboBoxZValueField.Text = "无";

        }

        private void comboBoxSearchRadius_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sRadiusType = comboBoxSearchRadius.Text;
            if (sRadiusType == "变化")
            {
                groupBoxVariable.Visible = true;
                groupBoxFixed.Visible = false;
            }
            else
            {
                groupBoxVariable.Visible = false;
                groupBoxFixed.Visible = true;
            }
        }

        private void chkBarrier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBarrier.Checked == true)
            {
                comboBoxBarrier.Enabled = true;
                btnOpenBarrier.Enabled = true;
            }
            else
            {
                comboBoxBarrier.Enabled = false;
                btnOpenBarrier.Enabled = false;
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            IFeatureClass pInPointFClass = null;//获得输入点特征数据类
            IFeatureClass pLineBarrierFClass = null;//获得输入的线障碍类
            IWorkspace pWorkspace;
            
            string fileName;
            string rasterPath;
            string shpFile;
            int startX, endX;
            string sFieldName;//选择要进行分析的字段
            if (bDataPath == true)
            {
                fileName = comboBoxInPoint.Text;
                string shpDir = fileName.Substring(0, fileName.LastIndexOf("\\"));
                startX = fileName.LastIndexOf("\\");
                endX = fileName.Length;
                shpFile = fileName.Substring(startX + 1, endX - startX - 1);
                pInPointFClass = Utility.OpenFeatureClassFromShapefile(shpDir, shpFile);
            }
            else
            {
                pInPointFClass = GetFeatureFromMapLyr(comboBoxInPoint.Text);
            }
            if (bDataLinePath == true)
            {
                fileName = comboBoxBarrier.Text;
                string shpDir = fileName.Substring(0, fileName.LastIndexOf("\\"));
                startX = fileName.LastIndexOf("\\");
                endX = fileName.Length;
                shpFile = fileName.Substring(startX + 1, endX - startX - 1);
                pLineBarrierFClass = Utility.OpenFeatureClassFromShapefile(shpDir, shpFile);
            }
            else
            {
                pLineBarrierFClass = GetFeatureFromMapLyr(comboBoxBarrier.Text);
            }
            IFeatureLayer pFeatLayer = new FeatureLayerClass();
            pFeatLayer.FeatureClass = pInPointFClass;
            rasterPath = txtOutputRasterPath.Text;
            IFeatureClassDescriptor pFeatClsDes = new FeatureClassDescriptorClass();
            if (comboBoxZValueField.Text != "无")
                pFeatClsDes.Create(pInPointFClass, null, comboBoxZValueField.Text);
            else
                pFeatClsDes.Create(pInPointFClass, null, "");
            try
            {
                IInterpolationOp pInterpolationOp = new RasterInterpolationOpClass();
                string sCellSize = txtCellSize.Text;
                double dCellSize = Convert.ToDouble(sCellSize);
                IRasterRadius pRsRadius = new RasterRadiusClass();
                string sPower=txtWeightValue.Text;
                double dPower=Convert.ToDouble(sPower);
                if(comboBoxSearchRadius.Text == "变化")
                {
                    string sPointNums=txtPointNumbers.Text;
                    int iPointNums=Convert.ToInt32(sPointNums);
                    double maxDis=Convert.ToDouble(txtDisMaxValue.Text);
                    object objMaxDis=maxDis;
                    pRsRadius.SetVariable(iPointNums,ref objMaxDis);
                }
                else
                {
                    string sDistance=txtDisValue.Text;
                    double dDistance=Convert.ToDouble(sDistance);
                    double maxPointNums=Convert.ToDouble(txtMaxPointNums.Text);
                    object objMinPointNums=maxPointNums;
                    pRsRadius.SetFixed(dDistance,ref objMinPointNums);
                }

                pInterpolationOp = Utility.SetRasterInterpolationAnalysisEnv(rasterPath, dCellSize, pFeatLayer);
                object objLineBarrier=null;
                if (chkBarrier.Checked == true)
                {
                    objLineBarrier=comboBoxBarrier;
                }
                else
                {
                    objLineBarrier = Type.Missing;
                }
                IRaster pOutRaster = null;
                pOutRaster = pInterpolationOp.IDW(pFeatClsDes as IGeoDataset, dPower, pRsRadius, ref objLineBarrier) as IRaster;
                
                //着色                
                IRasterLayer pRasterLayer = new RasterLayerClass();
                pRasterLayer.Name = "反距离栅格";
                Utility.ConvertRasterToRsDataset(rasterPath, pOutRaster, "反距离栅格");
                pRasterLayer = Utility.SetRsLayerClassifiedColor(pOutRaster);
                pMainFrm.getMapControl().AddLayer(pRasterLayer, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        //从地图图层中获得特征类数据图层
        private IFeatureClass GetFeatureFromMapLyr(string sLyrName)
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            IFeatureClass pFeatCls = null;

            for (int i = 0; i <= axMap.LayerCount - 1; i++)
            {
                ILayer pLyr = axMap.get_Layer(i);
                if (pLyr != null)
                {
                    if (pLyr.Name == sLyrName)
                    {
                        if (pLyr is IFeatureLayer)
                        {
                            IFeatureLayer pFLyr = pLyr as IFeatureLayer;
                            pFeatCls = pFLyr.FeatureClass;
                        }
                    }
                }
            }
            return pFeatCls;
        }

	}

}
