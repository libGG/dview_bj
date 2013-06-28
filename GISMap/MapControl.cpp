//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A1C5E3003E.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A1C5E3003E.cm

//## begin module%40A1C5E3003E.cp preserve=no
//## end module%40A1C5E3003E.cp

//## Module: MapControl%40A1C5E3003E; Pseudo Package body
//## Source file: E:\egisdevelop\code\mapcontrol\MapControl.cpp

//## begin module%40A1C5E3003E.additionalIncludes preserve=no
//## end module%40A1C5E3003E.additionalIncludes

//## begin module%40A1C5E3003E.includes preserve=yes
#include "stdafx.h"
#include "GISMap.h"
//## end module%40A1C5E3003E.includes

#include "MapControl.h"
//## begin module%40A1C5E3003E.additionalDeclarations preserve=yes
#include "math.h"
#include "IRender.h"
#include "MapLayer.h"
#include "MapProperty.h"
#include "CViewCtrlMouseListener.h"
//## end module%40A1C5E3003E.additionalDeclarations
// Class MapControl 



MapControl::MapControl()
//## begin MapControl::MapControl%40A1C5E3003E_const.hasinit preserve=no
//## end MapControl::MapControl%40A1C5E3003E_const.hasinit
//## begin MapControl::MapControl%40A1C5E3003E_const.initialization preserve=yes
//## end MapControl::MapControl%40A1C5E3003E_const.initialization
{
	//## begin MapControl::MapControl%40A1C5E3003E_const.body preserve=yes
	m_pPaintBuffer = m_pMapBuffer = 0 ;
	clientWidth = clientHeight = 0 ;
	dataX = dataY = dataWidth = dataHeight = 0;
	worldX = worldY = worldWidth = worldHeight = 0;

	m_pOwnerWindowDrawingPos = new CPoint(0,0);

	m_pOwnerView = 0 ;
	this->m_pMapBuffer = 0 ;
	this->m_pPaintBuffer = 0 ;
	layers = new Layers();

	this->m_pMouseListeners = new CMouseListeners();
	this->m_pMouseListeners->AddMouseListener(EMAP_TOOL_MAPVIEW_CONTROLLER, new CViewCtrlMouseListener() );
	//## end MapControl::MapControl%40A1C5E3003E_const.body
}


MapControl::~MapControl()
{
	//## begin MapControl::~MapControl%40A1C5E3003E_dest.body preserve=yes
	if ( m_pPaintBuffer != 0 )
	{
		delete m_pPaintBuffer;
		this->m_pPaintBuffer = 0;
	}

	if ( m_pMapBuffer != 0 )
	{
		delete m_pMapBuffer;
		this->m_pMapBuffer = 0;
	}

	if ( m_pOwnerWindowDrawingPos != 0 )
	{
		delete m_pOwnerWindowDrawingPos;
		m_pOwnerWindowDrawingPos = 0 ;
	}

	if ( layers != 0 )
	{
		delete layers ;
		layers = 0 ;
	}

	if ( this->m_pMouseListeners != 0 )
	{
		delete this->m_pMouseListeners;
		this->m_pMouseListeners = 0 ;
	}
	//## end MapControl::~MapControl%40A1C5E3003E_dest.body
}

void MapControl::SetOwnerView (CView* pView)
{
	//## begin CMAP_View::SetOwnerWindow%3DAA2F4702A8.body preserve=yes
	if ( pView == 0 )	return ;

	this ->m_pOwnerView = pView ;
	//## end CMAP_View::SetOwnerWindow%3DAA2F4702A8.body
}

CView* MapControl::GetOwnerView ()
{
	//## begin CMAP_View::GetOwnerWindow%3DB8B3CF03D5.body preserve=yes
	return m_pOwnerView ;
	//## end CMAP_View::GetOwnerWindow%3DB8B3CF03D5.body
}

void MapControl::GetViewBound ( int& x, int& y, int& w, int& h )
{
	x = 0 ;
	y = 0 ;
	w = clientWidth ;
	h = clientHeight ;
}

