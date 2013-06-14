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
    public partial class frmHillShade : Form
    {
        private MainFrm pMainFrm = null;
        private bool bDataPath = false;
        private IRasterLayer m_pRasterLyr = null;
        public frmHillShade(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBoxInData.Text = openFileDialog1.FileName;
            }
        }

        private void frmHillShade_Load(object sender, EventArgs e)
        {
            PopulateComboWithMapLayers(comboBoxInData, true);
            txtOutPath.Text = pMainFrm.SAoption.AnalysisPath;
            txtCellSize.Text = pMainFrm.SAoption.RasterCellSize.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
            saveFileDialog1.Filter = "IMAGING Files (*.img)|*.img|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutPath.Text = saveFileDialog1.FileName;
            }
            bDataPath = true;
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
                if (bDataPath == true)
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
                    shpFile = "…ΩÃÂ“ı”∞";
                }
                if (m_pRasterLyr != null)
                {
                    double dCellSize = Convert.ToDouble(txtCellSize.Text);
                    double dAzimuth=Convert.ToDouble(txtAzimuth.Text);
                    double dAltitude=Convert.ToDouble(txtAltitude.Text);
                    bool bModel=chkModelShadow.Checked;
                    double dZFactor=Convert.ToDouble(txtZFactor.Text);
                    object objZFactor=dZFactor;
                    ISurfaceOp pRasterSurfaceOp = Utility.SetRasterSurfaceAnalysisEnv(shpDir, dCellSize);
                    IRaster pInRaster = m_pRasterLyr.Raster;
                    IRaster pOutRaster = null;
                    IRasterLayer pRasterLayer = new RasterLayerClass();

                    pOutRaster = pRasterSurfaceOp.HillShade(pInRaster as IGeoDataset,dAzimuth,dAltitude,bModel,ref objZFactor) as IRaster;

                    pRasterLayer.Name = shpFile;
                    Utility.ConvertRasterToRsDataset(shpDir, pOutRaster, shpFile);
                    pRasterLayer = Utility.SetStretchRenderer(pOutRaster);
                    pMainFrm.getMapControl().AddLayer(pRasterLayer, 0);
                }
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
    }
}