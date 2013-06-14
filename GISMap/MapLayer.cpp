//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A1D1BD00FA.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A1D1BD00FA.cm

//## begin module%40A1D1BD00FA.cp preserve=no
//## end module%40A1D1BD00FA.cp

//## Module: MapLayer%40A1D1BD00FA; Pseudo Package body
//## Source file: E:\egis\code\mapcontrol\MapLayer.cpp

//## begin module%40A1D1BD00FA.additionalIncludes preserve=no
//## end module%40A1D1BD00FA.additionalIncludes

//## begin module%40A1D1BD00FA.includes preserve=yes
//## end module%40A1D1BD00FA.includes

#include "MapLayer.h"
//## begin module%40A1D1BD00FA.additionalDeclarations preserve=yes
#include "LayerProperty.h"
#include "FeatureClass.h"
//## end module%40A1D1BD00FA.additionalDeclarations


// Class MapLayer 



MapLayer::MapLayer (LayerProperty* layerProperty)
  //## begin MapLayer::MapLayer%40A1D1BD00FC.hasinit preserve=no
      : m_pRender(0)
  //## end MapLayer::MapLayer%40A1D1BD00FC.hasinit
  //## begin MapLayer::MapLayer%40A1D1BD00FC.initialization preserve=yes
  //## end MapLayer::MapLayer%40A1D1BD00FC.initialization
{
  //## begin MapLayer::MapLayer%40A1D1BD00FC.body preserve=yes
	m_pLayerProperty = layerProperty;
  //## end MapLayer::MapLayer%40A1D1BD00FC.body
}


MapLayer::~MapLayer()
{
  //## begin MapLayer::~MapLayer%40A1D1BD00FA_dest.body preserve=yes
	if ( m_pLayerProperty != 0 )
	{
		delete m_pLayerProperty;
		m_pLayerProperty = 0 ;
	}

	if ( m_pRender != 0 )
	{
		delete m_pRender ;
		m_pRender = 0 ;
	}
  //## end MapLayer::~MapLayer%40A1D1BD00FA_dest.body
}



//## Other Operations (implementation)
int MapLayer::GetLayerType ()
{
  //## begin MapLayer::GetLayerType%40A1D1BD00FF.body preserve=yes
	return 1;
  //## end MapLayer::GetLayerType%40A1D1BD00FF.body
}

const char* MapLayer::GetLayerName ()
{
  //## begin MapLayer::GetLayerName%40A1D1BD0100.body preserve=yes
	return m_pLayerProperty->GetLayerName();
  //## end MapLayer::GetLayerName%40A1D1BD0100.body
}

bool MapLayer::IsVisible ()
{
  //## begin MapLayer::IsVisible%40A1D1BD0101.body preserve=yes
	return m_pLayerProperty->IsVisible();
  //## end MapLayer::IsVisible%40A1D1BD0101.body
}

LayerProperty& MapLayer::GetProperty ()
{
  //## begin MapLayer::GetProperty%40A1D1BD0102.body preserve=yes
	return *m_pLayerProperty;
  //## end MapLayer::GetProperty%40A1D1BD0102.body
}

IRender& MapLayer::GetRender ()
{
  //## begin MapLayer::GetRender%40A1D1BD0103.body preserve=yes
	return *m_pRender;
  //## end MapLayer::GetRender%40A1D1BD0103.body
}

void MapLayer::SetVisible (bool bVisible)
{
  //## begin MapLayer::SetVisible%40A1D1BD0104.body preserve=yes
	m_pLayerProperty->SetVisible( bVisible );
  //## end MapLayer::SetVisible%40A1D1BD0104.body
}

void MapLayer::SetRender (IRender* renderObj)
{
  //## begin MapLayer::SetRender%40A1D1BD0106.body preserve=yes
	if ( m_pRender != 0 )
	{
		delete m_pRender ;
		m_pRender = 0 ;
	}
	m_pRender = renderObj;
  //## end MapLayer::SetRender%40A1D1BD0106.body
}

void MapLayer::GetBound (double& x, double& y, double& w, double& h)
{
  //## begin MapLayer::GetBound%40A1D1BD0108.body preserve=yes
	double minx, miny, width, height;

	FeatureClass& dataset = (FeatureClass&)m_pLayerProperty->GetRelateDataSet();
	dataset.GetBound( minx, miny, width, height );
	x = minx;
	y = miny;
	w = width;
	h = height;
  //## end MapLayer::GetBound%40A1D1BD0108.body
}

// Additional Declarations
  //## begin MapLayer%40A1D1BD00FA.declarations preserve=yes
  //## end MapLayer%40A1D1BD00FA.declarations

//## begin module%40A1D1BD00FA.epilog preserve=yes
//## end module%40A1D1BD00FA.epilog
