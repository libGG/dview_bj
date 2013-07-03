// testGDIDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "testGDI.h"
#include "testGDIDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// 用于应用程序“关于”菜单项的 CAboutDlg 对话框

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// 对话框数据
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 实现
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CtestGDIDlg 对话框




CtestGDIDlg::CtestGDIDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CtestGDIDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CtestGDIDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CtestGDIDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_WM_LBUTTONDOWN()
	ON_WM_LBUTTONUP()
	ON_BN_CLICKED(IDCANCEL, &CtestGDIDlg::OnBnClickedCancel)
	ON_WM_MOUSEMOVE()
END_MESSAGE_MAP()


// CtestGDIDlg 消息处理程序

BOOL CtestGDIDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// 将“关于...”菜单项添加到系统菜单中。

	// IDM_ABOUTBOX 必须在系统命令范围内。
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	SetIcon(m_hIcon, FALSE);		// 设置小图标

	// TODO: 在此添加额外的初始化代码

	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

void CtestGDIDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void CtestGDIDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作矩形中居中
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标显示。
//
HCURSOR CtestGDIDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CtestGDIDlg::OnLButtonDown(UINT nFlags, CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	this->pointori = point;
	m_pOrigin = point;
	CDialog::OnLButtonDown(nFlags, point);
}

void CtestGDIDlg::OnLButtonUp(UINT nFlags, CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	/*CDC *pDC=GetDC();
	CBrush *pOldBrush=(CBrush*)pDC->SelectStockObject(NULL_BRUSH);
	pDC->Rectangle(pointori.x,pointori.y, point.x,point.y);
	pDC->SelectObject(pOldBrush);
	CDialog::OnLButtonUp(nFlags, point);*/
}

void CtestGDIDlg::OnBnClickedCancel()
{
	// TODO: 在此添加控件通知处理程序代码
	OnCancel();
}

void CtestGDIDlg::OnMouseMove(UINT nFlags, CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值

	// 按下左键移动开始画图
	if (nFlags == MK_LBUTTON)
	{
		// 创建画笔RGB(0x00, 0x00, 0xFF)
		HPEN hPen = ::CreatePen(PS_SOLID, 3, RGB(0x00, 0x00, 0xFF));
		HDC m_hMemDC = GetDC()->m_hDC;
		// 使用画笔
		::SelectObject(m_hMemDC, hPen);
		//设置系统色彩模式取反色
		int oldRop=::SetROP2(m_hMemDC,R2_NOTXORPEN); 
		// 画线
		::MoveToEx(m_hMemDC,m_pOrigin.x,m_pOrigin.y, NULL);
		::LineTo(m_hMemDC, m_pPrev.x,m_pPrev.y);
		//恢复系统默认色彩模式
		::SetROP2(m_hMemDC,oldRop);
		::MoveToEx(m_hMemDC, m_pOrigin.x, m_pOrigin.y, NULL);
		::LineTo(m_hMemDC, point.x, point.y);
		m_pPrev = point;
		Invalidate(FALSE);

	}
	CDialog::OnMouseMove(nFlags, point);
}
