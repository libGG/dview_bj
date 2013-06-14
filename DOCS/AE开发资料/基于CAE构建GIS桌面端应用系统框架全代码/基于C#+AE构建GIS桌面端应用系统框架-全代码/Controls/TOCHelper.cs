using System;
using ESRI.ArcGIS.TOCControl;
using ESRI.ArcGIS.Carto;


namespace Controls
{
	/// <summary>
	/// TOCHelper ��ժҪ˵����
	/// </summary>
	public class TOCHelper:ITOCControlEvents
	{
		MainFrm pMainFrm=null;
		AxTOCControl pTOCCtl=null;

		public TOCHelper(MainFrm _pMainFrm,AxTOCControl _pTOCCtl)
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			pMainFrm=_pMainFrm;
			pTOCCtl=_pTOCCtl;




		}
		#region ITOCControlEvents ��Ա

		public void OnMouseDown(int button, int shift, int x, int y)
		{
			// TODO:  ��� TOCHelper.OnMouseDown ʵ��

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
			// TODO:  ��� TOCHelper.OnMouseUp ʵ��
		}

		public void OnBeginLabelEdit(int x, int y, ref bool CanEdit)
		{
			// TODO:  ��� TOCHelper.OnBeginLabelEdit ʵ��
		}

		public void OnKeyDown(int keyCode, int shift)
		{
			// TODO:  ��� TOCHelper.OnKeyDown ʵ��
		}

		public void OnKeyUp(int keyCode, int shift)
		{
			// TODO:  ��� TOCHelper.OnKeyUp ʵ��
		}

		public void OnMouseMove(int button, int shift, int x, int y)
		{
			// TODO:  ��� TOCHelper.OnMouseMove ʵ��
		}

		public void OnEndLabelEdit(int x, int y, string newLabel, ref bool CanEdit)
		{
			// TODO:  ��� TOCHelper.OnEndLabelEdit ʵ��
		}

		public void OnDoubleClick(int button, int shift, int x, int y)
		{
			// TODO:  ��� TOCHelper.OnDoubleClick ʵ��
		}

		#endregion
	}
}
