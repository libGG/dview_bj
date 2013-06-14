namespace Controls
{
    partial class frmCRNetASetting
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
            this.chkIgnoreInvalidLocations = new System.Windows.Forms.CheckBox();
            this.cboRouteOutputLines = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboUturnPolicy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPreserveLast = new System.Windows.Forms.CheckBox();
            this.chkPreserveFirst = new System.Windows.Forms.CheckBox();
            this.chkBestOrder = new System.Windows.Forms.CheckBox();
            this.chkUseTimeWindows = new System.Windows.Forms.CheckBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.chkUseStartTime = new System.Windows.Forms.CheckBox();
            this.cboImpedance = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chklstRestrictions = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkOpenDirectionWin = new System.Windows.Forms.CheckBox();
            this.cboRouteDirectionsTimeAttribute = new System.Windows.Forms.ComboBox();
            this.cboRouteDirectionsLengthUnits = new System.Windows.Forms.ComboBox();
            this.chkUseTimeP = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkUseHierarchy = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chklstAccumulateAttributes = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIgnoreInvalidLocations);
            this.groupBox1.Controls.Add(this.cboRouteOutputLines);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboUturnPolicy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkPreserveLast);
            this.groupBox1.Controls.Add(this.chkPreserveFirst);
            this.groupBox1.Controls.Add(this.chkBestOrder);
            this.groupBox1.Controls.Add(this.chkUseTimeWindows);
            this.groupBox1.Controls.Add(this.txtStartTime);
            this.groupBox1.Controls.Add(this.chkUseStartTime);
            this.groupBox1.Controls.Add(this.cboImpedance);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // chkIgnoreInvalidLocations
            // 
            this.chkIgnoreInvalidLocations.AutoSize = true;
            this.chkIgnoreInvalidLocations.Location = new System.Drawing.Point(18, 284);
            this.chkIgnoreInvalidLocations.Name = "chkIgnoreInvalidLocations";
            this.chkIgnoreInvalidLocations.Size = new System.Drawing.Size(114, 16);
            this.chkIgnoreInvalidLocations.TabIndex = 12;
            this.chkIgnoreInvalidLocations.Text = "忽略无效的位置:";
            this.chkIgnoreInvalidLocations.UseVisualStyleBackColor = true;
            // 
            // cboRouteOutputLines
            // 
            this.cboRouteOutputLines.FormattingEnabled = true;
            this.cboRouteOutputLines.Location = new System.Drawing.Point(102, 241);
            this.cboRouteOutputLines.Name = "cboRouteOutputLines";
            this.cboRouteOutputLines.Size = new System.Drawing.Size(121, 20);
            this.cboRouteOutputLines.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "输出形状类型:";
            // 
            // cboUturnPolicy
            // 
            this.cboUturnPolicy.FormattingEnabled = true;
            this.cboUturnPolicy.Location = new System.Drawing.Point(102, 202);
            this.cboUturnPolicy.Name = "cboUturnPolicy";
            this.cboUturnPolicy.Size = new System.Drawing.Size(121, 20);
            this.cboUturnPolicy.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "允许拐点:";
            // 
            // chkPreserveLast
            // 
            this.chkPreserveLast.AutoSize = true;
            this.chkPreserveLast.Location = new System.Drawing.Point(55, 178);
            this.chkPreserveLast.Name = "chkPreserveLast";
            this.chkPreserveLast.Size = new System.Drawing.Size(120, 16);
            this.chkPreserveLast.TabIndex = 7;
            this.chkPreserveLast.Text = "保存最后一个Stop";
            this.chkPreserveLast.UseVisualStyleBackColor = true;
            // 
            // chkPreserveFirst
            // 
            this.chkPreserveFirst.AutoSize = true;
            this.chkPreserveFirst.Location = new System.Drawing.Point(55, 156);
            this.chkPreserveFirst.Name = "chkPreserveFirst";
            this.chkPreserveFirst.Size = new System.Drawing.Size(108, 16);
            this.chkPreserveFirst.TabIndex = 6;
            this.chkPreserveFirst.Text = "保存第一个Stop";
            this.chkPreserveFirst.UseVisualStyleBackColor = true;
            // 
            // chkBestOrder
            // 
            this.chkBestOrder.AutoSize = true;
            this.chkBestOrder.Location = new System.Drawing.Point(18, 134);
            this.chkBestOrder.Name = "chkBestOrder";
            this.chkBestOrder.Size = new System.Drawing.Size(108, 16);
            this.chkBestOrder.TabIndex = 5;
            this.chkBestOrder.Text = "查找最优的路线";
            this.chkBestOrder.UseVisualStyleBackColor = true;
            // 
            // chkUseTimeWindows
            // 
            this.chkUseTimeWindows.AutoSize = true;
            this.chkUseTimeWindows.Location = new System.Drawing.Point(18, 102);
            this.chkUseTimeWindows.Name = "chkUseTimeWindows";
            this.chkUseTimeWindows.Size = new System.Drawing.Size(96, 16);
            this.chkUseTimeWindows.TabIndex = 4;
            this.chkUseTimeWindows.Text = "使用时间窗口";
            this.chkUseTimeWindows.UseVisualStyleBackColor = true;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(102, 66);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(121, 21);
            this.txtStartTime.TabIndex = 3;
            // 
            // chkUseStartTime
            // 
            this.chkUseStartTime.AutoSize = true;
            this.chkUseStartTime.Location = new System.Drawing.Point(18, 71);
            this.chkUseStartTime.Name = "chkUseStartTime";
            this.chkUseStartTime.Size = new System.Drawing.Size(78, 16);
            this.chkUseStartTime.TabIndex = 2;
            this.chkUseStartTime.Text = "开始时间:";
            this.chkUseStartTime.UseVisualStyleBackColor = true;
            // 
            // cboImpedance
            // 
            this.cboImpedance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImpedance.FormattingEnabled = true;
            this.cboImpedance.Location = new System.Drawing.Point(102, 26);
            this.cboImpedance.Name = "cboImpedance";
            this.cboImpedance.Size = new System.Drawing.Size(121, 20);
            this.cboImpedance.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Impedance:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chklstRestrictions);
            this.groupBox2.Location = new System.Drawing.Point(256, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 131);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "限制";
            // 
            // chklstRestrictions
            // 
            this.chklstRestrictions.CheckOnClick = true;
            this.chklstRestrictions.Location = new System.Drawing.Point(6, 20);
            this.chklstRestrictions.Name = "chklstRestrictions";
            this.chklstRestrictions.ScrollAlwaysVisible = true;
            this.chklstRestrictions.Size = new System.Drawing.Size(111, 100);
            this.chklstRestrictions.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkOpenDirectionWin);
            this.groupBox3.Controls.Add(this.cboRouteDirectionsTimeAttribute);
            this.groupBox3.Controls.Add(this.cboRouteDirectionsLengthUnits);
            this.groupBox3.Controls.Add(this.chkUseTimeP);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(256, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 139);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "方向";
            // 
            // chkOpenDirectionWin
            // 
            this.chkOpenDirectionWin.AutoSize = true;
            this.chkOpenDirectionWin.Location = new System.Drawing.Point(19, 104);
            this.chkOpenDirectionWin.Name = "chkOpenDirectionWin";
            this.chkOpenDirectionWin.Size = new System.Drawing.Size(144, 16);
            this.chkOpenDirectionWin.TabIndex = 5;
            this.chkOpenDirectionWin.Text = "自动打开方向属性窗口";
            this.chkOpenDirectionWin.UseVisualStyleBackColor = true;
            // 
            // cboRouteDirectionsTimeAttribute
            // 
            this.cboRouteDirectionsTimeAttribute.FormattingEnabled = true;
            this.cboRouteDirectionsTimeAttribute.Location = new System.Drawing.Point(114, 64);
            this.cboRouteDirectionsTimeAttribute.Name = "cboRouteDirectionsTimeAttribute";
            this.cboRouteDirectionsTimeAttribute.Size = new System.Drawing.Size(121, 20);
            this.cboRouteDirectionsTimeAttribute.TabIndex = 4;
            this.cboRouteDirectionsTimeAttribute.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // cboRouteDirectionsLengthUnits
            // 
            this.cboRouteDirectionsLengthUnits.FormattingEnabled = true;
            this.cboRouteDirectionsLengthUnits.Location = new System.Drawing.Point(114, 25);
            this.cboRouteDirectionsLengthUnits.Name = "cboRouteDirectionsLengthUnits";
            this.cboRouteDirectionsLengthUnits.Size = new System.Drawing.Size(121, 20);
            this.cboRouteDirectionsLengthUnits.TabIndex = 3;
            // 
            // chkUseTimeP
            // 
            this.chkUseTimeP.AutoSize = true;
            this.chkUseTimeP.Checked = true;
            this.chkUseTimeP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseTimeP.Location = new System.Drawing.Point(19, 66);
            this.chkUseTimeP.Name = "chkUseTimeP";
            this.chkUseTimeP.Size = new System.Drawing.Size(96, 16);
            this.chkUseTimeP.TabIndex = 2;
            this.chkUseTimeP.Text = "使用时间属性";
            this.chkUseTimeP.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "距离单位:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(298, 349);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(418, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkUseHierarchy
            // 
            this.chkUseHierarchy.Checked = true;
            this.chkUseHierarchy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseHierarchy.Location = new System.Drawing.Point(389, 12);
            this.chkUseHierarchy.Name = "chkUseHierarchy";
            this.chkUseHierarchy.Size = new System.Drawing.Size(115, 23);
            this.chkUseHierarchy.TabIndex = 16;
            this.chkUseHierarchy.Text = "Use Hierarchy";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chklstAccumulateAttributes);
            this.groupBox4.Location = new System.Drawing.Point(389, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(145, 107);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "累积属性";
            // 
            // chklstAccumulateAttributes
            // 
            this.chklstAccumulateAttributes.CheckOnClick = true;
            this.chklstAccumulateAttributes.Location = new System.Drawing.Point(6, 20);
            this.chklstAccumulateAttributes.Name = "chklstAccumulateAttributes";
            this.chklstAccumulateAttributes.ScrollAlwaysVisible = true;
            this.chklstAccumulateAttributes.Size = new System.Drawing.Size(129, 84);
            this.chklstAccumulateAttributes.TabIndex = 14;
            // 
            // frmCRNetASetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 384);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.chkUseHierarchy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCRNetASetting";
            this.Text = "最短路径网络分析设置";
            this.Load += new System.EventHandler(this.frmCRNetASetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboImpedance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIgnoreInvalidLocations;
        private System.Windows.Forms.ComboBox cboRouteOutputLines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboUturnPolicy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkPreserveLast;
        private System.Windows.Forms.CheckBox chkPreserveFirst;
        private System.Windows.Forms.CheckBox chkBestOrder;
        private System.Windows.Forms.CheckBox chkUseTimeWindows;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.CheckBox chkUseStartTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkOpenDirectionWin;
        private System.Windows.Forms.ComboBox cboRouteDirectionsTimeAttribute;
        private System.Windows.Forms.ComboBox cboRouteDirectionsLengthUnits;
        private System.Windows.Forms.CheckBox chkUseTimeP;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckedListBox chklstRestrictions;
        private System.Windows.Forms.CheckBox chkUseHierarchy;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox chklstAccumulateAttributes;
    }
}