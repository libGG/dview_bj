// GISMap.h : main header file for the GISMAP application
//

#if !defined(AFX_GISMAP_H__8F8F24E6_9CDE_4DAB_B4A0_7B9B09141290__INCLUDED_)
#define AFX_GISMAP_H__8F8F24E6_9CDE_4DAB_B4A0_7B9B09141290__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CGISMapApp:
// See GISMap.cpp for the implementation of this class
//

class CGISMapApp : public CWinApp
{
public:
	CGISMapApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CGISMapApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation
	//{{AFX_MSG(CGISMapApp)
	afx_msg void OnAppAbout();
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_GISMAP_H__8F8F24E6_9CDE_4DAB_B4A0_7B9B09141290__INCLUDED_)
