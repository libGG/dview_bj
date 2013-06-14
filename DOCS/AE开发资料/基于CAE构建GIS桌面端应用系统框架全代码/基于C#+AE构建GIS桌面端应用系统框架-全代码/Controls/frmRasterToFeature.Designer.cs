namespace Controls
{
    partial class frmRasterToFeature
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxInData = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxField = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxGeomeryType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkLines = new System.Windows.Forms.CheckBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入数据：";
            // 
            // comboBoxInData
            // 
            this.comboBoxInData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInData.FormattingEnabled = true;
            this.comboBoxInData.Location = new System.Drawing.Point(83, 12);
            this.comboBoxInData.Name = "comboBoxInData";
            this.comboBoxInData.Size = new System.Drawing.Size(154, 20);
            this.comboBoxInData.TabIndex = 1;
            this.comboBoxInData.SelectedIndexChanged += new System.EventHandler(this.comboBoxInData_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "字段：";
            // 
            // comboBoxField
            // 
            this.comboBoxField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxField.FormattingEnabled = true;
            this.comboBoxField.Location = new System.Drawing.Point(83, 56);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Size = new System.Drawing.Size(154, 20);
            this.comboBoxField.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "几何类型：";
            // 
            // comboBoxGeomeryType
            // 
            this.comboBoxGeomeryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGeomeryType.FormattingEnabled = true;
            this.comboBoxGeomeryType.Location = new System.Drawing.Point(83, 100);
            this.comboBoxGeomeryType.Name = "comboBoxGeomeryType";
            this.comboBoxGeomeryType.Size = new System.Drawing.Size(154, 20);
            this.comboBoxGeomeryType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "输出特征：";
            // 
            // txtOutPath
            // 
            this.txtOutPath.Location = new System.Drawing.Point(83, 144);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(154, 21);
            this.txtOutPath.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Controls.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(255, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(25, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(106, 192);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 10;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Destroy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkLines
            // 
            this.chkLines.AutoSize = true;
            this.chkLines.Location = new System.Drawing.Point(12, 195);
            this.chkLines.Name = "chkLines";
            this.chkLines.Size = new System.Drawing.Size(60, 16);
            this.chkLines.TabIndex = 12;
            this.chkLines.Text = "生成线";
            this.chkLines.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::Controls.Properties.Resources.open;
            this.btnOpen.Location = new System.Drawing.Point(255, 11);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(25, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // frmRasterToFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 230);
            this.Controls.Add(this.chkLines);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOutPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxGeomeryType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.comboBoxInData);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRasterToFeature";
            this.Text = "栅格转特征";
            this.Load += new System.EventHandler(this.frmRasterToFeature_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxInData;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxGeomeryType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkLines;
    }
}