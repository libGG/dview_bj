// testGDIDlg.h : ͷ�ļ�
//

#pragma once


// CtestGDIDlg �Ի���
class CtestGDIDlg : public CDialog
{
// ����
public:
	CtestGDIDlg(CWnd* pParent = NULL);	// ��׼���캯��

// �Ի�������
	enum { IDD = IDD_TESTGDI_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV ֧��
private:
	CPoint pointori;
	CPoint m_pOrigin;
	CPoint m_pPrev;

// ʵ��
protected:
	HICON m_hIcon;

	// ���ɵ���Ϣӳ�亯��
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
