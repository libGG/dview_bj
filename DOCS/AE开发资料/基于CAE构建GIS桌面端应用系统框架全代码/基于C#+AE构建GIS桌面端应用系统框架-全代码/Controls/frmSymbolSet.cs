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
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
namespace Controls
{
    public partial class frmSymbolSet : Form
    {
        private int [,] m_intColorRampArray;
        private MainFrm pMainFrm = null;
        private IFeatureLayer pFeatLayer = null;
        private ComboBoxEx comboBox1;
        private int m_intSymbolsNum;
        private string m_strShapeType;
        private IArray m_pSymbolsArray;
        private IArray m_colValues;
        public frmSymbolSet(MainFrm _pMainFrm,IFeatureLayer _pFeatLayer)
        {
            pMainFrm = _pMainFrm;
            pFeatLayer = _pFeatLayer;
            InitializeComponent();
        }

        private void frmSymbolSet_Load(object sender, EventArgs e)
        {
            m_strShapeType = GetLayerShapeType(pFeatLayer);
            InitTreeView();
            InitComboFieldUnique();
            InitComboColorUnique();
            InitUniqueColorRamp();
        }
        //初始化符号设置方法分类列表
        private void InitTreeView()
        {
            TreeNode node = null;
            treeView1.Nodes.Clear();
            node = treeView1.Nodes.Add("单值图");           
            node=treeView1.Nodes.Add("分类图");
            node = treeView1.Nodes.Add("密度图");
            node = treeView1.Nodes.Add("图表");
            node.Nodes.Add("饼图");
            node.Nodes.Add("柱状图");
            node.Nodes.Add("直方图");
        }
        //初始化字段下拉列表控件
        private void InitComboFieldUnique()
        {
            m_intSymbolsNum = -1;
            //初始化单值图的字段信息
            comboBoxUnique.Items.Clear();
            IFields pFields = pFeatLayer.FeatureClass.Fields;
            for (int i = 0; i <= pFields.FieldCount - 1; i++)
            {
                IField pField = pFields.get_Field(i);
                comboBoxUnique.Items.Add(pField.Name);
            }
        }
        //初始化颜色图片下拉列表控件
        private void InitComboColorUnique()
        {

            comboBoxEx1.ImageList = this.imageListUnique;
            comboBoxEx1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEx1.Items.Clear();
            for(int i=0;i<=imageListUnique.Images.Count-1;i++)
            {
                comboBoxEx1.Items.Add(new ComboxBoxExItem("",i));
            }
            comboBoxEx1.Width = 180;

        }
        //初始化单值图的色带
        private void InitUniqueColorRamp()
        {
           m_intColorRampArray=new int[3,6];
           m_intColorRampArray[0, 0] = 0;
           m_intColorRampArray[0, 1] = 360;
           m_intColorRampArray[0, 2] = 50;
           m_intColorRampArray[0, 3] = 100;
           m_intColorRampArray[0, 4] = 10;
           m_intColorRampArray[0, 5] = 60;

           m_intColorRampArray[1, 0] = 30;
           m_intColorRampArray[1, 1] = 30;
           m_intColorRampArray[1, 2] = 0;
           m_intColorRampArray[1, 3] = 50;
           m_intColorRampArray[1, 4] = 10;
           m_intColorRampArray[1, 5] = 20;

           m_intColorRampArray[2, 0] = 60;
           m_intColorRampArray[2, 1] = 160;
           m_intColorRampArray[2, 2] = 20;
           m_intColorRampArray[2, 3] = 100;
           m_intColorRampArray[2, 4] = 10;
           m_intColorRampArray[2, 05] = 60;
           
            //加载图例
             

        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            if (e.Node.IsExpanded == false)
            {
                if (e.Node.Text == "单值图")
                {
                    pictureBox1.Image = imageList2.Images[0];
            
                }
                else if (e.Node.Text == "分类图")
                {
                    pictureBox1.Image = imageList2.Images[3];
               
                }
            }
            else
            {
            }
        }

