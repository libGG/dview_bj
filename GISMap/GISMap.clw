; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CGISMapView
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "GISMap.h"
LastPage=0

ClassCount=5
Class1=CGISMapApp
Class2=CGISMapDoc
Class3=CGISMapView
Class4=CMainFrame

ResourceCount=2
Resource1=IDR_MAINFRAME
Class5=CAboutDlg
Resource2=IDD_ABOUTBOX

[CLS:CGISMapApp]
Type=0
HeaderFile=GISMap.h
ImplementationFile=GISMap.cpp
Filter=N

[CLS:CGISMapDoc]
Type=0
HeaderFile=GISMapDoc.h
ImplementationFile=GISMapDoc.cpp
Filter=N
BaseClass=CDocument
VirtualFilter=DC
LastObject=CGISMapDoc

[CLS:CGISMapView]
Type=0
HeaderFile=GISMapView.h
ImplementationFile=GISMapView.cpp
Filter=C
BaseClass=CView
VirtualFilter=VWC
LastObject=ID_FILE_OPEN


[CLS:CMainFrame]
Type=0
HeaderFile=MainFrm.h
ImplementationFile=MainFrm.cpp
Filter=T
LastObject=ID_SHAPEFILE_OPEN




[CLS:CAboutDlg]
Type=0
HeaderFile=GISMap.cpp
ImplementationFile=GISMap.cpp
Filter=D

[DLG:IDD_ABOUTBOX]
Type=1
Class=CAboutDlg
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308480
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889

[MNU:IDR_MAINFRAME]
Type=1
Class=CMainFrame
Command1=ID_FILE_NEW
Command2=ID_FILE_OPEN
Command3=ID_FILE_SAVE
Command4=ID_FILE_SAVE_AS
Command5=ID_FILE_PRINT
Command6=ID_FILE_PRINT_PREVIEW
Command7=ID_FILE_PRINT_SETUP
Command8=ID_FILE_MRU_FILE1
Command9=ID_APP_EXIT
Command10=ID_EDIT_UNDO
Command11=ID_EDIT_CUT
Command12=ID_EDIT_COPY
Command13=ID_EDIT_PASTE
Command14=ID_VIEW_TOOLBAR
Command15=ID_VIEW_STATUS_BAR
Command16=ID_APP_ABOUT
CommandCount=16

[ACL:IDR_MAINFRAME]
Type=1
Class=CMainFrame
Command1=ID_FILE_NEW
Command2=ID_FILE_OPEN
Command3=ID_FILE_SAVE
Command4=ID_FILE_PRINT
Command5=ID_EDIT_UNDO
Command6=ID_EDIT_CUT
Command7=ID_EDIT_COPY
Command8=ID_EDIT_PASTE
Command9=ID_EDIT_UNDO
Command10=ID_EDIT_CUT
Command11=ID_EDIT_COPY
Command12=ID_EDIT_PASTE
Command13=ID_NEXT_PANE
Command14=ID_PREV_PANE
CommandCount=14

[TB:IDR_MAINFRAME]
Type=1
Class=CMainFrame
Command1=ID_FILE_NEW
Command2=ID_FILE_OPEN
Command3=ID_FILE_SAVE
Command4=ID_EDIT_CUT
Command5=ID_EDIT_COPY
Command6=ID_EDIT_PASTE
Command7=ID_FILE_PRINT
Command8=ID_APP_ABOUT
Command9=GISMAP_ZOOMIN
Command10=GISMAP_ZOOMOUT
Command11=GISMAP_RESET
Command12=GISMAP_PAN
CommandCount=12

