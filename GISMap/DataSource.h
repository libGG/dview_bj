//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A768B0257.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A768B0257.cm

//## begin module%405A768B0257.cp preserve=no
//## end module%405A768B0257.cp

//## Module: DataSource%405A768B0257; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\DataSource.h

#ifndef DataSource_h
#define DataSource_h 1

//## begin module%405A768B0257.additionalIncludes preserve=no
//## end module%405A768B0257.additionalIncludes

//## begin module%405A768B0257.includes preserve=yes
//## end module%405A768B0257.includes

#include "DataSet.h"
//## begin module%405A768B0257.additionalDeclarations preserve=yes
#include <map>
using namespace std;
//## end module%405A768B0257.additionalDeclarations


//## begin DataSource%405A768B0257.preface preserve=yes
typedef map< int, DataSet* > MAP_DataSet;
//## end DataSource%405A768B0257.preface

//## Class: DataSource%405A768B0257
//## Category: DataAccess%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class DataSource
{
  //## begin DataSource%405A768B0257.initialDeclarations preserve=yes
  //## end DataSource%405A768B0257.initialDeclarations

  public:
	  int GetUniqueID();
    //## Constructors (generated)
      DataSource();

    //## Destructor (generated)
      ~DataSource();

      //## Operation: CreateDataSet%405BF6B303C8
      DataSet& CreateDataSet (int id, int type, const char* strName);

      //## Operation: Size%405BF7B10128
      int Size ();

      //## Operation: GetDataSet%405BF79C02BF
      DataSet& GetDataSet (int id);

      //## Operation: GetFirstDataSet%405BF77F0167
      DataSet* GetFirstDataSet ();

      //## Operation: GetNextDataSet%405BF78D0203
      DataSet* GetNextDataSet ();

  protected:
    // Additional Protected Declarations
      //## begin DataSource%405A768B0257.protected preserve=yes
      //## end DataSource%405A768B0257.protected

  private:
    // Additional Private Declarations
      //## begin DataSource%405A768B0257.private preserve=yes
      //## end DataSource%405A768B0257.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_mapDataSet%405BF6F800CB
      //## begin DataSource::m_mapDataSet%405BF6F800CB.attr preserve=no  private: MAP_DataSet {U} 
      MAP_DataSet m_mapDataSet;
      //## end DataSource::m_mapDataSet%405BF6F800CB.attr

      //## Attribute: m_curIterator%405BF7B90222
      //## begin DataSource::m_curIterator%405BF7B90222.attr preserve=no  private: MAP_DataSet::iterator {U} 
      MAP_DataSet::iterator m_curIterator;
      //## end DataSource::m_curIterator%405BF7B90222.attr

};

//## begin DataSource%405A768B0257.postscript preserve=yes
//## end DataSource%405A768B0257.postscript

// Class DataSource 

//## begin module%405A768B0257.epilog preserve=yes
//## end module%405A768B0257.epilog


#endif
