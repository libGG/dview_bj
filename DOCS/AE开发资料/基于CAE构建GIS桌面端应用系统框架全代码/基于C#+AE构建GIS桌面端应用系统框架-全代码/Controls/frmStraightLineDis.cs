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
	/// frmStraightLineDis 的摘要说明。
	/// </summary>
	public class frmStraightLineDis : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboDisRaster;
		private System.Windows.Forms.Button btnOpenRaster;
		private System.Windows.Forms.TextBox txtMaxDis;
		private System.Windows.Forms.TextBox txtCellSize;
		private System.Windows.Forms.CheckBox chkDirection;
		private System.Windows.Forms.TextBox txtDirectionPath;
		private System.Windows.Forms.Button btnOpenRaster2;
		private System.Windows.Forms.CheckBox chkAllocation;
		private System.Windows.Forms.TextBox txtAllocationPath;
		private System.Windows.Forms.Button btnOpenRaster3;
		private System.Windows.Forms.TextBox txtRasterPath;
		private System.Windows.Forms.Button btnOpenRaster4;
		private System.Windows.Forms.Button BtnGO;
		private System.Windows.Forms.Button BtnCance;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Collections.Hashtable m_LayersIndex;
		private MainFrm pMainFrm=null;
		private bool bDataPath=false;

		public frmStraightLineDis(MainFrm _pMainFrm)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStraightLineDis));
			this.label1 = new System.Windows.Forms.Label();
			this.cboDisRaster = new System.Windows.Forms.ComboBox();
			this.btnOpenRaster = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMaxDis = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCellSize = new System.Windows.Forms.TextBox();
			this.chkDirection = new System.Windows.Forms.CheckBox();
			this.txtDirectionPath = new System.Windows.Forms.TextBox();
			this.btnOpenRaster2 = new System.Windows.Forms.Button();
			this.chkAllocation = new System.Windows.Forms.CheckBox();
			this.txtAllocationPath = new System.Windows.Forms.TextBox();
			this.btnOpenRaster3 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtRasterPath = new System.Windows.Forms.TextBox();
			this.btnOpenRaster4 = new System.Windows.Forms.Button();
			this.BtnGO = new System.Windows.Forms.Button();
			this.BtnCance = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "原始数据：";
			// 
			// cboDisRaster
			// 
			this.cboDisRaster.Location = new System.Drawing.Point(112, 14);
			this.cboDisRaster.Name = "cboDisRaster";
			this.cboDisRaster.Size = new System.Drawing.Size(160, 20);
			this.cboDisRaster.TabIndex = 1;
			this.cboDisRaster.SelectedIndexChanged += new System.EventHandler(this.cboDisRaster_SelectedIndexChanged);
			// 
			// btnOpenRaster
			// 
			this.btnOpenRaster.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenRaster.Image")));
			this.btnOpenRaster.Location = new System.Drawing.Point(288, 12);
			this.btnOpenRaster.Name = "btnOpenRaster";
			this.btnOpenRaster.Size = new System.Drawing.Size(24, 24);
			this.btnOpenRaster.TabIndex = 2;
			this.btnOpenRaster.Click += new System.EventHandler(this.btnOpenRaster_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "最大距离值：";
			// 
			// txtMaxDis
			// 
			this.txtMaxDis.Location = new System.Drawing.Point(112, 47);
			this.txtMaxDis.Name = "txtMaxDis";
			this.txtMaxDis.Size = new System.Drawing.Size(160, 21);
			this.txtMaxDis.TabIndex = 4;
			this.txtMaxDis.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "输出栅格分辨率：";
			// 
			// txtCellSize
			// 
			this.txtCellSize.Location = new System.Drawing.Point(128, 80);
			this.txtCellSize.Name = "txtCellSize";
			this.txtCellSize.Size = new System.Drawing.Size(144, 21);
			this.txtCellSize.TabIndex = 6;
			this.txtCellSize.Text = "";
			// 
			// chkDirection
			// 
			this.chkDirection.Location = new System.Drawing.Point(24, 115);
			this.chkDirection.Name = "chkDirection";
			this.chkDirection.Size = new System.Drawing.Size(136, 24);
			this.chkDirection.TabIndex = 7;
			this.chkDirection.Text = "是否创建方向栅格？";
			this.chkDirection.CheckedChanged += new System.EventHandler(this.chkDirection_CheckedChanged);
			// 
			// txtDirectionPath
			// 
			this.txtDirectionPath.Location = new System.Drawing.Point(160, 117);
			this.txtDirectionPath.Name = "txtDirectionPath";
			this.txtDirectionPath.Size = new System.Drawing.Size(112, 21);
			this.txtDirectionPath.TabIndex = 8;
			this.txtDirectionPath.Text = "";
			// 
			// btnOpenRaster2
			// 
			this.btnOpenRaster2.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenRaster2.Image")));
			this.btnOpenRaster2.Location = new System.Drawing.Point(288, 115);
			this.btnOpenRaster2.Name = "btnOpenRaster2";
			this.btnOpenRaster2.Size = new System.Drawing.Size(24, 24);
			this.btnOpenRaster2.TabIndex = 9;
			this.btnOpenRaster2.Click += new System.EventHandler(this.btnOpenRaster2_Click);
			// 
			// chkAllocation
			// 
			this.chkAllocation.Location = new System.Drawing.Point(24, 156);
			this.chkAllocation.Name = "chkAllocation";
			this.chkAllocation.Size = new System.Drawing.Size(136, 24);
			this.chkAllocation.TabIndex = 10;
			this.chkAllocation.Text = "是否创建分配栅格？";
			this.chkAllocation.CheckedChanged += new System.EventHandler(this.chkAllocation_CheckedChanged);
			// 
			// txtAllocationPath
			// 
			this.txtAllocationPath.Location = new System.Drawing.Point(160, 158);
			this.txtAllocationPath.Name = "txtAllocationPath";
			this.txtAllocationPath.Size = new System.Drawing.Size(112, 21);
			this.txtAllocationPath.TabIndex = 11;
			this.txtAllocationPath.Text = "";
			// 
			// btnOpenRaster3
			// 
			this.btnOpenRaster3.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenRaster3.Image")));
			this.btnOpenRaster3.Location = new System.Drawing.Point(288, 156);
			this.btnOpenRaster3.Name = "btnOpenRaster3";
			this.btnOpenRaster3.Size = new System.Drawing.Size(24, 24);
			this.btnOpenRaster3.TabIndex = 12;
			this.btnOpenRaster3.Click += new System.EventHandler(this.btnOpenRaster3_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 197);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "输出栅格：";
			// 
			// txtRasterPath
			// 
			this.txtRasterPath.Location = new System.Drawing.Point(112, 195);
			this.txtRasterPath.Name = "txtRasterPath";
			this.txtRasterPath.Size = new System.Drawing.Size(160, 21);
			this.txtRasterPath.TabIndex = 14;
			this.txtRasterPath.Text = "";
			// 
			// btnOpenRaster4
			// 
			this.btnOpenRaster4.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenRaster4.Image")));
			this.btnOpenRaster4.Location = new System.Drawing.Point(288, 193);
			this.btnOpenRaster4.Name = "btnOpenRaster4";
			this.btnOpenRaster4.Size = new System.Drawing.Size(24, 24);
			this.btnOpenRaster4.TabIndex = 15;
			this.btnOpenRaster4.Click += new System.EventHandler(this.btnOpenRaster4_Click);
			// 
			// BtnGO
			// 
			this.BtnGO.Location = new System.Drawing.Point(120, 232);
			this.BtnGO.Name = "BtnGO";
			this.BtnGO.Size = new System.Drawing.Size(88, 24);
			this.BtnGO.TabIndex = 16;
			this.BtnGO.Text = "GO!";
			this.BtnGO.Click += new System.EventHandler(this.BtnGO_Click);
			// 
			// BtnCance
			// 
			this.BtnCance.Location = new System.Drawing.Point(240, 232);
			this.BtnCance.Name = "BtnCance";
			this.BtnCance.Size = new System.Drawing.Size(80, 24);
			this.BtnCance.TabIndex = 17;
			this.BtnCance.Text = "Destroy";
			this.BtnCance.Click += new System.EventHandler(this.BtnCance_Click);
			// 
			// frmStraightLineDis
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(336, 270);
			this.Controls.Add(this.BtnCance);
			this.Controls.Add(this.BtnGO);
			this.Controls.Add(this.btnOpenRaster4);
			this.Controls.Add(this.txtRasterPath);
			this.Controls.Add(this.txtAllocationPath);
			this.Controls.Add(this.txtDirectionPath);
			this.Controls.Add(this.txtCellSize);
			this.Controls.Add(this.txtMaxDis);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnOpenRaster3);
			this.Controls.Add(this.chkAllocation);
			this.Controls.Add(this.btnOpenRaster2);
			this.Controls.Add(this.chkDirection);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOpenRaster);
			this.Controls.Add(this.cboDisRaster);
			this.Controls.Add(this.label1);
			this.Name = "frmStraightLineDis";
			this.Text = "直线距离";
			this.Load += new System.EventHandler(this.frmStraightLineDis_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOpenRaster_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = "c:\\" ;
			 

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				 cboDisRaster.Text=openFileDialog1.FileName;
			}
			bDataPath=true;

		}

		private void frmStraightLineDis_Load(object sender, System.EventArgs e)
		{
			m_LayersIndex = new Hashtable();
			PopulateComboWithMapLayers(cboDisRaster,m_LayersIndex);	
		    txtCellSize.Text=pMainFrm.SAoption.RasterCellSize.ToString();
			txtDirectionPath.Enabled=false;
			txtAllocationPath.Enabled=false;
			txtRasterPath.Text=pMainFrm.SAoption.AnalysisPath;
			txtDirectionPath.Text=pMainFrm.SAoption.AnalysisPath;
			txtAllocationPath.Text=pMainFrm.SAoption.AnalysisPath;
		 
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
					if(aLayer is IFeatureLayer)
					{
						Layers.Items.Add(aLayer.Name);
						LayersIndex.Add(Layers.Items.Count-1,aLayer);
					}
				}
			}
		}

		private void chkDirection_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkDirection.Checked==true)
				txtDirectionPath.Enabled=true;
			else
				txtDirectionPath.Enabled=false;
		}

		private void chkAllocation_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkAllocation.Checked==true)
				txtAllocationPath.Enabled=true;
			else
				txtAllocationPath.Enabled=false;

		}

		private void btnOpenRaster4_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1=new SaveFileDialog();
			saveFileDialog1.InitialDirectory="c:\\";
			saveFileDialog1.Filter = "Grid Files (*.Grid)|*.Grid|All files (*.*)|*.*" ;

			if(saveFileDialog1.ShowDialog()== DialogResult.OK)
			{
				txtRasterPath.Text=saveFileDialog1.FileName;
			}

		}

		private void BtnCance_Click(object sender, System.EventArgs e)
		{
			 this.Dispose();
		}

		private void BtnGO_Click(object sender, System.EventArgs e)
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

				fileName=cboDisRaster.Text;

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
						if(pLyr.Name==cboDisRaster.Text)
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
		    double cellsize=Convert.ToDouble(txtCellSize.Text);
			rasterPath=txtRasterPath.Text;
            IFeatureLayer pfeatLyr = new FeatureLayerClass();
            pfeatLyr.FeatureClass = pFClass;
            IDistanceOp pDistranceOp = Utility.SetRasterDisAnalysisEnv(rasterPath, cellsize, pfeatLyr);
					
			double maxDis=Convert.ToDouble(txtMaxDis.Text);
			object objMaxDis=maxDis;
			 
			try
			{
				if(chkDirection.Checked==true)
				{
					rasterPath=txtDirectionPath.Text;
                    pDistranceOp = Utility.SetRasterDisAnalysisEnv(rasterPath, cellsize, pfeatLyr);
					IRasterLayer pRasterLayer1=new RasterLayerClass();
					IRaster pOutDirectiontRaster=pDistranceOp.EucDirection(pFClass as IGeoDataset,ref objMaxDis,ref Missing) as IRaster;
					//pRasterLayer1.CreateFromRaster(pOutDirectiontRaster);
					pRasterLayer1.Name="方向栅格";
					Utility.ConvertRasterToRsDataset(rasterPath,pOutDirectiontRaster,"方向栅格");
					pRasterLayer1=Utility.GetRLayerClassifyColor(pOutDirectiontRaster,maxDis);
					pMainFrm.getMapControl().AddLayer(pRasterLayer1,0);
				}
				if(chkAllocation.Checked==true)
				{
					rasterPath=txtAllocationPath.Text;
                    pDistranceOp = Utility.SetRasterDisAnalysisEnv(rasterPath, cellsize, pfeatLyr);
					IRasterLayer pRasterLayer2=new RasterLayerClass();
					IRaster pOutAllocationRaster=pDistranceOp.EucDirection(pFClass as IGeoDataset,ref objMaxDis,ref Missing) as IRaster;
					//pRasterLayer2.CreateFromRaster(pOutAllocationRaster);
					pRasterLayer2.Name="分配栅格";
					Utility.ConvertRasterToRsDataset(rasterPath,pOutAllocationRaster,"方向栅格");
					pRasterLayer2=Utility.GetRLayerClassifyColor(pOutAllocationRaster,maxDis);
					pMainFrm.getMapControl().AddLayer(pRasterLayer2,0);
				}
				IRasterLayer pRasterLayer3=new RasterLayerClass();
				IRaster pOutRaster=pDistranceOp.EucDistance(pFClass as IGeoDataset,ref objMaxDis,ref Missing) as IRaster;
				//pRasterLayer3.CreateFromRaster(pOutRaster);				
				//着色
                
				pRasterLayer3.Name="距离栅格";
				Utility.ConvertRasterToRsDataset(rasterPath,pOutRaster,"距离栅格");
				pRasterLayer3=Utility.GetRLayerClassifyColor(pOutRaster,maxDis);
				pMainFrm.getMapControl().AddLayer(pRasterLayer3,0);			 
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			
			}
		}
	
		private void btnOpenRaster2_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1=new SaveFileDialog();
			saveFileDialog1.InitialDirectory="c:\\";
			if(saveFileDialog1.ShowDialog()== DialogResult.OK)
			{
				txtDirectionPath.Text=saveFileDialog1.FileName;
			}
		}

		private void btnOpenRaster3_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1=new SaveFileDialog();
			saveFileDialog1.InitialDirectory="c:\\";
			if(saveFileDialog1.ShowDialog()== DialogResult.OK)
			{
				txtAllocationPath.Text=saveFileDialog1.FileName;
			}
		}

		private void cboDisRaster_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
