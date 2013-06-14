//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%407002740042.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%407002740042.cm

//## begin module%407002740042.cp preserve=no
//## end module%407002740042.cp

//## Module: GeoPolyline%407002740042; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\GEOO\GeoPolyline.cpp

//## begin module%407002740042.additionalIncludes preserve=no
//## end module%407002740042.additionalIncludes

//## begin module%407002740042.includes preserve=yes
//## end module%407002740042.includes

#include "GeoPolyline.h"
//## begin module%407002740042.additionalDeclarations preserve=yes
//## end module%407002740042.additionalDeclarations


// Class GeoPolyline 




GeoPolyline::GeoPolyline()
  //## begin GeoPolyline::GeoPolyline%407002740042_const.hasinit preserve=no
      : nPointsCount(0)
  //## end GeoPolyline::GeoPolyline%407002740042_const.hasinit
  //## begin GeoPolyline::GeoPolyline%407002740042_const.initialization preserve=yes
  //## end GeoPolyline::GeoPolyline%407002740042_const.initialization
{
  //## begin GeoPolyline::GeoPolyline%407002740042_const.body preserve=yes
  //## end GeoPolyline::GeoPolyline%407002740042_const.body
}


GeoPolyline::~GeoPolyline()
{
  //## begin GeoPolyline::~GeoPolyline%407002740042_dest.body preserve=yes
  //## end GeoPolyline::~GeoPolyline%407002740042_dest.body
}



//## Other Operations (implementation)
int GeoPolyline::GetGeoType ()
{
  //## begin GeoPolyline::GetGeoType%40A44FE502CE.body preserve=yes
	return GEO_POLYLINE;
  //## end GeoPolyline::GetGeoType%40A44FE502CE.body
}

void GeoPolyline::SetPointsCount (int nCount)
{
  //## begin GeoPolyline::SetPointsCount%409F7F39008C.body preserve=yes
	if( nPointsCount == 0 )
	{
		nPointsCount = nCount;
		arrayPoints = new GeoPoints[ nCount ];
	}
	else
	{
		delete []arrayPoints;
		nPointsCount = nCount;
		arrayPoints = new GeoPoints[ nCount ];
	}
  //## end GeoPolyline::SetPointsCount%409F7F39008C.body
}

int GeoPolyline::GetPointsCount ()
{
  //## begin GeoPolyline::GetPointsCount%409F7F540232.body preserve=yes
	return nPointsCount;
  //## end GeoPolyline::GetPointsCount%409F7F540232.body
}

GeoPoints& GeoPolyline::GetPoints (int index)
{
  //## begin GeoPolyline::GetPoints%409F7F65032C.body preserve=yes
	return arrayPoints[ index ];
  //## end GeoPolyline::GetPoints%409F7F65032C.body
}

// Additional Declarations
  //## begin GeoPolyline%407002740042.declarations preserve=yes
  //## end GeoPolyline%407002740042.declarations

//## begin module%407002740042.epilog preserve=yes
//## end module%407002740042.epilog
