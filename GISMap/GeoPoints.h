//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%4070026A0236.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%4070026A0236.cm

//## begin module%4070026A0236.cp preserve=no
//## end module%4070026A0236.cp

//## Module: GeoPoints%4070026A0236; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\GEOO\GeoPoints.h

#ifndef GeoPoints_h
#define GeoPoints_h 1

//## begin module%4070026A0236.additionalIncludes preserve=no
//## end module%4070026A0236.additionalIncludes

//## begin module%4070026A0236.includes preserve=yes
#include "geopoint.h"
//## end module%4070026A0236.includes

//## begin module%4070026A0236.additionalDeclarations preserve=yes
//## end module%4070026A0236.additionalDeclarations


//## begin GeoPoints%4070026A0236.preface preserve=yes
//## end GeoPoints%4070026A0236.preface

//## Class: GeoPoints%4070026A0236
//## Category: DataAccess::GEOO%407001E50071
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class GeoPoints 
{
  //## begin GeoPoints%4070026A0236.initialDeclarations preserve=yes
  //## end GeoPoints%4070026A0236.initialDeclarations

  public:
    //## Constructors (generated)
      GeoPoints();

    //## Destructor (generated)
      ~GeoPoints();


    //## Other Operations (specified)
      //## Operation: GetPoint%4070038E0340
      GeoPoint GetPoint (int index);

      //## Operation: GetPoint%40794C22003E
      void GetPoint (int index, double& x, double& y);

      //## Operation: GetPtCount%40700409035F
      int GetPtCount ();

      //## Operation: SetPointCount%4070052D0014
      void SetPointCount (int nPtCount);

      //## Operation: SetPoint%4079436D009C
      void SetPoint (int index, double x, double y);

      //## Operation: SetPoint%4079439803C8
      void SetPoint (int index, GeoPoint point);

    // Additional Public Declarations
      //## begin GeoPoints%4070026A0236.public preserve=yes
      //## end GeoPoints%4070026A0236.public
  protected:
    // Additional Protected Declarations
      //## begin GeoPoints%4070026A0236.protected preserve=yes
      //## end GeoPoints%4070026A0236.protected

  private:
    // Additional Private Declarations
      //## begin GeoPoints%4070026A0236.private preserve=yes
      //## end GeoPoints%4070026A0236.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: pArrayX%4070035700DF
      //## begin GeoPoints::pArrayX%4070035700DF.attr preserve=no  private: double* {U} 0
      double* pArrayX;
      //## end GeoPoints::pArrayX%4070035700DF.attr

      //## Attribute: pArrayY%4070037101E8
      //## begin GeoPoints::pArrayY%4070037101E8.attr preserve=no  private: double* {U} 0
      double* pArrayY;
      //## end GeoPoints::pArrayY%4070037101E8.attr

      //## Attribute: nPtCount%4070037A0330
      //## begin GeoPoints::nPtCount%4070037A0330.attr preserve=no  private: int {U} 0
      int nPtCount;
      //## end GeoPoints::nPtCount%4070037A0330.attr

    // Additional Implementation Declarations
      //## begin GeoPoints%4070026A0236.implementation preserve=yes
      //## end GeoPoints%4070026A0236.implementation

};

//## begin GeoPoints%4070026A0236.postscript preserve=yes
//## end GeoPoints%4070026A0236.postscript

// Class GeoPoints 

//## begin module%4070026A0236.epilog preserve=yes
//## end module%4070026A0236.epilog


#endif
