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
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
namespace Controls
{
    public partial class frmCellStatistic : Form
    {
        private MainFrm pMainFrm = null;
        private bool bDataPath = false;
        public frmCellStatistic(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;
            saveFileDialog1.Filter = "Grid Files (*.grid)|*.grid|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutData.Text = saveFileDialog1.FileName;
            }
            bDataPath = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmCellStatistic_Load(object sender, EventArgs e)
        {
            PopulateListBoxWithMapLayers(listBoxLayer, true);
            comboBoxMethod.Items.Clear();
            comboBoxMethod.Items.Add("Majority");
            comboBoxMethod.Items.Add("Maximum");
            comboBoxMethod.Items.Add("Mean");
            comboBoxMethod.Items.Add("Median");
            comboBoxMethod.Items.Add("Minimum");
            comboBoxMethod.Items.Add("Minority");
            comboBoxMethod.Items.Add("Range");
            comboBoxMethod.Items.Add("Standard Deviation");
            comboBoxMethod.Items.Add("Sum");
            comboBoxMethod.Items.Add("Variety");
            txtOutData.Text = pMainFrm.SAoption.AnalysisPath;
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
             string fileName;
            string shpFile;
            int startX, endX;
            string shpDir;
          　
                if (bDataPath == true)
                {
                    fileName = txtOutData.Text;
                    shpDir = fileName.Substring(0, fileName.LastIndexOf("\\"));
                    startX = fileName.LastIndexOf("\\");
                    endX = fileName.Length;
                    shpFile = fileName.Substring(startX + 1, endX - startX - 1);
                }
                else
                {
                    shpDir = txtOutData.Text;
                    shpFile = "象素统计栅格";
                }
            try
            {
               IRasterBandCollection pLocalCollection=new  RasterClass();
                ILocalOp pLocalOp=new RasterLocalOpClass();
                for (int i = 0; i <= listBoxAddedLayer.Items.Count - 1; i++)
                {
                    IRaster pInRaster=GetRSLyrFromMapLyr(listBoxAddedLayer.Items[i].ToString().Trim());
                    IRasterDataset pRasterGeo = pInRaster as IRasterDataset;
                    pLocalCollection.AppendBand(pRasterGeo as IRasterBand );   
                }
                string sMethod = comboBoxMethod.Text;
                IRasterLayer pRasterLayer = new RasterLayerClass();
                IRaster pOutRaster = null;
                switch (sMethod)
                {
                    case "Majority":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsMajority) as IRaster;
                        break;
                    case "Maximum":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsMaximum) as IRaster;
                        break;
                    case "Mean":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsMean) as IRaster;
                        break;
                    case "Median":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsMedian) as IRaster;
                        break;
                    case "Minimum":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsMinimum ) as IRaster;
                        break;
                    case "Minority":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsMinority ) as IRaster;
                        break;
                    case "Range":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsRange ) as IRaster;
                        break;
                    case "Standard Deviation":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsStd ) as IRaster;
                        break;
                    case "Sum":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsSum ) as IRaster;
                        break;
                    case "Variety":
                        pOutRaster = pLocalOp.LocalStatistics(pLocalCollection as IGeoDataset, esriGeoAnalysisStatisticsEnum.esriGeoAnalysisStatsVariety) as IRaster;
                        break;
                }
                pRasterLayer.Name = "象素统计栅格";
                Utility.ConvertRasterToRsDataset(shpDir, pOutRaster, "象素统计栅格");
                pRasterLayer = Utility.SetStretchRenderer(pOutRaster);
                pMainFrm.getMapControl().AddLayer(pRasterLayer, 0);
                 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }
        //从地图图层中获得栅格数据图层
        private IRaster GetRSLyrFromMapLyr(string sLyrName)
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            IRaster pRs = null;

            for (int i = 0; i <= axMap.LayerCount - 1; i++)
            {
                ILayer pLyr = axMap.get_Layer(i);
                if (pLyr != null)
                {
                    if (pLyr.Name == sLyrName)
                    {
                        if (pLyr is IRasterLayer)
                        {
                            IRasterLayer pRLyr = pLyr as IRasterLayer;
                            pRs = pRLyr.Raster;
                        }
                    }
                }
            }
            return pRs;
        }
        private void PopulateListBoxWithMapLayers(ListBox  Layers, bool bLayer)
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

        private void btnRightOne_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                if (listBoxLayer.Items.Count == 0 || listBoxLayer.SelectedIndex == -1)
                {
                }
                else
                {
                    listBoxAddedLayer.SelectedIndex = listBoxAddedLayer.Items.Add(listBoxLayer.Text);
                    i = listBoxLayer.SelectedIndex;
                    listBoxLayer.Items.RemoveAt(listBoxLayer.SelectedIndex);
                    if (listBoxLayer.Items.Count > 0)
                    {
                        if (i > listBoxLayer.Items.Count - 1)
                            listBoxLayer.SelectedIndex = i - 1;
                        else
                            listBoxLayer.SelectedIndex = i;

                    }
                }
            }
            catch (Exception ex)
            {
               

            }
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= listBoxLayer.Items.Count - 1; i++)
            {
                listBoxAddedLayer.Items.Add(listBoxLayer.Items[i].ToString());
            }
            listBoxLayer.Items.Clear();
            listBoxAddedLayer.SelectedIndex = 0;
        }

        private void btnLeftOne_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (listBoxAddedLayer.Items.Count == 0 || listBoxAddedLayer.SelectedIndex == -1)
            {
            }
            else
            {
                listBoxLayer.SelectedIndex = listBoxLayer.Items.Add(listBoxAddedLayer.Text);
                i = listBoxAddedLayer.SelectedIndex;
                listBoxAddedLayer.Items.RemoveAt(i);
                if (listBoxAddedLayer.Items.Count > 0)
                {
                    if (i > listBoxAddedLayer.Items.Count - 1)
                        listBoxAddedLayer.SelectedIndex = i - 1;
                    else
                        listBoxAddedLayer.SelectedIndex = i;
                }
            }
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= listBoxAddedLayer.Items.Count - 1; i++)
            {
                listBoxLayer.Items.Add(listBoxAddedLayer.Items[i].ToString());
            }
            listBoxAddedLayer.Items.Clear();
            listBoxLayer.SelectedIndex = listBoxLayer.Items.Count - 1;

        }
    }
}