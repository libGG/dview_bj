namespace ReportDemo.Controls
{
    partial class ControlReportTemplateManage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnaddreport = new DevExpress.XtraEditors.SimpleButton();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.categoriesTreeList1 = new ReportDemo.Controls.CategoriesTreeList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesTreeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnaddreport);
            this.panelControl1.Controls.Add(this.btnadd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(621, 26);
            this.panelControl1.TabIndex = 1;
            // 
            // btnaddreport
            // 
            this.btnaddreport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnaddreport.Image = global::ReportDemo.Properties.Resources.预览;
            this.btnaddreport.Location = new System.Drawing.Point(84, 1);
            this.btnaddreport.Name = "btnaddreport";
            this.btnaddreport.Size = new System.Drawing.Size(76, 23);
            this.btnaddreport.TabIndex = 4;
            this.btnaddreport.Text = "模板预览";
            this.btnaddreport.Click += new System.EventHandler(this.btnaddreport_Click);
            // 
            // btnadd
            // 
            this.btnadd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnadd.Image = global::ReportDemo.Properties.Resources.模板定制;
            this.btnadd.Location = new System.Drawing.Point(3, 1);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(76, 23);
            this.btnadd.TabIndex = 0;
            this.btnadd.Text = "模板定制";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // categoriesTreeList1
            // 
            this.categoriesTreeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(235)))));
            this.categoriesTreeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.categoriesTreeList1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.categoriesTreeList1.Appearance.OddRow.Options.UseBackColor = true;
            this.categoriesTreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesTreeList1.Location = new System.Drawing.Point(0, 26);
            this.categoriesTreeList1.Name = "categoriesTreeList1";
            this.categoriesTreeList1.OptionsBehavior.Editable = false;
            this.categoriesTreeList1.OptionsSelection.InvertSelection = true;
            this.categoriesTreeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.categoriesTreeList1.OptionsView.EnableAppearanceOddRow = true;
            this.categoriesTreeList1.OptionsView.ShowIndicator = false;
            this.categoriesTreeList1.Size = new System.Drawing.Size(621, 498);
            this.categoriesTreeList1.TabIndex = 2;
            this.categoriesTreeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.categoriesTree1_MouseDown);
            // 
            // ControlReportTemplateManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.categoriesTreeList1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ControlReportTemplateManage";
            this.Size = new System.Drawing.Size(621, 524);
            this.Load += new System.EventHandler(this.ControlReportTemplateManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesTreeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnaddreport;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private CategoriesTreeList categoriesTreeList1;
    }
}
