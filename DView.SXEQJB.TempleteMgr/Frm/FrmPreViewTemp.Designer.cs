namespace DView.SXEQJB.TempleteMgr
{
    partial class FrmPreViewTemp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPreViewTemp));
            this.axFramerControlPreView = new AxDSOFramer.AxFramerControl();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControlPreView)).BeginInit();
            this.SuspendLayout();
            // 
            // axFramerControlPreView
            // 
            this.axFramerControlPreView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFramerControlPreView.Enabled = true;
            this.axFramerControlPreView.Location = new System.Drawing.Point(0, 0);
            this.axFramerControlPreView.Name = "axFramerControlPreView";
            this.axFramerControlPreView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFramerControlPreView.OcxState")));
            this.axFramerControlPreView.Size = new System.Drawing.Size(915, 660);
            this.axFramerControlPreView.TabIndex = 0;
            // 
            // FrmPreViewTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 660);
            this.Controls.Add(this.axFramerControlPreView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPreViewTemp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmPreViewTemp";
            this.Load += new System.EventHandler(this.FrmPreViewTemp_Load);
            this.Shown += new System.EventHandler(this.FrmPreViewTemp_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPreViewTemp_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControlPreView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxDSOFramer.AxFramerControl axFramerControlPreView;
    }
}