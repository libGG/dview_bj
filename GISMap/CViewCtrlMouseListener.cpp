
// CViewCtrlMouseListener
#include "stdafx.h"
#include "GISMap.h"
#include "CViewCtrlMouseListener.h"
//## begin module%3DC0C5E90333.additionalDeclarations preserve=yes
#include "MapControl.h"
#include "CMouseEvent.h"
//## end module%3DC0C5E90333.additionalDeclarations


// Class CViewCtrlMouseListener 

CViewCtrlMouseListener::CViewCtrlMouseListener()
  //## begin CViewCtrlMouseListener::CViewCtrlMouseListener%3DC0C5E90333_const.hasinit preserve=no
  //## end CViewCtrlMouseListener::CViewCtrlMouseListener%3DC0C5E90333_const.hasinit
  //## begin CViewCtrlMouseListener::CViewCtrlMouseListener%3DC0C5E90333_const.initialization preserve=yes
  //## end CViewCtrlMouseListener::CViewCtrlMouseListener%3DC0C5E90333_const.initialization
{
  //## begin CViewCtrlMouseListener::CViewCtrlMouseListener%3DC0C5E90333_const.body preserve=yes
  //## end CViewCtrlMouseListener::CViewCtrlMouseListener%3DC0C5E90333_const.body
}


CViewCtrlMouseListener::~CViewCtrlMouseListener()
{
  //## begin CViewCtrlMouseListener::~CViewCtrlMouseListener%3DC0C5E90333_dest.body preserve=yes
  //## end CViewCtrlMouseListener::~CViewCtrlMouseListener%3DC0C5E90333_dest.body
}



//## Other Operations (implementation)
void CViewCtrlMouseListener::OnLButtonDown (CMouseEvent* pMouseEvent)
{
  //## begin CViewCtrlMouseListener::OnLButtonDown%3DC0C5E90334.body preserve=yes
	MapControl *pMapControl = (MapControl *)pMouseEvent ->GetSource() ;

	if ( !pMapControl ) return ;

	m_lastPoint = m_LButtonPoint = pMouseEvent ->GetPoint () ;
  //## end CViewCtrlMouseListener::OnLButtonDown%3DC0C5E90334.body
}

void CViewCtrlMouseListener::OnLButtonUp (CMouseEvent* pMouseEvent)
{
  //## begin CViewCtrlMouseListener::OnLButtonUp%3DC0C5E90336.body preserve=yes
	MapControl *pMapControl = (MapControl *)pMouseEvent ->GetSource() ;

	if ( !pMapControl ) return ;

	int tool = pMouseEvent ->GetTool () ;

	CPoint point = pMouseEvent ->GetPoint () ;

	int dx = point.x - m_LButtonPoint.x ;
	int dy = point.y - m_LButtonPoint.y ;

	CRect rect ;
	rect.SetRect( m_LButtonPoint.x, m_LButtonPoint.y, point.x, point.y ) ;
	rect.NormalizeRect () ;


	switch ( tool )
	{
	case EMAP_TOOL_ZOOMIN :
		{
			pMapControl->ZoomIn ( rect.left, rect.top, rect.Width(), rect.Height() ) ;
			pMapControl->Refresh();
		}
		break ;
	case EMAP_TOOL_ZOOMOUT :
		{
			pMapControl->ZoomOut ( rect.left, rect.top, rect.Width(), rect.Height() ) ;
			pMapControl->Refresh();
		}
		break ;
	case EMAP_TOOL_PAN:
		{
			CPoint *pViewDrawingPos = pMapControl->GetOwnerWindowDrawingPos();
			pViewDrawingPos->x = 0;
			pViewDrawingPos->y = 0;
			pMapControl->Scroll ( dx, dy ) ;
			pMapControl->Refresh();
		}
		break ;
	default:
		break ;
	}
  //## end CViewCtrlMouseListener::OnLButtonUp%3DC0C5E90336.body
}

