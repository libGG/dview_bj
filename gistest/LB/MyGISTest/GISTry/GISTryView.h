// GISTryView.h : CGISTryView 类的接口
//


#pragma once


class CGISTryView : public CView
{
protected: // 仅从序列化创建
	CGISTryView();
	DECLARE_DYNCREATE(CGISTryView)

// 属性
public:
	CGISTryDoc* GetDocument() const;

// 操作
public:

// 重写
public:
	virtual void OnDraw(CDC* pDC);  // 重写以绘制该视图
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// 实现
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

// 生成的消息映射函数
protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg BOOL OnMouseWheel(UINT nFlags, short zDelta, CPoint pt);
public:
	afx_msg void OnFileOpen();
public:
	afx_msg void OnTestClipboard();
};

#ifndef _DEBUG  // GISTryView.cpp 中的调试版本
inline CGISTryDoc* CGISTryView::GetDocument() const
   { return reinterpret_cast<CGISTryDoc*>(m_pDocument); }
#endif

