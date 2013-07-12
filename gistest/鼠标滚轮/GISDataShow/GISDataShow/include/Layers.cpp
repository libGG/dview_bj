#include "StdAfx.h"
#include "Layers.h"
#include "Layers.h"
#include "LayerPainter.h"
#include "mapcontrol.h"
void CLayers::AddLayer(CLayer*ly)
{
	 layers.Add(ly);
	 DRect ex=ly->GetFullExtent();
	 if(layers.GetSize()==1)
	 {
		 FullExtent=ex;
		 CRect rt;
		 pMap->GetClientRect(rt);
		 pMap->GetMapPosition()->InitialMap(rt,ex);
		 if(pSpatialReference==NULL) pSpatialReference=ly->GetSpatialReference();
	 }
	 else
	 {
		 if(ly->IsVectorLayer())
		 {
			 CSpatialRefTrans psp;
			 ex=psp.TransformRect(ly->GetSpatialReference(),GetSpatialReference(),ex);
		 }
		 FullExtent=FullExtent+ex;
	 }
}
void CLayers::DrawLayers(HDC m_hDC,CMapPosition*mp)
{
	int Count=layers.GetSize();
	for(int k=0;k<Count;k++)
	{
		CLayer*pLayer=layers.GetAt(k);
		CLayerPainterManager pManager(pLayer);
		pManager.Draw(m_hDC,mp);
	}
}