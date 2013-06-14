namespace Controls
{
    partial class frmNetAnalystSetting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboOutShapeType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboAllowedTurn = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbnFtoI = new System.Windows.Forms.RadioButton();
            this.rbnItoF = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownFCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownCutoff = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cboImpedance = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboTime = new System.Windows.Forms.ComboBox();
            this.chkUseTime = new System.Windows.Forms.CheckBox();
            this.cbmDisUnits = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkIgnoreInvalidValue = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCutoff)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboOutShapeType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboAllowedTurn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rbnFtoI);
            this.groupBox1.Controls.Add(this.rbnItoF);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDownFCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDownCutoff);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboImpedance);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 285);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // cboOutShapeType
            // 
            this.cboOutShapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutShapeType.FormattingEnabled = true;
            this.cboOutShapeType.Location = new System.Drawing.Point(99, 246);
            this.cboOutShapeType.Name = "cboOutShapeType";
            this.cboOutShapeType.Size = new System.Drawing.Size(131, 20);
            this.cboOutShapeType.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "输出形状类型：";
            // 
            // cboAllowedTurn
            // 
            this.cboAllowedTurn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAllowedTurn.FormattingEnabled = true;
            this.cboAllowedTurn.Location = new System.Drawing.Point(99, 209);
            this.cboAllowedTurn.Name = "cboAllowedTurn";
            this.cboAllowedTurn.Size = new System.Drawing.Size(131, 20);
            this.cboAllowedTurn.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "被允许的拐点：";
            // 
            // rbnFtoI
            // 
            this.rbnFtoI.AutoSize = true;
            this.rbnFtoI.Location = new System.Drawing.Point(99, 180);
            this.rbnFtoI.Name = "rbnFtoI";
            this.rbnFtoI.Size = new System.Drawing.Size(95, 16);
            this.rbnFtoI.TabIndex = 8;
            this.rbnFtoI.Text = "设施到事发地";
            this.rbnFtoI.UseVisualStyleBackColor = true;
            // 
            // rbnItoF
            // 
            this.rbnItoF.AutoSize = true;
            this.rbnItoF.Checked = true;
            this.rbnItoF.Location = new System.Drawing.Point(99, 155);
            this.rbnItoF.Name = "rbnItoF";
            this.rbnItoF.Size = new System.Drawing.Size(95, 16);
            this.rbnItoF.TabIndex = 7;
            this.rbnItoF.TabStop = true;
            this.rbnItoF.Text = "事发地到设施";
            this.rbnItoF.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "计算方向：";
            // 
            // numericUpDownFCount
            // 
            this.numericUpDownFCount.Location = new System.Drawing.Point(99, 113);
            this.numericUpDownFCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFCount.Name = "numericUpDownFCount";
            this.numericUpDownFCount.Size = new System.Drawing.Size(131, 21);
            this.numericUpDownFCount.TabIndex = 6;
            this.numericUpDownFCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "设施数量：";
            // 
            // numericUpDownCutoff
            // 
            this.numericUpDownCutoff.Location = new System.Drawing.Point(99, 71);
            this.numericUpDownCutoff.Name = "numericUpDownCutoff";
            this.numericUpDownCutoff.Size = new System.Drawing.Size(131, 21);
            this.numericUpDownCutoff.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cutoff值：";
            // 
            // cboImpedance
            // 
            this.cboImpedance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImpedance.FormattingEnabled = true;
            this.cboImpedance.Location = new System.Drawing.Point(99, 27);
            this.cboImpedance.Name = "cboImpedance";
            this.cboImpedance.Size = new System.Drawing.Size(131, 20);
            this.cboImpedance.TabIndex = 1;
            this.cboImpedance.SelectedIndexChanged += new System.EventHandler(this.cboImpedance_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Impedance：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(268, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 96);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "限制";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(16, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(213, 65);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboTime);
            this.groupBox3.Controls.Add(this.chkUseTime);
            this.groupBox3.Controls.Add(this.cbmDisUnits);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(268, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 85);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "方向";
            // 
            // cboTime
            // 
            this.cboTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTime.FormattingEnabled = true;
            this.cboTime.Location = new System.Drawing.Point(110, 52);
            this.cboTime.Name = "cboTime";
            this.cboTime.Size = new System.Drawing.Size(119, 20);
            this.cboTime.TabIndex = 3;
            // 
            // chkUseTime
            // 
            this.chkUseTime.AutoSize = true;
            this.chkUseTime.Checked = true;
            this.chkUseTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseTime.Location = new System.Drawing.Point(8, 56);
            this.chkUseTime.Name = "chkUseTime";
            this.chkUseTime.Size = new System.Drawing.Size(96, 16);
            this.chkUseTime.TabIndex = 2;
            this.chkUseTime.Text = "使用时间属性";
            this.chkUseTime.UseVisualStyleBackColor = true;
            // 
            // cbmDisUnits
            // 
            this.cbmDisUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmDisUnits.FormattingEnabled = true;
            this.cbmDisUnits.Location = new System.Drawing.Point(74, 23);
            this.cbmDisUnits.Name = "cbmDisUnits";
            this.cbmDisUnits.Size = new System.Drawing.Size(155, 20);
            this.cbmDisUnits.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "距离单位：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(301, 274);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(422, 274);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkIgnoreInvalidValue
            // 
            this.chkIgnoreInvalidValue.AutoSize = true;
            this.chkIgnoreInvalidValue.Checked = true;
            this.chkIgnoreInvalidValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreInvalidValue.Location = new System.Drawing.Point(268, 225);
            this.chkIgnoreInvalidValue.Name = "chkIgnoreInvalidValue";
            this.chkIgnoreInvalidValue.Size = new System.Drawing.Size(108, 16);
            this.chkIgnoreInvalidValue.TabIndex = 3;
            this.chkIgnoreInvalidValue.Text = "忽略无效的数值";
            this.chkIgnoreInvalidValue.UseVisualStyleBackColor = true;
            // 
            // frmNetAnalystSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 310);
            this.Controls.Add(this.chkIgnoreInvalidValue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNetAnalystSetting";
            this.Text = "网络分析设置";
            this.Load += new System.EventHandler(this.frmNetAnalystSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCutoff)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownFCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownCutoff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboImpedance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOutShapeType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAllowedTurn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbnFtoI;
        private System.Windows.Forms.RadioButton rbnItoF;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox cboTime;
        private System.Windows.Forms.CheckBox chkUseTime;
        private System.Windows.Forms.ComboBox cbmDisUnits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkIgnoreInvalidValue;
    }
}