namespace Controls
{
    partial class frmSymbolSet //x
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSymbolSet));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxEx1 = new Controls.ComboBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxUnique = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnAddAllValues = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.imageListUnique = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(156, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 312);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(441, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "单值图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(6, 85);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(432, 196);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxEx1);
            this.groupBox2.Location = new System.Drawing.Point(191, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 68);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "颜色";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ImageList = null;
            this.comboBoxEx1.Location = new System.Drawing.Point(21, 25);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(210, 22);
            this.comboBoxEx1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxUnique);
            this.groupBox1.Location = new System.Drawing.Point(6, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字段";
            // 
            // comboBoxUnique
            // 
            this.comboBoxUnique.FormattingEnabled = true;
            this.comboBoxUnique.Location = new System.Drawing.Point(6, 20);
            this.comboBoxUnique.Name = "comboBoxUnique";
            this.comboBoxUnique.Size = new System.Drawing.Size(159, 20);
            this.comboBoxUnique.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(441, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "分类图";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(441, 287);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(398, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取　消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(519, 323);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(82, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "应　用";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnAddAllValues
            // 
            this.btnAddAllValues.Location = new System.Drawing.Point(156, 323);
            this.btnAddAllValues.Name = "btnAddAllValues";
            this.btnAddAllValues.Size = new System.Drawing.Size(82, 23);
            this.btnAddAllValues.TabIndex = 5;
            this.btnAddAllValues.Text = "添加所有值";
            this.btnAddAllValues.UseVisualStyleBackColor = true;
            this.btnAddAllValues.Click += new System.EventHandler(this.btnAddAllValues_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(277, 323);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确　定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // imageListUnique
            // 
            this.imageListUnique.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListUnique.ImageStream")));
            this.imageListUnique.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListUnique.Images.SetKeyName(0, "YellowToRed.bmp");
            this.imageListUnique.Images.SetKeyName(1, "GreenToBlue.bmp");
            this.imageListUnique.Images.SetKeyName(2, "GreenToRed.bmp");
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(4, 5);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(149, 206);
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Controls.Properties.Resources.Unique;
            this.pictureBox1.Location = new System.Drawing.Point(6, 217);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Unique.bmp");
            this.imageList2.Images.SetKeyName(1, "Bar.bmp");
            this.imageList2.Images.SetKeyName(2, "Dot.bmp");
            this.imageList2.Images.SetKeyName(3, "GraduatedColor.bmp");
            this.imageList2.Images.SetKeyName(4, "GraduatedSymbol.bmp");
            this.imageList2.Images.SetKeyName(5, "Pie.bmp");
            this.imageList2.Images.SetKeyName(6, "Stack.bmp");
            // 
            // frmSymbolSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 357);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAddAllValues);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSymbolSet";
            this.Text = "符号化";
            this.Load += new System.EventHandler(this.frmSymbolSet_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnAddAllValues;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxUnique;
        private System.Windows.Forms.ImageList imageListUnique;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TreeView treeView1;
        private ComboBoxEx comboBoxEx1;
        private System.Windows.Forms.ImageList imageList2;
    }
}