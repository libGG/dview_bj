using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Utility;
using ESRI.ArcGIS.NetworkAnalysis;
namespace Controls
{
    public partial class frmUpstreamCreateOwnerList : Form
    {
        private MainFrm pMainFrm = null;
        private IFeatureLayer pParcelFeatLayer;
        private IArray pFeatArray;
        public frmUpstreamCreateOwnerList(MainFrm _pMainFrm,IFeatureLayer _pParcelFeatLayer, IArray _pFeatArray)
        {
            pParcelFeatLayer = _pParcelFeatLayer;
            pFeatArray = _pFeatArray;
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }
        //上朔追踪列出所有地块
        private   void UpstreamCreateOwnerList(IFeatureLayer pParcelFeatLayer, IArray pFeatArray)
        {
           
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("物主", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("地址", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("街道", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("城市", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("邮编", 50, HorizontalAlignment.Center);

      　
            //在地块图层获得关系类
            IFeatureClass pFeatClass = pParcelFeatLayer.FeatureClass;
            IObjectClass pObjectClass = pFeatClass as IObjectClass;
            IEnumRelationshipClass pEnumRelationshipClass = pObjectClass.get_RelationshipClasses(esriRelRole.esriRelRoleOrigin);
            pEnumRelationshipClass.Reset();
            IRelationshipClass pRelationshipClass = pEnumRelationshipClass.Next();
            IRow pOwnerRow;
            for (int i = 0; i <= pFeatArray.Count - 1; i++)
            {
                IFeature pParcelFeature = pFeatArray.get_Element(i) as IFeature;
                ISet pRelatedSet = pRelationshipClass.GetObjectsRelatedToObject(pParcelFeature);
                pRelatedSet.Reset();
                 pOwnerRow = pRelatedSet.Next() as IRow ;
               
                 if (pOwnerRow != null)
                 {
                     ListViewItem item = new ListViewItem();
                        
                      item.SubItems.Clear();
                     item.SubItems[0].Text=pOwnerRow.get_Value(pOwnerRow.Fields.FindField("TMK")).ToString();
                   
                     item.SubItems.Add(pOwnerRow.get_Value(pOwnerRow.Fields.FindField("ADDR")).ToString());
                   
                     item.SubItems.Add(pOwnerRow.get_Value(pOwnerRow.Fields.FindField("STREET")).ToString());
                  
                     item.SubItems.Add(pOwnerRow.get_Value(pOwnerRow.Fields.FindField("CITY")).ToString());
                     
                     item.SubItems.Add(pOwnerRow.get_Value(pOwnerRow.Fields.FindField("ZIP")).ToString());

                     listView1.Items.Add(item);
                 }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmUpstreamCreateOwnerList_Load(object sender, EventArgs e)
        {
            UpstreamCreateOwnerList(pParcelFeatLayer, pFeatArray);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //在地块图层获得关系类
            IFeatureClass pFeatClass = pParcelFeatLayer.FeatureClass;
            IObjectClass pObjectClass = pFeatClass as IObjectClass;
            IEnumRelationshipClass pEnumRelationshipClass = pObjectClass.get_RelationshipClasses(esriRelRole.esriRelRoleOrigin);
            pEnumRelationshipClass.Reset();
            IRelationshipClass pRelationshipClass = pEnumRelationshipClass.Next();
            IRow pOwnerRow;
            IFeature pParcelFeature;
            AxMapControl axMap = pMainFrm.getMapControl();
            for (int i = 0; i <= pFeatArray.Count - 1; i++)
            {
                pParcelFeature = pFeatArray.get_Element(i) as IFeature;
                ISet pRelatedSet = pRelationshipClass.GetObjectsRelatedToObject(pParcelFeature);
                pRelatedSet.Reset();
                pOwnerRow = pRelatedSet.Next() as IRow;

                if (pOwnerRow != null)
                {                   
                    
                    if (pOwnerRow.get_Value(pOwnerRow.Fields.FindField("TMK")).ToString() == e.Item.Text)
                    {
                        Utility.FlashFeature(pParcelFeature, axMap.ActiveView.FocusMap);
                        break;
                    }                   

                }
            }
        }  

        
    }
}