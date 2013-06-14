//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A1C5E3003E.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A1C5E3003E.cm

//## begin module%40A1C5E3003E.cp preserve=no
//## end module%40A1C5E3003E.cp

//## Module: MapControl%40A1C5E3003E; Pseudo Package specification
//## Source file: E:\egisdevelop\code\mapcontrol\MapControl.h

#ifndef MapControl_h
#define MapControl_h 1

//## begin module%40A1C5E3003E.additionalIncludes preserve=no
//## end module%40A1C5E3003E.additionalIncludes

//## begin module%40A1C5E3003E.includes preserve=yes
//## end module%40A1C5E3003E.includes

//## begin module%40A1C5E3003E.additionalDeclarations preserve=yes
#include "Layers.h"
#include "CMouseListeners.h"
//## end module%40A1C5E3003E.additionalDeclarations


//## begin MapControl%40A1C5E3003E.preface preserve=yes
class CBitmap;
class CView;
class CDC;
class CPoint;
//## end MapControl%40A1C5E3003E.preface

//## Class: MapControl%40A1C5E3003E
//## Category: mapcontrol%40A18DCA00FA
//## Persistence: Transient
//## Cardinality/Multiplicity: n

//## Uses: <unnamed>%40A1D264036B;MapProperty { -> }
//## Uses: <unnamed>%40A1D26F001F;TrackingLayer { -> }

class MapControl
{
  //## begin MapControl%40A1C5E3003E.initialDeclarations preserve=yes
  //## end MapControl%40A1C5E3003E.initialDeclarations

  public:
    //## Constructors (generated)
      MapControl();

    //## Destructor (generated)
      ~MapControl();

      //## Operation: GetDataBound%40AC5E3400FA
      void GetDataBound (double& x, double& y, double& w, double& h);

      //## Operation: GetWorldBound%40A1C5E30042
      void GetWorldBound (double& x, double& y, double& w, double& h);

      //## Operation: GetLayers%40A1C5E30046
      Layers& GetLayers ();

      //## Operation: ClientToWorld%40A1C5E30047
      void ClientToWorld (double& x, double& y);

      //## Operation: WorldToClient%40A1C5E30049
      void WorldToClient (double& x, double& y);

      //## Operation: SetWorldBound%40A1C5E3004D
      void SetWorldBound (double x, double y, double w, double h);

      //## Operation: Reset%40A1C5E30053
      void Reset ();

      //## Operation: ReDraw%40A1C5E30054
      void ReDraw (int x, int y, int w, int h);

      //## Operation: DrawMap%40AC7D5C03A9
      void DrawMap ();

      //## Operation: Refresh%40A1C5E3005B
      void Refresh ();

      //## Operation: ZoomIn%40A1C5E3005C
      void ZoomIn (int x, int y, int w, int h);

      //## Operation: ZoomOut%40A1C5E3005E
      void ZoomOut (int x, int y, int w, int h);

      //## Operation: Scroll%40A1C5E30060
      void Scroll (int dx, int dy);

    // Additional Public Declarations
	  void ClearBuffer( CDC *pDC, int x, int y, int w, int h );

      //## begin MapControl%40A1C5E3003E.public preserve=yes
	  void SetViewBound ( int x, int y, int w, int h );

	  void GetViewBound ( int& x, int& y, int& w, int& h );

	  //## Operation: SetOwnerView%3DAA2F4702A8
      void SetOwnerView (CView* pView);

      //## Operation: GetOwnerView%3DB8B3CF03D5
      CView* GetOwnerView ();
      //## end MapControl%40A1C5E3003E.public

	  CPoint* GetOwnerWindowDrawingPos();

	  CMouseListeners& GetMouseListeners();

  protected:
    // Additional Protected Declarations
      //## begin MapControl%40A1C5E3003E.protected preserve=yes
      //## end MapControl%40A1C5E3003E.protected

  private:
    // Additional Private Declarations
      //## begin MapControl%40A1C5E3003E.private preserve=yes
	  CPoint *m_pOwnerWindowDrawingPos;
      //## end MapControl%40A1C5E3003E.private

