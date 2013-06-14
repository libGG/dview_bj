//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A532D009F.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A532D009F.cm

//## begin module%405A532D009F.cp preserve=no
//## end module%405A532D009F.cp

//## Module: FieldValue%405A532D009F; Pseudo Package specification
//## Source file: E:\egis\code\数据访问模块\FieldValue.h

#ifndef FieldValue_h
#define FieldValue_h 1

//## begin module%405A532D009F.additionalIncludes preserve=no
//## end module%405A532D009F.additionalIncludes

//## begin module%405A532D009F.includes preserve=yes
//## end module%405A532D009F.includes

//## begin module%405A532D009F.additionalDeclarations preserve=yes
//## end module%405A532D009F.additionalDeclarations


//## begin FieldValue%405A532D009F.preface preserve=yes
//## end FieldValue%405A532D009F.preface

//## Class: FieldValue%405A532D009F
//	《说明》：一个字段的值
//## Category: 数据访问模块%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class FieldValue 
{
  //## begin FieldValue%405A532D009F.initialDeclarations preserve=yes
  //## end FieldValue%405A532D009F.initialDeclarations

  public:
    //## Constructors (generated)
      FieldValue();

    //## Destructor (generated)
      ~FieldValue();


    //## Other Operations (specified)
      //## Operation: GetInt%405BD268007D
      int GetInt ();

      //## Operation: SetInt%405BD2FD035B
      void SetInt (int value);

      //## Operation: GetDouble%405BD2AF02BF
      double GetDouble ();

      //## Operation: SetDouble%405BD2F1003E
      void SetDouble (double value);

      //## Operation: GetString%405BD2B70196
      const char* GetString ();

      //## Operation: SetString%405BD2DE01C5
      void SetString (const char* value);

    // Additional Public Declarations
      //## begin FieldValue%405A532D009F.public preserve=yes
      //## end FieldValue%405A532D009F.public

  protected:
    // Additional Protected Declarations
      //## begin FieldValue%405A532D009F.protected preserve=yes
      //## end FieldValue%405A532D009F.protected

  private:
    // Additional Private Declarations
      //## begin FieldValue%405A532D009F.private preserve=yes
      //## end FieldValue%405A532D009F.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_pValue%405BD22E02CE
      //## begin FieldValue::m_pValue%405BD22E02CE.attr preserve=no  private: char* {U} 0
      char* m_pValue;
      //## end FieldValue::m_pValue%405BD22E02CE.attr

    // Additional Implementation Declarations
      //## begin FieldValue%405A532D009F.implementation preserve=yes
      //## end FieldValue%405A532D009F.implementation

};

//## begin FieldValue%405A532D009F.postscript preserve=yes
//## end FieldValue%405A532D009F.postscript

// Class FieldValue 

//## begin module%405A532D009F.epilog preserve=yes
//## end module%405A532D009F.epilog


#endif
