//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A57F5033E.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A57F5033E.cm

//## begin module%405A57F5033E.cp preserve=no
//## end module%405A57F5033E.cp

//## Module: DataSet%405A57F5033E; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\DataSet.cpp

//## begin module%405A57F5033E.additionalIncludes preserve=no
//## end module%405A57F5033E.additionalIncludes

//## begin module%405A57F5033E.includes preserve=yes
//## end module%405A57F5033E.includes

#include "DataSet.h"
//## begin module%405A57F5033E.additionalDeclarations preserve=yes
#include "string.h"
//## end module%405A57F5033E.additionalDeclarations


// Class DataSet 








DataSet::DataSet (int id, int type, const char* strName, DataSource* pDataSource)
  //## begin DataSet::DataSet%40A03FD803C8.hasinit preserve=no
      : m_pOwnerDataSource(0)
  //## end DataSet::DataSet%40A03FD803C8.hasinit
  //## begin DataSet::DataSet%40A03FD803C8.initialization preserve=yes
  //## end DataSet::DataSet%40A03FD803C8.initialization
{
  //## begin DataSet::DataSet%40A03FD803C8.body preserve=yes
	m_szName = 0;
	m_nID = id;
	m_nType = (DATASETTYPE)type;
	m_pOwnerDataSource = pDataSource;
	int len = strlen( strName );
	if( len != 0 )
	{
		m_szName = new char[ len + 1 ];
		strcpy( m_szName, strName );
	}
  //## end DataSet::DataSet%40A03FD803C8.body
}


DataSet::~DataSet()
{
  //## begin DataSet::~DataSet%405A57F5033E_dest.body preserve=yes
	if( m_szName != 0 )	delete []m_szName;
  //## end DataSet::~DataSet%405A57F5033E_dest.body
}



//## Other Operations (implementation)
int DataSet::GetID ()
{
  //## begin DataSet::GetID%405BEFC10186.body preserve=yes
	return m_nID;
  //## end DataSet::GetID%405BEFC10186.body
}

DATASETTYPE DataSet::GetType ()
{
  //## begin DataSet::GetType%405A616B01D8.body preserve=yes
	return m_nType;
  //## end DataSet::GetType%405A616B01D8.body
}

const char * DataSet::GetName ()
{
  //## begin DataSet::GetName%40A1A56703B9.body preserve=yes
	return m_szName;
  //## end DataSet::GetName%40A1A56703B9.body
}

DataSource* DataSet::GetOwnerDataSource ()
{
  //## begin DataSet::GetOwnerDataSource%405BF0120186.body preserve=yes
	return m_pOwnerDataSource;
  //## end DataSet::GetOwnerDataSource%405BF0120186.body
}

// Additional Declarations
  //## begin DataSet%405A57F5033E.declarations preserve=yes
  //## end DataSet%405A57F5033E.declarations

//## begin module%405A57F5033E.epilog preserve=yes
//## end module%405A57F5033E.epilog
