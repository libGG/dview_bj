//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A57A401BB.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A57A401BB.cm

//## begin module%405A57A401BB.cp preserve=no
//## end module%405A57A401BB.cp

//## Module: Fields%405A57A401BB; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\Fields.cpp

//## begin module%405A57A401BB.additionalIncludes preserve=no
//## end module%405A57A401BB.additionalIncludes

//## begin module%405A57A401BB.includes preserve=yes
//## end module%405A57A401BB.includes

#include "Fields.h"
//## begin module%405A57A401BB.additionalDeclarations preserve=yes
//## end module%405A57A401BB.additionalDeclarations


// Class Fields 





Fields::Fields()
  //## begin Fields::Fields%405A57A401BB_const.hasinit preserve=no
  //## end Fields::Fields%405A57A401BB_const.hasinit
  //## begin Fields::Fields%405A57A401BB_const.initialization preserve=yes
  //## end Fields::Fields%405A57A401BB_const.initialization
{
  //## begin Fields::Fields%405A57A401BB_const.body preserve=yes
  //## end Fields::Fields%405A57A401BB_const.body
}


Fields::~Fields()
{
  //## begin Fields::~Fields%405A57A401BB_dest.body preserve=yes
	int i;
	Field	*pfield;
	for( i = 0; i < m_vectorField.size(); i++ )
	{
		pfield = m_vectorField[ i ];
		delete pfield;
	}
	m_vectorField.clear();
	m_mapField.clear();
  //## end Fields::~Fields%405A57A401BB_dest.body
}



//## Other Operations (implementation)
void Fields::AddField (const char* szName, const char* szCaption, int nFieldType, int nLength)
{
  //## begin Fields::AddField%405BD6B6030D.body preserve=yes
	Field *pfield = new Field( szName, szCaption, nFieldType, nLength );
	m_vectorField.push_back( pfield );
	m_mapField.insert( MAP_Field::value_type( pfield->GetFieldName(), pfield ) );
  //## end Fields::AddField%405BD6B6030D.body
}

int Fields::Size ()
{
  //## begin Fields::Size%405BDAF40271.body preserve=yes
	return m_vectorField.size();
  //## end Fields::Size%405BDAF40271.body
}

Field& Fields::GetField (int index)
{
  //## begin Fields::GetField%405BD72A02EE.body preserve=yes
	Field *pfield = m_vectorField[ index ];
	return *pfield;
  //## end Fields::GetField%405BD72A02EE.body
}

Field& Fields::GetField (const char* szFieldName)
{
  //## begin Fields::GetField%405BD73B0177.body preserve=yes
	Field *pfield = m_mapField[ szFieldName ];
	return *pfield;
  //## end Fields::GetField%405BD73B0177.body
}

int Fields::GetIndex (const char* szFieldName)
{
  //## begin Fields::GetIndex%405BE4FE0138.body preserve=yes
	int		i;
	for( i = 0; i < m_vectorField.size(); i++ )
	{
		if( strcmp( m_vectorField[ i ]->GetFieldName(), szFieldName ) == 0 )	return i;
	}
	return -1;
  //## end Fields::GetIndex%405BE4FE0138.body
}

void Fields::SetFieldCount (int nCount)
{
  //## begin Fields::SetFieldCount%40A221DE034B.body preserve=yes
	if( nCount >= m_vectorField.size() )
	{
		m_vectorField.reserve( nCount );
	}
  //## end Fields::SetFieldCount%40A221DE034B.body
}

void Fields::ClearMember ()
{
  //## begin Fields::ClearMember%405BD784030D.body preserve=yes
	int		i;
	Field	*pfield;
	for( i = 0; i < m_vectorField.size(); i++ )
	{
		pfield = m_vectorField[ i ];
		delete pfield;
	}
	m_vectorField.clear();
	m_mapField.clear();
  //## end Fields::ClearMember%405BD784030D.body
}

// Additional Declarations
  //## begin Fields%405A57A401BB.declarations preserve=yes
  //## end Fields%405A57A401BB.declarations

//## begin module%405A57A401BB.epilog preserve=yes
//## end module%405A57A401BB.epilog
