// GISMapView.cpp : implementation of the CGISMapView class
//

#include "stdafx.h"
#include "GISMap.h"

#include "GISMapDoc.h"
#include "GISMapView.h"

#include "MapControl.h"
#include "MapLayer.h"
#include "ShpRender.h"
#include "CMouseEvent.h"

#include "DataSource.h"
#include "FeatureClass.h"
#include "LayerProperty.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CGISMapView

IMPLEMENT_DYNCREATE(CGISMapView, CView)

BEGIN_MESSAGE_MAP(CGISMapView, CView)
	//{{AFX_MSG_MAP(CGISMapView)
	ON_WM_LBUTTONDOWN()
	ON_WM_MOUSEMOVE()
	ON_WM_LBUTTONUP()
	ON_COMMAND(GISMAP_PAN, OnPan)
	ON_COMMAND(GISMAP_ZOOMIN, OnZoomin)
	ON_COMMAND(GISMAP_ZOOMOUT, OnZoomout)
	ON_COMMAND(GISMAP_RESET, OnReset)
	ON_COMMAND(ID_FILE_OPEN, OnFileOpen)
	//}}AFX_MSG_MAP
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, CView::OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CGISMapView construction/destruction

CGISMapView::CGISMapView()
{
	// TODO: add construction code here
	m_pMapControl = new MapControl ;
}

CGISMapView::~CGISMapView()
{
	if ( m_pMapControl != 0 )
	{
		delete m_pMapControl ;
		m_pMapControl = 0 ;
	}
}

BOOL CGISMapView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CGISMapView drawing

void CGISMapView::OnDraw(CDC* pDC)
{
	CGISMapDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	// TODO: add draw code for native data here
	CRect clientRect;
	this->GetClientRect( &clientRect );
	if ( m_pMapControl == 0 ) return ;
	m_pMapControl->SetViewBound( clientRect.left,clientRect.top,clientRect.Width(), clientRect.Height() );
	m_pMapControl->DrawMap();
}

/////////////////////////////////////////////////////////////////////////////
// CGISMapView printing

BOOL CGISMapView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CGISMapView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CGISMapView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

/////////////////////////////////////////////////////////////////////////////
// CGISMapView diagnostics

#ifdef _DEBUG
void CGISMapView::AssertValid() const
{
	CView::AssertValid();
}

void CGISMapView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CGISMapDoc* CGISMapView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CGISMapDoc)));
	return (CGISMapDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CGISMapView message handlers
void CGISMapView::OnInitialUpdate() 
{
	CView::OnInitialUpdate();
	
	// TODO: Add your specialized code here and/or call the base class
	if ( m_pMapControl == 0 ) return ;
	m_pMapControl->SetOwnerView( this );
}

MapControl& CGISMapView::GetMapControl()
{
	return *m_pMapControl ;
}


void CGISMapView::OnLButtonDown(UINT nFlags, CPoint point) 
{
	// TODO: Add your message handler code here and/or call default
	this->SetCapture();
	CMouseListeners& mouselisteners = this->m_pMapControl->GetMouseListeners();
	IMouseListener *pMouseListener = mouselisteners.GetCurrentMouseListener();
	if ( pMouseListener != 0 )
	{
		CMouseEvent event( this->m_pMapControl, point, nFlags, 
				mouselisteners.GetCurrentSubMouseListenerKey() );
		pMouseListener->OnLButtonDown( & event );
	}
	CView::OnLButtonDown(nFlags, point);
}

void CGISMapView::OnMouseMove(UINT nFlags, CPoint point) 
{
	// TODO: Add your message handler code here and/or call default
	if ( (nFlags & MK_LBUTTON) != 0 )
	{
		CMouseListeners& mouselisteners = this->m_pMapControl->GetMouseListeners();
		IMouseListener *pMouseListener = mouselisteners.GetCurrentMouseListener();
		if ( pMouseListener != 0 )
		{
			CMouseEvent event( this->m_pMapControl, point, nFlags, 
					mouselisteners.GetCurrentSubMouseListenerKey() );
			pMouseListener->OnMouseDrag( & event );
		}
	}
	CView::OnMouseMove(nFlags, point);
}

void CGISMapView::OnLButtonUp(UINT nFlags, CPoint point) 
{
	// TODO: Add your message handler code here and/or call default
	if ( (nFlags & MK_LBUTTON) == 0 )
	{
		CMouseListeners& mouselisteners = this->m_pMapControl->GetMouseListeners();
		IMouseListener *pMouseListener = mouselisteners.GetCurrentMouseListener();
		if ( pMouseListener != 0 )
		{
			CMouseEvent event( this->m_pMapControl, point, nFlags, 
					mouselisteners.GetCurrentSubMouseListenerKey() );
			pMouseListener->OnLButtonUp( & event );
		}
	}
	ReleaseCapture();
	CView::OnLButtonUp(nFlags, point);
}

void CGISMapView::OnPan() 
{
	// TODO: Add your command handler code here
	CMouseListeners& mouselisteners = this->m_pMapControl->GetMouseListeners();
	mouselisteners.SetCurrentMouseListenerKey(EMAP_TOOL_MAPVIEW_CONTROLLER,EMAP_TOOL_PAN);
}

void CGISMapView::OnZoomin() 
{
	// TODO: Add your command handler code here
	CMouseListeners& mouselisteners = this->m_pMapControl->GetMouseListeners();
	mouselisteners.SetCurrentMouseListenerKey(EMAP_TOOL_MAPVIEW_CONTROLLER,EMAP_TOOL_ZOOMIN);
}

void CGISMapView::OnZoomout() 
{
	// TODO: Add your command handler code here
	CMouseListeners& mouselisteners = this->m_pMapControl->GetMouseListeners();
	mouselisteners.SetCurrentMouseListenerKey(EMAP_TOOL_MAPVIEW_CONTROLLER,EMAP_TOOL_ZOOMOUT);
}

void CGISMapView::OnReset()
{
	// TODO: Add your command handler code here
	m_pMapControl->Reset();
	CRect clientRect;
	this->GetClientRect(&clientRect);
	this->m_pMapControl->ReDraw(clientRect.left,clientRect.top,
								clientRect.Width(),clientRect.Height());
	this->Invalidate(false);
}

void CGISMapView::OnFileOpen() 
{
	// TODO: Add your command handler code here
	CGISMapDoc *pDoc = this->GetDocument();
	FeatureClass *pFeatureClass = pDoc->OnShapeFileOpen();
	if ( pFeatureClass == 0 ) return ;
	
	Layers& layers = m_pMapControl->GetLayers();
	LayerProperty *pLayerProperty = new LayerProperty(layers.Count()+1,pFeatureClass->GetName());
	pLayerProperty->SetRelateDataSet( pFeatureClass);
	MapLayer *pMapLayer = new MapLayer( pLayerProperty );
	pMapLayer->SetRender( new ShpRender( pMapLayer) );
	layers.Add( pMapLayer );

	this->m_pMapControl->Reset();
	CRect clientRect;
	this->GetClientRect(&clientRect);
	this->m_pMapControl->ReDraw(clientRect.left,clientRect.top,
								clientRect.Width(),clientRect.Height());
	this->Invalidate(false);
}
