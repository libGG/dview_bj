using System;
using ESRI.ArcGIS.Geodatabase;

namespace Controls
{
	/// <summary>
	/// SelectedFeature 的摘要说明。
	/// </summary>
	public class SelectedFeature
	{
		private IFeature m_pFeature=null;
		private string m_sLayerName;
		public SelectedFeature()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public IFeature pFeature
		{
			get
			{
				return m_pFeature;
			}
			set 
			{
				if(m_pFeature!=value)
				{
					m_pFeature=value;
				}
			}
		}
		public string sLayerName
		{
			get
			{
				return m_sLayerName;
			}
			set 
			{
				if(m_sLayerName!=value)
				{
					m_sLayerName=value;
				}
			}
		}
	}
}
