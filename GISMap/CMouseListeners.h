
#ifndef CMouseListeners_h
#define CMouseListeners_h 1

//## begin module%3E7A92A10264.additionalIncludes preserve=no
//## end module%3E7A92A10264.additionalIncludes

//## begin module%3E7A92A10264.includes preserve=yes
//## end module%3E7A92A10264.includes

// IMouseListener
#include "IMouseListener.h"
//## begin module%3E7A92A10264.additionalDeclarations preserve=yes
//## end module%3E7A92A10264.additionalDeclarations


//## begin CMouseListeners%3E7A92A10264.preface preserve=yes
#include <map>
using namespace std;
//## end CMouseListeners%3E7A92A10264.preface

//## Class: CMouseListeners%3E7A92A10264
//## Category: RunnerUpCommon%3E57602902DF
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class CMouseListeners
{
  //## begin CMouseListeners%3E7A92A10264.initialDeclarations preserve=yes
  //## end CMouseListeners%3E7A92A10264.initialDeclarations

  public:

    //## Other Operations (specified)
	  CMouseListeners();

	  ~CMouseListeners();
      //## Operation: AddMouseListener%3E7A98400000
      void AddMouseListener (int theKey, IMouseListener* pMouseListener);

      //## Operation: GetCurrentMouseListenerKey%3E8BF77501F5
      int GetCurrentMouseListenerKey ();

      //## Operation: GetCurrentSubMouseListenerKey%3E8BF8EE0319
      int GetCurrentSubMouseListenerKey ();

      //## Operation: SetCurrentMouseListenerKey%3E7A94750361
      int SetCurrentMouseListenerKey (int theKey, int theSubKey);

      //## Operation: GetCurrentMouseListener%3E7A94B00398
      IMouseListener* GetCurrentMouseListener ();

      //## Operation: Find%3E7A94D5039B
      IMouseListener* Find (int theKey);

      //## Operation: RemoveMouseListener%3E7A94DD02DF
      void RemoveMouseListener (IMouseListener* pMouseListener);

      //## Operation: RemoveMouseListener%3E7A94E90250
      void RemoveMouseListener (int theKey);

      //## Operation: RemoveAllMouseListener%3E7A94FF03B0
      void RemoveAllMouseListener ();
    // Additional Public Declarations
      //## begin CMouseListeners%3E7A92A10264.public preserve=yes
      //## end CMouseListeners%3E7A92A10264.public

  protected:
    // Data Members for Class Attributes

      //## Attribute: m_nCurrentMouseListenerKey%3E7A940C003F
      //## begin CMouseListeners::m_nCurrentMouseListenerKey%3E7A940C003F.attr preserve=no  protected: int {UA} 
      int m_nCurrentMouseListenerKey;
      //## end CMouseListeners::m_nCurrentMouseListenerKey%3E7A940C003F.attr

      //## Attribute: m_nCurrentSubMouseListenerKey%3E7AACD1003D
      //## begin CMouseListeners::m_nCurrentSubMouseListenerKey%3E7AACD1003D.attr preserve=no  protected: int {UA} 
      int m_nCurrentSubMouseListenerKey;
      //## end CMouseListeners::m_nCurrentSubMouseListenerKey%3E7AACD1003D.attr

    // Additional Protected Declarations
      //## begin CMouseListeners%3E7A92A10264.protected preserve=yes
      //## end CMouseListeners%3E7A92A10264.protected

  private:
    // Data Members for Class Attributes

      //## Attribute: m_eventlistenerContainer%3E7A93FE0157
      //## begin CMouseListeners::m_MouselistenerContainer%3E7A93FE0157.attr preserve=no  private: map<int,IMouseListener*> {UA} 
      map<int,IMouseListener*> m_MouselistenerContainer;
      //## end CMouseListeners::m_MouselistenerContainer%3E7A93FE0157.attr

    // Additional Private Declarations
      //## begin CMouseListeners%3E7A92A10264.private preserve=yes
      //## end CMouseListeners%3E7A92A10264.private

  private: //## implementation
    // Data Members for Associations

      //## Association: RunnerUpCommon::<unnamed>%3E7A991002EE
      //## Role: CMouseListeners::<the_IMouseListener>%3E7A99110282
      //## begin CMouseListeners::<the_IMouseListener>%3E7A99110282.role preserve=no  public: IMouseListener { -> UgN}
      //## end CMouseListeners::<the_IMouseListener>%3E7A99110282.role

    // Additional Implementation Declarations
      //## begin CMouseListeners%3E7A92A10264.implementation preserve=yes
      //## end CMouseListeners%3E7A92A10264.implementation

};

//## begin CMouseListeners%3E7A92A10264.postscript preserve=yes
//## end CMouseListeners%3E7A92A10264.postscript

// Class CMouseListeners 

//## begin module%3E7A92A10264.epilog preserve=yes
//## end module%3E7A92A10264.epilog


#endif
