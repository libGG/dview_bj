//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40B009580157.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40B009580157.cm

//## begin module%40B009580157.cp preserve=no
//## end module%40B009580157.cp

//## Module: GeoAnnotation%40B009580157; Pseudo Package body
//## Source file: E:\egisdevelop\code\Geometry\GeoAnnotation.cpp

//## begin module%40B009580157.additionalIncludes preserve=no
//## end module%40B009580157.additionalIncludes

//## begin module%40B009580157.includes preserve=yes
//## end module%40B009580157.includes

#include "GeoAnnotation.h"
//## begin module%40B009580157.additionalDeclarations preserve=yes
#include <string>
//## end module%40B009580157.additionalDeclarations


// Class GeoAnnotation 




GeoAnnotation::GeoAnnotation()
  //## begin GeoAnnotation::GeoAnnotation%40B009580157_const.hasinit preserve=no
      : pString(0)
  //## end GeoAnnotation::GeoAnnotation%40B009580157_const.hasinit
  //## begin GeoAnnotation::GeoAnnotation%40B009580157_const.initialization preserve=yes
  //## end GeoAnnotation::GeoAnnotation%40B009580157_const.initialization
{
  //## begin GeoAnnotation::GeoAnnotation%40B009580157_const.body preserve=yes
  //## end GeoAnnotation::GeoAnnotation%40B009580157_const.body
}

GeoAnnotation::GeoAnnotation (double X, double Y, const char *string)
  //## begin GeoAnnotation::GeoAnnotation%40B009580159.hasinit preserve=no
      : pString(0)
  //## end GeoAnnotation::GeoAnnotation%40B009580159.hasinit
  //## begin GeoAnnotation::GeoAnnotation%40B009580159.initialization preserve=yes
  //## end GeoAnnotation::GeoAnnotation%40B009580159.initialization
{
  //## begin GeoAnnotation::GeoAnnotation%40B009580159.body preserve=yes
	x = X;
	y = Y;
	if( pString != 0 ) 
	{
		delete []pString;
		pString = 0;
	}
	int len = strlen( string );
	pString = (char*)malloc( len + 1 );
	strcpy( pString, string );

  //## end GeoAnnotation::GeoAnnotation%40B009580159.body
}


GeoAnnotation::~GeoAnnotation()
{
  //## begin GeoAnnotation::~GeoAnnotation%40B009580157_dest.body preserve=yes
	if( pString )
	{
		delete []pString;
	}
  //## end GeoAnnotation::~GeoAnnotation%40B009580157_dest.body
}



//## Other Operations (implementation)
int GeoAnnotation::GetGeoType ()
{
  //## begin GeoAnnotation::GetGeoType%40B00958015D.body preserve=yes
	return GEO_ANNOTATION;
  //## end GeoAnnotation::GetGeoType%40B00958015D.body
}

double GeoAnnotation::GetX ()
{
  //## begin GeoAnnotation::GetX%40B00958015E.body preserve=yes
	return x;
  //## end GeoAnnotation::GetX%40B00958015E.body
}

double GeoAnnotation::GetY ()
{
  //## begin GeoAnnotation::GetY%40B00958015F.body preserve=yes
	return y;
  //## end GeoAnnotation::GetY%40B00958015F.body
}

const char * GeoAnnotation::GetString ()
{
  //## begin GeoAnnotation::GetString%40B009580160.body preserve=yes
	return pString;
  //## end GeoAnnotation::GetString%40B009580160.body
}

void GeoAnnotation::SetString (const char *string)
{
  //## begin GeoAnnotation::SetString%40B009580161.body preserve=yes
	if( pString )
	{
		delete []pString;
		pString = 0;
	}
	int len = strlen( string );
	pString = ( char * )malloc( len );
	strcpy( pString, string );
  //## end GeoAnnotation::SetString%40B009580161.body
}

void GeoAnnotation::SetX (double X)
{
  //## begin GeoAnnotation::SetX%40B009580163.body preserve=yes
	x = X;
  //## end GeoAnnotation::SetX%40B009580163.body
}

void GeoAnnotation::SetY (double Y)
{
  //## begin GeoAnnotation::SetY%40B009580165.body preserve=yes
	y = Y;
  //## end GeoAnnotation::SetY%40B009580165.body
}

// Additional Declarations
  //## begin GeoAnnotation%40B009580157.declarations preserve=yes
  //## end GeoAnnotation%40B009580157.declarations

//## begin module%40B009580157.epilog preserve=yes
//## end module%40B009580157.epilog
