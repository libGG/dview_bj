//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A577E01AD.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A577E01AD.cm

//## begin module%405A577E01AD.cp preserve=no
//## end module%405A577E01AD.cp

//## Module: Table%405A577E01AD; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\Table.cpp

//## begin module%405A577E01AD.additionalIncludes preserve=no
//## end module%405A577E01AD.additionalIncludes

//## begin module%405A577E01AD.includes preserve=yes
//## end module%405A577E01AD.includes

#include "Table.h"
//## begin module%405A577E01AD.additionalDeclarations preserve=yes
//## end module%405A577E01AD.additionalDeclarations


// Class Table 







Table::Table (int id, int type, DataSource* pDataSource, const char *strName)
  //## begin Table::Table%405D431201C5.hasinit preserve=no
      : m_pFields(0)
  //## end Table::Table%405D431201C5.hasinit
  //## begin Table::Table%405D431201C5.initialization preserve=yes
  ,DataSet( id, type, strName, pDataSource ) 
  //## end Table::Table%405D431201C5.initialization
{
  //## begin Table::Table%405D431201C5.body preserve=yes
	m_strName = new char[ strlen( strName ) + 1 ];
	strcpy( m_strName, strName );
	m_curRow = 0;
  //## end Table::Table%405D431201C5.body
}


Table::~Table()
{
  //## begin Table::~Table%405A577E01AD_dest.body preserve=yes
	delete []m_strName;
	m_strName = 0 ;

	if( m_pFields != 0 ) 
	{
		delete m_pFields;
		m_pFields = 0 ;
	}

	Row * pRow;
	for( m_curRow = m_mapRow.begin(); m_curRow != m_mapRow.end(); m_curRow++ )
	{
		pRow = ( Row * )(*m_curRow).second;
		delete pRow;
		(*m_curRow).second = 0;
	}
	m_mapRow.clear();
  //## end Table::~Table%405A577E01AD_dest.body
}



//## Other Operations (implementation)
const char* Table::GetTableName ()
{
  //## begin Table::GetTableName%405FEEA4036B.body preserve=yes
	return m_strName;
  //## end Table::GetTableName%405FEEA4036B.body
}

Fields& Table::GetFields ()
{
  //## begin Table::GetFields%405BDED301A5.body preserve=yes
	if( m_pFields == 0 )
	{
		m_pFields = new Fields();
	}
	return *m_pFields;
  //## end Table::GetFields%405BDED301A5.body
}

int Table::Size ()
{
  //## begin Table::Size%405BE55B0128.body preserve=yes
	return m_mapRow.size();
  //## end Table::Size%405BE55B0128.body
}

Row* Table::GetRow (int id)
{
  //## begin Table::GetRow%405BE576031C.body preserve=yes
	return m_mapRow[ id ];
  //## end Table::GetRow%405BE576031C.body
}

Row* Table::GetFirst ()
{
  //## begin Table::GetFirst%405E830E0136.body preserve=yes
	m_curRow = m_mapRow.begin();

	if( m_curRow == m_mapRow.end() ) return 0;
	else
		return (Row*)(*m_curRow).second;
  //## end Table::GetFirst%405E830E0136.body
}

Row* Table::GetNext ()
{
  //## begin Table::GetNext%405E831702CD.body preserve=yes
	m_curRow++;
	if( m_curRow == m_mapRow.end() ) 
	{
		m_curRow--;
		return 0;
	}
	else	return (Row*)(*m_curRow).second;
  //## end Table::GetNext%405E831702CD.body
}

void Table::AddRow (Row* pRow)
{
  //## begin Table::AddRow%40A1D37203C8.body preserve=yes
	m_mapRow.insert( MAP_Row::value_type( pRow->GetID(), pRow ) );
  //## end Table::AddRow%40A1D37203C8.body
}

// Additional Declarations
  //## begin Table%405A577E01AD.declarations preserve=yes
  //## end Table%405A577E01AD.declarations

//## begin module%405A577E01AD.epilog preserve=yes
//## end module%405A577E01AD.epilog
