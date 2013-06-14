using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controls
{
	/// <summary>
	/// frmPointQuery 的摘要说明。
	/// </summary>
	public class frmPointQuery : System.Windows.Forms.Form
	{
		public QueryControl.UserControl1 userControl11;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        
		public frmPointQuery()
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
			this.userControl11 = new QueryControl.UserControl1();
			this.SuspendLayout();
			// 
			// userControl11
			// 
			this.userControl11.Location = new System.Drawing.Point(0, 0);
			this.userControl11.MapControl = null;
			this.userControl11.MousePoint = null;
			this.userControl11.Name = "userControl11";
			this.userControl11.Size = new System.Drawing.Size(376, 280);
			this.userControl11.TabIndex = 0;
			// 
			// frmPointQuery
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(376, 278);
			this.Controls.Add(this.userControl11);
			this.Name = "frmPointQuery";
			this.Text = "查询结果";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
