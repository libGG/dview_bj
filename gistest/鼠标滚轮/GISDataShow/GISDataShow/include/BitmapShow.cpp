#include "StdAfx.h"
#include "BitmapShow.h"

BOOL CBitmapShow::CreateDIBPalette()
{
	if(Palette!=NULL)
	{
		delete Palette;
		Palette=NULL;
	}
	int NumberColors=GetNumberColors();
	if(NumberColors==0) return TRUE;
	CPalette*pPal;
	pPal=new CPalette;
	LPLOGPALETTE lpPal;
	HANDLE hLogPal;
	HPALETTE hPal=NULL;
	int i;
	hLogPal=::GlobalAlloc(GHND,sizeof(LOGPALETTE)+sizeof(PALETTEENTRY)*NumberColors);
	if(hLogPal==0)
	{
		delete pPal;
		return FALSE;
	}
	lpPal=(LPLOGPALETTE)::GlobalLock((HGLOBAL)hLogPal);
	lpPal->palVersion=PALVERSION;
	lpPal->palNumEntries=(WORD)NumberColors;
	for(int i=0;i<NumberColors;i++)
	{
		lpPal->palPalEntry[i].peRed=m_lpBitmapInfo->bmiColors[i].rgbRed;
		lpPal->palPalEntry[i].peGreen=m_lpBitmapInfo->bmiColors[i].rgbGreen;
		lpPal->palPalEntry[i].peBlue=m_lpBitmapInfo->bmiColors[i].rgbBlue;
		lpPal->palPalEntry[i].peFlags=0;
	}
	BOOL bResult=pPal->CreatePalette(lpPal);
	::GlobalUnlock((HGLOBAL)hLogPal);
	::GlobalFree((HGLOBAL)hLogPal);
    Palette=pPal;
    return bResult;
}
bool CBitmapShow::InitialBitmap(int width,int height)
{
     if((Width==width)&&(Height==height)) return true;
	 Width=width;
	 Height=height;
	 if(m_lpBitmapInfo!=NULL) GlobalFreePtr(m_lpBitmapInfo);
	 int colors=GetNumberColors();
	 if(colors==0) colors=256;
	 m_lpBitmapInfo = (LPBITMAPINFO) GlobalAllocPtr(GHND,sizeof(BITMAPINFOHEADER) + sizeof(RGBQUAD) * colors);
	 m_lpBitmapInfo->bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
	 m_lpBitmapInfo->bmiHeader.biWidth = Width;
	 m_lpBitmapInfo->bmiHeader.biHeight = Height;
	 m_lpBitmapInfo->bmiHeader.biCompression=GetCompressionKind();
	 m_lpBitmapInfo->bmiHeader.biSizeImage = 0;
	 m_lpBitmapInfo->bmiHeader.biXPelsPerMeter = 0;
	 m_lpBitmapInfo->bmiHeader.biYPelsPerMeter = 0;
	 m_lpBitmapInfo->bmiHeader.biPlanes = 1;
	 m_lpBitmapInfo->bmiHeader.biBitCount =GetBitCount();
	 m_lpBitmapInfo->bmiHeader.biClrUsed = 0;
	 m_lpBitmapInfo->bmiHeader.biClrImportant = 0;
	 ILineBytes=WIDTHBYTES(Width*GetBitCount());
	 m_lpBitmapInfo->bmiHeader.biSizeImage=ILineBytes*Height;
     for(int k=0;k<colors;k++) m_lpBitmapInfo->bmiColors[k].rgbRed=m_lpBitmapInfo->bmiColors[k].rgbGreen=m_lpBitmapInfo->bmiColors[k].rgbBlue=k;
	 if(!CreateDIBPalette())
	 {
         if(m_lpBitmapInfo!=NULL) GlobalFreePtr(m_lpBitmapInfo);
         m_lpBitmapInfo=NULL;
		 return false;
	 }
	 if(lpDIBBits!=NULL) GlobalFreePtr(lpDIBBits);
     lpDIBBits=NULL;
     lpDIBBits=(unsigned char*)GlobalAllocPtr(GHND,ILineBytes*Height);
	 if(lpDIBBits==NULL)
	 {
         if(m_lpBitmapInfo!=NULL) GlobalFreePtr(m_lpBitmapInfo);
         m_lpBitmapInfo=NULL;
         if(Palette!=NULL) delete Palette;
		 Palette=NULL;
		 return false;
	 }
	 return true;
}
bool CBitmapShow::ResetPaletteColor(int*r,int*g,int*b)
{
     int NumberColors=GetNumberColors();
	 for(int k=0;k<NumberColors;k++) 
	 {
		 m_lpBitmapInfo->bmiColors[k].rgbRed=r[k];
	     m_lpBitmapInfo->bmiColors[k].rgbGreen=g[k];
	     m_lpBitmapInfo->bmiColors[k].rgbBlue=b[k];
	 }
	 return CreateDIBPalette();
} 
bool CBitmapShow::PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect)
{
	if(m_lpBitmapInfo==NULL) return false;
	if(lpDIBBits==NULL) return false;
	BOOL bSuccess=false;
	HPALETTE hPal=NULL;
	HPALETTE hOldPal= NULL;
	CRect DIBRect(lpDIBRect->left,Height-lpDIBRect->bottom-1,lpDIBRect->right,Height-lpDIBRect->top-1);
	CPalette*pPal=Palette;
	if(pPal!=NULL)
	{
		hPal=(HPALETTE)pPal->m_hObject;
		hOldPal=::SelectPalette(hDC,hPal,TRUE);
	}
	::SetStretchBltMode(hDC,COLORONCOLOR);
	if((RECTWIDTH(lpDCRect)==RECTWIDTH(lpDIBRect))&&
		(RECTHEIGHT(lpDCRect)==RECTHEIGHT(lpDIBRect)))
	{
	
		bSuccess=::SetDIBitsToDevice(hDC,
			                         lpDCRect->left,                                             
                                     lpDCRect-> top, 
									 RECTWIDTH(lpDCRect), 
									 RECTHEIGHT(lpDCRect),
									 DIBRect.left,
									 DIBRect.top,
									 0,
									 Height,
									 lpDIBBits,
									 m_lpBitmapInfo,
									 DIB_RGB_COLORS);
	}
	else
	{
		
		bSuccess=::StretchDIBits(hDC,
			                      lpDCRect->left,
								  lpDCRect->top,
								  RECTWIDTH(lpDCRect),
                                  RECTHEIGHT(lpDCRect),
                                  DIBRect.left,
								  DIBRect.top,
								  DIBRect.Width()+1,
								  DIBRect.Height()+1,
								  lpDIBBits,
								  m_lpBitmapInfo,
								  DIB_RGB_COLORS,
								  SRCCOPY);

	}
	if(hOldPal!=NULL)
	{
		::SelectPalette(hDC,hOldPal,TRUE);
	}
	return bSuccess;
}
bool CBitmapShow::PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect,COLORREF TransparentColor)
{
	CDC*pDC=CDC::FromHandle(hDC);
	CDC memDC,tempDC;
	HBITMAP m_bitmap =CreateCompatibleBitmap(hDC,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect)); //创建位图内存 
	memDC.CreateCompatibleDC(pDC);
	HBITMAP pOldBitmap=(HBITMAP)SelectObject(memDC, m_bitmap); 
	CRect memrt(0,0,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect));
	if(!PaintDIB(memDC.m_hDC,memrt,lpDIBRect))
	{
		memDC.SelectObject(pOldBitmap);
		DeleteObject(m_bitmap); 
 	    memDC.DeleteDC();
		return false;
	}
	tempDC.CreateCompatibleDC(pDC);
	HBITMAP maskBMP =CreateBitmap(RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),1,1,NULL); //创建单色掩码位图 
    HBITMAP oldmaskBMP=(HBITMAP)SelectObject(tempDC, maskBMP);
	SetBkColor(memDC.m_hDC, TransparentColor);// 设置透明色 
	BitBlt(tempDC.m_hDC,0,0,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),memDC.m_hDC,0,0,SRCCOPY);
	SetBkColor(memDC.m_hDC, RGB(0,0,0)); 
	SetTextColor(memDC.m_hDC, RGB(255,255,255)); // 白色 
    BitBlt(memDC.m_hDC,0,0,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),tempDC.m_hDC,0,0,SRCAND); 
    SetBkColor(hDC,RGB(255,255,255)); // 透明部分保持屏幕不变，其它部分变成黑色 
	SetTextColor(hDC,RGB(0,0,0)); // 黑色 
	BitBlt(hDC,lpDCRect->left, lpDCRect->top,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),tempDC.m_hDC,0,0,SRCAND); //"与"运算,在hdc0生成掩模
    BitBlt(hDC,lpDCRect->left, lpDCRect->top,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),memDC.m_hDC,0,0,SRCPAINT);
	memDC.SelectObject(pOldBitmap);
	tempDC.SelectObject(oldmaskBMP);
	DeleteObject(m_bitmap); 
    DeleteObject(maskBMP); 
 	memDC.DeleteDC();
	tempDC.DeleteDC();
	return true;
}
bool CGrayBitmapShow::CopyDataFromArray(float*pData,bool IsReversed)
{
	if(lpDIBBits==NULL) return false;
	unsigned char*lpDst;
	long Pos=0;
	if(IsReversed)
	{
		for(int i=0;i<Height;i++)
		{
			 lpDst=lpDIBBits+ILineBytes*(Height-i-1);
			 for(int j=0;j<Width;j++)
			 {
				 *lpDst++=pData[Pos++];
			 }
		}
	}
	else
	{
		for(int i=0;i<Height;i++)
		{
			 lpDst=lpDIBBits+ILineBytes*i;
			 for(int j=0;j<Width;j++)
			 {
				 *lpDst++=pData[Pos++];
			 }
		}
	}
	return true;
}
bool CGrayBitmapShow::CopyDataFromArray(float*pData,float ax,float ay,bool IsReversed)
{
	if(lpDIBBits==NULL) return false;
	unsigned char*lpDst;
	long Pos=0;
	if(IsReversed)
	{
		for(int i=0;i<Height;i++)
		{
			 lpDst=lpDIBBits+ILineBytes*(Height-i-1);
			 for(int j=0;j<Width;j++)
			 {
				 *lpDst++=ax+pData[Pos++]+ay;
			 }
		}
	}
	else
	{
		for(int i=0;i<Height;i++)
		{
			 lpDst=lpDIBBits+ILineBytes*i;
			 for(int j=0;j<Width;j++)
			 {
				 *lpDst++=ax*pData[Pos++]+ay;
			 }
		}
	}
	return true;
}
bool CGrayBitmapShow::CopyDataFromArray(unsigned char*pData,bool IsReversed)
{
	if(lpDIBBits==NULL) return false;
	unsigned char*lpSrc,*lpDst;
	if(IsReversed)
	{
		for(int k=0;k<Height;k++)
		{
			lpSrc=pData+Width*(Height-k-1);
			lpDst=lpDIBBits+ILineBytes*k;
			memcpy(lpDst,lpSrc,Width*3);
		}
	}
	else
	{
		for(int k=0;k<Height;k++)
		{
			lpSrc=pData+Width*(Height-k-1);
			lpDst=lpDIBBits+ILineBytes*k;
			memcpy(lpDst,lpSrc,Width);
		}
	}
	return true;
}
CRGBBitmapShow::CRGBBitmapShow()
{
     PaletteR=NULL;
	 PaletteG=NULL;
	 PaletteB=NULL;
}
CRGBBitmapShow::~CRGBBitmapShow()
{
     if(PaletteR!=NULL) delete PaletteR;
	 PaletteR=NULL;
	 if(PaletteG!=NULL) delete PaletteG;
	 PaletteG=NULL;
	 if(PaletteB!=NULL) delete PaletteB;
	 PaletteB=NULL;
}
BOOL CRGBBitmapShow::CreateDIBPalette(CPalette**pPal,int index)
{
	int NumberColors=256;
	*pPal=new CPalette;
	LPLOGPALETTE lpPal;
	HANDLE hLogPal;
	HPALETTE hPal=NULL;
	int i;
	hLogPal=::GlobalAlloc(GHND,sizeof(LOGPALETTE)+sizeof(PALETTEENTRY)*256);
	if(hLogPal==0)
	{
		delete *pPal;
		*pPal=NULL;
		return FALSE;
	}
	lpPal=(LPLOGPALETTE)::GlobalLock((HGLOBAL)hLogPal);
	lpPal->palVersion=PALVERSION;
	lpPal->palNumEntries=(WORD)NumberColors;
	int ratio[3];
	if(index==0)
	{
		ratio[0]=1;
		ratio[1]=0;
		ratio[2]=0;
	}
	else if(index==1)
	{
        ratio[0]=0;
		ratio[1]=1;
		ratio[2]=0;
	}
	else
	{
		ratio[0]=0;
		ratio[1]=0;
		ratio[2]=1;
	}
	for(int i=0;i<256;i++)
	{
		lpPal->palPalEntry[i].peRed=pShow[index].m_lpBitmapInfo->bmiColors[i].rgbRed=i*ratio[0];
		lpPal->palPalEntry[i].peGreen=pShow[index].m_lpBitmapInfo->bmiColors[i].rgbGreen=i*ratio[1];
		lpPal->palPalEntry[i].peBlue=pShow[index].m_lpBitmapInfo->bmiColors[i].rgbBlue=i*ratio[2];
		lpPal->palPalEntry[i].peFlags=0;
	}
	BOOL bResult=(*pPal)->CreatePalette(lpPal);
	::GlobalUnlock((HGLOBAL)hLogPal);
	::GlobalFree((HGLOBAL)hLogPal);
    return bResult;
}
BOOL CRGBBitmapShow::CreateDIBPalette()
{
     if(PaletteR!=NULL) delete PaletteR;
	 PaletteR=NULL;
	 if(PaletteG!=NULL) delete PaletteG;
	 PaletteG=NULL;
	 if(PaletteB!=NULL) delete PaletteB;
	 PaletteB=NULL;
	 if(!CreateDIBPalette(&PaletteR,0)) return FALSE;
	 if(!CreateDIBPalette(&PaletteR,1)) return FALSE;
	 if(!CreateDIBPalette(&PaletteR,2)) return FALSE;
	 return TRUE;
}
bool CRGBBitmapShow::InitialBitmap(int width,int height)
{
     Width=width;
	 Height=height;
	 for(int k=0;k<3;k++) 
	 {
		 if(!pShow[k].InitialBitmap(Width,Height)) return FALSE;
	 }
	 if(!CreateDIBPalette()) return false;
	 return TRUE;
}
bool CRGBBitmapShow::PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect,int index)
{
    if(pShow[index].m_lpBitmapInfo==NULL) return false;
	if(pShow[index].lpDIBBits==NULL) return false;
	BOOL bSuccess=false;
	HPALETTE hPal=NULL;
	HPALETTE hOldPal= NULL;
	CRect DIBRect(lpDIBRect->left,Height-lpDIBRect->bottom-1,lpDIBRect->right,Height-lpDIBRect->top-1);
	CPalette*pPal;
	if(index==0)
		pPal=PaletteR;
	else if(index==1)
		pPal=PaletteG;
	else
		pPal=PaletteB;
	if(pPal!=NULL)
	{
		hPal=(HPALETTE)pPal->m_hObject;
		hOldPal=::SelectPalette(hDC,hPal,TRUE);
	}
	::SetStretchBltMode(hDC,COLORONCOLOR);
	if((RECTWIDTH(lpDCRect)==RECTWIDTH(lpDIBRect))&&
		(RECTHEIGHT(lpDCRect)==RECTHEIGHT(lpDIBRect)))
	{
	
		bSuccess=::SetDIBitsToDevice(hDC,
			                         lpDCRect->left,                                             
                                     lpDCRect-> top, 
									 RECTWIDTH(lpDCRect), 
									 RECTHEIGHT(lpDCRect),
									 DIBRect.left,
									 DIBRect.top,
									 0,
									 Height,
									 pShow[index].lpDIBBits,
									 pShow[index].m_lpBitmapInfo,
									 DIB_RGB_COLORS);
	}
	else
	{
		
		bSuccess=::StretchDIBits(hDC,
			                      lpDCRect->left,
								  lpDCRect->top,
								  RECTWIDTH(lpDCRect),
                                  RECTHEIGHT(lpDCRect),
                                  DIBRect.left,
								  DIBRect.top,
								  DIBRect.Width()+1,
								  DIBRect.Height()+1,
								  pShow[index].lpDIBBits,
								  pShow[index].m_lpBitmapInfo,
								  DIB_RGB_COLORS,
								  SRCCOPY);

	}
	if(hOldPal!=NULL)
	{
		::SelectPalette(hDC,hOldPal,TRUE);
	}
	return bSuccess;
}
bool CRGBBitmapShow::PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect)
{
    CDC*pDC=CDC::FromHandle(hDC);
    CDC memDC;
	memDC.CreateCompatibleDC(pDC);
	HBITMAP m_bitmap =CreateCompatibleBitmap(hDC,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect)); //创建位图内存 
    HBITMAP pOldBitmap=(HBITMAP)SelectObject(memDC, m_bitmap); 
    CRect memrt(0,0,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect));
    if(!PaintDIB(memDC.m_hDC,memrt,lpDIBRect,0))
	{
		memDC.SelectObject(pOldBitmap);
		DeleteObject(m_bitmap); 
 	    memDC.DeleteDC();
		return false;
	}
    BitBlt(hDC,lpDCRect->left, lpDCRect->top,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),memDC.m_hDC,0,0,SRCCOPY);
	if(!PaintDIB(memDC.m_hDC,memrt,lpDIBRect,1))
	{
		memDC.SelectObject(pOldBitmap);
		DeleteObject(m_bitmap); 
 	    memDC.DeleteDC();
		return false;
	}
    BitBlt(hDC,lpDCRect->left, lpDCRect->top,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),memDC.m_hDC,0,0,SRCPAINT);
	if(!PaintDIB(memDC.m_hDC,memrt,lpDIBRect,2))
	{
		memDC.SelectObject(pOldBitmap);
		DeleteObject(m_bitmap); 
 	    memDC.DeleteDC();
		return false;
	}
    BitBlt(hDC,lpDCRect->left, lpDCRect->top,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),memDC.m_hDC,0,0,SRCPAINT);
	memDC.SelectObject(pOldBitmap);
	DeleteObject(m_bitmap); 
 	memDC.DeleteDC();
	return true;
}
bool CRGBBitmapShow::PaintDIB(HDC hDC,LPRECT lpDCRect,LPRECT lpDIBRect,COLORREF TransparentColor)
{
    CDC*pDC=CDC::FromHandle(hDC);
	CDC memDC,tempDC;
	HBITMAP m_bitmap =CreateCompatibleBitmap(hDC,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect)); //创建位图内存 
	memDC.CreateCompatibleDC(pDC);
	HBITMAP pOldBitmap=(HBITMAP)SelectObject(memDC, m_bitmap); 
	CRect memrt(0,0,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect));
	if(!PaintDIB(memDC.m_hDC,memrt,lpDIBRect))
	{
		memDC.SelectObject(pOldBitmap);
		DeleteObject(m_bitmap); 
 	    memDC.DeleteDC();
		return false;
	}
	tempDC.CreateCompatibleDC(pDC);
	HBITMAP maskBMP =CreateBitmap(RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),1,1,NULL); //创建单色掩码位图 
    HBITMAP oldmaskBMP=(HBITMAP)SelectObject(tempDC, maskBMP);
	SetBkColor(memDC.m_hDC, TransparentColor);// 设置透明色 
	BitBlt(tempDC.m_hDC,0,0,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),memDC.m_hDC,0,0,SRCCOPY);
	SetBkColor(memDC.m_hDC, RGB(0,0,0)); 
	SetTextColor(memDC.m_hDC, RGB(255,255,255)); // 白色 
    BitBlt(memDC.m_hDC,0,0,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),tempDC.m_hDC,0,0,SRCAND); 
    SetBkColor(hDC,RGB(255,255,255)); // 透明部分保持屏幕不变，其它部分变成黑色 
	SetTextColor(hDC,RGB(0,0,0)); // 黑色 
	BitBlt(hDC,lpDCRect->left, lpDCRect->top,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),tempDC.m_hDC,0,0,SRCAND); //"与"运算,在hdc0生成掩模
    BitBlt(hDC,lpDCRect->left, lpDCRect->top,RECTWIDTH(lpDCRect),RECTHEIGHT(lpDCRect),memDC.m_hDC,0,0,SRCPAINT);
	memDC.SelectObject(pOldBitmap);
	tempDC.SelectObject(oldmaskBMP);
	DeleteObject(m_bitmap); 
    DeleteObject(maskBMP); 
 	memDC.DeleteDC();
	tempDC.DeleteDC();
	return true;
}