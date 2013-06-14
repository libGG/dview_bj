

#ifndef CViewCtrlMouseListener_h
#define CViewCtrlMouseListener_h 1

//## begin module%3DC0C5E90333.additionalIncludes preserve=no
//## end module%3DC0C5E90333.additionalIncludes

//## begin module%3DC0C5E90333.includes preserve=yes
//## end module%3DC0C5E90333.includes

// IMAP_MouseListener
#include "IMouseListener.h"
//## begin module%3DC0C5E90333.additionalDeclarations preserve=yes
//## end module%3DC0C5E90333.additionalDeclarations


//## begin CViewCtrlMouseListener%3DC0C5E90333.preface preserve=yes
//## end CViewCtrlMouseListener%3DC0C5E90333.preface

//## Class: CViewCtrlMouseListener%3DC0C5E90333
//	IMAP_MouseListener�ӿڣ�����¼������ӿ�
//## Category: RunnerUpME%3D76175B03CF
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class CViewCtrlMouseListener : public IMouseListener  //## Inherits: <unnamed>%3DC0C5F2021F
{
  //## begin CViewCtrlMouseListener%3DC0C5E90333.initialDeclarations preserve=yes
  //## end CViewCtrlMouseListener%3DC0C5E90333.initialDeclarations

  public:
    //## Constructors (generated)
      CViewCtrlMouseListener();

    //## Destructor (generated)
      ~CViewCtrlMouseListener();


    //## Other Operations (specified)
      //## Operation: OnLButtonDown%3DC0C5E90334
      //	�����������¡�
      void OnLButtonDown (CMouseEvent* pMouseEvent);

      //## Operation: OnLButtonUp%3DC0C5E90336
      //	��������̧��
      void OnLButtonUp (CMouseEvent* pMouseEvent);

      //## Operation: OnLButtonDBLClick%3DC0C5E90338
      //	��������˫����
      void OnLButtonDBLClick (CMouseEvent* pMouseEvent);

      //## Operation: OnRButtonDown%3DC0C5E9033A
      //	����Ҽ������¡�
      void OnRButtonDown (CMouseEvent* pMouseEvent);

      //## Operation: OnRButtonUp%3DC0C5E9033C
      //	����Ҽ���̧��
      void OnRButtonUp (CMouseEvent* pMouseEvent);

      //## Operation: OnMouseMove%3DC0C5E9033E
      //	����ƶ�
      void OnMouseMove (CMouseEvent* pMouseEvent);

      //## Operation: OnMouseDrag%3DC0C5E90340
      //	����϶�
      void OnMouseDrag (CMouseEvent* pMouseEvent);

      //## Operation: OnCancel%3DC0C5E90342
      //	ȡ��������
      void OnCancel ();

    // Additional Public Declarations
      //## begin CViewCtrlMouseListener%3DC0C5E90333.public preserve=yes
      //## end CViewCtrlMouseListener%3DC0C5E90333.public

  protected:
    // Additional Protected Declarations
      //## begin CViewCtrlMouseListener%3DC0C5E90333.protected preserve=yes
      //## end CViewCtrlMouseListener%3DC0C5E90333.protected

  private:
    // Additional Private Declarations
      //## begin CViewCtrlMouseListener%3DC0C5E90333.private preserve=yes
	  CPoint m_LButtonPoint ;
	  CPoint m_lastPoint ;
      //## end CViewCtrlMouseListener%3DC0C5E90333.private
  private: //## implementation
    // Additional Implementation Declarations
      //## begin CViewCtrlMouseListener%3DC0C5E90333.implementation preserve=yes
      //## end CViewCtrlMouseListener%3DC0C5E90333.implementation

};

//## begin CViewCtrlMouseListener%3DC0C5E90333.postscript preserve=yes
//## end CViewCtrlMouseListener%3DC0C5E90333.postscript

// Class CViewCtrlMouseListener 

//## begin module%3DC0C5E90333.epilog preserve=yes
//## end module%3DC0C5E90333.epilog


#endif
