//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A575E01E3.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A575E01E3.cm

//## begin module%405A575E01E3.cp preserve=no
//## end module%405A575E01E3.cp

//## Module: Feature%405A575E01E3; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\Feature.cpp

//## begin module%405A575E01E3.additionalIncludes preserve=no
//## end module%405A575E01E3.additionalIncludes

//## begin module%405A575E01E3.includes preserve=yes
//## end module%405A575E01E3.includes

#include "Feature.h"
//## begin module%405A575E01E3.additionalDeclarations preserve=yes
#include "GeoPoint.h"
#include "geopolyline.h"
#include "GeoPolygon.h"
//## end module%405A575E01E3.additionalDeclarations


// Class Feature 










Feature::Feature (int fid, int subType, Fields* pFields)
  //## begin Feature::Feature%405BE04F0251.hasinit preserve=no
      : m_pGeometry(0)
  //## end Feature::Feature%405BE04F0251.hasinit
  //## begin Feature::Feature%405BE04F0251.initialization preserve=yes
		,Row( fid, pFields )
  //## end Feature::Feature%405BE04F0251.initialization
{
  //## begin Feature::Feature%405BE04F0251.body preserve=yes
	m_nSubType = subType;
  //## end Feature::Feature%405BE04F0251.body
}


Feature::~Feature()
{
  //## begin Feature::~Feature%405A575E01E3_dest.body preserve=yes
	if( m_pGeometry ) 
	{
		switch( m_pGeometry ->GetGeoType() )
		{
		case GEO_POINT:	delete (GeoPoint*)m_pGeometry; break;
		case GEO_POLYLINE: delete (GeoPolyline*)m_pGeometry; break;
		case GEO_POLYGON: delete (GeoPolygon*)m_pGeometry; break;
		}
	}
  //## end Feature::~Feature%405A575E01E3_dest.body
}



//## Other Operations (implementation)
int Feature::GetFID ()
{
  //## begin Feature::GetFID%405BE00E033C.body preserve=yes
	return m_nID;
  //## end Feature::GetFID%405BE00E033C.body
}

int Feature::GetSubType ()
{
  //## begin Feature::GetSubType%405BE01302DE.body preserve=yes
	return m_nSubType;
  //## end Feature::GetSubType%405BE01302DE.body
}

void Feature::GetBound (double& minx, double& miny, double& w, double& h)
{
  //## begin Feature::GetBound%405D80D70261.body preserve=yes
	minx	=	m_dMinx;
	miny	=	m_dMiny;
	w		=	m_dWidth;
	h		=	m_dHeight;
  //## end Feature::GetBound%405D80D70261.body
}

void Feature::SetBound (double minx, double miny, double w, double h)
{
  //## begin Feature::SetBound%405D81010167.body preserve=yes
	m_dMinx		= minx;
	m_dMiny		= miny;
	m_dWidth	= w;
	m_dHeight	= h;
  //## end Feature::SetBound%405D81010167.body
}

Geometry& Feature::GetGeometry ()
{
  //## begin Feature::GetGeometry%405BE01A029F.body preserve=yes
	return *m_pGeometry;
  //## end Feature::GetGeometry%405BE01A029F.body
}

void Feature::SetGeometry (Geometry* pGeometry)
{
  //## begin Feature::SetGeometry%405BE28D0000.body preserve=yes
	m_pGeometry = pGeometry;
  //## end Feature::SetGeometry%405BE28D0000.body
}

// Additional Declarations
  //## begin Feature%405A575E01E3.declarations preserve=yes
  //## end Feature%405A575E01E3.declarations

//## begin module%405A575E01E3.epilog preserve=yes
//## end module%405A575E01E3.epilog
