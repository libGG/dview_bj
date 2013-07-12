// GISDataShowView.h : CGISDataShowView ��Ľӿ�
//
#include "include\MapControl.h"

#pragma once


class CGISDataShowView : public CMapControl
{
protected: // �������л�����
	CGISDataShowView();
	DECLARE_DYNCREATE(CGISDataShowView)

// ����
public:
	CGISDataShowDoc* GetDocument() const;

// ����
public:

// ��д
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// ʵ��
public:
	virtual ~CGISDataShowView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// ���ɵ���Ϣӳ�亯��
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

#ifndef _DEBUG  // GISDataShowView.cpp �еĵ��԰汾
inline CGISDataShowDoc* CGISDataShowView::GetDocument() const
   { return reinterpret_cast<CGISDataShowDoc*>(m_pDocument); }
#endif

