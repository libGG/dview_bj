//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A57DC00DF.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A57DC00DF.cm

//## begin module%405A57DC00DF.cp preserve=no
//## end module%405A57DC00DF.cp

//## Module: FeatureClass%405A57DC00DF; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\FeatureClass.cpp

//## begin module%405A57DC00DF.additionalIncludes preserve=no
//## end module%405A57DC00DF.additionalIncludes

//## begin module%405A57DC00DF.includes preserve=yes
//## end module%405A57DC00DF.includes

#include "FeatureClass.h"
//## begin module%405A57DC00DF.additionalDeclarations preserve=yes
//## end module%405A57DC00DF.additionalDeclarations


// Class FeatureClass 













FeatureClass::FeatureClass (int id, int type, const char *strName, DataSource* pDataSource )
  //## begin FeatureClass::FeatureClass%4067E86D0128.hasinit preserve=no
      : Table( id, type, pDataSource, strName )
  //## end FeatureClass::FeatureClass%4067E86D0128.hasinit
  //## begin FeatureClass::FeatureClass%4067E86D0128.initialization preserve=yes
  //## end FeatureClass::FeatureClass%4067E86D0128.initialization
{
  //## begin FeatureClass::FeatureClass%4067E86D0128.body preserve=yes
  //## end FeatureClass::FeatureClass%4067E86D0128.body
}


FeatureClass::~FeatureClass()
{
  //## begin FeatureClass::~FeatureClass%405A57DC00DF_dest.body preserve=yes
	Feature * pfeature;
	for( m_curRow = m_mapRow.begin(); m_curRow != m_mapRow.end(); m_curRow++ )
	{
		pfeature = ( Feature * )(*m_curRow).second;
		delete pfeature;
		(*m_curRow).second = 0;
	}
	m_mapRow.clear();
  //## end FeatureClass::~FeatureClass%405A57DC00DF_dest.body
}


const char* FeatureClass::GetName ()
{
  //## begin FeatureClass::GetName%405E8588026F.body preserve=yes
	return GetTableName();
  //## end FeatureClass::GetName%405E8588026F.body
}

void FeatureClass::GetBound (double& minx, double& miny, double& w, double& h)
{
  //## begin FeatureClass::GetBound%405D4612000F.body preserve=yes
	minx = m_dMinx;
	miny = m_dMiny;
	w    = m_dWidth;
	h    = m_dHeight;
  //## end FeatureClass::GetBound%405D4612000F.body
}

void FeatureClass::CalculateBound ()
{
  //## begin FeatureClass::CalculateBound%405D466200AB.body preserve=yes
	double	minx = 0, miny = 0, maxx = 0, maxy = 0;
	double	x, y, w, h;
	bool	isfirst = true;
	Feature *pfeature = ( Feature * )GetFirst();
	while( pfeature )
	{
		pfeature->GetBound( x, y, w, h );
		if( isfirst )
		{
			minx = x;
			miny = y;
			maxx = x+w;
			maxy = y+h;
			isfirst = false ;
		}
		else
		{
			if( minx > x ) minx = x;
			if( miny > y ) miny = y;
			if( maxx < w+x ) maxx = x+w;
			if( maxy < y+h ) maxy = y+h;
		}
		pfeature = (Feature*)GetNext();
	}

	m_dMinx = minx;
	m_dMiny = miny;
	m_dWidth = maxx-minx;
	m_dHeight = maxy-miny;
  //## end FeatureClass::CalculateBound%405D466200AB.body
}

int FeatureClass::GetFeatureSize ()
{
  //## begin FeatureClass::GetFeatureSize%405BE720038A.body preserve=yes
	return Size();
  //## end FeatureClass::GetFeatureSize%405BE720038A.body
}

Feature* FeatureClass::GetFirstFeature ()
{
  //## begin FeatureClass::GetFirstFeature%405BE70C033C.body preserve=yes
	return (Feature*)GetFirst();
  //## end FeatureClass::GetFirstFeature%405BE70C033C.body
}

Feature* FeatureClass::GetNextFeature ()
{
  //## begin FeatureClass::GetNextFeature%405BE7160251.body preserve=yes
	return (Feature*)GetNext();
  //## end FeatureClass::GetNextFeature%405BE7160251.body
}

Feature* FeatureClass::GetFeature (int fid)
{
  //## begin FeatureClass::GetFeature%405BE72B038A.body preserve=yes
	return (Feature*)GetRow(fid);
  //## end FeatureClass::GetFeature%405BE72B038A.body
}

// Additional Declarations
  //## begin FeatureClass%405A57DC00DF.declarations preserve=yes
  //## end FeatureClass%405A57DC00DF.declarations

//## begin module%405A57DC00DF.epilog preserve=yes
//## end module%405A57DC00DF.epilog
