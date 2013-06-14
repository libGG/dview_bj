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
    public partial class frmCutFill : Form
    {
        private MainFrm pMainFrm = null;
        private IRasterLayer m_pInBRsLyr = null;
        private IRasterLayer m_pInARsLyr = null;
        private bool bDataPath = false;
        public frmCutFill(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }

        private void btnOpenBRaster_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenARaster_Click(object sender, EventArgs e)
        {

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
            bDataPath = true;
        }

        private void comboBoxInBData_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sLayerName = comboBoxInBData.Text;
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
                            m_pInBRsLyr = pLyr as IRasterLayer;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void comboBoxInAData_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sLayerName = comboBoxInAData.Text;
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
                            m_pInARsLyr = pLyr as IRasterLayer;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void frmCutFill_Load(object sender, EventArgs e)
        {
            PopulateComboWithMapLayers(comboBoxInBData, true);
            PopulateComboWithMapLayers(comboBoxInAData, true);
            txtCellSize.Text = pMainFrm.SAoption.RasterCellSize.ToString();
            txtOutPath.Text = pMainFrm.SAoption.AnalysisPath;
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
                    shpFile = "ÌîÍÚ·½Á¿";
                }
                if ((m_pInBRsLyr != null) && (m_pInARsLyr!=null))
                {
                    double dCellSize = Convert.ToDouble(txtCellSize.Text);
                    ISurfaceOp pRasterSurfaceOp = Utility.SetRasterSurfaceAnalysisEnv(shpDir, dCellSize);
                    double dZFactor=Convert.ToDouble(txtZFactor.Text);
                    object objZFactor=dZFactor;
                    IRaster pInBRaster = m_pInBRsLyr.Raster;
                    IRaster pInARaster = m_pInARsLyr.Raster;
                    IRaster pOutRaster = null;
                    IRasterLayer pRasterLayer = new RasterLayerClass();

                    pOutRaster = pRasterSurfaceOp.CutFill(pInBRaster as IGeoDataset , pInARaster as IGeoDataset , ref objZFactor) as IRaster;

                    pRasterLayer.Name = shpFile;
                    Utility.ConvertRasterToRsDataset(shpDir, pOutRaster, shpFile);
                    pRasterLayer = Utility.SetCutFillRenderer(pOutRaster,"Value",shpDir);
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

      

      
    }
}