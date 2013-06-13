namespace DView.SXEQJB.TempleteMgr
{
    partial class FrmTempEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTempEdit));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveToLocal2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnBookmark2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave2 = new DevExpress.XtraEditors.SimpleButton();
            this.FramerCtlNew = new AxDSOFramer.AxFramerControl();
            this.panelControlWord = new DevExpress.XtraEditors.PanelControl();
            this.templete = new DView.SXEQJB.TempleteMgr.Controls.TempleteTableCtl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FramerCtlNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlWord)).BeginInit();
            this.panelControlWord.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControl1.ContentImage")));
            this.panelControl1.Controls.Add(this.templete);
            this.panelControl1.Controls.Add(this.btnSaveToLocal2);
            this.panelControl1.Controls.Add(this.btnBookmark2);
            this.panelControl1.Controls.Add(this.btnSave2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1280, 66);
            this.panelControl1.TabIndex = 3;
            // 
            // btnSaveToLocal2
            // 
            this.btnSaveToLocal2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSaveToLocal2.Appearance.Options.UseFont = true;
            this.btnSaveToLocal2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSaveToLocal2.Image = global::DView.SXEQJB.TempleteMgr.Properties.Resources.save_as_32;
            this.btnSaveToLocal2.Location = new System.Drawing.Point(3, 2);
            this.btnSaveToLocal2.Name = "btnSaveToLocal2";
            this.btnSaveToLocal2.Size = new System.Drawing.Size(93, 59);
            this.btnSaveToLocal2.TabIndex = 0;
            this.btnSaveToLocal2.Text = "另存为";
            this.btnSaveToLocal2.ToolTip = "模板保存到本地计算机";
            this.btnSaveToLocal2.Click += new System.EventHandler(this.btnSaveToLocal2_Click);
            // 
            // btnBookmark2
            // 
            this.btnBookmark2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnBookmark2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnBookmark2.Appearance.Options.UseFont = true;
            this.btnBookmark2.Appearance.Options.UseForeColor = true;
            this.btnBookmark2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnBookmark2.Image = global::DView.SXEQJB.TempleteMgr.Properties.Resources.bookmark_32;
            this.btnBookmark2.Location = new System.Drawing.Point(193, 2);
            this.btnBookmark2.Name = "btnBookmark2";
            this.btnBookmark2.Size = new System.Drawing.Size(93, 59);
            this.btnBookmark2.TabIndex = 0;
            this.btnBookmark2.Text = "书 签";
            this.btnBookmark2.ToolTip = "添加或删除书签";
            this.btnBookmark2.Click += new System.EventHandler(this.btnBookmark2_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSave2.Appearance.Options.UseFont = true;
            this.btnSave2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSave2.Image = global::DView.SXEQJB.TempleteMgr.Properties.Resources.upload3_32;
            this.btnSave2.Location = new System.Drawing.Point(98, 2);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(93, 59);
            this.btnSave2.TabIndex = 0;
            this.btnSave2.Text = "上 传";
            this.btnSave2.ToolTip = "保存模板并上传到服务器";
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // FramerCtlNew
            // 
            this.FramerCtlNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FramerCtlNew.Enabled = true;
            this.FramerCtlNew.Location = new System.Drawing.Point(2, 2);
            this.FramerCtlNew.Name = "FramerCtlNew";
            this.FramerCtlNew.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FramerCtlNew.OcxState")));
            this.FramerCtlNew.Size = new System.Drawing.Size(1276, 517);
            this.FramerCtlNew.TabIndex = 4;
            // 
            // panelControlWord
            // 
            this.panelControlWord.Controls.Add(this.FramerCtlNew);
            this.panelControlWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlWord.Location = new System.Drawing.Point(0, 66);
            this.panelControlWord.Name = "panelControlWord";
            this.panelControlWord.Size = new System.Drawing.Size(1280, 521);
            this.panelControlWord.TabIndex = 5;
            // 
            // templete
            // 
            this.templete.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.templete.Appearance.Options.UseBackColor = true;
            this.templete.Author = "";
            this.templete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("templete.BackgroundImage")));
            this.templete.Format = "word";
            this.templete.Location = new System.Drawing.Point(291, 1);
            this.templete.Memo = "";
            this.templete.Name = "templete";
            this.templete.Size = new System.Drawing.Size(584, 65);
            this.templete.TabIndex = 1;
            this.templete.TempleteName = "";
            // 
            // FrmTempEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 587);
            this.Controls.Add(this.panelControlWord);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTempEdit";
            this.Text = "定制模板";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FrmNewTemplete_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FramerCtlNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlWord)).EndInit();
            this.panelControlWord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave2;
        private DevExpress.XtraEditors.SimpleButton btnSaveToLocal2;
        private DevExpress.XtraEditors.SimpleButton btnBookmark2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DView.SXEQJB.TempleteMgr.Controls.TempleteTableCtl templete;
        private AxDSOFramer.AxFramerControl FramerCtlNew;
        private DevExpress.XtraEditors.PanelControl panelControlWord;

    }
}