// GISMapView.h : interface of the CGISMapView class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_GISMAPVIEW_H__DBCAD20E_2917_415B_9C6A_58A0216B2B5B__INCLUDED_)
#define AFX_GISMAPVIEW_H__DBCAD20E_2917_415B_9C6A_58A0216B2B5B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class MapControl ;

class CGISMapView : public CView
{
protected: // create from serialization only
	CGISMapView();
	DECLARE_DYNCREATE(CGISMapView)

// Attributes
public:
	CGISMapDoc* GetDocument();

private:
	MapControl *m_pMapControl;
// Operations
public:
	MapControl& GetMapControl();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CGISMapView)
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual void OnInitialUpdate();
	protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CGISMapView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CGISMapView)
	afx_msg void OnLButtonDown(UINT nFlags, CPoint point);
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
	afx_msg void OnLButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnPan();
	afx_msg void OnZoomin();
	afx_msg void OnZoomout();
	afx_msg void OnReset();
	afx_msg void OnFileOpen();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in GISMapView.cpp
inline CGISMapDoc* CGISMapView::GetDocument()
   { return (CGISMapDoc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_GISMAPVIEW_H__DBCAD20E_2917_415B_9C6A_58A0216B2B5B__INCLUDED_)
