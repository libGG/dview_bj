using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportDemo
{
    public partial class FrmLookAndFeel : DevExpress.XtraEditors.XtraForm
    {
        static public FrmLookAndFeel mFrmSkin = null;
        static public FrmLookAndFeel GetInstance()
        {
            if (mFrmSkin == null)
                mFrmSkin = new FrmLookAndFeel();
            return mFrmSkin;
        }

        public FrmLookAndFeel()
        {
            InitializeComponent();
        }

        private void FrmLookAndFeel_Load(object sender, EventArgs e)
        {
            comboBoxEdit1.Properties.Items.Clear();
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
                comboBoxEdit1.Properties.Items.Add(skin.SkinName);
            try
            {
                string defultSkin = XmlConfig.GetNodeValue("LookAndFeel"); ;
                if (comboBoxEdit1.Properties.Items.IndexOf(defultSkin) >= 0)
                    comboBoxEdit1.Text = defultSkin;
                else
                    comboBoxEdit1.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string strSkin = comboBoxEdit1.Text;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(strSkin);
                XmlConfig.SetNodeValue("LookAndFeel", strSkin);
            }
            catch
            {
            }
        }

        private void FrmLookAndFeel_FormClosed(object sender, FormClosedEventArgs e)
        {
            mFrmSkin = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            mFrmSkin = null;
            this.Close();

        }
    }
}