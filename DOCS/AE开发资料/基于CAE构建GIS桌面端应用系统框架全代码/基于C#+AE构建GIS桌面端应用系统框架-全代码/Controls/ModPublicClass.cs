using System;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.MapControl;
using ESRI.ArcGIS.Carto;
namespace Controls
{
	/// <summary>
	/// ModPublicClass ��ժҪ˵����
	/// </summary>
	public class ModPublicClass
	{
		private IMapDocument m_pDocument=null;
		private string m_MxdPath;
		private string m_MxdFileName;
	 
		public ModPublicClass(IMapDocument pDocument,string mxdFilePath,string mxdFileName)
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
            m_pDocument=new MapDocumentClass();
			m_MxdPath=mxdFilePath;
			m_MxdFileName=mxdFileName;
			//
		}
		//�ĵ�ģ������
		public IMapDocument pMapDocument
		{
			get
			{
				return m_pDocument;
			}
			set 
			{
				if(m_pDocument!=value)
				{
					m_pDocument=value;
				}
			}
		}
		//�ĵ�����·��
		public string MxdPath
		{
			get
			{
				return m_MxdPath;
			}
			set 
			{
				if(m_MxdPath!=value)
				{
					m_MxdPath=value;
				}
			}
		}

		//�ĵ����ļ�����
		public string MxdFileName
		{
			get
			{
				return m_MxdFileName;
			}
			set 
			{
				if(m_MxdFileName!=value)
				{
					m_MxdFileName=value;
				}
			}
		}
		
	}
}
