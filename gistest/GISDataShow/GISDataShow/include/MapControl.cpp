// include\MapControl.cpp : 实现文件
//

#include "stdafx.h"
#include "MapControl.h"
#include "..\resource.h"

// CMapControl

IMPLEMENT_DYNCREATE(CMapControl, CView)

CMapControl::CMapControl()
{
    pLayers=new CLayers(this);
	CReaderEnvi::InitialEnvi();
	IsLeftButtonDown=false;
	m_Tool=0;
	bBitmap=false;
	bitmapDifX=bitmapDifY=0;
}

CMapControl::~CMapControl()
{
	delete pLayers;
	if(bBitmap) m_bitmap.DeleteObject();  
}

BEGIN_MESSAGE_MAP(CMapControl, CView)
	ON_WM_SIZE()
	ON_WM_LBUTTONDOWN()
	ON_WM_LBUTTONUP()
	ON_WM_MOUSEMOVE()
END_MESSAGE_MAP()


// CMapControl 绘图
void  CMapControl::PrepareDraw(CDC*pDC)
{ 
    if(bBitmap) m_bitmap.DeleteObject();
	CRect memRect;
	GetClientRect(memRect);
	m_bitmap.CreateCompatibleBitmap(pDC,memRect.Width(), memRect.Height());
    bBitmap=true;
	CDC memDC;
	memDC.CreateCompatibleDC(pDC);
    CBitmap*oldbitmap=memDC.SelectObject(&m_bitmap);
	memDC.PatBlt(-1,-1,memRect.Width()+1,memRect.Height()+1,WHITENESS);
    pLayers->DrawLayers(memDC.m_hDC,&mp);
	memDC.SelectObject(oldbitmap);
 	memDC.DeleteDC();
}
void CMapControl::OnDraw(CDC* pDC)
{
	CDocument* pDoc = GetDocument();
	CRect memRect;
	GetClientRect(memRect);
	CDC tempDC;
	tempDC.CreateCompatibleDC(pDC);
    tempDC.PatBlt(-1,-1,memRect.Width()+1,memRect.Height()+1,WHITENESS);
    CBitmap*oldbitmap=tempDC.SelectObject(&m_bitmap);
    CDC memDC;
	memDC.CreateCompatibleDC(pDC);
	CBitmap membitmap;
	membitmap.CreateCompatibleBitmap(pDC,memRect.Width(),memRect.Height()); 
	CBitmap*pOldBitmap=memDC.SelectObject(&membitmap); 
	memDC.PatBlt(-1,-1,memRect.Width()+1,memRect.Height()+1,WHITENESS);
	BitBlt(memDC.m_hDC,bitmapDifX, bitmapDifY,memRect.Width(),memRect.Height(),tempDC.m_hDC,0,0,SRCCOPY);
    BitBlt(pDC->m_hDC,memRect.left, memRect.top,memRect.Width(),memRect.Height(),memDC.m_hDC,0,0,SRCCOPY);
	tempDC.SelectObject(oldbitmap);
 	tempDC.DeleteDC();
    memDC.SelectObject(pOldBitmap);
    memDC.DeleteDC();
    membitmap.DeleteObject();
	membitmap.Detach();
}

// CMapControl 诊断

#ifdef _DEBUG
void CMapControl::AssertValid() const
{
	CView::AssertValid();
}

#ifndef _WIN32_WCE
void CMapControl::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}
#endif
#endif //_DEBUG


