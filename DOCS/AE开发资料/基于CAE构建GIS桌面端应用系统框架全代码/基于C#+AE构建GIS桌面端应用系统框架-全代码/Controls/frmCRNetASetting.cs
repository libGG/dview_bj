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
    public partial class frmCRNetASetting : Form
    {
        private MainFrm pMainFrm = null;
        public frmCRNetASetting(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmCRNetASetting_Load(object sender, EventArgs e)
        {
            cboUturnPolicy.Items.Clear();
            cboUturnPolicy.Items.Add("Nowhere");
            cboUturnPolicy.Items.Add("Everywhere");
            cboUturnPolicy.Items.Add("Only at Dead Ends");

            cboRouteOutputLines.Items.Add("None");
            cboRouteOutputLines.Items.Add("Straight Line");
            cboRouteOutputLines.Items.Add("True Shape");
            cboRouteOutputLines.Items.Add("True Shape With Ms");

            cboRouteDirectionsLengthUnits.Items.Add("Feet");
            cboRouteDirectionsLengthUnits.Items.Add("Yards");
            cboRouteDirectionsLengthUnits.Items.Add("Miles");
            cboRouteDirectionsLengthUnits.Items.Add("Meters");
            cboRouteDirectionsLengthUnits.Items.Add("Kilometers");
            Initialize();
            GetSolverSpecificInterface();
            GetServerSolverParams();
       
        }
        private void Initialize()
        {
            int ImpedanceIndex = 0;

            //Get Attributes
            cboImpedance.Items.Clear();
            chklstAccumulateAttributes.Items.Clear();
            chklstRestrictions.Items.Clear();
            cboUturnPolicy.SelectedIndex = -1;
            //������������������ò�������ֵ
            INASolverSettings2 pNaSolverSetting = pMainFrm.m_NAContext.Solver as INASolverSettings2;
            //�����������ۻ�������
            IStringArray accumulateAttributeNames = pNaSolverSetting.AccumulateAttributeNames;
            //��������������������
            IStringArray restrictionAttributeNames = pNaSolverSetting.RestrictionAttributeNames;
            //��������������
            INetworkAttribute pNetworkAttribute;
            for (int i = 0; i < pMainFrm.m_pNetDataset.AttributeCount ; i++)
            {
                pNetworkAttribute = pMainFrm.m_pNetDataset.get_Attribute(i);
                string networkAttributeName = pNetworkAttribute.Name;
                //�������������Ե�������
                if (pNetworkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTCost)
                {
                    chklstAccumulateAttributes.Items.Add(networkAttributeName, IsStringInStringArray(networkAttributeName, accumulateAttributeNames));

                    int index = cboImpedance.Items.Add(pNetworkAttribute.Name + " (" + pNetworkAttribute.Units.ToString().Substring(7) + ")");
                    if (networkAttributeName == pNaSolverSetting.ImpedanceAttributeName)
                        ImpedanceIndex = index;
                }
                //�������������Ե�������
                if (pNetworkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTRestriction)
                {
                    chklstRestrictions.Items.Add(pNetworkAttribute.Name, IsStringInStringArray(networkAttributeName, restrictionAttributeNames));
                }
            }
            if (cboImpedance.Items.Count > 0)
                cboImpedance.SelectedIndex = ImpedanceIndex;
            //�Ƿ�ʹ�ø߼�
            chkUseHierarchy.Checked = pNaSolverSetting.UseHierarchy;
            //�Ƿ�ʹ�ø߼�
            chkUseHierarchy.Enabled = pNaSolverSetting.HierarchyAttributeName.Length > 0;
            //�Ƿ������Ч��λ��
            chkIgnoreInvalidLocations.Checked = pNaSolverSetting.IgnoreInvalidLocations;
            //�Ƿ�����յ�
            cboUturnPolicy.SelectedIndex = System.Convert.ToInt32(pNaSolverSetting.RestrictUTurns);
        }
        private bool IsStringInStringArray(string inputString, IStringArray stringArray)
        {
            int numInArray = stringArray.Count;
            for (int i = 0; i < numInArray; i++)
            {
                if (inputString.Equals(stringArray.get_Element(i)))
                    return true;
            }

            return false;
        }
        //��� ServerSolverParams ���� (ReturnMap, SnapTolerance, etc.)
        private void GetServerSolverParams()
        {            
            //Set Directions Defaults
            cboRouteDirectionsTimeAttribute.Items.Clear();
            //��������������
            INetworkAttribute pNetworkAttribute;
            for (int i = 0; i < pMainFrm.m_pNetDataset.AttributeCount; i++)
            {
                pNetworkAttribute = pMainFrm.m_pNetDataset.get_Attribute(i);
                if (pNetworkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTCost)
                {
                    if (String.Compare(pNetworkAttribute.Units.ToString(), "esriNAUMinutes") == 0)
                    {
                        cboRouteDirectionsTimeAttribute.Items.Add(pNetworkAttribute.Name);
                    }
                }
            }

            // Set the default direction settings
            
            cboRouteDirectionsLengthUnits.SelectedIndex = 0;
                
            
        }
        //����Ĭ�ϵĲ���  (BestOrder, UseTimeWindows, UseStartTime, etc.)
        private void GetSolverSpecificInterface()
        {
            INARouteSolver2 routeSolver =  pMainFrm.m_NAContext.Solver as INARouteSolver2;
            if (routeSolver != null)
            {
                chkBestOrder.Checked = routeSolver.FindBestSequence;
                chkPreserveFirst.Checked = routeSolver.PreserveFirstStop;
                chkPreserveLast.Checked = routeSolver.PreserveLastStop;
                if (chkBestOrder.Checked == true)
                {
                    this.chkPreserveFirst.Enabled = true;
                    this.chkPreserveLast.Enabled = true;
                }
                else
                {
                    this.chkPreserveFirst.Enabled = false;
                    this.chkPreserveLast.Enabled = false;
                }

                chkUseTimeWindows.Checked = routeSolver.UseTimeWindows;
                chkUseStartTime.Checked = routeSolver.UseStartTime;
                if (chkUseStartTime.Checked)
                {
                    txtStartTime.Enabled = true;
                    txtStartTime.Text = routeSolver.StartTime.ToString();
                }
                else
                {
                    txtStartTime.Enabled = false;
                    txtStartTime.Text = System.DateTime.Now.ToString();
                }
                cboRouteOutputLines.SelectedIndex = System.Convert.ToInt32(routeSolver.OutputLines);
            }
        }
        
        private string ExtractImpedanceName(string impedanceUnits)
        {
            int firstIndex = impedanceUnits.LastIndexOf(" ");
            int lastIndex = impedanceUnits.Length;
            return impedanceUnits.Remove(firstIndex, (lastIndex - firstIndex));
        }
        /// <summary>
        /// Set general solver settings  (Impedance, Restrictions, Accumulates, etc.)
        /// </summary>   
        private void SetINASolverSettings(INASolverSettings2 solverSettings)
        {
            //1.����Impedance
            solverSettings.ImpedanceAttributeName = ExtractImpedanceName(cboImpedance.Text);
            //2.������������
            IStringArray restrictionAttributes = solverSettings.RestrictionAttributeNames;
            restrictionAttributes.RemoveAll();
            for (int i = 0; i < chklstRestrictions.CheckedItems.Count; i++)
                restrictionAttributes.Add(chklstRestrictions.Items[chklstRestrictions.CheckedIndices[i]].ToString());
            solverSettings.RestrictionAttributeNames = restrictionAttributes;
            //3.�����ۼ�����
            IStringArray accumulateAttributes = solverSettings.AccumulateAttributeNames;
            accumulateAttributes.RemoveAll();
            for (int i = 0; i < chklstAccumulateAttributes.CheckedItems.Count; i++)
                accumulateAttributes.Add(chklstAccumulateAttributes.Items[chklstAccumulateAttributes.CheckedIndices[i]].ToString());
            solverSettings.AccumulateAttributeNames = accumulateAttributes;
            //4.��������յ����
            solverSettings.RestrictUTurns = (esriNetworkForwardStarBacktrack)cboUturnPolicy.SelectedIndex;
            //5.���ú�����Чλ��
            solverSettings.IgnoreInvalidLocations = chkIgnoreInvalidLocations.Checked;
            //6.����ʹ�ø߼�����
            solverSettings.UseHierarchy = chkUseHierarchy.Checked;
        }
        /// <summary>
        /// Set specific solver settings  (FindBestSequence, UseTimeWindows, etc.)      
        /// </summary>        
        private void SetSolverSpecificInterface()
        {
            INARouteSolver2 routeSolver = pMainFrm.m_NAContext.Solver as INARouteSolver2;
            if (routeSolver != null)
            {
                //7.���ò�������·��
                routeSolver.FindBestSequence = chkBestOrder.Checked;
                //8.���ñ����һ���ӣԣϣ�
                routeSolver.PreserveFirstStop = chkPreserveFirst.Checked;
                //9.���ñ������һ���ӣԣϣ�
                routeSolver.PreserveLastStop = chkPreserveLast.Checked;
                //10.����ʹ��ʱ�䴰������
                routeSolver.UseTimeWindows = chkUseTimeWindows.Checked;
                //11.������������ʽ
                routeSolver.OutputLines = (esriNAOutputLineType)cboRouteOutputLines.SelectedIndex;
                //12.����ʹ�ÿ�ʼʱ��
                routeSolver.UseStartTime = chkUseStartTime.Checked;
                if (routeSolver.UseStartTime == true)
                    routeSolver.StartTime = System.Convert.ToDateTime(txtStartTime.Text.ToString());
            }
        }
       
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
           // IServerContext serverContext = null;
            try
            {
                INASolverSettings2 pNaSolverSetting = pMainFrm.m_NAContext.Solver as INASolverSettings2;
                SetINASolverSettings(pNaSolverSetting);
                SetSolverSpecificInterface();
                pMainFrm.m_NAContext.Solver.UpdateContext(pMainFrm.m_NAContext, Utility.GetDENetworkDataset(pMainFrm.m_pNetDataset), new GPMessagesClass());
                ToolBarButton toolbarbutton1 = pMainFrm.returnToolbarButton();
                toolbarbutton1.Enabled = true;
                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred");
            }
            finally
            {
                // Release the ServerContext
             //   if (serverContext != null)
              //      serverContext.ReleaseContext();
            }

            this.Cursor = Cursors.Default;

        }

    }
}