void MapControl::SetViewBound ( int x, int y, int w, int h )
{
	if ( clientWidth == w && clientHeight == h || m_pOwnerView == 0 )
		return ;
	TRACE("x:%d y:%d w:%d h:%d \n",x,y,w,h);
	// 处理worldBound begin
	// 确保客户区大小改变后地图不变形
	double offset_width = 0;
	double offset_height = 0;
	double originx = 0, originy = 0, destx = 0, desty = 0;
	if (clientWidth != 0 && clientHeight != 0)
	{
		ClientToWorld(originx,originy);
		destx = w - clientWidth;
		desty = h - clientHeight;
		ClientToWorld(destx,desty);
		offset_width = destx - originx;
		offset_height = desty - originy;
	}
	worldWidth += offset_width;
	worldHeight -= offset_height;
	// 处理worldBound end

	clientWidth = w ;
	clientHeight = h ;
	// 创建OffScreen对象
	if ( m_pPaintBuffer != 0 ) 
	{
		delete m_pPaintBuffer;
		m_pPaintBuffer = 0 ;
	}
	if ( m_pMapBuffer != 0 )
	{
		delete m_pMapBuffer;
		m_pMapBuffer = 0 ;
	}

	CDC *pDC = this->m_pOwnerView->GetDC();

	m_pPaintBuffer = new CBitmap();
	m_pPaintBuffer->CreateCompatibleBitmap(pDC,clientWidth,clientHeight) ;

	m_pMapBuffer = new CBitmap();
	m_pMapBuffer->CreateCompatibleBitmap(pDC,clientWidth,clientHeight) ;

	this->m_pOwnerView->ReleaseDC( pDC );
	pDC = 0 ;

	this->ReDraw(x,y,w,h);
}

void MapControl::GetDataBound (double& x, double& y, double& w, double& h)
{
	//## begin MapControl::GetDataBound%40AC5E3400FA.body preserve=yes
	x = dataX ;
	y = dataY ;
	w = dataWidth ;
	h = dataHeight ;
	//## end MapControl::GetDataBound%40AC5E3400FA.body
}

void MapControl::GetWorldBound (double& x, double& y, double& w, double& h)
{
	//## begin MapControl::GetWorldBound%40A1C5E30042.body preserve=yes
	x = worldX ;
	y = worldY ;
	w = worldWidth ;
	h = worldHeight ;
	//## end MapControl::GetWorldBound%40A1C5E30042.body
}

Layers& MapControl::GetLayers ()
{
	//## begin MapControl::GetLayers%40A1C5E30046.body preserve=yes
	return *layers ;
	//## end MapControl::GetLayers%40A1C5E30046.body
}


CMouseListeners& MapControl::GetMouseListeners()
{
	return *m_pMouseListeners;
}

void MapControl::ClientToWorld (double& x, double& y)
{
	//## begin MapControl::ClientToWorld%40A1C5E30047.body preserve=yes
	double x_scale = 1.0 * x / clientWidth;
	double y_scale = 1.0 * y / clientHeight;

	x = worldX + x_scale * worldWidth;
	y = worldY - y_scale * worldHeight;
	//## end MapControl::ClientToWorld%40A1C5E30047.body
}

void MapControl::WorldToClient (double& x, double& y)
{
	//## begin MapControl::WorldToClient%40A1C5E30049.body preserve=yes
	double x_scale = 1.0 * (x - worldX) / worldWidth;
	double y_scale = 1.0 * (y - worldY) / worldHeight;

	x = x_scale * clientWidth;
	y = -y_scale * clientHeight;
	//## end MapControl::WorldToClient%40A1C5E30049.body
}

void MapControl::SetWorldBound (double x, double y, double w, double h)
{
	//## begin MapControl::SetWorldBound%40A1C5E3004D.body preserve=yes
	worldX = x ;
	worldY = y ;
	worldWidth = w ;
	worldHeight = h ;
	//## end MapControl::SetWorldBound%40A1C5E3004D.body
}

void MapControl::Reset ()
{
	//## begin MapControl::Reset%40A1C5E30053.body preserve=yes
	// 处理worldBound
	// 整个地图的大小
	// 从Layers对象中计算dataX,dataY,dataWidth,dataHeight的大小
	// Added the code here!!!!
	double x, y ,w , h ;
	bool isfirst = true ;
	int layercount = layers->Count();
	for ( int i = 0 ; i < layercount ; i ++ )
	{
		ILayer *pLayer = layers ->GetLayer(i);
		pLayer ->GetBound(x,y,w,h);
		if ( isfirst )
		{
			dataX = x; dataY = y;
			dataWidth = w; dataHeight = h ;
			isfirst = false ;
		}
		else
		{
			if ( x < dataX ) dataX = x; 
			if ( y < dataY ) dataY = y ;
			if ( x + w > dataX + dataWidth )	dataWidth = x + w - dataX ;
			if ( y + h > dataY + dataHeight )	dataHeight = y + h - dataY ;
		}
	}

	// Notice:地理坐标系为!!!
	//   A y
	//   |
	// --+------->x
	//   |
	worldX = dataX;
	worldY = dataY;
	worldWidth = dataWidth;
	worldHeight = dataHeight;
	// Notice:屏幕坐标系为!!!
	//   |
	// --+------->x
	//   |
	//   V y
	worldY = worldY + worldHeight;
	double world_scale = 1.0 * worldWidth / worldHeight;
	double client_scale = 1.0 * clientWidth / clientHeight;
	if (world_scale > client_scale)
	{
		double height = worldWidth / client_scale;
		double y = worldY + (height - worldHeight) / 2.0;
		worldY = y ;
		worldHeight = height ;
	}
	else if (world_scale < client_scale)
	{
		double width = worldHeight * client_scale;
		double x = worldX - (width - worldWidth) / 2.0;
		worldX = x ;
		worldWidth = width ;
	}
	//## end MapControl::Reset%40A1C5E30053.body
}

