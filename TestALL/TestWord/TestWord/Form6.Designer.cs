namespace TestWord
{
    partial class Form6
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
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ribbonBarMergeContainer1 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.ribbonBarMergeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxX1.Location = new System.Drawing.Point(0, 627);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(1238, 1);
            this.textBoxX1.TabIndex = 0;
            // 
            // ribbonBarMergeContainer1
            // 
            this.ribbonBarMergeContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarMergeContainer1.Controls.Add(this.textBoxX1);
            this.ribbonBarMergeContainer1.Location = new System.Drawing.Point(1, 2);
            this.ribbonBarMergeContainer1.Name = "ribbonBarMergeContainer1";
            this.ribbonBarMergeContainer1.Size = new System.Drawing.Size(1238, 628);
            this.ribbonBarMergeContainer1.TabIndex = 0;
            this.ribbonBarMergeContainer1.Visible = false;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 627);
            this.Controls.Add(this.ribbonBarMergeContainer1);
            this.Name = "Form6";
            this.Text = "Form6";
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer1;

    }
}