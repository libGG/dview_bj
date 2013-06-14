// Copyright 2006 ESRI
//
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
//
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
//
// See use restrictions at /arcgis/developerkit/userestrictions.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.NetworkAnalyst;


// This form allows users to load locations from another point feature layer into the selected NALayer and active category.

namespace NAEngine
{
	/// <summary>
	/// Summary description for frmLoadLocations.
	/// </summary>
	public class frmLoadLocations : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblPointLayer;
		private System.Windows.Forms.CheckBox chkUseSelectedFeatures;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox cboPointLayers;

		bool m_okClicked;
		System.Collections.IList m_lstLayers;

		public frmLoadLocations()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.cboPointLayers = new System.Windows.Forms.ComboBox();
            this.lblPointLayer = new System.Windows.Forms.Label();
            this.chkUseSelectedFeatures = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboPointLayers
            // 
            this.cboPointLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPointLayers.Location = new System.Drawing.Point(106, 17);
            this.cboPointLayers.Name = "cboPointLayers";
            this.cboPointLayers.Size = new System.Drawing.Size(422, 20);
            this.cboPointLayers.TabIndex = 0;
            this.cboPointLayers.SelectedIndexChanged += new System.EventHandler(this.cboPointLayers_SelectedIndexChanged);
            // 
            // lblPointLayer
            // 
            this.lblPointLayer.Location = new System.Drawing.Point(19, 26);
            this.lblPointLayer.Name = "lblPointLayer";
            this.lblPointLayer.Size = new System.Drawing.Size(77, 26);
            this.lblPointLayer.TabIndex = 1;
            this.lblPointLayer.Text = "Point Layer";
            // 
            // chkUseSelectedFeatures
            // 
            this.chkUseSelectedFeatures.Location = new System.Drawing.Point(106, 60);
            this.chkUseSelectedFeatures.Name = "chkUseSelectedFeatures";
            this.chkUseSelectedFeatures.Size = new System.Drawing.Size(412, 18);
            this.chkUseSelectedFeatures.TabIndex = 2;
            this.chkUseSelectedFeatures.Text = "Use Selected Features";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(394, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 34);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(240, 112);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(134, 34);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmLoadLocations
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(652, 148);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkUseSelectedFeatures);
            this.Controls.Add(this.lblPointLayer);
            this.Controls.Add(this.cboPointLayers);
            this.Name = "frmLoadLocations";
            this.Text = "Load Locations";
            this.ResumeLayout(false);

		}
		#endregion

		public bool ShowModal(IMapControl3 mapControl, IEngineNetworkAnalystEnvironment naEnv)
		{
			// Initialize variables
			m_okClicked = false;
			m_lstLayers = new System.Collections.ArrayList();
			this.Text = "Load Locations into " + naEnv.NAWindow.ActiveCategory.Layer.Name;

			// Loop through all the layers, adding the point feature layers to the combo box and array
			IEnumLayer layers = mapControl.Map.get_Layers(null, true);
			ILayer layer;
			layer = layers.Next();
			while (layer != null)
			{
				IFeatureLayer fLayer = layer as IFeatureLayer;
				IDisplayTable displayTable = layer as IDisplayTable;

				if ((fLayer != null) && (displayTable != null))
				{
					IFeatureClass fClass = fLayer.FeatureClass;
					if (fClass.ShapeType == esriGeometryType.esriGeometryPoint)
					{
						// Add the layer name to the combobox and the layer to the list
						cboPointLayers.Items.Add(layer.Name);
						m_lstLayers.Add(layer);
					}
				}
				layer = layers.Next();
			}
			//Select the first point feature layer from the list
			if (cboPointLayers.Items.Count > 0)
				cboPointLayers.SelectedIndex = 0;

			// Show the window
			this.ShowDialog();

			// If we selected a layer and clicked OK, load the locations
			if (m_okClicked && (cboPointLayers.SelectedIndex >= 0))
			{
				// Get the NALayer and NAContext
				INALayer naLayer = naEnv.NAWindow.ActiveAnalysis;
				INAContext naContext = naLayer.Context;

				//Get the active category
				IEngineNAWindowCategory activeCategory = naEnv.NAWindow.ActiveCategory;
				INAClass naClass = activeCategory.NAClass;
				IDataset naDataset = naClass as IDataset;

				// Get a cursor to the input features (either though the selection set or table)
				// Use IDisplayTable because it accounts for joins, querydefs, etc.
				IDisplayTable displayTable = m_lstLayers[cboPointLayers.SelectedIndex] as IDisplayTable;
				ICursor cursor;
				if (chkUseSelectedFeatures.Checked)  
				{
					ISelectionSet selSet;
					selSet = displayTable.DisplaySelectionSet;
					selSet.Search(null, false, out cursor);
				}
				else
				{
					cursor = displayTable.SearchDisplayTable(null, false);
				}

				// Setup NAClassLoader and Load Locations
				INAClassLoader2 naClassLoader = new NAClassLoader() as INAClassLoader2;
				naClassLoader.Initialize(naContext, naDataset.Name, cursor);
				int rowsIn = 0;
				int rowsLocated = 0;
				naClassLoader.Load(cursor, null, ref rowsIn, ref rowsLocated);

				return true;
			}
			else
			{
				return false;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			m_okClicked = true;
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_okClicked = false;
			this.Close();
		}

		private void cboPointLayers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Set the chkUseSelecteFeatures control based on if anything is selected or not
			if (cboPointLayers.SelectedIndex >= 0)
			{
				IDisplayTable displayTable = m_lstLayers[cboPointLayers.SelectedIndex] as IDisplayTable;
				chkUseSelectedFeatures.Checked = (displayTable.DisplaySelectionSet.Count > 0);
				chkUseSelectedFeatures.Enabled = (displayTable.DisplaySelectionSet.Count > 0);
			}
		}
	}
}
