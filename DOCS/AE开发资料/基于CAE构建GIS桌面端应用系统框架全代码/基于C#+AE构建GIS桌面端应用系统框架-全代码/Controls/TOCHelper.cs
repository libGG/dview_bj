using System;
using ESRI.ArcGIS.TOCControl;
using ESRI.ArcGIS.Carto;


namespace Controls
{
	/// <summary>
	/// TOCHelper 的摘要说明。
	/// </summary>
	public class TOCHelper:ITOCControlEvents
	{
		MainFrm pMainFrm=null;
		AxTOCControl pTOCCtl=null;

		public TOCHelper(MainFrm _pMainFrm,AxTOCControl _pTOCCtl)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			pMainFrm=_pMainFrm;
			pTOCCtl=_pTOCCtl;




		}
		#region ITOCControlEvents 成员

		public void OnMouseDown(int button, int shift, int x, int y)
		{
			// TODO:  添加 TOCHelper.OnMouseDown 实现

			IBasicMap map=null;
			ILayer layer=null;
            Object other=null;
			esriTOCControlItem pItem=0;
			pTOCCtl.HitTest(x,y,ref pItem,ref map,ref layer,ref other,ref other);
			if(pItem==esriTOCControlItem.esriTOCControlItemLayer){

				if(layer!=null)
				pMainFrm.setCurrentLayer(layer);
				

			
			}



		}

		public void OnMouseUp(int button, int shift, int x, int y)
		{
			// TODO:  添加 TOCHelper.OnMouseUp 实现
		}

		public void OnBeginLabelEdit(int x, int y, ref bool CanEdit)
		{
			// TODO:  添加 TOCHelper.OnBeginLabelEdit 实现
		}

		public void OnKeyDown(int keyCode, int shift)
		{
			// TODO:  添加 TOCHelper.OnKeyDown 实现
		}

		public void OnKeyUp(int keyCode, int shift)
		{
			// TODO:  添加 TOCHelper.OnKeyUp 实现
		}

		public void OnMouseMove(int button, int shift, int x, int y)
		{
			// TODO:  添加 TOCHelper.OnMouseMove 实现
		}

		public void OnEndLabelEdit(int x, int y, string newLabel, ref bool CanEdit)
		{
			// TODO:  添加 TOCHelper.OnEndLabelEdit 实现
		}

		public void OnDoubleClick(int button, int shift, int x, int y)
		{
			// TODO:  添加 TOCHelper.OnDoubleClick 实现
		}

		#endregion
	}
}
