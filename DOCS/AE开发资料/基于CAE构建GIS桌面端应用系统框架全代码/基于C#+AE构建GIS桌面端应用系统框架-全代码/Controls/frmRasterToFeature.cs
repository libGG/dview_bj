using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.DataSourcesFile;
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
    public partial class frmRasterToFeature : Form
    {
        private MainFrm pMainFrm = null;
        private bool bFeatDataPath = false;
        private bool bRasterDataPath = false;
        private IRaster m_pInRaster = null;
        public frmRasterToFeature(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
            openFileDialog1.Filter = "Imagine (*.img)|*.img|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBoxInData.Text = openFileDialog1.FileName;
            }
            bFeatDataPath = true;
        }

        private void comboBoxInData_SelectedIndexChanged(object sender, EventArgs e)
        {
             string sLayerName = comboBoxInData.Text;
            AxMapControl axMap = pMainFrm.getMapControl();
            IRasterLayer pRsLayer = null;    
			 						
            comboBoxField.Items.Clear();
            comboBoxField.Items.Add("无");
            try
            {
                for (int i = 0; i <= axMap.LayerCount - 1; i++)
                {
                    ILayer pLyr = axMap.get_Layer(i);
                    if (pLyr.Name == sLayerName)
                    {
                        if (pLyr is IRasterLayer)
                        {
                            pRsLayer = pLyr as IRasterLayer;
                            m_pInRaster = pRsLayer.Raster;
                            IRasterBandCollection pBandCol = pRsLayer.Raster as IRasterBandCollection;
                            IRasterBand pBand = pBandCol.Item(0);
                            bool HasTable;
                            pBand.HasTable(out HasTable);
                            if (HasTable == true)
                            {
                                ITable pTable = pBand.AttributeTable;
                                IFields pFields = pTable.Fields;
                                for (i = 0; i <= pFields.FieldCount - 1; i++)
                                {
                                    comboBoxField.Items.Add(pFields.get_Field(i).Name);
                                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
            saveFileDialog1.Filter = "Shape Files (*.shp)|*.shp|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutPath.Text = saveFileDialog1.FileName;
            }
            bRasterDataPath = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            string fileName;
            string shpFile;
            int startX, endX;
            string shpDir;
            object Missing = Type.Missing;	
            //if (bFeatDataPath == true)
            //{
            //    fileName = comboBoxInData.Text;
            //    shpDir = fileName.Substring(0, fileName.LastIndexOf("\\"));
            //    startX = fileName.LastIndexOf("\\");
            //    endX = fileName.Length;
            //    shpFile = fileName.Substring(startX + 1, endX - startX - 1);
            //    pFClass = Utility.OpenFeatureClassFromShapefile(shpDir, shpFile);
            //}
            //else
            //{
            //    pFClass = GetFeatureFromMapLyr(comboBoxInData.Text);
            //}
            if (bRasterDataPath == true)
            {
                fileName = txtOutPath.Text;
                shpDir = fileName.Substring(0, fileName.LastIndexOf("\\"));
                startX = fileName.LastIndexOf("\\");
                endX = fileName.Length;
                shpFile = fileName.Substring(startX + 1, endX - startX - 1);
            }
            else
            {
                shpDir = txtOutPath.Text;
                shpFile = "栅格转特征";
            }
            try
            {
                //删除临时特征文件
                DelFeatFile(shpDir, shpFile);
                //获得栅格数据集
                IRasterDescriptor pRsDescriptor = new RasterDescriptorClass();
                pRsDescriptor.Create(m_pInRaster, new QueryFilterClass(), comboBoxField.Text);
                //获得输出工作空间
                IWorkspaceFactory pWSF=new ShapefileWorkspaceFactoryClass();
                IWorkspace pWS = pWSF.OpenFromFile(shpDir, 0);
                //转换栅格为特征类
                IConversionOp pConversionOp = new RasterConversionOpClass();
                IFeatureClass  pOutFeatCls = null;
                switch (comboBoxGeomeryType.Text)
                {
                    case "点":
                        pOutFeatCls = pConversionOp.RasterDataToPointFeatureData(pRsDescriptor as IGeoDataset, pWS, shpFile) as IFeatureClass ;
                        break;
                    case "线":
                        pOutFeatCls = pConversionOp.RasterDataToLineFeatureData(pRsDescriptor as IGeoDataset, pWS, shpFile, false, false, ref Missing) as IFeatureClass;
                        break;
                    case "面":
                        pOutFeatCls = pConversionOp.RasterDataToPolygonFeatureData(pRsDescriptor as IGeoDataset, pWS, shpFile,false ) as IFeatureClass;
                        break;
                }
                IFeatureLayer pFeatLyr = new FeatureLayerClass();
                pFeatLyr.FeatureClass = pOutFeatCls;
                pMainFrm.getMapControl().AddLayer(pFeatLyr, 0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        //删除已存在的特征文件
        private void DelFeatFile(string sPath, string sName)
        {
            try
            {
                IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
                IFeatureWorkspace pFeatWorkspace = pWorkspaceFactory.OpenFromFile(sPath, 0) as IFeatureWorkspace ;
                IFeatureClass pFeatCls = pFeatWorkspace.OpenFeatureClass(sName);
                IDataset pDataset = pFeatCls as IDataset;
                pDataset.Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void PopulateComboWithMapLayers(ComboBox Layers, bool bLayer)
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
                        if (aLayer is  IRasterLayer)
                        {
                            Layers.Items.Add(aLayer.Name);
                        }
                    }

                }
            }
        }

        private void frmRasterToFeature_Load(object sender, EventArgs e)
        {
            PopulateComboWithMapLayers(comboBoxInData, true);
            txtOutPath.Text = pMainFrm.SAoption.AnalysisPath;
            comboBoxGeomeryType.Items.Clear();
            comboBoxGeomeryType.Items.Add("点");
            comboBoxGeomeryType.Items.Add("线");
            comboBoxGeomeryType.Items.Add("面");
        }

       
    }
}