//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A19BA10399.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A19BA10399.cm

//## begin module%40A19BA10399.cp preserve=no
//## end module%40A19BA10399.cp

//## Module: Layers%40A19BA10399; Pseudo Package specification
//## Source file: E:\egis\code\mapcontrol\Layers.h

#ifndef Layers_h
#define Layers_h 1

//## begin module%40A19BA10399.additionalIncludes preserve=no
//## end module%40A19BA10399.additionalIncludes

//## begin module%40A19BA10399.includes preserve=yes
//## end module%40A19BA10399.includes

//## begin module%40A19BA10399.additionalDeclarations preserve=yes
#include "ILayer.h"
#include <vector>
using namespace std;
//## end module%40A19BA10399.additionalDeclarations


//## begin Layers%40A19BA10399.preface preserve=yes
typedef vector< ILayer * > VECTORLayer;
//## end Layers%40A19BA10399.preface

//## Class: Layers%40A19BA10399
//## Category: mapcontrol%40A18DCA00FA
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class Layers 
{
  //## begin Layers%40A19BA10399.initialDeclarations preserve=yes
  //## end Layers%40A19BA10399.initialDeclarations

  public:
    //## Constructors (generated)
      Layers();

    //## Destructor (generated)
      ~Layers();


    //## Other Operations (specified)
      //## Operation: Add%40A19BA1039A
      void Add (ILayer* layer);

      //## Operation: GetLayer%40A19BA1039C
      ILayer* GetLayer (int index);

      //## Operation: Count%40A19BA1039E
      int Count ();

      //## Operation: GetActive%40A19BA1039F
      int GetActive ();

      //## Operation: GetActiveLayer%40A19C1402FD
      ILayer* GetActiveLayer ();

      //## Operation: SetActive%40A19BA103A0
      void SetActive (int index);

      //## Operation: MoveTo%40A19BA103A2
      bool MoveTo (int fromIndex, int toIndex);

      //## Operation: MoveToBottom%40A19BA103A5
      bool MoveToBottom (int index);

      //## Operation: MoveToTop%40A19BA103A7
      bool MoveToTop (int index);

      //## Operation: Remove%40A19BA103A9
      void Remove (int index);

      //## Operation: Clear%40A19BA103AB
      void Clear ();

    // Additional Public Declarations
      //## begin Layers%40A19BA10399.public preserve=yes
      //## end Layers%40A19BA10399.public

  protected:
    // Additional Protected Declarations
      //## begin Layers%40A19BA10399.protected preserve=yes
      //## end Layers%40A19BA10399.protected

  private:
    // Additional Private Declarations
      //## begin Layers%40A19BA10399.private preserve=yes
      //## end Layers%40A19BA10399.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_vectorLayers%40A19BA103AC
      //## begin Layers::m_vectorLayers%40A19BA103AC.attr preserve=no  private: VECTORLayer {U} 
      VECTORLayer m_vectorLayers;
      //## end Layers::m_vectorLayers%40A19BA103AC.attr

      //## Attribute: m_nActiveIndex%40A19BA103AD
      //## begin Layers::m_nActiveIndex%40A19BA103AD.attr preserve=no  private: int {U} -1
      int m_nActiveIndex;
      //## end Layers::m_nActiveIndex%40A19BA103AD.attr

    // Additional Implementation Declarations
      //## begin Layers%40A19BA10399.implementation preserve=yes
      //## end Layers%40A19BA10399.implementation

};

//## begin Layers%40A19BA10399.postscript preserve=yes
//## end Layers%40A19BA10399.postscript

// Class Layers 

//## begin module%40A19BA10399.epilog preserve=yes
//## end module%40A19BA10399.epilog


#endif
