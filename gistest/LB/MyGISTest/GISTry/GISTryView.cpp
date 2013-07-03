// GISTryView.cpp : CGISTryView ���ʵ��
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
	// ��׼��ӡ����
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CGISTryView ����/����

CGISTryView::CGISTryView()
{
	// TODO: �ڴ˴���ӹ������

}

CGISTryView::~CGISTryView()
{
}

BOOL CGISTryView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: �ڴ˴�ͨ���޸�
	//  CREATESTRUCT cs ���޸Ĵ��������ʽ

	return CView::PreCreateWindow(cs);
}

// CGISTryView ����

void CGISTryView::OnDraw(CDC* /*pDC*/)
{
	CGISTryDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: �ڴ˴�Ϊ����������ӻ��ƴ���
}


// CGISTryView ��ӡ

BOOL CGISTryView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// Ĭ��׼��
	return DoPreparePrinting(pInfo);
}

void CGISTryView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: ��Ӷ���Ĵ�ӡǰ���еĳ�ʼ������
}

void CGISTryView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: ��Ӵ�ӡ����е��������
}


// CGISTryView ���

#ifdef _DEBUG
void CGISTryView::AssertValid() const
{
	CView::AssertValid();
}

void CGISTryView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CGISTryDoc* CGISTryView::GetDocument() const // �ǵ��԰汾��������
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CGISTryDoc)));
	return (CGISTryDoc*)m_pDocument;
}
#endif //_DEBUG


// CGISTryView ��Ϣ�������
