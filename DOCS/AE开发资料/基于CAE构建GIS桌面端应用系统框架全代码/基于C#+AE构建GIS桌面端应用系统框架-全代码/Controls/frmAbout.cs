using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controls
{
	/// <summary>
	/// frmAbout 的摘要说明。
	/// </summary>
	public class frmAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAbout()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAbout));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(104, 88);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(136, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(304, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "ArcGIS Engine .Net框架和高级分析功能演示";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(136, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(304, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "版权所有(c)2006 陈雪冬";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// frmAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(424, 104);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAbout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "关于";
			this.Click += new System.EventHandler(this.frmAbout_Click);
			this.Load += new System.EventHandler(this.frmAbout_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAbout_Load(object sender, System.EventArgs e)
		{
		
		}

		private void frmAbout_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
		this.Dispose();
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		this.Dispose();
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
		this.Dispose();
		}
	}
}
