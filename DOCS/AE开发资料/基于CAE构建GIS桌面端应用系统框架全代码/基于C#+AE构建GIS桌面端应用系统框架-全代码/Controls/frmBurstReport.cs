using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls; 
namespace Controls
{
    public partial class frmBurstReport : Form
    {
        private MainFrm pMainFrm = null;
        private IFeatureLayer pFeatLayerValves = null;
        private IFeatureLayer pFeatLayerWaterLines = null;
        private IArray pArrayValves = null;
   
        private IFeature pFeatureWaterLine = null;
        public frmBurstReport(MainFrm _pMainFrm, IFeatureLayer _pFeatLayerValves, IFeatureLayer _pFeatLayerWaterLines, IArray  _pArrayValves, IFeature _pFeatureWaterLine)
        {
            pMainFrm = _pMainFrm;
            pFeatLayerValves = _pFeatLayerValves;
            pFeatLayerWaterLines = _pFeatLayerWaterLines;
            pArrayValves = _pArrayValves;
            pFeatureWaterLine = _pFeatureWaterLine;
          
            InitializeComponent();
        }
        //初始化树状列表控件
        private void InitTreeViewControl()
        {
            TreeNode node = null;
            node = treeView1.Nodes.Add("爆管的线路");
            //列出爆管的线路
            IFields pFields = pFeatureWaterLine.Fields;
            node.Nodes.Add(pFeatureWaterLine.get_Value(pFields.FindField("WATER_ID")).ToString());
            node = treeView1.Nodes.Add("受影响的阀门");
            //列出所有受到影响的阀门
            int field1=0;
            
            for (int i = 0; i <= pArrayValves.Count - 1; i++)
            {
                IFeature pValveFeature = pArrayValves.get_Element(i) as IFeature;
                pFields = pValveFeature.Fields;
                node.Nodes.Add(pValveFeature.get_Value(pFields.FindField("WATER_ID")).ToString());
            }

            
        }

        private void frmBurstReport_Load(object sender, EventArgs e)
        {
            InitTreeViewControl();
        }
        //获得阀门的属性字段和信息
        private void GetValves(IFeature pFeature, out string var1, out string var2, out string var3)
        {
            IFields pFields = pFeature.Fields;
            ISubtypes pWaterPtSubtypes = pFeatLayerValves.FeatureClass as ISubtypes;
            var1=pFeature.get_Value(pFields.FindField("WATER_ID")).ToString();
            var2=pFeature.get_Value(pFields.FindField("PWV_TYPE")).ToString();
            var3=pFeature.get_Value(pFields.FindField("PWSHEETNO")).ToString();
            IRowSubtypes pRowSubtypes = pFeature as IRowSubtypes;
            if(pRowSubtypes!=null)
            {
                IDomain pDomain=pWaterPtSubtypes.get_Domain(pRowSubtypes.SubtypeCode, "PWV_TYPE");
                if(pDomain!=null)
                {
                    ICodedValueDomain pCodedValDomain = pDomain as ICodedValueDomain;
                    for(int i=0;i<=pCodedValDomain.CodeCount-1;i++)
                    {
                        if(pCodedValDomain.get_Value(i).ToString()==var2)
                        {
                            var2=pCodedValDomain.get_Name(i).ToString();
                        }
                    }
                }
            }
        }
        //获得管线的属性字段和信息
        private void GetWaterLineValue(out string var1, out string var2, out string var3, out string var4, out string var5)
        {
            IFields pFields = pFeatureWaterLine.Fields;
            var1 = pFeatureWaterLine.get_Value(pFields.FindField("WATER_ID")).ToString();
            var2 = pFeatureWaterLine.get_Value(pFields.FindField("PIPEUSE_CODE")).ToString();
            var3 = pFeatureWaterLine.get_Value(pFields.FindField("SHAPE_LENGTH")).ToString();
            var4 = pFeatureWaterLine.get_Value(pFields.FindField("PWDIAM")).ToString();
            var5 = pFeatureWaterLine.get_Value(pFields.FindField("PWMATERIAL")).ToString();
            //根据子类型代码获得子类型名称
            ISubtypes  pWaterLineSubtypes=pFeatLayerWaterLines.FeatureClass as ISubtypes ;
            IRowSubtypes pRowSubtypes = pFeatureWaterLine as IRowSubtypes;
            if (pRowSubtypes != null)
            {
                var2 = pWaterLineSubtypes.get_SubtypeName(pRowSubtypes.SubtypeCode);
                //获取属性域             
                IDomain pDomain=pWaterLineSubtypes.get_Domain(pRowSubtypes.SubtypeCode, "PWMATERIAL");
                if(pDomain!=null)
                {
                    ICodedValueDomain pCodedValDomain = pDomain as ICodedValueDomain;
                    for (int i = 0; i <= pCodedValDomain.CodeCount - 1; i++)
                    {
                        if (pCodedValDomain.get_Value(i) == var5)
                        {
                            var5 = pCodedValDomain.get_Name(i);
                        }
                    }
                }

            
                }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListViewItem item;
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("属性信息", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("数值", 150, HorizontalAlignment.Left);

          
            IFields pFields;
            int field1 = 0;
            string var1,var2,var3,var4,var5;
            try
            {
                 
                    if (e.Node.IsExpanded == true)
                    {
                        if (e.Node.Text.Trim() == "爆管的线路")
                        {
                            
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        if (e.Node.Parent.Text.Trim() == "爆管的线路")
                        {
                            if (pFeatureWaterLine != null)
                            {
                                GetWaterLineValue(out var1, out var2, out var3, out var4, out var5);
                                item = listView1.Items.Add("WATER_ID");
                                item.SubItems.Add(var1);
                                item = listView1.Items.Add("PIPEUSE_CODE");
                                item.SubItems.Add(var2);
                                item = listView1.Items.Add("SHAPE_LENGTH");
                                item.SubItems.Add(var3);
                                item = listView1.Items.Add("PWDIAM");
                                item.SubItems.Add(var4);
                                item = listView1.Items.Add("PWMATERIAL");
                                item.SubItems.Add(var5);
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= pArrayValves.Count - 1; i++)
                            {
                                IFeature pValveFeature = pArrayValves.get_Element(i) as IFeature;
                                pFields = pValveFeature.Fields;
                                GetValves(pValveFeature, out var1, out var2, out var3);
                                item = listView1.Items.Add("WATER_ID");
                                item.SubItems.Add(var1);
                                item = listView1.Items.Add("PWV_TYPE");
                                item.SubItems.Add(var2);
                                item = listView1.Items.Add("PWSHEETNO");
                                item.SubItems.Add(var3);
                            
                            }
                          
                        }
                    }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}