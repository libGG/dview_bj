using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controls
{
	/// <summary>
	/// frmPointQuery ��ժҪ˵����
	/// </summary>
	public class frmPointQuery : System.Windows.Forms.Form
	{
		public QueryControl.UserControl1 userControl11;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
        
		public frmPointQuery()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			this.Text = "��ѯ���";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
