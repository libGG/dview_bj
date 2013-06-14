using System;
using ESRI.ArcGIS.Geometry;

namespace Newleaf
{
	/// <summary>
	/// ExtentUpdatedEventArgs 的摘要说明。
	/// </summary>
	public class ExtentUpdatedEventArgs:EventArgs
	{
		private IEnvelope m_newEnvelope ;

		public ExtentUpdatedEventArgs(IEnvelope newEnvelope)
		{
			m_newEnvelope = newEnvelope;
		}

		public IEnvelope Envelope
		{
			get
			{
				return m_newEnvelope;
			}
			set
			{
				m_newEnvelope = value;
			}
		}
	}
}
