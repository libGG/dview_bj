//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A532D009F.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A532D009F.cm

//## begin module%405A532D009F.cp preserve=no
//## end module%405A532D009F.cp

//## Module: FieldValue%405A532D009F; Pseudo Package body
//## Source file: E:\egis\code\数据访问模块\FieldValue.cpp

//## begin module%405A532D009F.additionalIncludes preserve=no
//## end module%405A532D009F.additionalIncludes

//## begin module%405A532D009F.includes preserve=yes
//## end module%405A532D009F.includes

#include "FieldValue.h"
//## begin module%405A532D009F.additionalDeclarations preserve=yes
#include "string.h"
#include "malloc.h"
//## end module%405A532D009F.additionalDeclarations


// Class FieldValue 





FieldValue::FieldValue()
  //## begin FieldValue::FieldValue%405A532D009F_const.hasinit preserve=no
      : m_pValue(0)
  //## end FieldValue::FieldValue%405A532D009F_const.hasinit
  //## begin FieldValue::FieldValue%405A532D009F_const.initialization preserve=yes
  //## end FieldValue::FieldValue%405A532D009F_const.initialization
{
  //## begin FieldValue::FieldValue%405A532D009F_const.body preserve=yes
  //## end FieldValue::FieldValue%405A532D009F_const.body
}


FieldValue::~FieldValue()
{
  //## begin FieldValue::~FieldValue%405A532D009F_dest.body preserve=yes
	if( m_pValue ) delete []m_pValue;
  //## end FieldValue::~FieldValue%405A532D009F_dest.body
}



//## Other Operations (implementation)
int FieldValue::GetInt ()
{
  //## begin FieldValue::GetInt%405BD268007D.body preserve=yes
	if( m_pValue )
		return *( (int*) m_pValue );
	else
		return 0;
  //## end FieldValue::GetInt%405BD268007D.body
}

void FieldValue::SetInt (int value)
{
  //## begin FieldValue::SetInt%405BD2FD035B.body preserve=yes
	if( m_pValue == 0 )
		m_pValue = (char*) malloc( sizeof( int ) );
	*( (int*) m_pValue ) = value;
  //## end FieldValue::SetInt%405BD2FD035B.body
}

double FieldValue::GetDouble ()
{
  //## begin FieldValue::GetDouble%405BD2AF02BF.body preserve=yes
	if( !m_pValue )
		return *( (double*) m_pValue );
	else	
		return 0;
  //## end FieldValue::GetDouble%405BD2AF02BF.body
}

void FieldValue::SetDouble (double value)
{
  //## begin FieldValue::SetDouble%405BD2F1003E.body preserve=yes
	if( m_pValue == 0 )
		m_pValue = (char*)malloc( sizeof( double ) );
	*( (double*) m_pValue ) = value;
  //## end FieldValue::SetDouble%405BD2F1003E.body
}

const char* FieldValue::GetString ()
{
  //## begin FieldValue::GetString%405BD2B70196.body preserve=yes
	return m_pValue;
  //## end FieldValue::GetString%405BD2B70196.body
}

void FieldValue::SetString (const char* value)
{
  //## begin FieldValue::SetString%405BD2DE01C5.body preserve=yes
	if( !m_pValue )
	{
		m_pValue = (char*) malloc( strlen( value ) + 1 );
		strcpy( m_pValue, value );
	}
	else
	{
		delete m_pValue;
		m_pValue = (char*)malloc( strlen( value ) + 1 );
		strcpy( m_pValue, value );
	}
  //## end FieldValue::SetString%405BD2DE01C5.body
}

// Additional Declarations
  //## begin FieldValue%405A532D009F.declarations preserve=yes
  //## end FieldValue%405A532D009F.declarations

//## begin module%405A532D009F.epilog preserve=yes
//## end module%405A532D009F.epilog
