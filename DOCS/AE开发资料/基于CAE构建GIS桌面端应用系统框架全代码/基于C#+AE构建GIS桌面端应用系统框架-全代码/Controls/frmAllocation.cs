using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geometry; 
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls; 
namespace Controls
{
    public partial class frmAllocation : Form
    {
        private MainFrm pMainFrm = null;
        private bool bDataPath = false;
        private IFeatureLayer m_pInFeatLyr = null;
        public frmAllocation(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
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
                        if (pLyr is IFeatureLayer)
                        {
                            m_pInFeatLyr = pLyr as IFeatureLayer ;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAllocation_Load(object sender, EventArgs e)
        {
            PopulateComboWithMapLayers(comboBoxInData, true);
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
                    shpFile = "·ÖÅäÕ¤¸ñ";
                }
                if (m_pInFeatLyr != null)
                {
                    double dCellSize = Convert.ToDouble(txtCellSize.Text);
                    double dMaxDis = Convert.ToDouble(txtMaxValue.Text);
                    object objMaxDis=dMaxDis;
                    object Missing = Type.Missing;	
                    IDistanceOp pDistanceOp = Utility.SetRasterDisAnalysisEnv(shpDir, dCellSize, m_pInFeatLyr);

                    IFeatureClass pInFeatCls = m_pInFeatLyr.FeatureClass;
                    IRaster pOutRaster = null;
                    IRasterLayer pRasterLayer = new RasterLayerClass();

                    pOutRaster = pDistanceOp.EucAllocation(pInFeatCls as IGeoDataset, ref objMaxDis,ref Missing ) as IRaster;

                    pRasterLayer.Name = shpFile;
                    Utility.ConvertRasterToRsDataset(shpDir, pOutRaster, shpFile);
                    pRasterLayer = Utility.SetRsLayerClassifiedColor(pOutRaster);
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
                        if (aLayer is IFeatureLayer )
                        {
                            Layers.Items.Add(aLayer.Name);
                        }
                    }

                }
            }
        }
    }
}