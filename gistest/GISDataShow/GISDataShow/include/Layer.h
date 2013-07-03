#pragma once
#include "baseclass.h"
#include "gisreader.h"
class CLayers;
enum LayerType
{
	UnknownLayer=-1,
	VectorLayer =0,
	GrayRasterLayer =1,
    RGBRasterLayer =2,
};
class CLayer
{
public:
	CLayer(CLayers*pRefLayers)
	{
		type=UnknownLayer;
		IsVisible=true;
		m_RefLayers=pRefLayers;
	};
	virtual~CLayer()
	{
	};
	CString GetLayerName()
	{
		return LayerName;
	};
	void SetLayerName(CString Name)
	{  
       Name.Trim();
	   LayerName=Name;
	};
	LayerType GetLayerType()
	{
		return type;
	};
	CString GetPathName()
	{
		return lpszPathName;
	};
	bool GetIsVisible()
	{
		return IsVisible;
	};
	bool IsRasterLayer()
	{
		return ((type!=VectorLayer)&&(type!=UnknownLayer));
	};
	bool IsVectorLayer()
	{
		return (type==VectorLayer);
	};
	CLayers*GetLayers()
	{
		return m_RefLayers;
	};
	virtual bool SetPathName(CString PathName)=0;
	virtual DRect GetFullExtent()=0;
	virtual OGRSpatialReference*GetSpatialReference()=0;
protected:
	LayerType type;
	CString lpszPathName;
	bool IsVisible;
	CString LayerName;
	CLayers*m_RefLayers;
};
class CRasterLayer :public CLayer
{
public:
	CRasterLayer(CLayers*pRefLayers) :CLayer(pRefLayers)
	{
		pReader=NULL;
	};
	virtual~CRasterLayer()
	{
        if(pReader!=NULL) delete pReader;
	};
    bool SetPathName(CString PathName);
	DRect GetFullExtent();
	CRasterReader*GetRasterReader()
	{
		return pReader;
	};
	OGRSpatialReference*GetSpatialReference()
	{
		if(pReader==NULL) return NULL;
		return pReader->GetSpatialRef();
	};
protected:
	virtual void CreateNewRasterReader()=0;
	CRasterReader*pReader;
};
class CGrayRasterLayer :public CRasterLayer
{
public:
	CGrayRasterLayer(CLayers*pRefLayers) :CRasterLayer(pRefLayers)
	{
		type=GrayRasterLayer;
		pBand=-1;
	};
	virtual~CGrayRasterLayer()
	{
	};
	CGrayRasterReader*GetRasterReader()
	{
		return (CGrayRasterReader*)pReader;
	};
	void SetBand(int band)
	{
        pBand=band;
	};
	int GetBand()
	{
		return pBand;
	};
protected:
    void CreateNewRasterReader()
	{
		pReader=new CGrayRasterReader();
	};
protected:
	int pBand;
};
class CRGBRasterLayer :public CRasterLayer
{
public:
	CRGBRasterLayer(CLayers*pRefLayers) :CRasterLayer(pRefLayers)
	{
		type=RGBRasterLayer;
		for(int k=0;k<3;k++)
		{
			pBand[k]=-1;
		}
	};
	virtual~CRGBRasterLayer()
	{
	};
	CRGBRasterReader*GetRasterReader()
	{
		return (CRGBRasterReader*)pReader;
	};
	void SetBand(int*band)
	{
        for(int k=0;k<3;k++) pBand[k]=band[k];
	};
	int*GetBand()
	{
		return pBand;
	};
protected:
    void CreateNewRasterReader()
	{
		pReader=new CRGBRasterReader();
	};
protected:
	int pBand[3];
};
class CVectorLayer :public CLayer
{
public:
	CVectorLayer(CLayers*pRefLayers) :CLayer(pRefLayers)
	{
        type=VectorLayer;
		pReader=NULL;
	};
	virtual~CVectorLayer()
	{
		if(pReader!=NULL) delete pReader;
	};
    GeometryType GetShapeType()
	{
		if(pReader==NULL) return gUnknown;
		return pReader->GetShapeType();
	};
	bool SetPathName(CString PathName);
	DRect GetFullExtent();
	CVectorReader*GetVectorReader()
	{
		return pReader;
	};
	OGRSpatialReference*GetSpatialReference()
	{
		if(pReader==NULL) return NULL;
		return pReader->GetSpatialRef();
	};
protected:
	CVectorReader*pReader;
};