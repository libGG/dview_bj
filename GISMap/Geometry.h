#pragma once
//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A1DA6803B9.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A1DA6803B9.cm

//## begin module%40A1DA6803B9.cp preserve=no
//## end module%40A1DA6803B9.cp

//## Module: Geometry%40A1DA6803B9; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\GEOO\Geometry.h

//#ifndef Geometry_h
//#define Geometry_h 1

//## begin module%40A1DA6803B9.additionalIncludes preserve=no
//## end module%40A1DA6803B9.additionalIncludes

//## begin module%40A1DA6803B9.includes preserve=yes
//## end module%40A1DA6803B9.includes

//## begin module%40A1DA6803B9.additionalDeclarations preserve=yes
enum GEOTYPE2
{
	GEO_POINT = 0,
	GEO_POLYLINE = 1, 
	GEO_POLYGON = 2,
	GEO_ANNOTATION	= 3
};
//## end module%40A1DA6803B9.additionalDeclarations


//## begin Geometry%40A1DA6803B9.preface preserve=yes
//## end Geometry%40A1DA6803B9.preface

//## Class: Geometry%40A1DA6803B9
//## Category: DataAccess::GEOO%407001E50071
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class Geometry 
{
  //## begin Geometry%40A1DA6803B9.initialDeclarations preserve=yes
  //## end Geometry%40A1DA6803B9.initialDeclarations

  public:

    //## Other Operations (specified)
      //## Operation: GetGeoType%40A44EA1007D
      virtual int GetGeoType () = 0;

    // Additional Public Declarations
      //## begin Geometry%40A1DA6803B9.public preserve=yes
      //## end Geometry%40A1DA6803B9.public

  protected:
    // Additional Protected Declarations
      //## begin Geometry%40A1DA6803B9.protected preserve=yes
      //## end Geometry%40A1DA6803B9.protected

  private:
    // Additional Private Declarations
      //## begin Geometry%40A1DA6803B9.private preserve=yes
      //## end Geometry%40A1DA6803B9.private

  private: //## implementation
    // Additional Implementation Declarations
      //## begin Geometry%40A1DA6803B9.implementation preserve=yes
      //## end Geometry%40A1DA6803B9.implementation

};

//## begin Geometry%40A1DA6803B9.postscript preserve=yes
//## end Geometry%40A1DA6803B9.postscript

// Class Geometry 

//## begin module%40A1DA6803B9.epilog preserve=yes
//## end module%40A1DA6803B9.epilog


//#endif
