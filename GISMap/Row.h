//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A573602DF.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A573602DF.cm

//## begin module%405A573602DF.cp preserve=no
//## end module%405A573602DF.cp

//## Module: Row%405A573602DF; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\Row.h

#ifndef Row_h
#define Row_h 1

//## begin module%405A573602DF.additionalIncludes preserve=no
//## end module%405A573602DF.additionalIncludes

//## begin module%405A573602DF.includes preserve=yes
//## end module%405A573602DF.includes

#include "FieldValue.h"
//## begin module%405A573602DF.additionalDeclarations preserve=yes
//## end module%405A573602DF.additionalDeclarations


//## begin Row%405A573602DF.preface preserve=yes
class Fields;
//## end Row%405A573602DF.preface

//## Class: Row%405A573602DF
//## Category: DataAccess%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class Row 
{
  //## begin Row%405A573602DF.initialDeclarations preserve=yes
  //## end Row%405A573602DF.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: Row%405BE25D037A
      Row (int id, Fields* pFields);

    //## Destructor (generated)
      ~Row();


    //## Other Operations (specified)
      //## Operation: GetID%405E6905034B
      int GetID ();

      //## Operation: GetFields%405BE4BD03A9
      Fields& GetFields ();

      //## Operation: GetFieldValue%405BE43600BB
      FieldValue& GetFieldValue (int index);

      //## Operation: GetFieldValue%405BE487008C
      FieldValue& GetFieldValue (const char* szFieldName);

    // Additional Public Declarations
      //## begin Row%405A573602DF.public preserve=yes
      //## end Row%405A573602DF.public

  protected:
    // Additional Protected Declarations
      int m_nID;
      //## begin Row%405A573602DF.protected preserve=yes
      //## end Row%405A573602DF.protected

  private:
    // Additional Private Declarations
      //## begin Row%405A573602DF.private preserve=yes
      //## end Row%405A573602DF.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_pFields%405BDF020000
      //## begin Row::m_pFields%405BDF020000.attr preserve=no  private: Fields* {U} 0
      Fields* m_pFields;
      //## end Row::m_pFields%405BDF020000.attr

      //## Attribute: m_nID%405E599F00CB
      //## begin Row::m_nID%405E599F00CB.attr preserve=no  protected: int {U} 
      //## end Row::m_nID%405E599F00CB.attr

      //## Attribute: m_pArrayValue%405BE23D01E4
      //## begin Row::m_pArrayValue%405BE23D01E4.attr preserve=no  private: FieldValue* {U} 0
      FieldValue* m_pArrayValue;
      //## end Row::m_pArrayValue%405BE23D01E4.attr

    // Data Members for Associations

      //## Association: DataAccess::SDE::<unnamed>%405A5B71034B
      //## Role: Row::<the_FieldValue>%405A5B720112
      //## begin Row::<the_FieldValue>%405A5B720112.role preserve=no  public: FieldValue { -> UHgN}
      //## end Row::<the_FieldValue>%405A5B720112.role

    // Additional Implementation Declarations
      //## begin Row%405A573602DF.implementation preserve=yes
      //## end Row%405A573602DF.implementation

};

//## begin Row%405A573602DF.postscript preserve=yes
//## end Row%405A573602DF.postscript

// Class Row 

//## begin module%405A573602DF.epilog preserve=yes
//## end module%405A573602DF.epilog


#endif
