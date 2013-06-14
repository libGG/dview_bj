using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Carto;
namespace Controls
{
    public partial class frmSetLayerTips : Form
    {
        private MainFrm pMainFrm = null;
        public frmSetLayerTips(MainFrm _pMainFrm,string sLayerName)
        {
            pMainFrm = _pMainFrm;
           
            InitializeComponent();
            comboBoxLayer.Items.Clear();
            comboBoxLayer.Items.Add(sLayerName);
            comboBoxLayer.Text = sLayerName;
            InitDataLayer();
        }
        private void ShowLayerTips()
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            //Loop through the maps layers
            for (int i = 0; i <= axMap.LayerCount - 1; i++)
            {
                //Get ILayer interface
                ILayer layer = axMap.get_Layer(i);
                //If is the layer selected in the control
                if (comboBoxLayer.Text == layer.Name )
                {
                    //If want to show map tips
                    if (chkShowTips.CheckState == CheckState.Checked)
                    {
                        layer.ShowTips = true;
                    }
                    else
                    {
                        layer.ShowTips = false;
                    }
                }
                else
                {
                    layer.ShowTips = false;
                }
            }
        }
        private void InitDataLayer()
        {

            IFeatureLayer featureLayer = GetFeatLayerByName(comboBoxLayer.Text);
            //Query inteface for ILayerFields
            ILayerFields layerFields = (ILayerFields)featureLayer;

            int j = 0;
            comboBoxField.Items.Clear();
            comboBoxField.Enabled = true;
            //Loop through the fields
            for (int i = 0; i <= layerFields.FieldCount - 1; i++)
            {
                //Get IField interface
                IField field = layerFields.get_Field(i);
                //If the field is not the shape field
                if (field.Type != esriFieldType.esriFieldTypeGeometry)
                {
                    //Add field name to the control
                    comboBoxField.Items.Insert(j, field.Name);
                    //If the field name is the display field
                    if (field.Name == featureLayer.DisplayField)
                    {
                        //Select the field name in the control
                        comboBoxField.SelectedIndex = j;
                    }
                    j = j + 1;
                }
            }
        }
        private IFeatureLayer GetFeatLayerByName(string strLayerName)
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            ILayer pLayer = null;
            IFeatureLayer pFeatLyr = null;
            for (int i = 0; i <= axMap.LayerCount - 1; i++)
            {
                pLayer = axMap.get_Layer(i);
                if (pLayer.Valid)
                {
                    if (pLayer.Name == strLayerName)
                    {
                        if (pLayer is IFeatureLayer)
                        {
                            pFeatLyr = pLayer as  IFeatureLayer;

                        }
                    }
                }
            }
            return pFeatLyr;
        }
 

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AxMapControl axMap = pMainFrm.getMapControl();
            if (chkShowTips.Checked == true)
            {
                axMap.ShowMapTips = true;
                ShowLayerTips();
            }
            else {
                axMap.ShowMapTips = false;
            }
            this.Dispose();
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}