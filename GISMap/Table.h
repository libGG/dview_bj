//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A577E01AD.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A577E01AD.cm

//## begin module%405A577E01AD.cp preserve=no
//## end module%405A577E01AD.cp

//## Module: Table%405A577E01AD; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\Table.h

#ifndef Table_h
#define Table_h 1

//## begin module%405A577E01AD.additionalIncludes preserve=no
//## end module%405A577E01AD.additionalIncludes

//## begin module%405A577E01AD.includes preserve=yes
//## end module%405A577E01AD.includes

#include "DataSet.h"
#include "Fields.h"
#include "Row.h"
//## begin module%405A577E01AD.additionalDeclarations preserve=yes
//## end module%405A577E01AD.additionalDeclarations


//## begin Table%405A577E01AD.preface preserve=yes
typedef map< int, Row* > MAP_Row;
typedef vector< Row* > VECTOR_Row;
//## end Table%405A577E01AD.preface

//## Class: Table%405A577E01AD
//## Category: DataAccess%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class Table : public DataSet  //## Inherits: <unnamed>%405A5BAD00F8
{
  //## begin Table%405A577E01AD.initialDeclarations preserve=yes
  //## end Table%405A577E01AD.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: Table%405D431201C5
      Table (int id, int type, DataSource* pDataSource = 0, const char *strName = 0);

    //## Destructor (generated)
      ~Table();


    //## Other Operations (specified)
      //## Operation: GetTableName%405FEEA4036B
      const char* GetTableName ();

      //## Operation: GetFields%405BDED301A5
      Fields& GetFields ();

      //## Operation: Size%405BE55B0128
      int Size ();

      //## Operation: GetRow%405BE576031C
      Row* GetRow (int id);

      //## Operation: GetFirst%405E830E0136
      Row* GetFirst ();

      //## Operation: GetNext%405E831702CD
      Row* GetNext ();

      //## Operation: AddRow%40A1D37203C8
      void AddRow (Row* pRow);

    // Additional Public Declarations
      //## begin Table%405A577E01AD.public preserve=yes
      //## end Table%405A577E01AD.public

  protected:
    // Additional Protected Declarations
      //## begin Table%405A577E01AD.protected preserve=yes
      //## end Table%405A577E01AD.protected
      //## Attribute: m_mapRow%405BE3F801C5
      //## begin Table::m_mapRow%405BE3F801C5.attr preserve=no  protected: MAP_Row {U} 
      MAP_Row m_mapRow;
      //## end Table::m_mapRow%405BE3F801C5.attr

      //## Attribute: m_curRow%40651FC40222
      //## begin Table::m_curRow%40651FC40222.attr preserve=no  protected: MAP_Row::iterator {U} 
      MAP_Row::iterator m_curRow;
      //## end Table::m_curRow%40651FC40222.attr

  private:
    // Additional Private Declarations
      //## begin Table%405A577E01AD.private preserve=yes
      //## end Table%405A577E01AD.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_strName%405FEE8B0203
      //## begin Table::m_strName%405FEE8B0203.attr preserve=no  private: char* {U} 
      char* m_strName;
      //## end Table::m_strName%405FEE8B0203.attr

      //## Attribute: m_pFields%405BDDF20138
      //## begin Table::m_pFields%405BDDF20138.attr preserve=no  private: Fields* {U} 0
      Fields* m_pFields;
      //## end Table::m_pFields%405BDDF20138.attr


    // Data Members for Associations

      //## Association: DataAccess::SDE::<unnamed>%405A5BC40354
      //## Role: Table::<the_Fields>%405A5BC50125
      //## begin Table::<the_Fields>%405A5BC50125.role preserve=no  public: Fields { -> UHgN}
      //## end Table::<the_Fields>%405A5BC50125.role

      //## Association: DataAccess::SDE::<unnamed>%406525F30156
      //## Role: Table::<the_Row>%406525F4033B
      //## begin Table::<the_Row>%406525F4033B.role preserve=no  public: Row { -> UHgN}
      //## end Table::<the_Row>%406525F4033B.role

    // Additional Implementation Declarations
      //## begin Table%405A577E01AD.implementation preserve=yes
      //## end Table%405A577E01AD.implementation

};

//## begin Table%405A577E01AD.postscript preserve=yes
//## end Table%405A577E01AD.postscript

// Class Table 

//## begin module%405A577E01AD.epilog preserve=yes
//## end module%405A577E01AD.epilog


#endif
