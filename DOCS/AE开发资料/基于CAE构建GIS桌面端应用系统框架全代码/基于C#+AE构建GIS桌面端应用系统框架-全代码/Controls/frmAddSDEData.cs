using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Server;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;

namespace Controls
{
    public partial class frmAddSDEData : Form
    {
        private IWorkspaceFactory m_pWorkspaceFactory;
        private IPropertySet m_pPropSet;
        private IFeatureWorkspace m_pFeatureWorkspace;
        private IWorkspace m_pWorkspace;
        private IVersionedWorkspace m_pVersionedWorkspace;
        private bool isSelectNode;
        private string m_strSelFeatLayer;
         private MainFrm pMainFrm = null;
        private IGeoDataset pGeoDataset = null;
        public frmAddSDEData(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            isSelectNode = false;
            InitializeComponent();
        }

        private void btnConnectSDE_Click(object sender, EventArgs e)
        {
            TestConnectSDEData(txtSDEServer.Text, txtSDEService.Text, txtSDEDatabase.Text, txtUser.Text, txtPassword.Text, labelVersion.Text);
        }
        private void TestConnectSDEData(string server, string instance,string database, string user, string password, string version)
        {
            try
            {
                m_pWorkspaceFactory = new  SdeWorkspaceFactoryClass();
                m_pPropSet = new PropertySetClass();
                //设置ＳＤＥ连接属性信息
                m_pPropSet.SetProperty("SERVER", server);
                m_pPropSet.SetProperty("INSTANCE", instance);
                m_pPropSet.SetProperty("Database", database);
                m_pPropSet.SetProperty("User", user);
                m_pPropSet.SetProperty("password", password);
                m_pPropSet.SetProperty("version", version);
                m_pWorkspace = m_pWorkspaceFactory.Open(m_pPropSet, 0);
                m_pFeatureWorkspace = m_pWorkspace as  IFeatureWorkspace;
                /////////////////////////////////////////////////////////
                IEnumDatasetName pEnumDSName = m_pWorkspace.get_DatasetNames(esriDatasetType.esriDTFeatureDataset);
                IDatasetName pSDEDsName = pEnumDSName.Next();
                treeView1.Nodes.Clear();
                TreeNode node1;
                while (pSDEDsName != null)
                {
                    node1=treeView1.Nodes.Add(pSDEDsName.Name);
                    LoadAllFeatClass(node1,pSDEDsName.Name );
                    pSDEDsName = pEnumDSName.Next();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        //创建一个新的地理数据集
        private void CreateFeatureDataset()
        {
           try
           {
               
            ISpatialReference pSpatialRef = pGeoDataset.SpatialReference;            
            m_pFeatureWorkspace.CreateFeatureDataset("aa", pSpatialRef);        
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);

        }

        }
        private void LoadAllFeatClass(TreeNode node1, string sDatasetName)
        {
            try
            {
                IFeatureDataset pFeatDS = m_pFeatureWorkspace.OpenFeatureDataset(sDatasetName);
                pGeoDataset = pFeatDS as IGeoDataset;
                IEnumDataset pEnumDataset = pFeatDS.Subsets;
                IDataset pDataset = pEnumDataset.Next();
                while (pDataset != null)
                {
                    if (pDataset.Type == esriDatasetType.esriDTFeatureClass)
                    {
                        node1.Nodes.Add(pDataset.Name);

                    }
                    pDataset = pEnumDataset.Next();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.IsExpanded == true)
                {
                   
                    isSelectNode = false;
                }
                else
                {
                    m_strSelFeatLayer = e.Node.Text;
                    isSelectNode = true;
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (isSelectNode == true)
            {
                IFeatureClass pFeatCls = m_pFeatureWorkspace.OpenFeatureClass(m_strSelFeatLayer);
                IFeatureLayer pFeatLayer = new FeatureLayerClass();
                pFeatLayer.FeatureClass = pFeatCls;
                pFeatLayer.Visible = true;
                pFeatLayer.Name = pFeatCls.AliasName;
                AxMapControl axMap = pMainFrm.getMapControl();
                axMap.AddLayer(pFeatLayer);
                axMap.Refresh();
            }
        }

        private void btnModifyVersion_Click(object sender, EventArgs e)
        {
            if (m_pWorkspace != null)
            {
                if (m_pWorkspace.Type == esriWorkspaceType.esriRemoteDatabaseWorkspace)
                {
                    if (m_pWorkspace is IVersionedWorkspace)
                    {
                        m_pVersionedWorkspace = m_pWorkspace as IVersionedWorkspace;
                    }
                }
            }
            //打开版本修改界面
            if (m_pVersionedWorkspace != null)
            {
                frmChangeVersion frmChangeVersion1 = new frmChangeVersion(m_pVersionedWorkspace);
                frmChangeVersion1.Show();
            }
        }

      

        
       
    }
}