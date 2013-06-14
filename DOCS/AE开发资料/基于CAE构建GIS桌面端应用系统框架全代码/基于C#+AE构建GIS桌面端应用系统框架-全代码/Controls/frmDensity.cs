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
using ESRI.ArcGIS.Controls; 
namespace Controls
{
	/// <summary>
	/// frmDensity 的摘要说明。
	/// </summary>
	public class frmDensity : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnOpenSourceData;
		private System.Windows.Forms.Button btnSaveRaster;
		private System.Windows.Forms.Button btnGO;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton rdoKernel;
		private System.Windows.Forms.RadioButton rdoSimple;
		private System.Windows.Forms.ComboBox comboBoxInData;
		private System.Windows.Forms.ComboBox comboBoxField;
		private System.Windows.Forms.TextBox txtSearchRadius;
		private System.Windows.Forms.ComboBox comboBoxAreaUnit;
		private System.Windows.Forms.TextBox txtCellSize;
		private System.Windows.Forms.TextBox txtRasterPath;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private MainFrm pMainFrm=null;
		private bool bDataPath;
		public frmDensity(MainFrm _pMainFrm)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDensity));
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxInData = new System.Windows.Forms.ComboBox();
			this.btnOpenSourceData = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxField = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.rdoKernel = new System.Windows.Forms.RadioButton();
			this.rdoSimple = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSearchRadius = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBoxAreaUnit = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCellSize = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtRasterPath = new System.Windows.Forms.TextBox();
			this.btnSaveRaster = new System.Windows.Forms.Button();
			this.btnGO = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "输入数据：";
			// 
			// comboBoxInData
			// 
			this.comboBoxInData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxInData.Location = new System.Drawing.Point(112, 6);
			this.comboBoxInData.Name = "comboBoxInData";
			this.comboBoxInData.Size = new System.Drawing.Size(144, 20);
			this.comboBoxInData.TabIndex = 1;
			this.comboBoxInData.SelectedIndexChanged += new System.EventHandler(this.comboBoxInData_SelectedIndexChanged);
			// 
			// btnOpenSourceData
			// 
			this.btnOpenSourceData.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSourceData.Image")));
			this.btnOpenSourceData.Location = new System.Drawing.Point(272, 4);
			this.btnOpenSourceData.Name = "btnOpenSourceData";
			this.btnOpenSourceData.Size = new System.Drawing.Size(24, 24);
			this.btnOpenSourceData.TabIndex = 2;
			this.btnOpenSourceData.Click += new System.EventHandler(this.btnOpenSourceData_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "人口字段：";
			// 
			// comboBoxField
			// 
			this.comboBoxField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxField.Location = new System.Drawing.Point(112, 38);
			this.comboBoxField.Name = "comboBoxField";
			this.comboBoxField.Size = new System.Drawing.Size(144, 20);
			this.comboBoxField.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "密度计算类型：";
			// 
			// rdoKernel
			// 
			this.rdoKernel.Checked = true;
			this.rdoKernel.Location = new System.Drawing.Point(112, 72);
			this.rdoKernel.Name = "rdoKernel";
			this.rdoKernel.Size = new System.Drawing.Size(72, 16);
			this.rdoKernel.TabIndex = 6;
			this.rdoKernel.TabStop = true;
			this.rdoKernel.Text = "Kernel";
			// 
			// rdoSimple
			// 
			this.rdoSimple.Location = new System.Drawing.Point(192, 72);
			this.rdoSimple.Name = "rdoSimple";
			this.rdoSimple.Size = new System.Drawing.Size(88, 16);
			this.rdoSimple.TabIndex = 7;
			this.rdoSimple.Text = "Simple";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "搜索半径";
			// 
			// txtSearchRadius
			// 
			this.txtSearchRadius.Location = new System.Drawing.Point(112, 102);
			this.txtSearchRadius.Name = "txtSearchRadius";
			this.txtSearchRadius.Size = new System.Drawing.Size(144, 21);
			this.txtSearchRadius.TabIndex = 9;
			this.txtSearchRadius.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "面积单位：";
			// 
			// comboBoxAreaUnit
			// 
			this.comboBoxAreaUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxAreaUnit.Location = new System.Drawing.Point(112, 134);
			this.comboBoxAreaUnit.Name = "comboBoxAreaUnit";
			this.comboBoxAreaUnit.Size = new System.Drawing.Size(144, 20);
			this.comboBoxAreaUnit.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 168);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 16);
			this.label6.TabIndex = 12;
			this.label6.Text = "输出象素大小：";
			// 
			// txtCellSize
			// 
			this.txtCellSize.Location = new System.Drawing.Point(112, 166);
			this.txtCellSize.Name = "txtCellSize";
			this.txtCellSize.Size = new System.Drawing.Size(144, 21);
			this.txtCellSize.TabIndex = 13;
			this.txtCellSize.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 200);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 16);
			this.label7.TabIndex = 14;
			this.label7.Text = "输出栅格位置：";
			// 
			// txtRasterPath
			// 
			this.txtRasterPath.Location = new System.Drawing.Point(112, 198);
			this.txtRasterPath.Name = "txtRasterPath";
			this.txtRasterPath.Size = new System.Drawing.Size(144, 21);
			this.txtRasterPath.TabIndex = 15;
			this.txtRasterPath.Text = "";
			// 
			// btnSaveRaster
			// 
			this.btnSaveRaster.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRaster.Image")));
			this.btnSaveRaster.Location = new System.Drawing.Point(272, 196);
			this.btnSaveRaster.Name = "btnSaveRaster";
			this.btnSaveRaster.Size = new System.Drawing.Size(24, 24);
			this.btnSaveRaster.TabIndex = 16;
			this.btnSaveRaster.Click += new System.EventHandler(this.btnSaveRaster_Click);
			// 
			// btnGO
			// 
			this.btnGO.Location = new System.Drawing.Point(88, 240);
			this.btnGO.Name = "btnGO";
			this.btnGO.Size = new System.Drawing.Size(88, 24);
			this.btnGO.TabIndex = 17;
			this.btnGO.Text = "GO!";
			this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(200, 240);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 24);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Destroy";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmDensity
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(312, 278);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnGO);
			this.Controls.Add(this.btnSaveRaster);
			this.Controls.Add(this.txtRasterPath);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtCellSize);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.comboBoxAreaUnit);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtSearchRadius);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.rdoSimple);
			this.Controls.Add(this.rdoKernel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBoxField);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOpenSourceData);
			this.Controls.Add(this.comboBoxInData);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDensity";
			this.Text = "栅格密度计算";
			this.Load += new System.EventHandler(this.frmDensity_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void btnOpenSourceData_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
			 

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				comboBoxInData.Text=openFileDialog1.FileName;
			}
			bDataPath=true;
		}

		private void btnSaveRaster_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1=new SaveFileDialog();
			saveFileDialog1.InitialDirectory=pMainFrm.SAoption.AnalysisPath;
			saveFileDialog1.Filter = "Grid Files (*.Grid)|*.Grid|All files (*.*)|*.*" ;

			if(saveFileDialog1.ShowDialog()== DialogResult.OK)
			{
				txtRasterPath.Text=saveFileDialog1.FileName;
			} 
		}
		private void PopulateComboWithMapLayers(ComboBox Layers, bool bLayer)
		{
			Layers.Items.Clear();
	 

			ILayer aLayer;
			AxMapControl axMap=pMainFrm.getMapControl();
			for (int i=0; i <= axMap.LayerCount-1; i++)
			{
				// Get the layer name and add to combo
				aLayer = axMap.get_Layer(i);
				if (aLayer.Valid == true)
				{					
					if(bLayer==true)
					{
						if(aLayer is IFeatureLayer)
						{
							IFeatureLayer pFeatLayer=aLayer as IFeatureLayer;
							if(pFeatLayer.FeatureClass.ShapeType!=esriGeometryType.esriGeometryPolygon)
								Layers.Items.Add(aLayer.Name);							 
						}
					}
					 
				}
			}
		}

		private void frmDensity_Load(object sender, System.EventArgs e)
		{
			comboBoxInData.Items.Clear();
			bool b=true;
			PopulateComboWithMapLayers(comboBoxInData,b);
			comboBoxAreaUnit.Items.Add("按地图单位");
			comboBoxAreaUnit.Items.Add("按象素单位");
			comboBoxInData.Text=pMainFrm.SAoption.AnalysisPath;
			txtRasterPath.Text=pMainFrm.SAoption.AnalysisPath;
			txtCellSize.Text=pMainFrm.SAoption.RasterCellSize.ToString();
			
			comboBoxField.Items.Add("无");
			comboBoxField.Text="无";
		}

		private void comboBoxInData_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sLayerName=comboBoxInData.Text;
			AxMapControl axMap=pMainFrm.getMapControl();
			IFeatureLayer pFeatLyr=null;
		   
			comboBoxField.Items.Clear();
			comboBoxField.Items.Add("无");
			try
			{
				for(int i=0;i<=axMap.LayerCount-1;i++)
				{
					ILayer pLyr=axMap.get_Layer(i);
					if(pLyr.Name==sLayerName)
					{
						if(pLyr is IFeatureLayer)
						{
							pFeatLyr=pLyr as IFeatureLayer;
							IFeatureClass m_pFeatCls=pFeatLyr.FeatureClass;					
							for(int j=0;j<=m_pFeatCls.Fields.FieldCount-1;j++)
							{
								comboBoxField.Items.Add(m_pFeatCls.Fields.get_Field(j).Name);
							}
						}						 
					}
				}
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			
			}
		}

		private void btnGO_Click(object sender, System.EventArgs e)
		{
			IFeatureClass pFClass=null;//获得输入特征数据类
			 
			IWorkspace pWorkspace;
			object Missing = Type.Missing;	
			string fileName;
			string rasterPath;
			string shpFile;
			int startX,endX;
			string sFieldName;//选择要进行分析的字段
			if(bDataPath==true)
			{
				fileName=comboBoxInData.Text;
				string shpDir =fileName.Substring(0, fileName.LastIndexOf("\\")); 
				startX=fileName.LastIndexOf("\\");
				endX=fileName.Length;
				shpFile=fileName.Substring(startX+1,endX-startX-1);
				pFClass=Utility.OpenFeatureClassFromShapefile(shpDir,shpFile);
			}
			else
			{
				pFClass=GetFeatureFromMapLyr(comboBoxInData.Text);
			}
			IFeatureLayer pFeatLayer =new FeatureLayerClass();
			pFeatLayer.FeatureClass=pFClass;
			rasterPath=txtRasterPath.Text;
			IFeatureClassDescriptor pFeatClsDes=new FeatureClassDescriptorClass();
			if(comboBoxField.Text!="无")
				pFeatClsDes.Create(pFClass,null,comboBoxField.Text);
			else
				pFeatClsDes.Create(pFClass,null,"");
			try
			{
				 IDensityOp pDensityOp=new RasterDensityOpClass();
				string sCellSize=txtCellSize.Text ;
				double dCellSize=Convert.ToDouble(sCellSize);
				string sRadius=txtSearchRadius.Text;
				double dRadius=Convert.ToDouble(sRadius);
				object objRadius=dRadius;
				pDensityOp=Utility.SetRasterDensityAnalysisEnv(rasterPath,dCellSize,pFeatLayer);
				IRasterNeighborhood pRasNeighborhood=new RasterNeighborhoodClass();
				if(comboBoxAreaUnit.Text=="按地图单位")
					pRasNeighborhood.SetCircle(dRadius,esriGeoAnalysisUnitsEnum.esriUnitsMap);
				else
					pRasNeighborhood.SetCircle(dRadius,esriGeoAnalysisUnitsEnum.esriUnitsCells);
				IRaster pOutRaster=null;
				switch(pFClass.ShapeType)
				{
					case esriGeometryType.esriGeometryPoint:
						if(rdoKernel.Checked==false)
							pOutRaster= pDensityOp.PointDensity(pFeatClsDes as IGeoDataset,pRasNeighborhood,ref Missing) as IRaster;
						else
							pOutRaster= pDensityOp.KernelDensity(pFeatClsDes as IGeoDataset,ref objRadius,ref Missing) as IRaster;
						break;
					case esriGeometryType.esriGeometryPolyline:
						if(rdoKernel.Checked==false)
							pOutRaster= pDensityOp.LineDensity(pFeatClsDes as IGeoDataset,ref objRadius,ref Missing) as IRaster;
						else
							pOutRaster=pDensityOp.KernelDensity(pFeatClsDes as IGeoDataset,ref objRadius,ref Missing) as IRaster;
						break;
				}
				//着色                
				IRasterLayer pRasterLayer=new RasterLayerClass();
				pRasterLayer.Name="密度栅格";
				Utility.ConvertRasterToRsDataset(rasterPath,pOutRaster,"密度栅格");
                pRasterLayer = Utility.SetRsLayerClassifiedColor(pOutRaster);
				pMainFrm.getMapControl().AddLayer(pRasterLayer,0);		
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			
			}
		
		}
		//从地图图层中获得特征类数据图层
		private IFeatureClass GetFeatureFromMapLyr(string sLyrName)
		{
			AxMapControl axMap=pMainFrm.getMapControl();
			IFeatureClass pFeatCls=null;
			　
			for (int i=0; i <= axMap.LayerCount-1; i++)
			{
				ILayer pLyr=axMap.get_Layer(i);
				if(pLyr!=null)
				{
					if(pLyr.Name==sLyrName)
					{
						if(pLyr is IFeatureLayer )
						{
							IFeatureLayer pFLyr=pLyr as  IFeatureLayer ;
							pFeatCls=pFLyr.FeatureClass;
						}						 
					}
				}				
			}
			return pFeatCls;
		}
　
	}
}
