using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
 
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Carto;
namespace Controls
{
    public partial class frmViewshed : Form
    {
        private MainFrm pMainFrm = null;
        private bool bInDataPath = false;
        private bool bOutDataPath = false;
        private IRasterLayer m_pRasterLyr = null;
        private IFeatureLayer m_pFeatLyr = null;
        public frmViewshed(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }

        private void btnOpenRaster_Click(object sender, EventArgs e)
        {


        }

        private void btnOpenFeat_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBoxOPosition.Text = openFileDialog1.FileName;
            }
            bInDataPath = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
            saveFileDialog1.Filter = "IMAGINE Files (*.img)|*.img|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutPath.Text = saveFileDialog1.FileName;
            }
            bOutDataPath = true;
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
            try
            {
                if (bOutDataPath == true)
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
                    shpFile = "Õ® ”∑÷Œˆ";
                }
                if ((m_pRasterLyr != null) && (m_pFeatLyr !=null))
                {
                    double dCellSize = Convert.ToDouble(txtCellSize.Text);
                    ISurfaceOp pRasterSurfaceOp = Utility.SetRasterSurfaceAnalysisEnv(shpDir, dCellSize);

                    IRaster pInRaster = m_pRasterLyr.Raster;
                    IFeatureClass pInFeatCls=m_pFeatLyr.FeatureClass;
                    IRaster pOutRaster = null;
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    if(chkEarthCurve.Checked==false)
                        pOutRaster = pRasterSurfaceOp.Visibility(pInRaster as IGeoDataset, pInFeatCls as IGeoDataset,esriGeoAnalysisVisibilityEnum.esriGeoAnalysisVisibilityObservers) as IRaster;
                    else 
                        pOutRaster = pRasterSurfaceOp.Visibility(pInRaster as IGeoDataset, pInFeatCls as IGeoDataset, esriGeoAnalysisVisibilityEnum.esriGeoAnalysisVisibilityObserversUseCurvature) as IRaster;

                    pRasterLayer.Name = shpFile;
                    Utility.ConvertRasterToRsDataset(shpDir, pOutRaster, shpFile);
                    pRasterLayer = Utility.SetViewShedRenderer(pOutRaster, "Value", shpDir);
                    pMainFrm.getMapControl().AddLayer(pRasterLayer, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void frmViewshed_Load(object sender, EventArgs e)
        {
            PopulateComboWithMapLayers(comboBoxInData, false);
            PopulateComboWithMapLayers(comboBoxOPosition, true);
            txtCellSize.Text = pMainFrm.SAoption.RasterCellSize.ToString();
            txtOutPath.Text = pMainFrm.SAoption.AnalysisPath;

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
                            IFeatureLayer pFeatLayer = aLayer as IFeatureLayer;
                            if (pFeatLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolygon)
                                Layers.Items.Add(aLayer.Name);
                        }
                    }
                    else                         
                    {
                        if (aLayer is IRasterLayer)
                        {
                            Layers.Items.Add(aLayer.Name);
                        }

                    }

                }
            }
        }

        private void comboBoxInData_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sLayerName = comboBoxInData.Text;
            AxMapControl axMap = pMainFrm.getMapControl();


            try
            {
                for (int i = 0; i <= axMap.LayerCount - 1; i++)
                {
                    ILayer pLyr = axMap.get_Layer(i);
                    if (pLyr.Name == sLayerName)
                    {
                        if (pLyr is IRasterLayer)
                        {
                            m_pRasterLyr = pLyr as IRasterLayer;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void comboBoxOPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sLayerName = comboBoxOPosition.Text;
            AxMapControl axMap = pMainFrm.getMapControl();


            try
            {
                for (int i = 0; i <= axMap.LayerCount - 1; i++)
                {
                    ILayer pLyr = axMap.get_Layer(i);
                    if (pLyr.Name == sLayerName)
                    {
                        if (pLyr is IFeatureLayer )
                        {
                            m_pFeatLyr  = pLyr as IFeatureLayer;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}