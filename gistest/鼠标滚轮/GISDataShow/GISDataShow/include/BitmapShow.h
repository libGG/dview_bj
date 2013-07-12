#include <windowsx.h>
#pragma once
# ifndef _INC_DIBAPI
# define _INC_DIBAPI
#endif
DECLARE_HANDLE(HDIB);
#define PALVERSION 0x300
#define IS_WIN30_DIB(lpbi) ((*(LPDWORD)(lpbi))==sizeof(BITMAPINFOHEADER))
#define RECTWIDTH(lpRect) ((lpRect)->right-(lpRect)->left) 
#define RECTHEIGHT(lpRect) ((lpRect)->bottom-(lpRect)->top)
#define WIDTHBYTES(bits)   (((bits)+31)/32*4)
#define DIB_HEADER_MARKER  ((WORD) ('M'<<8)|'B')
#if _MSC_VER > 1000
#endif // _MSC_VER > 1000
//注意：CBitmapShow采用的是BIT信息头和内容分开的技术
enum BitmapShowKind
{
	UnknownShow=-1,
	GrayShow=0
};
class CRGBBitmapShow;
class CBitmapShow
{
public:
	CBitmapShow()
	{
		kind=UnknownShow;
		Palette=NULL;
		m_lpBitmapInfo=NULL;
		lpDIBBits=NULL;
		Width=Height=0;
	};
	virtual~CBitmapShow()
	{
		if(Palette!=NULL)
		{
			delete Palette;
			Palette=NULL;
		}
		if(m_lpBitmapInfo!=NULL) GlobalFreePtr(m_lpBitmapInfo);
		if(lpDIBBits!=NULL) GlobalFreePtr(lpDIBBits);
        lpDIBBits=NULL;
	};
	int GetWidth()
	{
		return Width;
	};
	int GetHeight()
	{
		return Height;
	};
	BitmapShowKind GetBitmapShowKind()
	{
		return kind;
	};
	bool InitialBitmap(int Width,int Height);
	bool ResetPaletteColor(int*r,int*g,int*b);
	long GetILineBytes()
	{
		return ILineBytes;
	};//每一行的字节数
	unsigned char*GetDIBBits()
	{
		return lpDIBBits;
	};//得到图像数组
	bool PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect);
	bool PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect,COLORREF TransparentColor);
	virtual bool CopyDataFromArray(unsigned char*pData,bool IsReversed=true)=0;//注意，pData大小为Width*Height,而不是ILineBytes*Height
	virtual bool CopyDataFromArray(float*pData,bool IsReversed=true)=0;
	virtual bool CopyDataFromArray(float*pData,float ax,float ay,bool IsReversed=true)=0;
protected:
	virtual DWORD GetCompressionKind()=0;
	virtual int GetNumberColors()=0;
	virtual int GetBitCount()=0;
protected:
	BOOL CreateDIBPalette();
protected:
	friend class CRGBBitmapShow;
    int Width;
	int Height;
    BitmapShowKind kind;
	LPBITMAPINFO m_lpBitmapInfo;
	CPalette*Palette;
	unsigned char* lpDIBBits;// 位图数据，像素值
	long ILineBytes;
};
class CGrayBitmapShow :public CBitmapShow
{
public:
    CGrayBitmapShow()
	{
	};
	virtual~CGrayBitmapShow()
	{
	};
	bool CopyDataFromArray(unsigned char*pData,bool IsReversed=true);//注意，pData大小为Width*Height,而不是ILineBytes*Height
	bool CopyDataFromArray(float*pData,bool IsReversed=true);
	bool CopyDataFromArray(float*pData,float ax,float ay,bool IsReversed=true);
protected:

	int GetNumberColors()
	{
		return 256;
	};
	int GetBitCount()
	{
		return 8;
	};
	DWORD GetCompressionKind()
	{
		return BI_RGB;
	};
};
class CRGBBitmapShow
{
public:
    CRGBBitmapShow();
	virtual~CRGBBitmapShow();
	bool InitialBitmap(int Width,int Height);
    bool PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect);
	bool PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect,COLORREF TransparentColor);
    CGrayBitmapShow*GetBandShow(int index)
	{
		return &pShow[index];
	};
protected:
	bool PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect,int index);
	BOOL CreateDIBPalette(CPalette**pPal,int index);
	BOOL CreateDIBPalette();
protected:
	CGrayBitmapShow pShow[3];
    CPalette*PaletteR;
	CPalette*PaletteG;
	CPalette*PaletteB;
	int Width;
	int Height;
};