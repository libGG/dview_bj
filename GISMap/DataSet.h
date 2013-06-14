//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A57F5033E.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A57F5033E.cm

//## begin module%405A57F5033E.cp preserve=no
//## end module%405A57F5033E.cp

//## Module: DataSet%405A57F5033E; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\DataSet.h

#ifndef DataSet_h
#define DataSet_h 1

//## begin module%405A57F5033E.additionalIncludes preserve=no
//## end module%405A57F5033E.additionalIncludes

//## begin module%405A57F5033E.includes preserve=yes
//## end module%405A57F5033E.includes

//## begin module%405A57F5033E.additionalDeclarations preserve=yes
//## end module%405A57F5033E.additionalDeclarations


//## begin DataSet%405A57F5033E.preface preserve=yes
class DataSource;
enum DATASETTYPE
{
	POINTDATASET = 0,
	LINEDATASET = 1,
	POLYGONDATASET = 2,
	ANNOTATIONDATASET = 3
};
//## end DataSet%405A57F5033E.preface

//## Class: DataSet%405A57F5033E
//## Category: DataAccess%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class DataSet 
{
  //## begin DataSet%405A57F5033E.initialDeclarations preserve=yes
  //## end DataSet%405A57F5033E.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: DataSet%40A03FD803C8
      DataSet (int id, int type, const char* strName, DataSource* pDataSource);

    //## Destructor (generated)
      ~DataSet();


    //## Other Operations (specified)
      //## Operation: GetID%405BEFC10186
      int GetID ();

      //## Operation: GetType%405A616B01D8
      DATASETTYPE GetType ();

      //## Operation: GetName%40A1A56703B9
      const char * GetName ();

      //## Operation: GetOwnerDataSource%405BF0120186
      DataSource* GetOwnerDataSource ();

    // Additional Public Declarations
      //## begin DataSet%405A57F5033E.public preserve=yes
      //## end DataSet%405A57F5033E.public

  protected:
    // Additional Protected Declarations
      //## begin DataSet%405A57F5033E.protected preserve=yes
      //## end DataSet%405A57F5033E.protected

  private:
    // Additional Private Declarations
      //## begin DataSet%405A57F5033E.private preserve=yes
      //## end DataSet%405A57F5033E.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_nID%405BEFFE032C
      //## begin DataSet::m_nID%405BEFFE032C.attr preserve=no  private: int {U} 
      int m_nID;
      //## end DataSet::m_nID%405BEFFE032C.attr

      //## Attribute: m_nType%405BF1540138
      //## begin DataSet::m_nType%405BF1540138.attr preserve=no  private: DATASETTYPE {U} 
      DATASETTYPE m_nType;
      //## end DataSet::m_nType%405BF1540138.attr

      //## Attribute: m_pOwnerDataSource%405BEFDB038A
      //## begin DataSet::m_pOwnerDataSource%405BEFDB038A.attr preserve=no  private: DataSource* {U} 0
      DataSource* m_pOwnerDataSource;
      //## end DataSet::m_pOwnerDataSource%405BEFDB038A.attr

      //## Attribute: m_szName%40A081ED02BF
      //## begin DataSet::m_szName%40A081ED02BF.attr preserve=no  private: char[ 255 ] {U} 
      char *m_szName;
      //## end DataSet::m_szName%40A081ED02BF.attr

    // Data Members for Associations

      //## Association: DataAccess::DAE::<unnamed>%40A0415201E4
      //## Role: DataSet::<the_DataSource>%40A041530232
      //## begin DataSet::<the_DataSource>%40A041530232.role preserve=no  public: DataSource { -> UHgN}
      //## end DataSet::<the_DataSource>%40A041530232.role

    // Additional Implementation Declarations
      //## begin DataSet%405A57F5033E.implementation preserve=yes
      //## end DataSet%405A57F5033E.implementation

};

//## begin DataSet%405A57F5033E.postscript preserve=yes
//## end DataSet%405A57F5033E.postscript

// Class DataSet 

//## begin module%405A57F5033E.epilog preserve=yes
//## end module%405A57F5033E.epilog


#endif
