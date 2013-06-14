using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase; 
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.GeoAnalyst;
namespace Controls
{
    public partial class frmContour : Form
    {
        private MainFrm pMainFrm = null;
        private bool bDataPath = false;
        private IRasterLayer m_pRasterLyr = null;
        public frmContour(MainFrm _pMainFrm)
        {
            pMainFrm=_pMainFrm;
            InitializeComponent();
        }

        private void btnOpenData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBoxInputData.Text = openFileDialog1.FileName;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
            saveFileDialog1.Filter = "Shapefiles (*.shp)|*.shp|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutputData.Text = saveFileDialog1.FileName;
            } 
            bDataPath = true;
        }

        private void frmContour_Load(object sender, EventArgs e)
        {
            PopulateComboWithMapLayers(comboBoxInputData, true);
            
            txtOutputData.Text = pMainFrm.SAoption.AnalysisPath;

        }

        private void comboBoxInputData_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sLayerName = comboBoxInputData.Text;
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
                            IRaster pInRaster = m_pRasterLyr.Raster ;
                            RasterStatistics(pInRaster);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void RasterStatistics(IRaster pInRaster)
        {
            
            IRasterBandCollection pRasterBands=pInRaster as IRasterBandCollection;
            IRasterBand pRasterBand=null;
            if (pRasterBands.Count > 0)
            {
                pRasterBand = pRasterBands.Item(0);
                IRasterStatistics pRasterStat = pRasterBand.Statistics;
                double dZMax = pRasterStat.Maximum;
                double dZMin = pRasterStat.Minimum;
                lblZMax.Text = dZMax.ToString();
                lblZMin.Text = dZMin.ToString();
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
                    fileName=txtOutputData.Text;
                    shpDir =fileName.Substring(0, fileName.LastIndexOf("\\")); 
                    startX=fileName.LastIndexOf("\\");
                    endX=fileName.Length;
                    shpFile=fileName.Substring(startX+1,endX-startX-1);
                }
                else
                {
                    shpDir=txtOutputData.Text;
                    shpFile="µÈÖµÏß";
                }
                if (m_pRasterLyr != null)
                {
                    double dInterval=Convert.ToDouble(txtConInterval.Text);
                    double dBaseLine=Convert.ToDouble(txtBaseLine.Text);
                    object objBaseLine=dBaseLine;
                    ISurfaceOp pRasterSurfaceOp = new RasterSurfaceOpClass();
                    IRaster pInRaster = m_pRasterLyr.Raster;
                    IFeatureClass  pOutFClass= pRasterSurfaceOp.Contour(pInRaster as IGeoDataset , dInterval, ref objBaseLine) as IFeatureClass ;
                    //2. QI to IDataset
                    IDataset pFDS=pOutFClass as IDataset ;
                    //3. Get a shapefile workspace
                    IWorkspaceFactory pSWF=new  ShapefileWorkspaceFactoryClass();
                    IFeatureWorkspace pFWS=pSWF.OpenFromFile(shpDir,0) as IFeatureWorkspace ;
                    //4. Copy contour output to a new shapefile
                    IWorkspace pWS = pFWS as IWorkspace;
                    if (pWS.Exists() == true)
                        Utility.DelFeatureFile(shpDir, shpFile + ".shp");
                    pFDS.Copy(shpFile,pFWS as IWorkspace );
                    IFeatureLayer pFeatLyr = new FeatureLayerClass();
                    pFeatLyr.FeatureClass = pOutFClass;
                    pFeatLyr.Name = pOutFClass.AliasName;
                    pFeatLyr.Visible = true;
                    pMainFrm.getMapControl().AddLayer(pFeatLyr, 0);	
                }
            }
             
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}