#include "StdAfx.h"
#include "LayerPainter.h"
#include "layers.h"
bool CRasterLayerPainter::ComputePaintRect(CMapPosition*mp,CRect&PaintClient,DRect&PaintExtent,CRect&PixelRect)
{
    PaintExtent=mp->GetExtentRect();
	CRasterReader*pReader=((CRasterLayer*)pRefLayer)->GetRasterReader();
	PixelRect.left=pReader->GetPixelRealCol(PaintExtent.Left);
    PixelRect.right=pReader->GetPixelRealCol(PaintExtent.Right);
	PixelRect.top=pReader->GetPixelRealRow(PaintExtent.Top);
	PixelRect.bottom=pReader->GetPixelRealRow(PaintExtent.Bottom);
	PixelRect.NormalizeRect();
	PixelRect.InflateRect(1,1,1,1);
	int Width=pReader->GetCols();
	int Height=pReader->GetRows();
    if(PixelRect.left<0) 
		PixelRect.left=0;
	else if(PixelRect.left>=Width)
		PixelRect.left=Width;
    if(PixelRect.right<0) 
		PixelRect.right=-1;
	else if(PixelRect.right>=Width)
		PixelRect.right=Width-1;
    if(PixelRect.top<0) 
		PixelRect.top=0;
	else if(PixelRect.top>=Height)
		PixelRect.top=Height;
    if(PixelRect.bottom<0) 
		PixelRect.bottom=-1;
	else if(PixelRect.bottom>=Height)
		PixelRect.bottom=Height-1;
    if(PixelRect.left>PixelRect.right) return false;
    if(PixelRect.top>PixelRect.bottom) return false;
    PaintExtent.Left=pReader->GetMapX(PixelRect.left);
    PaintExtent.Right=pReader->GetMapX(PixelRect.right);
    PaintExtent.Top=pReader->GetMapY(PixelRect.top);
	PaintExtent.Bottom=pReader->GetMapY(PixelRect.bottom);
    DRect Client=mp->MapToClient(PaintExtent);
	if(Client.Width()==0) return false;
	if(Client.Height()==0) return false;
    PaintClient=CRect(Client.Left,Client.Top,Client.Right,Client.Bottom);
	return true;
}