void MapControl::ClearBuffer( CDC *pDC, int x, int y, int w, int h )
{
	CRect rect;
	rect.SetRect(x,y,x+w,y+h);
	CBrush brush ;
	brush.CreateSolidBrush(RGB(255,255,255));
	pDC->FillRect(&rect,&brush);
	brush.DeleteObject();
}

void MapControl::ReDraw (int x, int y, int w, int h)
{
	//## begin MapControl::ReDraw%40A1C5E30054.body preserve=yes
	if ( w == 0 || h == 0 ) return ;

	// 地图可视范围示意图
	// (x,y)            (0,0)
	//   +-----+          +-----+
	//   |     |h   ==>   |     |h
	//   +--w--+          +--w--+
	//   ~view~           ~Image~
	MapProperty mapProperty(this);
	mapProperty.SetClipRect(x,y,w,h);

	CDC *pDC = this->m_pOwnerView->GetDC();
	CDC mapBufferDC ;
	mapBufferDC.CreateCompatibleDC( pDC );
	CBitmap *pPreMapBitmap = (CBitmap*)mapBufferDC.SelectObject(m_pMapBuffer);
	ClearBuffer(&mapBufferDC,x,y,w,h);

	CRect clip_rect ;
	CRgn /*preRgn,*/ newRgn;
	newRgn.CreateRectRgn( x,y,x+w,y+h);
	TRACE("地图绘制区域：%d, %d, %d, %d\n",x,y,x+w,y+h);
	mapBufferDC.GetClipBox(&clip_rect) ;// 获得要刷新的区域，即无效区
	TRACE("窗口无效区域：%d, %d, %d, %d\n",clip_rect.left,clip_rect.top,clip_rect.right,clip_rect.bottom);
	mapBufferDC.SelectClipRgn( &newRgn );// 设置即将刷新的区域
	newRgn.DeleteObject();// 在DC中把区域设置后，把区域对象(gdi对象)删除，释放资源
	int layerCount = layers->Count();
	for (int i = 0; i < layerCount; i++)
	{
		ILayer *pLayer = layers->GetLayer(i);
		LayerProperty &layerProperty = pLayer->GetProperty();
		pLayer->GetRender().Render(&mapBufferDC,&mapProperty);
	}
	//preRgn.CreateRectRgnIndirect(&clip_rect);
	//preRgn.DeleteObject();

	CDC paintBufferDC ;
	paintBufferDC.CreateCompatibleDC( pDC );
	CBitmap *pPrePaintBitmap = (CBitmap*)paintBufferDC.SelectObject(m_pPaintBuffer);
	//Map ----> Paint
	paintBufferDC.BitBlt(x,y,w,h,&mapBufferDC,x,y,SRCCOPY);
	//Map ----> Paint 
	paintBufferDC.SelectObject( pPrePaintBitmap );
	paintBufferDC.DeleteDC();
	pPrePaintBitmap = 0 ;

	mapBufferDC.SelectObject(pPreMapBitmap);
	mapBufferDC.DeleteDC();
	pPreMapBitmap = 0;

	this->m_pOwnerView->ReleaseDC(pDC);
	//## end MapControl::ReDraw%40A1C5E30054.body
}

CPoint* MapControl::GetOwnerWindowDrawingPos()
{
	return m_pOwnerWindowDrawingPos;
}

