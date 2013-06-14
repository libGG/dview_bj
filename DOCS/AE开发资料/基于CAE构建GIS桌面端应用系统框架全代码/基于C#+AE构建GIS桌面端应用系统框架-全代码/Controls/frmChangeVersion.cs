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
namespace Controls
{
    public partial class frmChangeVersion : Form
    {
        private IVersionedWorkspace pVersionedWorkspace = null;
        private IVersionInfo m_pVersionInfo = null;
        public frmChangeVersion(IVersionedWorkspace _pVersionedWorkspace)
        {
            pVersionedWorkspace = _pVersionedWorkspace;
            InitializeComponent();
        }

        private void frmChangeVersion_Load(object sender, EventArgs e)
        {

        }
        private void LoadVersionTree()
        {
            treeViewVersion.Nodes.Clear();           
        }
        private void AddVersionToTree(IVersionInfo pVersionInfo, TreeNode pParentNode)
        {
            IEnumVersionInfo pEnumVersionInfo;
            TreeNode pNode;
            if (pParentNode == null)
                pNode = treeViewVersion.Nodes.Add(pVersionInfo.VersionName, pVersionInfo.VersionName);
            pEnumVersionInfo=pVersionInfo.Children;
            pVersionInfo=pEnumVersionInfo.Next();
            


        }
    }
}