bool CGrayRasterLayerPainter::Draw(HDC hDC,CMapPosition*mp)
{
    CRect pixelrect,Client;
	DRect PaintExtent;
	if(!ComputePaintRect(mp,Client,PaintExtent,pixelrect)) return false;
	CGrayBitmapShow*pgs=pShow;
	CRasterReader*pReader=((CRasterLayer*)pRefLayer)->GetRasterReader();
	CGrayRasterReader*gr=(CGrayRasterReader*)pReader;
	CGrayRasterLayer*ly=(CGrayRasterLayer*)pRefLayer;
	int band=ly->GetBand();
	if(band==-1) return false;
	int W,H;
	if(Client.Width()>pixelrect.Width())
	{
		W=pixelrect.Width()+1;
		H=pixelrect.Height()+1;
	}
	else
	{
        W=Client.Width()+1;
		H=Client.Height()+1;
	}
	gr->LoadBandData(band,pixelrect.left,pixelrect.top,pixelrect.Width()+1,pixelrect.Height()+1,W,H);
    float*sV=gr->GetGrayBandData();
	pgs->InitialBitmap(W,H);
    pgs->CopyDataFromArray(sV);
    pixelrect=CRect(0,0,W-1,H-1);
	pgs->PaintDIB(hDC,&Client,&pixelrect);
	return true;
}
bool CRGBRasterLayerPainter::Draw(HDC hDC,CMapPosition*mp)
{
    CRect pixelrect,Client;
	DRect PaintExtent;
	if(!ComputePaintRect(mp,Client,PaintExtent,pixelrect)) return false;
	CRGBBitmapShow*pgs=pShow;
	CRasterReader*pReader=((CRasterLayer*)pRefLayer)->GetRasterReader();
	CRGBRasterReader*gr=(CRGBRasterReader*)pReader;
	CRGBRasterLayer*ly=(CRGBRasterLayer*)pRefLayer;
	int*band=ly->GetBand();
	if(band[0]==-1) return false;
	int W,H;
	if(Client.Width()>pixelrect.Width())
	{
		W=pixelrect.Width()+1;
		H=pixelrect.Height()+1;
	}
	else
	{
        W=Client.Width()+1;
		H=Client.Height()+1;
	}
	gr->LoadBandData(band,pixelrect.left,pixelrect.top,pixelrect.Width()+1,pixelrect.Height()+1,W,H);
	float*srV=gr->GetRBandData();
    float*sgV=gr->GetGBandData();
	float*sbV=gr->GetBBandData();
	pgs->InitialBitmap(W,H);
    pgs->GetBandShow(0)->CopyDataFromArray(srV);
    pgs->GetBandShow(1)->CopyDataFromArray(sgV);
	pgs->GetBandShow(2)->CopyDataFromArray(sbV);
    pixelrect=CRect(0,0,W-1,H-1);
	pgs->PaintDIB(hDC,&Client,&pixelrect);
	return true;
}
void CPointLayerPainter::SetDrawEnvi(COLORREF Color,int size)
{
	TextColor=Color;
	Size=size;
}
bool CPointLayerPainter::Draw(HDC hDC,CMapPosition*mp)
{
	CVectorReader*pReader=((CVectorLayer*)pRefLayer)->GetVectorReader();
	if(pReader==NULL) return false;
	COLORREF color;
	CFont pFont,*oldfont;
	pFont.CreateFontA(Size*2,0,0,0,FW_THIN,false,false,false,DEFAULT_CHARSET,OUT_DEFAULT_PRECIS,OUT_DEFAULT_PRECIS,DEFAULT_QUALITY,DEFAULT_PITCH,"ËÎÌå");
	CDC*pDC=CDC::FromHandle(hDC);
    color=pDC->SetTextColor(TextColor);
	oldfont=pDC->SelectObject(&pFont);
    DRect rt=mp->GetExtentRect();
	pReader->SetSpatialFilterRect(rt.Left,rt.Bottom,rt.Right,rt.Top);
	long Count;
	pReader->GetFeatureCount(Count);
	OGRPoint*dpt;
	DBPoint pt;
	pReader->MoveNext();
	OGRCoordinateTransformation*poCT=NULL;
	if((pRefLayer->GetSpatialReference()!=NULL)&&(pRefLayer->GetLayers()->GetSpatialReference()!=NULL))
	{
		poCT=OGRCreateCoordinateTransformation(pRefLayer->GetSpatialReference(),pRefLayer->GetLayers()->GetSpatialReference());
	}
	for(long k=0;k<Count;k++)
	{
        dpt=(OGRPoint*)pReader->GetCurrentOrginFeatureShape();
		if(dpt==NULL) continue;
        pt.X=dpt->getX();
		pt.Y=dpt->getY();
		if(poCT!=NULL) poCT->Transform(1,&pt.X,&pt.Y);
		pt=mp->MapToClient(pt);
		CRect rt(pt.X-Size,pt.Y-Size,pt.X+Size,pt.Y+Size);
	    pDC->DrawText("¡ï",&rt,0);
		pReader->MoveNext();
	}
	if(poCT!=NULL) delete poCT;
	pDC->SetTextColor(color);
	pDC->SelectObject(oldfont);
	return true;
}
void CPolylineLayerPainter::SetDrawEnvi(COLORREF Color,int size)
{
	LineColor=Color;
	Size=size;
}
void CPolylineLayerPainter::DrawLineString(OGRLineString*ls,CDC*pDC,CMapPosition*mp,OGRCoordinateTransformation*poCT)
{
	/*
	long pCount=ls->getNumPoints(); 
	if(pCount<2) return;
	DBPoint fpt,tpt;
	double*AX=new double[pCount];
    double*AY=new double[pCount];
    for(long p=0;p<pCount;p++)
	{ 
        AX[p]=ls->getX(p);
	    AY[p]=ls->getY(p);
	}
    if(poCT!=NULL) poCT->Transform(pCount,AX,AY);
	fpt.X=AX[0];
	fpt.Y=AY[0];
	if(poCT!=NULL) poCT->Transform(1,&fpt.X,&fpt.Y);
	fpt=mp->MapToClient(fpt);
	using namespace Gdiplus;
	Graphics graphics( pDC->m_hDC );
	REAL dashValues[4] = {5, 2, 15, 4};
	Pen blackPen(Color(255, 0, 0,255), 1);
	blackPen.SetDashPattern(dashValues, 4);

	//pDC->MoveTo(fpt.X,fpt.Y);
	for(long p=1;p<pCount;p++)
	{
		 tpt.X=AX[p];
		 tpt.Y=AY[p];
		 if(poCT!=NULL) poCT->Transform(1,&tpt.X,&tpt.Y);
		 tpt=mp->MapToClient(tpt);
		 graphics.DrawLine(&blackPen, Point(fpt.X,fpt.Y), Point(tpt.X,tpt.Y));
		 //pDC->LineTo(tpt.X,tpt.Y);
		 fpt=tpt;
	}
	delete []AX;
	delete []AY;
	*/
	///*
	long pCount=ls->getNumPoints(); 
	if(pCount<2) return;
	DBPoint fpt,tpt;
	double*AX=new double[pCount];
    double*AY=new double[pCount];
    for(long p=0;p<pCount;p++)
	{ 
        AX[p]=ls->getX(p);
	    AY[p]=ls->getY(p);
	}
    if(poCT!=NULL) poCT->Transform(pCount,AX,AY);
	fpt.X=AX[0];
	fpt.Y=AY[0];
	fpt=mp->MapToClient(fpt);
	pDC->MoveTo(fpt.X,fpt.Y);
	for(long p=1;p<pCount;p++)
	{
		 tpt.X=AX[p];
		 tpt.Y=AY[p];
		 tpt=mp->MapToClient(tpt);
		 pDC->LineTo(tpt.X,tpt.Y);
		 fpt=tpt;
	}
	delete []AX;
	delete []AY;
	//*/
}
void CPolylineLayerPainter::DrawMultiLineString(OGRMultiLineString*mls,CDC*pDC,CMapPosition*mp,OGRCoordinateTransformation*poCT)
{
    long Count=mls->getNumGeometries();
	long pCount=0;
	long num;
	OGRLineString*ls;
	for(int k=0;k<Count;k++)
	{
        ls=(OGRLineString*)mls->getGeometryRef(k);
	    pCount+=ls->getNumPoints();
	}
	DBPoint fpt,tpt;
	double*AX=new double[pCount];
    double*AY=new double[pCount];
	pCount=0;
    for(int k=0;k<Count;k++)
	{
        ls=(OGRLineString*)mls->getGeometryRef(k);
        num=ls->getNumPoints();
		for(long p=0;p<num;p++)
		{ 
			AX[pCount]=ls->getX(p);
			AY[pCount]=ls->getY(p);
			pCount++;
		}
	}
    if(poCT!=NULL) poCT->Transform(pCount,AX,AY);
    pCount=0;
    for(int k=0;k<Count;k++)
	{
        ls=(OGRLineString*)mls->getGeometryRef(k);
		fpt.X=AX[pCount];
	    fpt.Y=AY[pCount];
		fpt=mp->MapToClient(fpt);
	    pDC->MoveTo(fpt.X,fpt.Y);
		pCount++;
		num=ls->getNumPoints();
		for(long p=1;p<num;p++)
		{ 
			tpt.X=AX[pCount];
		    tpt.Y=AY[pCount];
            tpt=mp->MapToClient(tpt);
		    pDC->LineTo(tpt.X,tpt.Y);
		    fpt=tpt;
			pCount++;
		}
	}
	delete []AX;
	delete []AY;
}
bool CPolylineLayerPainter::Draw(HDC hDC,CMapPosition*mp)
{
	CVectorReader*pReader=((CVectorLayer*)pRefLayer)->GetVectorReader();
	if(pReader==NULL) return false;
	CPen pPen,*oldpen;
	CDC*pDC=CDC::FromHandle(hDC);
    pPen.CreatePen(0,Size,LineColor);
	oldpen=pDC->SelectObject(&pPen);
    DRect rt=mp->GetExtentRect();
	pReader->SetSpatialFilterRect(rt.Left,rt.Bottom,rt.Right,rt.Top);
	//long Count;
	//pReader->GetFeatureCount(Count);
	OGRGeometry*gr;
	OGRLineString*ls;
    OGRMultiLineString*mls;
	OGRPoint*dpt;
	OGRCoordinateTransformation*poCT=NULL;
	if((pRefLayer->GetSpatialReference()!=NULL)&&(pRefLayer->GetLayers()->GetSpatialReference()!=NULL))
	{
		poCT=OGRCreateCoordinateTransformation(pRefLayer->GetSpatialReference(),pRefLayer->GetLayers()->GetSpatialReference());
	}
	int AllCount=0;
    while(pReader->MoveNext())
	{
        gr=pReader->GetCurrentOrginFeatureShape();
        OGRwkbGeometryType type=gr->getGeometryType();
		if(gr->getGeometryType()==wkbLineString)
		{
			ls=(OGRLineString*)gr;
			if(ls==NULL) continue;
			DrawLineString(ls,pDC,mp,poCT);
		}
		else
		{
            mls=(OGRMultiLineString*)gr;
			if(mls==NULL) continue;
			DrawMultiLineString(mls,pDC,mp,poCT);
		}
	}
	pDC->SelectObject(oldpen);
	if(poCT!=NULL) delete poCT;
	return true;
}
void CPolygonLayerPainter::SetDrawEnvi(COLORREF Color)
{
	PolyColor=Color;
}
void CPolygonLayerPainter::DrawPoly(OGRPolygon*poly,CDC*pDC,CMapPosition*mp,OGRCoordinateTransformation*poCT)
{
	OGRLinearRing*ring=poly->getExteriorRing();
	if(ring==NULL) return;
	int Count=poly->getNumInteriorRings()+1;
	int AllCount=0;
	int*Counts=new int[Count];
	OGRLineString*ls=(OGRLineString*)ring;
	Counts[0]=ls->getNumPoints();
	AllCount=Counts[0];
    for(int k=0;k<Count-1;k++)
	{
        AllCount+=poly->getInteriorRing(k)->getNumPoints();
	}
	double*AX=new double[AllCount];
	double*AY=new double[AllCount];
    AllCount=0;
	DBPoint dpt;
	for(long p=0;p<Counts[0];p++)
	{
		 AX[p]=ls->getX(p);
		 AY[p]=ls->getY(p);
		 AllCount++;
	}
	for(int k=0;k<Count-1;k++)
	{
        ring=poly->getInteriorRing(k);
        OGRLineString*ls=(OGRLineString*)ring;
		Counts[k+1]=ls->getNumPoints();
		for(int p=0;p<Counts[k+1];p++)
		{
             AX[AllCount]=ls->getX(p);
			 AY[AllCount]=ls->getY(p);
			 AllCount++;
		}
	}
	if(poCT!=NULL) poCT->Transform(AllCount,AX,AY);
	CPoint*points=new CPoint[AllCount];
	AllCount=0;
	for(long p=0;p<Counts[0];p++)
	{
		 dpt.X=AX[p];
		 dpt.Y=AY[p];
		 dpt=mp->MapToClient(dpt);
		 points[AllCount]=CPoint(dpt.X,dpt.Y);
		 AllCount++;
	}
    for(int k=0;k<Count-1;k++)
	{
        ring=poly->getInteriorRing(k);
        OGRLineString*ls=(OGRLineString*)ring;
		Counts[k+1]=ls->getNumPoints();
		for(int p=0;p<Counts[k+1];p++)
		{
             dpt.X=AX[AllCount];
			 dpt.Y=AY[AllCount];
			 dpt=mp->MapToClient(dpt);
			 points[AllCount]=CPoint(dpt.X,dpt.Y);
			 AllCount++;
		}
	}
	pDC->PolyPolygon(points,Counts,Count);
	delete []Counts;
	delete []points;
	delete []AX;
	delete []AY;
}
bool CPolygonLayerPainter::Draw(HDC hDC,CMapPosition*mp)
{
	CVectorReader*pReader=((CVectorLayer*)pRefLayer)->GetVectorReader();
	if(pReader==NULL) return false;
	CPen*oldpen,pPen;
	pPen.CreatePen(0,1,RGB(0,255,0));
	CBrush pBrush,*oldbrush;
	CDC*pDC=CDC::FromHandle(hDC);
	oldpen=pDC->SelectObject(&pPen);
	pBrush.CreateSolidBrush(PolyColor);
	oldbrush=pDC->SelectObject(&pBrush);
    DRect rt=mp->GetExtentRect();
	CSpatialRefTrans pTrans;
	rt=pTrans.TransformRect(pRefLayer->GetLayers()->GetSpatialReference(),pRefLayer->GetSpatialReference(),rt);
	pReader->SetSpatialFilterRect(rt.Left,rt.Bottom,rt.Right,rt.Top);
	long Count;
	pReader->GetFeatureCount(Count);
	OGRGeometry*gr;
    OGRPolygon*ls;
    OGRMultiPolygon*mls;
	pReader->MoveNext();
	OGRCoordinateTransformation*poCT=NULL;
	if((pRefLayer->GetSpatialReference()!=NULL)&&(pRefLayer->GetLayers()->GetSpatialReference()!=NULL))
	{
		poCT=OGRCreateCoordinateTransformation(pRefLayer->GetSpatialReference(),pRefLayer->GetLayers()->GetSpatialReference());
	}
    for(long k=0;k<Count;k++)
	{
        gr=pReader->GetCurrentOrginFeatureShape();
        OGRwkbGeometryType type=gr->getGeometryType();
		if(gr->getGeometryType()==wkbPolygon)
		{
			ls=(OGRPolygon*)gr;
			if(ls==NULL) continue;
			DrawPoly(ls,pDC,mp,poCT);
		}
		else
		{
            mls=(OGRMultiPolygon*)gr;
			if(mls==NULL) continue;
			long pCount=mls->getNumGeometries(); 
            for(long l=0;l<pCount;l++)
			{
                ls=(OGRPolygon*)mls->getGeometryRef(l);
				DrawPoly(ls,pDC,mp,poCT);
			}
		}
		pReader->MoveNext();
	}
	pDC->SelectObject(oldpen);
    pDC->SelectObject(oldbrush);
	if(poCT!=NULL) delete poCT;
	return true;
}
void CLayerPainterManager::CreateNewPainter(CLayer*pLayer)
{
	switch(pLayer->GetLayerType())
	{
	case GrayRasterLayer:
		pPainter=new CGrayRasterLayerPainter(pLayer);
		break;
	case RGBRasterLayer:
        pPainter=new CRGBRasterLayerPainter(pLayer);
		break;
	case VectorLayer:
		{
            GeometryType type=((CVectorLayer*)pLayer)->GetShapeType();
			switch(type)
			{
			case gPoint:
                 pPainter=new CPointLayerPainter(pLayer);
				 break;
			case gPolyline:
                 pPainter=new CPolylineLayerPainter(pLayer);
				 break;
			case gPolygon:
			case gMultiPolygon:
				 pPainter=new CPolygonLayerPainter(pLayer);
				 break;
			}
			break;
		}
	}  
}
bool CLayerPainterManager::Draw(HDC hDC,CMapPosition*mp)
{
    return pPainter->Draw(hDC,mp);
}
