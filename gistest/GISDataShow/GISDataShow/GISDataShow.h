// GISDataShow.h : GISDataShow Ӧ�ó������ͷ�ļ�
//
#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"       // ������


// CGISDataShowApp:
// �йش����ʵ�֣������ GISDataShow.cpp
//

class CGISDataShowApp : public CWinApp
{
public:
	CGISDataShowApp();

private:
	 ULONG_PTR m_gdiplusToken;
// ��д
public:
	virtual BOOL InitInstance();
    virtual int ExitInstance();
// ʵ��
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CGISDataShowApp theApp;