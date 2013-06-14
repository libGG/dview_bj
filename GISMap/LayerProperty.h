//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A237BE01E4.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A237BE01E4.cm

//## begin module%40A237BE01E4.cp preserve=no
//## end module%40A237BE01E4.cp

//## Module: LayerProperty%40A237BE01E4; Pseudo Package specification
//## Source file: E:\egis\code\DataAccess\LayerProperty.h

#ifndef LayerProperty_h
#define LayerProperty_h 1

//## begin module%40A237BE01E4.additionalIncludes preserve=no
//## end module%40A237BE01E4.additionalIncludes

//## begin module%40A237BE01E4.includes preserve=yes
#include "dataset.h"
//## end module%40A237BE01E4.includes

//## begin module%40A237BE01E4.additionalDeclarations preserve=yes
//## end module%40A237BE01E4.additionalDeclarations


//## begin LayerProperty%40A237BE01E4.preface preserve=yes
//## end LayerProperty%40A237BE01E4.preface

//## Class: LayerProperty%40A237BE01E4
//## Category: DataAccess%4056B67500D5
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class LayerProperty 
{
  //## begin LayerProperty%40A237BE01E4.initialDeclarations preserve=yes
  //## end LayerProperty%40A237BE01E4.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: LayerProperty%40A237BE01E5
      LayerProperty (int layerID, const char* name );

    //## Destructor (generated)
      ~LayerProperty();


    //## Other Operations (specified)
      //## Operation: GetLayerID%40A237BE01E8
      int GetLayerID ();

      //## Operation: GetLayerName%40A237BE01E9
      const char* GetLayerName ();

      //## Operation: GetLayerIndex%40A237BE01EA
      int GetLayerIndex ();

      //## Operation: IsVisible%40A237BE01EB
      bool IsVisible ();

      //## Operation: GetMinVisual%40A237BE01EC
      double GetMinVisual ();

      //## Operation: GetMaxVisual%40A237BE01ED
      double GetMaxVisual ();

      //## Operation: SetMinVisual%40A237BE01EE
      void SetMinVisual (double visual);

      //## Operation: SetMaxVisual%40A237BE01F0
      void SetMaxVisual (double visual);

      //## Operation: AddRelateDataSet%40A237BE01F2
      void SetRelateDataSet (DataSet* pDataset);

      //## Operation: GetRelateDataSet%40A237BE01F5
      DataSet& GetRelateDataSet ( );

      //## Operation: SetLayerIndex%40A237BE01F8
      void SetLayerIndex (int layerIndex);

      //## Operation: SetVisible%40A237BE01FA
      void SetVisible (bool visible);

    // Additional Public Declarations
      //## begin LayerProperty%40A237BE01E4.public preserve=yes
      //## end LayerProperty%40A237BE01E4.public

  protected:
    // Additional Protected Declarations
      //## begin LayerProperty%40A237BE01E4.protected preserve=yes
      //## end LayerProperty%40A237BE01E4.protected

  private:
    // Additional Private Declarations
      //## begin LayerProperty%40A237BE01E4.private preserve=yes
      //## end LayerProperty%40A237BE01E4.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_nLayerID%40A237BE01FC
      //## begin LayerProperty::m_nLayerID%40A237BE01FC.attr preserve=no  private: int {U} -1
      int m_nLayerID;
      //## end LayerProperty::m_nLayerID%40A237BE01FC.attr

      //## Attribute: m_szName%40A237BE01FD
      //## begin LayerProperty::m_szName%40A237BE01FD.attr preserve=no  private: char[40] {U} 
      char m_szName[40];
      //## end LayerProperty::m_szName%40A237BE01FD.attr

      //## Attribute: m_nLayerIndex%40A237BE01FE
      //## begin LayerProperty::m_nLayerIndex%40A237BE01FE.attr preserve=no  private: int {U} 
      int m_nLayerIndex;
      //## end LayerProperty::m_nLayerIndex%40A237BE01FE.attr

      //## Attribute: m_isVisible%40A237BE01FF
      //## begin LayerProperty::m_isVisible%40A237BE01FF.attr preserve=no  private: bool {U} true
      bool m_isVisible;
      //## end LayerProperty::m_isVisible%40A237BE01FF.attr

      //## Attribute: m_dMinVisual%40A237BE0200
      //## begin LayerProperty::m_dMinVisual%40A237BE0200.attr preserve=no  private: double {U} 0.0
      double m_dMinVisual;
      //## end LayerProperty::m_dMinVisual%40A237BE0200.attr

      //## Attribute: m_dMaxVisual%40A237BE0201
      //## begin LayerProperty::m_dMaxVisual%40A237BE0201.attr preserve=no  private: double {U} 3.6e11
      double m_dMaxVisual;
      //## end LayerProperty::m_dMaxVisual%40A237BE0201.attr

      //## Attribute: m_vectorDataSet%40A237BE0202
      //## begin LayerProperty::m_vectorDataSet%40A237BE0202.attr preserve=no  private: VECTOR_DataSet {U} 
      DataSet *m_pDataSet;
      //## end LayerProperty::m_vectorDataSet%40A237BE0202.attr

    // Additional Implementation Declarations
      //## begin LayerProperty%40A237BE01E4.implementation preserve=yes
      //## end LayerProperty%40A237BE01E4.implementation

};

//## begin LayerProperty%40A237BE01E4.postscript preserve=yes
//## end LayerProperty%40A237BE01E4.postscript

// Class LayerProperty 

//## begin module%40A237BE01E4.epilog preserve=yes
//## end module%40A237BE01E4.epilog


#endif