// CMapControl 消息处理程序
CLayer*CMapControl::AddGrayRasterLayer(CString lpszPathName,int band)
{
     CGrayRasterLayer*ly=new CGrayRasterLayer(pLayers);
	 if(!ly->SetPathName(lpszPathName))
	 {
		 delete ly;
		 return NULL;
	 }
	 ly->SetBand(band);
	 pLayers->AddLayer(ly);
	 return ly;
}
CLayer*CMapControl::AddRGBRasterLayer(CString lpszPathName,int*band)
{
     CRGBRasterLayer*ly=new CRGBRasterLayer(pLayers);
	 if(!ly->SetPathName(lpszPathName))
	 {
		 delete ly;
		 return NULL;
	 }
	 ly->SetBand(band);
	 pLayers->AddLayer(ly);
	 return ly;
}
CLayer*CMapControl::AddVectorLayer(CString lpszPathName)
{
     CVectorLayer*ly=new CVectorLayer(pLayers);
	 if(!ly->SetPathName(lpszPathName))
	 {
		 delete ly;
		 return NULL;
	 }
	 pLayers->AddLayer(ly);
	 return ly;
}
void CMapControl::OnSize(UINT nType, int cx, int cy)
{
	CView::OnSize(nType, cx, cy);
    mp.SizeMap(CRect(0,0,cx,cy));
	Invalidate(true);
}
void CMapControl::ZoomIn(CRect rect)
{
	rect.NormalizeRect();
	if((rect.Width()<2)&&(rect.Height()<2)) 
	{
		ZoomInAtPoint(CPoint((rect.left+rect.right)/2,(rect.top+rect.bottom)/2));
		return;
	}
	DRect ir;
	DBPoint lt=mp.ClientToMap(DBPoint(rect.left,rect.top));
    DBPoint rb=mp.ClientToMap(DBPoint(rect.right,rect.bottom));
	ir.Left=lt.X;ir.Top=lt.Y;
	ir.Right=rb.X;ir.Bottom=rb.Y;
	CRect CurrentClientRect;
	GetClientRect(CurrentClientRect);
	mp.InitialMap(CurrentClientRect,ir);
	Invalidate(true);
}
void CMapControl::ZoomOut(CRect rect)
{
	rect.NormalizeRect();
	CPoint pt(CPoint((rect.left+rect.right)/2,(rect.top+rect.bottom)/2));
	if((rect.Width()<2)&&(rect.Height()<2)) 
	{
		ZoomOutAtPoint(pt);
		return;
	}
	CRect CurrentClientRect;
	GetClientRect(CurrentClientRect);
	double ratiox=(float)rect.Width()/CurrentClientRect.Width();
	double ratioy=fabs((float)rect.Height()/CurrentClientRect.Height());
	double Ratio=max(ratiox,ratioy);
    if(Ratio<0.001)
	{
		ZoomOutAtPoint(pt);
		return;
	}
    Ratio=1/Ratio/2+0.5;
    DRect CurrentMapExtent=mp.GetExtentRect();
	double Width=CurrentMapExtent.Width();
	double Height=CurrentMapExtent.Height();
	DBPoint CenterPt=mp.ClientToMap(DBPoint(pt.x,pt.y));
	CurrentMapExtent.Left=CenterPt.X-Width*Ratio;
	CurrentMapExtent.Right=CenterPt.X+Width*Ratio;
	CurrentMapExtent.Top=CenterPt.Y-Height*Ratio;
	CurrentMapExtent.Bottom=CenterPt.Y+Height*Ratio;
	mp.InitialMap(CurrentClientRect,CurrentMapExtent);
    Invalidate(true);
}
void CMapControl::ZoomInAtPoint(CPoint pt)
{
	DBPoint CenterPt=mp.ClientToMap(DBPoint(pt.x,pt.y));
    DRect CurrentMapExtent=mp.GetExtentRect();
	double Ratio=0.4;
	double Width=CurrentMapExtent.Width();
	double Height=CurrentMapExtent.Height();
	CurrentMapExtent.Left=CenterPt.X-Width*Ratio;
	CurrentMapExtent.Right=CenterPt.X+Width*Ratio;
	CurrentMapExtent.Top=CenterPt.Y-Height*Ratio;
	CurrentMapExtent.Bottom=CenterPt.Y+Height*Ratio;
    CRect CurrentClientRect;
	GetClientRect(CurrentClientRect);
	mp.InitialMap(CurrentClientRect,CurrentMapExtent);
    Invalidate(true);
}
void CMapControl::ZoomOutAtPoint(CPoint pt)
{
	DBPoint CenterPt=mp.ClientToMap(DBPoint(pt.x,pt.y));
	double Ratio=0.625;
	DRect CurrentMapExtent=mp.GetExtentRect();
	double Width=CurrentMapExtent.Width();
	double Height=CurrentMapExtent.Height();
	CurrentMapExtent.Left=CenterPt.X-Width*Ratio;
	CurrentMapExtent.Right=CenterPt.X+Width*Ratio;
	CurrentMapExtent.Top=CenterPt.Y-Height*Ratio;
	CurrentMapExtent.Bottom=CenterPt.Y+Height*Ratio;
    CRect CurrentClientRect;
	GetClientRect(CurrentClientRect);
	mp.InitialMap(CurrentClientRect,CurrentMapExtent);
    Invalidate(true);
}

