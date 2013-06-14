namespace DView.SXEQJB.TempleteMgr
{
    partial class FrmQueryCus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQueryCus));
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnImportTemp = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewTemp = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(297, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 78);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.ContentImage = global::DView.SXEQJB.TempleteMgr.Properties.Resources.panel_backColor_Ctl;
            this.panelControl1.Controls.Add(this.btnImportTemp);
            this.panelControl1.Controls.Add(this.btnNewTemp);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(252, 77);
            this.panelControl1.TabIndex = 0;
            // 
            // btnImportTemp
            // 
            this.btnImportTemp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImportTemp.Location = new System.Drawing.Point(137, 17);
            this.btnImportTemp.Name = "btnImportTemp";
            this.btnImportTemp.Size = new System.Drawing.Size(87, 36);
            this.btnImportTemp.TabIndex = 2;
            this.btnImportTemp.Text = "导 入(&I)";
            this.btnImportTemp.ToolTip = "导入本地已有的模板文件";
            this.btnImportTemp.Click += new System.EventHandler(this.btnImportTemp_Click);
            // 
            // btnNewTemp
            // 
            this.btnNewTemp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNewTemp.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNewTemp.Location = new System.Drawing.Point(23, 17);
            this.btnNewTemp.Name = "btnNewTemp";
            this.btnNewTemp.Size = new System.Drawing.Size(87, 36);
            this.btnNewTemp.TabIndex = 2;
            this.btnNewTemp.Text = "新 建(&N)";
            this.btnNewTemp.ToolTip = "全新建立模板";
            this.btnNewTemp.Click += new System.EventHandler(this.btnNewTemp_Click);
            // 
            // FrmQueryCus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(252, 77);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQueryCus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择定制模板方式";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.GroupControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnImportTemp;
        private DevExpress.XtraEditors.SimpleButton btnNewTemp;
    }
}