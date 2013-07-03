#include "StdAfx.h"
#include "GeometryDef.h"
CGeometryDef::CGeometryDef()
{
	type=gUnknown;
}
CGeometryDef::~CGeometryDef()
{
	
}
GeometryType CGeometryDef::GetType()
{
    return type;
}
bool CGeometryDef::GetEnvelope(double&XMin,double&YMin,double&XMax,double&YMax)
{
    CGeometryFactory fac;
	OGREnvelope pEnv;
	switch(GetType())
	{
	case gPoint:
		{
			OGRPoint pdef;
			fac.ConvertGeometry(this,pdef);
			pdef.getEnvelope(&pEnv);
			XMin=pEnv.MinX;
			YMin=pEnv.MinY;
			XMax=pEnv.MaxX;
			YMax=pEnv.MaxY;
			return true;
		}
    case gPoints:
		{
			OGRMultiPoint pdef;
			fac.ConvertGeometry(this,pdef);
			pdef.getEnvelope(&pEnv);
			XMin=pEnv.MinX;
			YMin=pEnv.MinY;
			XMax=pEnv.MaxX;
			YMax=pEnv.MaxY;
			return true;
		}
    case gPolyline:
		{
			CPolylineDef*pPoly=(CPolylineDef*)this;
			if(pPoly->GetCount()==1)
			{
			   OGRLineString pdef;
			   fac.ConvertGeometry(this,pdef);
			   pdef.getEnvelope(&pEnv);
			   XMin=pEnv.MinX;
			   YMin=pEnv.MinY;
			   XMax=pEnv.MaxX;
			   YMax=pEnv.MaxY;
			   return true;
			}
			else
			{
               OGRMultiLineString pdef;
			   fac.ConvertGeometry(this,pdef);
		 	   pdef.getEnvelope(&pEnv);
			   XMin=pEnv.MinX;
			   YMin=pEnv.MinY;
			   XMax=pEnv.MaxX;
			   YMax=pEnv.MaxY;
			   return true;
			}
			break;
		}
	case gPolygon:
		{
            OGRPolygon pdef;
			fac.ConvertGeometry(this,pdef);
			pdef.getEnvelope(&pEnv);
			XMin=pEnv.MinX;
			YMin=pEnv.MinY;
			XMax=pEnv.MaxX;
			YMax=pEnv.MaxY;
			return true;
		}
    case gMultiPolygon:
		{
            OGRMultiPolygon pdef;
			fac.ConvertGeometry(this,pdef);
			pdef.getEnvelope(&pEnv);
			XMin=pEnv.MinX;
			YMin=pEnv.MinY;
			XMax=pEnv.MaxX;
			YMax=pEnv.MaxY;
			return true;
		}
     case gCollection:
		{
            OGRGeometryCollection pdef;
			fac.ConvertGeometry(this,pdef);
			pdef.getEnvelope(&pEnv);
			XMin=pEnv.MinX;
			YMin=pEnv.MinY;
			XMax=pEnv.MaxX;
			YMax=pEnv.MaxY;
			return true;
		}
	}
	return false;
}
CPointDef::CPointDef()
{
	type=gPoint;
	X=Y=Z=0;
}
CPointDef::CPointDef(double x,double y,double z)
{
    type=gPoint;
	X=x;Y=y;Z=z;
}
CPointDef::~CPointDef()
{
}
double CPointDef::GetX()
{
	return X;
}
double CPointDef::GetY()
{
	return Y;
}
double CPointDef::GetZ()
{
	return Z;
}
void CPointDef::SetX(double x)
{
	X=x;
}
void CPointDef::SetY(double y)
{
	Y=y;
}
void CPointDef::SetZ(double z)
{
	Z=z;
}
CPointsDef::CPointsDef()
{
	type=gPoints;
}
CPointsDef::~CPointsDef()
{
    for(long k=pts.GetSize()-1;k>=0;k--) delete pts.GetAt(k);
	pts.RemoveAll();
}
long CPointsDef::GetCount()
{
	return pts.GetSize();
}
CPointDef*CPointsDef::Item(long index)
{
	return pts.GetAt(index);
}
void CPointsDef::AddPoint(double X,double Y,double Z)
{
    CPointDef*newpt=new CPointDef(X,Y,Z);
	pts.Add(newpt);
}
void CPointsDef::RemoveAt(long index)
{
    delete pts.GetAt(index);
	pts.RemoveAt(index);
}
void CPointsDef::RemoveAll()
{
    for(long k=pts.GetSize()-1;k>=0;k--) delete pts.GetAt(k);
	pts.RemoveAll();
}
CPolylineDef::CPolylineDef()
{
   type=gPolyline;
}
CPolylineDef::~CPolylineDef()
{
     for(long k=parts.GetSize()-1;k>=0;k--) delete parts.GetAt(k);
	 parts.RemoveAll();
}
long CPolylineDef::GetCount()
{
	return parts.GetSize();
}
CPointsDef*CPolylineDef::Item(long index)
{
	return parts.GetAt(index);
}
void CPolylineDef::AddNewPart()
{
    CPointsDef*newpts=new CPointsDef();
	parts.Add(newpts);
}
void CPolylineDef::RemoveAt(long index)
{
	delete parts.GetAt(index);
	parts.RemoveAt(index);
}
void CPolylineDef::RemoveAll()
{
    for(long k=parts.GetSize()-1;k>=0;k--) delete parts.GetAt(k);
	 parts.RemoveAll();
}
CPolygonDef::CPolygonDef()
{
   type=gPolygon;
}
CPolygonDef::~CPolygonDef()
{
     for(long k=parts.GetSize()-1;k>=0;k--) delete parts.GetAt(k);
	 parts.RemoveAll();
}
long CPolygonDef::GetCount()
{
	return parts.GetSize();
}
CPointsDef*CPolygonDef::Item(long index)
{
	return parts.GetAt(index);
}
void CPolygonDef::AddNewPart()
{
    CPointsDef*newpts=new CPointsDef();
	parts.Add(newpts);
}
void CPolygonDef::RemoveAt(long index)
{
	delete parts.GetAt(index);
	parts.RemoveAt(index);
}
void CPolygonDef::RemoveAll()
{
    for(long k=parts.GetSize()-1;k>=0;k--) delete parts.GetAt(k);
	 parts.RemoveAll();
}
CMultiPolygonDef::CMultiPolygonDef()
{
   type=gMultiPolygon;
}
CMultiPolygonDef::~CMultiPolygonDef()
{
     for(long k=parts.GetSize()-1;k>=0;k--) delete parts.GetAt(k);
	 parts.RemoveAll();
}
long CMultiPolygonDef::GetCount()
{
	return parts.GetSize();
}
CPolygonDef*CMultiPolygonDef::Item(long index)
{
	return parts.GetAt(index);
}
void CMultiPolygonDef::AddNewPart()
{
    CPolygonDef*newpts=new CPolygonDef();
	parts.Add(newpts);
}
void CMultiPolygonDef::RemoveAt(long index)
{
	delete parts.GetAt(index);
	parts.RemoveAt(index);
}
void CMultiPolygonDef::RemoveAll()
{
    for(long k=parts.GetSize()-1;k>=0;k--) delete parts.GetAt(k);
	parts.RemoveAll();
}
CGeometryCollectionDef::CGeometryCollectionDef()
{
    type=gCollection;
}
CGeometryCollectionDef::~CGeometryCollectionDef()
{
     for(long k=parts.GetSize()-1;k>=0;k--) delete parts.GetAt(k);
	 parts.RemoveAll();
}
long CGeometryCollectionDef::GetCount()
{
     return parts.GetSize();
}
CGeometryDef*CGeometryCollectionDef::Item(long index)
{
     return parts.GetAt(index);
}
void CGeometryCollectionDef::AddNewPart(CGeometryDef*pGeo)
{
     parts.Add(pGeo);
}
void CGeometryCollectionDef::RemoveAt(long index)
{
    delete parts.GetAt(index);
	parts.RemoveAt(index);
}
void CGeometryCollectionDef::RemoveAll()
{
     for(long k=parts.GetSize()-1;k>=0;k--) delete parts.GetAt(k);
	 parts.RemoveAll();
}
CGeometryFactory::CGeometryFactory()
{
   
}
CGeometryFactory::~CGeometryFactory()
{

}
CPointDef*CGeometryFactory::CreatePoint(OGRPoint*def)
{
    CPointDef*pDef=new CPointDef(def->getX(),def->getY(),def->getZ());
	return pDef;
}
CPointsDef*CGeometryFactory::CreatePoints(OGRMultiPoint*def)
{
    long Count=def->getNumGeometries();
	CPointsDef*pDef=new CPointsDef();
	for(long k=0;k<Count;k++)
	{
         OGRPoint*pt=(OGRPoint*)def->getGeometryRef(k);
		 CPointDef*ptdef=CreatePoint(pt);
		 pDef->pts.Add(ptdef);
	}
	return pDef;
}
CPolylineDef*CGeometryFactory::CreatePolyline(OGRLineString*def)
{
    long Count=def->getNumPoints(); 
	CPolylineDef*pDef=new CPolylineDef();
	pDef->AddNewPart();
	for(long k=0;k<Count;k++)
	{
		 CPointDef*ptdef=new CPointDef(def->getX(k),def->getY(k),def->getZ(k));
		 pDef->parts.GetAt(0)->pts.Add(ptdef);
	}
	return pDef;
}
CPolylineDef*CGeometryFactory::CreatePolyline(OGRMultiLineString*def)
{
    long Count=def->getNumGeometries();
	CPolylineDef*pDef=new CPolylineDef();
	for(long k=0;k<Count;k++)
	{
         OGRLineString*pts=(OGRLineString*)def->getGeometryRef(k);
		 CPolylineDef*sub=CreatePolyline(pts);
		 pDef->parts.Add(sub->parts.GetAt(0));
		 sub->parts.RemoveAll();
		 delete sub;
	}
	return pDef;
}
CPolygonDef*CGeometryFactory::CreatePolygon(OGRPolygon*def)
{
	OGRLinearRing*lr=def->getExteriorRing();
    OGRLineString*ls=(OGRLineString*)lr;
	CPolylineDef*pPoly=CreatePolyline(ls);
    CPolygonDef*pDef=new CPolygonDef();
    pDef->parts.Add(pPoly->parts.GetAt(0));
    pPoly->parts.RemoveAll();
    delete pPoly;
	int innerCount=def->getNumInteriorRings();
    for(int k=0;k<innerCount;k++)
	{
        lr=def->getInteriorRing(k);
        ls=(OGRLineString*)lr;
	    pPoly=CreatePolyline(ls);
        pDef->parts.Add(pPoly->parts.GetAt(0));
        pPoly->parts.RemoveAll();
        delete pPoly;
	}
	return pDef;
}
CMultiPolygonDef*CGeometryFactory::CreateMultiPolygon(OGRMultiPolygon*def)
{
    long Count=def->getNumGeometries();
	CMultiPolygonDef*pDef=new CMultiPolygonDef();
	for(long k=0;k<Count;k++)
	{
         OGRPolygon*po=(OGRPolygon*)def->getGeometryRef(k);
		 CPolygonDef*podef=CreatePolygon(po);
		 pDef->parts.Add(podef);
	}
	return pDef;
}
CGeometryCollectionDef*CGeometryFactory::CreateCollection(OGRGeometryCollection*def)
{
    long Count=def->getNumGeometries();
	CGeometryCollectionDef*pDef=new CGeometryCollectionDef();
	for(long k=0;k<Count;k++)
	{
		 pDef->parts.Add(CreateGeometry(def->getGeometryRef(k)));
	}
	return pDef;
}
CGeometryDef*CGeometryFactory::CreateGeometry(OGRGeometry*pGeo)
{
     OGRwkbGeometryType type=pGeo->getGeometryType();
	 switch(type)
	 {
	 case wkbPoint :
			 return CreatePoint((OGRPoint*)pGeo);
     case wkbLineString :
			 return CreatePolyline((OGRLineString*)pGeo);
     case wkbPolygon :
			 return CreatePolygon((OGRPolygon*)pGeo);
     case wkbMultiPoint :
			 return CreatePoints((OGRMultiPoint*)pGeo);
     case wkbMultiLineString :
			 return CreatePolyline((OGRMultiLineString*)pGeo);
     case wkbMultiPolygon :
			 return CreateMultiPolygon((OGRMultiPolygon*)pGeo);
	 case wkbGeometryCollection:
             return CreateCollection((OGRGeometryCollection*)pGeo);
	 }
	 return NULL;
}
void CGeometryFactory::ConvertPoint(CPointDef*pDef,OGRPoint&def)
{
	def.setX(pDef->X);
	def.setY(pDef->Y);
	def.setZ(pDef->Z);
}
void CGeometryFactory::ConvertPoints(CPointsDef*pDef,OGRMultiPoint&def)
{ 
	def.empty();
	long Count=pDef->GetCount();
	OGRPoint newpt;
	for(long k=0;k<Count;k++)
	{
		ConvertPoint(pDef->Item(k),newpt);
		def.addGeometry(&newpt);
	}
}
void CGeometryFactory::ConvertPolyline(CPointsDef*pts,OGRLineString&def)
{
	def.empty();
	long Count=pts->GetCount();
	CPointDef*pt;
	for(long k=0;k<Count;k++)
	{
        pt=pts->pts.GetAt(k);
		def.addPoint(pt->X,pt->Y,pt->Z);
	}
}
void CGeometryFactory::ConvertPolyline(CPolylineDef*pDef,OGRLineString&def)
{ 
    ConvertPolyline(pDef->parts.GetAt(0),def);
}
void CGeometryFactory::ConvertComplexPolyline(CPolylineDef*pDef,OGRMultiLineString&def)
{
	def.empty();
	long Count=pDef->GetCount();
	CPointsDef*pts;
	for(long k=0;k<Count;k++)
	{
        pts=pDef->parts.GetAt(k);
		OGRLineString newpts;
		ConvertPolyline(pts,newpts);
        def.addGeometry(&newpts);
	}
}
void CGeometryFactory::ConvertRing(CPointsDef*pts,OGRLinearRing&def)
{
	def.empty();
	long Count=pts->GetCount();
	CPointDef*pt;
	for(long k=0;k<Count;k++)
	{
        pt=pts->pts.GetAt(k);
		def.addPoint(pt->X,pt->Y,pt->Z);
	}
}
void CGeometryFactory::ConvertPolygon(CPolygonDef*pDef,OGRPolygon&def)
{
	def.empty();
	long Count=pDef->GetCount();
	CPointsDef*pts;
	for(long k=0;k<Count;k++)
	{
        pts=pDef->parts.GetAt(k);
		OGRLinearRing newpts;
        ConvertRing(pts,newpts);
        def.addRing(&newpts);
	}
}
void CGeometryFactory::ConvertMultiPolygon(CMultiPolygonDef*pDef,OGRMultiPolygon&def)
{
	def.empty();
	long Count=pDef->GetCount();
	for(long k=0;k<Count;k++)
	{
        OGRPolygon newpo;
		ConvertPolygon(pDef->parts.GetAt(k),newpo);
        def.addGeometry(&newpo);
	}
}
void CGeometryFactory::ConvertGeometryCollection(CGeometryCollectionDef*pDef,OGRGeometryCollection&def)
{
	def.empty();
	long Count=pDef->GetCount();
	for(long k=0;k<Count;k++)
	{
        CGeometryDef*sub=pDef->parts.GetAt(k);
		switch(sub->GetType())
		{
		case gPoint:
			{
				OGRPoint psub;
				ConvertPoint((CPointDef*)sub,psub);
				def.addGeometry(&psub);
				break;
			}
        case gPoints:
			{
				OGRMultiPoint psub;
				ConvertPoints((CPointsDef*)sub,psub);
				def.addGeometry(&psub);
				break;
			}
        case gPolyline:
			{
				CPolylineDef*pPoly=(CPolylineDef*)sub;
				if(pPoly->GetCount()==1)
				{
				   OGRLineString psub;
				   ConvertPolyline(pPoly,psub);
				   def.addGeometry(&psub);
				}
				else
				{
                   OGRMultiLineString psub;
				   ConvertComplexPolyline(pPoly,psub);
				   def.addGeometry(&psub);
				}
				break;
			}
		case gPolygon:
			{
                OGRPolygon psub;
				ConvertPolygon((CPolygonDef*)sub,psub);
				def.addGeometry(&psub);
				break;
			}
        case gMultiPolygon:
			{
                OGRMultiPolygon psub;
				ConvertMultiPolygon((CMultiPolygonDef*)sub,psub);
				def.addGeometry(&psub);
				break;
			}
         case gCollection:
			{
                OGRGeometryCollection psub;
				ConvertGeometryCollection((CGeometryCollectionDef*)sub,psub);
				def.addGeometry(&psub);
				break;
			}
		}
	}
}
bool CGeometryFactory::ConvertGeometry(CGeometryDef*pDef,OGRPoint&def)
{
    if(pDef->GetType()!=gPoint) return false;
	ConvertPoint((CPointDef*)pDef,def);
	return true;
}
bool CGeometryFactory::ConvertGeometry(CGeometryDef*pDef,OGRMultiPoint&def)
{
    if(pDef->GetType()!=gPoints) return false;
	ConvertPoints((CPointsDef*)pDef,def);
	return true;
}
bool CGeometryFactory::ConvertGeometry(CGeometryDef*pDef,OGRLineString&def)
{
    if(pDef->GetType()!=gPolyline) return false;
    CPolylineDef*ply=(CPolylineDef*)pDef;
	if(ply->GetCount()!=1) return false;
	ConvertPolyline((CPolylineDef*)pDef,def);
	return true;
}
bool CGeometryFactory::ConvertGeometry(CGeometryDef*pDef,OGRMultiLineString&def)
{
    if(pDef->GetType()!=gPolyline) return false;
    CPolylineDef*ply=(CPolylineDef*)pDef;
	if(ply->GetCount()<=1) return false;
	ConvertComplexPolyline((CPolylineDef*)pDef,def);
	return true;
}
bool CGeometryFactory::ConvertGeometry(CGeometryDef*pDef,OGRPolygon&def)
{
    if(pDef->GetType()!=gPolygon) return false;
	ConvertPolygon((CPolygonDef*)pDef,def);
	return true;
}
bool CGeometryFactory::ConvertGeometry(CGeometryDef*pDef,OGRMultiPolygon&def)
{
    if(pDef->GetType()!=gMultiPolygon) return false;
	ConvertMultiPolygon((CMultiPolygonDef*)pDef,def);
	return true;
}
bool CGeometryFactory::ConvertGeometry(CGeometryDef*pDef,OGRGeometryCollection&def)
{
    if(pDef->GetType()!=gCollection) return false;
	ConvertGeometryCollection((CGeometryCollectionDef*)pDef,def);
	return true;
}
CEmbedSpatialRef::CEmbedSpatialRef()
{
    LoadState=0;
}
CEmbedSpatialRef::~CEmbedSpatialRef()
{

}
bool CEmbedSpatialRef::LoadEmbedSpatial()
{
	if(LoadState==1)
		return true;
	else if(LoadState==2)
		return false;
	CFilePath pPath;
	CString Dir=pPath.GetCurrentDir();
	pPath.SetFilePath(Dir);
	Dir=pPath.GetDir();
	if(!gcs.ReadFromCSVFile(Dir+"\\proj\\gcs.csv",7)) 
	{
	    LoadState=2;
		return false;
	}
    if(!pcs.ReadFromCSVFile(Dir+"\\proj\\pcs.csv",4))
	{
	    LoadState=2;
		return false;
	}
    if(!datum.ReadFromCSVFile(Dir+"\\proj\\gdal_datum.csv",2))
	{
	    LoadState=2;
		return false;
	}
    if(!ellipsiod.ReadFromCSVFile(Dir+"\\proj\\ellipsoid.csv",6))
	{
	    LoadState=2;
		return false;
	}
	LoadState=1;
	return true;
}
CString CEmbedSpatialRef::GetGeogCSInfo(CString sID)
{
    if(LoadState==0) 
		LoadEmbedSpatial();
	else if(LoadState==2)
		return "";
	long index=gcs.GetAt(0)->FindValue(sID);
	if(index==-1) return "";
	CString sInfo;
	sInfo="坐标名称:"+gcs.GetAt(1)->GetAt(index)+"\r\n";
	sInfo=sInfo+"Datum:";
	CString dID=gcs.GetAt(2)->GetAt(index);
    long dindex=datum.GetAt(0)->FindValue(dID);
	if(dindex>=0) sInfo=sInfo+datum.GetAt(1)->GetAt(dindex);
	sInfo+="\r\n";
    sInfo+="椭球体:";
    CString eID=gcs.GetAt(6)->GetAt(index);
    long eindex=ellipsiod.GetAt(0)->FindValue(eID);
	if(eindex>=0) sInfo=sInfo+ellipsiod.GetAt(1)->GetAt(eindex);
    sInfo+="\r\n";
	sInfo+="semi_major_axis:";
    if(eindex>=0) sInfo=sInfo+ellipsiod.GetAt(2)->GetAt(eindex);
    sInfo+="\r\n";
	if(eindex>=0)
	{
	   CString minor=ellipsiod.GetAt(5)->GetAt(eindex);
	   if(!minor.IsEmpty())
	   {
		   sInfo=sInfo+"semi_minor_axis:"+minor+"\r\n";
	   }
	}
	sInfo+="inv_flattening:";
    if(eindex>=0) sInfo=sInfo+ellipsiod.GetAt(4)->GetAt(eindex);
    sInfo+="\r\n";
	return sInfo;
}
CString CEmbedSpatialRef::GetProjCSInfo(CString sID)
{
    if(LoadState==0) 
		LoadEmbedSpatial();
	else if(LoadState==2)
		return "";
	long index=pcs.GetAt(0)->FindValue(sID);
	if(index==-1) return "";
	CString sInfo;
	sInfo="坐标名称:"+pcs.GetAt(1)->GetAt(index)+"\r\n";
	CString gID=pcs.GetAt(3)->GetAt(index);
	index=gcs.GetAt(0)->FindValue(gID);
	if(index==-1) return sInfo;
	sInfo=sInfo+"Datum:";
	CString dID=gcs.GetAt(2)->GetAt(index);
    long dindex=datum.GetAt(0)->FindValue(dID);
	if(dindex>=0) sInfo=sInfo+datum.GetAt(1)->GetAt(dindex);
	sInfo+="\r\n";
    sInfo+="椭球体:";
    CString eID=gcs.GetAt(6)->GetAt(index);
    long eindex=ellipsiod.GetAt(0)->FindValue(eID);
	if(eindex>=0) sInfo=sInfo+ellipsiod.GetAt(1)->GetAt(eindex);
    sInfo+="\r\n";
	sInfo+="semi_major_axis:";
    if(eindex>=0) sInfo=sInfo+ellipsiod.GetAt(2)->GetAt(eindex);
    sInfo+="\r\n";
	if(eindex>=0)
	{
	   CString minor=ellipsiod.GetAt(5)->GetAt(eindex);
	   if(!minor.IsEmpty())
	   {
		   sInfo=sInfo+"semi_minor_axis:"+minor+"\r\n";
	   }
	}
	sInfo+="inv_flattening:";
    if(eindex>=0) sInfo=sInfo+ellipsiod.GetAt(4)->GetAt(eindex);
    sInfo+="\r\n";
	return sInfo;
}
CString CEmbedSpatialRef::GetProjInfo(CString sID)
{
    long index=pcs.GetAt(0)->FindValue(sID);
	if(index==-1) return GetGeogCSInfo(sID);
	return GetProjCSInfo(sID);
}
bool CEmbedSpatialRef::GetHasSuccessfulLoad()
{
	if(LoadState==0) LoadEmbedSpatial();
	return (LoadState==1);
}
CCSVDatabase*CEmbedSpatialRef::GetEmbedGeog()
{
	return &gcs;
}
CCSVDatabase*CEmbedSpatialRef::GetEmbedProj()
{
    return &pcs;
}
CSpatialRefTrans::CSpatialRefTrans()
{
    ems=new CEmbedSpatialRef();
}
CSpatialRefTrans::~CSpatialRefTrans()
{
    delete ems;
}
bool CSpatialRefTrans::SetGeoCS(OGRSpatialReference&osr,SpatialRef ref)
{
     if(osr.SetGeogCS(ref.DatumName,ref.DatumName,"",ref.SemiMajor,ref.InvFlattening,"",ref.PMOffset,ref.Units,ref.ConvertToRadians)!=0) return false;
	 return true;
}
bool CSpatialRefTrans::SetWellKnownWellKnownGeogCS(OGRSpatialReference&osr,WellKnownGeogCS wkg)
{
	switch(wkg)
	{
    case NAD27:
	   return (osr.SetWellKnownGeogCS("NAD27")==0);
	case NAD83:
       return (osr.SetWellKnownGeogCS("NAD83")==0);
	case WGS72:
       return (osr.SetWellKnownGeogCS("WGS72")==0);
	case WGS84:
        return (osr.SetWellKnownGeogCS("WGS84")==0);
	}
	return false;
}
bool CSpatialRefTrans::SetUTMProjCS(OGRSpatialReference&osr,int nZone,int bNorth)
{
    return (osr.SetUTM(nZone,bNorth)==0);
}
bool CSpatialRefTrans::SetTM(OGRSpatialReference&osr,double dfCenterLat,double dfCenterLong,double dfScale,double dfFalseEasting,double dfFalseNorthing)
{
    return (osr.SetTM(dfCenterLat,dfCenterLong,dfScale,dfFalseEasting,dfFalseNorthing)==0);
}
bool CSpatialRefTrans::SetMercator(OGRSpatialReference&osr,double dfCenterLat,double dfCenterLong,double dfScale,double dfFalseEasting,double dfFalseNorthing)
{
    return (osr.SetMercator(dfCenterLat,dfCenterLong,dfScale,dfFalseEasting,dfFalseNorthing)==0);
}
bool CSpatialRefTrans::SetSpatialRef(OGRSpatialReference&osr,CString ProjString)
{
    char*wkt=ProjString.GetBuffer(ProjString.GetLength());
	return (osr.importFromWkt(&wkt)==CE_None);
}
bool CSpatialRefTrans::TransformPointSelf(OGRCoordinateTransformation*poCT,CPointDef*source)
{
    double X=source->X;
	double Y=source->Y;
	if(!poCT->Transform(1,&X, &Y)) return false;
	source->X=X;
	source->Y=Y;
	return true;
}
bool CSpatialRefTrans::TransformPointsSelf(OGRCoordinateTransformation*poCT,CPointsDef*source)
{
	CPointDef*pt;
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pt=source->pts.GetAt(k);
		if(!TransformPointSelf(poCT,pt)) return false;
	}
	return true;
}
bool CSpatialRefTrans::TransformPolylineSelf(OGRCoordinateTransformation*poCT,CPolylineDef*source)
{  
    CPointsDef*pts;
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pts=source->parts.GetAt(k);
		if(!TransformPointsSelf(poCT,pts)) return false;
	}
	return true;
}
bool CSpatialRefTrans::TransformPolygonSelf(OGRCoordinateTransformation*poCT,CPolygonDef*source)
{
    CPointsDef*pts;
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pts=source->parts.GetAt(k);
		if(!TransformPointsSelf(poCT,pts)) return false;
	}
	return true;
}
bool CSpatialRefTrans::TransformMultiPolygonSelf(OGRCoordinateTransformation*poCT,CMultiPolygonDef*source)
{
    CPolygonDef*pts;
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pts=source->parts.GetAt(k);
		if(!TransformPolygonSelf(poCT,pts)) return false;
	}
	return true;
}
bool CSpatialRefTrans::TransformCollectionSelf(OGRCoordinateTransformation*poCT,CGeometryCollectionDef*source)
{
    CGeometryDef*pts;
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pts=source->parts.GetAt(k);
		if(!TransformGeometrySelf(poCT,pts)) return false;
	}
	return true;
}
bool CSpatialRefTrans::TransformGeometrySelf(OGRCoordinateTransformation*poCT,CGeometryDef*SourceGeo)
{
     switch(SourceGeo->GetType())
	{
	case gPoint:
         return TransformPointSelf(poCT,(CPointDef*)SourceGeo);
	case gPoints:
		 return TransformPointsSelf(poCT,(CPointsDef*)SourceGeo);
    case gPolyline:
		 return TransformPolylineSelf(poCT,(CPolylineDef*)SourceGeo);
    case gPolygon:
		 return TransformPolygonSelf(poCT,(CPolygonDef*)SourceGeo);
    case gMultiPolygon:
		 return TransformMultiPolygonSelf(poCT,(CMultiPolygonDef*)SourceGeo);
    case gCollection:
         return TransformCollectionSelf(poCT,(CGeometryCollectionDef*)SourceGeo);
	}
	return NULL;
}
bool CSpatialRefTrans::TransToGeogCSSelf(OGRSpatialReference&SourceCS,CGeometryDef*SourceGeo)
{
    OGRCoordinateTransformation *poCT;
    OGRSpatialReference*TargetCS=SourceCS.CloneGeogCS();
    poCT=OGRCreateCoordinateTransformation(&SourceCS,TargetCS);
	delete TargetCS;
	if(poCT==NULL) return false;
	bool Suc=TransformGeometrySelf(poCT,SourceGeo);
	delete poCT;
	return Suc;
}
OGRCoordinateTransformation*CSpatialRefTrans::GetTransForm(OGRSpatialReference&SourceCS,OGRSpatialReference&TargetCS)
{ 
    OGRCoordinateTransformation *poCT;
    poCT=OGRCreateCoordinateTransformation(&SourceCS,&TargetCS);
	return poCT;
}
bool CSpatialRefTrans::TransformSelf(OGRCoordinateTransformation*poCT,CGeometryDef*SourceGeo)
{
    if(poCT==NULL) return false;
	bool Suc=TransformGeometrySelf(poCT,SourceGeo);
	return Suc;
}
bool CSpatialRefTrans::TransformSelf(OGRSpatialReference&SourceCS,OGRSpatialReference&TargetCS,CGeometryDef*SourceGeo)
{ 
    OGRCoordinateTransformation *poCT;
    poCT=OGRCreateCoordinateTransformation(&SourceCS,&TargetCS);
	if(poCT==NULL) return false;
	bool Suc=TransformGeometrySelf(poCT,SourceGeo);
	delete poCT;
	return Suc;
}
CPointDef*CSpatialRefTrans::TransformPoint(OGRCoordinateTransformation*poCT,CPointDef*source)
{
    double X=source->X;
	double Y=source->Y;
	if(!poCT->Transform(1,&X, &Y)) return NULL;
	CPointDef*target=new CPointDef(X,Y,source->Z);
	return target;
}
CPointsDef*CSpatialRefTrans::TransformPoints(OGRCoordinateTransformation*poCT,CPointsDef*source)
{
	CPointDef*pt,*targ;
	CPointsDef*newdef=new CPointsDef();
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pt=source->pts.GetAt(k);
		targ=TransformPoint(poCT,pt);
		if(targ==NULL) 
		{
			delete newdef;
			return NULL;
		}
		newdef->pts.Add(targ);
	}
	return newdef;
}
CPolylineDef*CSpatialRefTrans::TransformPolyline(OGRCoordinateTransformation*poCT,CPolylineDef*source)
{  
    CPointsDef*pts,*targ;
	CPolylineDef*newdef=new CPolylineDef();
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pts=source->parts.GetAt(k);
		targ=TransformPoints(poCT,pts);
		if(targ==NULL) 
		{
			delete newdef;
			return NULL;
		}
		newdef->parts.Add(targ);
	}
	return newdef;
}
CPolygonDef*CSpatialRefTrans::TransformPolygon(OGRCoordinateTransformation*poCT,CPolygonDef*source)
{
    CPointsDef*pts,*targ;
	CPolygonDef*newdef=new CPolygonDef();
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pts=source->parts.GetAt(k);
		targ=TransformPoints(poCT,pts);
		if(targ==NULL) 
		{
			delete newdef;
			return NULL;
		}
		newdef->parts.Add(targ);
	}
	return newdef;
}
CMultiPolygonDef*CSpatialRefTrans::TransformMultiPolygon(OGRCoordinateTransformation*poCT,CMultiPolygonDef*source)
{
    CPolygonDef*pts,*targ;
	CMultiPolygonDef*newdef=new CMultiPolygonDef();
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pts=source->parts.GetAt(k);
		targ=TransformPolygon(poCT,pts);
		if(targ==NULL) 
		{
			delete newdef;
			return NULL;
		}
		newdef->parts.Add(targ);
	}
	return newdef;
}
CGeometryCollectionDef*CSpatialRefTrans::TransformCollection(OGRCoordinateTransformation*poCT,CGeometryCollectionDef*source)
{
    CGeometryDef*pts,*targ;
	CGeometryCollectionDef*newdef=new CGeometryCollectionDef();
	long Size=source->GetCount();
	for(long k=0;k<Size;k++)
	{
		pts=source->parts.GetAt(k);
		targ=TransformGeometry(poCT,pts);
		if(targ==NULL) 
		{
			delete newdef;
			return NULL;
		}
		newdef->parts.Add(targ);
	}
	return newdef;
}
CGeometryDef*CSpatialRefTrans::TransformGeometry(OGRCoordinateTransformation*poCT,CGeometryDef*SourceGeo)
{
     switch(SourceGeo->GetType())
	{
	case gPoint:
         return TransformPoint(poCT,(CPointDef*)SourceGeo);
	case gPoints:
		 return TransformPoints(poCT,(CPointsDef*)SourceGeo);
    case gPolyline:
		 return TransformPolyline(poCT,(CPolylineDef*)SourceGeo);
    case gPolygon:
		 return TransformPolygon(poCT,(CPolygonDef*)SourceGeo);
    case gMultiPolygon:
		 return TransformMultiPolygon(poCT,(CMultiPolygonDef*)SourceGeo);
    case gCollection:
         return TransformCollection(poCT,(CGeometryCollectionDef*)SourceGeo);
	}
	return NULL;
}
CGeometryDef*CSpatialRefTrans::TransformToGeogCS(OGRSpatialReference&SourceCS,CGeometryDef*SourceGeo)
{
    OGRCoordinateTransformation *poCT;
	OGRSpatialReference*TargetCS=SourceCS.CloneGeogCS();
    poCT=OGRCreateCoordinateTransformation(&SourceCS,TargetCS);
	delete TargetCS;
	if(poCT==NULL) return false;
	CGeometryDef*newdef=TransformGeometry(poCT,SourceGeo);
	delete poCT;
	return newdef;
}
CGeometryDef*CSpatialRefTrans::Transform(OGRSpatialReference&SourceCS,OGRSpatialReference&TargetCS,CGeometryDef*SourceGeo)
{ 
    OGRCoordinateTransformation *poCT;
    poCT=OGRCreateCoordinateTransformation(&SourceCS,&TargetCS);
	if(poCT==NULL) return false;
	CGeometryDef*newdef=TransformGeometry(poCT,SourceGeo);
	delete poCT;
	return newdef;
}
DRect CSpatialRefTrans::TransformRect(OGRSpatialReference*SourceCS,OGRSpatialReference*TargetCS,DRect rt)
{
    if((SourceCS==NULL)||(TargetCS==NULL)) return rt;
    OGRCoordinateTransformation *poCT;
    poCT=OGRCreateCoordinateTransformation(SourceCS,TargetCS);
	if(poCT==NULL) return rt;
	DBPoint dpt;
	dpt.X=rt.Left;
	dpt.Y=rt.Top;
	poCT->Transform(1,&dpt.X,&dpt.Y);
	DBPoint des=dpt;
	DRect rect(des.X,des.Y,des.X,des.Y);
    dpt.X=rt.Right;
	dpt.Y=rt.Top;
	poCT->Transform(1,&dpt.X,&dpt.Y);
	des=dpt;
	rect+=DRect(des.X,des.Y,des.X,des.Y);
    dpt.X=rt.Right;
	dpt.Y=rt.Bottom;
	poCT->Transform(1,&dpt.X,&dpt.Y);
	des=dpt;
	rect+=DRect(des.X,des.Y,des.X,des.Y);
	dpt.X=rt.Left;
	dpt.Y=rt.Bottom;
	poCT->Transform(1,&dpt.X,&dpt.Y);
	des=dpt;
	rect+=DRect(des.X,des.Y,des.X,des.Y);
	double DifX=rt.Width()/5;
	double DifY=rt.Height()/5;
	double x,y;
	y=rt.Top;
	for(double x=rt.Left+DifX;x<rt.Right;x+=DifX)
	{  
        des.X=x;des.Y=y;
		poCT->Transform(1,&des.X,&des.Y);
	    rect+=DRect(des.X,des.Y,des.X,des.Y);
	}
	y=rt.Bottom;
    for(x=rt.Left+DifX;x<rt.Right;x+=DifX)
	{  
        des.X=x;des.Y=y;
		poCT->Transform(1,&des.X,&des.Y);
	    rect+=DRect(des.X,des.Y,des.X,des.Y);
	}
	if(rt.Top<rt.Bottom)
	{
       x=rt.Left;
	   for(y=rt.Top+DifY;y<rt.Bottom;y+=DifY)
	   {  
          des.X=x;des.Y=y;
		  poCT->Transform(1,&des.X,&des.Y);
	      rect+=DRect(des.X,des.Y,des.X,des.Y);
	   }
       x=rt.Right;
	   for(y=rt.Top+DifY;y<rt.Bottom;y+=DifY)
	   {  
          des.X=x;des.Y=y;
		  poCT->Transform(1,&des.X,&des.Y);
	      rect+=DRect(des.X,des.Y,des.X,des.Y);
	   }
	}
	else
	{
       x=rt.Left;
	   for(y=rt.Top+DifY;y>rt.Bottom;y+=DifY)
	   {  
          des.X=x;des.Y=y;
		  poCT->Transform(1,&des.X,&des.Y);
	      rect+=DRect(des.X,des.Y,des.X,des.Y);
	   }
       x=rt.Right;
	   for(y=rt.Top+DifY;y>rt.Bottom;y+=DifY)
	   {  
          des.X=x;des.Y=y;
		  poCT->Transform(1,&des.X,&des.Y);
	      rect+=DRect(des.X,des.Y,des.X,des.Y);
	   }
	}
	return rect;
}