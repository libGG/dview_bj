namespace Controls
{
    partial class frmCellStatistic
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
            this.listBoxLayer = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRightOne = new System.Windows.Forms.Button();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxAddedLayer = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutData = new System.Windows.Forms.TextBox();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnLeftOne = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxLayer
            // 
            this.listBoxLayer.FormattingEnabled = true;
            this.listBoxLayer.ItemHeight = 12;
            this.listBoxLayer.Location = new System.Drawing.Point(12, 34);
            this.listBoxLayer.Name = "listBoxLayer";
            this.listBoxLayer.Size = new System.Drawing.Size(131, 160);
            this.listBoxLayer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "图层列表：";
            // 
            // btnRightOne
            // 
            this.btnRightOne.Location = new System.Drawing.Point(149, 34);
            this.btnRightOne.Name = "btnRightOne";
            this.btnRightOne.Size = new System.Drawing.Size(60, 23);
            this.btnRightOne.TabIndex = 2;
            this.btnRightOne.Text = ">";
            this.btnRightOne.UseVisualStyleBackColor = true;
            this.btnRightOne.Click += new System.EventHandler(this.btnRightOne_Click);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.Location = new System.Drawing.Point(149, 169);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(60, 23);
            this.btnLeftAll.TabIndex = 3;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = true;
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "输入的栅格图层：";
            // 
            // listBoxAddedLayer
            // 
            this.listBoxAddedLayer.FormattingEnabled = true;
            this.listBoxAddedLayer.ItemHeight = 12;
            this.listBoxAddedLayer.Location = new System.Drawing.Point(215, 34);
            this.listBoxAddedLayer.Name = "listBoxAddedLayer";
            this.listBoxAddedLayer.Size = new System.Drawing.Size(133, 160);
            this.listBoxAddedLayer.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "统计方法：";
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Location = new System.Drawing.Point(95, 217);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(253, 20);
            this.comboBoxMethod.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "输出栅格：";
            // 
            // txtOutData
            // 
            this.txtOutData.Location = new System.Drawing.Point(95, 253);
            this.txtOutData.Name = "txtOutData";
            this.txtOutData.Size = new System.Drawing.Size(222, 21);
            this.txtOutData.TabIndex = 9;
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(181, 297);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 11;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(273, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Destroy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Controls.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(323, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(25, 24);
            this.btnSave.TabIndex = 10;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRightAll
            // 
            this.btnRightAll.Location = new System.Drawing.Point(149, 79);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(60, 23);
            this.btnRightAll.TabIndex = 13;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = true;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // btnLeftOne
            // 
            this.btnLeftOne.Location = new System.Drawing.Point(149, 124);
            this.btnLeftOne.Name = "btnLeftOne";
            this.btnLeftOne.Size = new System.Drawing.Size(60, 23);
            this.btnLeftOne.TabIndex = 14;
            this.btnLeftOne.Text = "<";
            this.btnLeftOne.UseVisualStyleBackColor = true;
            this.btnLeftOne.Click += new System.EventHandler(this.btnLeftOne_Click);
            // 
            // frmCellStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 332);
            this.Controls.Add(this.btnLeftOne);
            this.Controls.Add(this.btnRightAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOutData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxMethod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxAddedLayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLeftAll);
            this.Controls.Add(this.btnRightOne);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxLayer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCellStatistic";
            this.Text = "象素统计";
            this.Load += new System.EventHandler(this.frmCellStatistic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRightOne;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxAddedLayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnLeftOne;
    }
}