	  CMouseListeners *m_pMouseListeners;
  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: dataX%40AC5AFD0242
      //## begin MapControl::dataX%40AC5AFD0242.attr preserve=no  private: double {U} 
      double dataX;
      //## end MapControl::dataX%40AC5AFD0242.attr

      //## Attribute: dataY%40AC5E1C01F4
      //## begin MapControl::dataY%40AC5E1C01F4.attr preserve=no  private: double {U} 
      double dataY;
      //## end MapControl::dataY%40AC5E1C01F4.attr

      //## Attribute: dataWidth%40AC5E2101D4
      //## begin MapControl::dataWidth%40AC5E2101D4.attr preserve=no  private: double {U} 
      double dataWidth;
      //## end MapControl::dataWidth%40AC5E2101D4.attr

      //## Attribute: dataHeight%40AC5E270280
      //## begin MapControl::dataHeight%40AC5E270280.attr preserve=no  private: double {U} 
      double dataHeight;
      //## end MapControl::dataHeight%40AC5E270280.attr

      //## Attribute: clientWidth%40A1C5E30069
      //## begin MapControl::clientWidth%40A1C5E30069.attr preserve=no  private: int {U} 
      int clientWidth;
      //## end MapControl::clientWidth%40A1C5E30069.attr

      //## Attribute: clientHeight%40A1CE07034B
      //## begin MapControl::clientHeight%40A1CE07034B.attr preserve=no  private: int {U} 
      int clientHeight;
      //## end MapControl::clientHeight%40A1CE07034B.attr

      //## Attribute: worldX%40A1C5E3006A
      //## begin MapControl::worldX%40A1C5E3006A.attr preserve=no  private: double {U} 
      double worldX;
      //## end MapControl::worldX%40A1C5E3006A.attr

      //## Attribute: worldY%40A1CE2A01A5
      //## begin MapControl::worldY%40A1CE2A01A5.attr preserve=no  private: double {U} 
      double worldY;
      //## end MapControl::worldY%40A1CE2A01A5.attr

      //## Attribute: worldWidth%40A1CE3000BB
      //## begin MapControl::worldWidth%40A1CE3000BB.attr preserve=no  private: double {U} 
      double worldWidth;
      //## end MapControl::worldWidth%40A1CE3000BB.attr

      //## Attribute: worldHeight%40A1CE3B00BB
      //## begin MapControl::worldHeight%40A1CE3B00BB.attr preserve=no  private: double {U} 
      double worldHeight;
      //## end MapControl::worldHeight%40A1CE3B00BB.attr

      //## Attribute: mapBufferID%40AC59C1003E
      //## begin MapControl::mapBufferID%40AC59C1003E.attr preserve=no  private: Fl_Offscreen {U} 
      CBitmap *m_pMapBuffer;
      //## end MapControl::mapBufferID%40AC59C1003E.attr

      //## Attribute: paintBufferID%40AC5A8D000F
      //## begin MapControl::paintBufferID%40AC5A8D000F.attr preserve=no  private: Fl_Offscreen {U} 
      CBitmap *m_pPaintBuffer;
      //## end MapControl::paintBufferID%40AC5A8D000F.attr

      //## Attribute: layers%40A1C5E3006C
      //## begin MapControl::layers%40A1C5E3006C.attr preserve=no  private: Layers* {U} 0
      Layers* layers;
      //## end MapControl::layers%40A1C5E3006C.attr

    // Additional Implementation Declarations
      //## begin MapControl%40A1C5E3003E.implementation preserve=yes
	  CView *m_pOwnerView;
      //## end MapControl%40A1C5E3003E.implementation

};

//## begin MapControl%40A1C5E3003E.postscript preserve=yes
//## end MapControl%40A1C5E3003E.postscript

// Class MapControl 

//## begin module%40A1C5E3003E.epilog preserve=yes
//## end module%40A1C5E3003E.epilog


#endif