        private void btnAddAllValues_Click(object sender, EventArgs e)
        {
            //开始获得图层的表格和字段等信息
            IFillSymbol pSymbol;
            IColor pColor;
            IColor pNextUniqueColor;
            IEnumColors pEnumRamp;
            IQueryFilter pQueryFilter;
            ICursor pCursor;
            IRow pNextRow;
            IRowBuffer pNextRowBuffer;
            object objTempValue="";
            object objCodeValue;
            ITable pTable = pFeatLayer as ITable;
            IRandomColorRamp pColorRamp = new RandomColorRampClass();
            m_colValues=new ArrayClass();
            if (comboBoxUnique.Text != "")
            {
                int iFieldNo = pTable.FindField(comboBoxUnique.Text);
                if (iFieldNo != -1)
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        if (comboBoxEx1.SelectedIndex == i)
                        {
                            pColorRamp.StartHue = m_intColorRampArray[i, 0];
                            pColorRamp.EndHue = m_intColorRampArray[i, 1];
                            pColorRamp.MinValue = m_intColorRampArray[i, 2];
                            pColorRamp.MaxValue = m_intColorRampArray[i, 3];
                            pColorRamp.MinSaturation = m_intColorRampArray[i, 4];
                            pColorRamp.MaxSaturation = m_intColorRampArray[i, 5];
                        }
                    }
                    pColorRamp.Size = 100;
                    bool ok=true;
                    pColorRamp.CreateRamp(out ok);
                    pEnumRamp = pColorRamp.Colors;

                    pQueryFilter = new QueryFilterClass();
                    pQueryFilter.AddField(comboBoxUnique.Text);
                    pCursor = pTable.Search(pQueryFilter, true);
                    pNextRow = pCursor.NextRow();

                    m_intSymbolsNum = 0;
                    //填加面状图层
                    if (m_strShapeType == "Fill Symbols")
                    {
                        IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
                        m_pSymbolsArray = new ESRI.ArcGIS.esriSystem.ArrayClass();
                        while (pNextRow != null)
                        {
                            pNextRowBuffer = pNextRow as IRowBuffer;
                            objCodeValue=pNextRowBuffer.get_Value(iFieldNo);
                            if ((objTempValue != objCodeValue) || (m_intSymbolsNum == 0))
                            {
                                pNextUniqueColor = pEnumRamp.Next();
                                if (pNextUniqueColor == null)
                                {
                                    pEnumRamp.Reset();
                                    pNextUniqueColor = pEnumRamp.Next();
                                }
                                pFillSymbol.Color = pNextUniqueColor;
                                m_pSymbolsArray.Add(pFillSymbol);
                                m_colValues.Add(objCodeValue);
                                m_intSymbolsNum += 1;
                                objTempValue = objCodeValue;
                                pFillSymbol = null;
                            }
                            pNextRow = pCursor.NextRow();
                        }
                    }
                    //线图层
                    if (m_strShapeType == "Line Symbols")
                    {
                        ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
                        m_pSymbolsArray.RemoveAll();
                        while (pNextRow != null)
                        {
                            pNextRowBuffer = pNextRow as IRowBuffer;
                            objCodeValue = pNextRowBuffer.get_Value(iFieldNo);
                            if ((objTempValue != objCodeValue) || (m_intSymbolsNum == 0))
                            {
                                pNextUniqueColor = pEnumRamp.Next();
                                if (pNextUniqueColor == null)
                                {
                                    pEnumRamp.Reset();
                                    pNextUniqueColor = pEnumRamp.Next();
                                }
                                pLineSymbol.Color = pNextUniqueColor;
                                m_pSymbolsArray.Add(pLineSymbol);
                                m_colValues.Add(objCodeValue);
                                m_intSymbolsNum += 1;
                                objTempValue = objCodeValue;
                                pLineSymbol = null;
                            }
                            pNextRow = pCursor.NextRow();
                        }
                    }
                    //点图层
                    if (m_strShapeType == "Marker Symbols")
                    {
                        IMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbolClass();
                        m_pSymbolsArray.RemoveAll();
                        while (pNextRow != null)
                        {
                            pNextRowBuffer = pNextRow as IRowBuffer;
                            objCodeValue = pNextRowBuffer.get_Value(iFieldNo);
                            if ((objTempValue != objCodeValue) || (m_intSymbolsNum == 0))
                            {
                                pNextUniqueColor = pEnumRamp.Next();
                                if (pNextUniqueColor == null)
                                {
                                    pEnumRamp.Reset();
                                    pNextUniqueColor = pEnumRamp.Next();
                                }
                                pMarkerSymbol.Color = pNextUniqueColor;
                                m_pSymbolsArray.Add(pMarkerSymbol);
                                m_colValues.Add(objCodeValue);
                                m_intSymbolsNum += 1;
                                pMarkerSymbol = null;
                            }
                            pNextRow = pCursor.NextRow();
                        }
                    }
                    pColorRamp = null;
                    pQueryFilter = null;
                    pColorRamp = null;
                    //显示符号


                }
            }
        }
        //显示符号
        private void DisplaySymbols()
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            IEnumVariantSimple pEnumVariantSimple = GetUniqueValue(comboBoxUnique.Text, axMap.ActiveView.FocusMap, pFeatLayer.Name);
            listView1.Items.Clear();
            listView1.Refresh();
            ISymbol pSymbol;
            ImageList imageList1 = new ImageList();
            for (int i = 0; i <= m_intSymbolsNum - 1; i++)
            {
                pSymbol = m_pSymbolsArray.get_Element(i) as ISymbol;


            }
        }
        //得到地图中的指定特征图层指定字段的不重复值
        private IEnumVariantSimple GetUniqueValue(string strFieldName, IMap pMap, string strLayerName)
        {
            IFeatureLayer pFeatLayer = Utility.FindFeatLayer(strLayerName, pMainFrm);
            ICursor pCursor = pFeatLayer.Search(null, false) as ICursor;
            IDataStatistics pDatasetStat = new DataStatisticsClass();
            pDatasetStat.Field = strFieldName;
            pDatasetStat.Cursor = pCursor;
            return pDatasetStat.UniqueValues as IEnumVariantSimple;
        }
        //获得图层的符号类型
        private string GetLayerShapeType(IFeatureLayer pFeatLayer)
        {
            IFeatureClass pFeatCls = pFeatLayer.FeatureClass;
            if (pFeatCls != null)
            {
                if (pFeatCls.ShapeType == esriGeometryType.esriGeometryPolygon)
                    return "Fill Symbols";
                if (pFeatCls.ShapeType == esriGeometryType.esriGeometryPolyline)
                    return "Line Symbols";
                if (pFeatCls.ShapeType == esriGeometryType.esriGeometryPoint)
                    return "Marker Symbols";
            }
            return "";
        }
    }
}