// GISTryView.h : CGISTryView ��Ľӿ�
//


#pragma once


class CGISTryView : public CView
{
protected: // �������л�����
	CGISTryView();
	DECLARE_DYNCREATE(CGISTryView)

// ����
public:
	CGISTryDoc* GetDocument() const;

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
	virtual ~CGISTryView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	void loadbmp(CString filename);
	void CopyWndToClipBoard(CWnd *pWnd);

private:
	CBitmap* m_pBuffer;
	BITMAP m_bitmap;

// ���ɵ���Ϣӳ�亯��
protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg BOOL OnMouseWheel(UINT nFlags, short zDelta, CPoint pt);
public:
	afx_msg void OnFileOpen();
public:
	afx_msg void OnTestClipboard();
};

#ifndef _DEBUG  // GISTryView.cpp �еĵ��԰汾
inline CGISTryDoc* CGISTryView::GetDocument() const
   { return reinterpret_cast<CGISTryDoc*>(m_pDocument); }
#endif

