
#ifndef IMouseListener_h
#define IMouseListener_h 1

//## begin module%3D79A4100275.additionalIncludes preserve=no
//## end module%3D79A4100275.additionalIncludes

//## begin module%3D79A4100275.includes preserve=yes
//工具类型
enum 
{
	EMAP_TOOL_NULL	= 0,					// 缺省状态下的工具状态

	EMAP_TOOL_MAPVIEW_CONTROLLER = 10,		// 视图的控制工具。  其子工具包括：
									
		EMAP_TOOL_ZOOMIN = 11,				// 缩小
		EMAP_TOOL_ZOOMOUT = 12,				// 放大
		EMAP_TOOL_PAN = 13					// 抓取滚动屏幕
};
//## end module%3D79A4100275.includes

class CMouseEvent;

//## begin module%3D79A4100275.additionalDeclarations preserve=yes
//## end module%3D79A4100275.additionalDeclarations


//## begin IMouseListener%3D79A4100275.preface preserve=yes
//## end IMouseListener%3D79A4100275.preface

//## Class: IMouseListener%3D79A4100275
//	IMouseListener接口：鼠标事件监听接口
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
      //	鼠标左键被按下。
      virtual void OnLButtonDown (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnLButtonUp%3D79A4100278
      //	鼠标左键被抬起。
      virtual void OnLButtonUp (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnLButtonDBLClick%3D79A410027A
      //	鼠标左键被双击。
      virtual void OnLButtonDBLClick (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnRButtonDown%3D79A410027C
      //	鼠标右键被按下。
      virtual void OnRButtonDown (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnRButtonUp%3D79A410027E
      //	鼠标右键被抬起。
      virtual void OnRButtonUp (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnMouseMove%3D79A4100280
      //	鼠标移动
      virtual void OnMouseMove (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnMouseDrag%3D79A4100282
      //	鼠标拖动
      virtual void OnMouseDrag (CMouseEvent* pMouseEvent) = 0;

      //## Operation: OnCancel%3D79A4100284
      //	取消操作。
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
