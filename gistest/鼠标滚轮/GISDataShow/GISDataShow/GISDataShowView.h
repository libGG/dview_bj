// GISDataShowView.h : CGISDataShowView 类的接口
//
#include "include\MapControl.h"

#pragma once


class CGISDataShowView : public CMapControl
{
protected: // 仅从序列化创建
	CGISDataShowView();
	DECLARE_DYNCREATE(CGISDataShowView)

// 属性
public:
	CGISDataShowDoc* GetDocument() const;

// 操作
public:

// 重写
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// 实现
public:
	virtual ~CGISDataShowView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// 生成的消息映射函数
protected:
	afx_msg void OnFileOpen();
	afx_msg void OnFileOpen1();
	afx_msg void OnZoomIn();
	afx_msg void OnUpdateZoomIn(CCmdUI* pCmdUI);
    afx_msg void OnZoomOut();
	afx_msg void OnUpdateZoomOut(CCmdUI* pCmdUI);
    afx_msg void OnPan();
	afx_msg void OnUpdatePan(CCmdUI* pCmdUI);
	afx_msg void OnGloble();
public:
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnOpenvec();
public:
	afx_msg void OnMytestClip();
};

#ifndef _DEBUG  // GISDataShowView.cpp 中的调试版本
inline CGISDataShowDoc* CGISDataShowView::GetDocument() const
   { return reinterpret_cast<CGISDataShowDoc*>(m_pDocument); }
#endif

