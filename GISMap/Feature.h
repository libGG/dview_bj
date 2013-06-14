//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A575E01E3.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A575E01E3.cm

//## begin module%405A575E01E3.cp preserve=no
//## end module%405A575E01E3.cp

//## Module: Feature%405A575E01E3; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\Feature.h

#ifndef Feature_h
#define Feature_h 1

//## begin module%405A575E01E3.additionalIncludes preserve=no
//## end module%405A575E01E3.additionalIncludes

//## begin module%405A575E01E3.includes preserve=yes
//## end module%405A575E01E3.includes

#include "Row.h"
//## begin module%405A575E01E3.additionalDeclarations preserve=yes
//## end module%405A575E01E3.additionalDeclarations


//## begin Feature%405A575E01E3.preface preserve=yes
class Geometry;
//## end Feature%405A575E01E3.preface

//## Class: Feature%405A575E01E3
//## Category: DataAccess%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class Feature : public Row  //## Inherits: <unnamed>%405A5C070166
{
  //## begin Feature%405A575E01E3.initialDeclarations preserve=yes
  //## end Feature%405A575E01E3.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: Feature%405BE04F0251
      Feature (int fid, int subType, Fields* pFields);

    //## Destructor (generated)
      ~Feature();


    //## Other Operations (specified)
      //## Operation: GetFID%405BE00E033C
      int GetFID ();

      //## Operation: GetSubType%405BE01302DE
      int GetSubType ();

      //## Operation: GetBound%405D80D70261
      void GetBound (double& minx, double& miny, double& w, double& h);

      //## Operation: SetBound%405D81010167
      void SetBound (double minx, double miny, double w, double h);

      //## Operation: GetGeometry%405BE01A029F
      Geometry& GetGeometry ();

      //## Operation: SetGeometry%405BE28D0000
      void SetGeometry (Geometry* pGeometry);

  protected:
    // Additional Protected Declarations
      //## begin Feature%405A575E01E3.protected preserve=yes
      //## end Feature%405A575E01E3.protected

  private:
    // Additional Private Declarations
      //## begin Feature%405A575E01E3.private preserve=yes
      //## end Feature%405A575E01E3.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_nSubType%405BDFC001B5
      //## begin Feature::m_nSubType%405BDFC001B5.attr preserve=no  private: int {U} 
      int m_nSubType;
      //## end Feature::m_nSubType%405BDFC001B5.attr

      //## Attribute: m_dMinx%405D80DC033C
      //## begin Feature::m_dMinx%405D80DC033C.attr preserve=no  private: double {U} 
      double m_dMinx;
      //## end Feature::m_dMinx%405D80DC033C.attr

      //## Attribute: m_dMiny%405D80E20109
      //## begin Feature::m_dMiny%405D80E20109.attr preserve=no  private: double {U} 
      double m_dMiny;
      //## end Feature::m_dMiny%405D80E20109.attr

      //## Attribute: m_dWidth%405D80E700CB
      //## begin Feature::m_dWidth%405D80E700CB.attr preserve=no  private: double {U} 
      double m_dWidth;
      //## end Feature::m_dWidth%405D80E700CB.attr

      //## Attribute: m_dHeight%405D80EE007D
      //## begin Feature::m_dHeight%405D80EE007D.attr preserve=no  private: double {U} 
      double m_dHeight;
      //## end Feature::m_dHeight%405D80EE007D.attr

      //## Attribute: m_pGeometry%405BDFCB0157
      //## begin Feature::m_pGeometry%405BDFCB0157.attr preserve=no  private: Geometry* {U} 0
      Geometry* m_pGeometry;
      //## end Feature::m_pGeometry%405BDFCB0157.attr
};

//## begin Feature%405A575E01E3.postscript preserve=yes
//## end Feature%405A575E01E3.postscript

// Class Feature 

//## begin module%405A575E01E3.epilog preserve=yes
//## end module%405A575E01E3.epilog


#endif
