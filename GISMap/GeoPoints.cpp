//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%4070026A0236.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%4070026A0236.cm

//## begin module%4070026A0236.cp preserve=no
//## end module%4070026A0236.cp

//## Module: GeoPoints%4070026A0236; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\GEOO\GeoPoints.cpp

//## begin module%4070026A0236.additionalIncludes preserve=no
//## end module%4070026A0236.additionalIncludes

//## begin module%4070026A0236.includes preserve=yes
//## end module%4070026A0236.includes

#include "GeoPoints.h"
//## begin module%4070026A0236.additionalDeclarations preserve=yes
//## end module%4070026A0236.additionalDeclarations


// Class GeoPoints 






GeoPoints::GeoPoints()
  //## begin GeoPoints::GeoPoints%4070026A0236_const.hasinit preserve=no
      : pArrayX(0),
        pArrayY(0),
        nPtCount(0)
  //## end GeoPoints::GeoPoints%4070026A0236_const.hasinit
  //## begin GeoPoints::GeoPoints%4070026A0236_const.initialization preserve=yes
  //## end GeoPoints::GeoPoints%4070026A0236_const.initialization
{
  //## begin GeoPoints::GeoPoints%4070026A0236_const.body preserve=yes
  //## end GeoPoints::GeoPoints%4070026A0236_const.body
}


GeoPoints::~GeoPoints()
{
  //## begin GeoPoints::~GeoPoints%4070026A0236_dest.body preserve=yes
	delete []pArrayX;
	delete []pArrayY;
  //## end GeoPoints::~GeoPoints%4070026A0236_dest.body
}



//## Other Operations (implementation)
GeoPoint GeoPoints::GetPoint (int index)
{
  //## begin GeoPoints::GetPoint%4070038E0340.body preserve=yes
	return GeoPoint( pArrayX[ index], pArrayY[ index ] );
  //## end GeoPoints::GetPoint%4070038E0340.body
}

void GeoPoints::GetPoint (int index, double& x, double& y)
{
  //## begin GeoPoints::GetPoint%40794C22003E.body preserve=yes
	x = pArrayX[ index ];
	y = pArrayY[ index ];
  //## end GeoPoints::GetPoint%40794C22003E.body
}

int GeoPoints::GetPtCount ()
{
  //## begin GeoPoints::GetPtCount%40700409035F.body preserve=yes
	return nPtCount;
  //## end GeoPoints::GetPtCount%40700409035F.body
}

void GeoPoints::SetPointCount (int nPtCount)
{
  //## begin GeoPoints::SetPointCount%4070052D0014.body preserve=yes
	if( pArrayX == 0 && pArrayY == 0 )
	{
		pArrayX = new double[ nPtCount ];
		pArrayY = new double[ nPtCount ];
		this->nPtCount = nPtCount;
		return;
	}
	else
	{
	}
  //## end GeoPoints::SetPointCount%4070052D0014.body
}

void GeoPoints::SetPoint (int index, double x, double y)
{
  //## begin GeoPoints::SetPoint%4079436D009C.body preserve=yes
	pArrayX[ index ] = x;
	pArrayY[ index ] = y;
  //## end GeoPoints::SetPoint%4079436D009C.body
}

void GeoPoints::SetPoint (int index, GeoPoint point)
{
  //## begin GeoPoints::SetPoint%4079439803C8.body preserve=yes
	pArrayX[ index ] = point.GetX();
	pArrayY[ index ] = point.GetY();
  //## end GeoPoints::SetPoint%4079439803C8.body
}

// Additional Declarations
  //## begin GeoPoints%4070026A0236.declarations preserve=yes
  //## end GeoPoints%4070026A0236.declarations

//## begin module%4070026A0236.epilog preserve=yes
//## end module%4070026A0236.epilog
