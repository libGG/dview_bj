//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A237BE01E4.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A237BE01E4.cm

//## begin module%40A237BE01E4.cp preserve=no
//## end module%40A237BE01E4.cp

//## Module: LayerProperty%40A237BE01E4; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\LayerProperty.cpp

//## begin module%40A237BE01E4.additionalIncludes preserve=no
//## end module%40A237BE01E4.additionalIncludes

//## begin module%40A237BE01E4.includes preserve=yes
//## end module%40A237BE01E4.includes

#include "LayerProperty.h"
//## begin module%40A237BE01E4.additionalDeclarations preserve=yes
#include "string.h"
//## end module%40A237BE01E4.additionalDeclarations


// Class LayerProperty 










LayerProperty::LayerProperty (int layerID, const char* name )
  //## begin LayerProperty::LayerProperty%40A237BE01E5.hasinit preserve=no
      : m_nLayerID(-1),
        m_isVisible(true),
        m_dMinVisual(0.0),
        m_dMaxVisual(3.6e11)
  //## end LayerProperty::LayerProperty%40A237BE01E5.hasinit
  //## begin LayerProperty::LayerProperty%40A237BE01E5.initialization preserve=yes
  //## end LayerProperty::LayerProperty%40A237BE01E5.initialization
{
  //## begin LayerProperty::LayerProperty%40A237BE01E5.body preserve=yes
	m_nLayerID = layerID;
	strcpy( m_szName, name );
  //## end LayerProperty::LayerProperty%40A237BE01E5.body
}


LayerProperty::~LayerProperty()
{
  //## begin LayerProperty::~LayerProperty%40A237BE01E4_dest.body preserve=yes
  //## end LayerProperty::~LayerProperty%40A237BE01E4_dest.body
}



//## Other Operations (implementation)
int LayerProperty::GetLayerID ()
{
  //## begin LayerProperty::GetLayerID%40A237BE01E8.body preserve=yes
	return m_nLayerID;
  //## end LayerProperty::GetLayerID%40A237BE01E8.body
}

const char* LayerProperty::GetLayerName ()
{
  //## begin LayerProperty::GetLayerName%40A237BE01E9.body preserve=yes
	return m_szName;
  //## end LayerProperty::GetLayerName%40A237BE01E9.body
}

int LayerProperty::GetLayerIndex ()
{
  //## begin LayerProperty::GetLayerIndex%40A237BE01EA.body preserve=yes
	return m_nLayerIndex;
  //## end LayerProperty::GetLayerIndex%40A237BE01EA.body
}

bool LayerProperty::IsVisible ()
{
  //## begin LayerProperty::IsVisible%40A237BE01EB.body preserve=yes
	return m_isVisible;
  //## end LayerProperty::IsVisible%40A237BE01EB.body
}

double LayerProperty::GetMinVisual ()
{
  //## begin LayerProperty::GetMinVisual%40A237BE01EC.body preserve=yes
	return m_dMinVisual;
  //## end LayerProperty::GetMinVisual%40A237BE01EC.body
}

double LayerProperty::GetMaxVisual ()
{
  //## begin LayerProperty::GetMaxVisual%40A237BE01ED.body preserve=yes
	return m_dMaxVisual;
  //## end LayerProperty::GetMaxVisual%40A237BE01ED.body
}

void LayerProperty::SetMinVisual (double visual)
{
  //## begin LayerProperty::SetMinVisual%40A237BE01EE.body preserve=yes
	m_dMinVisual = visual;
  //## end LayerProperty::SetMinVisual%40A237BE01EE.body
}

void LayerProperty::SetMaxVisual (double visual)
{
  //## begin LayerProperty::SetMaxVisual%40A237BE01F0.body preserve=yes
	m_dMaxVisual = visual;
  //## end LayerProperty::SetMaxVisual%40A237BE01F0.body
}

void LayerProperty::SetRelateDataSet (DataSet* pDataset)
{
  //## begin LayerProperty::AddRelateDataSet%40A237BE01F2.body preserve=yes
	this->m_pDataSet = pDataset ;
  //## end LayerProperty::AddRelateDataSet%40A237BE01F2.body
}

DataSet& LayerProperty::GetRelateDataSet ( )
{
  //## begin LayerProperty::GetRelateDataSet%40A237BE01F5.body preserve=yes
	return *m_pDataSet ;
  //## end LayerProperty::GetRelateDataSet%40A237BE01F5.body
}

void LayerProperty::SetLayerIndex (int layerIndex)
{
  //## begin LayerProperty::SetLayerIndex%40A237BE01F8.body preserve=yes
	m_nLayerIndex = layerIndex;
  //## end LayerProperty::SetLayerIndex%40A237BE01F8.body
}

void LayerProperty::SetVisible (bool visible)
{
  //## begin LayerProperty::SetVisible%40A237BE01FA.body preserve=yes
	m_isVisible = visible;
  //## end LayerProperty::SetVisible%40A237BE01FA.body
}

// Additional Declarations
  //## begin LayerProperty%40A237BE01E4.declarations preserve=yes
  //## end LayerProperty%40A237BE01E4.declarations

//## begin module%40A237BE01E4.epilog preserve=yes
//## end module%40A237BE01E4.epilog
