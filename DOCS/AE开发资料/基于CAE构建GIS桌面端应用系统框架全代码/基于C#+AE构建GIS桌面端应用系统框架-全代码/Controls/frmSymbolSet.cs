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
        //��ʼ���������÷��������б�
        private void InitTreeView()
        {
            TreeNode node = null;
            treeView1.Nodes.Clear();
            node = treeView1.Nodes.Add("��ֵͼ");           
            node=treeView1.Nodes.Add("����ͼ");
            node = treeView1.Nodes.Add("�ܶ�ͼ");
            node = treeView1.Nodes.Add("ͼ��");
            node.Nodes.Add("��ͼ");
            node.Nodes.Add("��״ͼ");
            node.Nodes.Add("ֱ��ͼ");
        }
        //��ʼ���ֶ������б�ؼ�
        private void InitComboFieldUnique()
        {
            m_intSymbolsNum = -1;
            //��ʼ����ֵͼ���ֶ���Ϣ
            comboBoxUnique.Items.Clear();
            IFields pFields = pFeatLayer.FeatureClass.Fields;
            for (int i = 0; i <= pFields.FieldCount - 1; i++)
            {
                IField pField = pFields.get_Field(i);
                comboBoxUnique.Items.Add(pField.Name);
            }
        }
        //��ʼ����ɫͼƬ�����б�ؼ�
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
        //��ʼ����ֵͼ��ɫ��
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
           
            //����ͼ��
             

        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            if (e.Node.IsExpanded == false)
            {
                if (e.Node.Text == "��ֵͼ")
                {
                    pictureBox1.Image = imageList2.Images[0];
            
                }
                else if (e.Node.Text == "����ͼ")
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
            //��ʼ���ͼ��ı����ֶε���Ϣ
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
                    //�����״ͼ��
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
                    //��ͼ��
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
                    //��ͼ��
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
                    //��ʾ����


                }
            }
        }
        //��ʾ����
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
        //�õ���ͼ�е�ָ������ͼ��ָ���ֶεĲ��ظ�ֵ
        private IEnumVariantSimple GetUniqueValue(string strFieldName, IMap pMap, string strLayerName)
        {
            IFeatureLayer pFeatLayer = Utility.FindFeatLayer(strLayerName, pMainFrm);
            ICursor pCursor = pFeatLayer.Search(null, false) as ICursor;
            IDataStatistics pDatasetStat = new DataStatisticsClass();
            pDatasetStat.Field = strFieldName;
            pDatasetStat.Cursor = pCursor;
            return pDatasetStat.UniqueValues as IEnumVariantSimple;
        }
        //���ͼ��ķ�������
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