// GISDataShowDoc.cpp : CGISDataShowDoc 类的实现
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


// CGISDataShowDoc 构造/析构

CGISDataShowDoc::CGISDataShowDoc()
{
	// TODO: 在此添加一次性构造代码

}

CGISDataShowDoc::~CGISDataShowDoc()
{
}

BOOL CGISDataShowDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: 在此添加重新初始化代码
	// (SDI 文档将重用该文档)

	return TRUE;
}




// CGISDataShowDoc 序列化

void CGISDataShowDoc::Serialize(CArchive& ar)
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


// CGISDataShowDoc 诊断

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


// CGISDataShowDoc 命令
