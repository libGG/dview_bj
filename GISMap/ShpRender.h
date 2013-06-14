//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40AD72380148.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40AD72380148.cm

//## begin module%40AD72380148.cp preserve=no
//## end module%40AD72380148.cp

//## Module: ShpRender%40AD72380148; Pseudo Package specification
//## Source file: E:\egisdevelop\code\mapcontrol\ShpRender.h

#ifndef ShpRender_h
#define ShpRender_h 1

//## begin module%40AD72380148.additionalIncludes preserve=no
//## end module%40AD72380148.additionalIncludes

//## begin module%40AD72380148.includes preserve=yes
//## end module%40AD72380148.includes

#include "IRender.h"
//## begin module%40AD72380148.additionalDeclarations preserve=yes
class MapLayer ;
//## end module%40AD72380148.additionalDeclarations


//## begin ShpRender%40AD72380148.preface preserve=yes
//## end ShpRender%40AD72380148.preface

//## Class: ShpRender%40AD72380148
//## Category: mapcontrol%40A18DCA00FA
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class ShpRender : public IRender  //## Inherits: <unnamed>%40AD72A202CE
{
  //## begin ShpRender%40AD72380148.initialDeclarations preserve=yes
  //## end ShpRender%40AD72380148.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: ShpRender%40AD74640251
      ShpRender (MapLayer* pLayer);

    //## Destructor (generated)
      ~ShpRender();


    //## Other Operations (specified)
      //## Operation: Render%40AD729501E4
      void Render (CDC *pDC, MapProperty* pMapProperty);

    // Additional Public Declarations
      //## begin ShpRender%40AD72380148.public preserve=yes
      //## end ShpRender%40AD72380148.public

  protected:
    // Additional Protected Declarations
      //## begin ShpRender%40AD72380148.protected preserve=yes
      //## end ShpRender%40AD72380148.protected

  private:
    // Additional Private Declarations
      //## begin ShpRender%40AD72380148.private preserve=yes
      //## end ShpRender%40AD72380148.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_pLayer%40AD745100BB
      //## begin ShpRender::m_pLayer%40AD745100BB.attr preserve=no  private: MapLayer* {U} 
      MapLayer* m_pLayer;
      //## end ShpRender::m_pLayer%40AD745100BB.attr

    // Additional Implementation Declarations
      //## begin ShpRender%40AD72380148.implementation preserve=yes
      //## end ShpRender%40AD72380148.implementation

};

//## begin ShpRender%40AD72380148.postscript preserve=yes
//## end ShpRender%40AD72380148.postscript

// Class ShpRender 

//## begin module%40AD72380148.epilog preserve=yes
//## end module%40AD72380148.epilog


#endif
