// MyGISTestView.h : CMyGISTestView ��Ľӿ�
//


#pragma once


class CMyGISTestView : public CView
{
protected: // �������л�����
	CMyGISTestView();
	DECLARE_DYNCREATE(CMyGISTestView)

// ����
public:
	CMyGISTestDoc* GetDocument() const;

// ����
public:

// ��д
public:
	virtual void OnDraw(CDC* pDC);  // ��д�Ի��Ƹ���ͼ
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// ʵ��
public:
	virtual ~CMyGISTestView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

private:
	CPoint pointori;
	CPoint pointOld;

// ���ɵ���Ϣӳ�亯��
protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
	afx_msg void OnLButtonDown(UINT nFlags, CPoint point);
	afx_msg void OnLButtonUp(UINT nFlags, CPoint point);
};

#ifndef _DEBUG  // MyGISTestView.cpp �еĵ��԰汾
inline CMyGISTestDoc* CMyGISTestView::GetDocument() const
   { return reinterpret_cast<CMyGISTestDoc*>(m_pDocument); }
#endif

