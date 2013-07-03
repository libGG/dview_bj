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
END_MESSAGE_MAP()

// CGISTryView 构造/析构

CGISTryView::CGISTryView()
{
	// TODO: 在此处添加构造代码

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

void CGISTryView::OnDraw(CDC* /*pDC*/)
{
	CGISTryDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: 在此处为本机数据添加绘制代码
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
