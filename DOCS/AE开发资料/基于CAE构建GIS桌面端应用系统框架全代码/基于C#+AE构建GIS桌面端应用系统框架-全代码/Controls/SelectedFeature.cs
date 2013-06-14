using System;
using ESRI.ArcGIS.Geodatabase;

namespace Controls
{
	/// <summary>
	/// SelectedFeature ��ժҪ˵����
	/// </summary>
	public class SelectedFeature
	{
		private IFeature m_pFeature=null;
		private string m_sLayerName;
		public SelectedFeature()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
