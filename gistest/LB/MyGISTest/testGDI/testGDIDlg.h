// testGDIDlg.h : 头文件
//

#pragma once


// CtestGDIDlg 对话框
class CtestGDIDlg : public CDialog
{
// 构造
public:
	CtestGDIDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_TESTGDI_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持
private:
	CPoint pointori;
	CPoint m_pOrigin;
	CPoint m_pPrev;

// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnLButtonDown(UINT nFlags, CPoint point);
public:
	afx_msg void OnLButtonUp(UINT nFlags, CPoint point);
public:
	afx_msg void OnBnClickedCancel();
public:
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
};
