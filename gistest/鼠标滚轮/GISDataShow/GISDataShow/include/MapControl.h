#pragma once
#include "layer.h"
#include "layers.h"

// CMapControl 视图

class CMapControl : public CView
{
	DECLARE_DYNCREATE(CMapControl)

protected:
	CMapControl();           // 动态创建所使用的受保护的构造函数
	virtual ~CMapControl();
public:
	CLayer*AddGrayRasterLayer(CString lpszPathName,int band);
    CLayer*AddRGBRasterLayer(CString lpszPathName,int*band);
	CLayer*AddVectorLayer(CString lpszPathName);
	CLayers*GetLayers()
	{
		return pLayers;
	};
	void ZoomIn(CRect rect);
    void ZoomOut(CRect rect);
	void Pan(CRect rect);
	void PanTo(DBPoint dpt);
	void ZoomInAtPoint(CPoint pt); 
	void ZoomOutAtPoint(CPoint pt);
	void Globle();
	void SetCurTool(int Tool);
	UINT GetCurTool();
    void Invalidate(bool Erase=1)
	{
		if(bBitmap) m_bitmap.DeleteObject();  
		bBitmap=false;
		bitmapDifX=0;
        bitmapDifY=0;
		CDC*pDC=GetDC();
		PrepareDraw(pDC);
		CView::Invalidate(Erase);
		ReleaseDC(pDC);
	};
	
	CMapPosition*GetMapPosition()
	{
		return &mp;
	};
protected:
	void PrepareDraw(CDC*pDC);
protected:
	CLayers*pLayers;
	CMapPosition mp;
	CArray<CLayer*,CLayer*>layers;
	UINT m_Tool;
	CPen m_pendotted;
	bool IsLeftButtonDown;
	bool IsRightButtonDown;
	CPoint m_lpointori;
    CPoint m_lpointold;
    CPoint m_rpointori;
    CPoint m_rPointold;
	CBitmap m_bitmap;
	bool bBitmap;
	int bitmapDifX;
	int bitmapDifY;
public:
	virtual void OnDraw(CDC* pDC);      // 重写以绘制该视图
#ifdef _DEBUG
	virtual void AssertValid() const;
#ifndef _WIN32_WCE
	virtual void Dump(CDumpContext& dc) const;
#endif
#endif
protected:
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnLButtonDown(UINT nFlags, CPoint point);
	afx_msg void OnLButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
	DECLARE_MESSAGE_MAP()
};


