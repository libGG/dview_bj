//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40AD72380148.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40AD72380148.cm

//## begin module%40AD72380148.cp preserve=no
//## end module%40AD72380148.cp

//## Module: ShpRender%40AD72380148; Pseudo Package body
//## Source file: E:\egisdevelop\code\mapcontrol\ShpRender.cpp

//## begin module%40AD72380148.additionalIncludes preserve=no
//## end module%40AD72380148.additionalIncludes

//## begin module%40AD72380148.includes preserve=yes
//## end module%40AD72380148.includes
#include "stdafx.h"
#include "GISMap.h"
#include "ShpRender.h"
//## begin module%40AD72380148.additionalDeclarations preserve=yes
#include "math.h"
#include "MapLayer.h"
#include "MapProperty.h"
#include "LayerProperty.h"
#include "featureclass.h"
#include "feature.h"
#include "geopolyline.h"
#include "geopolygon.h"
//## end module%40AD72380148.additionalDeclarations
// Class ShpRender 


ShpRender::ShpRender (MapLayer* pLayer)
//## begin ShpRender::ShpRender%40AD74640251.hasinit preserve=no
//## end ShpRender::ShpRender%40AD74640251.hasinit
//## begin ShpRender::ShpRender%40AD74640251.initialization preserve=yes
//## end ShpRender::ShpRender%40AD74640251.initialization
{
	//## begin ShpRender::ShpRender%40AD74640251.body preserve=yes
	this ->m_pLayer = pLayer ;
	//## end ShpRender::ShpRender%40AD74640251.body
}


ShpRender::~ShpRender()
{
	//## begin ShpRender::~ShpRender%40AD72380148_dest.body preserve=yes
	this ->m_pLayer = 0 ;
	//## end ShpRender::~ShpRender%40AD72380148_dest.body
}

