using System;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.GeoDatabaseDistributed;
using System.Windows.Forms;




namespace Controls
{
	/// <summary>
	/// DisconnectEditingTool ��ժҪ˵����
	/// </summary>
	public class DisconnectEditingFunctions
	{
		public DisconnectEditingFunctions()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static  string GetUniqueName()
		{
			string sPrefix = "Check-Out";
			
			string sUnique = DateTime.UtcNow.Ticks.ToString();
			sUnique = sUnique.Substring(10);
			return sPrefix + sUnique;
		}


	}
}
