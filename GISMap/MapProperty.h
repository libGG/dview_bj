//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%40AD5E5200ED.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%40AD5E5200ED.cm

//## begin module%40AD5E5200ED.cp preserve=no
//## end module%40AD5E5200ED.cp

//## Module: MapProperty%40AD5E5200ED; Pseudo Package specification
//## Source file: E:\egisdevelop\code\mapcontrol\MapProperty.h

#ifndef MapProperty_h
#define MapProperty_h 1

//## begin module%40AD5E5200ED.additionalIncludes preserve=no
//## end module%40AD5E5200ED.additionalIncludes

//## begin module%40AD5E5200ED.includes preserve=yes
//## end module%40AD5E5200ED.includes

//## begin module%40AD5E5200ED.additionalDeclarations preserve=yes
//## end module%40AD5E5200ED.additionalDeclarations


//## begin MapProperty%40AD5E5200ED.preface preserve=yes
class MapControl;
//## end MapProperty%40AD5E5200ED.preface

//## Class: MapProperty%40AD5E5200ED
//## Category: mapcontrol%40A18DCA00FA
//## Persistence: Transient
//## Cardinality/Multiplicity: n

class MapProperty 
{
  //## begin MapProperty%40AD5E5200ED.initialDeclarations preserve=yes
  //## end MapProperty%40AD5E5200ED.initialDeclarations

  public:
    //## Constructors (specified)
      //## Operation: MapProperty%40AD5E5200EE
      MapProperty (MapControl* mapCtrl);

    //## Destructor (generated)
      ~MapProperty();


    //## Other Operations (specified)
      //## Operation: ClientToWorld%40AD5E5200F0
      void ClientToWorld (double& x, double& y);

      //## Operation: WorldToClient%40AD5E5200F3
      void WorldToClient (double& x, double& y);

      //## Operation: GetClipRect%40AD5E5200F6
      void GetClipRect (int& x, int& y, int& w, int& h);

      //## Operation: SetClipRect%40AD6128007D
      void SetClipRect (int x, int y, int w, int h);

    // Additional Public Declarations
      //## begin MapProperty%40AD5E5200ED.public preserve=yes
	  double GetViewScale();

	  void ClientToWorldEx (double& x, double& y);

      void WorldToClientEx (double& x, double& y);

	  // 基于屏幕坐标系旋转，参数必须为屏幕坐标
	  void RotateBaseOnClient(double& x, double& y, bool direction);
	  // 基于地理坐标系旋转，参数必须为地理坐标
	  void RotateBaseOnWorld(double& x, double& y, bool direction);
      //## end MapProperty%40AD5E5200ED.public

  protected:
    // Additional Protected Declarations
      //## begin MapProperty%40AD5E5200ED.protected preserve=yes
      //## end MapProperty%40AD5E5200ED.protected

  private:
    // Additional Private Declarations
      //## begin MapProperty%40AD5E5200ED.private preserve=yes
      //## end MapProperty%40AD5E5200ED.private

  private: //## implementation
    // Data Members for Class Attributes

      //## Attribute: m_pMapControl%40AD5E5200FB
      //## begin MapProperty::m_pMapControl%40AD5E5200FB.attr preserve=no  private: MapControl* {U} 
      MapControl* m_pMapControl;
      //## end MapProperty::m_pMapControl%40AD5E5200FB.attr

      //## Attribute: m_nClipX%40AD5E5200FC
      //## begin MapProperty::m_nClipX%40AD5E5200FC.attr preserve=no  private: int {U} 
      int m_nClipX;
      //## end MapProperty::m_nClipX%40AD5E5200FC.attr

      //## Attribute: m_nClipY%40AD5E5200FD
      //## begin MapProperty::m_nClipY%40AD5E5200FD.attr preserve=no  private: int {U} 
      int m_nClipY;
      //## end MapProperty::m_nClipY%40AD5E5200FD.attr

      //## Attribute: m_nClipWidth%40AD5E5200FE
      //## begin MapProperty::m_nClipWidth%40AD5E5200FE.attr preserve=no  private: int {U} 
      int m_nClipWidth;
      //## end MapProperty::m_nClipWidth%40AD5E5200FE.attr

      //## Attribute: m_nClipHeight%40AD5E5200FF
      //## begin MapProperty::m_nClipHeight%40AD5E5200FF.attr preserve=no  private: int {U} 
      int m_nClipHeight;
      //## end MapProperty::m_nClipHeight%40AD5E5200FF.attr

    // Additional Implementation Declarations
      //## begin MapProperty%40AD5E5200ED.implementation preserve=yes
      //## end MapProperty%40AD5E5200ED.implementation

};

//## begin MapProperty%40AD5E5200ED.postscript preserve=yes
//## end MapProperty%40AD5E5200ED.postscript

// Class MapProperty 

//## begin module%40AD5E5200ED.epilog preserve=yes
//## end module%40AD5E5200ED.epilog


#endif
