using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace ReportDemo.Controls
{
    public partial class ControlReportGene : DevExpress.XtraEditors.XtraUserControl
    {
        public ControlReportGene()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.textEdit1.Text = "̫ԭ��������";
            this.textEdit2.Text = "6";
            this.memoEdit1.Text = "��ϵͳ���������ε�����������ʮ������������Լ�����ˣ��޼ҿɹ���ԱԼ20���ˡ�";
            this.memoEdit2.Text = "��ϵͳ���������ε���������������������Լ9000�䡢Լ��30�򴱽������ܵ���ͬ�̶ȵ��ƻ�����ɷ���ֱ�Ӿ�����ʧԼΪ60��Ԫ�������߾�����ʧԼ10��Ԫ������������ʧԼ10��Ԫ���������ƣ�ֱ�Ӿ�����ʧԼ80��Ԫ��";
            this.memoEdit3.Text = "��ϵͳ����������Ӱ���漰��ɽ��ʡ��4���м������������صĵط���̫ԭ�С����ε���������������Լ7056ƽ����������˿�ԼΪ100��";
        }

        private void ControlReportGene_Load(object sender, EventArgs e)
        {
            this.dateEdit1.DateTime = DateTime.Now;
            this.timeEdit1.Time = DateTime.Now;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            string templatePath = System.Windows.Forms.Application.StartupPath + @"\����ģ��\���������.doc";

            if (File.Exists(templatePath))
            {
                WordOperator op = new WordOperator(templatePath);
                object ob_location = "location";//��������
                object ob_quakebelief = "quakebelief";//������
                object ob_Casualties = "Casualties";//��Ա����
                object ob_EconomicLoss = "EconomicLoss";//������ʧ
                object ob_DisasterPeople = "DisasterPeople";//�����˿�
                object ob_IntensityDistrib_pic = "IntensityDistrib";//�Ҷȷֲ�
                object ob_explain = "explain";//˵��
                object ob_EQAffectRegionExplain = "EQAffectRegionExplain";//���𲨼���Χ˵��
                object ob_EQAffectRegionTable = "EQAffectRegionTable";//���𲨼���Χ��
                object year = "year";//��
                object month = "month";//��
                object day = "day";//��
                double jd = 112.96;

                double wd = 38.04;
                string zqgs = "";
                //Ϊ�ı���ǩ��ֵ

                string strDate = string.Format("{0}��{1}��{2}��{3}ʱ{4}��", dateEdit1.DateTime.Date.Year.ToString(), dateEdit1.DateTime.Date.Month.ToString(), dateEdit1.DateTime.Date.Day.ToString(), timeEdit1.Time.Hour.ToString(), timeEdit1.Time.Minute.ToString());
                zqgs = "2013��5��9��14ʱ53�֣�����ʡ̫ԭ�������ط�������6����������λ�ô��ڶ���112.96����γ38.04��ɽ��ʡ�����ֺ���������ϵͳ�������ֺ�Ԥ����������£�";

                string disasterPerson = "";
                if (this.memoEdit1.Text.Trim() == "")
                {
                    disasterPerson = "��ϵͳ���������ε�����������ʮ������������Լ�����ˣ��޼ҿɹ���ԱԼ20���ˡ�";
                }
                else
                {
                    disasterPerson = this.memoEdit1.Text;
                }


                string enconmyLoss = "";
                if (this.memoEdit2.Text.Trim() == "")
                {
                    enconmyLoss = "��ϵͳ���������ε���������������������Լ9000�䡢Լ��30�򴱽������ܵ���ͬ�̶ȵ��ƻ�����ɷ���ֱ�Ӿ�����ʧԼΪ60��Ԫ�������߾�����ʧԼ10��Ԫ������������ʧԼ10��Ԫ���������ƣ�ֱ�Ӿ�����ʧԼ80��Ԫ��";
                }
                else
                {
                    enconmyLoss = this.memoEdit2.Text;
                }

                string affectedRegion = "";// this.memoEdit3.Text; 
                if (this.memoEdit3.Text.Trim() == "")
                {
                    affectedRegion = "��ϵͳ����������Ӱ���漰��ɽ��ʡ��4���м������������صĵط���̫ԭ�С����ε���������������Լ7056ƽ����������˿�ԼΪ100��";
                }
                else
                {
                    affectedRegion = this.memoEdit3.Text;
                }

                string information = "���ε���΢������λ��̫ԭ��������һ����������������ƻ������������ԼΪ7056ƽ�����";


                op.SetTextBookmark(ob_location, "̫ԭ�������� 6 ��");
                op.SetTextBookmark(ob_quakebelief, zqgs);
                op.SetTextBookmark(ob_Casualties, disasterPerson);
                op.SetTextBookmark(ob_EconomicLoss, enconmyLoss);
                op.SetTextBookmark(ob_DisasterPeople, affectedRegion);
                op.SetTextBookmark(ob_explain, information);
                op.SetTextBookmark(year, this.dateEdit1.DateTime.Date.Year.ToString());
                op.SetTextBookmark(month, this.dateEdit1.DateTime.Date.Month.ToString());
                op.SetTextBookmark(day, this.dateEdit1.DateTime.Date.Day.ToString());

                //ΪͼƬ��ǩ��ֵ
                try
                {

                    string sPicFileName = System.Windows.Forms.Application.StartupPath + @"\Ӱ�쳡.jpg";

                    if (!string.IsNullOrEmpty(sPicFileName))
                    {
                        op.SetPicBookmark(ob_IntensityDistrib_pic, sPicFileName);
                    }



                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("�Ҳ�������Word�ĵ�ģ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
