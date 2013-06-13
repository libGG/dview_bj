namespace DView.SXEQJB.TempleteMgr.Controls
{
    partial class ImportTempleteTableCtl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAuthor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTempName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.checkWord = new DevExpress.XtraEditors.CheckEdit();
            this.checkPdf = new DevExpress.XtraEditors.CheckEdit();
            this.checkPpt = new DevExpress.XtraEditors.CheckEdit();
            this.txtMemo = new DevExpress.XtraEditors.TextEdit();
            this.btnOpenFile = new DevExpress.XtraEditors.SimpleButton();
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTempName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPdf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPpt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "制作人:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(60, 31);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(192, 21);
            this.txtAuthor.TabIndex = 1;
            this.txtAuthor.ToolTip = "制作人";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "模板名称:";
            // 
            // txtTempName
            // 
            this.txtTempName.Location = new System.Drawing.Point(60, 4);
            this.txtTempName.Name = "txtTempName";
            this.txtTempName.Size = new System.Drawing.Size(192, 21);
            this.txtTempName.TabIndex = 1;
            this.txtTempName.ToolTip = "模板名称";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(258, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "格式:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(258, 34);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(28, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "备注:";
            // 
            // checkWord
            // 
            this.checkWord.EditValue = true;
            this.checkWord.Location = new System.Drawing.Point(292, 4);
            this.checkWord.Name = "checkWord";
            this.checkWord.Properties.Caption = "word";
            this.checkWord.Size = new System.Drawing.Size(55, 19);
            this.checkWord.TabIndex = 2;
            this.checkWord.ToolTip = "Microsoft word";
            // 
            // checkPdf
            // 
            this.checkPdf.Location = new System.Drawing.Point(353, 5);
            this.checkPdf.Name = "checkPdf";
            this.checkPdf.Properties.Caption = "pdf";
            this.checkPdf.Size = new System.Drawing.Size(49, 19);
            this.checkPdf.TabIndex = 2;
            this.checkPdf.ToolTip = "pdf";
            // 
            // checkPpt
            // 
            this.checkPpt.Location = new System.Drawing.Point(408, 5);
            this.checkPpt.Name = "checkPpt";
            this.checkPpt.Properties.Caption = "ppt";
            this.checkPpt.Size = new System.Drawing.Size(62, 19);
            this.checkPpt.TabIndex = 2;
            this.checkPpt.ToolTip = "Microsoft Power Point";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(293, 31);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(234, 21);
            this.txtMemo.TabIndex = 1;
            this.txtMemo.ToolTip = "备注";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpenFile.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnOpenFile.Location = new System.Drawing.Point(531, 62);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(34, 23);
            this.btnOpenFile.TabIndex = 6;
            this.btnOpenFile.Text = "······";
            this.btnOpenFile.ToolTip = "点击选择模板";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(61, 63);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(466, 21);
            this.txtFileName.TabIndex = 5;
            this.txtFileName.ToolTip = "模板文件路径";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(3, 64);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "选择模板:";
            // 
            // ImportTempleteTableCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DView.SXEQJB.TempleteMgr.Properties.Resources.panel_backColor_Ctl;
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.checkPpt);
            this.Controls.Add(this.checkPdf);
            this.Controls.Add(this.checkWord);
            this.Controls.Add(this.txtTempName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Name = "ImportTempleteTableCtl";
            this.Size = new System.Drawing.Size(570, 93);
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTempName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPdf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPpt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAuthor;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTempName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit checkWord;
        private DevExpress.XtraEditors.CheckEdit checkPdf;
        private DevExpress.XtraEditors.CheckEdit checkPpt;
        private DevExpress.XtraEditors.TextEdit txtMemo;
        private DevExpress.XtraEditors.SimpleButton btnOpenFile;
        private DevExpress.XtraEditors.TextEdit txtFileName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}