void CViewCtrlMouseListener::OnLButtonDBLClick (CMouseEvent* pMouseEvent)
{
  //## begin CViewCtrlMouseListener::OnLButtonDBLClick%3DC0C5E90338.body preserve=yes
  //## end CViewCtrlMouseListener::OnLButtonDBLClick%3DC0C5E90338.body
}

void CViewCtrlMouseListener::OnRButtonDown (CMouseEvent* pMouseEvent)
{
  //## begin CViewCtrlMouseListener::OnRButtonDown%3DC0C5E9033A.body preserve=yes
  //## end CViewCtrlMouseListener::OnRButtonDown%3DC0C5E9033A.body
}

void CViewCtrlMouseListener::OnRButtonUp (CMouseEvent* pMouseEvent)
{
  //## begin CViewCtrlMouseListener::OnRButtonUp%3DC0C5E9033C.body preserve=yes
  //## end CViewCtrlMouseListener::OnRButtonUp%3DC0C5E9033C.body
}

void CViewCtrlMouseListener::OnMouseMove (CMouseEvent* pMouseEvent)
{
  //## begin CViewCtrlMouseListener::OnMouseMove%3DC0C5E9033E.body preserve=yes
  //## end CViewCtrlMouseListener::OnMouseMove%3DC0C5E9033E.body
}

void CViewCtrlMouseListener::OnMouseDrag (CMouseEvent* pMouseEvent)
{
  //## begin CViewCtrlMouseListener::OnMouseDrag%3DC0C5E90340.body preserve=yes
	MapControl *pMapControl = (MapControl *)pMouseEvent ->GetSource() ;

	if ( !pMapControl ) return ;

	int tool = pMouseEvent ->GetTool () ;

	CPoint point = pMouseEvent ->GetPoint () ;

	switch ( tool )
	{
	case EMAP_TOOL_ZOOMIN :		
	case EMAP_TOOL_ZOOMOUT :
		{
			CView *pView = pMapControl ->GetOwnerView () ;

			pMapControl ->Refresh ();
			
			CDC *pDC = pView->GetDC();
			CPen pen, *pOldPen ;
			pen.CreatePen ( 0, 1, 255 ) ;
			pOldPen = ( CPen*)pDC ->SelectObject ( &pen );
			CBrush *pOldBrush = (CBrush*)pDC ->SelectStockObject ( NULL_BRUSH );
			pDC ->Rectangle ( m_LButtonPoint.x, m_LButtonPoint.y, point.x, point.y ) ;
			pDC ->SelectObject ( pOldBrush );
			pDC ->SelectObject ( pOldPen );
			pen.DeleteObject () ;
			pView->ReleaseDC(pDC);
			pOldPen = 0;
			pOldBrush = 0;
			pDC = 0;
		}
		break ;
	case EMAP_TOOL_PAN:
		{
			//int dx = point.x - m_LButtonPoint.x ;
			//int dy = point.y - m_LButtonPoint.y ;
			//pMapControl ->Refresh ( dx, dy ) ;

			int dx = point.x - m_lastPoint.x ;
			int dy = point.y - m_lastPoint.y ;
			CView *pView = pMapControl ->GetOwnerView () ;
			CPoint *pViewDrawingPos = pMapControl->GetOwnerWindowDrawingPos();
			pViewDrawingPos->x = point.x-m_LButtonPoint.x;
			pViewDrawingPos->y = point.y-m_LButtonPoint.y;
			pView ->ScrollWindow(dx,dy);
			m_lastPoint = point ;
		}
		break ;
	default:
		break ;
	}

  //## end CViewCtrlMouseListener::OnMouseDrag%3DC0C5E90340.body
}

void CViewCtrlMouseListener::OnCancel ()
{
  //## begin CViewCtrlMouseListener::OnCancel%3DC0C5E90342.body preserve=yes
  //## end CViewCtrlMouseListener::OnCancel%3DC0C5E90342.body
}
// Additional Declarations
  //## begin CViewCtrlMouseListener%3DC0C5E90333.declarations preserve=yes
  //## end CViewCtrlMouseListener%3DC0C5E90333.declarations

//## begin module%3DC0C5E90333.epilog preserve=yes
//## end module%3DC0C5E90333.epilog