void MapControl::DrawMap ()
{
	//## begin MapControl::DrawMap%40AC7D5C03A9.body preserve=yes
	if ( m_pPaintBuffer == 0 )  return ;
	CDC *pDC = this->m_pOwnerView->GetDC();
	CDC tempDC ;
	tempDC.CreateCompatibleDC(pDC);
	CBitmap *preBitmap = (CBitmap*)tempDC.SelectObject(m_pPaintBuffer);
	pDC ->BitBlt(m_pOwnerWindowDrawingPos->x,m_pOwnerWindowDrawingPos->y,clientWidth,clientHeight,&tempDC,0,0,SRCCOPY);
	tempDC.SelectObject(preBitmap);
	tempDC.DeleteDC();
	this->m_pOwnerView->ReleaseDC(pDC);
	//## end MapControl::DrawMap%40AC7D5C03A9.body
}

void MapControl::Refresh ()
{
	//## begin MapControl::Refresh%40A1C5E3005B.body preserve=yes
	if ( m_pPaintBuffer == 0 )  return ;

	CDC *pDC = this->m_pOwnerView->GetDC();
	CDC tempDC ;
	tempDC.CreateCompatibleDC(pDC);
	CBitmap *preBitmap = (CBitmap*)tempDC.SelectObject(m_pPaintBuffer);
	pDC ->BitBlt(0,0,clientWidth,clientHeight,&tempDC,0,0,SRCCOPY);
	tempDC.SelectObject(preBitmap);
	tempDC.DeleteDC();
	this->m_pOwnerView->ReleaseDC(pDC);
	//## end MapControl::Refresh%40A1C5E3005B.body
}

void MapControl::ZoomIn (int x, int y, int w, int h)
{
	//## begin MapControl::ZoomIn%40A1C5E3005C.body preserve=yes
	int i, centrex, centrey;
	centrex = x + w / 2;
	centrey = y + h / 2;
	if ( w < 5 || h < 5 )
	{
		w = clientWidth / 2;
		h = clientHeight / 2;
		x = centrex - w / 2;
		y = centrey - h / 2;
	}
	double scale = 1.0 * worldWidth / worldHeight;

	//世界坐标中的左上角点，右下角点
	double wleft, wtop, wright, wbottom, wcenterx, wcentery;
	wleft = x; wtop = y ;
	ClientToWorld( wleft, wtop );
	wright = x + w; wbottom = y + h;
	ClientToWorld( wright, wbottom );

	double width = fabs(wright - wleft);
	double height = fabs(wbottom - wtop);

	if ( (1.0 * width / height) > scale)
		height = width / scale;
	else
		width = height * scale;

	wcenterx = centrex; wcentery = centrey;
	ClientToWorld( wcenterx, wcentery );

	worldX = wcenterx - width / 2;
	worldY = wcentery + height / 2;
	worldWidth = width;
	worldHeight = height;

	ReDraw(0,0,clientWidth,clientHeight);
	//## end MapControl::ZoomIn%40A1C5E3005C.body
}

void MapControl::ZoomOut (int x, int y, int w, int h)
{
	//## begin MapControl::ZoomOut%40A1C5E3005E.body preserve=yes
	double scale = 2.0;
	int i, centrex, centrey;
	centrex = x + w / 2;
	centrey = y + h / 2;

	//世界坐标中的左上角点，右下角点
	double wleft, wtop, wright, wbottom, wcenterx, wcentery;
	wleft = x; wtop = y ;
	ClientToWorld( wleft, wtop );
	wright = x + w; wbottom = y + h;
	ClientToWorld( wright, wbottom );

	double width = fabs(wright - wleft);
	double height = fabs(wbottom - wtop);

	if (w > 5 && h > 5)
	{
		double scaleX, scaleY;
		scaleX = worldWidth / width;
		scaleY = worldHeight / height;

		if (scaleX > scaleY)
			scale = scaleX;
		else
			scale = scaleY;
	}

	width = scale * worldWidth;
	height = scale * worldHeight;
	wcenterx = centrex; wcentery = centrey;
	ClientToWorld( wcenterx, wcentery );

	worldX = wcenterx - width / 2;
	worldY = wcentery + height / 2;
	worldWidth = width;
	worldHeight = height;

	ReDraw(0,0,clientWidth,clientHeight);
	//## end MapControl::ZoomOut%40A1C5E3005E.body
}

