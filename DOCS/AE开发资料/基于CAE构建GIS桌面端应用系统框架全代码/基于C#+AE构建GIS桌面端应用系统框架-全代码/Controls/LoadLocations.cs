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

using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;


// This command allows users to load locations from another point feature layer into the selected NALayer and active category.

namespace NAEngine
{
	[Guid("72BDDCB7-03E8-4777-BECA-11DC47EFEDBA")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("NAEngine.LoadLocations")]
	public sealed class LoadLocations : BaseCommand  
	{
		private IMapControl3 m_mapControl;
		private IEngineNetworkAnalystEnvironment m_naEnv;

		public LoadLocations()
		{
			base.m_caption = "Load locations from layer...";
		}

		public override bool Enabled
		{
			get
			{
				// Enabled if the active category is an input point NAClass

				IEngineNAWindowCategory naWindowCategory = m_naEnv.NAWindow.ActiveCategory;
				if (naWindowCategory == null)
					return false;

				INAClass naClass = naWindowCategory.NAClass;
				if (naClass == null)
					return false;

				IFeatureClass fClass = (IFeatureClass)naClass;
				if (fClass.ShapeType != esriGeometryType.esriGeometryPoint)
					return false;

				INAClassDefinition naClassDefinition = naClass.ClassDefinition;
				if (naClassDefinition == null)
					return false;

				return naClassDefinition.IsInput;
			}
		}

		public override void OnClick()
		{
			// Get the NALayer and corresponding NAContext of the layer that
			// was right-clicked on in the table of contents
			// m_MapControl.CustomProperty was set in frmMain.axTOCControl1_OnMouseDown
			INALayer naLayer =  (INALayer) m_mapControl.CustomProperty;

			// Set the Active Analysis layer to be the layer right-clicked on
			m_naEnv.NAWindow.ActiveAnalysis = naLayer;

			if (!Enabled)
				return;

			// Show the Property Page form for Network Analyst
			frmLoadLocations loadLocations = new frmLoadLocations();
			if (loadLocations.ShowModal(m_mapControl, m_naEnv))
			{
				// If loaded locations, refresh the NAWindow and the Screen
				m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, m_mapControl.Extent);
				m_naEnv.NAWindow.UpdateContent(m_naEnv.NAWindow.ActiveCategory);
			}
		}

		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3) hook;
      
			// Get the Network Analyst Env
			m_naEnv = new EngineNetworkAnalystEnvironmentClass();
		}
	}
}
