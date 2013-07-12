// BaseClass.cpp: implementation of the CBaseClass class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "BaseClass.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////
CFilePath::CFilePath()
{
}
CFilePath::CFilePath(CString PathName)
{
	lpszPathName=PathName;
}
void CFilePath::SetFilePath(CString PathName)
{
    lpszPathName=PathName;
}
CFilePath::~CFilePath()
{
}
CString CFilePath::GetDir()
{
	int pos=lpszPathName.ReverseFind('\\');
	if (pos>=0) 
	{
		CString dir=lpszPathName.Left(pos);
		dir.TrimLeft();
		dir.TrimRight();
		return dir;
	}
	return " ";
}
CString CFilePath::GetFileName()
{
	CString fullpath=lpszPathName;
	fullpath.TrimLeft();
	fullpath.TrimRight();
	int ipos=fullpath.ReverseFind('\\');
    if(ipos>=1)
	{
	    CString fn=fullpath.Right(fullpath.GetLength()-ipos-1);
		fn.TrimLeft();
		fn.TrimRight();
		return fn;
	}
	return "";
}
CString CFilePath::GetFileNameNoExa()
{
	CString filename=GetFileName();
	if(filename=="")
	{
		filename=lpszPathName;
	}
    int ipos=filename.ReverseFind('.');
	if(ipos>=0)
	  return filename.Left(ipos);
	return filename;
}
CString CFilePath::GetFileExa()
{
    int ipos=lpszPathName.ReverseFind('.');
    if(ipos>=0)
	  return lpszPathName.Right(lpszPathName.GetLength()-ipos-1);
	return "";
}
CString CFilePath::GetSystemTempDir()
{
	TCHAR szDir [MAX_PATH];
	GetTempPath(MAX_PATH,szDir);
    CString SysPath=szDir;
	if(SysPath.GetAt(SysPath.GetLength()-1)=='\\') SysPath.Delete(SysPath.GetLength()-1);
	return SysPath;
}
CString CFilePath::GetCurrentDir()
{
	TCHAR szDir [MAX_PATH];
    GetModuleFileName(NULL, szDir,MAX_PATH); 
	CString SysPath=szDir;
	if(SysPath.GetAt(SysPath.GetLength()-1)=='\\') SysPath.Delete(SysPath.GetLength()-1);
	return SysPath;
}
CTabedString::CTabedString(CString sV,char sepChar)
{
   sValue=sV;
   Pin=0;
   Length=sV.GetLength();
   SepChar=sepChar;
}
CTabedString::~CTabedString()
{
    
}
bool CTabedString::GetNextString(CString&str)
{
    if(Pin>=Length) return false;
	char tc;
	int SpaceState=0;
	str="";
	for(int k=Pin;k<Length;k++)
	{
        Pin=k;
		tc=sValue.GetAt(k);
		if(tc==SepChar) 
		{
			if(SpaceState==1) 
			{
				Pin++;
				return true;
			}
		}
		else 
		{
			SpaceState=1;
			str=str+tc;
		}
	}
	if(SpaceState==1) 
	{
		Pin++;
		return true;
	}
	return false;
}
CMapPosition::CMapPosition()
{
    ax=ay=1;
	bx=by=0;
}
CMapPosition::~CMapPosition()
{
   
}

