namespace DView.SXEQJB.TempleteMgr
{
    partial class FrmQueryCloseWord
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
            this.btnManual = new DevExpress.XtraEditors.SimpleButton();
            this.btnAutomatic = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // btnManual
            // 
            this.btnManual.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnManual.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnManual.Location = new System.Drawing.Point(127, 68);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(83, 36);
            this.btnManual.TabIndex = 4;
            this.btnManual.Text = "手动关闭(&M)";
            this.btnManual.ToolTip = "手动去关闭Word软件";
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutomatic.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAutomatic.Location = new System.Drawing.Point(20, 68);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(83, 36);
            this.btnAutomatic.TabIndex = 3;
            this.btnAutomatic.Text = "自动关闭(&A)";
            this.btnAutomatic.ToolTip = "程序自动关闭所有Word，此操作不会保存Word，如果用户当前在编辑Word，请选择手动关闭";
            this.btnAutomatic.Click += new System.EventHandler(this.btnAutomatic_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(234, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取 消(&C)";
            this.btnCancel.ToolTip = "取消本次操作";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(326, 38);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "检测到系统当前有Word程序在运行，\r\n请先关闭掉所有Word程序后，再进行该操作。";
            // 
            // FrmQueryCloseWord
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(337, 118);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.btnAutomatic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmQueryCloseWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提醒";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnManual;
        private DevExpress.XtraEditors.SimpleButton btnAutomatic;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}