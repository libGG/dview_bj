#pragma once
#include "gdal\gdal_priv.h"
#include "gdal\ogrsf_frmts.h"
#include "baseclass.h"
class CGeometryDef;
class CPointDef;
class CPointsDef;
class CPolylineDef;
class CPolygonDef;
class CMultiPolygonDef;
class CGeometryCollectionDef;
class CGeometryFactory;
class CSpatialRefTrans;
enum GeometryType
{
	gUnknown=0,
	gPoint=1,
	gPoints=2,
	gPolyline=3,
	gPolygon=4,
	gMultiPolygon=5,
    gCollection=6
};
class CGeometryDef   //几何形体抽象类
{
public:
     CGeometryDef();
     virtual~CGeometryDef()=0;
	 GeometryType GetType();
     bool GetEnvelope(double&XMin,double&YMin,double&XMax,double&YMax);//得到其外接矩形
	 friend class CGeometryFactory;
	 friend class CSpatialRefTrans;
protected:
     GeometryType type;
};
class CPointDef :public CGeometryDef //点
{
public:
	CPointDef();
    CPointDef(double x,double y,double z);
	virtual~CPointDef();
	double GetX();
	double GetY();
	double GetZ();
	void SetX(double x);
    void SetY(double y);
	void SetZ(double z);
	friend class CGeometryFactory;
	friend class CSpatialRefTrans;
protected:
    double X;
	double Y;
	double Z;
}; 
class CPointsDef :public CGeometryDef //点集
{
public:
	CPointsDef();
	virtual~CPointsDef();
	long GetCount();
	CPointDef*Item(long index);
	void AddPoint(double X,double Y,double Z=0);
	void RemoveAt(long index);
	void RemoveAll();
	friend class CGeometryFactory;
	friend class CSpatialRefTrans;
protected:
    CArray<CPointDef*,CPointDef*>pts;
};
class CPolylineDef :public CGeometryDef //线
{
public:
	CPolylineDef();
	virtual~CPolylineDef();
	long GetCount();
	CPointsDef*Item(long index);
	void AddNewPart();
	void Add(CPointsDef*pts)
	{
		parts.Add(pts);
	};
	void RemoveAt(long index);
	void RemoveAll();
	friend class CGeometryFactory;
	friend class CSpatialRefTrans;
protected:
    CArray<CPointsDef*,CPointsDef*>parts;
};
class CPolygonDef :public CGeometryDef //多边形
{
public:
	CPolygonDef();
	virtual~CPolygonDef();
	long GetCount();
	CPointsDef*Item(long index);
	void AddNewPart();
	void Add(CPointsDef*pts)
	{
		parts.Add(pts);
	};
	void RemoveAt(long index);
	void RemoveAll();
	friend class CGeometryFactory;
	friend class CSpatialRefTrans;
protected:
    CArray<CPointsDef*,CPointsDef*>parts;
};
class CMultiPolygonDef :public CGeometryDef //多边形集合
{
public:
	CMultiPolygonDef();
	virtual~CMultiPolygonDef();
	long GetCount();
	CPolygonDef*Item(long index);
	void AddNewPart();
	void Add(CPolygonDef*poly)
	{
		parts.Add(poly);
	};
	void RemoveAt(long index);
	void RemoveAll();
	friend class CGeometryFactory;
	friend class CSpatialRefTrans;
protected:
    CArray<CPolygonDef*,CPolygonDef*>parts;
};
class CGeometryCollectionDef :public CGeometryDef  //几何形体集合
{
public:
    CGeometryCollectionDef();
	virtual~CGeometryCollectionDef();
	long GetCount();
	CGeometryDef*Item(long index);
	void AddNewPart(CGeometryDef*pGeo);
	void RemoveAt(long index);
	void RemoveAll();
	friend class CGeometryFactory;
	friend class CSpatialRefTrans;
protected:
    CArray<CGeometryDef*,CGeometryDef*>parts;
};
class CGeometryFactory
{
public:
	CGeometryFactory();
	virtual~CGeometryFactory();
    CGeometryDef*CreateGeometry(OGRGeometry*pGeo);
	bool ConvertGeometry(CGeometryDef*pDef,OGRPoint&def);
	bool ConvertGeometry(CGeometryDef*pDef,OGRMultiPoint&def);
    bool ConvertGeometry(CGeometryDef*pDef,OGRLineString&def);
    bool ConvertGeometry(CGeometryDef*pDef,OGRMultiLineString&def);
    bool ConvertGeometry(CGeometryDef*pDef,OGRPolygon&def);
    bool ConvertGeometry(CGeometryDef*pDef,OGRMultiPolygon&def);
    bool ConvertGeometry(CGeometryDef*pDef,OGRGeometryCollection&def);
protected:
    CPointDef*CreatePoint(OGRPoint*def);
    CPointsDef*CreatePoints(OGRMultiPoint*def);
    CPolylineDef*CreatePolyline(OGRLineString*def);
    CPolylineDef*CreatePolyline(OGRMultiLineString*def);
    CPolygonDef*CreatePolygon(OGRPolygon*def);
    CMultiPolygonDef*CreateMultiPolygon(OGRMultiPolygon*def);
    CGeometryCollectionDef*CreateCollection(OGRGeometryCollection*def);
protected:
	void ConvertPoint(CPointDef*pDef,OGRPoint&def);
    void ConvertPoints(CPointsDef*pDef,OGRMultiPoint&def);
	void ConvertPolyline(CPointsDef*pts,OGRLineString&def);
    void ConvertPolyline(CPolylineDef*pDef,OGRLineString&def);
    void ConvertComplexPolyline(CPolylineDef*pDef,OGRMultiLineString&def);
    void ConvertRing(CPointsDef*pts,OGRLinearRing&def);
	void ConvertPolygon(CPolygonDef*pDef,OGRPolygon&def);
    void ConvertMultiPolygon(CMultiPolygonDef*pDef,OGRMultiPolygon&def);
    void ConvertGeometryCollection(CGeometryCollectionDef*pDef,OGRGeometryCollection&def);
};
struct SpatialRef
{
    CString DatumName;
	double SemiMajor;
	double InvFlattening;
	double PMOffset;
	CString Units;
	double ConvertToRadians;
};
enum WellKnownGeogCS   //通常的地理坐标系统
{
    NAD27=1,
	NAD83=2,
	WGS72=3,
	WGS84=4
};
class CEmbedSpatialRef
{
public:
    CEmbedSpatialRef();
	virtual~CEmbedSpatialRef();
	bool LoadEmbedSpatial();
	CString GetGeogCSInfo(CString sID);
	CString GetProjCSInfo(CString sID);
	CString GetProjInfo(CString sID);
	bool GetHasSuccessfulLoad();
	CCSVDatabase*GetEmbedGeog();
    CCSVDatabase*GetEmbedProj();
private:
	CCSVDatabase gcs;
	CCSVDatabase pcs;
	CCSVDatabase datum;
	CCSVDatabase ellipsiod;
	int LoadState;
};
class CSpatialRefTrans  
{
public:
	CSpatialRefTrans();
	virtual ~CSpatialRefTrans();
	OGRCoordinateTransformation*GetTransForm(OGRSpatialReference&SourceCS,OGRSpatialReference&TargetCS);
    bool TransformSelf(OGRCoordinateTransformation*poCT,CGeometryDef*SourceGeo);
    bool SetGeoCS(OGRSpatialReference&osr,SpatialRef ref);
	//通过SpatialRef参数设置地理坐标系统
	bool SetSpatialRef(OGRSpatialReference&osr,CString ProjString);
	bool SetWellKnownWellKnownGeogCS(OGRSpatialReference&osr,WellKnownGeogCS wkg);
	//设置常用的地理坐标系统
	bool SetUTMProjCS(OGRSpatialReference&osr,int nZone,int bNorth=true);
	//设置UTM投影坐标系统
	bool SetTM(OGRSpatialReference&osr,double dfCenterLat,double dfCenterLong,double dfScale,double dfFalseEasting,double dfFalseNorthing);
    //设置TM投影坐标系统
	bool SetMercator(OGRSpatialReference&osr,double dfCenterLat,double dfCenterLong,double dfScale,double dfFalseEasting,double dfFalseNorthing);
    //设置Mercator投影坐标系统
	bool TransToGeogCSSelf(OGRSpatialReference&SourceCS,CGeometryDef*SourceGeo);
	//假定SourceCS为投影坐标系统，直接依据SourceCS将其转换为地理坐标系统
    bool TransformSelf(OGRSpatialReference&SourceCS,OGRSpatialReference&TargetCS,CGeometryDef*SourceGeo);
    //将SourceCS的SourceGeo转换为TargetCS的GeometryDef,SourceGeo本身的坐标值改变
	CGeometryDef*TransformToGeogCS(OGRSpatialReference&SourceCS,CGeometryDef*SourceGeo);
	//假定SourceCS为投影坐标系统，直接依据SourceCS将其转换为地理坐标系统TargetCS的GeometryDef返回,使用后注意删除
	CGeometryDef*Transform(OGRSpatialReference&SourceCS,OGRSpatialReference&TargetCS,CGeometryDef*SourceGeo);
    //将SourceCS的SourceGeo转换为TargetCS的GeometryDef返回,使用后注意删除
	DRect TransformRect(OGRSpatialReference*SourceCS,OGRSpatialReference*TargetCS,DRect rt);
protected:
    bool TransformPointSelf(OGRCoordinateTransformation*poCT,CPointDef*source);
    bool TransformPointsSelf(OGRCoordinateTransformation*poCT,CPointsDef*source);
	bool TransformPolylineSelf(OGRCoordinateTransformation*poCT,CPolylineDef*source);
    bool TransformPolygonSelf(OGRCoordinateTransformation*poCT,CPolygonDef*source);
    bool TransformMultiPolygonSelf(OGRCoordinateTransformation*poCT,CMultiPolygonDef*source);
    bool TransformCollectionSelf(OGRCoordinateTransformation*poCT,CGeometryCollectionDef*source);
    bool TransformGeometrySelf(OGRCoordinateTransformation*poCT,CGeometryDef*SourceGeo);

	CPointDef*TransformPoint(OGRCoordinateTransformation*poCT,CPointDef*source);
    CPointsDef*TransformPoints(OGRCoordinateTransformation*poCT,CPointsDef*source);
	CPolylineDef*TransformPolyline(OGRCoordinateTransformation*poCT,CPolylineDef*source);
    CPolygonDef*TransformPolygon(OGRCoordinateTransformation*poCT,CPolygonDef*source);
    CMultiPolygonDef*TransformMultiPolygon(OGRCoordinateTransformation*poCT,CMultiPolygonDef*source);
    CGeometryCollectionDef*TransformCollection(OGRCoordinateTransformation*poCT,CGeometryCollectionDef*source);
    CGeometryDef*TransformGeometry(OGRCoordinateTransformation*poCT,CGeometryDef*SourceGeo);
	CEmbedSpatialRef*ems;
};
