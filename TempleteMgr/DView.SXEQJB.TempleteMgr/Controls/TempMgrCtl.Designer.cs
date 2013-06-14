namespace DView.SXEQJB.TempleteMgr.Controls
{
    partial class TempMgrCtl
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
            this.categoriesTreeList1 = new DView.SXEQJB.TempleteMgr.CategoriesTreeList(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnPreView2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnModify2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCustomize2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesTreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoriesTreeList1
            // 
            this.categoriesTreeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(235)))));
            this.categoriesTreeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.categoriesTreeList1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.categoriesTreeList1.Appearance.OddRow.Options.UseBackColor = true;
            this.categoriesTreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesTreeList1.Location = new System.Drawing.Point(0, 43);
            this.categoriesTreeList1.Name = "categoriesTreeList1";
            this.categoriesTreeList1.OptionsBehavior.Editable = false;
            this.categoriesTreeList1.OptionsSelection.InvertSelection = true;
            this.categoriesTreeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.categoriesTreeList1.OptionsView.EnableAppearanceOddRow = true;
            this.categoriesTreeList1.OptionsView.ShowIndicator = false;
            this.categoriesTreeList1.Size = new System.Drawing.Size(809, 529);
            this.categoriesTreeList1.TabIndex = 3;
            this.categoriesTreeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.categoriesTreeList1_MouseDown);
            this.categoriesTreeList1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.categoriesTreeList1_MouseDoubleClick);
            this.categoriesTreeList1.MBFocusedNodeChanged += new DView.SXEQJB.TempleteMgr.MBFocusedNodeChangedEventHandler(this.OnMBFocusedNodeChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.ContentImage = global::DView.SXEQJB.TempleteMgr.Properties.Resources.panel_backColor_new;
            this.panelControl1.Controls.Add(this.btnPreView2);
            this.panelControl1.Controls.Add(this.btnDelete2);
            this.panelControl1.Controls.Add(this.btnModify2);
            this.panelControl1.Controls.Add(this.btnCustomize2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(809, 43);
            this.panelControl1.TabIndex = 2;
            // 
            // btnPreView2
            // 
            this.btnPreView2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnPreView2.Image = global::DView.SXEQJB.TempleteMgr.Properties.Resources.preview_32;
            this.btnPreView2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPreView2.Location = new System.Drawing.Point(306, 3);
            this.btnPreView2.Name = "btnPreView2";
            this.btnPreView2.Size = new System.Drawing.Size(97, 37);
            this.btnPreView2.TabIndex = 0;
            this.btnPreView2.Text = "模板预览";
            this.btnPreView2.ToolTip = "预览选中的模板";
            this.btnPreView2.Click += new System.EventHandler(this.btnPreView2_Click);
            // 
            // btnDelete2
            // 
            this.btnDelete2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnDelete2.Image = global::DView.SXEQJB.TempleteMgr.Properties.Resources.del_btn_32;
            this.btnDelete2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDelete2.Location = new System.Drawing.Point(205, 3);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(97, 37);
            this.btnDelete2.TabIndex = 0;
            this.btnDelete2.Text = "模板删除";
            this.btnDelete2.ToolTip = "删除选中的模板";
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnModify2
            // 
            this.btnModify2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnModify2.Image = global::DView.SXEQJB.TempleteMgr.Properties.Resources.modify_btn2;
            this.btnModify2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnModify2.Location = new System.Drawing.Point(104, 3);
            this.btnModify2.Name = "btnModify2";
            this.btnModify2.Size = new System.Drawing.Size(97, 37);
            this.btnModify2.TabIndex = 0;
            this.btnModify2.Text = "模板修改";
            this.btnModify2.ToolTip = "修改现有模板";
            this.btnModify2.Click += new System.EventHandler(this.btnModify2_Click);
            // 
            // btnCustomize2
            // 
            this.btnCustomize2.BackgroundImage = global::DView.SXEQJB.TempleteMgr.Properties.Resources.button_color_big;
            this.btnCustomize2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCustomize2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnCustomize2.Image = global::DView.SXEQJB.TempleteMgr.Properties.Resources.customize_btn_32;
            this.btnCustomize2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCustomize2.Location = new System.Drawing.Point(3, 3);
            this.btnCustomize2.Name = "btnCustomize2";
            this.btnCustomize2.Size = new System.Drawing.Size(97, 37);
            this.btnCustomize2.TabIndex = 0;
            this.btnCustomize2.Text = "模板定制";
            this.btnCustomize2.ToolTip = "新建或导入已有模板";
            this.btnCustomize2.Click += new System.EventHandler(this.btnCustomize2_Click);
            // 
            // TempMgrCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.categoriesTreeList1);
            this.Controls.Add(this.panelControl1);
            this.Name = "TempMgrCtl";
            this.Size = new System.Drawing.Size(809, 572);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesTreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CategoriesTreeList categoriesTreeList1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPreView2;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        private DevExpress.XtraEditors.SimpleButton btnModify2;
        private DevExpress.XtraEditors.SimpleButton btnCustomize2;
    }
}
