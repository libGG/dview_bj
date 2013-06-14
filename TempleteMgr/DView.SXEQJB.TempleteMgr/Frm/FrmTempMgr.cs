//created by lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DView.SXEQJB.TempleteMgr.Controls;

namespace DView.SXEQJB.TempleteMgr
{
    public partial class FrmTempMgr : DevExpress.XtraEditors.XtraForm
    {
        public FrmTempMgr()
        {
            InitializeComponent();
        }

        private void FrmTempMgr_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Control ctl = new TempMgrCtl();
            this.Controls.Add(ctl);
            ctl.Dock = DockStyle.Fill;
            this.Cursor = Cursors.Default;
        }
    }
}