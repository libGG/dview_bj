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
using ESRI.ArcGIS.NetworkAnalyst;
namespace Controls
{
    public partial class frmLoadNetworkData : Form
    {
        private MainFrm pMainFrm = null;         
        private bool bDataPath = false;
        private IFeatureLayer m_pInFeatLyr = null;
        private TreeNode  NodeSelected;
        public frmLoadNetworkData(MainFrm _pMainFrm, TreeNode _SelectedNode)
        {
            pMainFrm = _pMainFrm;
            NodeSelected = _SelectedNode;
             
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pMainFrm.SAoption.AnalysisPath;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBoxDataList.Text = openFileDialog1.FileName;
            }
            bDataPath = true;
        }

        private void comboBoxDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sLayerName = comboBoxDataList.Text;
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
                            m_pInFeatLyr = pLyr as IFeatureLayer;

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

        private void frmLoadNetworkData_Load(object sender, EventArgs e)
        {
            PopulateComboWithMapLayers(comboBoxDataList, true);
            comboBoxUnits.Items.Clear();
            comboBoxUnits.Items.Add("��");
            comboBoxUnits.Text = "��";

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IFeatureCursor pFeatCursor=m_pInFeatLyr.FeatureClass.Search(new QueryFilterClass(),true);
            IFeature pFeature=pFeatCursor.NextFeature();
            TreeView treeView1 = pMainFrm.getTreeViewControl();
            NodeSelected.Nodes.Clear();
                           
            while (pFeature != null)
            {
                NodeSelected.Nodes.Add(pFeature.get_Value(m_pInFeatLyr.FeatureClass.FindField("Name")).ToString());
                pFeature = pFeatCursor.NextFeature();
            }
            treeView1.Refresh();
            //��ʼװ������
            if (pMainFrm.strNetAnalystContext == "�ٽ���ʩ")
            {
                switch (NodeSelected.Text)
                {
                    case "��ʩ":
                        LoadNANetworkLocations("Facilities", m_pInFeatLyr.FeatureClass, Convert.ToDouble(textBoxTolerance.Text));
                        break;
                    case "�¹�":
                        LoadNANetworkLocations("Incidents", m_pInFeatLyr.FeatureClass, Convert.ToDouble(textBoxTolerance.Text));
                        break;
                    case "�ϰ�":
                        LoadNANetworkLocations("Barriers", m_pInFeatLyr.FeatureClass, Convert.ToDouble(textBoxTolerance.Text));
                        break;
                }
             
            }
            if (pMainFrm.strNetAnalystContext == "���·��")
            {
                switch (NodeSelected.Text)
                {
                    case "·��":
                        LoadNANetworkLocations("Routes", m_pInFeatLyr.FeatureClass, Convert.ToDouble(textBoxTolerance.Text));
                        break;
                    case "�¹�":
                        LoadNANetworkLocations("Stops", m_pInFeatLyr.FeatureClass, Convert.ToDouble(textBoxTolerance.Text));
                        break;
                    case "�ϰ�":
                        LoadNANetworkLocations("Barriers", m_pInFeatLyr.FeatureClass, Convert.ToDouble(textBoxTolerance.Text));
                        break;
                }

            }

        }
        //װ���������Ԫ�ص�λ��
        private void LoadNANetworkLocations(string strNAClassName, IFeatureClass inputFC, double snapTolerance)
        {
            try
            {
            INAClass naClass;
            INamedSet classes;
            classes =pMainFrm.m_NAContext.NAClasses;
            naClass = classes.get_ItemByName(strNAClassName) as INAClass;

            // delete existing Locations except if that a barriers
            naClass.DeleteAllRows();

            // Create a NAClassLoader and set the snap tolerance (meters unit)
            INAClassLoader classLoader = new NAClassLoader();
            classLoader.Locator = pMainFrm.m_NAContext.Locator;
            if (snapTolerance > 0) classLoader.Locator.SnapTolerance = snapTolerance;
            classLoader.NAClass = naClass;

            //Create field map to automatically map fields from input class to naclass
            INAClassFieldMap fieldMap;
            fieldMap = new NAClassFieldMap();
            fieldMap.CreateMapping(naClass.ClassDefinition, inputFC.Fields);
            classLoader.FieldMap = fieldMap;

            //Load Network Locations
            int rowsIn = 0;
            int rowsLocated = 0;
            IFeatureCursor featureCursor = inputFC.Search(null, true);
            classLoader.Load((ICursor)featureCursor, null, ref rowsIn, ref rowsLocated);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);

        }  
        }
        
        //��ʼ��Ҫѡ��װ�ص�����ͼ������
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
                            IFeatureLayer pFeatLyr = aLayer as IFeatureLayer;
                            if (pFeatLyr.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                                Layers.Items.Add(aLayer.Name);
                        }
                    }

                }
            }
        }

       ��
    }
}