#pragma once
#include "layer.h"
#include "bitmapshow.h"
enum PainterType
{
	UnknownPainter=-1,
    GrayPainter=0,
	RGBPainter=1,
	PointPainter=2,
	PolylinePainter=3,
	PolygonPainter=4
};
class CLayerPainter
{
public:
    CLayerPainter(CLayer*pLayer)
	{
		pRefLayer=pLayer;
		type=UnknownPainter;
	};
	virtual~CLayerPainter()
	{
		
	};
	PainterType GetPainterType()
	{
		return type;
	};
    virtual bool Draw(HDC hDC,CMapPosition*mp)=0;
protected:
    CLayer*pRefLayer;
	PainterType type;
}; 
class CRasterLayerPainter :public CLayerPainter
{
public:
	CRasterLayerPainter(CLayer*pLayer) :CLayerPainter(pLayer)
	{
		
	};
	virtual~CRasterLayerPainter()
	{
	};
	bool ComputePaintRect(CMapPosition*mp,CRect&PaintClient,DRect&PaintExtent,CRect&PixelRect);
};
class CGrayRasterLayerPainter :public CRasterLayerPainter
{
public:
    CGrayRasterLayerPainter(CLayer*pLayer) :CRasterLayerPainter(pLayer)
	{
		type=GrayPainter;
		pShow=new CGrayBitmapShow;
	};
	virtual~CGrayRasterLayerPainter()
	{
		delete pShow;
	};
    bool Draw(HDC hDC,CMapPosition*mp);
protected:
	 CGrayBitmapShow*pShow;
};
class CRGBRasterLayerPainter :public CRasterLayerPainter
{
public:
    CRGBRasterLayerPainter(CLayer*pLayer) :CRasterLayerPainter(pLayer)
	{
		type=RGBPainter;
		pShow=new CRGBBitmapShow;
	};;
	virtual~CRGBRasterLayerPainter()
	{
		delete pShow;
	};
    bool Draw(HDC hDC,CMapPosition*mp);
protected:
	 CRGBBitmapShow*pShow;
};
class CVectorLayerPainter :public CLayerPainter
{
public:
	CVectorLayerPainter(CLayer*pLayer) :CLayerPainter(pLayer)
	{

	};
	virtual~CVectorLayerPainter()
	{
	};
};
class CPointLayerPainter :public CVectorLayerPainter
{
public:
	CPointLayerPainter(CLayer*pLayer) :CVectorLayerPainter(pLayer)
	{
        Size=5;
		TextColor=RGB(0,0,0);
		type=PointPainter;
	};
	virtual~CPointLayerPainter()
	{

	};
	void SetDrawEnvi(COLORREF Color,int Size);
	bool Draw(HDC hDC,CMapPosition*mp);
protected:
    COLORREF TextColor;
	int Size;
};
class CPolylineLayerPainter :public CVectorLayerPainter
{
public:
	CPolylineLayerPainter(CLayer*pLayer) :CVectorLayerPainter(pLayer)
	{
        Size=1;
		LineColor=RGB(0,255,0);
		type=PolylinePainter;
	};
	virtual~CPolylineLayerPainter()
	{

	};
	void SetDrawEnvi(COLORREF Color,int Size);
	bool Draw(HDC hDC,CMapPosition*mp);
protected:
    COLORREF LineColor;
	void DrawLineString(OGRLineString*ls,CDC*pDC,CMapPosition*mp,OGRCoordinateTransformation*poCT);
    void DrawMultiLineString(OGRMultiLineString*mls,CDC*pDC,CMapPosition*mp,OGRCoordinateTransformation*poCT);
	int Size;
};
class CPolygonLayerPainter :public CVectorLayerPainter
{
public:
	CPolygonLayerPainter(CLayer*pLayer) :CVectorLayerPainter(pLayer)
	{
		PolyColor=RGB(255,0,0);
		type=PolygonPainter;
	};
	virtual~CPolygonLayerPainter()
	{

	};
	void SetDrawEnvi(COLORREF Color);
	bool Draw(HDC hDC,CMapPosition*mp);
protected:
	void DrawPoly(OGRPolygon*poly,CDC*pDC,CMapPosition*mp,OGRCoordinateTransformation*poCT);
    COLORREF PolyColor;
};
class CLayerPainterManager
{
public:
	CLayerPainterManager(CLayer*pLayer)
	{
		pPainter=NULL;
		CreateNewPainter(pLayer);
	};
	virtual~CLayerPainterManager()
	{
		if(pPainter!=NULL) delete pPainter;
	};
	bool Draw(HDC hDC,CMapPosition*mp);
protected:
    void CreateNewPainter(CLayer*pLayer);
protected:
	CLayerPainter*pPainter;
};
