#include "StdAfx.h"
#include "Layer.h"
bool CRasterLayer::SetPathName(CString PathName)
{
    lpszPathName=PathName;
	if(pReader!=NULL) delete pReader;
	CreateNewRasterReader();
	if(!pReader->OpenRaster(PathName)) return false;
	CFilePath pPath(PathName);
	LayerName=pPath.GetFileNameNoExa();
	return true;
}
DRect CRasterLayer::GetFullExtent()
{
    if(pReader==NULL) return DRect(0,0,0,0);
	DRect ex;
	pReader->GetExtent(ex.Left,ex.Bottom,ex.Right,ex.Top);
	return ex;
}
bool CVectorLayer::SetPathName(CString PathName)
{
	lpszPathName=PathName;
	if(pReader!=NULL) delete pReader;
	pReader=new CVectorReader;
	if(!pReader->OpenVector(PathName)) return false;
	CFilePath pPath(PathName);
	LayerName=pPath.GetFileNameNoExa();
	return true;
}
DRect CVectorLayer::GetFullExtent()
{
	if(pReader==NULL) return DRect(0,0,0,0);
	DRect ex;
	pReader->GetExtent(ex.Left,ex.Bottom,ex.Right,ex.Top);
	return ex;
}
