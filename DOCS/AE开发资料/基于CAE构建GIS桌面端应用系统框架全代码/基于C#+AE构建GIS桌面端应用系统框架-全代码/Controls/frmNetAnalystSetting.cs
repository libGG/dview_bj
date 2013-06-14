using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Controls;
namespace Controls
{
    public partial class frmNetAnalystSetting : Form
    {
        private MainFrm pMainFrm = null;
        public frmNetAnalystSetting(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }

        private void frmNetAnalystSetting_Load(object sender, EventArgs e)
        {
            cboImpedance.Items.Clear();
            ListViewItem item;
            listView1.Items.Clear();

            cboAllowedTurn.Items.Clear();
            cboOutShapeType.Items.Clear();
            cboTime.Items.Clear();
            INetworkAttribute networkAttribute;
            for (int i = 0; i < pMainFrm.m_pNetDataset.AttributeCount - 1; i++)
            {
                networkAttribute = pMainFrm.m_pNetDataset.get_Attribute(i);
                if (networkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTCost)
                {
                    cboImpedance.Items.Add(networkAttribute.Name);
                    cboImpedance.SelectedIndex = 0;
                    cboTime.Items.Add(networkAttribute.Name);
                    cboTime.SelectedIndex = 0;
                }
                if (networkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTRestriction)
                {
                    item = listView1.Items.Add(networkAttribute.Name);
                }
            
                cbmDisUnits.Items.Add(GetUnitNameFrom(networkAttribute.Units.ToString()));
                cbmDisUnits.SelectedIndex = 0;
            }
            cboAllowedTurn.Items.Add("任何端点");
            cboAllowedTurn.Items.Add("仅在末端");
            cboAllowedTurn.Items.Add("无");
            cboAllowedTurn.SelectedIndex = 0;
            cboOutShapeType.Items.Add("无");
            cboOutShapeType.Items.Add("直线");
            cboOutShapeType.Items.Add("True Shape");
            cboOutShapeType.Items.Add("True Shape(无测量)");
            cboOutShapeType.SelectedIndex = 2;

        }
        //将单位转换为中文
        private string GetUnitNameFrom(string strUnit)
        {
            switch (strUnit)
            {
                case "esriNAUInches":
                    return "寸";
                    break;
                case "esriNAUFeet":
                    return "英尺";
                    break;
                case "esriNAUYards":
                    return "码";
                    break;
                case "esriNAUMiles":
                    return "英里";
                    break;
                case "esriNAUNauticalMiles":
                    return "海里";
                    break;
                case "esriNAUMillimeters":
                    return "毫米";
                    break;
                case "esriNAUCentimeters":
                    return "厘米";
                    break;
                case "esriNAUMeters":
                    return "米";
                    break;
                case "esriNAUKilometers":
                    return "公里";
                    break;
                case "esriNAUSeconds":
                    return "秒";
                    break;
                case "esriNAUMinutes":
                    return "分钟";
                    break;
                case "esriNAUHours":
                    return "小时";
                    break;
                case "esriNAUDays":
                    return "天";
                    break;
            }
            return "无";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            INASolver naSolver = pMainFrm.m_NAContext.Solver ;
            //开始进行设置
            INAClosestFacilitySolver cfSolver = naSolver as INAClosestFacilitySolver;
            if (numericUpDownCutoff.Value == 0)
                cfSolver.DefaultCutoff = null;
            else
                cfSolver.DefaultCutoff = numericUpDownCutoff.Value;
            if (numericUpDownFCount.Value == 0)
                cfSolver.DefaultTargetFacilityCount = 1;
            else
                cfSolver.DefaultTargetFacilityCount = int.Parse(numericUpDownFCount.Value.ToString());
            //设置输出线的形状
            switch (cboOutShapeType.Text)
            {
                case "无":
                    cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineNone;
                    break;
                case "直线":
                    cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineStraight;
                    break;
                case "True Shape":
                    cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineTrueShape;
                    break;
                case "True Shape(无测量)":
                    cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineTrueShapeWithMeasure;
                    break;
            }
            //设置查找方向
            if (rbnItoF.Checked == true)
                cfSolver.TravelDirection = esriNATravelDirection.esriNATravelDirectionToFacility;
            else
                cfSolver.TravelDirection = esriNATravelDirection.esriNATravelDirectionFromFacility;

            //设置ＳＯＬＶＥＲ的参数
            //设置Impedance的属性
            INASolverSettings naSolverSetting = naSolver as INASolverSettings;
            naSolverSetting.ImpedanceAttributeName = cboImpedance.Text;
            //设置OneWay限制
            IStringArray restriction = naSolverSetting.RestrictionAttributeNames;
            restriction.RemoveAll();
            int i = 0;
            for (i = 0; i <= listView1.SelectedItems.Count - 1; i++)
            {                
                restriction.Add(listView1.SelectedItems.ToString());
            }
            naSolverSetting.RestrictionAttributeNames = restriction;
            //设置拐点
            switch(cboAllowedTurn.Text)
            {
                case "无":
                    naSolverSetting.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBNoBacktrack;
                    break;
                case "任何端点":
                    naSolverSetting.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBAllowBacktrack;
                    break;
                case "仅在末端":
                    naSolverSetting.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBAtDeadEndsOnly;
                    break;
            }
            naSolverSetting.IgnoreInvalidLocations = chkIgnoreInvalidValue.Checked;
            naSolver.UpdateContext(pMainFrm.m_NAContext,Utility.GetDENetworkDataset(pMainFrm.m_pNetDataset),new GPMessagesClass());
            ToolBarButton toolbarbutton1 = pMainFrm.returnToolbarButton();
            toolbarbutton1.Enabled = true;
            this.Dispose();
        }

        private void cboImpedance_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}