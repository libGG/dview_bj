//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40AD5E5200ED.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40AD5E5200ED.cm

//## begin module%40AD5E5200ED.cp preserve=no
//## end module%40AD5E5200ED.cp

//## Module: MapProperty%40AD5E5200ED; Pseudo Package body
//## Source file: E:\egisdevelop\code\mapcontrol\MapProperty.cpp

//## begin module%40AD5E5200ED.additionalIncludes preserve=no
//## end module%40AD5E5200ED.additionalIncludes

//## begin module%40AD5E5200ED.includes preserve=yes
//## end module%40AD5E5200ED.includes

#include "MapProperty.h"
//## begin module%40AD5E5200ED.additionalDeclarations preserve=yes
#include "MapControl.h"
//## end module%40AD5E5200ED.additionalDeclarations


// Class MapProperty 






MapProperty::MapProperty (MapControl* mapCtrl)
  //## begin MapProperty::MapProperty%40AD5E5200EE.hasinit preserve=no
  //## end MapProperty::MapProperty%40AD5E5200EE.hasinit
  //## begin MapProperty::MapProperty%40AD5E5200EE.initialization preserve=yes
  //## end MapProperty::MapProperty%40AD5E5200EE.initialization
{
  //## begin MapProperty::MapProperty%40AD5E5200EE.body preserve=yes
	this ->m_pMapControl = mapCtrl ;
  //## end MapProperty::MapProperty%40AD5E5200EE.body
}


MapProperty::~MapProperty()
{
  //## begin MapProperty::~MapProperty%40AD5E5200ED_dest.body preserve=yes
	m_pMapControl = 0 ;
  //## end MapProperty::~MapProperty%40AD5E5200ED_dest.body
}



//## Other Operations (implementation)
void MapProperty::ClientToWorld (double& x, double& y)
{
  //## begin MapProperty::ClientToWorld%40AD5E5200F0.body preserve=yes
	m_pMapControl ->ClientToWorld(x,y);
  //## end MapProperty::ClientToWorld%40AD5E5200F0.body
}

void MapProperty::WorldToClient (double& x, double& y)
{
  //## begin MapProperty::WorldToClient%40AD5E5200F3.body preserve=yes
	m_pMapControl->WorldToClient(x,y);
  //## end MapProperty::WorldToClient%40AD5E5200F3.body
}

void MapProperty::GetClipRect (int& x, int& y, int& w, int& h)
{
  //## begin MapProperty::GetClipRect%40AD5E5200F6.body preserve=yes
	x = this ->m_nClipX ;
	y = this ->m_nClipY ;
	w = this ->m_nClipWidth ;
	h = this ->m_nClipHeight ;
  //## end MapProperty::GetClipRect%40AD5E5200F6.body
}

void MapProperty::SetClipRect (int x, int y, int w, int h)
{
  //## begin MapProperty::SetClipRect%40AD6128007D.body preserve=yes
	this ->m_nClipX = x ; 
	this ->m_nClipY = y ;
	this ->m_nClipWidth = w ;
	this ->m_nClipHeight = h ;
  //## end MapProperty::SetClipRect%40AD6128007D.body
}

// Additional Declarations
  //## begin MapProperty%40AD5E5200ED.declarations preserve=yes
  //## end MapProperty%40AD5E5200ED.declarations

//## begin module%40AD5E5200ED.epilog preserve=yes
//## end module%40AD5E5200ED.epilog
