#pragma once
#include "layer.h"
#include "baseclass.h"
class CMapControl;
class CLayers
{
public:
	CLayers(CMapControl*map)
	{
		pMap=map;
		pSpatialReference=NULL;
	};
	virtual ~CLayers(void)
	{
		for(int k=layers.GetSize()-1;k>=0;k--) delete layers.GetAt(k);
		layers.RemoveAll();
	};
	int GetCount()
	{
		return layers.GetSize();
	};
	void RemoveAll()
	{
        for(int k=layers.GetSize()-1;k>=0;k--) delete layers.GetAt(k);
		layers.RemoveAll();
	};
	CLayer*Item(int index)
	{
		return layers.GetAt(index);
	};
	void AddLayer(CLayer*ly);
	DRect GetFullExtent()
	{
		return FullExtent;
	};
	OGRSpatialReference*GetSpatialReference()
	{
		return pSpatialReference;
	};
	void DrawLayers(HDC m_hDC,CMapPosition*mp);
protected:
	CArray<CLayer*,CLayer*>layers;
	DRect FullExtent;
	CMapControl*pMap;
	OGRSpatialReference*pSpatialReference;
};
