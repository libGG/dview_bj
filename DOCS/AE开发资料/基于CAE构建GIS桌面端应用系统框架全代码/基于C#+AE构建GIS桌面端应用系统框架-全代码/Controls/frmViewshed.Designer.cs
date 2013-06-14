namespace Controls
{
    partial class frmViewshed
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
            this.btnOpenRaster = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxOPosition = new System.Windows.Forms.ComboBox();
            this.btnOpenFeat = new System.Windows.Forms.Button();
            this.chkEarthCurve = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtZFactor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCellSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入栅格数据：";
            // 
            // comboBoxInData
            // 
            this.comboBoxInData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInData.FormattingEnabled = true;
            this.comboBoxInData.Location = new System.Drawing.Point(107, 15);
            this.comboBoxInData.Name = "comboBoxInData";
            this.comboBoxInData.Size = new System.Drawing.Size(192, 20);
            this.comboBoxInData.TabIndex = 1;
            this.comboBoxInData.SelectedIndexChanged += new System.EventHandler(this.comboBoxInData_SelectedIndexChanged);
            // 
            // btnOpenRaster
            // 
            this.btnOpenRaster.Image = global::Controls.Properties.Resources.open;
            this.btnOpenRaster.Location = new System.Drawing.Point(315, 14);
            this.btnOpenRaster.Name = "btnOpenRaster";
            this.btnOpenRaster.Size = new System.Drawing.Size(24, 23);
            this.btnOpenRaster.TabIndex = 2;
            this.btnOpenRaster.UseVisualStyleBackColor = true;
            this.btnOpenRaster.Click += new System.EventHandler(this.btnOpenRaster_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "观测位置：";
            // 
            // comboBoxOPosition
            // 
            this.comboBoxOPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOPosition.FormattingEnabled = true;
            this.comboBoxOPosition.Location = new System.Drawing.Point(107, 50);
            this.comboBoxOPosition.Name = "comboBoxOPosition";
            this.comboBoxOPosition.Size = new System.Drawing.Size(192, 20);
            this.comboBoxOPosition.TabIndex = 4;
            this.comboBoxOPosition.SelectedIndexChanged += new System.EventHandler(this.comboBoxOPosition_SelectedIndexChanged);
            // 
            // btnOpenFeat
            // 
            this.btnOpenFeat.Image = global::Controls.Properties.Resources.open;
            this.btnOpenFeat.Location = new System.Drawing.Point(315, 49);
            this.btnOpenFeat.Name = "btnOpenFeat";
            this.btnOpenFeat.Size = new System.Drawing.Size(24, 23);
            this.btnOpenFeat.TabIndex = 5;
            this.btnOpenFeat.UseVisualStyleBackColor = true;
            this.btnOpenFeat.Click += new System.EventHandler(this.btnOpenFeat_Click);
            // 
            // chkEarthCurve
            // 
            this.chkEarthCurve.AutoSize = true;
            this.chkEarthCurve.Location = new System.Drawing.Point(12, 85);
            this.chkEarthCurve.Name = "chkEarthCurve";
            this.chkEarthCurve.Size = new System.Drawing.Size(96, 16);
            this.chkEarthCurve.TabIndex = 6;
            this.chkEarthCurve.Text = "使用地球曲率";
            this.chkEarthCurve.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Z因子：";
            // 
            // txtZFactor
            // 
            this.txtZFactor.Location = new System.Drawing.Point(107, 119);
            this.txtZFactor.Name = "txtZFactor";
            this.txtZFactor.Size = new System.Drawing.Size(100, 21);
            this.txtZFactor.TabIndex = 8;
            this.txtZFactor.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "象素大小：";
            // 
            // txtCellSize
            // 
            this.txtCellSize.Location = new System.Drawing.Point(107, 155);
            this.txtCellSize.Name = "txtCellSize";
            this.txtCellSize.Size = new System.Drawing.Size(100, 21);
            this.txtCellSize.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "输出栅格数据：";
            // 
            // txtOutPath
            // 
            this.txtOutPath.Location = new System.Drawing.Point(107, 188);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(192, 21);
            this.txtOutPath.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Controls.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(315, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(152, 231);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 14;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(248, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Destroy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmViewshed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 266);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOutPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCellSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtZFactor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkEarthCurve);
            this.Controls.Add(this.btnOpenFeat);
            this.Controls.Add(this.comboBoxOPosition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenRaster);
            this.Controls.Add(this.comboBoxInData);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewshed";
            this.Text = "通视分析";
            this.Load += new System.EventHandler(this.frmViewshed_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxInData;
        private System.Windows.Forms.Button btnOpenRaster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxOPosition;
        private System.Windows.Forms.Button btnOpenFeat;
        private System.Windows.Forms.CheckBox chkEarthCurve;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtZFactor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCellSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnCancel;
    }
}