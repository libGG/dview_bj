// MyGISTest.h : MyGISTest Ӧ�ó������ͷ�ļ�
//
#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"       // ������


// CMyGISTestApp:
// �йش����ʵ�֣������ MyGISTest.cpp
//

class CMyGISTestApp : public CWinApp
{
public:
	CMyGISTestApp();


// ��д
public:
	virtual BOOL InitInstance();

// ʵ��
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CMyGISTestApp theApp;