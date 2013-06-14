//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%407002620042.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%407002620042.cm

//## begin module%407002620042.cp preserve=no
//## end module%407002620042.cp

//## Module: GeoPoint%407002620042; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\GEOO\GeoPoint.h

#ifndef GeoPoint_h
#define GeoPoint_h 1

//## begin module%407002620042.additionalIncludes preserve=no
//## end module%407002620042.additionalIncludes

//## begin module%407002620042.includes preserve=yes
//## end module%407002620042.includes

#include "Geometry.h"
//## begin module%407002620042.additionalDeclarations preserve=yes
//## end module%407002620042.additionalDeclarations


//## begin GeoPoint%407002620042.preface preserve=yes
//## end GeoPoint%407002620042.preface

//## Class: GeoPoint%407002620042
//## Category: DataAccess::GEOO%407001E50071
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class GeoPoint : public Geometry  //## Inherits: <unnamed>%40A1DD0B031C
{
  //## begin GeoPoint%407002620042.initialDeclarations preserve=yes
  //## end GeoPoint%407002620042.initialDeclarations

  public:
    //## Constructors (generated)
      GeoPoint();

    //## Constructors (specified)
      //## Operation: GeoPoint%407955DB0128
      GeoPoint (double X, double Y);

    //## Destructor (generated)
      ~GeoPoint();


    //## Other Operations (specified)
      //## Operation: GetGeoType%40A44FD8002E
      int GetGeoType ();

      //## Operation: GetX%407002AC00DF
      double GetX ();

      //## Operation: GetY%407002EF0217
      double GetY ();

      //## Operation: SetX%407002F4036F
      void SetX (double X);

      //## Operation: SetY%40700328014C
      void SetY (double Y);

    // Additional Public Declarations
      //## begin GeoPoint%407002620042.public preserve=yes
      //## end GeoPoint%407002620042.public

  protected:
    // Additional Protected Declarations
      //## begin GeoPoint%407002620042.protected preserve=yes
      //## end GeoPoint%407002620042.protected

  private:
    // Additional Private Declarations
      //## begin GeoPoint%407002620042.private preserve=yes
      //## end GeoPoint%407002620042.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: x%407002A90014
      //## begin GeoPoint::x%407002A90014.attr preserve=no  private: double {U} 0
      double x;
      //## end GeoPoint::x%407002A90014.attr

      //## Attribute: y%407002CA01C9
      //## begin GeoPoint::y%407002CA01C9.attr preserve=no  private: double {U} 0
      double y;
      //## end GeoPoint::y%407002CA01C9.attr

    // Additional Implementation Declarations
      //## begin GeoPoint%407002620042.implementation preserve=yes
      //## end GeoPoint%407002620042.implementation

};

//## begin GeoPoint%407002620042.postscript preserve=yes
//## end GeoPoint%407002620042.postscript

// Class GeoPoint 

//## begin module%407002620042.epilog preserve=yes
//## end module%407002620042.epilog


#endif
