using System;

namespace Controls
{
	/// <summary>
	/// SpatialAnalysisOption ��ժҪ˵����
	/// </summary>
	public class SpatialAnalysisOption
	{
		//���ÿռ��������������ʱ·��
		private string m_AnalysisPath;
		//���ÿռ�����ο�������ģ��
        private string m_AnalysisMask;
	   //���÷�����Χ
		private double m_AnalysisExtentTop;
        private double m_AnalysisExtentBottom;
		private double m_AnalysisExtentLeft;
		private double m_AnalysisExtentRight;
		//�������դ��ֱ��ʴ�С
		private double m_RasterCellSize;

		public SpatialAnalysisOption(string sAnalysisPath)
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�		
	        m_AnalysisPath=sAnalysisPath;
			//
		}
		//��ʱ·������
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
		//�����ο�ģ������
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
		//���÷�����Χ���Ͻ�
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
		//���÷�����Χ���½�
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
		//���÷�����Χ����߽�
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
		//���÷�����Χ���ұ߽�
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
		//�������դ��ķֱ��ʴ�С
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
