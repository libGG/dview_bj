// GISTryDoc.cpp : CGISTryDoc ���ʵ��
//

#include "stdafx.h"
#include "GISTry.h"

#include "GISTryDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CGISTryDoc

IMPLEMENT_DYNCREATE(CGISTryDoc, CDocument)

BEGIN_MESSAGE_MAP(CGISTryDoc, CDocument)
END_MESSAGE_MAP()


// CGISTryDoc ����/����

CGISTryDoc::CGISTryDoc()
{
	// TODO: �ڴ����һ���Թ������

}

CGISTryDoc::~CGISTryDoc()
{
}

BOOL CGISTryDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: �ڴ�������³�ʼ������
	// (SDI �ĵ������ø��ĵ�)

	return TRUE;
}




// CGISTryDoc ���л�

void CGISTryDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: �ڴ���Ӵ洢����
	}
	else
	{
		// TODO: �ڴ���Ӽ��ش���
	}
}


// CGISTryDoc ���

#ifdef _DEBUG
void CGISTryDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CGISTryDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CGISTryDoc ����
