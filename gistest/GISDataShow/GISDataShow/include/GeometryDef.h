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
class CGeometryDef   //�������������
{
public:
     CGeometryDef();
     virtual~CGeometryDef()=0;
	 GeometryType GetType();
     bool GetEnvelope(double&XMin,double&YMin,double&XMax,double&YMax);//�õ�����Ӿ���
	 friend class CGeometryFactory;
	 friend class CSpatialRefTrans;
protected:
     GeometryType type;
};
class CPointDef :public CGeometryDef //��
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
class CPointsDef :public CGeometryDef //�㼯
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
class CPolylineDef :public CGeometryDef //��
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
class CPolygonDef :public CGeometryDef //�����
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
class CMultiPolygonDef :public CGeometryDef //����μ���
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
class CGeometryCollectionDef :public CGeometryDef  //�������弯��
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
enum WellKnownGeogCS   //ͨ���ĵ�������ϵͳ
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
	//ͨ��SpatialRef�������õ�������ϵͳ
	bool SetSpatialRef(OGRSpatialReference&osr,CString ProjString);
	bool SetWellKnownWellKnownGeogCS(OGRSpatialReference&osr,WellKnownGeogCS wkg);
	//���ó��õĵ�������ϵͳ
	bool SetUTMProjCS(OGRSpatialReference&osr,int nZone,int bNorth=true);
	//����UTMͶӰ����ϵͳ
	bool SetTM(OGRSpatialReference&osr,double dfCenterLat,double dfCenterLong,double dfScale,double dfFalseEasting,double dfFalseNorthing);
    //����TMͶӰ����ϵͳ
	bool SetMercator(OGRSpatialReference&osr,double dfCenterLat,double dfCenterLong,double dfScale,double dfFalseEasting,double dfFalseNorthing);
    //����MercatorͶӰ����ϵͳ
	bool TransToGeogCSSelf(OGRSpatialReference&SourceCS,CGeometryDef*SourceGeo);
	//�ٶ�SourceCSΪͶӰ����ϵͳ��ֱ������SourceCS����ת��Ϊ��������ϵͳ
    bool TransformSelf(OGRSpatialReference&SourceCS,OGRSpatialReference&TargetCS,CGeometryDef*SourceGeo);
    //��SourceCS��SourceGeoת��ΪTargetCS��GeometryDef,SourceGeo���������ֵ�ı�
	CGeometryDef*TransformToGeogCS(OGRSpatialReference&SourceCS,CGeometryDef*SourceGeo);
	//�ٶ�SourceCSΪͶӰ����ϵͳ��ֱ������SourceCS����ת��Ϊ��������ϵͳTargetCS��GeometryDef����,ʹ�ú�ע��ɾ��
	CGeometryDef*Transform(OGRSpatialReference&SourceCS,OGRSpatialReference&TargetCS,CGeometryDef*SourceGeo);
    //��SourceCS��SourceGeoת��ΪTargetCS��GeometryDef����,ʹ�ú�ע��ɾ��
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
