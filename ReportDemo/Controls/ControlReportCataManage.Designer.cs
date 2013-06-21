namespace ReportDemo.Controls
{
    partial class ControlReportCataManage
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
            this.btnquery = new DevExpress.XtraEditors.SimpleButton();
            this.btndelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnupdate = new DevExpress.XtraEditors.SimpleButton();
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
            this.panelControl1.Controls.Add(this.btnquery);
            this.panelControl1.Controls.Add(this.btndelete);
            this.panelControl1.Controls.Add(this.btnupdate);
            this.panelControl1.Controls.Add(this.btnadd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(621, 26);
            this.panelControl1.TabIndex = 0;
            // 
            // btnaddreport
            // 
            this.btnaddreport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnaddreport.Image = global::ReportDemo.Properties.Resources.添加1_16;
            this.btnaddreport.Location = new System.Drawing.Point(84, 1);
            this.btnaddreport.Name = "btnaddreport";
            this.btnaddreport.Size = new System.Drawing.Size(76, 23);
            this.btnaddreport.TabIndex = 4;
            this.btnaddreport.Text = "添加报告";
            this.btnaddreport.Click += new System.EventHandler(this.btnaddreport_Click);
            // 
            // btnquery
            // 
            this.btnquery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnquery.Image = global::ReportDemo.Properties.Resources.查询_16;
            this.btnquery.Location = new System.Drawing.Point(275, 1);
            this.btnquery.Name = "btnquery";
            this.btnquery.Size = new System.Drawing.Size(50, 23);
            this.btnquery.TabIndex = 3;
            this.btnquery.Text = "查询";
            this.btnquery.Visible = false;
            this.btnquery.Click += new System.EventHandler(this.btnquery_Click);
            // 
            // btndelete
            // 
            this.btndelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btndelete.Image = global::ReportDemo.Properties.Resources.删除_16;
            this.btndelete.Location = new System.Drawing.Point(220, 1);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(50, 23);
            this.btndelete.TabIndex = 2;
            this.btndelete.Text = "删除";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnupdate.Image = global::ReportDemo.Properties.Resources.修改_16;
            this.btnupdate.Location = new System.Drawing.Point(165, 1);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(50, 23);
            this.btnupdate.TabIndex = 1;
            this.btnupdate.Text = "修改";
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnadd
            // 
            this.btnadd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnadd.Image = global::ReportDemo.Properties.Resources.添加_16;
            this.btnadd.Location = new System.Drawing.Point(3, 1);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(76, 23);
            this.btnadd.TabIndex = 0;
            this.btnadd.Text = "添加类别";
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
            this.categoriesTreeList1.TabIndex = 1;
            this.categoriesTreeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.categoriesTree1_MouseDown);
            // 
            // ControlReportCataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.categoriesTreeList1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ControlReportCataManage";
            this.Size = new System.Drawing.Size(621, 524);
            this.Load += new System.EventHandler(this.ControlReportCataManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesTreeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.SimpleButton btnquery;
        private DevExpress.XtraEditors.SimpleButton btndelete;
        private DevExpress.XtraEditors.SimpleButton btnupdate;
        private CategoriesTreeList categoriesTreeList1;
        private DevExpress.XtraEditors.SimpleButton btnaddreport;

    }
}
