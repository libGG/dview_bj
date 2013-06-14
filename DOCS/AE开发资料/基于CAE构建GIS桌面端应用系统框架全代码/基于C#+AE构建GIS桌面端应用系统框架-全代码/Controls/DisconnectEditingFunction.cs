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
	/// DisconnectEditingTool 的摘要说明。
	/// </summary>
	public class DisconnectEditingFunctions
	{
		public DisconnectEditingFunctions()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
