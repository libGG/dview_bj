//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40B009580157.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40B009580157.cm

//## begin module%40B009580157.cp preserve=no
//## end module%40B009580157.cp

//## Module: GeoAnnotation%40B009580157; Pseudo Package specification
//## Source file: E:\egisdevelop\code\Geometry\GeoAnnotation.h

#ifndef GeoAnnotation_h
#define GeoAnnotation_h 1

//## begin module%40B009580157.additionalIncludes preserve=no
//## end module%40B009580157.additionalIncludes

//## begin module%40B009580157.includes preserve=yes
//## end module%40B009580157.includes

#include "Geometry.h"
//## begin module%40B009580157.additionalDeclarations preserve=yes
//## end module%40B009580157.additionalDeclarations


//## begin GeoAnnotation%40B009580157.preface preserve=yes
//## end GeoAnnotation%40B009580157.preface

//## Class: GeoAnnotation%40B009580157
//## Category: Geometry%407001E50071
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class GeoAnnotation : public Geometry  //## Inherits: <unnamed>%40B0096C035B
{
  //## begin GeoAnnotation%40B009580157.initialDeclarations preserve=yes
  //## end GeoAnnotation%40B009580157.initialDeclarations

  public:
    //## Constructors (generated)
      GeoAnnotation();

    //## Constructors (specified)
      //## Operation: GeoAnnotation%40B009580159
      GeoAnnotation (double X, double Y, const char *string = 0);

    //## Destructor (generated)
      ~GeoAnnotation();


    //## Other Operations (specified)
      //## Operation: GetGeoType%40B00958015D
      int GetGeoType ();

      //## Operation: GetX%40B00958015E
      double GetX ();

      //## Operation: GetY%40B00958015F
      double GetY ();

      //## Operation: GetString%40B009580160
      const char * GetString ();

      //## Operation: SetString%40B009580161
      void SetString (const char *string);

      //## Operation: SetX%40B009580163
      void SetX (double X);

      //## Operation: SetY%40B009580165
      void SetY (double Y);

    // Additional Public Declarations
      //## begin GeoAnnotation%40B009580157.public preserve=yes
      //## end GeoAnnotation%40B009580157.public

  protected:
    // Additional Protected Declarations
      //## begin GeoAnnotation%40B009580157.protected preserve=yes
      //## end GeoAnnotation%40B009580157.protected

  private:
    // Additional Private Declarations
      //## begin GeoAnnotation%40B009580157.private preserve=yes
      //## end GeoAnnotation%40B009580157.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: pString%40B009580167
      //## begin GeoAnnotation::pString%40B009580167.attr preserve=no  private: char* {U} 0
      char* pString;
      //## end GeoAnnotation::pString%40B009580167.attr

      //## Attribute: x%40B009580168
      //## begin GeoAnnotation::x%40B009580168.attr preserve=no  private: double {U} 
      double x;
      //## end GeoAnnotation::x%40B009580168.attr

      //## Attribute: y%40B009580169
      //## begin GeoAnnotation::y%40B009580169.attr preserve=no  private: double {U} 
      double y;
      //## end GeoAnnotation::y%40B009580169.attr

    // Additional Implementation Declarations
      //## begin GeoAnnotation%40B009580157.implementation preserve=yes
      //## end GeoAnnotation%40B009580157.implementation

};

//## begin GeoAnnotation%40B009580157.postscript preserve=yes
//## end GeoAnnotation%40B009580157.postscript

// Class GeoAnnotation 

//## begin module%40B009580157.epilog preserve=yes
//## end module%40B009580157.epilog


#endif
