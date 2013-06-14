using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls; 
namespace Controls
{
    public partial class frmRasterCalculate : Form
    {
        private MainFrm pMainFrm = null;
        public frmRasterCalculate(MainFrm _pMainFrm)
        {
            pMainFrm = _pMainFrm;
            InitializeComponent();
        }
        private void PopulateListBoxWithMapLayers(ListBox Layers, bool bLayer)
        {
            Layers.Items.Clear();
            ILayer aLayer;
            AxMapControl axMap = pMainFrm.getMapControl();
            for (int i = 0; i <= axMap.LayerCount - 1; i++)
            {
                // Get the layer name and add to combo
                aLayer = axMap.get_Layer(i);
                if (aLayer.Valid == true)
                {
                    if (bLayer == true)
                    {
                        if (aLayer is IRasterLayer)
                        {
                            Layers.Items.Add(aLayer.Name);
                        }
                    }

                }
            }
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "*";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "/";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "-";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "+";
        }

        private void frmRasterCalculate_Load(object sender, EventArgs e)
        {
            PopulateListBoxWithMapLayers(listBoxLayer, true);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "9";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "6";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "3";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "0";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = ".";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "=";
        }

        private void btnNotEqual_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "<>";
        }

        private void btnAnd_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "&&";
        }

        private void btnGreater_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = ">";
        }

        private void btnGreatEqual_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = ">=";
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "||";
        }

        private void btnSmaller_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "<";
        }

        private void btnSmallEqual_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "<=";
        }

        private void btnXor_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "^";
        }

        private void btnLeftBracket_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "(";
        }

        private void btnRightBracket_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = ")";
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "!";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {

        }

        private void listBoxLayer_DoubleClick(object sender, EventArgs e)
        {
            txtCalculate.SelectedText = "["+ listBoxLayer.SelectedItem.ToString() + "]";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = "";
        }

      
    }
}