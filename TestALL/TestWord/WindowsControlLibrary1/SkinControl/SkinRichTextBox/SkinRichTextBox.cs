using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(RichTextBox))]
    public class SkinRichTextBox : RichTextBox
    {
        private RichEditOle _richEditOle;
        private Dictionary<int, REOBJECT> _oleObjectList;

        public SkinRichTextBox()
            : base()
        {
        }

        public Dictionary<int, REOBJECT> OleObjectList
        {
            get
            {
                if (_oleObjectList == null)
                {
                    _oleObjectList = new Dictionary<int, REOBJECT>(10);
                }
                return _oleObjectList;
            }
        }

        public RichEditOle RichEditOle
        {
            get
            {
                if (_richEditOle == null)
                {
                    if (base.IsHandleCreated)
                    {
                        _richEditOle = new RichEditOle(this);
                    }
                }

                return _richEditOle;
            }
        }

        public bool InsertImageUseGifBox(string path)
        {
            try
            {
                SkinGifBox gif = new SkinGifBox();
                gif.BackColor = base.BackColor;
                gif.Image = Image.FromFile(path);
                RichEditOle.InsertControl(gif);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
