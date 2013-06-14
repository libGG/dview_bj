//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A1D1BD00FA.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A1D1BD00FA.cm

//## begin module%40A1D1BD00FA.cp preserve=no
//## end module%40A1D1BD00FA.cp

//## Module: MapLayer%40A1D1BD00FA; Pseudo Package specification
//## Source file: E:\egis\code\mapcontrol\MapLayer.h

#ifndef MapLayer_h
#define MapLayer_h 1

//## begin module%40A1D1BD00FA.additionalIncludes preserve=no
//## end module%40A1D1BD00FA.additionalIncludes

//## begin module%40A1D1BD00FA.includes preserve=yes
//## end module%40A1D1BD00FA.includes

#include "ILayer.h"
//## begin module%40A1D1BD00FA.additionalDeclarations preserve=yes
//## end module%40A1D1BD00FA.additionalDeclarations


//## begin MapLayer%40A1D1BD00FA.preface preserve=yes
//## end MapLayer%40A1D1BD00FA.preface

//## Class: MapLayer%40A1D1BD00FA
//## Category: mapcontrol%40A18DCA00FA
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class MapLayer : public ILayer  //## Inherits: <unnamed>%40A1D2580109
{
  //## begin MapLayer%40A1D1BD00FA.initialDeclarations preserve=yes
  //## end MapLayer%40A1D1BD00FA.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: MapLayer%40A1D1BD00FC
      MapLayer (LayerProperty* layerProperty);

    //## Destructor (generated)
      ~MapLayer();


    //## Other Operations (specified)
      //## Operation: GetLayerType%40A1D1BD00FF
      int GetLayerType ();

      //## Operation: GetLayerName%40A1D1BD0100
      const char* GetLayerName ();

      //## Operation: IsVisible%40A1D1BD0101
      bool IsVisible ();

      //## Operation: GetProperty%40A1D1BD0102
      LayerProperty& GetProperty ();

      //## Operation: GetRender%40A1D1BD0103
      IRender& GetRender ();

      //## Operation: SetVisible%40A1D1BD0104
      void SetVisible (bool bVisible);

      //## Operation: SetRender%40A1D1BD0106
      void SetRender (IRender* renderObj);

      //## Operation: GetBound%40A1D1BD0108
      void GetBound (double& x, double& y, double& w, double& h);

    // Additional Public Declarations
      //## begin MapLayer%40A1D1BD00FA.public preserve=yes
      //## end MapLayer%40A1D1BD00FA.public

  protected:
    // Additional Protected Declarations
      //## begin MapLayer%40A1D1BD00FA.protected preserve=yes
      //## end MapLayer%40A1D1BD00FA.protected

  private:
    // Additional Private Declarations
      //## begin MapLayer%40A1D1BD00FA.private preserve=yes
      //## end MapLayer%40A1D1BD00FA.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_pLayerProperty%40A1D1BD010F
      //## begin MapLayer::m_pLayerProperty%40A1D1BD010F.attr preserve=no  private: LayerProperty* {U} 0
      LayerProperty* m_pLayerProperty;
      //## end MapLayer::m_pLayerProperty%40A1D1BD010F.attr

      //## Attribute: m_pRender%40A1D1BD0110
      //## begin MapLayer::m_pRender%40A1D1BD0110.attr preserve=no  private: IRender* {U} 0
      IRender* m_pRender;
      //## end MapLayer::m_pRender%40A1D1BD0110.attr

    // Additional Implementation Declarations
      //## begin MapLayer%40A1D1BD00FA.implementation preserve=yes
      //## end MapLayer%40A1D1BD00FA.implementation

};

//## begin MapLayer%40A1D1BD00FA.postscript preserve=yes
//## end MapLayer%40A1D1BD00FA.postscript

// Class MapLayer 

//## begin module%40A1D1BD00FA.epilog preserve=yes
//## end module%40A1D1BD00FA.epilog


#endif
