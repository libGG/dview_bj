//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%407002620042.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%407002620042.cm

//## begin module%407002620042.cp preserve=no
//## end module%407002620042.cp

//## Module: GeoPoint%407002620042; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\GEOO\GeoPoint.cpp

//## begin module%407002620042.additionalIncludes preserve=no
//## end module%407002620042.additionalIncludes

//## begin module%407002620042.includes preserve=yes
//## end module%407002620042.includes

#include "GeoPoint.h"
//## begin module%407002620042.additionalDeclarations preserve=yes
//## end module%407002620042.additionalDeclarations


// Class GeoPoint 




GeoPoint::GeoPoint()
  //## begin GeoPoint::GeoPoint%407002620042_const.hasinit preserve=no
      : x(0),
        y(0)
  //## end GeoPoint::GeoPoint%407002620042_const.hasinit
  //## begin GeoPoint::GeoPoint%407002620042_const.initialization preserve=yes
  //## end GeoPoint::GeoPoint%407002620042_const.initialization
{
  //## begin GeoPoint::GeoPoint%407002620042_const.body preserve=yes
  //## end GeoPoint::GeoPoint%407002620042_const.body
}

GeoPoint::GeoPoint (double X, double Y)
  //## begin GeoPoint::GeoPoint%407955DB0128.hasinit preserve=no
      : x(0),
        y(0)
  //## end GeoPoint::GeoPoint%407955DB0128.hasinit
  //## begin GeoPoint::GeoPoint%407955DB0128.initialization preserve=yes
  //## end GeoPoint::GeoPoint%407955DB0128.initialization
{
  //## begin GeoPoint::GeoPoint%407955DB0128.body preserve=yes
	this->x = X;
	this->y = Y;
  //## end GeoPoint::GeoPoint%407955DB0128.body
}


GeoPoint::~GeoPoint()
{
  //## begin GeoPoint::~GeoPoint%407002620042_dest.body preserve=yes
  //## end GeoPoint::~GeoPoint%407002620042_dest.body
}



//## Other Operations (implementation)
int GeoPoint::GetGeoType ()
{
  //## begin GeoPoint::GetGeoType%40A44FD8002E.body preserve=yes
	return GEO_POINT;
  //## end GeoPoint::GetGeoType%40A44FD8002E.body
}

double GeoPoint::GetX ()
{
  //## begin GeoPoint::GetX%407002AC00DF.body preserve=yes
	return x;
  //## end GeoPoint::GetX%407002AC00DF.body
}

double GeoPoint::GetY ()
{
  //## begin GeoPoint::GetY%407002EF0217.body preserve=yes
	return y;
  //## end GeoPoint::GetY%407002EF0217.body
}

void GeoPoint::SetX (double X)
{
  //## begin GeoPoint::SetX%407002F4036F.body preserve=yes
	this->x = X;
  //## end GeoPoint::SetX%407002F4036F.body
}

void GeoPoint::SetY (double Y)
{
  //## begin GeoPoint::SetY%40700328014C.body preserve=yes
	this->y = Y;
  //## end GeoPoint::SetY%40700328014C.body
}

// Additional Declarations
  //## begin GeoPoint%407002620042.declarations preserve=yes
  //## end GeoPoint%407002620042.declarations

//## begin module%407002620042.epilog preserve=yes
//## end module%407002620042.epilog
