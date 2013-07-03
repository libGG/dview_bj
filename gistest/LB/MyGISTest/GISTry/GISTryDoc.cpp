// GISTryDoc.cpp : CGISTryDoc 类的实现
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


// CGISTryDoc 构造/析构

CGISTryDoc::CGISTryDoc()
{
	// TODO: 在此添加一次性构造代码

}

CGISTryDoc::~CGISTryDoc()
{
}

BOOL CGISTryDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: 在此添加重新初始化代码
	// (SDI 文档将重用该文档)

	return TRUE;
}




// CGISTryDoc 序列化

void CGISTryDoc::Serialize(CArchive& ar)
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


// CGISTryDoc 诊断

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


// CGISTryDoc 命令
