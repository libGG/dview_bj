// MyGISTestDoc.cpp : CMyGISTestDoc ���ʵ��
//

#include "stdafx.h"
#include "MyGISTest.h"

#include "MyGISTestDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMyGISTestDoc

IMPLEMENT_DYNCREATE(CMyGISTestDoc, CDocument)

BEGIN_MESSAGE_MAP(CMyGISTestDoc, CDocument)
END_MESSAGE_MAP()


// CMyGISTestDoc ����/����

CMyGISTestDoc::CMyGISTestDoc()
{
	// TODO: �ڴ����һ���Թ������

}

CMyGISTestDoc::~CMyGISTestDoc()
{
}

BOOL CMyGISTestDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: �ڴ�������³�ʼ������
	// (SDI �ĵ������ø��ĵ�)

	return TRUE;
}




// CMyGISTestDoc ���л�

void CMyGISTestDoc::Serialize(CArchive& ar)
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


// CMyGISTestDoc ���

#ifdef _DEBUG
void CMyGISTestDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CMyGISTestDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CMyGISTestDoc ����
