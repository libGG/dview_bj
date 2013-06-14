namespace Controls
{
    partial class frmAddSDEData
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
            this.txtSDEServer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSDEService = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSDEDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.btnModifyVersion = new System.Windows.Forms.Button();
            this.chkDefaultVersion = new System.Windows.Forms.CheckBox();
            this.btnConnectSDE = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "SDE服务器：";
            // 
            // txtSDEServer
            // 
            this.txtSDEServer.Location = new System.Drawing.Point(135, 20);
            this.txtSDEServer.Name = "txtSDEServer";
            this.txtSDEServer.Size = new System.Drawing.Size(252, 21);
            this.txtSDEServer.TabIndex = 1;
            this.txtSDEServer.Text = "chenxd";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSDEService);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSDEDatabase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSDEServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 189);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SDE连接参数";
            // 
            // txtSDEService
            // 
            this.txtSDEService.Location = new System.Drawing.Point(135, 54);
            this.txtSDEService.Name = "txtSDEService";
            this.txtSDEService.Size = new System.Drawing.Size(252, 21);
            this.txtSDEService.TabIndex = 9;
            this.txtSDEService.Text = "sde:sql server:chenxd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "SDE服务：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(135, 156);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(252, 21);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Text = "111111";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码：";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(135, 122);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(252, 21);
            this.txtUser.TabIndex = 5;
            this.txtUser.Text = "sde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名：";
            // 
            // txtSDEDatabase
            // 
            this.txtSDEDatabase.Location = new System.Drawing.Point(135, 88);
            this.txtSDEDatabase.Name = "txtSDEDatabase";
            this.txtSDEDatabase.Size = new System.Drawing.Size(252, 21);
            this.txtSDEDatabase.TabIndex = 3;
            this.txtSDEDatabase.Text = "sde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "SDE数据库：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelVersion);
            this.groupBox2.Controls.Add(this.btnModifyVersion);
            this.groupBox2.Controls.Add(this.chkDefaultVersion);
            this.groupBox2.Location = new System.Drawing.Point(12, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 60);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "版本";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(133, 25);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(71, 12);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "SDE.DEFAULT";
            // 
            // btnModifyVersion
            // 
            this.btnModifyVersion.Location = new System.Drawing.Point(301, 20);
            this.btnModifyVersion.Name = "btnModifyVersion";
            this.btnModifyVersion.Size = new System.Drawing.Size(86, 23);
            this.btnModifyVersion.TabIndex = 1;
            this.btnModifyVersion.Text = "修改版本";
            this.btnModifyVersion.UseVisualStyleBackColor = true;
            this.btnModifyVersion.Click += new System.EventHandler(this.btnModifyVersion_Click);
            // 
            // chkDefaultVersion
            // 
            this.chkDefaultVersion.AutoSize = true;
            this.chkDefaultVersion.Checked = true;
            this.chkDefaultVersion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultVersion.Location = new System.Drawing.Point(27, 24);
            this.chkDefaultVersion.Name = "chkDefaultVersion";
            this.chkDefaultVersion.Size = new System.Drawing.Size(72, 16);
            this.chkDefaultVersion.TabIndex = 0;
            this.chkDefaultVersion.Text = "保存版本";
            this.chkDefaultVersion.UseVisualStyleBackColor = true;
            // 
            // btnConnectSDE
            // 
            this.btnConnectSDE.Location = new System.Drawing.Point(15, 374);
            this.btnConnectSDE.Name = "btnConnectSDE";
            this.btnConnectSDE.Size = new System.Drawing.Size(75, 23);
            this.btnConnectSDE.TabIndex = 4;
            this.btnConnectSDE.Text = "测试连接";
            this.btnConnectSDE.UseVisualStyleBackColor = true;
            this.btnConnectSDE.Click += new System.EventHandler(this.btnConnectSDE_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(226, 374);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(324, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 273);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(417, 95);
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // frmAddSDEData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 403);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnConnectSDE);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddSDEData";
            this.Text = "添加SDE数据";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSDEServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSDEDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDefaultVersion;
        private System.Windows.Forms.Button btnModifyVersion;
        private System.Windows.Forms.Button btnConnectSDE;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSDEService;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TreeView treeView1;
    }
}