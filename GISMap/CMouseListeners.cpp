
// CMouseListeners
#include "CMouseListeners.h"
//## begin module%3E7A92A10264.additionalDeclarations preserve=yes
//## end module%3E7A92A10264.additionalDeclarations


// Class CMouseListeners 
CMouseListeners::CMouseListeners()
{
	this->m_nCurrentMouseListenerKey = EMAP_TOOL_NULL;
	this->m_nCurrentSubMouseListenerKey = EMAP_TOOL_NULL;
}

CMouseListeners::~CMouseListeners()
{
	this->RemoveAllMouseListener();
	this->m_nCurrentMouseListenerKey = EMAP_TOOL_NULL;
	this->m_nCurrentSubMouseListenerKey = EMAP_TOOL_NULL;
}

void CMouseListeners::AddMouseListener (int theKey, IMouseListener* pMouseListener)
{
  //## begin CMouseListeners::AddMouseListener%3E7A98400000.body preserve=yes
	if ( pMouseListener == 0 )	return ;
	m_MouselistenerContainer.insert(map<int,IMouseListener*>::value_type(theKey,pMouseListener) ) ;
  //## end CMouseListeners::AddMouseListener%3E7A98400000.body
}

int CMouseListeners::GetCurrentMouseListenerKey ()
{
  //## begin CMouseListeners::GetCurrentMouseListenerKey%3E8BF77501F5.body preserve=yes
	return m_nCurrentMouseListenerKey ;
  //## end CMouseListeners::GetCurrentMouseListenerKey%3E8BF77501F5.body
}

int CMouseListeners::GetCurrentSubMouseListenerKey ()
{
  //## begin CMouseListeners::GetCurrentSubMouseListenerKey%3E8BF8EE0319.body preserve=yes
	return m_nCurrentSubMouseListenerKey ;
  //## end CMouseListeners::GetCurrentSubMouseListenerKey%3E8BF8EE0319.body
}

int CMouseListeners::SetCurrentMouseListenerKey (int theKey, int theSubKey)
{
  //## begin CMouseListeners::SetCurrentMouseListenerKey%3E7A94750361.body preserve=yes
	int oldKey = m_nCurrentMouseListenerKey ;
	this ->m_nCurrentMouseListenerKey = theKey ;
	this ->m_nCurrentSubMouseListenerKey = theSubKey ;
	return oldKey ;
  //## end CMouseListeners::SetCurrentMouseListenerKey%3E7A94750361.body
}

IMouseListener* CMouseListeners::GetCurrentMouseListener ()
{
  //## begin CMouseListeners::GetCurrentMouseListener%3E7A94B00398.body preserve=yes
	return m_MouselistenerContainer[m_nCurrentMouseListenerKey] ;
  //## end CMouseListeners::GetCurrentMouseListener%3E7A94B00398.body
}

IMouseListener* CMouseListeners::Find (int theKey)
{
  //## begin CMouseListeners::Find%3E7A94D5039B.body preserve=yes
	return m_MouselistenerContainer[theKey];
  //## end CMouseListeners::Find%3E7A94D5039B.body
}

void CMouseListeners::RemoveMouseListener (IMouseListener* pMouseListener)
{
  //## begin CMouseListeners::RemoveMouseListener%3E7A94DD02DF.body preserve=yes
	map<int,IMouseListener*>::iterator iterator ;
	for ( iterator = m_MouselistenerContainer.begin(); iterator != m_MouselistenerContainer.end() ; iterator ++ )
	{
		if ( (*iterator).second == pMouseListener )
			break ;
	}

	IMouseListener *tobedeleteMouseListener = (*iterator).second ;
	delete tobedeleteMouseListener ;
	tobedeleteMouseListener = 0 ;
	(*iterator).second = 0 ;
	pMouseListener = 0 ;

	m_MouselistenerContainer.erase ( iterator ) ;
  //## end CMouseListeners::RemoveMouseListener%3E7A94DD02DF.body
}

void CMouseListeners::RemoveMouseListener (int theKey)
{
  //## begin CMouseListeners::RemoveMouseListener%3E7A94E90250.body preserve=yes
	map<int,IMouseListener*>::iterator iterator ;
	iterator = m_MouselistenerContainer.find( theKey );
	if ( iterator != m_MouselistenerContainer.end() )
	{
		IMouseListener *tobedeleteMouseListener = (*iterator).second ;
		if ( tobedeleteMouseListener )
			delete tobedeleteMouseListener ;
		tobedeleteMouseListener = 0 ;
		(*iterator).second = 0 ;
	}
	m_MouselistenerContainer.erase ( iterator ) ;
  //## end CMouseListeners::RemoveMouseListener%3E7A94E90250.body
}

void CMouseListeners::RemoveAllMouseListener ()
{
  //## begin CMouseListeners::RemoveAllMouseListener%3E7A94FF03B0.body preserve=yes
	map<int,IMouseListener*>::iterator iterator ;
	for ( iterator = m_MouselistenerContainer.begin(); iterator != m_MouselistenerContainer.end() ; iterator ++ )
	{
		IMouseListener *pMouseListener = (*iterator).second ;
		if ( pMouseListener )
		{
			delete pMouseListener;
			pMouseListener = 0 ;
			(*iterator).second = 0;
		}
	}
	m_MouselistenerContainer.clear () ;
  //## end CMouseListeners::RemoveAllMouseListener%3E7A94FF03B0.body
}

// Additional Declarations
  //## begin CMouseListeners%3E7A92A10264.declarations preserve=yes
  //## end CMouseListeners%3E7A92A10264.declarations

//## begin module%3E7A92A10264.epilog preserve=yes
//## end module%3E7A92A10264.epilog