//## Other Operations (implementation)
void ShpRender::Render (CDC *pDC, MapProperty* pMapProperty)
{
	//## begin ShpRender::Render%40AD729501E4.body preserve=yes
	int i, x, y, w, h ;
	double x0, y0, x1, y1;
	double clipL, clipT, clipR, clipB ; // 地理坐标
	double intersectL, intersectT, intersectR, intersectB ; // 相交的矩形
	double xs[4], ys[4];
	//CPoint pointarray[ 500 ];
	pMapProperty->GetClipRect(x,y,w,h);	
	xs[0] = x ; ys[0] = y ;
	xs[1] = x ; ys[1] = y+h ;
	xs[2] = x+w ; ys[2] = y ;
	xs[3] = x+w ; ys[3] = y+h ;
	// (地理坐标系)
	for ( i = 0; i < 4; i ++ )
		pMapProperty->ClientToWorld(xs[i],ys[i]);

	clipL = clipR = xs[0];
	clipB = clipT = ys[0];
	for ( i = 1; i < 4; i ++ )// 计算在视图矩形中显示的地图范围
	{
		if ( clipL > xs[i] ) clipL = xs[i];// 左上角X坐标
		if ( clipR < xs[i] ) clipR = xs[i];// 左上角Y坐标
		if ( clipB > ys[i] ) clipB = ys[i];// 右下角角X坐标
		if ( clipT < ys[i] ) clipT = ys[i];// 右下角Y坐标
	}

	Feature			*pfeature;
	int	pointscount, pointcount, index ;
	LayerProperty &layerproperty = m_pLayer ->GetProperty();
	FeatureClass &featureClass = (FeatureClass&)layerproperty.GetRelateDataSet();
#pragma region 绘制点
	if ( featureClass.GetType() == POINTDATASET )
	{
		for( pfeature = featureClass.GetFirstFeature(); pfeature != NULL; pfeature = featureClass.GetNextFeature() )
		{
			pfeature ->GetBound(x0, y0, x1, y1);

			// 增加判断以提高显示速度
			intersectL = max(clipL,x0);
			intersectR = min(clipR,x0+x1);
			intersectB = max(clipB,y0);
			intersectT = min(clipT,y0+y1);
			if ( intersectL - intersectR >= 1e-8 || intersectB - intersectT >= 1e-8 )
				continue ;

			GeoPoint &point = (GeoPoint&)pfeature ->GetGeometry();
			x0 = point.GetX();
			y0 = point.GetY();
			pMapProperty->WorldToClient(x0,y0);
			//pDC->Ellipse(x0-2,y0-2,x0+2,y0+2);
			pDC->Ellipse(x0-5,y0-5,x0+5,y0+5);
		}
	}
#pragma endregion
	else if ( featureClass.GetType() == LINEDATASET )
	{
		CPen newPen, *pPrePen;
		newPen.CreatePen(0,1,RGB(0,0,200) );
		pPrePen = pDC->SelectObject( &newPen );
		for( pfeature = featureClass.GetFirstFeature(); pfeature != NULL; pfeature = featureClass.GetNextFeature() )
		{
			pfeature ->GetBound(x0, y0, x1, y1);

			// 增加判断以提高显示速度
			intersectL = max(clipL,x0);
			intersectR = min(clipR,x0+x1);
			intersectB = max(clipB,y0);
			intersectT = min(clipT,y0+y1);
			if ( intersectL > intersectR || intersectB > intersectT )
				continue ;

			GeoPolyline &polyline = (GeoPolyline&)pfeature ->GetGeometry();
			pointscount = polyline.GetPointsCount();
			for ( index = 0; index < pointscount; index ++ )
			{
				GeoPoints &points = polyline.GetPoints(index);
				pointcount = points.GetPtCount();
				for ( i = 0; i < pointcount - 1; i ++ )
				{
					points.GetPoint(i,x0,y0);
					points.GetPoint(i+1,x1,y1);
					pMapProperty->WorldToClient(x0,y0);
					pMapProperty->WorldToClient(x1,y1);
					pDC->MoveTo( x0, y0 );
					pDC->LineTo( x1, y1 );
				}
			}
		}
		pDC->SelectObject(pPrePen);
		newPen.DeleteObject();
		pPrePen = 0 ;
	}
	else if ( featureClass.GetType() == POLYGONDATASET )
	{
		CPen newPen, *pPrePen;
		newPen.CreatePen(0,1,RGB(0,200,0) );
		pPrePen = pDC->SelectObject( &newPen );
		for( pfeature = featureClass.GetFirstFeature(); pfeature != NULL; pfeature = featureClass.GetNextFeature() )
		{
			pfeature ->GetBound(x0, y0, x1, y1);

			// 增加判断以提高显示速度
			intersectL = max(clipL,x0);
			intersectR = min(clipR,x0+x1);
			intersectB = max(clipB,y0);
			intersectT = min(clipT,y0+y1);
			if ( intersectL > intersectR || intersectB > intersectT )
				continue ;

			GeoPolygon &polygon = (GeoPolygon&)pfeature ->GetGeometry();
			pointscount = polygon.GetPointsCount();
			for ( index = 0; index < pointscount; index ++ )
			{
				GeoPoints &points = polygon.GetPoints(index);
				pointcount = points.GetPtCount();
				for ( i = 0; i < pointcount-1; i ++ )
				{
					points.GetPoint(i,x0,y0);
					points.GetPoint(i+1,x1,y1);
					pMapProperty->WorldToClient(x0,y0);
					pMapProperty->WorldToClient(x1,y1);
					pDC->MoveTo( x0, y0 );
					pDC->LineTo( x1, y1 );
				}
			}
		}
		pDC->SelectObject(pPrePen);
		newPen.DeleteObject();
		pPrePen = 0 ;
	}
	//## end ShpRender::Render%40AD729501E4.body
}

// Additional Declarations
//## begin ShpRender%40AD72380148.declarations preserve=yes
//## end ShpRender%40AD72380148.declarations

//## begin module%40AD72380148.epilog preserve=yes
//## end module%40AD72380148.epilog
