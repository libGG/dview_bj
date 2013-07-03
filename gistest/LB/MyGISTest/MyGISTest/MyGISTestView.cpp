// MyGISTestView.cpp : CMyGISTestView ���ʵ��
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
	// ��׼��ӡ����
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_MOUSEMOVE()
	ON_WM_LBUTTONDOWN()
	ON_WM_LBUTTONUP()
END_MESSAGE_MAP()

// CMyGISTestView ����/����

CMyGISTestView::CMyGISTestView()
{
	// TODO: �ڴ˴���ӹ������

}

CMyGISTestView::~CMyGISTestView()
{
}

BOOL CMyGISTestView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: �ڴ˴�ͨ���޸�
	//  CREATESTRUCT cs ���޸Ĵ��������ʽ

	return CView::PreCreateWindow(cs);
}

// CMyGISTestView ����

void CMyGISTestView::OnDraw(CDC* /*pDC*/)
{
	CMyGISTestDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: �ڴ˴�Ϊ����������ӻ��ƴ���
}


// CMyGISTestView ��ӡ

BOOL CMyGISTestView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// Ĭ��׼��
	return DoPreparePrinting(pInfo);
}

void CMyGISTestView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: ��Ӷ���Ĵ�ӡǰ���еĳ�ʼ������
}

void CMyGISTestView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: ��Ӵ�ӡ����е��������
}


// CMyGISTestView ���

#ifdef _DEBUG
void CMyGISTestView::AssertValid() const
{
	CView::AssertValid();
}

void CMyGISTestView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CMyGISTestDoc* CMyGISTestView::GetDocument() const // �ǵ��԰汾��������
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMyGISTestDoc)));
	return (CMyGISTestDoc*)m_pDocument;
}
#endif //_DEBUG


// CMyGISTestView ��Ϣ�������

void CMyGISTestView::OnMouseMove(UINT nFlags, CPoint point)
{
	// TODO: �ڴ������Ϣ�����������/�����Ĭ��ֵ

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
	// TODO: �ڴ������Ϣ�����������/�����Ĭ��ֵ
	pointori = point;
	pointOld = point;
	CView::OnLButtonDown(nFlags, point);
}

void CMyGISTestView::OnLButtonUp(UINT nFlags, CPoint point)
{
	// TODO: �ڴ������Ϣ�����������/�����Ĭ��ֵ
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
