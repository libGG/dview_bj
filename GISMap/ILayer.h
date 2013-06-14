//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A19AE303C8.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A19AE303C8.cm

//## begin module%40A19AE303C8.cp preserve=no
//## end module%40A19AE303C8.cp

//## Module: ILayer%40A19AE303C8; Pseudo Package specification
//## Source file: E:\egis\code\mapcontrol\ILayer.h

#ifndef ILayer_h
#define ILayer_h 1

//## begin module%40A19AE303C8.additionalIncludes preserve=no
//## end module%40A19AE303C8.additionalIncludes

//## begin module%40A19AE303C8.includes preserve=yes
//#include "LayerProperty.h"
//#include "irender.h"
//## end module%40A19AE303C8.includes

//## begin module%40A19AE303C8.additionalDeclarations preserve=yes
class LayerProperty ;
class IRender ;
//## end module%40A19AE303C8.additionalDeclarations


//## begin ILayer%40A19AE303C8.preface preserve=yes
//## end ILayer%40A19AE303C8.preface

//## Class: ILayer%40A19AE303C8
//## Category: mapcontrol%40A18DCA00FA
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class ILayer 
{
  //## begin ILayer%40A19AE303C8.initialDeclarations preserve=yes
  //## end ILayer%40A19AE303C8.initialDeclarations

  public:

    //## Other Operations (specified)
      //## Operation: GetLayerType%40A19AF401A5
      virtual int GetLayerType () = 0;

      //## Operation: GetLayerName%40A19B0A0290
      virtual const char* GetLayerName () = 0;

      //## Operation: IsVisible%40A19B1C038A
      virtual bool IsVisible () = 0;

      //## Operation: GetProperty%40A19B2A03C8
      virtual LayerProperty& GetProperty () = 0;

      //## Operation: GetRender%40A19B3A0232
      virtual IRender& GetRender () = 0;

      //## Operation: GetBound%40A19B510232
      virtual void GetBound (double& x, double& y, double& w, double& h) = 0;

    // Additional Public Declarations
      //## begin ILayer%40A19AE303C8.public preserve=yes
      //## end ILayer%40A19AE303C8.public

  protected:
    // Additional Protected Declarations
      //## begin ILayer%40A19AE303C8.protected preserve=yes
      //## end ILayer%40A19AE303C8.protected

  private:
    // Additional Private Declarations
      //## begin ILayer%40A19AE303C8.private preserve=yes
      //## end ILayer%40A19AE303C8.private

  private: //## implementation
    // Additional Implementation Declarations
      //## begin ILayer%40A19AE303C8.implementation preserve=yes
      //## end ILayer%40A19AE303C8.implementation

};

//## begin ILayer%40A19AE303C8.postscript preserve=yes
//## end ILayer%40A19AE303C8.postscript

// Class ILayer 

//## begin module%40A19AE303C8.epilog preserve=yes
//## end module%40A19AE303C8.epilog


#endif
