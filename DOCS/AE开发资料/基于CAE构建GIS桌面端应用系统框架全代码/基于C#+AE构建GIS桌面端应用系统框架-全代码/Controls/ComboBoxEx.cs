using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms.Design;

namespace Controls
{
    class ComboBoxEx:ComboBox
    {
        private ImageList _imageList;
        //∂®“ÂImageList Ù–‘ 
        public ImageList ImageList
        {
            get
            {
                return _imageList;
            }
            set
            {
                _imageList = value;
            }
        } 

        public ComboBoxEx()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }
        protected override void OnDrawItem(DrawItemEventArgs ea)
        {
            ea.DrawBackground();
            ea.DrawFocusRectangle();

            ComboxBoxExItem item;
            Size imageSize = _imageList.ImageSize;
            Rectangle bounds = ea.Bounds;
            try
            {
                item = (ComboxBoxExItem)Items[ea.Index];
                if (item.ImageIndex != -1)
                {
                    _imageList.Draw(ea.Graphics,bounds.X,bounds.Y,bounds.Width,bounds.Height , item.ImageIndex);
                   // ea.Graphics.DrawString(item.Text, ea.Font, new SolidBrush(ea.ForeColor), bounds.Left+imageSize.Width, bounds.Top);
                }
                else
                {
                   // ea.Graphics.DrawString(item.Text, ea.Font, new SolidBrush(ea.ForeColor), bounds.Left, bounds.Top);
                }
            }
            catch
            {
                if (ea.Index != -1)
                {
                   // ea.Graphics.DrawString(Items[ea.Index].ToString(), ea.Font, new SolidBrush(ea.ForeColor), bounds.Left, bounds.Top);
                }
                else
                {
                   // ea.Graphics.DrawString(Text, ea.Font, new SolidBrush(ea.ForeColor), bounds.Left, bounds.Top);
                }
            }
            base.OnDrawItem(ea);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
  }

   
}
