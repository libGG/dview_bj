// GISDataShowDoc.cpp : CGISDataShowDoc ���ʵ��
//

#include "stdafx.h"
#include "GISDataShow.h"

#include "GISDataShowDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CGISDataShowDoc

IMPLEMENT_DYNCREATE(CGISDataShowDoc, CDocument)

BEGIN_MESSAGE_MAP(CGISDataShowDoc, CDocument)
END_MESSAGE_MAP()


// CGISDataShowDoc ����/����

CGISDataShowDoc::CGISDataShowDoc()
{
	// TODO: �ڴ����һ���Թ������

}

CGISDataShowDoc::~CGISDataShowDoc()
{
}

BOOL CGISDataShowDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: �ڴ�������³�ʼ������
	// (SDI �ĵ������ø��ĵ�)

	return TRUE;
}




// CGISDataShowDoc ���л�

void CGISDataShowDoc::Serialize(CArchive& ar)
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


// CGISDataShowDoc ���

#ifdef _DEBUG
void CGISDataShowDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CGISDataShowDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CGISDataShowDoc ����
