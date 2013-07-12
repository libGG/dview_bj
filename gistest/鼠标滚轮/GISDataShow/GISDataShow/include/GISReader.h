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
	static void InitialEnvi();   //静态方法，请在使用栅格库之前先执行该方法
};
class CRasterReader
{
public:
    CRasterReader();
	virtual~CRasterReader();
	static int GetBandCountFromPath(CString PathName);
	bool OpenRaster(CString PathName);  
	bool HasOpened(){return poDataset!=NULL;}
	//打开一个栅格数据，支持的格式包括
	//Arc/Info ASCII Grid 、Arc/Info Binary Grid (.adf) 、TIFF / BigTIFF / GeoTIFF (.tif) 、ENVI .hdr Labelled Raster 、Erdas Imagine (.img) 
	//GXF - Grid eXchange File 、JPEG JFIF (.jpg) 、Microsoft Windows Device Independent Bitmap (.bmp) 
	//等等
	//打开grid路径只需到grid文件夹，打开bmp、tiff等文件需要带扩展名
    int GetCols();//得到列数
	int GetRows();//得到行数
	long GetPixelCol(double x);
    long GetPixelRow(double y);
	long GetPixelRealCol(double x);
    long GetPixelRealRow(double y);
	float GetPixelCenterX(long rx);
    float GetPixelCenterY(long ry);
	float GetMapX(float rx);
    float GetMapY(float ry);
	double GetCellSize();
	double GetLeft();//得到图像左边x坐标
	double GetBottom();//得到图像下边y坐标
	int GetBandCount();//得到波段数
	CRect GetLoadedRect()
	{
		return LoadedRect;
	};
    OGRSpatialReference*GetSpatialRef();//得到图层的空间坐标系统
	bool GetExtent(double&XMin,double&YMin,double&XMax,double&YMax);
	//得到图象的空间范围
    CColorTable*GetColorTable(int band=1);//得到调色板,如果原图没有调色板，返回空，使用后不要删除
	//注意：波段从1开始计数
	CString GetErrorInfo();//得到错误信息
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
	CRect LoadedRect;//加载的范围
};
class CGrayRasterReader :public CRasterReader
{
public:
     CGrayRasterReader();
	 virtual~CGrayRasterReader();
	 bool LoadBandData(int band);//装载波段数据到内存，装载后的波段为当前波段
     bool LoadBandData(int band,int fromx,int fromy,int width,int height,int bufx,int bufy);//装载波段数据到内存，装载后的波段为当前波段
	 float*GetGrayBandData();//得到当前波段内存数组，请使用后不要删除
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
	 bool LoadBandData(int*band);//装载波段数据到内存，装载后的波段为当前波段
     bool LoadBandData(int*band,int fromx,int fromy,int width,int height,int bufx,int bufy);//装载波段数据到内存，装载后的波段为当前波段
	 float*GetRBandData();//得到当前波段内存数组，请使用后不要删除
     float*GetGBandData();//得到当前波段内存数组，请使用后不要删除
	 float*GetBBandData();//得到当前波段内存数组，请使用后不要删除
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
    OGRSpatialReference*GetSpatialRef();//得到图层的空间坐标系统
    bool GetExtent(double&XMin,double&YMin,double&XMax,double&YMax);
	GeometryType GetShapeType();
	//获取图层范围
    bool ResetReadering();
    //移动指针到当前记录集第一条记录
	bool MoveNext();
    //向下移动指针,到达记录集底部返回False
	bool Move(long index);
	CGeometryDef*GetCurrentFeatureShape();
	OGRGeometry*GetCurrentOrginFeatureShape();
	//得到当前指针所在记录的空间数据
    CString GetCurrentFieldValueAsString(int iField);
	//得到当前指针所在记录的字段iField的值，转换为字符串输出
	bool GetFeatureCount(long&Count);
	//得到当前记录集记录个数，没有设置空间过滤器和属性过滤器时返回总记录集记录个数
	long GetFieldCount();
	//得到字段个数
    CString GetFieldName(long index);
	//得到字段名称
    OGRFieldType GetFieldType(long index);
    //得到字段类型
	int GetFieldWidth(long index);
	//得到字段宽度
	int GetFieldPrecision(long index);
	//得到小数型字段精度，其他类型字段返回0
	CString GetErrorInfo();//得到错误信息
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
