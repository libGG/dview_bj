using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
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
	/// frmCostWeightLineDis 的摘要说明。
	/// </summary>
	public class frmCostWeightLineDis : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbDataSource;
		private System.Windows.Forms.Button btnOpenFile1;
		private System.Windows.Forms.Button btnOpenFile2;
		private System.Windows.Forms.CheckBox chkDirection;
		private System.Windows.Forms.CheckBox chkAllocation;
		private System.Windows.Forms.Button btnOpenFile3;
		private System.Windows.Forms.Button btnOpenFile4;
		private System.Windows.Forms.Button btnOpenFile5;
		private System.Windows.Forms.ComboBox cmbCostRaster;
		private System.Windows.Forms.TextBox txtMaxDis;
		private System.Windows.Forms.TextBox txtOutputDirection;
		private System.Windows.Forms.TextBox txtOutputAllocation;
		private System.Windows.Forms.TextBox txtOutpurRasterPath;
		private System.Windows.Forms.Button btnGO;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private MainFrm pMainFrm=null;
		private System.Collections.Hashtable m_LayersIndex;
		private bool bDataPath=false;
		public frmCostWeightLineDis(MainFrm _pMainFrm)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCostWeightLineDis));
			this.label1 = new System.Windows.Forms.Label();
			this.cmbDataSource = new System.Windows.Forms.ComboBox();
			this.btnOpenFile1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbCostRaster = new System.Windows.Forms.ComboBox();
			this.btnOpenFile2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMaxDis = new System.Windows.Forms.TextBox();
			this.chkDirection = new System.Windows.Forms.CheckBox();
			this.chkAllocation = new System.Windows.Forms.CheckBox();
			this.txtOutputDirection = new System.Windows.Forms.TextBox();
			this.txtOutputAllocation = new System.Windows.Forms.TextBox();
			this.btnOpenFile3 = new System.Windows.Forms.Button();
			this.btnOpenFile4 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtOutpurRasterPath = new System.Windows.Forms.TextBox();
			this.btnOpenFile5 = new System.Windows.Forms.Button();
			this.btnGO = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "原始数据：";
			// 
			// cmbDataSource
			// 
			this.cmbDataSource.Location = new System.Drawing.Point(104, 22);
			this.cmbDataSource.Name = "cmbDataSource";
			this.cmbDataSource.Size = new System.Drawing.Size(160, 20);
			this.cmbDataSource.TabIndex = 1;
			// 
			// btnOpenFile1
			// 
			this.btnOpenFile1.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile1.Image")));
			this.btnOpenFile1.Location = new System.Drawing.Point(272, 20);
			this.btnOpenFile1.Name = "btnOpenFile1";
			this.btnOpenFile1.Size = new System.Drawing.Size(32, 24);
			this.btnOpenFile1.TabIndex = 2;
			this.btnOpenFile1.Click += new System.EventHandler(this.btnOpenFile1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "费用栅格：";
			// 
			// cmbCostRaster
			// 
			this.cmbCostRaster.Location = new System.Drawing.Point(104, 54);
			this.cmbCostRaster.Name = "cmbCostRaster";
			this.cmbCostRaster.Size = new System.Drawing.Size(160, 20);
			this.cmbCostRaster.TabIndex = 4;
			// 
			// btnOpenFile2
			// 
			this.btnOpenFile2.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile2.Image")));
			this.btnOpenFile2.Location = new System.Drawing.Point(272, 52);
			this.btnOpenFile2.Name = "btnOpenFile2";
			this.btnOpenFile2.Size = new System.Drawing.Size(32, 24);
			this.btnOpenFile2.TabIndex = 5;
			this.btnOpenFile2.Click += new System.EventHandler(this.btnOpenFile2_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "最大距离值：";
			// 
			// txtMaxDis
			// 
			this.txtMaxDis.Location = new System.Drawing.Point(104, 94);
			this.txtMaxDis.Name = "txtMaxDis";
			this.txtMaxDis.Size = new System.Drawing.Size(160, 21);
			this.txtMaxDis.TabIndex = 7;
			this.txtMaxDis.Text = "";
			// 
			// chkDirection
			// 
			this.chkDirection.Location = new System.Drawing.Point(24, 136);
			this.chkDirection.Name = "chkDirection";
			this.chkDirection.Size = new System.Drawing.Size(136, 16);
			this.chkDirection.TabIndex = 8;
			this.chkDirection.Text = "是否创建方向栅格？";
			this.chkDirection.CheckedChanged += new System.EventHandler(this.chkDirection_CheckedChanged);
			// 
			// chkAllocation
			// 
			this.chkAllocation.Location = new System.Drawing.Point(24, 168);
			this.chkAllocation.Name = "chkAllocation";
			this.chkAllocation.Size = new System.Drawing.Size(136, 16);
			this.chkAllocation.TabIndex = 9;
			this.chkAllocation.Text = "是否创建分配栅格？";
			this.chkAllocation.CheckedChanged += new System.EventHandler(this.chkAllocation_CheckedChanged);
			// 
			// txtOutputDirection
			// 
			this.txtOutputDirection.Location = new System.Drawing.Point(152, 134);
			this.txtOutputDirection.Name = "txtOutputDirection";
			this.txtOutputDirection.Size = new System.Drawing.Size(112, 21);
			this.txtOutputDirection.TabIndex = 10;
			this.txtOutputDirection.Text = "";
			// 
			// txtOutputAllocation
			// 
			this.txtOutputAllocation.Location = new System.Drawing.Point(152, 166);
			this.txtOutputAllocation.Name = "txtOutputAllocation";
			this.txtOutputAllocation.Size = new System.Drawing.Size(112, 21);
			this.txtOutputAllocation.TabIndex = 11;
			this.txtOutputAllocation.Text = "";
			// 
			// btnOpenFile3
			// 
			this.btnOpenFile3.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile3.Image")));
			this.btnOpenFile3.Location = new System.Drawing.Point(272, 132);
			this.btnOpenFile3.Name = "btnOpenFile3";
			this.btnOpenFile3.Size = new System.Drawing.Size(32, 24);
			this.btnOpenFile3.TabIndex = 12;
			this.btnOpenFile3.Click += new System.EventHandler(this.btnOpenFile3_Click);
			// 
			// btnOpenFile4
			// 
			this.btnOpenFile4.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile4.Image")));
			this.btnOpenFile4.Location = new System.Drawing.Point(272, 164);
			this.btnOpenFile4.Name = "btnOpenFile4";
			this.btnOpenFile4.Size = new System.Drawing.Size(32, 24);
			this.btnOpenFile4.TabIndex = 13;
			this.btnOpenFile4.Click += new System.EventHandler(this.btnOpenFile4_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 208);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 14;
			this.label4.Text = "输出栅格：";
			// 
			// txtOutpurRasterPath
			// 
			this.txtOutpurRasterPath.Location = new System.Drawing.Point(104, 206);
			this.txtOutpurRasterPath.Name = "txtOutpurRasterPath";
			this.txtOutpurRasterPath.Size = new System.Drawing.Size(160, 21);
			this.txtOutpurRasterPath.TabIndex = 15;
			this.txtOutpurRasterPath.Text = "";
			// 
			// btnOpenFile5
			// 
			this.btnOpenFile5.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile5.Image")));
			this.btnOpenFile5.Location = new System.Drawing.Point(272, 204);
			this.btnOpenFile5.Name = "btnOpenFile5";
			this.btnOpenFile5.Size = new System.Drawing.Size(32, 24);
			this.btnOpenFile5.TabIndex = 16;
			this.btnOpenFile5.Click += new System.EventHandler(this.btnOpenFile5_Click);
			// 
			// btnGO
			// 
			this.btnGO.Location = new System.Drawing.Point(112, 240);
			this.btnGO.Name = "btnGO";
			this.btnGO.TabIndex = 17;
			this.btnGO.Text = "GO！";
			this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(216, 240);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Destroy";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmCostWeightLineDis
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(328, 278);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnGO);
			this.Controls.Add(this.btnOpenFile5);
			this.Controls.Add(this.txtOutpurRasterPath);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnOpenFile4);
			this.Controls.Add(this.btnOpenFile3);
			this.Controls.Add(this.txtOutputAllocation);
			this.Controls.Add(this.txtOutputDirection);
			this.Controls.Add(this.chkAllocation);
			this.Controls.Add(this.chkDirection);
			this.Controls.Add(this.txtMaxDis);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnOpenFile2);
			this.Controls.Add(this.cmbCostRaster);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOpenFile1);
			this.Controls.Add(this.cmbDataSource);
			this.Controls.Add(this.label1);
			this.Name = "frmCostWeightLineDis";
			this.Text = "费用权重";
			this.Load += new System.EventHandler(this.frmCostWeightLineDis_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOpenFile1_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
			 

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				cmbDataSource.Text=openFileDialog1.FileName;
			}
			bDataPath=true;
		}

		private void btnOpenFile2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnOpenFile3_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1=new SaveFileDialog();
			saveFileDialog1.InitialDirectory=pMainFrm.SAoption.AnalysisPath;
			saveFileDialog1.Filter = "Grid Files (*.Grid)|*.Grid|All files (*.*)|*.*" ;

			if(saveFileDialog1.ShowDialog()== DialogResult.OK)
			{
				txtOutputDirection.Text=saveFileDialog1.FileName;
			} 
			 
		}

		private void btnOpenFile4_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1=new SaveFileDialog();
			saveFileDialog1.InitialDirectory=pMainFrm.SAoption.AnalysisPath;
			saveFileDialog1.Filter = "Grid Files (*.Grid)|*.Grid|All files (*.*)|*.*" ;

			if(saveFileDialog1.ShowDialog()== DialogResult.OK)
			{
				txtOutputAllocation.Text=saveFileDialog1.FileName;
			} 
		}

		private void btnOpenFile5_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1=new SaveFileDialog();
			saveFileDialog1.InitialDirectory=pMainFrm.SAoption.AnalysisPath;
			saveFileDialog1.Filter = "Grid Files (*.Grid)|*.Grid|All files (*.*)|*.*" ;

			if(saveFileDialog1.ShowDialog()== DialogResult.OK)
			{
				txtOutpurRasterPath.Text=saveFileDialog1.FileName;
			} 
		}

		private void frmCostWeightLineDis_Load(object sender, System.EventArgs e)
		{
			m_LayersIndex = new Hashtable();
			bool b=true;
			 PopulateComboWithMapLayers(cmbDataSource,b,m_LayersIndex);	
			b=false;
             PopulateComboWithMapLayers(cmbCostRaster,b,m_LayersIndex);	
			//txtCellSize.Text=pMainFrm.SAoption.RasterCellSize.ToString();
			txtOutputDirection.Enabled=false;
			txtOutputAllocation.Enabled=false;
			txtOutpurRasterPath.Text=pMainFrm.SAoption.AnalysisPath;
			txtOutputDirection.Text=pMainFrm.SAoption.AnalysisPath;
			txtOutputAllocation.Text=pMainFrm.SAoption.AnalysisPath;
		}
		private void PopulateComboWithMapLayers(ComboBox Layers, bool bLayer,System.Collections.Hashtable LayersIndex)
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
					if(bLayer==true)
					{
						if(aLayer is IFeatureLayer)
						{
							Layers.Items.Add(aLayer.Name);
							LayersIndex.Add(Layers.Items.Count-1,aLayer);
						}
					}
					else
					{
						if(aLayer is IRasterLayer)
						{
							Layers.Items.Add(aLayer.Name);
							LayersIndex.Add(Layers.Items.Count-1,aLayer);
						}
					}
				}
			}
		}

		private void chkDirection_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkDirection.Checked==true)
				txtOutputDirection.Enabled=true;
			else
				txtOutputDirection.Enabled=false;
		}

		private void chkAllocation_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkAllocation.Checked==true)
				txtOutputAllocation.Enabled=true;
			else
				txtOutputAllocation.Enabled=false;
		}

		private void btnGO_Click(object sender, System.EventArgs e)
		{
			IFeatureClass pFClass=null;
			IWorkspace pWorkspace;
			object Missing = Type.Missing;	
			string fileName;
			string rasterPath;
			string shpFile;
			int startX,endX;
			if(bDataPath==true)
			{

				fileName=cmbDataSource.Text;

				string shpDir =fileName.Substring(0, fileName.LastIndexOf("\\")); 
				startX=fileName.LastIndexOf("\\");
				endX=fileName.Length;
				shpFile=fileName.Substring(startX+1,endX-startX-1);

				pFClass=Utility.OpenFeatureClassFromShapefile(shpDir,shpFile);

			}
			else
			{
				AxMapControl axMap=pMainFrm.getMapControl();
				IRasterLayer pRLyr;
				IFeatureLayer pFLyr;
				for (int i=0; i <= axMap.LayerCount-1; i++)
				{
					ILayer pLyr=axMap.get_Layer(i);
					if(pLyr!=null)
					{
						if(pLyr.Name==cmbDataSource.Text)
						{
							if(pLyr is IFeatureLayer)
							{
								pFLyr=pLyr as IFeatureLayer;
								pFClass=pFLyr.FeatureClass as IFeatureClass;

							}
							else
							{
								if(pLyr is IRasterLayer)
								{
									pRLyr=pLyr as IRasterLayer;
									 	
								}
							}
						}
					}				
				}
			}
			 
			rasterPath=txtOutpurRasterPath.Text;
            IFeatureLayer pfeatLyr = new FeatureLayerClass();
            pfeatLyr.FeatureClass = pFClass;
            IDistanceOp pDistranceOp = Utility.SetRasterDisAnalysisEnv(rasterPath, 30, pfeatLyr);
					
			double maxDis=Convert.ToDouble(txtMaxDis.Text);
			object objMaxDis=maxDis;
			 
			try
			{
				IRaster pRs=GetRSLyrFromMapLyr(cmbCostRaster.Text);　
				IRasterLayer pRasterLayer3=new RasterLayerClass();
				IRaster pOutRaster=pDistranceOp.CostDistance(pFClass as IGeoDataset,pRs as IGeoDataset ,ref objMaxDis,ref Missing) as IRaster;
			    //着色                
				pRasterLayer3.Name="费用权重栅格";
				Utility.ConvertRasterToRsDataset(rasterPath,pOutRaster,"费用权重栅格");
                pRasterLayer3 = Utility.SetRsLayerClassifiedColor(pOutRaster);
				pMainFrm.getMapControl().AddLayer(pRasterLayer3,0);		
				if(chkDirection.Checked==true)
				{
					rasterPath=txtOutputDirection.Text;
                    pDistranceOp = Utility.SetRasterDisAnalysisEnv(rasterPath, 30, pfeatLyr);
					IRasterLayer pRasterLayer1=new RasterLayerClass();
					IRaster pOutDirectiontRaster=pDistranceOp.EucDirection(pFClass as IGeoDataset,ref objMaxDis,ref Missing) as IRaster;
					//pRasterLayer1.CreateFromRaster(pOutDirectiontRaster);
					pRasterLayer1.Name="费用方向栅格";
					Utility.ConvertRasterToRsDataset(rasterPath,pOutDirectiontRaster,"费用方向栅格");
                    pRasterLayer1 = Utility.SetRsLayerClassifiedColor(pOutDirectiontRaster);
					pMainFrm.getMapControl().AddLayer(pRasterLayer1,0);
				}
				if(chkAllocation.Checked==true)
				{
					rasterPath=txtOutputAllocation.Text;
                    pDistranceOp = Utility.SetRasterDisAnalysisEnv(rasterPath, 30, pfeatLyr);
					IRasterLayer pRasterLayer2=new RasterLayerClass();
					IRaster pOutAllocationRaster=pDistranceOp.EucDirection(pFClass as IGeoDataset,ref objMaxDis,ref Missing) as IRaster;
					//pRasterLayer2.CreateFromRaster(pOutAllocationRaster);
					pRasterLayer2.Name="费用分配栅格";
					Utility.ConvertRasterToRsDataset(rasterPath,pOutAllocationRaster,"费用方向栅格");
					pRasterLayer2=Utility.SetRsLayerClassifiedColor(pOutAllocationRaster);
					pMainFrm.getMapControl().AddLayer(pRasterLayer2,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			
			}
		}
		//从地图图层中获得栅格数据图层
		private IRaster GetRSLyrFromMapLyr(string sLyrName)
		{
			AxMapControl axMap=pMainFrm.getMapControl();
			IRaster pRs=null;
			　
			for (int i=0; i <= axMap.LayerCount-1; i++)
			{
				ILayer pLyr=axMap.get_Layer(i);
				if(pLyr!=null)
				{
					if(pLyr.Name==sLyrName)
					{
						if(pLyr is IRasterLayer)
						{
							IRasterLayer pRLyr=pLyr as IRasterLayer;
							pRs=pRLyr.Raster;
						}						 
					}
				}				
			}
			return pRs;
		}
　
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		this.Dispose();
		}
	}
}