void MapControl::Scroll (int dx, int dy)
{
	//## begin MapControl::Scroll%40A1C5E30060.body preserve=yes
	if ( this->m_pPaintBuffer == 0 )   return;

	double x0 = 0, y0 = 0, x1 = dx, y1 = dy;
	ClientToWorld(x0, y0);    
	ClientToWorld(x1, y1);

	double offset_x = x1 - x0;
	double offset_y = y1 - y0;

	worldX -= offset_x;
	worldY -= offset_y;

	CDC *pDC = this->m_pOwnerView->GetDC();
	CDC mapBufferDC, paintBufferDC ;
	mapBufferDC.CreateCompatibleDC( pDC );
	paintBufferDC.CreateCompatibleDC( pDC );
	CBitmap *pPrePaintBitmap = (CBitmap*)paintBufferDC.SelectObject(m_pPaintBuffer);
	CBitmap *pPreMapBitmap = (CBitmap*)mapBufferDC.SelectObject(m_pMapBuffer);

	// 填补空白 begin
	int invalidatex1, invalidatey1, invalidatew1, invalidateh1;
	int invalidatex2, invalidatey2, invalidatew2, invalidateh2;
	if (dx >= 0)
	{
		if (dy >= 0)
		{
			paintBufferDC.BitBlt(dx,dy,clientWidth-dx,clientHeight-dy,&mapBufferDC,0,0,SRCCOPY);
			//(m_pPaintBuffer,dx,dy,clientWidth-dx,clientHeight-dy,m_pMapBuffer,0,0);		  
			invalidatex1 = invalidatey1 = 0 ;
			invalidatew1 = clientWidth, invalidateh1 = dy ;
			invalidatex2 = 0, invalidatey2 = dy ;
			invalidatew2 = dx, invalidateh2 = clientHeight - dy ;
		}
		else
		{
			paintBufferDC.BitBlt(dx,0,clientWidth-dx,clientHeight+dy,&mapBufferDC,0,-dy,SRCCOPY);
			//(m_pPaintBuffer,dx,0,clientWidth-dx,clientHeight+dy,m_pMapBuffer,0,-dy);
			invalidatex1 = invalidatey1 = 0 ;
			invalidatew1 = dx, invalidateh1 = clientHeight + dy ;
			invalidatex2 = 0, invalidatey2 = clientHeight + dy ;
			invalidatew2 = clientWidth, invalidateh2 = -dy ;
		}
	}
	else
	{
		if (dy >= 0)
		{
			paintBufferDC.BitBlt(0,dy,clientWidth+dx,clientHeight-dy,&mapBufferDC,-dx,0,SRCCOPY);
			//(m_pPaintBuffer,0,dy,clientWidth+dx,clientHeight-dy,m_pMapBuffer,-dx,0);
			invalidatex1 = invalidatey1 = 0 ;
			invalidatew1 = clientWidth, invalidateh1 = dy ;
			invalidatex2 = clientWidth + dx, invalidatey2 = dy ;
			invalidatew2 = -dx, invalidateh2 = clientHeight - dy ;
		}
		else
		{
			paintBufferDC.BitBlt(0,0,clientWidth+dx,clientHeight+dy,&mapBufferDC,-dx,-dy,SRCCOPY);
			//(m_pPaintBuffer,0,0,clientWidth+dx,clientHeight+dy,m_pMapBuffer,-dx,-dy);
			invalidatex1 = clientWidth + dx, invalidatey1 = 0 ;
			invalidatew1 = -dx, invalidateh1 = clientHeight + dy ;
			invalidatex2 = 0, invalidatey2 = clientHeight + dy ;
			invalidatew2 = clientWidth, invalidateh2 = -dy ;
		}
	}
	mapBufferDC.BitBlt(0,0,clientWidth,clientHeight,&paintBufferDC,0,0,SRCCOPY);
	//(m_pMapBuffer,0,0,clientWidth,clientHeight,m_pPaintBuffer,0,0);
	paintBufferDC.SelectObject( pPrePaintBitmap );
	paintBufferDC.DeleteDC();
	pPrePaintBitmap = 0 ;
	mapBufferDC.SelectObject(pPreMapBitmap);
	mapBufferDC.DeleteDC();
	pPreMapBitmap = 0;
	this->m_pOwnerView->ReleaseDC(pDC);

	ReDraw(invalidatex1, invalidatey1, invalidatew1, invalidateh1);
	ReDraw(invalidatex2, invalidatey2, invalidatew2, invalidateh2);
	// 填补空白 end
	//## end MapControl::Scroll%40A1C5E30060.body
}

// Additional Declarations
//## begin MapControl%40A1C5E3003E.declarations preserve=yes
//## end MapControl%40A1C5E3003E.declarations
//## begin module%40A1C5E3003E.epilog preserve=yes

//## end module%40A1C5E3003E.epilog