void CMapControl::Pan(CRect rect)
{
	double DifX,DifY;
	DRect ir;
	DBPoint lt=mp.ClientToMap(DBPoint(rect.left,rect.top));
    DBPoint rb=mp.ClientToMap(DBPoint(rect.right,rect.bottom));
	DifX=rb.X-lt.X;
	DifY=rb.Y-lt.Y;
    DRect CurrentMapExtent=mp.GetExtentRect();
	CurrentMapExtent.Left-=DifX;
	CurrentMapExtent.Right-=DifX;
	CurrentMapExtent.Top-=DifY;
	CurrentMapExtent.Bottom-=DifY;
    CRect CurrentClientRect;
	GetClientRect(CurrentClientRect);
	mp.InitialMap(CurrentClientRect,CurrentMapExtent);
    Invalidate(true);
}
void CMapControl::PanTo(DBPoint dpt)
{
    DRect CurrentMapExtent=mp.GetExtentRect();
	DBPoint CenterMap((CurrentMapExtent.Left+CurrentMapExtent.Right)/2,(CurrentMapExtent.Top+CurrentMapExtent.Bottom)/2);
	double DifX=dpt.X-CenterMap.X;
    double DifY=dpt.Y-(CenterMap.Y);
    CurrentMapExtent.Left+=DifX;
	CurrentMapExtent.Right+=DifX;
	CurrentMapExtent.Top+=DifY;
	CurrentMapExtent.Bottom+=DifY;
    CRect CurrentClientRect;
	GetClientRect(CurrentClientRect);
	mp.InitialMap(CurrentClientRect,CurrentMapExtent);
    Invalidate(true);
}
void CMapControl::Globle()
{
	CRect CurrentClientRect;
	GetClientRect(CurrentClientRect);
	mp.InitialMap(CurrentClientRect,pLayers->GetFullExtent());
    Invalidate(true);
}
void CMapControl::SetCurTool(int Tool)
{
     m_Tool=Tool;
}
UINT CMapControl::GetCurTool()
{
	return m_Tool;
}
void CMapControl::OnLButtonDown(UINT nFlags, CPoint point)
{
	m_lpointori=point;
	IsLeftButtonDown=true;
	SetCapture();
	CView::OnLButtonDown(nFlags, point);
}

void CMapControl::OnLButtonUp(UINT nFlags, CPoint point)
{
	bool NeedDrawRect=false;
	if((IsLeftButtonDown)&&((m_Tool==1)||(m_Tool==2))) NeedDrawRect=true;
	if(NeedDrawRect)
	{
		CDC*pDC=GetDC();
		pDC->SetROP2(R2_NOT);
		pDC->SelectObject(m_pendotted);
		pDC->SetBkColor(TRANSPARENT);
		pDC->SelectStockObject(NULL_BRUSH);
		pDC->Rectangle(m_lpointori.x,m_lpointori.y,m_lpointold.x,m_lpointold.y);
		ReleaseDC(pDC);
		if(m_Tool==1)
		{
			CRect rect;
			rect.left=m_lpointori.x;
			rect.top=m_lpointori.y;
			rect.right=m_lpointold.x;
			rect.bottom=m_lpointold.y;
			ZoomIn(rect);
		}
		else if(m_Tool==2)
		{
            CRect rect;
			rect.left=m_lpointori.x;
			rect.top=m_lpointori.y;
			rect.right=m_lpointold.x;
			rect.bottom=m_lpointold.y;
			ZoomOut(rect);
		}
		IsLeftButtonDown=false;
	}
	if(m_Tool==3)
	{
		CRect rect;
		rect.left=m_lpointori.x;
		rect.top=m_lpointori.y;
		rect.right=m_lpointold.x;
		rect.bottom=m_lpointold.y;
		Pan(rect);
		IsLeftButtonDown=false;
	}
	ReleaseCapture();
	CView::OnLButtonUp(nFlags, point);
}

void CMapControl::OnMouseMove(UINT nFlags, CPoint point)
{
	bool NeedDrawRect=false;
	CRect CurrentClientRect;
	GetClientRect(CurrentClientRect);
	if(CurrentClientRect.PtInRect(point))
	{
		if(m_Tool==1)
			::SetCursor(AfxGetApp()->LoadCursor(IDC_ZOOMIN));
		else if(m_Tool==2)
			::SetCursor(AfxGetApp()->LoadCursor(IDC_ZOOMOUT));
        else if(m_Tool==3)
			::SetCursor(AfxGetApp()->LoadCursor(IDC_PAN));
		else
			::SetCursor(AfxGetApp()->LoadStandardCursor(IDC_ARROW));
	}
	if((IsLeftButtonDown)&&((m_Tool==1)||(m_Tool==2))) NeedDrawRect=true;
	if(NeedDrawRect)
	{
		CDC*pDC=GetDC();
		pDC->SetROP2(R2_NOT);//R2_NOT
		pDC->SelectObject(m_pendotted);
		pDC->SetBkColor(TRANSPARENT);
		pDC->SelectStockObject(NULL_BRUSH);
		pDC->Rectangle(m_lpointori.x,m_lpointori.y,m_lpointold.x,m_lpointold.y);
        pDC->Rectangle(m_lpointori.x,m_lpointori.y,point.x,point.y);
		ReleaseDC(pDC);
	}
	if((m_Tool==3)&&(IsLeftButtonDown))
	{
        CRect rect;
		rect.left=m_lpointold.x;
		rect.top=m_lpointold.y;
		rect.right=point.x;
		rect.bottom=point.y;
		bitmapDifX=point.x-m_lpointori.x;
        bitmapDifY=point.y-m_lpointori.y;
		CView::Invalidate(true);
	}
	m_lpointold=point;
	CView::OnMouseMove(nFlags, point);
}