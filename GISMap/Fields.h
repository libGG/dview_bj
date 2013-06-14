//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A57A401BB.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A57A401BB.cm

//## begin module%405A57A401BB.cp preserve=no
//## end module%405A57A401BB.cp

//## Module: Fields%405A57A401BB; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\Fields.h

#ifndef Fields_h
#define Fields_h 1

//## begin module%405A57A401BB.additionalIncludes preserve=no
//## end module%405A57A401BB.additionalIncludes

//## begin module%405A57A401BB.includes preserve=yes
//## end module%405A57A401BB.includes

#include "Field.h"
//## begin module%405A57A401BB.additionalDeclarations preserve=yes
#include <map>
#include <vector>
#include <string>
using namespace std;
typedef vector< Field * >				VECTOR_Field;
typedef map< string, Field* >			MAP_Field;
//## end module%405A57A401BB.additionalDeclarations


//## begin Fields%405A57A401BB.preface preserve=yes
//## end Fields%405A57A401BB.preface

//## Class: Fields%405A57A401BB
//## Category: DataAccess%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class Fields 
{
  //## begin Fields%405A57A401BB.initialDeclarations preserve=yes
  //## end Fields%405A57A401BB.initialDeclarations

  public:
    //## Constructors (generated)
      Fields();

    //## Destructor (generated)
      ~Fields();


    //## Other Operations (specified)
      //## Operation: AddField%405BD6B6030D
      void AddField (const char* szName, const char* szCaption, int nFieldType, int nLength = 0);

      //## Operation: Size%405BDAF40271
      int Size ();

      //## Operation: GetField%405BD72A02EE
      Field& GetField (int index);

      //## Operation: GetField%405BD73B0177
      Field& GetField (const char* szFieldName);

      //## Operation: GetIndex%405BE4FE0138
      int GetIndex (const char* szFieldName);

      //## Operation: SetFieldCount%40A221DE034B
      void SetFieldCount (int nCount);

    // Additional Public Declarations
      //## begin Fields%405A57A401BB.public preserve=yes
      //## end Fields%405A57A401BB.public

  protected:
    // Additional Protected Declarations
      //## begin Fields%405A57A401BB.protected preserve=yes
      //## end Fields%405A57A401BB.protected

  private:

    //## Other Operations (specified)
      //## Operation: ClearMember%405BD784030D
      void ClearMember ();

    // Additional Private Declarations
      //## begin Fields%405A57A401BB.private preserve=yes
      //## end Fields%405A57A401BB.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_mapField%405BD60C035B
      //## begin Fields::m_mapField%405BD60C035B.attr preserve=no  private: MAP_Field {U} 
      MAP_Field m_mapField;
      //## end Fields::m_mapField%405BD60C035B.attr

      //## Attribute: m_vectorField%405BD629003E
      //## begin Fields::m_vectorField%405BD629003E.attr preserve=no  private: VECTOR_Field {U} 
      VECTOR_Field m_vectorField;
      //## end Fields::m_vectorField%405BD629003E.attr

    // Data Members for Associations

      //## Association: DataAccess::SDE::<unnamed>%405A5BBE014D
      //## Role: Fields::<the_Field>%405A5BBE0338
      //## begin Fields::<the_Field>%405A5BBE0338.role preserve=no  public: Field { -> UHgN}
      //## end Fields::<the_Field>%405A5BBE0338.role

    // Additional Implementation Declarations
      //## begin Fields%405A57A401BB.implementation preserve=yes
      //## end Fields%405A57A401BB.implementation

};

//## begin Fields%405A57A401BB.postscript preserve=yes
//## end Fields%405A57A401BB.postscript

// Class Fields 

//## begin module%405A57A401BB.epilog preserve=yes
//## end module%405A57A401BB.epilog


#endif
