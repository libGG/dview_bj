namespace DView.SXEQJB.TempleteMgr
{
    partial class FrmImportTemp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportTemp));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.importTempleteTableCtl1 = new DView.SXEQJB.TempleteMgr.Controls.ImportTempleteTableCtl();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnOK.Location = new System.Drawing.Point(176, 96);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确 定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(315, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取 消";
            // 
            // importTempleteTableCtl1
            // 
            this.importTempleteTableCtl1.Author = "";
            this.importTempleteTableCtl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("importTempleteTableCtl1.BackgroundImage")));
            this.importTempleteTableCtl1.FileName = "";
            this.importTempleteTableCtl1.Format = "word";
            this.importTempleteTableCtl1.Location = new System.Drawing.Point(1, 0);
            this.importTempleteTableCtl1.Memo = "";
            this.importTempleteTableCtl1.Name = "importTempleteTableCtl1";
            this.importTempleteTableCtl1.Size = new System.Drawing.Size(566, 93);
            this.importTempleteTableCtl1.TabIndex = 5;
            this.importTempleteTableCtl1.TempleteName = "";
            // 
            // FrmImportTemp
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::DView.SXEQJB.TempleteMgr.Properties.Resources.panel_backColor_Ctl;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(567, 127);
            this.Controls.Add(this.importTempleteTableCtl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportTemp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导入模板";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DView.SXEQJB.TempleteMgr.Controls.ImportTempleteTableCtl importTempleteTableCtl1;
    }
}