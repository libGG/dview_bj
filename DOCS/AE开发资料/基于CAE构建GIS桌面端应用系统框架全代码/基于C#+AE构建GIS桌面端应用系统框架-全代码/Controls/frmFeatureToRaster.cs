using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
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
    public partial class frmFeatureToRaster : Form
    {
        private MainFrm pMainFrm = null;
        private bool bFeatDataPath = false;
        private bool bRasterDataPath = false;
        public frmFeatureToRaster(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
            openFileDialog1.Filter = "Shape Files (*.shp)|*.shp|All files (*.*)|*.*";

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
            IFeatureLayer pFeatLyr = null;

            comboBoxField.Items.Clear();
            comboBoxField.Items.Add("无");
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
                                comboBoxField.Items.Add(m_pFeatCls.Fields.get_Field(j).Name);
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
            saveFileDialog1.Filter = "Image Files (*.img)|*.img|All files (*.*)|*.*";

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
            IFeatureClass pFClass = null;
            if (bFeatDataPath == true)
            {
                fileName = comboBoxInData.Text;
                shpDir = fileName.Substring(0, fileName.LastIndexOf("\\"));
                startX = fileName.LastIndexOf("\\");
                endX = fileName.Length;
                shpFile = fileName.Substring(startX + 1, endX - startX - 1);
                pFClass = Utility.OpenFeatureClassFromShapefile(shpDir, shpFile);
            }
            else
            {
                pFClass = GetFeatureFromMapLyr(comboBoxInData.Text);
            }
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
                shpFile = "特征转栅格";
            }
            IGeoDataset pTempDS = pFClass as IGeoDataset;
            IFeatureLayer pFeatLayer = new FeatureLayerClass();
            pFeatLayer.FeatureClass = pFClass;

            IFeatureClassDescriptor pFeatClsDes = new FeatureClassDescriptorClass();
            if (comboBoxField.Text != "无")
                pFeatClsDes.Create(pFClass, null, comboBoxField.Text);
            else
                pFeatClsDes.Create(pFClass, null, "");
            pTempDS = pFeatClsDes as IGeoDataset;
            try
            {
                IConversionOp pConversionOp = new RasterConversionOpClass();
                string sCellSize = txtCellSize.Text;
                double dCellSize = Convert.ToDouble(sCellSize);
                pConversionOp = Utility.SetFeatToRasterAnalysisEnv(shpDir, dCellSize, pFeatLayer);
                if (File.Exists(shpDir + "\\" + shpFile + ".img") == true)
                    File.Delete(shpDir + "\\" + shpFile + ".img");
                IWorkspace pWS = Utility.setRasterWorkspace(shpDir);
                IRasterDataset pRasterDs = pConversionOp.ToRasterDataset(pTempDS, "IMAGINE Image", pWS, shpFile);
                ITemporaryDataset pTempRaster = pRasterDs as ITemporaryDataset;
                if (pTempRaster.IsTemporary() == true)
                    pTempRaster.MakePermanent();
                IRaster pOutRaster = pRasterDs.CreateDefaultRaster();
                IRasterLayer pRasterLayer = Utility.SetStretchRenderer(pOutRaster);
                pMainFrm.getMapControl().AddLayer(pRasterLayer, 0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void frmFeatureToRaster_Load(object sender, EventArgs e)
        {
            comboBoxField.Items.Add("无");
            PopulateComboWithMapLayers(comboBoxInData, true);
            txtCellSize.Text = pMainFrm.SAoption.RasterCellSize.ToString();
            txtOutPath.Text = pMainFrm.SAoption.AnalysisPath;
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
                        if (aLayer is IFeatureLayer)
                        {
                            Layers.Items.Add(aLayer.Name);
                        }
                    }

                }
            }
        }

    }
}