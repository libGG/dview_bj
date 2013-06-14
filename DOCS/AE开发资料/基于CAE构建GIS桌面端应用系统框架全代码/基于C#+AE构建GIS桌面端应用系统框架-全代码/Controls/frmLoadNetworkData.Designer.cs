namespace Controls
{
    partial class frmLoadNetworkData
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
            this.comboBoxDataList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxUnits = new System.Windows.Forms.ComboBox();
            this.textBoxTolerance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "装载数据从：";
            // 
            // comboBoxDataList
            // 
            this.comboBoxDataList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataList.FormattingEnabled = true;
            this.comboBoxDataList.Location = new System.Drawing.Point(95, 15);
            this.comboBoxDataList.Name = "comboBoxDataList";
            this.comboBoxDataList.Size = new System.Drawing.Size(184, 20);
            this.comboBoxDataList.TabIndex = 1;
            this.comboBoxDataList.SelectedIndexChanged += new System.EventHandler(this.comboBoxDataList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxUnits);
            this.groupBox1.Controls.Add(this.textBoxTolerance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "位置定位";
            // 
            // comboBoxUnits
            // 
            this.comboBoxUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnits.FormattingEnabled = true;
            this.comboBoxUnits.Location = new System.Drawing.Point(211, 31);
            this.comboBoxUnits.Name = "comboBoxUnits";
            this.comboBoxUnits.Size = new System.Drawing.Size(71, 20);
            this.comboBoxUnits.TabIndex = 2;
            // 
            // textBoxTolerance
            // 
            this.textBoxTolerance.Location = new System.Drawing.Point(83, 31);
            this.textBoxTolerance.Name = "textBoxTolerance";
            this.textBoxTolerance.Size = new System.Drawing.Size(108, 21);
            this.textBoxTolerance.TabIndex = 1;
            this.textBoxTolerance.Text = "5000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "搜索容差：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(128, 153);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Image = global::Controls.Properties.Resources.adddata;
            this.btnLoadData.Location = new System.Drawing.Point(285, 14);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(29, 23);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // frmLoadNetworkData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 191);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.comboBoxDataList);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoadNetworkData";
            this.Text = "装载网络特征数据";
            this.Load += new System.EventHandler(this.frmLoadNetworkData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDataList;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxUnits;
        private System.Windows.Forms.TextBox textBoxTolerance;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}