using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraEditors;

namespace TestWord
{
    public partial class DViewButton : SimpleButton
    {
        public DViewButton()
        {
            InitializeComponent();
        }

        public DViewButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            
        }
    }
}
