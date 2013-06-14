namespace Controls
{
    partial class frmChangeVersion
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
            this.treeViewVersion = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVersionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVersionDes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnPublic = new System.Windows.Forms.RadioButton();
            this.rbtnPrivate = new System.Windows.Forms.RadioButton();
            this.rbtnProtect = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCreateDate = new System.Windows.Forms.TextBox();
            this.txtModifyDate = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewVersion
            // 
            this.treeViewVersion.Location = new System.Drawing.Point(3, 2);
            this.treeViewVersion.Name = "treeViewVersion";
            this.treeViewVersion.Size = new System.Drawing.Size(385, 172);
            this.treeViewVersion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "详细名称：";
            // 
            // txtVersionName
            // 
            this.txtVersionName.Location = new System.Drawing.Point(107, 185);
            this.txtVersionName.Name = "txtVersionName";
            this.txtVersionName.Size = new System.Drawing.Size(281, 21);
            this.txtVersionName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "描述：";
            // 
            // txtVersionDes
            // 
            this.txtVersionDes.Location = new System.Drawing.Point(107, 214);
            this.txtVersionDes.Name = "txtVersionDes";
            this.txtVersionDes.Size = new System.Drawing.Size(281, 21);
            this.txtVersionDes.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnProtect);
            this.groupBox1.Controls.Add(this.rbtnPrivate);
            this.groupBox1.Controls.Add(this.rbtnPublic);
            this.groupBox1.Location = new System.Drawing.Point(3, 299);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 55);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "种类";
            // 
            // rbtnPublic
            // 
            this.rbtnPublic.AutoSize = true;
            this.rbtnPublic.Location = new System.Drawing.Point(37, 20);
            this.rbtnPublic.Name = "rbtnPublic";
            this.rbtnPublic.Size = new System.Drawing.Size(59, 16);
            this.rbtnPublic.TabIndex = 0;
            this.rbtnPublic.TabStop = true;
            this.rbtnPublic.Text = "公共的";
            this.rbtnPublic.UseVisualStyleBackColor = true;
            // 
            // rbtnPrivate
            // 
            this.rbtnPrivate.AutoSize = true;
            this.rbtnPrivate.Location = new System.Drawing.Point(164, 20);
            this.rbtnPrivate.Name = "rbtnPrivate";
            this.rbtnPrivate.Size = new System.Drawing.Size(59, 16);
            this.rbtnPrivate.TabIndex = 1;
            this.rbtnPrivate.TabStop = true;
            this.rbtnPrivate.Text = "私有的";
            this.rbtnPrivate.UseVisualStyleBackColor = true;
            // 
            // rbtnProtect
            // 
            this.rbtnProtect.AutoSize = true;
            this.rbtnProtect.Location = new System.Drawing.Point(291, 20);
            this.rbtnProtect.Name = "rbtnProtect";
            this.rbtnProtect.Size = new System.Drawing.Size(59, 16);
            this.rbtnProtect.TabIndex = 2;
            this.rbtnProtect.TabStop = true;
            this.rbtnProtect.Text = "保护的";
            this.rbtnProtect.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "创建日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "修改日期：";
            // 
            // txtCreateDate
            // 
            this.txtCreateDate.Location = new System.Drawing.Point(107, 243);
            this.txtCreateDate.Name = "txtCreateDate";
            this.txtCreateDate.Size = new System.Drawing.Size(281, 21);
            this.txtCreateDate.TabIndex = 8;
            // 
            // txtModifyDate
            // 
            this.txtModifyDate.Location = new System.Drawing.Point(107, 272);
            this.txtModifyDate.Name = "txtModifyDate";
            this.txtModifyDate.Size = new System.Drawing.Size(281, 21);
            this.txtModifyDate.TabIndex = 9;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(180, 375);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(294, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmChangeVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 410);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtModifyDate);
            this.Controls.Add(this.txtCreateDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtVersionDes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVersionName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewVersion);
            this.Name = "frmChangeVersion";
            this.Text = "版本管理";
            this.Load += new System.EventHandler(this.frmChangeVersion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVersionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVersionDes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnProtect;
        private System.Windows.Forms.RadioButton rbtnPrivate;
        private System.Windows.Forms.RadioButton rbtnPublic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCreateDate;
        private System.Windows.Forms.TextBox txtModifyDate;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}