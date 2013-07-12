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
	ON_WM_MOUSEWHEEL()
	ON_COMMAND(ID_FILE_OPEN, &CGISTryView::OnFileOpen)
	ON_COMMAND(ID_TEST_ClipBoard, &CGISTryView::OnTestClipboard)
END_MESSAGE_MAP()

// CGISTryView ����/����

CGISTryView::CGISTryView()
{
	// TODO: �ڴ˴���ӹ������
	this->m_pBuffer =0;
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

void CGISTryView::OnDraw(CDC* pDC)
{
	CGISTryDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: �ڴ˴�Ϊ����������ӻ��ƴ���

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

BOOL CGISTryView::OnMouseWheel(UINT nFlags, short zDelta, CPoint pt)
{
	// TODO: �ڴ������Ϣ�����������/�����Ĭ��ֵ
	TRACE("zDelta: %d\n", zDelta);
	


	return CView::OnMouseWheel(nFlags, zDelta, pt);
}

void CGISTryView::OnFileOpen()
{
	char szFilter[]="λͼ(*.bmp)|*.bmp||";
	CFileDialog dlg(true,"shp","",OFN_HIDEREADONLY|OFN_OVERWRITEPROMPT,szFilter,NULL);
	dlg.m_ofn.lpstrTitle="װ��";
    if(dlg.DoModal()==IDCANCEL) return;
	loadbmp(dlg.GetPathName());
	Invalidate(true);
}
void CGISTryView::loadbmp(CString filename)
{
	HBITMAP hbitmap=0;
	hbitmap=(HBITMAP)::LoadImage(NULL,filename,IMAGE_BITMAP,0,0,LR_LOADFROMFILE);
	//m_pBuffer = CBitmap::FromHandle(hbitmap);//���ַ���������
	m_pBuffer = new CBitmap();
	bool isok = m_pBuffer->Attach(hbitmap);
	m_pBuffer->GetBitmap(&m_bitmap);//Ҳ����m_pBuffer->GetObject(sizeof(bitmap),&bitmap);	
	//::DeleteObject(hbitmap);//�������ɾ�ˣ�m_pBuufer����Ҳû�����ˣ����Ҳ������ʾ��
}
void CGISTryView::OnTestClipboard()
{
	this->CopyWndToClipBoard(this);	
}
void CGISTryView::CopyWndToClipBoard(CWnd *pWnd)//CWnd *pWnd����Ҫ��ͼ�Ĵ��ڡ�
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
