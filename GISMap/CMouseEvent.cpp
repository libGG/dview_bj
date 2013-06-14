

// CMouseEvent
#include "stdafx.h"
#include "GISMap.h"
#include "CMouseEvent.h"
//## begin module%3D7871E20168.additionalDeclarations preserve=yes
//## end module%3D7871E20168.additionalDeclarations


// Class CMouseEvent 




CMouseEvent::CMouseEvent (void* pSource, CPoint point, int mouseFlag, int theTool)
  //## begin CMouseEvent::CMouseEvent%3D7871E20172.hasinit preserve=no
  //## end CMouseEvent::CMouseEvent%3D7871E20172.hasinit
  //## begin CMouseEvent::CMouseEvent%3D7871E20172.initialization preserve=yes
  //## end CMouseEvent::CMouseEvent%3D7871E20172.initialization
{
  //## begin CMouseEvent::CMouseEvent%3D7871E20172.body preserve=yes
	this->m_pSource = pSource ;
	this ->m_Point = point ;
	this ->m_MouseFlag = mouseFlag ;
	this ->m_tool = theTool ;
  //## end CMouseEvent::CMouseEvent%3D7871E20172.body
}


CMouseEvent::~CMouseEvent()
{
  //## begin CMouseEvent::~CMouseEvent%3D7871E20168_dest.body preserve=yes
	m_pSource = 0 ;
  //## end CMouseEvent::~CMouseEvent%3D7871E20168_dest.body
}



//## Other Operations (implementation)
CPoint CMouseEvent::GetPoint ()
{
  //## begin CMouseEvent::GetPoint%3D7871E20187.body preserve=yes
	return m_Point ;
  //## end CMouseEvent::GetPoint%3D7871E20187.body
}

int CMouseEvent::GetMouseFlag ()
{
  //## begin CMouseEvent::GetMouseFlag%3D7871E20188.body preserve=yes
	return this ->m_MouseFlag ;
  //## end CMouseEvent::GetMouseFlag%3D7871E20188.body
}

int CMouseEvent::GetTool ()
{
  //## begin CMouseEvent::GetTool%3D7871E20189.body preserve=yes
	return this ->m_tool ;
  //## end CMouseEvent::GetTool%3D7871E20189.body
}

// Additional Declarations
  //## begin CMouseEvent%3D7871E20168.declarations preserve=yes
//## Other Operations (implementation)
void* CMouseEvent::GetSource ()
{
  //## begin IMAP_Event::GetSource%3E5893F103A5.body preserve=yes
	return m_pSource ;
  //## end IMAP_Event::GetSource%3E5893F103A5.body
}
  //## end CMouseEvent%3D7871E20168.declarations

//## begin module%3D7871E20168.epilog preserve=yes
//## end module%3D7871E20168.epilog
