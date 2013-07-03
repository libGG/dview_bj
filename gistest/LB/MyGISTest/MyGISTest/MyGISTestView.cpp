// MyGISTestView.cpp : CMyGISTestView 类的实现
//

#include "stdafx.h"
#include "MyGISTest.h"

#include "MyGISTestDoc.h"
#include "MyGISTestView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMyGISTestView

IMPLEMENT_DYNCREATE(CMyGISTestView, CView)

BEGIN_MESSAGE_MAP(CMyGISTestView, CView)
	// 标准打印命令
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_MOUSEMOVE()
	ON_WM_LBUTTONDOWN()
	ON_WM_LBUTTONUP()
END_MESSAGE_MAP()

// CMyGISTestView 构造/析构

CMyGISTestView::CMyGISTestView()
{
	// TODO: 在此处添加构造代码

}

CMyGISTestView::~CMyGISTestView()
{
}

BOOL CMyGISTestView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: 在此处通过修改
	//  CREATESTRUCT cs 来修改窗口类或样式

	return CView::PreCreateWindow(cs);
}

// CMyGISTestView 绘制

void CMyGISTestView::OnDraw(CDC* /*pDC*/)
{
	CMyGISTestDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: 在此处为本机数据添加绘制代码
}


// CMyGISTestView 打印

BOOL CMyGISTestView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 默认准备
	return DoPreparePrinting(pInfo);
}

void CMyGISTestView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加额外的打印前进行的初始化过程
}

void CMyGISTestView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加打印后进行的清除过程
}


// CMyGISTestView 诊断

#ifdef _DEBUG
void CMyGISTestView::AssertValid() const
{
	CView::AssertValid();
}

void CMyGISTestView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CMyGISTestDoc* CMyGISTestView::GetDocument() const // 非调试版本是内联的
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMyGISTestDoc)));
	return (CMyGISTestDoc*)m_pDocument;
}
#endif //_DEBUG


// CMyGISTestView 消息处理程序

void CMyGISTestView::OnMouseMove(UINT nFlags, CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值

	int a=nFlags & 1;
	if((nFlags & MK_LBUTTON) == MK_LBUTTON)//if(nFlags & MK_LBUTTON)	
	{
		//CDC *pDC=this->GetDC();
		//pDC->SetBkColor(TRANSPARENT);
		//CPen pen1;
		////pen1.CreatePen( 0, 1, RGB(255,255,255));
		//pen1.CreatePen(PS_SOLID,1,RGB(255,255,255));
		//CPen *oldPen=pDC->SelectObject(&pen1);
		//CBrush brush;
		//brush.CreateStockObject(NULL_BRUSH);//NULL_BRUSH
		//CBrush *oldBrush;
		//oldBrush = pDC->SelectObject(&brush);
		//pDC->Rectangle(pointori.x,pointori.y, pointOld.x, pointOld.y);
		//pDC->SelectObject(oldPen);
		//pen1.DeleteObject();
		//pDC->Rectangle(pointori.x,pointori.y,point.x,point.y);
		//pointOld = point;
		//pDC->SelectObject(oldBrush);
		//brush.DeleteObject();
		//ReleaseDC(pDC);

		CDC *pDC=this->GetDC();
		pDC->SetROP2(R2_NOT);
		CBrush brush;
		brush.CreateStockObject(NULL_BRUSH);//NULL_BRUSH
		CBrush *oldBrush;
		oldBrush = pDC->SelectObject(&brush);
		pDC->Rectangle(pointori.x,pointori.y, pointOld.x, pointOld.y);
		//pDC->SelectObject(oldPen);
		//pen1.DeleteObject();
		pDC->Rectangle(pointori.x,pointori.y,point.x,point.y);
		pointOld = point;
		pDC->SelectObject(oldBrush);
		brush.DeleteObject();
		ReleaseDC(pDC);
	}
	CView::OnMouseMove(nFlags, point);
}

void CMyGISTestView::OnLButtonDown(UINT nFlags, CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	pointori = point;
	pointOld = point;
	CView::OnLButtonDown(nFlags, point);
}

void CMyGISTestView::OnLButtonUp(UINT nFlags, CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	CDC *pDC=this->GetDC();
	CPen pen1;
	pen1.CreatePen( 0, 1, RGB(255,255,255));
	CPen *oldPen=pDC->SelectObject(&pen1);
	CBrush *pBrush=CBrush::FromHandle((HBRUSH)GetStockObject(NULL_BRUSH));
	CBrush *oldBrush = pDC->SelectObject(pBrush);
	pDC->Rectangle(pointori.x,pointori.y, pointOld.x, pointOld.y);
	pDC->SelectObject(oldPen);
	pen1.DeleteObject();
	ReleaseDC(pDC);

	//CDC *pDC=this->GetDC();
	//pDC->SetROP2(R2_NOT);
	//CBrush *pBrush=CBrush::FromHandle((HBRUSH)GetStockObject(NULL_BRUSH));
	//CBrush *oldBrush = pDC->SelectObject(pBrush);
	//pDC->Rectangle(pointori.x,pointori.y, pointOld.x, pointOld.y);
	//ReleaseDC(pDC);


	CView::OnLButtonUp(nFlags, point);
}
