//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40A19BA10399.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40A19BA10399.cm

//## begin module%40A19BA10399.cp preserve=no
//## end module%40A19BA10399.cp

//## Module: Layers%40A19BA10399; Pseudo Package body
//## Source file: E:\egis\code\mapcontrol\Layers.cpp

//## begin module%40A19BA10399.additionalIncludes preserve=no
//## end module%40A19BA10399.additionalIncludes

//## begin module%40A19BA10399.includes preserve=yes
//## end module%40A19BA10399.includes

#include "Layers.h"
//## begin module%40A19BA10399.additionalDeclarations preserve=yes
#include "ILayer.h"
#include "maplayer.h"
//## end module%40A19BA10399.additionalDeclarations


// Class Layers 



Layers::Layers()
  //## begin Layers::Layers%40A19BA10399_const.hasinit preserve=no
      : m_nActiveIndex(-1)
  //## end Layers::Layers%40A19BA10399_const.hasinit
  //## begin Layers::Layers%40A19BA10399_const.initialization preserve=yes
  //## end Layers::Layers%40A19BA10399_const.initialization
{
  //## begin Layers::Layers%40A19BA10399_const.body preserve=yes
  //## end Layers::Layers%40A19BA10399_const.body
}


Layers::~Layers()
{
  //## begin Layers::~Layers%40A19BA10399_dest.body preserve=yes
	ILayer *player;
	int i;
	for( i = 0; i < m_vectorLayers.size(); i++ )
	{
		player = m_vectorLayers[ i ];
		if( player->GetLayerType() == 1 )
		{
			delete (MapLayer *)player;
		}
	}
	m_vectorLayers.clear();
  //## end Layers::~Layers%40A19BA10399_dest.body
}



//## Other Operations (implementation)
void Layers::Add (ILayer* layer)
{
  //## begin Layers::Add%40A19BA1039A.body preserve=yes
	m_vectorLayers.push_back( layer );
	if( m_vectorLayers.capacity() - m_vectorLayers.size() > 10 )
	{
		m_vectorLayers.reserve( m_vectorLayers.size() + 9 );
	}
  //## end Layers::Add%40A19BA1039A.body
}

ILayer* Layers::GetLayer (int index)
{
  //## begin Layers::GetLayer%40A19BA1039C.body preserve=yes
	return m_vectorLayers[ index ];
  //## end Layers::GetLayer%40A19BA1039C.body
}

int Layers::Count ()
{
  //## begin Layers::Count%40A19BA1039E.body preserve=yes
	return m_vectorLayers.size();
  //## end Layers::Count%40A19BA1039E.body
}

int Layers::GetActive ()
{
  //## begin Layers::GetActive%40A19BA1039F.body preserve=yes
	return m_nActiveIndex;
  //## end Layers::GetActive%40A19BA1039F.body
}

ILayer* Layers::GetActiveLayer ()
{
  //## begin Layers::GetActiveLayer%40A19C1402FD.body preserve=yes
	return m_vectorLayers[ m_nActiveIndex ];
  //## end Layers::GetActiveLayer%40A19C1402FD.body
}

void Layers::SetActive (int index)
{
  //## begin Layers::SetActive%40A19BA103A0.body preserve=yes
	m_nActiveIndex = index;
  //## end Layers::SetActive%40A19BA103A0.body
}

bool Layers::MoveTo (int fromIndex, int toIndex)
{
  //## begin Layers::MoveTo%40A19BA103A2.body preserve=yes
	ILayer *player;
	player = m_vectorLayers[ fromIndex ];
	m_vectorLayers[ fromIndex ] = m_vectorLayers[ toIndex ];
	m_vectorLayers[ toIndex ] = player;
	return true;
  //## end Layers::MoveTo%40A19BA103A2.body
}

bool Layers::MoveToBottom (int index)
{
  //## begin Layers::MoveToBottom%40A19BA103A5.body preserve=yes
	ILayer *player;
	int n = m_vectorLayers.size() - 1;
	player = m_vectorLayers[ n ] ;
	m_vectorLayers[ n ] = m_vectorLayers[ index ];
	m_vectorLayers[ index ] = player;
	return true;
  //## end Layers::MoveToBottom%40A19BA103A5.body
}

bool Layers::MoveToTop (int index)
{
  //## begin Layers::MoveToTop%40A19BA103A7.body preserve=yes
	ILayer *player;
	player = m_vectorLayers[ 0 ];
	m_vectorLayers[ 0 ] = m_vectorLayers[ index ];
	m_vectorLayers[ index ] = player;
	return true;
  //## end Layers::MoveToTop%40A19BA103A7.body
}

void Layers::Remove (int index)
{
  //## begin Layers::Remove%40A19BA103A9.body preserve=yes
	ILayer *player = m_vectorLayers[ index ];
	m_vectorLayers.erase( m_vectorLayers.begin() + index );

	if( player->GetLayerType() == 1 )
	{
		delete (MapLayer*)player;
	}
  //## end Layers::Remove%40A19BA103A9.body
}

void Layers::Clear ()
{
  //## begin Layers::Clear%40A19BA103AB.body preserve=yes
	ILayer *player;
	int i, count;
	count = m_vectorLayers.size();
	for( i = 0; i < count; i++ )
	{
		player = m_vectorLayers[ i ];
		delete player;
	}
	m_vectorLayers.clear();
  //## end Layers::Clear%40A19BA103AB.body
}

// Additional Declarations
  //## begin Layers%40A19BA10399.declarations preserve=yes
  //## end Layers%40A19BA10399.declarations

//## begin module%40A19BA10399.epilog preserve=yes
//## end module%40A19BA10399.epilog
