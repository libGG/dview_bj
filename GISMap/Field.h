//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A578700DD.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A578700DD.cm

//## begin module%405A578700DD.cp preserve=no
//## end module%405A578700DD.cp

//## Module: Field%405A578700DD; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\Field.h

#ifndef Field_h
#define Field_h 1

//## begin module%405A578700DD.additionalIncludes preserve=no
//## end module%405A578700DD.additionalIncludes

//## begin module%405A578700DD.includes preserve=yes
//## end module%405A578700DD.includes

#include "FieldValue.h"
//## begin module%405A578700DD.additionalDeclarations preserve=yes
//## end module%405A578700DD.additionalDeclarations


//## begin Field%405A578700DD.preface preserve=yes
enum FIELDTYPE
{
	FIELD_INT = 1,
    FIELD_DOUBLE = 2,
    FIELD_STRING = 3
};
//## end Field%405A578700DD.preface

//## Class: Field%405A578700DD
//	《说明》：单个字段的描述信息。
//	包括：字段的名称、字段的类型、字段的长度和字段的值
//## Category: DataAccess%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class Field 
{
  //## begin Field%405A578700DD.initialDeclarations preserve=yes
	enum { FIELDNAMELEN = 40, FIELDCAPTIONLEN = 40 };
  //## end Field%405A578700DD.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: Field%405BD4B4038A
      Field (const char* szName, const char* szCaption, int nFieldType, int nLength);

    //## Destructor (generated)
      ~Field();


    //## Other Operations (specified)
      //## Operation: GetFieldName%405BD4E901A5
      const char* GetFieldName ();

      //## Operation: GetFieldCaption%405BD4F202CE
      const char* GetFieldCaption ();

      //## Operation: SetFieldCaption%405BD503037A
      void SetFieldCaption (const char* szCaption);

      //## Operation: GetFieldType%405BD50C029F
      FIELDTYPE GetFieldType ();

      //## Operation: GetFieldLength%405BD5190399
      int GetFieldLength ();

      //## Operation: GetFieldValue%405BD82701C5
      FieldValue& GetFieldValue ();

    // Additional Public Declarations
      //## begin Field%405A578700DD.public preserve=yes
      //## end Field%405A578700DD.public

  protected:
    // Additional Protected Declarations
      //## begin Field%405A578700DD.protected preserve=yes
      //## end Field%405A578700DD.protected

  private:
    // Additional Private Declarations
      //## begin Field%405A578700DD.private preserve=yes
      //## end Field%405A578700DD.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_szFieldName%405BD4350177
      //## begin Field::m_szFieldName%405BD4350177.attr preserve=no  private: char[FIELDNAMELEN] {U} 
      char m_szFieldName[FIELDNAMELEN];
      //## end Field::m_szFieldName%405BD4350177.attr

      //## Attribute: m_szFieldCaption%405BD440033C
      //## begin Field::m_szFieldCaption%405BD440033C.attr preserve=no  private: char[FIELDCAPTIONLEN] {U} 
      char m_szFieldCaption[FIELDCAPTIONLEN];
      //## end Field::m_szFieldCaption%405BD440033C.attr

      //## Attribute: m_nFieldType%405BD44D000F
      //## begin Field::m_nFieldType%405BD44D000F.attr preserve=no  private: FIELDTYPE {U} 
      FIELDTYPE m_nFieldType;
      //## end Field::m_nFieldType%405BD44D000F.attr

      //## Attribute: m_nFieldLength%405BD49C0109
      //## begin Field::m_nFieldLength%405BD49C0109.attr preserve=no  private: int {U} 
      int m_nFieldLength;
      //## end Field::m_nFieldLength%405BD49C0109.attr

      //## Attribute: m_oFieldValue%405BD804033C
      //## begin Field::m_oFieldValue%405BD804033C.attr preserve=no  private: FieldValue {U} 
      FieldValue m_oFieldValue;
      //## end Field::m_oFieldValue%405BD804033C.attr

    // Data Members for Associations

      //## Association: DataAccess::SDE::<unnamed>%406017520290
      //## Role: Field::<the_FieldValue>%406017530232
      //## begin Field::<the_FieldValue>%406017530232.role preserve=no  public: FieldValue { -> UHgPN}
      //## end Field::<the_FieldValue>%406017530232.role

      //## Association: DataAccess::SDE::<unnamed>%4060282403B9
      //## Role: Field::<the_FieldValue>%40602826002E
      //## begin Field::<the_FieldValue>%40602826002E.role preserve=no  public: FieldValue { -> UHgN}
      //## end Field::<the_FieldValue>%40602826002E.role

    // Additional Implementation Declarations
      //## begin Field%405A578700DD.implementation preserve=yes
      //## end Field%405A578700DD.implementation

};

//## begin Field%405A578700DD.postscript preserve=yes
//## end Field%405A578700DD.postscript

// Class Field 

//## begin module%405A578700DD.epilog preserve=yes
//## end module%405A578700DD.epilog


#endif
