namespace Controls
{
    partial class frmHillShade
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAltitude = new System.Windows.Forms.TextBox();
            this.txtAzimuth = new System.Windows.Forms.TextBox();
            this.chkModelShadow = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtZFactor = new System.Windows.Forms.TextBox();
            this.txtCellSize = new System.Windows.Forms.TextBox();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入栅格数据：";
            // 
            // comboBoxInData
            // 
            this.comboBoxInData.FormattingEnabled = true;
            this.comboBoxInData.Location = new System.Drawing.Point(107, 14);
            this.comboBoxInData.Name = "comboBoxInData";
            this.comboBoxInData.Size = new System.Drawing.Size(200, 20);
            this.comboBoxInData.TabIndex = 1;
            this.comboBoxInData.SelectedIndexChanged += new System.EventHandler(this.comboBoxInData_SelectedIndexChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::Controls.Properties.Resources.open;
            this.btnOpen.Location = new System.Drawing.Point(313, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(27, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Azimuth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Altitude";
            // 
            // txtAltitude
            // 
            this.txtAltitude.Location = new System.Drawing.Point(107, 91);
            this.txtAltitude.Name = "txtAltitude";
            this.txtAltitude.Size = new System.Drawing.Size(175, 21);
            this.txtAltitude.TabIndex = 5;
            this.txtAltitude.Text = "45";
            // 
            // txtAzimuth
            // 
            this.txtAzimuth.Location = new System.Drawing.Point(107, 52);
            this.txtAzimuth.Name = "txtAzimuth";
            this.txtAzimuth.Size = new System.Drawing.Size(175, 21);
            this.txtAzimuth.TabIndex = 6;
            this.txtAzimuth.Text = "315";
            // 
            // chkModelShadow
            // 
            this.chkModelShadow.AutoSize = true;
            this.chkModelShadow.Location = new System.Drawing.Point(30, 130);
            this.chkModelShadow.Name = "chkModelShadow";
            this.chkModelShadow.Size = new System.Drawing.Size(72, 16);
            this.chkModelShadow.TabIndex = 7;
            this.chkModelShadow.Text = "模拟阴影";
            this.chkModelShadow.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ｚ因子：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "象素大小：";
            // 
            // txtZFactor
            // 
            this.txtZFactor.Location = new System.Drawing.Point(107, 164);
            this.txtZFactor.Name = "txtZFactor";
            this.txtZFactor.Size = new System.Drawing.Size(175, 21);
            this.txtZFactor.TabIndex = 10;
            this.txtZFactor.Text = "1";
            // 
            // txtCellSize
            // 
            this.txtCellSize.Location = new System.Drawing.Point(107, 203);
            this.txtCellSize.Name = "txtCellSize";
            this.txtCellSize.Size = new System.Drawing.Size(175, 21);
            this.txtCellSize.TabIndex = 11;
            // 
            // txtOutPath
            // 
            this.txtOutPath.Location = new System.Drawing.Point(107, 242);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(200, 21);
            this.txtOutPath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "输出栅格数据：";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Controls.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(313, 241);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(27, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(152, 288);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 15;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(255, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Destroy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmHillShade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 323);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOutPath);
            this.Controls.Add(this.txtCellSize);
            this.Controls.Add(this.txtZFactor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkModelShadow);
            this.Controls.Add(this.txtAzimuth);
            this.Controls.Add(this.txtAltitude);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.comboBoxInData);
            this.Controls.Add(this.label1);
            this.Name = "frmHillShade";
            this.Text = "山体阴影";
            this.Load += new System.EventHandler(this.frmHillShade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxInData;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAltitude;
        private System.Windows.Forms.TextBox txtAzimuth;
        private System.Windows.Forms.CheckBox chkModelShadow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtZFactor;
        private System.Windows.Forms.TextBox txtCellSize;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnCancel;
    }
}