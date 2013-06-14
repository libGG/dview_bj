using System;

namespace Controls
{
	/// <summary>
	/// SpatialAnalysisOption 的摘要说明。
	/// </summary>
	public class SpatialAnalysisOption
	{
		//设置空间分析结果输出的临时路径
		private string m_AnalysisPath;
		//设置空间分析参考的数据模板
        private string m_AnalysisMask;
	   //设置分析范围
		private double m_AnalysisExtentTop;
        private double m_AnalysisExtentBottom;
		private double m_AnalysisExtentLeft;
		private double m_AnalysisExtentRight;
		//设置输出栅格分辨率大小
		private double m_RasterCellSize;

		public SpatialAnalysisOption(string sAnalysisPath)
		{
			//
			// TODO: 在此处添加构造函数逻辑		
	        m_AnalysisPath=sAnalysisPath;
			//
		}
		//临时路径属性
		public string AnalysisPath
		{
			get
			{
				return m_AnalysisPath;
			}
			set 
			{
				if(m_AnalysisPath!=value)
				{
					m_AnalysisPath=value;
				}
			}
		}
		//分析参考模板属性
		public string AnalysisMask
		{
			get
			{
				return m_AnalysisMask;
			}
			set
			{
				if(m_AnalysisMask!=value)
				{
					m_AnalysisMask=value;
				}
			}
		}
		//设置分析范围的上界
		public double AnalysisExtentTop
		{
			get
			{
				return m_AnalysisExtentTop;
			}
			set
			{
				if(m_AnalysisExtentTop!=value)
				{
					m_AnalysisExtentTop=value;
				}
			}
		}
		//设置分析范围的下界
		public double AnalysisExtentBottom
		{
			get
			{
				return m_AnalysisExtentBottom;
			}
			set
			{
				if(m_AnalysisExtentBottom!=value)
				{
					m_AnalysisExtentBottom=value;
				}
			}
		}
		//设置分析范围的左边界
		public double AnalysisExtentLeft
		{
			get
			{
				return m_AnalysisExtentLeft;
			}
			set
			{
				if(m_AnalysisExtentLeft!=value)
				{
					m_AnalysisExtentLeft=value;
				}
			}
		}
		//设置分析范围的右边界
		public double AnalysisExtentRight
		{
			get
			{
				return m_AnalysisExtentRight;
			}
			set
			{
				if(m_AnalysisExtentRight!=value)
				{
					m_AnalysisExtentRight=value;
				}
			}
		}
		//设置输出栅格的分辨率大小
		public double RasterCellSize
		{
			get
			{
				return m_RasterCellSize;
			}
			set
			{
				if(m_RasterCellSize!=value)
				{
					m_RasterCellSize=value;
				}
			}
		}

	}
}
