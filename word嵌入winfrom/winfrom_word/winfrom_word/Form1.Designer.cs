namespace winfrom_word
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
            this.btnOpenWord = new System.Windows.Forms.Button();
            this.btnSaveWord = new System.Windows.Forms.Button();
            this.winWordControl1 = new WinWordControl.WinWordControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenWord
            // 
            this.btnOpenWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenWord.Location = new System.Drawing.Point(593, 402);
            this.btnOpenWord.Name = "btnOpenWord";
            this.btnOpenWord.Size = new System.Drawing.Size(75, 23);
            this.btnOpenWord.TabIndex = 1;
            this.btnOpenWord.Text = "打开word";
            this.btnOpenWord.UseVisualStyleBackColor = true;
            this.btnOpenWord.Click += new System.EventHandler(this.btnOpenWord_Click);
            // 
            // btnSaveWord
            // 
            this.btnSaveWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveWord.Location = new System.Drawing.Point(694, 402);
            this.btnSaveWord.Name = "btnSaveWord";
            this.btnSaveWord.Size = new System.Drawing.Size(75, 23);
            this.btnSaveWord.TabIndex = 1;
            this.btnSaveWord.Text = "保存wrod";
            this.btnSaveWord.UseVisualStyleBackColor = true;
            this.btnSaveWord.Click += new System.EventHandler(this.btnSaveWord_Click);
            // 
            // winWordControl1
            // 
            this.winWordControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.winWordControl1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.winWordControl1.Location = new System.Drawing.Point(2, 1);
            this.winWordControl1.Name = "winWordControl1";
            this.winWordControl1.Size = new System.Drawing.Size(803, 372);
            this.winWordControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 437);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSaveWord);
            this.Controls.Add(this.btnOpenWord);
            this.Controls.Add(this.winWordControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WinWordControl.WinWordControl winWordControl1;
        private System.Windows.Forms.Button btnOpenWord;
        private System.Windows.Forms.Button btnSaveWord;
        private System.Windows.Forms.Button button1;
    }
}

