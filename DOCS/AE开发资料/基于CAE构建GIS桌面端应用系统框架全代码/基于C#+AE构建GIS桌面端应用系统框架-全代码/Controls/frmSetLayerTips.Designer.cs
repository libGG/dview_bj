namespace Controls
{
    partial class frmSetLayerTips
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
            this.comboBoxLayer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxField = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.chkShowTips = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层：";
            // 
            // comboBoxLayer
            // 
            this.comboBoxLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayer.FormattingEnabled = true;
            this.comboBoxLayer.Location = new System.Drawing.Point(77, 9);
            this.comboBoxLayer.Name = "comboBoxLayer";
            this.comboBoxLayer.Size = new System.Drawing.Size(193, 20);
            this.comboBoxLayer.TabIndex = 1;
             
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "字段：";
            // 
            // comboBoxField
            // 
            this.comboBoxField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxField.FormattingEnabled = true;
            this.comboBoxField.Location = new System.Drawing.Point(77, 55);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Size = new System.Drawing.Size(193, 20);
            this.comboBoxField.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(105, 127);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "GO";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // chkShowTips
            // 
            this.chkShowTips.AutoSize = true;
            this.chkShowTips.Location = new System.Drawing.Point(18, 96);
            this.chkShowTips.Name = "chkShowTips";
            this.chkShowTips.Size = new System.Drawing.Size(108, 16);
            this.chkShowTips.TabIndex = 5;
            this.chkShowTips.Text = "是否设置提示？";
            this.chkShowTips.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(195, 127);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Destroy";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // frmSetLayerTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 162);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.chkShowTips);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxLayer);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetLayerTips";
            this.Text = "设置图层提示";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxField;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox chkShowTips;
        private System.Windows.Forms.Button buttonCancel;
    }
}