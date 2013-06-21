namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.mapPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenGoogleEarthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddkmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPanel
            // 
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(0, 25);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(1046, 915);
            this.mapPanel.TabIndex = 2;
            this.mapPanel.SizeChanged += new System.EventHandler(this.mapPanel_SizeChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.图层ToolStripMenuItem,
            this.AddkmlToolStripMenuItem,
            this.aaaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenGoogleEarthToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.OpenToolStripMenuItem.Text = "打开";
            // 
            // OpenGoogleEarthToolStripMenuItem
            // 
            this.OpenGoogleEarthToolStripMenuItem.Name = "OpenGoogleEarthToolStripMenuItem";
            this.OpenGoogleEarthToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.OpenGoogleEarthToolStripMenuItem.Text = "打开GoogleEarth";
            this.OpenGoogleEarthToolStripMenuItem.Click += new System.EventHandler(this.OpenGoogleEarthToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // 图层ToolStripMenuItem
            // 
            this.图层ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLayerToolStripMenuItem});
            this.图层ToolStripMenuItem.Name = "图层ToolStripMenuItem";
            this.图层ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.图层ToolStripMenuItem.Text = "图层";
            // 
            // showLayerToolStripMenuItem
            // 
            this.showLayerToolStripMenuItem.Name = "showLayerToolStripMenuItem";
            this.showLayerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.showLayerToolStripMenuItem.Text = "ShowLayer";
            this.showLayerToolStripMenuItem.Click += new System.EventHandler(this.showLayerToolStripMenuItem_Click);
            // 
            // AddkmlToolStripMenuItem
            // 
            this.AddkmlToolStripMenuItem.Name = "AddkmlToolStripMenuItem";
            this.AddkmlToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.AddkmlToolStripMenuItem.Text = "加载kml";
            this.AddkmlToolStripMenuItem.Click += new System.EventHandler(this.AddkmlToolStripMenuItem_Click);
            // 
            // aaaToolStripMenuItem
            // 
            this.aaaToolStripMenuItem.Name = "aaaToolStripMenuItem";
            this.aaaToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.aaaToolStripMenuItem.Text = "aaa";
            this.aaaToolStripMenuItem.Click += new System.EventHandler(this.aaaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 940);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenGoogleEarthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddkmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aaaToolStripMenuItem;
    }
}

