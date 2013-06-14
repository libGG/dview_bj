
#ifndef IMouseListener_h
#define IMouseListener_h 1

//## begin module%3D79A4100275.additionalIncludes preserve=no
//## end module%3D79A4100275.additionalIncludes

//## begin module%3D79A4100275.includes preserve=yes
//��������
enum 
{
	EMAP_TOOL_NULL	= 0,					// ȱʡ״̬�µĹ���״̬

	EMAP_TOOL_MAPVIEW_CONTROLLER = 10,		// ��ͼ�Ŀ��ƹ��ߡ�  ���ӹ��߰�����
									
		EMAP_TOOL_ZOOMIN = 11,				// ��С
		EMAP_TOOL_ZOOMOUT = 12,				// �Ŵ�
		EMAP_TOOL_PAN = 13					// ץȡ������Ļ
};
//## end module%3D79A4100275.includes

class CMouseEvent;

//## begin module%3D79A4100275.additionalDeclarations preserve=yes
//## end module%3D79A4100275.additionalDeclarations


//## begin IMouseListener%3D79A4100275.preface preserve=yes
//## end IMouseListener%3D79A4100275.preface

//## Class: IMouseListener%3D79A4100275
//	IMouseListener�ӿڣ�����¼������ӿ�
//## Category: RunnerUpCommon%3E57602902DF
//## Persistence: Transient
//## Cardinality/Multiplicity: n

//## Uses: <unnamed>%3D79A6050257;CMouseEvent { -> F}

class IMouseListener
{
  //## begin IMouseListener%3D79A4100275.initialDeclarations preserve=yes
  //## end IMouseListener%3D79A4100275.initialDeclarations

  public:

    //## Other Operations (specified)
      //## Operation: OnLButtonDown%3D79A4100276
      //	�����������¡�
      virtual void OnLButtonDown (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnLButtonUp%3D79A4100278
      //	��������̧��
      virtual void OnLButtonUp (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnLButtonDBLClick%3D79A410027A
      //	��������˫����
      virtual void OnLButtonDBLClick (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnRButtonDown%3D79A410027C
      //	����Ҽ������¡�
      virtual void OnRButtonDown (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnRButtonUp%3D79A410027E
      //	����Ҽ���̧��
      virtual void OnRButtonUp (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnMouseMove%3D79A4100280
      //	����ƶ�
      virtual void OnMouseMove (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnMouseDrag%3D79A4100282
      //	����϶�
      virtual void OnMouseDrag (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnCancel%3D79A4100284
      //	ȡ��������
      virtual void OnCancel () = 0;

    // Additional Public Declarations
      //## begin IMouseListener%3D79A4100275.public preserve=yes
      //## end IMouseListener%3D79A4100275.public

  protected:
    // Additional Protected Declarations
      //## begin IMouseListener%3D79A4100275.protected preserve=yes
      //## end IMouseListener%3D79A4100275.protected

  private:
    // Additional Private Declarations
      //## begin IMouseListener%3D79A4100275.private preserve=yes
      //## end IMouseListener%3D79A4100275.private

  private: //## implementation
    // Additional Implementation Declarations
      //## begin IMouseListener%3D79A4100275.implementation preserve=yes
      //## end IMouseListener%3D79A4100275.implementation

};

//## begin IMouseListener%3D79A4100275.postscript preserve=yes
//## end IMouseListener%3D79A4100275.postscript

// Class IMouseListener 

//## begin module%3D79A4100275.epilog preserve=yes
//## end module%3D79A4100275.epilog


#endif
