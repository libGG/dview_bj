#pragma once
#include "baseclass.h"
#include "geometrydef.h"
struct RGBColor
{
	int r;
	int g;
	int b;
};
class CColorTable
{
public:
	CColorTable();
	virtual~CColorTable();
	int GetCount();
	int GetR(int index);
    int GetG(int index);
	int GetB(int index);
	friend class CRasterReader;
private:
    CArray<RGBColor,RGBColor>els;
};
class CReaderEnvi
{
public:
	CReaderEnvi(); 
	virtual~CReaderEnvi();
	static void InitialEnvi();   //��̬����������ʹ��դ���֮ǰ��ִ�и÷���
};
class CRasterReader
{
public:
    CRasterReader();
	virtual~CRasterReader();
	static int GetBandCountFromPath(CString PathName);
	bool OpenRaster(CString PathName);  
	bool HasOpened(){return poDataset!=NULL;}
	//��һ��դ�����ݣ�֧�ֵĸ�ʽ����
	//Arc/Info ASCII Grid ��Arc/Info Binary Grid (.adf) ��TIFF / BigTIFF / GeoTIFF (.tif) ��ENVI .hdr Labelled Raster ��Erdas Imagine (.img) 
	//GXF - Grid eXchange File ��JPEG JFIF (.jpg) ��Microsoft Windows Device Independent Bitmap (.bmp) 
	//�ȵ�
	//��grid·��ֻ�赽grid�ļ��У���bmp��tiff���ļ���Ҫ����չ��
    int GetCols();//�õ�����
	int GetRows();//�õ�����
	long GetPixelCol(double x);
    long GetPixelRow(double y);
	long GetPixelRealCol(double x);
    long GetPixelRealRow(double y);
	float GetPixelCenterX(long rx);
    float GetPixelCenterY(long ry);
	float GetMapX(float rx);
    float GetMapY(float ry);
	double GetCellSize();
	double GetLeft();//�õ�ͼ�����x����
	double GetBottom();//�õ�ͼ���±�y����
	int GetBandCount();//�õ�������
	CRect GetLoadedRect()
	{
		return LoadedRect;
	};
    OGRSpatialReference*GetSpatialRef();//�õ�ͼ��Ŀռ�����ϵͳ
	bool GetExtent(double&XMin,double&YMin,double&XMax,double&YMax);
	//�õ�ͼ��Ŀռ䷶Χ
    CColorTable*GetColorTable(int band=1);//�õ���ɫ��,���ԭͼû�е�ɫ�壬���ؿգ�ʹ�ú�Ҫɾ��
	//ע�⣺���δ�1��ʼ����
	CString GetErrorInfo();//�õ�������Ϣ
protected:
	virtual void NotifyRasterOpening()=0;
	bool GetBandData(int band,int&formerbufx,int&formerbufy,float**data);
	bool GetBandData(int band,int fromx,int fromy,int width,int height,int bufx,int bufy,int&formerbufx,int&formerbufy,float**data);
    GDALDataset  *poDataset;
    CString lpszPathName;
	double adfGeoTransform[6];
    int nXSize,nYSize;
	int BandCount;
	OGRSpatialReference pSpatial;
	CString ErrorInfo;
	CColorTable*pColorTable;
	CRect LoadedRect;//���صķ�Χ
};
class CGrayRasterReader :public CRasterReader
{
public:
     CGrayRasterReader();
	 virtual~CGrayRasterReader();
	 bool LoadBandData(int band);//װ�ز������ݵ��ڴ棬װ�غ�Ĳ���Ϊ��ǰ����
     bool LoadBandData(int band,int fromx,int fromy,int width,int height,int bufx,int bufy);//װ�ز������ݵ��ڴ棬װ�غ�Ĳ���Ϊ��ǰ����
	 float*GetGrayBandData();//�õ���ǰ�����ڴ����飬��ʹ�ú�Ҫɾ��
	 int GetBuffXSize()
	{
		return BuffXSize;
	};
    int GetBuffYSize()
	{
		return BuffYSize;
	};
protected:
	 void NotifyRasterOpening();
	 float*data;
	 int CurrentBand;
	 int BuffXSize;
	 int BuffYSize;
};
class CRGBRasterReader :public CRasterReader
{
public:
     CRGBRasterReader();
	 virtual~CRGBRasterReader();
	 bool LoadBandData(int*band);//װ�ز������ݵ��ڴ棬װ�غ�Ĳ���Ϊ��ǰ����
     bool LoadBandData(int*band,int fromx,int fromy,int width,int height,int bufx,int bufy);//װ�ز������ݵ��ڴ棬װ�غ�Ĳ���Ϊ��ǰ����
	 float*GetRBandData();//�õ���ǰ�����ڴ����飬��ʹ�ú�Ҫɾ��
     float*GetGBandData();//�õ���ǰ�����ڴ����飬��ʹ�ú�Ҫɾ��
	 float*GetBBandData();//�õ���ǰ�����ڴ����飬��ʹ�ú�Ҫɾ��
	 int GetBuffXSize(int index)
	{
		return BuffXSize[index];
	};
    int GetBuffYSize(int index)
	{
		return BuffYSize[index];
	};
protected:
	 void NotifyRasterOpening();
	 int CurrentBand[3];
	 float*rdata;
     float*gdata;
	 float*bdata;
	 int BuffXSize[3];
	 int BuffYSize[3];
};

class CVectorReader
{
public:
    CVectorReader();
	virtual~CVectorReader();
	bool OpenVector(CString PathName);  
	bool HasOpened(){return poLayer!=NULL;}
	bool SetSpatialFilterRect(double dfMinX, double dfMinY, double dfMaxX, double dfMaxY);
    OGRSpatialReference*GetSpatialRef();//�õ�ͼ��Ŀռ�����ϵͳ
    bool GetExtent(double&XMin,double&YMin,double&XMax,double&YMax);
	GeometryType GetShapeType();
	//��ȡͼ�㷶Χ
    bool ResetReadering();
    //�ƶ�ָ�뵽��ǰ��¼����һ����¼
	bool MoveNext();
    //�����ƶ�ָ��,�����¼���ײ�����False
	bool Move(long index);
	CGeometryDef*GetCurrentFeatureShape();
	OGRGeometry*GetCurrentOrginFeatureShape();
	//�õ���ǰָ�����ڼ�¼�Ŀռ�����
    CString GetCurrentFieldValueAsString(int iField);
	//�õ���ǰָ�����ڼ�¼���ֶ�iField��ֵ��ת��Ϊ�ַ������
	bool GetFeatureCount(long&Count);
	//�õ���ǰ��¼����¼������û�����ÿռ�����������Թ�����ʱ�����ܼ�¼����¼����
	long GetFieldCount();
	//�õ��ֶθ���
    CString GetFieldName(long index);
	//�õ��ֶ�����
    OGRFieldType GetFieldType(long index);
    //�õ��ֶ�����
	int GetFieldWidth(long index);
	//�õ��ֶο��
	int GetFieldPrecision(long index);
	//�õ�С�����ֶξ��ȣ����������ֶη���0
	CString GetErrorInfo();//�õ�������Ϣ
private:
	OGRDataSource*poDS;
	OGRLayer*poLayer;
	OGRFeature*poFeature;
    CArray<CString,CString>FieldNames;
	CArray<OGRFieldType,OGRFieldType>FieldTypes;
	CArray<int,int>FieldWidths;
	CArray<int,int>FieldPrecisions;
    CString lpszPathName;
	OGRSpatialReference*pSpatial;
	CString ErrorInfo;
};
