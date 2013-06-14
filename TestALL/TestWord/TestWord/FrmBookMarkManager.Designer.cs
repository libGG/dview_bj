namespace TestWord
{
    partial class FrmBookMarkManager
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBookmark = new DevExpress.XtraEditors.TextEdit();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLoc = new DevExpress.XtraEditors.SimpleButton();
            this.radioButtonName = new System.Windows.Forms.RadioButton();
            this.radioButtonLocation = new System.Windows.Forms.RadioButton();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCurSelectedItem = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookmark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "书签名(&B)：";
            // 
            // txtBookmark
            // 
            this.txtBookmark.Location = new System.Drawing.Point(10, 40);
            this.txtBookmark.Name = "txtBookmark";
            this.txtBookmark.Size = new System.Drawing.Size(201, 21);
            this.txtBookmark.TabIndex = 1;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Location = new System.Drawing.Point(10, 61);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(201, 180);
            this.listBoxControl1.TabIndex = 2;
            this.listBoxControl1.DoubleClick += new System.EventHandler(this.listBoxControl1_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(217, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(217, 81);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(217, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 247);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "排序依据:";
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(217, 124);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "定位";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // radioButtonName
            // 
            this.radioButtonName.AutoSize = true;
            this.radioButtonName.Checked = true;
            this.radioButtonName.Location = new System.Drawing.Point(68, 247);
            this.radioButtonName.Name = "radioButtonName";
            this.radioButtonName.Size = new System.Drawing.Size(49, 18);
            this.radioButtonName.TabIndex = 4;
            this.radioButtonName.TabStop = true;
            this.radioButtonName.Text = "名称";
            this.radioButtonName.UseVisualStyleBackColor = true;
            this.radioButtonName.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonLocation
            // 
            this.radioButtonLocation.AutoSize = true;
            this.radioButtonLocation.Location = new System.Drawing.Point(68, 271);
            this.radioButtonLocation.Name = "radioButtonLocation";
            this.radioButtonLocation.Size = new System.Drawing.Size(49, 18);
            this.radioButtonLocation.TabIndex = 4;
            this.radioButtonLocation.Text = "位置";
            this.radioButtonLocation.UseVisualStyleBackColor = true;
            this.radioButtonLocation.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(217, 218);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(65, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "test";
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(312, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(557, 288);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(217, 169);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(65, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "test";
            this.simpleButton1.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCurSelectedItem
            // 
            this.btnCurSelectedItem.Location = new System.Drawing.Point(217, 169);
            this.btnCurSelectedItem.Name = "btnCurSelectedItem";
            this.btnCurSelectedItem.Size = new System.Drawing.Size(65, 23);
            this.btnCurSelectedItem.TabIndex = 6;
            this.btnCurSelectedItem.Text = "当前";
            this.btnCurSelectedItem.Visible = false;
            this.btnCurSelectedItem.Click += new System.EventHandler(this.btnCurSelectedItem_Click);
            // 
            // FrmBookMarkManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 328);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnCurSelectedItem);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.radioButtonLocation);
            this.Controls.Add(this.radioButtonName);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listBoxControl1);
            this.Controls.Add(this.txtBookmark);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBookMarkManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "书签";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBookMarkManager_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtBookmark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBookmark;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnLoc;
        private System.Windows.Forms.RadioButton radioButtonName;
        private System.Windows.Forms.RadioButton radioButtonLocation;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnCurSelectedItem;
    }
}