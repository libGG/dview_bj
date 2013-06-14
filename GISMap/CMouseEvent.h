
#ifndef CMouseEvent_h
#define CMouseEvent_h 1

//## begin module%3D7871E20168.additionalIncludes preserve=no
//## end module%3D7871E20168.additionalIncludes

//## begin module%3D7871E20168.includes preserve=yes
//## end module%3D7871E20168.includes


//## begin CMouseEvent%3D7871E20168.preface preserve=yes
//## end CMouseEvent%3D7871E20168.preface

//## Class: CMouseEvent%3D7871E20168
//	CMouseEvent�ࣺ����¼��ࡣ
//## Category: RunnerUpCommon%3E57602902DF
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class CMouseEvent
{
  //## begin CMouseEvent%3D7871E20168.initialDeclarations preserve=yes
  //## end CMouseEvent%3D7871E20168.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: CMouseEvent%3D7871E20172
      //	���캯����
      //	�ڹ���ö���ʱ����ʼ������Ա������
      CMouseEvent (void* pSource, CPoint point, int mouseFlag, int theTool = -1);

    //## Destructor (generated)
      ~CMouseEvent();


    //## Other Operations (specified)
      //## Operation: GetPoint%3D7871E20187
      //	��ȡ��ǰ������ڵ�����ꡣ������Ϊ�豸���ꡣ
      CPoint GetPoint ();

      //## Operation: GetMouseFlag%3D7871E20188
      //	��ȡ��ǰ�����Ƽ���״̬��
      int GetMouseFlag ();

      //## Operation: GetTool%3D7871E20189
      //	��ȡ��ǰ�������ߵ��ӹ������͡�
      int GetTool ();

    // Additional Public Declarations
      //## begin CMouseEvent%3D7871E20168.public preserve=yes
	  void* GetSource ();
      //## end CMouseEvent%3D7871E20168.public

  protected:
    // Additional Protected Declarations
      //## begin CMouseEvent%3D7871E20168.protected preserve=yes
      //## end CMouseEvent%3D7871E20168.protected

  private:
    // Data Members for Class Attributes

      //## Attribute: m_Point%3D7871E2018B
      //	��ǰ������ڵ�����ꡣ������Ϊ�豸���ꡣ
      //## begin CMouseEvent::m_Point%3D7871E2018B.attr preserve=no  private: CMAP_Vertex {UA} 
      CPoint m_Point;
      //## end CMouseEvent::m_Point%3D7871E2018B.attr

      //## Attribute: m_MouseFlag%3D7871E20190
      //	������ǰ�Ƿ��п��Ƽ������¡����EGIS_MouseFlag��˵����
      //## begin CMouseEvent::m_MouseFlag%3D7871E20190.attr preserve=no  private: int {UA} 
      int m_MouseFlag;
      //## end CMouseEvent::m_MouseFlag%3D7871E20190.attr

      //## Attribute: m_tool%3D7871E20191
      //	��ǰ�������ߵ��ӹ������͡�
      //## begin CMouseEvent::m_tool%3D7871E20191.attr preserve=no  private: int {UA} 
      int m_tool;
      //## end CMouseEvent::m_tool%3D7871E20191.attr

    // Additional Private Declarations
      //## begin CMouseEvent%3D7871E20168.private preserve=yes
	  void* m_pSource;
      //## end CMouseEvent%3D7871E20168.private

  private: //## implementation
    // Additional Implementation Declarations
      //## begin CMouseEvent%3D7871E20168.implementation preserve=yes
      //## end CMouseEvent%3D7871E20168.implementation

};

//## begin CMouseEvent%3D7871E20168.postscript preserve=yes
//## end CMouseEvent%3D7871E20168.postscript

// Class CMouseEvent 

//## begin module%3D7871E20168.epilog preserve=yes
//## end module%3D7871E20168.epilog


#endif
