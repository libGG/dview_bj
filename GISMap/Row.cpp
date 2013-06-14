//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A573602DF.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A573602DF.cm

//## begin module%405A573602DF.cp preserve=no
//## end module%405A573602DF.cp

//## Module: Row%405A573602DF; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\Row.cpp

//## begin module%405A573602DF.additionalIncludes preserve=no
//## end module%405A573602DF.additionalIncludes

//## begin module%405A573602DF.includes preserve=yes
//## end module%405A573602DF.includes

#include "Row.h"
//## begin module%405A573602DF.additionalDeclarations preserve=yes
#include "fields.h"
//## end module%405A573602DF.additionalDeclarations


// Class Row 






Row::Row (int id, Fields* pFields)
  //## begin Row::Row%405BE25D037A.hasinit preserve=no
      : m_pFields(0),
        m_pArrayValue(0)
  //## end Row::Row%405BE25D037A.hasinit
  //## begin Row::Row%405BE25D037A.initialization preserve=yes
  //## end Row::Row%405BE25D037A.initialization
{
  //## begin Row::Row%405BE25D037A.body preserve=yes
	int		num;
	m_nID		= id;
	m_pFields	= pFields;
	
	num = pFields->Size();
	if ( num > 0 )
		m_pArrayValue = new FieldValue[ num ];
	
  //## end Row::Row%405BE25D037A.body
}


Row::~Row()
{
  //## begin Row::~Row%405A573602DF_dest.body preserve=yes
	if( m_pArrayValue ) delete []m_pArrayValue;
  //## end Row::~Row%405A573602DF_dest.body
}



//## Other Operations (implementation)
int Row::GetID ()
{
  //## begin Row::GetID%405E6905034B.body preserve=yes
	return m_nID;
  //## end Row::GetID%405E6905034B.body
}

Fields& Row::GetFields ()
{
  //## begin Row::GetFields%405BE4BD03A9.body preserve=yes
	return *m_pFields;
  //## end Row::GetFields%405BE4BD03A9.body
}

FieldValue& Row::GetFieldValue (int index)
{
  //## begin Row::GetFieldValue%405BE43600BB.body preserve=yes
	return m_pArrayValue[ index ];
  //## end Row::GetFieldValue%405BE43600BB.body
}

FieldValue& Row::GetFieldValue (const char* szFieldName)
{
  //## begin Row::GetFieldValue%405BE487008C.body preserve=yes
	int index = m_pFields->GetIndex( szFieldName );
	if( index != -1 )	return m_pArrayValue[ index ];
  //## end Row::GetFieldValue%405BE487008C.body
}

// Additional Declarations
  //## begin Row%405A573602DF.declarations preserve=yes
  //## end Row%405A573602DF.declarations

//## begin module%405A573602DF.epilog preserve=yes
//## end module%405A573602DF.epilog
