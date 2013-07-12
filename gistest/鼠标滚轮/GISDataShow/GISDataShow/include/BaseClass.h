// BaseClass.h: interface for the CBaseClass class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_BASECLASS_H__6B4FB5B1_FCED_4B9B_B137_5E4ED310F2C6__INCLUDED_)
#define AFX_BASECLASS_H__6B4FB5B1_FCED_4B9B_B137_5E4ED310F2C6__INCLUDED_
#include "afxtempl.h"
#include "math.h"
#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
struct DBPoint    //该类主要用于地理空间中点的表示
{
	double X;
	double Y;
	DBPoint()
	{
	};
	DBPoint(double x,double y)
	{
		X=x;
		Y=y;
	};
};
struct DRect   //本结构提供了double型Rectangle的定义，主要用于地理空间范围的表达。鉴于地理空间的特性，合法的DRect的Bottom小于Top
{
	double Left;
	double Top;
	double Right;
	double Bottom;
	DRect()
	{
	};
	DRect(double l,double t,double r,double b)
	{
		Left=l;
		Top=t;
		Right=r;
		Bottom=b;
	};
	DRect(CRect&rect)
	{
		Left=rect.left;
		Top=rect.top;
		Right=rect.right;
		Bottom=rect.bottom;
	};
	DRect(DRect&rect)
	{
        Left=rect.Left;
		Top=rect.Top;
		Right=rect.Right;
		Bottom=rect.Bottom;
	};
	double Width()
	{
		return Right-Left;
	};
	double Height()
	{
		return Bottom-Top;
	};
	DRect operator + (DRect&Other)
	{
		DRect rect;
		rect.Left=min(Left,Other.Left);
		rect.Right=max(Right,Other.Right);
		if(Bottom<=Top)
		{
		    rect.Top=max(Top,Other.Top);
		    rect.Bottom=min(Bottom,Other.Bottom);
		}
		else
		{
            rect.Top=min(Top,Other.Top);
		    rect.Bottom=max(Bottom,Other.Bottom);
		}
		return rect;
	};
	DRect& operator += (DRect&Other)
	{
		Left=min(Left,Other.Left);
		Right=max(Right,Other.Right);
		if(Bottom<=Top)
		{
		    Top=max(Top,Other.Top);
		    Bottom=min(Bottom,Other.Bottom);
		}
		else
		{
            Top=min(Top,Other.Top);
		    Bottom=max(Bottom,Other.Bottom);
		}
		return *this;
	};
	DRect Intersect(DRect other)
	{
        bool IsNormal=(Top>=Bottom); 
		DRect pr(Left,Top,Right,Bottom);
		pr.NormalizeRect();
		other.NormalizeRect();
        pr.Left=max(Left,other.Left);
        pr.Top=min(Top,other.Top); 
        pr.Right=min(Right,other.Right);
        pr.Bottom=max(Bottom,other.Bottom); 
        if(!IsNormal)
		{
			double t=pr.Top;
			pr.Top=pr.Bottom;
			pr.Bottom=t;
		}
		return pr;
	};
	void InflateRect(double l,double t,double r,double b,bool IsRatio=false)
	{
		if(IsRatio)
		{
			l=l*(Right-Left);
			r=r*(Right-Left);
			t=t*fabs(Top-Bottom);
			b=b*fabs(Top-Bottom);
		}
		Left-=l;
		Right+=r;
		if(Top>Bottom)
		{
		  Top+=t;
		  Bottom-=b;
		}
		else
		{
          Top-=t;
		  Bottom+=b;
		}
	};
	void NormalizeRect()   //使DRect合法
	{
		if(Left>Right)
		{
			double temp=Left;
			Left=Right;
			Right=temp;
		}
		if(Bottom>Top)
		{
			double temp=Bottom;
			Bottom=Top;
			Top=temp;
		}
	};
	bool PtInRect(double X,double Y)
	{
       return ((X>=Left)&&(X<=Right)&&(Y>=min(Bottom,Top))&&(Y<=max(Bottom,Top)));
	};
	bool PtInRect(CPoint&pt)
	{
		return ((pt.x>=Left)&&(pt.x<=Right)&&(pt.y>=min(Bottom,Top))&&(pt.y<=max(Bottom,Top)));
	};
    bool PtInRect(DBPoint&pt)
	{
		return ((pt.X>=Left)&&(pt.X<=Right)&&(pt.Y>=min(Bottom,Top))&&(pt.Y<=max(Bottom,Top)));
	};
	bool IntersectRect(DRect other)
	{
		other.NormalizeRect();
		DRect rt(Left,Top,Right,Bottom);
		rt.NormalizeRect();
		if(other.Left>rt.Right) return false;
		if(other.Right<rt.Left) return false;
		if(other.Top<rt.Bottom) return false;
		if(other.Bottom>rt.Top) return false;
		return true;
	};
	bool IntersectRect(CRect other)
	{
        other.NormalizeRect();
		DRect rt(Left,Top,Right,Bottom);
		rt.NormalizeRect();
		if(other.left>rt.Right) return false;
		if(other.right<rt.Left) return false;
		if(other.bottom<rt.Bottom) return false;
		if(other.top>rt.Top) return false;
		return true;
	};
	bool IsPointIn(DBPoint&dpt)
	{
		if((dpt.X<Left)||(dpt.X>Right)) return false;
		if((dpt.Y<min(Top,Bottom))||(dpt.Y>max(Top,Bottom))) return false;
		return true;
	};
	bool IsPointIn(CPoint&pt)
	{
        if((pt.x<Left)||(pt.x>Right)) return false;
		if((pt.y<min(Top,Bottom))||(pt.y>max(Top,Bottom))) return false;
		return true;
	};
	bool IsRectIn(DRect&other)
	{
        other.NormalizeRect();
		DRect rt(Left,Top,Right,Bottom);
		rt.NormalizeRect();
		return ((other.Left>=rt.Left)&&(other.Right<=rt.Right)&&(other.Bottom>=rt.Bottom)&&(other.Top<=rt.Top));
	};
};
class CFilePath
{
public:
    CFilePath();
	CFilePath(CString PathName);
	virtual~CFilePath();
    CString GetDir();
	CString GetFileName();
	CString GetFileNameNoExa();
	CString GetFileExa();
	CString GetSystemTempDir();
	CString GetCurrentDir();
	void SetFilePath(CString PathName);
private:
    CString lpszPathName;
};
class CTabedString
{
public:
	CTabedString(CString sV,char SepChar=' ');
	virtual~CTabedString();
    bool GetNextString(CString&str);
private:
	CString sValue;
	int Pin;
	int Length;
	char SepChar;
};
class CMapPosition            
//该类实现地图坐标和客户坐标相互转换，使用时只需调用InitialPaintMap即可计算转换系数，当客户范围改变后，请使用SizePaintMap
{
public:
    CMapPosition();
	virtual~CMapPosition();
	void InitialMap(CRect Client,DRect Extent);
	void SizeMap(CRect Client);  //当客户范围改变后，重新调整地图范围
	DBPoint ClientToMap(DBPoint pt);   //由客户坐标求取地图坐标
	DBPoint MapToClient(DBPoint dpt);  //由地图坐标求取客户坐标
	double ToMapDistance(double ClientDist);
	DRect ClientToMap(DRect rt);
	DRect MapToClient(DRect drt);
	CRect GetClientRect();
	DRect GetExtentRect();
	double GetOnePixelMapDistance()
	{
		return min(fabs(ax),fabs(ay));
	};
protected:
	void ComputeTransForm();  //该类实现转换系数的求取
protected:
    double ax,bx;
	double ay,by;
	CRect ClientRect;  //客户范围
	DRect ExtentRect;  //地图范围
};
class CCSVColumn
{
public:
	CCSVColumn();
	virtual~CCSVColumn();
	void Add(CString sV);
	long GetSize();
	CString GetAt(long index);
	void SetFiledName(CString fn);
	CString GetFieldName();
	long FindValue(CString sValue);
private:
	CString FieldName;
    CArray<CString,CString>sValues;
};
class CCSVDatabase
{
public:
	CCSVDatabase();
	virtual~CCSVDatabase();
	CCSVColumn*GetAt(long index);
	CCSVColumn*GetAt(CString FieldName);
	bool ReadFromCSVFile(CString lpszPath,int MaxReaderNum=0);
private:
	CCSVColumn*Add(CString FieldName);
    CArray<CCSVColumn*,CCSVColumn*>cols;
};

#endif // !defined(AFX_BASECLASS_H__6B4FB5B1_FCED_4B9B_B137_5E4ED310F2C6__INCLUDED_)
