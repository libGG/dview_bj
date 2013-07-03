// MyGISTestDoc.cpp : CMyGISTestDoc 类的实现
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


// CMyGISTestDoc 构造/析构

CMyGISTestDoc::CMyGISTestDoc()
{
	// TODO: 在此添加一次性构造代码

}

CMyGISTestDoc::~CMyGISTestDoc()
{
}

BOOL CMyGISTestDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: 在此添加重新初始化代码
	// (SDI 文档将重用该文档)

	return TRUE;
}




// CMyGISTestDoc 序列化

void CMyGISTestDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: 在此添加存储代码
	}
	else
	{
		// TODO: 在此添加加载代码
	}
}


// CMyGISTestDoc 诊断

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


// CMyGISTestDoc 命令