void CMapPosition::InitialMap(CRect Client,DRect Extent)
{
	double ratio=fabs((Extent.Right-Extent.Left)/(Extent.Bottom-Extent.Top));
	double ratio1=(double)Client.Width()/Client.Height();
	if(fabs(ratio-ratio1)<=0.0001)
	{
        ClientRect=Client;
	    ExtentRect=Extent;
	    ComputeTransForm();
		return;
	}
	DRect ir;
	if(ratio<=ratio1)
	{
        ir.Top=Extent.Top;
		ir.Bottom=Extent.Bottom;
		float W=fabs(Extent.Height()*ratio1);
        ir.Left=Extent.Left+(Extent.Width()-W)/2;
        ir.Right=Extent.Right-(Extent.Width()-W)/2;
	}
	else
	{
        ir.Left=Extent.Left;
		ir.Right=Extent.Right;
		double H=fabs(Extent.Width()/ratio1);
        if(Extent.Top>Extent.Bottom)
		{
			ir.Top=Extent.Top+(H-fabs(Extent.Height()))/2;
			ir.Bottom=Extent.Bottom-(H-fabs(Extent.Height()))/2;
		}
		else
		{
            ir.Top=Extent.Top-(H-Extent.Height())/2;
			ir.Bottom=Extent.Bottom+(H-Extent.Height())/2;
		}
	} 
    ClientRect=Client;
	ExtentRect=ir;
	ComputeTransForm();
}
void CMapPosition::SizeMap(CRect Client)
{
	 if(Client.Height()==0) return;
	 float ratio1=(float)Client.Width()/Client.Height();
	 DRect NewExtent;
     NewExtent.Top=ExtentRect.Top;
	 NewExtent.Bottom=ExtentRect.Bottom;
	 float dif=ratio1*fabs(NewExtent.Height())-ExtentRect.Width();
	 NewExtent.Left=ExtentRect.Left-dif/2;
     NewExtent.Right=ExtentRect.Right+dif/2;
	 ExtentRect=NewExtent;
	 ClientRect=Client;
	 ComputeTransForm();
}
void CMapPosition::ComputeTransForm()
{
	ax=(ExtentRect.Right-ExtentRect.Left)/(ClientRect.right-ClientRect.left);
	bx=-ClientRect.left*ax+ExtentRect.Left;// ClientRect.left通常都为0呀，研究了半天，终于有进展了
	ay=(ExtentRect.Bottom-ExtentRect.Top)/(ClientRect.bottom-ClientRect.top);
	by=-ClientRect.top*ay+ExtentRect.Top;// ClientRect.top通常都为0呀
	TRACE("ax= %f, ay= %f\n",ax,ay);
	TRACE("ClientRect.left*ax= %f, ClientRect.top*ay= %f\n",ClientRect.left*ax,ClientRect.top*ay);
}
DBPoint CMapPosition::ClientToMap(DBPoint pt)
{
	DBPoint dpt;
	dpt.X=ax*pt.X+bx;
	dpt.Y=ay*pt.Y+by;
	return dpt;
}
DRect CMapPosition::ClientToMap(DRect rt)
{
	DRect drt;
    drt.Left=ax*rt.Left+bx;
    drt.Top=ay*rt.Top+by;
    drt.Right=ax*rt.Right+bx;
    drt.Bottom=ay*rt.Bottom+by;
	return drt;
}
double CMapPosition::ToMapDistance(double ClientDist)
{
    return max(ax*ClientDist,ay*ClientDist);
}
DBPoint CMapPosition::MapToClient(DBPoint dpt)
{
    DBPoint pt;
	pt.X=(dpt.X-bx)/ax;
	pt.Y=(dpt.Y-by)/ay;
	return pt;
}
DRect CMapPosition::MapToClient(DRect drt)
{
	DRect rt;
    rt.Left=(drt.Left-bx)/ax;
    rt.Top=(drt.Top-by)/ay;
    rt.Right=(drt.Right-bx)/ax;
    rt.Bottom=(drt.Bottom-by)/ay;
	return rt;
}
CRect CMapPosition::GetClientRect()
{
	return ClientRect;
}
DRect CMapPosition::GetExtentRect()
{
	return ExtentRect;
}
CCSVColumn::CCSVColumn()
{
   
}
CCSVColumn::~CCSVColumn()
{
    
}
void CCSVColumn::Add(CString sV)
{ 
    sValues.Add(sV);
}
long CCSVColumn::GetSize()
{
     return sValues.GetSize();
}
CString CCSVColumn::GetAt(long index)
{
    return sValues.GetAt(index);
}
void CCSVColumn::SetFiledName(CString fn)
{
    FieldName=fn;
}
CString CCSVColumn::GetFieldName()
{
     return FieldName;
}
long CCSVColumn::FindValue(CString sValue)
{
    long Size=sValues.GetSize();
	for(long k=0;k<Size;k++)
	{
		if(sValue==sValues.GetAt(k)) return k;
	}
	return -1;
}
CCSVDatabase::CCSVDatabase()
{

}
CCSVDatabase::~CCSVDatabase()
{
    for(long k=cols.GetSize()-1;k>=0;k--) delete cols.GetAt(k);
}
CCSVColumn*CCSVDatabase::GetAt(long index)
{
    return cols.GetAt(index);
}
CCSVColumn*CCSVDatabase::GetAt(CString FieldName)
{
    for(long k=cols.GetSize()-1;k>=0;k--)
	{
		CCSVColumn*pColumn=cols.GetAt(k);
		if(pColumn->GetFieldName()==FieldName) return pColumn;
	}
	return NULL;
}
CCSVColumn*CCSVDatabase::Add(CString FieldName)
{
    CCSVColumn*pCol=new CCSVColumn();
	pCol->SetFiledName(FieldName);
	cols.Add(pCol);
	return pCol;
}
bool CCSVDatabase::ReadFromCSVFile(CString lpszPath,int MaxReaderNum)
{ 
    for(long k=cols.GetSize()-1;k>=0;k--) delete cols.GetAt(k);
	cols.RemoveAll();
	CFileFind fd;
	if(!fd.FindFile(lpszPath)) return false;
	CStdioFile File;
	if(!File.Open(lpszPath,CFile::modeRead)) return false;
	long fl=File.GetLength();
	CString FileData;
	long index=0;
	long Num;
	CString sValue;
	while(File.GetPosition()<fl)
	{
        File.ReadString(FileData);
        CTabedString pTS(FileData,',');
		if(index>0)
		{
           Num=0;
		   while(pTS.GetNextString(sValue))
		   {
               int len=sValue.GetLength();
			   if(len>2)
			   {
				   if(sValue.GetAt(len-1)=='"') sValue.Delete(len-1);
				   if(sValue.GetAt(0)=='"') sValue.Delete(0);
			   }
			   cols.GetAt(Num)->Add(sValue);
			   Num++;
			   if((MaxReaderNum>0)&&(Num>=MaxReaderNum)) break;
		   }
		}
	    else
		{
		   Num=0;
		   while(pTS.GetNextString(sValue))
		   {
               int len=sValue.GetLength();
			   if(len>2)
			   {
				   if(sValue.GetAt(len-1)=='"') sValue.Delete(len-1);
				   if(sValue.GetAt(0)=='"') sValue.Delete(0);
			   }
			   Add(sValue);
			   Num++;
			   if((MaxReaderNum>0)&&(Num>=MaxReaderNum)) break;
		   }
		}
		index++;
	}
	return true;
}