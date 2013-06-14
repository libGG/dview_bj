//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%407002740042.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%407002740042.cm

//## begin module%407002740042.cp preserve=no
//## end module%407002740042.cp

//## Module: GeoPolyline%407002740042; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\GEOO\GeoPolyline.h

#ifndef GeoPolyline_h
#define GeoPolyline_h 1

//## begin module%407002740042.additionalIncludes preserve=no
//## end module%407002740042.additionalIncludes

//## begin module%407002740042.includes preserve=yes
//## end module%407002740042.includes

#include "Geometry.h"
#include "GeoPoints.h"
//## begin module%407002740042.additionalDeclarations preserve=yes
//## end module%407002740042.additionalDeclarations


//## begin GeoPolyline%407002740042.preface preserve=yes
//## end GeoPolyline%407002740042.preface

//## Class: GeoPolyline%407002740042
//## Category: DataAccess::GEOO%407001E50071
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class GeoPolyline : public Geometry  //## Inherits: <unnamed>%40A1DAB2006D
{
  //## begin GeoPolyline%407002740042.initialDeclarations preserve=yes
  //## end GeoPolyline%407002740042.initialDeclarations

  public:
    //## Constructors (generated)
      GeoPolyline();

    //## Destructor (generated)
      ~GeoPolyline();


    //## Other Operations (specified)
      //## Operation: GetGeoType%40A44FE502CE
      int GetGeoType ();

      //## Operation: SetPointsCount%409F7F39008C
      void SetPointsCount (int nCount);

      //## Operation: GetPointsCount%409F7F540232
      int GetPointsCount ();

      //## Operation: GetPoints%409F7F65032C
      GeoPoints& GetPoints (int index);

    // Additional Public Declarations
      //## begin GeoPolyline%407002740042.public preserve=yes
      //## end GeoPolyline%407002740042.public

  protected:
    // Additional Protected Declarations
      //## begin GeoPolyline%407002740042.protected preserve=yes
      //## end GeoPolyline%407002740042.protected

  private:
    // Additional Private Declarations
      //## begin GeoPolyline%407002740042.private preserve=yes
      //## end GeoPolyline%407002740042.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: arrayPoints%407005C100CF
      //## begin GeoPolyline::arrayPoints%407005C100CF.attr preserve=no  private: GeoPoints* {U} 
      GeoPoints* arrayPoints;
      //## end GeoPolyline::arrayPoints%407005C100CF.attr

      //## Attribute: nPointsCount%40A1DAFF03B9
      //## begin GeoPolyline::nPointsCount%40A1DAFF03B9.attr preserve=no  private: int {U} 0
      int nPointsCount;
      //## end GeoPolyline::nPointsCount%40A1DAFF03B9.attr

    // Data Members for Associations

      //## Association: DataAccess::GEOO::<unnamed>%4079454E005D
      //## Role: GeoPolyline::<the_GeoPoints>%4079454E03B9
      //## begin GeoPolyline::<the_GeoPoints>%4079454E03B9.role preserve=no  public: GeoPoints { -> UHgN}
      //## end GeoPolyline::<the_GeoPoints>%4079454E03B9.role

    // Additional Implementation Declarations
      //## begin GeoPolyline%407002740042.implementation preserve=yes
      //## end GeoPolyline%407002740042.implementation

};

//## begin GeoPolyline%407002740042.postscript preserve=yes
//## end GeoPolyline%407002740042.postscript

// Class GeoPolyline 

//## begin module%407002740042.epilog preserve=yes
//## end module%407002740042.epilog


#endif
