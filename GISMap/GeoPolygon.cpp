//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%4070027E0052.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%4070027E0052.cm

//## begin module%4070027E0052.cp preserve=no
//## end module%4070027E0052.cp

//## Module: GeoPolygon%4070027E0052; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\GEOO\GeoPolygon.cpp

//## begin module%4070027E0052.additionalIncludes preserve=no
//## end module%4070027E0052.additionalIncludes

//## begin module%4070027E0052.includes preserve=yes
//## end module%4070027E0052.includes

#include "GeoPolygon.h"
//## begin module%4070027E0052.additionalDeclarations preserve=yes
//## end module%4070027E0052.additionalDeclarations


// Class GeoPolygon 




GeoPolygon::GeoPolygon()
  //## begin GeoPolygon::GeoPolygon%4070027E0052_const.hasinit preserve=no
      : nPointsCount(0)
  //## end GeoPolygon::GeoPolygon%4070027E0052_const.hasinit
  //## begin GeoPolygon::GeoPolygon%4070027E0052_const.initialization preserve=yes
  //## end GeoPolygon::GeoPolygon%4070027E0052_const.initialization
{
  //## begin GeoPolygon::GeoPolygon%4070027E0052_const.body preserve=yes
  //## end GeoPolygon::GeoPolygon%4070027E0052_const.body
}


GeoPolygon::~GeoPolygon()
{
  //## begin GeoPolygon::~GeoPolygon%4070027E0052_dest.body preserve=yes
	delete []arrayPoints;
  //## end GeoPolygon::~GeoPolygon%4070027E0052_dest.body
}



//## Other Operations (implementation)
int GeoPolygon::GetGeoType ()
{
  //## begin GeoPolygon::GetGeoType%40A44FEE0148.body preserve=yes
	return GEO_POLYGON;		
  //## end GeoPolygon::GetGeoType%40A44FEE0148.body
}

void GeoPolygon::SetPointsCount (int nCount)
{
  //## begin GeoPolygon::SetPointsCount%4085E53101F3.body preserve=yes
	if( nPointsCount == 0 )
	{
		nPointsCount = nCount;
		arrayPoints = new GeoPoints[ nCount ];
	}
	else
	{
		nPointsCount = nCount;
		delete []arrayPoints;
		arrayPoints = new GeoPoints[ nCount ];
	}
  //## end GeoPolygon::SetPointsCount%4085E53101F3.body
}

int GeoPolygon::GetPointsCount ()
{
  //## begin GeoPolygon::GetPointsCount%4085E58A0137.body preserve=yes
	return nPointsCount;
  //## end GeoPolygon::GetPointsCount%4085E58A0137.body
}

GeoPoints& GeoPolygon::GetPoints (int index)
{
  //## begin GeoPolygon::GetPoints%40794BBD00BB.body preserve=yes
	return arrayPoints[ index ];
  //## end GeoPolygon::GetPoints%40794BBD00BB.body
}

// Additional Declarations
  //## begin GeoPolygon%4070027E0052.declarations preserve=yes
  //## end GeoPolygon%4070027E0052.declarations

//## begin module%4070027E0052.epilog preserve=yes
//## end module%4070027E0052.epilog
