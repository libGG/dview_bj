// GISTryView.cpp : CGISTryView 类的实现
//

#include "stdafx.h"
#include "GISTry.h"

#include "GISTryDoc.h"
#include "GISTryView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CGISTryView

IMPLEMENT_DYNCREATE(CGISTryView, CView)

BEGIN_MESSAGE_MAP(CGISTryView, CView)
	// 标准打印命令
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_MOUSEWHEEL()
	ON_COMMAND(ID_FILE_OPEN, &CGISTryView::OnFileOpen)
	ON_COMMAND(ID_TEST_ClipBoard, &CGISTryView::OnTestClipboard)
END_MESSAGE_MAP()

// CGISTryView 构造/析构

CGISTryView::CGISTryView()
{
	// TODO: 在此处添加构造代码
	this->m_pBuffer =0;
}

CGISTryView::~CGISTryView()
{
}

BOOL CGISTryView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: 在此处通过修改
	//  CREATESTRUCT cs 来修改窗口类或样式

	return CView::PreCreateWindow(cs);
}

// CGISTryView 绘制

void CGISTryView::OnDraw(CDC* pDC)
{
	CGISTryDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: 在此处为本机数据添加绘制代码

	if(NULL == m_pBuffer)return;
	CRect clientRect;
	this->GetClientRect(&clientRect);
	CDC memDC;
	memDC.CreateCompatibleDC(pDC);
	CBitmap* oldbitmap= memDC.SelectObject(m_pBuffer);
	pDC->BitBlt(0,0,m_bitmap.bmWidth,m_bitmap.bmHeight,&memDC,0,0,SRCCOPY);
	memDC.SelectObject(oldbitmap);
	//ReleaseDC(&memDC);
	memDC.DeleteDC();
}


// CGISTryView 打印

BOOL CGISTryView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 默认准备
	return DoPreparePrinting(pInfo);
}

void CGISTryView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加额外的打印前进行的初始化过程
}

void CGISTryView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加打印后进行的清除过程
}


// CGISTryView 诊断

#ifdef _DEBUG
void CGISTryView::AssertValid() const
{
	CView::AssertValid();
}

void CGISTryView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CGISTryDoc* CGISTryView::GetDocument() const // 非调试版本是内联的
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CGISTryDoc)));
	return (CGISTryDoc*)m_pDocument;
}
#endif //_DEBUG


// CGISTryView 消息处理程序

BOOL CGISTryView::OnMouseWheel(UINT nFlags, short zDelta, CPoint pt)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	TRACE("zDelta: %d\n", zDelta);
	


	return CView::OnMouseWheel(nFlags, zDelta, pt);
}

void CGISTryView::OnFileOpen()
{
	char szFilter[]="位图(*.bmp)|*.bmp||";
	CFileDialog dlg(true,"shp","",OFN_HIDEREADONLY|OFN_OVERWRITEPROMPT,szFilter,NULL);
	dlg.m_ofn.lpstrTitle="装载";
    if(dlg.DoModal()==IDCANCEL) return;
	loadbmp(dlg.GetPathName());
	Invalidate(true);
}
void CGISTryView::loadbmp(CString filename)
{
	HBITMAP hbitmap=0;
	hbitmap=(HBITMAP)::LoadImage(NULL,filename,IMAGE_BITMAP,0,0,LR_LOADFROMFILE);
	//m_pBuffer = CBitmap::FromHandle(hbitmap);//两种方法都可以
	m_pBuffer = new CBitmap();
	bool isok = m_pBuffer->Attach(hbitmap);
	m_pBuffer->GetBitmap(&m_bitmap);//也可以m_pBuffer->GetObject(sizeof(bitmap),&bitmap);	
	//::DeleteObject(hbitmap);//这里如果删了，m_pBuufer里面也没数据了，后边也不能显示了
}
void CGISTryView::OnTestClipboard()
{
	this->CopyWndToClipBoard(this);	
}
void CGISTryView::CopyWndToClipBoard(CWnd *pWnd)//CWnd *pWnd是你要截图的窗口。
{
	CBitmap bitmap;
	CClientDC dc(pWnd);
	CDC memdc;
	CRect rect;

	memdc.CreateCompatibleDC(&dc);
	//pWnd->GetWindowRect(&rect);
	pWnd->GetClientRect(&rect);
	bitmap.CreateCompatibleBitmap(&dc,rect.Width(),rect.Height());
	//rect.NormalizeRect();
	CBitmap* pOldBitmap = memdc.SelectObject(&bitmap);
	memdc.BitBlt(0,0,rect.Width(),rect.Height(),&dc,0,0,SRCCOPY);

	pWnd->OpenClipboard();
	EmptyClipboard();
	SetClipboardData(CF_BITMAP,bitmap.GetSafeHandle());
	CloseClipboard();

	memdc.SelectObject(pOldBitmap);
	bitmap.Detach();
}
