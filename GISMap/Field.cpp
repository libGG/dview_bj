//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A578700DD.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A578700DD.cm

//## begin module%405A578700DD.cp preserve=no
//## end module%405A578700DD.cp

//## Module: Field%405A578700DD; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\Field.cpp

//## begin module%405A578700DD.additionalIncludes preserve=no
//## end module%405A578700DD.additionalIncludes

//## begin module%405A578700DD.includes preserve=yes
//## end module%405A578700DD.includes

#include "Field.h"
//## begin module%405A578700DD.additionalDeclarations preserve=yes

#include "string.h"
//## end module%405A578700DD.additionalDeclarations


// Class Field 










Field::Field (const char* szName, const char* szCaption, int nFieldType, int nLength)
  //## begin Field::Field%405BD4B4038A.hasinit preserve=no
  //## end Field::Field%405BD4B4038A.hasinit
  //## begin Field::Field%405BD4B4038A.initialization preserve=yes
  //## end Field::Field%405BD4B4038A.initialization
{
  //## begin Field::Field%405BD4B4038A.body preserve=yes
	if ( sizeof (szCaption) > FIELDCAPTIONLEN )
	{
		strncpy(m_szFieldCaption, szCaption, FIELDCAPTIONLEN - 1) ;
		m_szFieldName[FIELDCAPTIONLEN - 1 ] = '\0' ;
	}
	else strcpy ( m_szFieldCaption, szCaption ) ;
	if ( sizeof (szName) > FIELDNAMELEN )
	{
		strncpy(m_szFieldName, szName, FIELDNAMELEN - 1) ;
		m_szFieldName[FIELDNAMELEN - 1 ] = '\0' ;
	}
	else strcpy ( m_szFieldName, szName ) ;

	m_nFieldType		=	(FIELDTYPE)nFieldType;
	m_nFieldLength		=	nLength;
  //## end Field::Field%405BD4B4038A.body
}


Field::~Field()
{
  //## begin Field::~Field%405A578700DD_dest.body preserve=yes
  //## end Field::~Field%405A578700DD_dest.body
}



//## Other Operations (implementation)
const char* Field::GetFieldName ()
{
  //## begin Field::GetFieldName%405BD4E901A5.body preserve=yes
	return m_szFieldName;
  //## end Field::GetFieldName%405BD4E901A5.body
}

const char* Field::GetFieldCaption ()
{
  //## begin Field::GetFieldCaption%405BD4F202CE.body preserve=yes
	return m_szFieldCaption;
  //## end Field::GetFieldCaption%405BD4F202CE.body
}

void Field::SetFieldCaption (const char* szCaption)
{
  //## begin Field::SetFieldCaption%405BD503037A.body preserve=yes
	if ( strlen (szCaption) > FIELDCAPTIONLEN )
	{
		strncpy(m_szFieldCaption, szCaption, FIELDCAPTIONLEN - 1) ;
		m_szFieldName[FIELDCAPTIONLEN - 1 ] = '\0' ;
	}
	else strcpy ( m_szFieldCaption, szCaption ) ;
  //## end Field::SetFieldCaption%405BD503037A.body
}

FIELDTYPE Field::GetFieldType ()
{
  //## begin Field::GetFieldType%405BD50C029F.body preserve=yes
	return m_nFieldType;
  //## end Field::GetFieldType%405BD50C029F.body
}

int Field::GetFieldLength ()
{
  //## begin Field::GetFieldLength%405BD5190399.body preserve=yes
	return m_nFieldLength;
  //## end Field::GetFieldLength%405BD5190399.body
}

FieldValue& Field::GetFieldValue ()
{
  //## begin Field::GetFieldValue%405BD82701C5.body preserve=yes
	return m_oFieldValue;
  //## end Field::GetFieldValue%405BD82701C5.body
}

// Additional Declarations
  //## begin Field%405A578700DD.declarations preserve=yes
  //## end Field%405A578700DD.declarations

//## begin module%405A578700DD.epilog preserve=yes
//## end module%405A578700DD.epilog
