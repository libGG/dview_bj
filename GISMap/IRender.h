//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40AD5E52008C.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40AD5E52008C.cm

//## begin module%40AD5E52008C.cp preserve=no
//## end module%40AD5E52008C.cp

//## Module: IRender%40AD5E52008C; Pseudo Package specification
//## Source file: E:\egisdevelop\code\mapcontrol\IRender.h

#ifndef IRender_h
#define IRender_h 1

//## begin module%40AD5E52008C.additionalIncludes preserve=no
//## end module%40AD5E52008C.additionalIncludes

//## begin module%40AD5E52008C.includes preserve=yes

//## end module%40AD5E52008C.includes

//## begin module%40AD5E52008C.additionalDeclarations preserve=yes
class MapProperty;
class CDC ;
//## end module%40AD5E52008C.additionalDeclarations


//## begin IRender%40AD5E52008C.preface preserve=yes
//## end IRender%40AD5E52008C.preface

//## Class: IRender%40AD5E52008C
//## Category: mapcontrol%40A18DCA00FA
//## Persistence: Transient
//## Cardinality/Multiplicity: n
class IRender 
{
  //## begin IRender%40AD5E52008C.initialDeclarations preserve=yes
  //## end IRender%40AD5E52008C.initialDeclarations

  public:

    //## Other Operations (specified)
      //## Operation: Render%40AD5E52008E
      virtual void Render (CDC *pDC, MapProperty* pMapProperty) = 0;

    // Additional Public Declarations
      //## begin IRender%40AD5E52008C.public preserve=yes
      //## end IRender%40AD5E52008C.public

  protected:
    // Additional Protected Declarations
      //## begin IRender%40AD5E52008C.protected preserve=yes
      //## end IRender%40AD5E52008C.protected

  private:
    // Additional Private Declarations
      //## begin IRender%40AD5E52008C.private preserve=yes
      //## end IRender%40AD5E52008C.private

  private: //## implementation
    // Additional Implementation Declarations
      //## begin IRender%40AD5E52008C.implementation preserve=yes
      //## end IRender%40AD5E52008C.implementation

};

//## begin IRender%40AD5E52008C.postscript preserve=yes
//## end IRender%40AD5E52008C.postscript

// Class IRender 

//## begin module%40AD5E52008C.epilog preserve=yes
//## end module%40AD5E52008C.epilog


#endif
