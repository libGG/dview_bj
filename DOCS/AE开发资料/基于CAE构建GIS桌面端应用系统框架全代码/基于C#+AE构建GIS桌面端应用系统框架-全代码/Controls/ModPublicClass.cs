using System;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.MapControl;
using ESRI.ArcGIS.Carto;
namespace Controls
{
	/// <summary>
	/// ModPublicClass 的摘要说明。
	/// </summary>
	public class ModPublicClass
	{
		private IMapDocument m_pDocument=null;
		private string m_MxdPath;
		private string m_MxdFileName;
	 
		public ModPublicClass(IMapDocument pDocument,string mxdFilePath,string mxdFileName)
		{
			//
			// TODO: 在此处添加构造函数逻辑
            m_pDocument=new MapDocumentClass();
			m_MxdPath=mxdFilePath;
			m_MxdFileName=mxdFileName;
			//
		}
		//文档模板属性
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
		//文档所在路径
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

		//文档的文件名称
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
