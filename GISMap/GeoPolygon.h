//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%4070027E0052.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%4070027E0052.cm

//## begin module%4070027E0052.cp preserve=no
//## end module%4070027E0052.cp

//## Module: GeoPolygon%4070027E0052; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\GEOO\GeoPolygon.h

#ifndef GeoPolygon_h
#define GeoPolygon_h 1

//## begin module%4070027E0052.additionalIncludes preserve=no
//## end module%4070027E0052.additionalIncludes

//## begin module%4070027E0052.includes preserve=yes
//## end module%4070027E0052.includes

#include "Geometry.h"
#include "GeoPoints.h"
//## begin module%4070027E0052.additionalDeclarations preserve=yes
//## end module%4070027E0052.additionalDeclarations


//## begin GeoPolygon%4070027E0052.preface preserve=yes
//## end GeoPolygon%4070027E0052.preface

//## Class: GeoPolygon%4070027E0052
//## Category: DataAccess::GEOO%407001E50071
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class GeoPolygon : public Geometry  //## Inherits: <unnamed>%40A1DABA0251
{
  //## begin GeoPolygon%4070027E0052.initialDeclarations preserve=yes
  //## end GeoPolygon%4070027E0052.initialDeclarations

  public:
    //## Constructors (generated)
      GeoPolygon();

    //## Destructor (generated)
      ~GeoPolygon();


    //## Other Operations (specified)
      //## Operation: GetGeoType%40A44FEE0148
      int GetGeoType ();

      //## Operation: SetPointsCount%4085E53101F3
      void SetPointsCount (int nCount);

      //## Operation: GetPointsCount%4085E58A0137
      int GetPointsCount ();

      //## Operation: GetPoints%40794BBD00BB
      GeoPoints& GetPoints (int index);

    // Additional Public Declarations
      //## begin GeoPolygon%4070027E0052.public preserve=yes
      //## end GeoPolygon%4070027E0052.public

  protected:
    // Additional Protected Declarations
      //## begin GeoPolygon%4070027E0052.protected preserve=yes
      //## end GeoPolygon%4070027E0052.protected

  private:
    // Additional Private Declarations
      //## begin GeoPolygon%4070027E0052.private preserve=yes
      //## end GeoPolygon%4070027E0052.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: arrayPoints%40794A69035B
      //## begin GeoPolygon::arrayPoints%40794A69035B.attr preserve=no  private: GeoPoints* {U} 
      GeoPoints* arrayPoints;
      //## end GeoPolygon::arrayPoints%40794A69035B.attr

      //## Attribute: nPointsCount%4085E4EB003D
      //## begin GeoPolygon::nPointsCount%4085E4EB003D.attr preserve=no  private: int {U} 0
      int nPointsCount;
      //## end GeoPolygon::nPointsCount%4085E4EB003D.attr

    // Data Members for Associations

      //## Association: DataAccess::GEOO::<unnamed>%40794C8401B5
      //## Role: GeoPolygon::<the_GeoPoints>%40794C8500BB
      //## begin GeoPolygon::<the_GeoPoints>%40794C8500BB.role preserve=no  public: GeoPoints { -> UHgN}
      //## end GeoPolygon::<the_GeoPoints>%40794C8500BB.role

    // Additional Implementation Declarations
      //## begin GeoPolygon%4070027E0052.implementation preserve=yes
      //## end GeoPolygon%4070027E0052.implementation

};

//## begin GeoPolygon%4070027E0052.postscript preserve=yes
//## end GeoPolygon%4070027E0052.postscript

// Class GeoPolygon 

//## begin module%4070027E0052.epilog preserve=yes
//## end module%4070027E0052.epilog


#endif
