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
            this.textEdit1.Text = "太原市阳曲县";
            this.textEdit2.Text = "6";
            this.memoEdit1.Text = "经系统评估，本次地震可能造成数十人死亡，受伤约数百人，无家可归人员约20万人。";
            this.memoEdit2.Text = "经系统评估，本次地震可能造成灾区倒塌房屋约9000间、约有30万幢建筑物受到不同程度的破坏；造成房屋直接经济损失约为60亿元，生命线经济损失约10亿元，其他经济损失约10亿元。初步估计，直接经济损失约80亿元。";
            this.memoEdit3.Text = "经系统评估，地震影响涉及到山西省的4个市级，受灾最严重的地方是太原市。本次地震造成灾区总面积约7056平方公里，灾区人口约为100万。";
        }

        private void ControlReportGene_Load(object sender, EventArgs e)
        {
            this.dateEdit1.DateTime = DateTime.Now;
            this.timeEdit1.Time = DateTime.Now;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            string templatePath = System.Windows.Forms.Application.StartupPath + @"\报表模板\地震灾情简报.doc";

            if (File.Exists(templatePath))
            {
                WordOperator op = new WordOperator(templatePath);
                object ob_location = "location";//地震发生地
                object ob_quakebelief = "quakebelief";//地震简介
                object ob_Casualties = "Casualties";//人员伤亡
                object ob_EconomicLoss = "EconomicLoss";//经济损失
                object ob_DisasterPeople = "DisasterPeople";//灾区人口
                object ob_IntensityDistrib_pic = "IntensityDistrib";//烈度分布
                object ob_explain = "explain";//说明
                object ob_EQAffectRegionExplain = "EQAffectRegionExplain";//地震波及范围说明
                object ob_EQAffectRegionTable = "EQAffectRegionTable";//地震波及范围表
                object year = "year";//年
                object month = "month";//月
                object day = "day";//日
                double jd = 112.96;

                double wd = 38.04;
                string zqgs = "";
                //为文本书签赋值

                string strDate = string.Format("{0}年{1}月{2}日{3}时{4}分", dateEdit1.DateTime.Date.Year.ToString(), dateEdit1.DateTime.Date.Month.ToString(), dateEdit1.DateTime.Date.Day.ToString(), timeEdit1.Time.Hour.ToString(), timeEdit1.Time.Minute.ToString());
                zqgs = "2013年5月9日14时53分，在我省太原市阳曲县发生里氏6级地震，震中位置处于东经112.96，北纬38.04。山西省地震灾害快速评估系统产生的灾害预评估结果如下：";

                string disasterPerson = "";
                if (this.memoEdit1.Text.Trim() == "")
                {
                    disasterPerson = "经系统评估，本次地震可能造成数十人死亡，受伤约数百人，无家可归人员约20万人。";
                }
                else
                {
                    disasterPerson = this.memoEdit1.Text;
                }


                string enconmyLoss = "";
                if (this.memoEdit2.Text.Trim() == "")
                {
                    enconmyLoss = "经系统评估，本次地震可能造成灾区倒塌房屋约9000间、约有30万幢建筑物受到不同程度的破坏；造成房屋直接经济损失约为60亿元，生命线经济损失约10亿元，其他经济损失约10亿元。初步估计，直接经济损失约80亿元。";
                }
                else
                {
                    enconmyLoss = this.memoEdit2.Text;
                }

                string affectedRegion = "";// this.memoEdit3.Text; 
                if (this.memoEdit3.Text.Trim() == "")
                {
                    affectedRegion = "经系统评估，地震影响涉及到山西省的4个市级，受灾最严重的地方是太原市。本次地震造成灾区总面积约7056平方公里，灾区人口约为100万。";
                }
                else
                {
                    affectedRegion = this.memoEdit3.Text;
                }

                string information = "本次地震微观震中位于太原市阳曲县一带。极震区达Ⅷ度破坏，灾区总面积约为7056平方公里。";


                op.SetTextBookmark(ob_location, "太原市阳曲县 6 级");
                op.SetTextBookmark(ob_quakebelief, zqgs);
                op.SetTextBookmark(ob_Casualties, disasterPerson);
                op.SetTextBookmark(ob_EconomicLoss, enconmyLoss);
                op.SetTextBookmark(ob_DisasterPeople, affectedRegion);
                op.SetTextBookmark(ob_explain, information);
                op.SetTextBookmark(year, this.dateEdit1.DateTime.Date.Year.ToString());
                op.SetTextBookmark(month, this.dateEdit1.DateTime.Date.Month.ToString());
                op.SetTextBookmark(day, this.dateEdit1.DateTime.Date.Day.ToString());

                //为图片书签赋值
                try
                {

                    string sPicFileName = System.Windows.Forms.Application.StartupPath + @"\影响场.jpg";

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
                MessageBox.Show("找不到灾情Word文档模板", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
