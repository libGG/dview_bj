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
	/// frmFind 的摘要说明。
	/// </summary>
	public class frmFind : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxLayer;
		private System.Windows.Forms.Button buttonEqual;
		private System.Windows.Forms.Button buttonUnequal;
		private System.Windows.Forms.ListBox listBoxField;
		private System.Windows.Forms.Button buttonBig;
		private System.Windows.Forms.Button buttonBigEqual;
		private System.Windows.Forms.Button buttonLike;
		private System.Windows.Forms.Button buttonAnd;
		private System.Windows.Forms.Button buttonPercent;
		private System.Windows.Forms.Button buttonOr;
		private System.Windows.Forms.Button buttonSmallEqual;
		private System.Windows.Forms.Button buttonSmall;
		private System.Windows.Forms.Button buttonBracket;
		private System.Windows.Forms.Button buttonNot;
		private System.Windows.Forms.Button buttonIs;
        private System.Windows.Forms.ListBox listBoxValue;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label labelCaption;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private MainFrm pMainFrm=null;//获取主窗体
		private IFeatureClass m_pFeatCls=null;//根据所选择的图层查询得到的特征类
		private System.Windows.Forms.TextBox textBox1;
		private ITable m_pTable=null;//如果选择的图层是栅格类型，则获取得到它的属性表
		private IRaster m_pRaster=null;//栅格数据类
		public frmFind(MainFrm _pMainFrm)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			pMainFrm=_pMainFrm;
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
		//添加所有的图层
		private void AddAllLayertoComboBox(ComboBox cboBox)
		{
			cboBox.Items.Clear();
			int iLyrIndex;
			ILayer pLyr=null;
		 
			AxMapControl axMap=pMainFrm.getMapControl();
			int iLayerCount=axMap.LayerCount;
			if(iLayerCount>0)
			{
				cboBox.Enabled=true;
				for(iLyrIndex=0;iLyrIndex<=iLayerCount-1;iLyrIndex++)
				{
					pLyr=axMap.get_Layer(iLyrIndex);
					cboBox.Items.Add(pLyr.Name);					
				}				
			}
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLayer = new System.Windows.Forms.ComboBox();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.listBoxField = new System.Windows.Forms.ListBox();
            this.buttonUnequal = new System.Windows.Forms.Button();
            this.buttonBig = new System.Windows.Forms.Button();
            this.buttonBigEqual = new System.Windows.Forms.Button();
            this.buttonLike = new System.Windows.Forms.Button();
            this.buttonAnd = new System.Windows.Forms.Button();
            this.buttonPercent = new System.Windows.Forms.Button();
            this.buttonOr = new System.Windows.Forms.Button();
            this.buttonSmallEqual = new System.Windows.Forms.Button();
            this.buttonSmall = new System.Windows.Forms.Button();
            this.buttonBracket = new System.Windows.Forms.Button();
            this.buttonNot = new System.Windows.Forms.Button();
            this.buttonIs = new System.Windows.Forms.Button();
            this.listBoxValue = new System.Windows.Forms.ListBox();
            this.labelCaption = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层：";
            // 
            // comboBoxLayer
            // 
            this.comboBoxLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayer.Location = new System.Drawing.Point(120, 14);
            this.comboBoxLayer.Name = "comboBoxLayer";
            this.comboBoxLayer.Size = new System.Drawing.Size(184, 20);
            this.comboBoxLayer.TabIndex = 1;
            this.comboBoxLayer.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayer_SelectedIndexChanged);
            // 
            // buttonEqual
            // 
            this.buttonEqual.Location = new System.Drawing.Point(16, 144);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(32, 23);
            this.buttonEqual.TabIndex = 2;
            this.buttonEqual.Text = "=";
            this.buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
            // 
            // listBoxField
            // 
            this.listBoxField.ItemHeight = 12;
            this.listBoxField.Location = new System.Drawing.Point(16, 40);
            this.listBoxField.Name = "listBoxField";
            this.listBoxField.Size = new System.Drawing.Size(344, 100);
            this.listBoxField.TabIndex = 3;
            this.listBoxField.DoubleClick += new System.EventHandler(this.listBoxField_DoubleClick);
            this.listBoxField.SelectedIndexChanged += new System.EventHandler(this.listBoxField_SelectedIndexChanged);
            // 
            // buttonUnequal
            // 
            this.buttonUnequal.Location = new System.Drawing.Point(56, 144);
            this.buttonUnequal.Name = "buttonUnequal";
            this.buttonUnequal.Size = new System.Drawing.Size(32, 23);
            this.buttonUnequal.TabIndex = 4;
            this.buttonUnequal.Text = "<>";
            this.buttonUnequal.Click += new System.EventHandler(this.buttonUnequal_Click);
            // 
            // buttonBig
            // 
            this.buttonBig.Location = new System.Drawing.Point(16, 184);
            this.buttonBig.Name = "buttonBig";
            this.buttonBig.Size = new System.Drawing.Size(32, 23);
            this.buttonBig.TabIndex = 5;
            this.buttonBig.Text = ">";
            this.buttonBig.Click += new System.EventHandler(this.buttonBig_Click);
            // 
            // buttonBigEqual
            // 
            this.buttonBigEqual.Location = new System.Drawing.Point(56, 184);
            this.buttonBigEqual.Name = "buttonBigEqual";
            this.buttonBigEqual.Size = new System.Drawing.Size(32, 23);
            this.buttonBigEqual.TabIndex = 6;
            this.buttonBigEqual.Text = ">=";
            this.buttonBigEqual.Click += new System.EventHandler(this.buttonBigEqual_Click);
            // 
            // buttonLike
            // 
            this.buttonLike.Location = new System.Drawing.Point(96, 144);
            this.buttonLike.Name = "buttonLike";
            this.buttonLike.Size = new System.Drawing.Size(40, 23);
            this.buttonLike.TabIndex = 7;
            this.buttonLike.Text = "Like";
            this.buttonLike.Click += new System.EventHandler(this.buttonLike_Click);
            // 
            // buttonAnd
            // 
            this.buttonAnd.Location = new System.Drawing.Point(96, 184);
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(32, 23);
            this.buttonAnd.TabIndex = 8;
            this.buttonAnd.Text = "And";
            this.buttonAnd.Click += new System.EventHandler(this.buttonAnd_Click);
            // 
            // buttonPercent
            // 
            this.buttonPercent.Location = new System.Drawing.Point(136, 144);
            this.buttonPercent.Name = "buttonPercent";
            this.buttonPercent.Size = new System.Drawing.Size(32, 23);
            this.buttonPercent.TabIndex = 9;
            this.buttonPercent.Text = "%";
            this.buttonPercent.Click += new System.EventHandler(this.buttonPercent_Click);
            // 
            // buttonOr
            // 
            this.buttonOr.Location = new System.Drawing.Point(96, 224);
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(32, 23);
            this.buttonOr.TabIndex = 10;
            this.buttonOr.Text = "Or";
            this.buttonOr.Click += new System.EventHandler(this.buttonOr_Click);
            // 
            // buttonSmallEqual
            // 
            this.buttonSmallEqual.Location = new System.Drawing.Point(56, 224);
            this.buttonSmallEqual.Name = "buttonSmallEqual";
            this.buttonSmallEqual.Size = new System.Drawing.Size(32, 23);
            this.buttonSmallEqual.TabIndex = 11;
            this.buttonSmallEqual.Text = "<=";
            this.buttonSmallEqual.Click += new System.EventHandler(this.buttonSmallEqual_Click);
            // 
            // buttonSmall
            // 
            this.buttonSmall.Location = new System.Drawing.Point(16, 224);
            this.buttonSmall.Name = "buttonSmall";
            this.buttonSmall.Size = new System.Drawing.Size(32, 23);
            this.buttonSmall.TabIndex = 12;
            this.buttonSmall.Text = "<";
            this.buttonSmall.Click += new System.EventHandler(this.buttonSmall_Click);
            // 
            // buttonBracket
            // 
            this.buttonBracket.Location = new System.Drawing.Point(136, 184);
            this.buttonBracket.Name = "buttonBracket";
            this.buttonBracket.Size = new System.Drawing.Size(32, 23);
            this.buttonBracket.TabIndex = 13;
            this.buttonBracket.Text = "()";
            this.buttonBracket.Click += new System.EventHandler(this.buttonBracket_Click);
            // 
            // buttonNot
            // 
            this.buttonNot.Location = new System.Drawing.Point(136, 224);
            this.buttonNot.Name = "buttonNot";
            this.buttonNot.Size = new System.Drawing.Size(32, 23);
            this.buttonNot.TabIndex = 14;
            this.buttonNot.Text = "Not";
            this.buttonNot.Click += new System.EventHandler(this.buttonNot_Click);
            // 
            // buttonIs
            // 
            this.buttonIs.Location = new System.Drawing.Point(16, 256);
            this.buttonIs.Name = "buttonIs";
            this.buttonIs.Size = new System.Drawing.Size(32, 23);
            this.buttonIs.TabIndex = 15;
            this.buttonIs.Text = "Is";
            this.buttonIs.Click += new System.EventHandler(this.buttonIs_Click);
            // 
            // listBoxValue
            // 
            this.listBoxValue.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBoxValue.ItemHeight = 12;
            this.listBoxValue.Location = new System.Drawing.Point(176, 144);
            this.listBoxValue.Name = "listBoxValue";
            this.listBoxValue.Size = new System.Drawing.Size(184, 100);
            this.listBoxValue.TabIndex = 16;
            this.listBoxValue.DoubleClick += new System.EventHandler(this.listBoxValue_DoubleClick);
            // 
            // labelCaption
            // 
            this.labelCaption.Location = new System.Drawing.Point(16, 296);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(168, 16);
            this.labelCaption.TabIndex = 19;
            this.labelCaption.Text = "Select * From Table Where";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(196, 384);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(72, 24);
            this.buttonApply.TabIndex = 21;
            this.buttonApply.Text = "应用";
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(288, 384);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(72, 24);
            this.buttonClose.TabIndex = 22;
            this.buttonClose.Text = "关闭";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 320);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 56);
            this.textBox1.TabIndex = 23;
            // 
            // frmFind
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(376, 414);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.labelCaption);
            this.Controls.Add(this.listBoxValue);
            this.Controls.Add(this.buttonIs);
            this.Controls.Add(this.buttonNot);
            this.Controls.Add(this.buttonBracket);
            this.Controls.Add(this.buttonSmall);
            this.Controls.Add(this.buttonSmallEqual);
            this.Controls.Add(this.buttonOr);
            this.Controls.Add(this.buttonPercent);
            this.Controls.Add(this.buttonAnd);
            this.Controls.Add(this.buttonLike);
            this.Controls.Add(this.buttonBigEqual);
            this.Controls.Add(this.buttonBig);
            this.Controls.Add(this.buttonUnequal);
            this.Controls.Add(this.listBoxField);
            this.Controls.Add(this.buttonEqual);
            this.Controls.Add(this.comboBoxLayer);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFind";
            this.Text = "通过属性查询";
            this.Load += new System.EventHandler(this.frmFind_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmFind_Load(object sender, System.EventArgs e)
		{
			comboBoxLayer.Enabled=false;
			AddAllLayertoComboBox(comboBoxLayer);
			
		
		}

		private void comboBoxLayer_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sLayerName=comboBoxLayer.Text;
			AxMapControl axMap=pMainFrm.getMapControl();
			IFeatureLayer pFeatLyr=null;
			IRasterLayer pRsLayer=null;
			listBoxField.Items.Clear();
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
							m_pFeatCls=pFeatLyr.FeatureClass;					
							for(int j=0;j<=m_pFeatCls.Fields.FieldCount-1;j++)
							{
								listBoxField.Items.Add(m_pFeatCls.Fields.get_Field(j).Name);
							}
						}
						else
						{
							pRsLayer=pLyr as IRasterLayer;
							IRaster pInRaster=pRsLayer.Raster;
							m_pRaster=pInRaster;
							IRasterBandCollection pBandCol=pInRaster as IRasterBandCollection;
							IRasterBand pBand=pBandCol.Item(0);
							bool HasTable;
							pBand.HasTable(out HasTable);
							if(HasTable==true)
							{
								m_pTable=pBand.AttributeTable;
								IFields pFields=m_pTable.Fields;
								for( i=0;i<=pFields.FieldCount-1;i++)
								{
									listBoxField.Items.Add(pFields.get_Field(i).Name);
								}
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
//判断选择的图层是特征类还是栅格类
		private bool GetLayerType(string sLayerName)
		{
			AxMapControl axMap=pMainFrm.getMapControl();
			bool LayerType=false;
			for(int i=0;i<=axMap.LayerCount-1;i++)
			{
				ILayer pLyr=axMap.get_Layer(i);
				if(pLyr.Name==sLayerName)
				{
					if(pLyr is IFeatureLayer)
					{
						LayerType=false;
					}
					else
					{
						LayerType=true;
					}
				}
			}
			return LayerType;

		}
		private void listBoxField_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sFieldName=listBoxField.Text;
			bool bLayerType=GetLayerType(comboBoxLayer.Text);
			listBoxValue.Items.Clear();
			int iFieldIndex=0;
			IField pField=null;
			int i=0;
			if(bLayerType==false)
			{
				 IFeatureCursor pFeatCursor=m_pFeatCls.Search(null,true);
				IFeature pFeat=pFeatCursor.NextFeature() ;
				iFieldIndex=m_pFeatCls.FindField(sFieldName);
				pField=m_pFeatCls.Fields.get_Field(iFieldIndex);
				while(pFeat!=null)
				{
					listBoxValue.Items.Add(pFeat.get_Value(iFieldIndex));
					pFeat=pFeatCursor.NextFeature();
				}
			    
			}
			else
			{
				iFieldIndex=m_pTable.FindField(sFieldName);
				pField=m_pTable.Fields.get_Field(iFieldIndex);
				for(i=0;i<=m_pTable.RowCount(null)-1;i++)
				{
					IRow pRow=m_pTable.GetRow(i);
					listBoxValue.Items.Add(pRow.get_Value(iFieldIndex));
				}
			}

		}

		private void listBoxField_DoubleClick(object sender, System.EventArgs e)
		{
			textBox1.SelectedText =listBoxField.SelectedItem.ToString()+ " ";
		}

		private void listBoxValue_DoubleClick(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="'"+listBoxValue.SelectedItem.ToString()+ "' ";
		}

		private void buttonEqual_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="= ";
		}

		private void buttonUnequal_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="<> ";
		}

		private void buttonLike_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="Like ";
		}

		private void buttonPercent_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="%";
		}

		private void buttonBig_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="> ";
		}

		private void buttonBigEqual_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText=">= ";
		}

		private void buttonAnd_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="and ";
		}

		private void buttonBracket_Click(object sender, System.EventArgs e)
		{
		 
			textBox1.SelectedText="( ) ";
		 
		}

		private void buttonSmall_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="< ";
		}

		private void buttonSmallEqual_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="<= ";
		}

		private void buttonOr_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="or ";
		}

		private void buttonNot_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="not ";
		}

		private void buttonIs_Click(object sender, System.EventArgs e)
		{
			textBox1.SelectedText="is ";
		}

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
       //
		private void buttonApply_Click(object sender, System.EventArgs e)
		{
			try
			{
				IQueryFilter pQueryFilter=new QueryFilterClass();
				AxMapControl axMap=pMainFrm.getMapControl();
				string sLayerName=comboBoxLayer.Text;
				bool bLayerType=GetLayerType(sLayerName);
				IActiveView pActiveView=axMap.Map as IActiveView ;
			                 
				if(bLayerType==false)
				{
					pQueryFilter.WhereClause=textBox1.Text;		 
					IFeatureCursor pFeatCursor=m_pFeatCls.Search(pQueryFilter,false);
					IFeature pFeature=pFeatCursor.NextFeature();
 
					axMap.Map.ClearSelection();
					IEnvelope pEnvelope=new EnvelopeClass();
					ILayer pLayer=GetLayerFromName(sLayerName);
					
					while(pFeature!=null)
					{
						axMap.Map.SelectFeature(pLayer,pFeature);
						pEnvelope.Union(pFeature.Extent.Envelope);
						pFeature=pFeatCursor.NextFeature();
					}		
					axMap.Extent=pEnvelope;
					pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection,null,null);	
					pActiveView.Refresh();
				 
				}
				else
				{
					IRasterDescriptor pRasDes=new RasterDescriptorClass();
					pQueryFilter.WhereClause=textBox1.Text;		
					pRasDes.Create(m_pRaster,pQueryFilter,listBoxField.Text);
					IExtractionOp pExtrOp=new RasterExtractionOpClass();
					IRaster pRaster=pExtrOp.Attribute(pRasDes) as Raster ;
					IRasterLayer pRsLayer=new RasterLayerClass();
					pRsLayer.CreateFromRaster(pRaster);
					axMap.Map.AddLayer(pRsLayer);
					pActiveView.Refresh();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			
			}

		}
		//从图层的名称获得Ilayer接口类
		private ILayer GetLayerFromName(string sName)
		{
			AxMapControl axMap=pMainFrm.getMapControl();
			ILayer pLyr=null;
			for(int i=0;i<=axMap.LayerCount-1;i++)
			{
				
				if(axMap.Map.get_Layer(i).Name==sName)
				{
					pLyr=axMap.get_Layer(i);
				}
			}
			return pLyr;
		}
　　

		 
	}
	 
}
