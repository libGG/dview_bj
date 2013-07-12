// GISDataShowView.cpp : CGISDataShowView 类的实现
//

#include "stdafx.h"
#include "GISDataShow.h"

#include "GISDataShowDoc.h"
#include "GISDataShowView.h"
#include "atlimage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CGISDataShowView

IMPLEMENT_DYNCREATE(CGISDataShowView, CView)

BEGIN_MESSAGE_MAP(CGISDataShowView, CMapControl)
	// 标准打印命令
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_COMMAND(ID_FILE_OPEN, &CGISDataShowView::OnFileOpen)
	ON_COMMAND(ID_ZOOM_IN, &CGISDataShowView::OnZoomIn)
	ON_UPDATE_COMMAND_UI(ID_ZOOM_IN, &CGISDataShowView::OnUpdateZoomIn)
	ON_COMMAND(ID_ZOOM_OUT, &CGISDataShowView::OnZoomOut)
	ON_UPDATE_COMMAND_UI(ID_ZOOM_OUT, &CGISDataShowView::OnUpdateZoomOut)
	ON_COMMAND(ID_PAN, &CGISDataShowView::OnPan)
	ON_UPDATE_COMMAND_UI(ID_PAN, &CGISDataShowView::OnUpdatePan)
    ON_COMMAND(ID_GLOBLE, &CGISDataShowView::OnGloble)
	ON_WM_ERASEBKGND()
	ON_COMMAND(ID_FILE_OPEN1, &CGISDataShowView::OnFileOpen1)
	ON_COMMAND(ID_OPENVEC, &CGISDataShowView::OnOpenvec)
	ON_COMMAND(ID_MYTEST_Clip, &CGISDataShowView::OnMytestClip)
END_MESSAGE_MAP()

// CGISDataShowView 构造/析构

CGISDataShowView::CGISDataShowView()
{
	// TODO: 在此处添加构造代码

}

CGISDataShowView::~CGISDataShowView()
{
}

BOOL CGISDataShowView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: 在此处通过修改
	//  CREATESTRUCT cs 来修改窗口类或样式

	return CView::PreCreateWindow(cs);
}

// CGISDataShowView 绘制

// CGISDataShowView 打印

BOOL CGISDataShowView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 默认准备
	return DoPreparePrinting(pInfo);
}

void CGISDataShowView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加额外的打印前进行的初始化过程
}

void CGISDataShowView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加打印后进行的清除过程
}


// CGISDataShowView 诊断

#ifdef _DEBUG
void CGISDataShowView::AssertValid() const
{
	CView::AssertValid();
}

void CGISDataShowView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CGISDataShowDoc* CGISDataShowView::GetDocument() const // 非调试版本是内联的
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CGISDataShowDoc)));
	return (CGISDataShowDoc*)m_pDocument;
}
#endif //_DEBUG


// CGISDataShowView 消息处理程序
void CGISDataShowView::OnFileOpen()
{
	char szFilter[]="图像(*.*)|*.*||";
	CFileDialog dlg(true,"","",OFN_HIDEREADONLY|OFN_OVERWRITEPROMPT,szFilter,NULL);
	dlg.m_ofn.lpstrTitle="装载";
    if(dlg.DoModal()==IDCANCEL) return;
	if(AddGrayRasterLayer(dlg.GetPathName(),1)) Invalidate(true);
}
void CGISDataShowView::OnZoomIn()
{
    SetCurTool(1);
}
void CGISDataShowView::OnUpdateZoomIn(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(GetCurTool()==1);
}
void CGISDataShowView::OnZoomOut()
{
    SetCurTool(2);
}
void CGISDataShowView::OnUpdateZoomOut(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(GetCurTool()==2);
}
void CGISDataShowView::OnPan()
{
    SetCurTool(3);
}
void CGISDataShowView::OnUpdatePan(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(GetCurTool()==3);
}
void CGISDataShowView::OnGloble()
{
    Globle();
}
BOOL CGISDataShowView::OnEraseBkgnd(CDC* pDC)
{
	return true;
	return CMapControl::OnEraseBkgnd(pDC);
}

void CGISDataShowView::OnFileOpen1()
{
	char szFilter[]="图像(*.*)|*.*||";
	CFileDialog dlg(true,"","",OFN_HIDEREADONLY|OFN_OVERWRITEPROMPT,szFilter,NULL);
	dlg.m_ofn.lpstrTitle="装载";
    if(dlg.DoModal()==IDCANCEL) return;
	int band[3];
	band[0]=1;
	band[1]=2;
	band[2]=3;
	if(AddRGBRasterLayer(dlg.GetPathName(),band)) Invalidate(true);
}

void CGISDataShowView::OnOpenvec()
{
	char szFilter[]="Shapefile文件(*.shp)|*.shp||";
	CFileDialog dlg(true,"shp","",OFN_HIDEREADONLY|OFN_OVERWRITEPROMPT,szFilter,NULL);
	dlg.m_ofn.lpstrTitle="装载";
    if(dlg.DoModal()==IDCANCEL) return;
	if(AddVectorLayer(dlg.GetPathName())) Invalidate(true);
}

void CGISDataShowView::OnMytestClip()
{
	HDC hdcSrc = GetDC()->m_hAttribDC;
	int nBitPerPixel = GetDeviceCaps(hdcSrc, BITSPIXEL);
	int nWidth = GetDeviceCaps(hdcSrc, HORZRES);
	int nHeight = GetDeviceCaps(hdcSrc, VERTRES);
	CImage image;
	image.Create(nWidth, nHeight, nBitPerPixel);
	BitBlt(image.GetDC(), 0, 0, nWidth, nHeight, hdcSrc, 0, 0, SRCCOPY);
	//ReleaseDC(hdcSrc);
	::ReleaseDC(this->m_hWnd,hdcSrc);
	image.ReleaseDC();
	//image.Save(L"1.png", Gdiplus::ImageFormatPNG);//ImageFormatJPEG
	image.Save("c:\\1.bmp");
}
