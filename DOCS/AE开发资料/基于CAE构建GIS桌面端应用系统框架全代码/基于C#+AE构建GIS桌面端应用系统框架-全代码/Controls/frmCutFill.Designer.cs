namespace Controls
{
    partial class frmCutFill
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
            this.comboBoxInBData = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxInAData = new System.Windows.Forms.ComboBox();
            this.btnOpenARaster = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtZFactor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCellSize = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenBRaster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "之前：";
            // 
            // comboBoxInBData
            // 
            this.comboBoxInBData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInBData.FormattingEnabled = true;
            this.comboBoxInBData.Location = new System.Drawing.Point(85, 15);
            this.comboBoxInBData.Name = "comboBoxInBData";
            this.comboBoxInBData.Size = new System.Drawing.Size(189, 20);
            this.comboBoxInBData.TabIndex = 1;
            this.comboBoxInBData.SelectedIndexChanged += new System.EventHandler(this.comboBoxInBData_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "之后：";
            // 
            // comboBoxInAData
            // 
            this.comboBoxInAData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInAData.FormattingEnabled = true;
            this.comboBoxInAData.Location = new System.Drawing.Point(85, 55);
            this.comboBoxInAData.Name = "comboBoxInAData";
            this.comboBoxInAData.Size = new System.Drawing.Size(189, 20);
            this.comboBoxInAData.TabIndex = 4;
            this.comboBoxInAData.SelectedIndexChanged += new System.EventHandler(this.comboBoxInAData_SelectedIndexChanged);
            // 
            // btnOpenARaster
            // 
            this.btnOpenARaster.Image = global::Controls.Properties.Resources.open;
            this.btnOpenARaster.Location = new System.Drawing.Point(296, 54);
            this.btnOpenARaster.Name = "btnOpenARaster";
            this.btnOpenARaster.Size = new System.Drawing.Size(26, 23);
            this.btnOpenARaster.TabIndex = 5;
            this.btnOpenARaster.UseVisualStyleBackColor = true;
            this.btnOpenARaster.Click += new System.EventHandler(this.btnOpenARaster_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "输出栅格：";
            // 
            // txtOutPath
            // 
            this.txtOutPath.Location = new System.Drawing.Point(85, 177);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(189, 21);
            this.txtOutPath.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ｚ因子：";
            // 
            // txtZFactor
            // 
            this.txtZFactor.Location = new System.Drawing.Point(85, 95);
            this.txtZFactor.Name = "txtZFactor";
            this.txtZFactor.Size = new System.Drawing.Size(145, 21);
            this.txtZFactor.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "象素大小：";
            // 
            // txtCellSize
            // 
            this.txtCellSize.Location = new System.Drawing.Point(85, 136);
            this.txtCellSize.Name = "txtCellSize";
            this.txtCellSize.Size = new System.Drawing.Size(145, 21);
            this.txtCellSize.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Controls.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(296, 176);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(26, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(145, 228);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 13;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Destroy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOpenBRaster
            // 
            this.btnOpenBRaster.Image = global::Controls.Properties.Resources.open;
            this.btnOpenBRaster.Location = new System.Drawing.Point(296, 14);
            this.btnOpenBRaster.Name = "btnOpenBRaster";
            this.btnOpenBRaster.Size = new System.Drawing.Size(26, 23);
            this.btnOpenBRaster.TabIndex = 2;
            this.btnOpenBRaster.UseVisualStyleBackColor = true;
            this.btnOpenBRaster.Click += new System.EventHandler(this.btnOpenBRaster_Click);
            // 
            // frmCutFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCellSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtZFactor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOutPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOpenARaster);
            this.Controls.Add(this.comboBoxInAData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenBRaster);
            this.Controls.Add(this.comboBoxInBData);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCutFill";
            this.Text = "填挖方量";
            this.Load += new System.EventHandler(this.frmCutFill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxInBData;
        private System.Windows.Forms.Button btnOpenBRaster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxInAData;
        private System.Windows.Forms.Button btnOpenARaster;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtZFactor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCellSize;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnCancel;
    }
}