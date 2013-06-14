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
            cboAllowedTurn.Items.Add("�κζ˵�");
            cboAllowedTurn.Items.Add("����ĩ��");
            cboAllowedTurn.Items.Add("��");
            cboAllowedTurn.SelectedIndex = 0;
            cboOutShapeType.Items.Add("��");
            cboOutShapeType.Items.Add("ֱ��");
            cboOutShapeType.Items.Add("True Shape");
            cboOutShapeType.Items.Add("True Shape(�޲���)");
            cboOutShapeType.SelectedIndex = 2;

        }
        //����λת��Ϊ����
        private string GetUnitNameFrom(string strUnit)
        {
            switch (strUnit)
            {
                case "esriNAUInches":
                    return "��";
                    break;
                case "esriNAUFeet":
                    return "Ӣ��";
                    break;
                case "esriNAUYards":
                    return "��";
                    break;
                case "esriNAUMiles":
                    return "Ӣ��";
                    break;
                case "esriNAUNauticalMiles":
                    return "����";
                    break;
                case "esriNAUMillimeters":
                    return "����";
                    break;
                case "esriNAUCentimeters":
                    return "����";
                    break;
                case "esriNAUMeters":
                    return "��";
                    break;
                case "esriNAUKilometers":
                    return "����";
                    break;
                case "esriNAUSeconds":
                    return "��";
                    break;
                case "esriNAUMinutes":
                    return "����";
                    break;
                case "esriNAUHours":
                    return "Сʱ";
                    break;
                case "esriNAUDays":
                    return "��";
                    break;
            }
            return "��";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            INASolver naSolver = pMainFrm.m_NAContext.Solver ;
            //��ʼ��������
            INAClosestFacilitySolver cfSolver = naSolver as INAClosestFacilitySolver;
            if (numericUpDownCutoff.Value == 0)
                cfSolver.DefaultCutoff = null;
            else
                cfSolver.DefaultCutoff = numericUpDownCutoff.Value;
            if (numericUpDownFCount.Value == 0)
                cfSolver.DefaultTargetFacilityCount = 1;
            else
                cfSolver.DefaultTargetFacilityCount = int.Parse(numericUpDownFCount.Value.ToString());
            //��������ߵ���״
            switch (cboOutShapeType.Text)
            {
                case "��":
                    cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineNone;
                    break;
                case "ֱ��":
                    cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineStraight;
                    break;
                case "True Shape":
                    cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineTrueShape;
                    break;
                case "True Shape(�޲���)":
                    cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineTrueShapeWithMeasure;
                    break;
            }
            //���ò��ҷ���
            if (rbnItoF.Checked == true)
                cfSolver.TravelDirection = esriNATravelDirection.esriNATravelDirectionToFacility;
            else
                cfSolver.TravelDirection = esriNATravelDirection.esriNATravelDirectionFromFacility;

            //���ãӣϣ̣֣ţҵĲ���
            //����Impedance������
            INASolverSettings naSolverSetting = naSolver as INASolverSettings;
            naSolverSetting.ImpedanceAttributeName = cboImpedance.Text;
            //����OneWay����
            IStringArray restriction = naSolverSetting.RestrictionAttributeNames;
            restriction.RemoveAll();
            int i = 0;
            for (i = 0; i <= listView1.SelectedItems.Count - 1; i++)
            {                
                restriction.Add(listView1.SelectedItems.ToString());
            }
            naSolverSetting.RestrictionAttributeNames = restriction;
            //���ùյ�
            switch(cboAllowedTurn.Text)
            {
                case "��":
                    naSolverSetting.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBNoBacktrack;
                    break;
                case "�κζ˵�":
                    naSolverSetting.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBAllowBacktrack;
                    break;
                case "����ĩ��":
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