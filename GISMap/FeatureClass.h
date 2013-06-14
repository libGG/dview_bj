//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A57DC00DF.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A57DC00DF.cm

//## begin module%405A57DC00DF.cp preserve=no
//## end module%405A57DC00DF.cp

//## Module: FeatureClass%405A57DC00DF; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\FeatureClass.h

#ifndef FeatureClass_h
#define FeatureClass_h 1

//## begin module%405A57DC00DF.additionalIncludes preserve=no
//## end module%405A57DC00DF.additionalIncludes

//## begin module%405A57DC00DF.includes preserve=yes
//## end module%405A57DC00DF.includes

#include "Table.h"
#include "Feature.h"
//## begin module%405A57DC00DF.additionalDeclarations preserve=yes
//## end module%405A57DC00DF.additionalDeclarations


//## begin FeatureClass%405A57DC00DF.preface preserve=yes
//## end FeatureClass%405A57DC00DF.preface

//## Class: FeatureClass%405A57DC00DF
//## Category: DataAccess%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class FeatureClass : public Table  //## Inherits: <unnamed>%405A5BD50363
{
  //## begin FeatureClass%405A57DC00DF.initialDeclarations preserve=yes
  //## end FeatureClass%405A57DC00DF.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: FeatureClass%4067E86D0128
      FeatureClass (int id, int type, const char *strName, DataSource* pDataSource = 0);

    //## Destructor (generated)
      ~FeatureClass();

      //## Operation: GetName%405E8588026F
      const char* GetName ();

      //## Operation: GetBound%405D4612000F
      void GetBound (double& minx, double& miny, double& w, double& h);

      //## Operation: CalculateBound%405D466200AB
      void CalculateBound ();

      //## Operation: GetFeatureSize%405BE720038A
      int GetFeatureSize ();

      //## Operation: GetFirstFeature%405BE70C033C
      Feature* GetFirstFeature ();

      //## Operation: GetNextFeature%405BE7160251
      Feature* GetNextFeature ();

      //## Operation: GetFeature%405BE72B038A
      Feature* GetFeature (int fid);

    // Additional Public Declarations
      //## begin FeatureClass%405A57DC00DF.public preserve=yes
      //## end FeatureClass%405A57DC00DF.public

  protected:
    // Additional Protected Declarations
      //## begin FeatureClass%405A57DC00DF.protected preserve=yes
      //## end FeatureClass%405A57DC00DF.protected

  private:
    // Additional Private Declarations
      //## begin FeatureClass%405A57DC00DF.private preserve=yes
      //## end FeatureClass%405A57DC00DF.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_dMinx%405D45CF0242
      //## begin FeatureClass::m_dMinx%405D45CF0242.attr preserve=no  private: double {U} 
      double m_dMinx;
      //## end FeatureClass::m_dMinx%405D45CF0242.attr

      //## Attribute: m_dMiny%405D45E7009C
      //## begin FeatureClass::m_dMiny%405D45E7009C.attr preserve=no  private: double {U} 
      double m_dMiny;
      //## end FeatureClass::m_dMiny%405D45E7009C.attr

      //## Attribute: m_dWidth%405D45EF02EE
      //## begin FeatureClass::m_dWidth%405D45EF02EE.attr preserve=no  private: double {U} 
      double m_dWidth;
      //## end FeatureClass::m_dWidth%405D45EF02EE.attr

      //## Attribute: m_dHeight%405D45F7037A
      //## begin FeatureClass::m_dHeight%405D45F7037A.attr preserve=no  private: double {U} 
      double m_dHeight;
      //## end FeatureClass::m_dHeight%405D45F7037A.attr

};

//## begin FeatureClass%405A57DC00DF.postscript preserve=yes
//## end FeatureClass%405A57DC00DF.postscript

// Class FeatureClass 

//## begin module%405A57DC00DF.epilog preserve=yes
//## end module%405A57DC00DF.epilog


#endif
