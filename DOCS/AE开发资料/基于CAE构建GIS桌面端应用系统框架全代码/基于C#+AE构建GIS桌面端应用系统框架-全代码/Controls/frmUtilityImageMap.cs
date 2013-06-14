using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Controls
{
    public partial class frmUtilityImageMap : Form
    {
        public frmUtilityImageMap()
        {
            InitializeComponent();
        }

        private void frmUtilityImageMap_Load(object sender, EventArgs e)
        {
          
             string sDataPath = Application.StartupPath + @"\..\..\..\Data\Sewer9\data\planscans";
            axMapControl1.AddLayerFromFile(sDataPath + "\\36-6im.tif.lyr");
            axMapControl1.AddLayerFromFile(sDataPath + "\\36-5im.tif.lyr");
            axMapControl1.AddLayerFromFile(sDataPath + "\\36-4im.tif.lyr");
            axMapControl1.AddLayerFromFile(sDataPath + "\\36-3im.tif.lyr");
            axMapControl1.AddLayerFromFile(sDataPath + "\\36-2im.tif.lyr");
            axMapControl1.AddLayerFromFile(sDataPath + "\\36-1im.tif.lyr");

            listBox1.Items.Clear();
            listBox1.Items.Add("标题单");
            listBox1.Items.Add("工程建设细节");
            listBox1.Items.Add("计划和剖面表单-1");
            listBox1.Items.Add("计划和剖面表单-2");
            listBox1.Items.Add("计划和剖面表单-3");
            listBox1.Items.Add("计划和剖面表单-4");
            listBox1.SelectedIndex = 0;
        }

      

        private void listBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= axMapControl1.LayerCount - 1; i++)
            {
                axMapControl1.get_Layer(i).Visible = false;
            }
            axMapControl1.Extent = axMapControl1.FullExtent;
            axMapControl1.get_Layer(listBox1.SelectedIndex).Visible = true;
            axMapControl1.Refresh();
        }
    }
}