// GISTry.h : GISTry Ӧ�ó������ͷ�ļ�
//
#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"       // ������


// CGISTryApp:
// �йش����ʵ�֣������ GISTry.cpp
//

class CGISTryApp : public CWinApp
{
public:
	CGISTryApp();


// ��д
public:
	virtual BOOL InitInstance();

// ʵ��
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CGISTryApp theApp;