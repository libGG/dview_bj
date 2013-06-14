namespace Controls
{
    partial class frmContour
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
            this.comboBoxInputData = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConInterval = new System.Windows.Forms.TextBox();
            this.txtBaseLine = new System.Windows.Forms.TextBox();
            this.txtZFactor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOutputData = new System.Windows.Forms.TextBox();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpenData = new System.Windows.Forms.Button();
            this.lblZMin = new System.Windows.Forms.Label();
            this.lblZMax = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入源数据：";
            // 
            // comboBoxInputData
            // 
            this.comboBoxInputData.FormattingEnabled = true;
            this.comboBoxInputData.Location = new System.Drawing.Point(96, 9);
            this.comboBoxInputData.Name = "comboBoxInputData";
            this.comboBoxInputData.Size = new System.Drawing.Size(217, 20);
            this.comboBoxInputData.TabIndex = 1;
            this.comboBoxInputData.SelectedIndexChanged += new System.EventHandler(this.comboBoxInputData_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblZMax);
            this.groupBox1.Controls.Add(this.lblZMin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtZFactor);
            this.groupBox1.Controls.Add(this.txtBaseLine);
            this.groupBox1.Controls.Add(this.txtConInterval);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 162);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置等值线参数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "高程范围：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "最小值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "最大值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "间隔：";
            // 
            // txtConInterval
            // 
            this.txtConInterval.Location = new System.Drawing.Point(83, 63);
            this.txtConInterval.Name = "txtConInterval";
            this.txtConInterval.Size = new System.Drawing.Size(217, 21);
            this.txtConInterval.TabIndex = 4;
            this.txtConInterval.Text = "100";
            // 
            // txtBaseLine
            // 
            this.txtBaseLine.Location = new System.Drawing.Point(83, 97);
            this.txtBaseLine.Name = "txtBaseLine";
            this.txtBaseLine.Size = new System.Drawing.Size(217, 21);
            this.txtBaseLine.TabIndex = 5;
            this.txtBaseLine.Text = "0";
            // 
            // txtZFactor
            // 
            this.txtZFactor.Location = new System.Drawing.Point(83, 131);
            this.txtZFactor.Name = "txtZFactor";
            this.txtZFactor.Size = new System.Drawing.Size(217, 21);
            this.txtZFactor.TabIndex = 6;
            this.txtZFactor.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "基础线：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ｚ因子：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "输出：";
            // 
            // txtOutputData
            // 
            this.txtOutputData.Location = new System.Drawing.Point(96, 244);
            this.txtOutputData.Name = "txtOutputData";
            this.txtOutputData.Size = new System.Drawing.Size(217, 21);
            this.txtOutputData.TabIndex = 5;
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(130, 297);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(86, 25);
            this.btnGO.TabIndex = 7;
            this.btnGO.Text = "GO！";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(262, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Destroy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Controls.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(319, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpenData
            // 
            this.btnOpenData.Image = global::Controls.Properties.Resources.open;
            this.btnOpenData.Location = new System.Drawing.Point(319, 7);
            this.btnOpenData.Name = "btnOpenData";
            this.btnOpenData.Size = new System.Drawing.Size(24, 23);
            this.btnOpenData.TabIndex = 2;
            this.btnOpenData.UseVisualStyleBackColor = true;
            this.btnOpenData.Click += new System.EventHandler(this.btnOpenData_Click);
            // 
            // lblZMin
            // 
            this.lblZMin.AutoSize = true;
            this.lblZMin.Location = new System.Drawing.Point(148, 32);
            this.lblZMin.Name = "lblZMin";
            this.lblZMin.Size = new System.Drawing.Size(0, 12);
            this.lblZMin.TabIndex = 9;
            // 
            // lblZMax
            // 
            this.lblZMax.AutoSize = true;
            this.lblZMax.Location = new System.Drawing.Point(259, 32);
            this.lblZMax.Name = "lblZMax";
            this.lblZMax.Size = new System.Drawing.Size(0, 12);
            this.lblZMax.TabIndex = 10;
            // 
            // frmContour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 333);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOutputData);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenData);
            this.Controls.Add(this.comboBoxInputData);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContour";
            this.Text = "等值线";
            this.Load += new System.EventHandler(this.frmContour_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxInputData;
        private System.Windows.Forms.Button btnOpenData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZFactor;
        private System.Windows.Forms.TextBox txtBaseLine;
        private System.Windows.Forms.TextBox txtConInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOutputData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblZMax;
        private System.Windows.Forms.Label lblZMin;
    }
}