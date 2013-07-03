// GISDataShowView.cpp : CGISDataShowView ���ʵ��
//

#include "stdafx.h"
#include "GISDataShow.h"

#include "GISDataShowDoc.h"
#include "GISDataShowView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CGISDataShowView

IMPLEMENT_DYNCREATE(CGISDataShowView, CView)

BEGIN_MESSAGE_MAP(CGISDataShowView, CMapControl)
	// ��׼��ӡ����
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
END_MESSAGE_MAP()

// CGISDataShowView ����/����

CGISDataShowView::CGISDataShowView()
{
	// TODO: �ڴ˴���ӹ������

}

CGISDataShowView::~CGISDataShowView()
{
}

BOOL CGISDataShowView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: �ڴ˴�ͨ���޸�
	//  CREATESTRUCT cs ���޸Ĵ��������ʽ

	return CView::PreCreateWindow(cs);
}

// CGISDataShowView ����

// CGISDataShowView ��ӡ

BOOL CGISDataShowView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// Ĭ��׼��
	return DoPreparePrinting(pInfo);
}

void CGISDataShowView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: ��Ӷ���Ĵ�ӡǰ���еĳ�ʼ������
}

void CGISDataShowView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: ��Ӵ�ӡ����е��������
}


// CGISDataShowView ���

#ifdef _DEBUG
void CGISDataShowView::AssertValid() const
{
	CView::AssertValid();
}

void CGISDataShowView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CGISDataShowDoc* CGISDataShowView::GetDocument() const // �ǵ��԰汾��������
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CGISDataShowDoc)));
	return (CGISDataShowDoc*)m_pDocument;
}
#endif //_DEBUG


// CGISDataShowView ��Ϣ�������
void CGISDataShowView::OnFileOpen()
{
	char szFilter[]="ͼ��(*.*)|*.*||";
	CFileDialog dlg(true,"","",OFN_HIDEREADONLY|OFN_OVERWRITEPROMPT,szFilter,NULL);
	dlg.m_ofn.lpstrTitle="װ��";
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
	char szFilter[]="ͼ��(*.*)|*.*||";
	CFileDialog dlg(true,"","",OFN_HIDEREADONLY|OFN_OVERWRITEPROMPT,szFilter,NULL);
	dlg.m_ofn.lpstrTitle="װ��";
    if(dlg.DoModal()==IDCANCEL) return;
	int band[3];
	band[0]=1;
	band[1]=2;
	band[2]=3;
	if(AddRGBRasterLayer(dlg.GetPathName(),band)) Invalidate(true);
}

void CGISDataShowView::OnOpenvec()
{
	char szFilter[]="Shapefile�ļ�(*.shp)|*.shp||";
	CFileDialog dlg(true,"shp","",OFN_HIDEREADONLY|OFN_OVERWRITEPROMPT,szFilter,NULL);
	dlg.m_ofn.lpstrTitle="װ��";
    if(dlg.DoModal()==IDCANCEL) return;
	if(AddVectorLayer(dlg.GetPathName())) Invalidate(true);
}
