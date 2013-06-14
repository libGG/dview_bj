// GISMapDoc.cpp : implementation of the CGISMapDoc class
//

#include "stdafx.h"
#include "GISMap.h"

#include "GISMapDoc.h"
#include "DataSource.h"
#include "FeatureClass.h"
#include "GeoPoint.h"
#include "GeoPolyline.h"
#include "GeoPolygon.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CGISMapDoc

IMPLEMENT_DYNCREATE(CGISMapDoc, CDocument)

BEGIN_MESSAGE_MAP(CGISMapDoc, CDocument)
	//{{AFX_MSG_MAP(CGISMapDoc)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CGISMapDoc construction/destruction

CGISMapDoc::CGISMapDoc()
{
	// TODO: add one-time construction code here
	m_pDataSource = new DataSource() ;
}

CGISMapDoc::~CGISMapDoc()
{
	if ( m_pDataSource != 0 )
	{
		delete m_pDataSource ;
		m_pDataSource = 0 ;
	}
}

BOOL CGISMapDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CGISMapDoc serialization

void CGISMapDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

/////////////////////////////////////////////////////////////////////////////
// CGISMapDoc diagnostics

#ifdef _DEBUG
void CGISMapDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CGISMapDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CGISMapDoc commands
DataSource& CGISMapDoc::GetDataSource()
{
	return *m_pDataSource ;
}

FeatureClass* CGISMapDoc::OnShapeFileOpen() 
{
	// TODO: Add your command handler code here
	
	static char BASED_CODE szFilter[] = "Data Files (*.shp)|*.shp|All Files (*.*)|*.*||" ;

	CFileDialog dlg( true , NULL , NULL , OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT , szFilter , NULL ) ;

	if( dlg.DoModal() == IDCANCEL )
	{
		AfxMessageBox( "你没有选择要打开的文件!" ) ;
		return 0;
	}

	CString pathName = dlg.GetPathName() ;
	CString dbfFileName = pathName ;
	CString fileExt = dlg.GetFileExt() ;
	dbfFileName.Replace( "shp" , "dbf" ) ;
    layerName = dlg.GetFileTitle() ;

	fileExt.MakeUpper();
	if( fileExt == "SHP")
	{
		FILE* fpShp = fopen( pathName , "rb" ) ;
		FILE* fpDbf = fopen( dbfFileName , "rb" ) ;

		if( !fpShp )
		{
			AfxMessageBox( "打开文件失败!" ) ;
			return 0;
		}
		if( !fpDbf )
		{
			AfxMessageBox( "打开属性文件失败!" ) ;
			return 0;
		}
		FeatureClass *pFeatureClass = ImportShapeFileData( fpShp, fpDbf ) ;
		if ( pFeatureClass != 0 )
			pFeatureClass->CalculateBound();
		//关闭文件
		fclose(fpShp) ;
		fpShp = 0 ;
		fclose(fpDbf);
		fpDbf = 0 ;

		return pFeatureClass ;
	}

	return 0 ;
}

FeatureClass* CGISMapDoc::ImportShapeFileData( FILE* fpShp, FILE* fpDbf )
{
    //读Shp文件头开始
    int fileCode = -1;
    int fileLength = -1;
    int version = -1;
    int shapeType = -1;
    fread(&fileCode , sizeof(int) , 1 , fpShp) ;
	fileCode = ReverseBytes(fileCode) ;

    if (fileCode != 9994)
	{
		CString strTemp ;
		strTemp.Format(" WARNING filecode %d ", fileCode );
		AfxMessageBox(strTemp);
	}

	for( int i = 0 ; i < 5 ; i ++ )
		fread(&fileCode , sizeof(int) , 1 , fpShp) ;

    fread(&fileLength , sizeof(int) , 1 , fpShp) ;
	fileLength = ReverseBytes(fileLength) ;

    fread(&version , sizeof(int) , 1 , fpShp) ;
    fread(&shapeType , sizeof(int) , 1 , fpShp) ;

    double tempOriginX , tempOriginY ;
	fread( &tempOriginX , sizeof(double) , 1 , fpShp ) ;
	fread( &tempOriginY , sizeof(double) , 1 , fpShp ) ;

    double xMaxLayer , yMaxLayer ;
	fread( &xMaxLayer , sizeof(double) , 1 , fpShp ) ;
	fread( &yMaxLayer , sizeof(double) , 1 , fpShp ) ;

	double* skip = new double[4] ;
	fread( skip , sizeof(double) , 4 , fpShp ) ;
	delete []skip ;
	skip = 0 ;
    //读Shp文件头结束

	int uniqueID = this->m_pDataSource->GetUniqueID() ;
	FeatureClass* pShpDataSet = 0 ;
    //根据目标类型创建相应的图层DataSet。
    switch( shapeType )
    {
      case 1 :
        pShpDataSet = (FeatureClass*)&(m_pDataSource->CreateDataSet(uniqueID , POINTDATASET , layerName)) ;
        break ;
      case 3 :
      case 23 :
        pShpDataSet = (FeatureClass*)&(m_pDataSource->CreateDataSet(uniqueID , LINEDATASET , layerName)) ;
        break ;
      case 5 :
        pShpDataSet = (FeatureClass*)&(m_pDataSource->CreateDataSet(uniqueID , POLYGONDATASET , layerName)) ;
        break ;
    }

	if ( pShpDataSet == 0 ) return 0;

	// 读DBF文件头---------begin------------
	struct DBFHeader
	{
	   char m_nValid;
	   char m_aDate[3];
	   char m_nNumRecords[4];
	   char m_nHeaderBytes[2];
	   char m_nRecordBytes[2];
	   char m_nReserved1[3];
	   char m_nReserved2[13];
	   char m_nReserved3[4];
	}dbfheader;

	struct DBFFIELDDescriptor
	{
	   char m_sName[10];//应该为char m_sName[11]
	   char m_nType;
	   char m_nAddress[4];
	   char m_nFieldLength;
	   char m_nFieldDecimal;
	   char m_nReserved1[2];
	   char m_nWorkArea;
	   char m_nReserved2[2];
	   char m_nSetFieldsFlag;
	   char m_nReserved3[8];
	};

	fread(&dbfheader,sizeof(DBFHeader),1,fpDbf);
	/*int recordsNum = *((int*)dbfheader.m_nNumRecords);
	int headLen = *((short*)dbfheader.m_nHeaderBytes);
	int everyRecordLen = *((short*)dbfheader.m_nRecordBytes);

	if ( recordsNum == 0 ||  headLen == 0 || everyRecordLen == 0 )
		return 0 ;

	int fieldCount = (headLen - 1 - sizeof(DBFHeader))/sizeof(DBFFIELDDescriptor);

	DBFFIELDDescriptor *pFields = new DBFFIELDDescriptor[fieldCount];
	for ( i = 0; i < fieldCount; i ++ )
		fread(&pFields[i],sizeof(DBFFIELDDescriptor),1,fpDbf);

	char endByte;
	fread(&endByte,sizeof(char),1,fpDbf);
	
	if ( endByte != 0x0D)
	{
		delete []pFields;
		pFields = 0;
		return 0;
	}*/



	Fields& fields = pShpDataSet->GetFields();
	DBFFIELDDescriptor field ;
	BYTE endByte = ' ';
	char fieldName[12];
	int fieldDecimal, fieldLen, everyRecordLen = 0 ;
	while ( !feof(fpDbf) )
	{
		fread(&endByte,sizeof(BYTE),1,fpDbf);
		if ( endByte == 0x0D)	break ;
		fread(&field,sizeof(DBFFIELDDescriptor),1,fpDbf);
		
		fieldName[0] = endByte;
		for (int i = 0; i < 10; i ++ )
			fieldName[i+1] = field.m_sName[i];
		fieldName[11] = '\0';

		fieldDecimal = field.m_nFieldDecimal;
		fieldLen = field.m_nFieldLength;
		switch( field.m_nType )
		{
			case 'C':
				fields.AddField(fieldName,fieldName,FIELD_STRING,fieldLen);
				break;
			case 'F':
				fields.AddField(fieldName,fieldName,FIELD_DOUBLE,fieldLen);
				break;
			case 'N':
				{
					if ( fieldDecimal == 0 ) 
						fields.AddField(fieldName,fieldName,FIELD_INT,fieldLen);
					else fields.AddField(fieldName,fieldName,FIELD_DOUBLE,fieldLen);
				}
				break;
		}
		everyRecordLen += fieldLen ;
	}
	// 读DBF文件头---------end------------

      while( !feof(fpShp) )
      {
        //读记录头开始
        int recordNumber = -1 ;
        int contentLength = -1 ;
		fread(&recordNumber , sizeof(int) , 1 , fpShp) ;
		fread(&contentLength , sizeof(int) , 1 , fpShp) ;
        recordNumber = ReverseBytes(recordNumber) ;
        contentLength = ReverseBytes(contentLength) ;
        //读记录头结束

        switch( shapeType )
        {
          case 1: // '\001'
          //读取点目标开始
          {
			Fields &featureFields = pShpDataSet->GetFields();
			Feature *pFeature = new Feature(recordNumber , 1 , &featureFields) ;

            int pointShapeType ;
			fread(&pointShapeType , sizeof(int) , 1 , fpShp) ;
			double xValue , yValue ;
			fread(&xValue , sizeof(double) , 1 , fpShp) ;
			fread(&yValue , sizeof(double) , 1 , fpShp) ;

            GeoPoint *pNewGeoPoint = new GeoPoint( xValue , yValue ) ;
			pFeature->SetBound(xValue , yValue , 0 , 0 ) ;
			pFeature->SetGeometry(pNewGeoPoint) ;
			this->LoadAttributeData(pFeature,fpDbf,everyRecordLen);
            pShpDataSet->AddRow(pFeature) ;
          }
          break ;
          //读取点目标结束

          case 3: // '\003'
          //读取线目标开始
          {
			Fields &featureFields = pShpDataSet->GetFields();
			Feature *pFeature = new Feature(recordNumber , 1 , &featureFields) ;

            int arcShapeType ;
			fread(&arcShapeType , sizeof(int) , 1 , fpShp) ;

            double objMinX , objMinY , objMaxX , objMaxY ;
			fread(&objMinX , sizeof(double) , 1 , fpShp) ;
			fread(&objMinY , sizeof(double) , 1 , fpShp) ;
			fread(&objMaxX , sizeof(double) , 1 , fpShp) ;
			fread(&objMaxY , sizeof(double) , 1 , fpShp) ;

            GeoPolyline *pNewGeoLine = new GeoPolyline();
            double width = objMaxX - objMinX ;
            double height = objMaxY - objMinY ;
			pFeature->SetBound(objMinX , objMinY , width , height) ;

            int numParts , numPoints ;
			fread(&numParts , sizeof(int) , 1 , fpShp) ;
			fread(&numPoints , sizeof(int) , 1 , fpShp) ;
            //存储各段线的起点索引
			int* startOfPart = new int[numParts] ;
            for( int i = 0 ; i < numParts ; i++ )
            {
              int indexFirstPoint ;
			  fread(&indexFirstPoint , sizeof(int) , 1 , fpShp) ;
              startOfPart[i] = indexFirstPoint ;
            }

            //处理单个目标有多条线的问题
            pNewGeoLine->SetPointsCount( numParts ) ;

            for(int i = 0 ; i < numParts ; i++ )
            {
              GeoPoints& points = pNewGeoLine->GetPoints(i) ;
              int curPosIndex = startOfPart[i] ;
              int nextPosIndex = 0 ;
              int curPointCount = 0 ;
              if( i == numParts - 1 )
                curPointCount = numPoints - curPosIndex ;
              else
              {
                nextPosIndex = startOfPart[i + 1] ;
                curPointCount = nextPosIndex - curPosIndex ;
              }
              points.SetPointCount( curPointCount ) ;
              //加载一条线段的坐标
              for( int iteratorPoint = 0 ; iteratorPoint < curPointCount ; iteratorPoint ++ )
              {
				  double x , y ;
				  fread(&x , sizeof(double) , 1 , fpShp) ;
				  fread(&y , sizeof(double) , 1 , fpShp) ;
                GeoPoint newVertex(x, y);
                points.SetPoint(iteratorPoint, newVertex);
              }
            }
			delete []startOfPart ;
			startOfPart = 0 ;
			pFeature->SetGeometry(pNewGeoLine) ;
			this->LoadAttributeData(pFeature,fpDbf,everyRecordLen);
            pShpDataSet->AddRow(pFeature) ;
          }
          break ;
          //读取线目标结束

          case 5: // '\005'
          //读取面目标开始
          {
			Fields &featureFields = pShpDataSet->GetFields();
			Feature *pFeature = new Feature(recordNumber , 1 , &featureFields) ;
            int polygonShapeType ;
			fread(&polygonShapeType  , sizeof(int) , 1 ,fpShp) ;
            if( polygonShapeType != 5 )
               AfxMessageBox( "Error: Attempt to load non polygon shape as polygon." ) ;

            double objMinX , objMinY , objMaxX , objMaxY ;
			fread(&objMinX , sizeof(double) , 1 , fpShp) ;
			fread(&objMinY , sizeof(double) , 1 , fpShp) ;
			fread(&objMaxX , sizeof(double) , 1 , fpShp) ;
			fread(&objMaxY , sizeof(double) , 1 , fpShp) ;

            GeoPolygon *pNewGeoPolygon = new GeoPolygon();
            double width = objMaxX - objMinX ;
            double height = objMaxY - objMinY ;
			pFeature->SetBound(objMinX , objMinY , width , height) ;

            int numParts , numPoints ;
			fread(&numParts , sizeof(int) , 1 , fpShp) ;
			fread(&numPoints , sizeof(int) , 1 , fpShp) ;
            //存储各个面的起点索引
			int* startOfPart = new int[numParts] ;
            for( int i = 0 ; i < numParts ; i++ )
            {
              int indexFirstPoint ;
			  fread(&indexFirstPoint , sizeof(int) , 1 , fpShp) ;
              startOfPart[i] = indexFirstPoint ;
            }

            //处理单个目标有多面问题
            pNewGeoPolygon->SetPointsCount( numParts ) ;

            for(int i = 0 ; i < numParts ; i++ )
            {
              GeoPoints& points = pNewGeoPolygon->GetPoints(i) ;
              int curPosIndex = startOfPart[i] ;
              int nextPosIndex = 0 ;
              int curPointCount = 0 ;
              if( i == numParts - 1 )
                curPointCount = numPoints - curPosIndex ;
              else
              {
                nextPosIndex = startOfPart[i + 1];
                curPointCount = nextPosIndex - curPosIndex ;
              }
              points.SetPointCount( curPointCount ) ;
              //加载一个面(多边形)的坐标
              for( int iteratorPoint = 0 ; iteratorPoint < curPointCount ; iteratorPoint ++ )
              {
                double x , y ;
				fread(&x , sizeof(double) , 1 , fpShp) ;
				fread(&y , sizeof(double) , 1 , fpShp) ;
                GeoPoint newVertex(x, y);
                points.SetPoint(iteratorPoint, newVertex);
              }
            }
			delete []startOfPart ;
			startOfPart = 0 ;
			pFeature->SetGeometry(pNewGeoPolygon) ;
			this->LoadAttributeData(pFeature,fpDbf,everyRecordLen);
            pShpDataSet->AddRow(pFeature) ;
          }
          break ;
          //读取面目标结束

          case 23: // '\027'
          //读取Measure形线目标开始
          {
			Fields &featureFields = pShpDataSet->GetFields();
			Feature *pFeature = new Feature(recordNumber , 1 , &featureFields) ;
            int arcMShapeType ;
			fread(&arcMShapeType , sizeof(int) , 1 , fpShp) ;

            double objMinX , objMinY , objMaxX , objMaxY ;
			fread(&objMinX , sizeof(double) , 1 , fpShp) ;
			fread(&objMinY , sizeof(double) , 1 , fpShp) ;
			fread(&objMaxX , sizeof(double) , 1 , fpShp) ;
			fread(&objMaxY , sizeof(double) , 1 , fpShp) ;

            GeoPolyline *pNewGeoLine = new GeoPolyline();
            double width = objMaxX - objMinX ;
            double height = objMaxY - objMinY ;
			pFeature->SetBound(objMinX , objMinY , width , height) ;

            int numParts , numPoints ;
			fread(&numParts , sizeof(int) , 1 , fpShp) ;
			fread(&numPoints , sizeof(int) , 1 , fpShp) ;
            //存储各段线的起点索引
			int* startOfPart = new int[numParts] ;
            for( int i = 0 ; i < numParts ; i++ )
            {
              int indexFirstPoint ;
			  fread(&indexFirstPoint , sizeof(int) , 1 , fpShp) ;
              startOfPart[i] = indexFirstPoint ;
            }

            //处理单个目标有多条线的问题
            pNewGeoLine->SetPointsCount( numParts ) ;

            for(int i = 0 ; i < numParts ; i++ )
            {
              GeoPoints& points = pNewGeoLine->GetPoints(i) ;
              int curPosIndex = startOfPart[i] ;
              int nextPosIndex = 0 ;
              int curPointCount = 0 ;
              if( i == numParts - 1 )
                curPointCount = numPoints - curPosIndex ;
              else
              {
                nextPosIndex = startOfPart[i + 1] ;
                curPointCount = nextPosIndex - curPosIndex ;
              }
              points.SetPointCount( curPointCount ) ;
              //加载一条线段的坐标
              for( int iteratorPoint = 0 ; iteratorPoint < curPointCount ; iteratorPoint ++ )
              {
				  double x , y ;
				  fread(&x , sizeof(double) , 1 , fpShp) ;
				  fread(&y , sizeof(double) , 1 , fpShp) ;
                GeoPoint newVertex(x, y);
                points.SetPoint(iteratorPoint, newVertex);
              }
            }
			delete []startOfPart ;
			startOfPart = 0 ;

			double* value = new double[2 + numPoints] ;
			fread( value , sizeof(double) , 2+numPoints, fpShp) ;
			delete []value ;
			value = 0 ;

			pFeature->SetGeometry(pNewGeoLine) ;
			this->LoadAttributeData(pFeature,fpDbf,everyRecordLen);
            pShpDataSet->AddRow(pFeature);
          }
          break ;
          //读取Measure形线目标结束
        }
      }
	  return pShpDataSet ;
}

void CGISMapDoc::LoadAttributeData(Feature *pFeature, FILE* fpDbf, int everyRecordLen)
{
	if ( everyRecordLen <= 0 ) return ;
	Fields &fields = pFeature->GetFields();
	int fieldCount = fields.Size();
	if ( fieldCount <= 0 ) return ;
	char *pValue = new char[everyRecordLen];
	fread( pValue, everyRecordLen*sizeof(char),1,fpDbf);
	int dPos = 1;
	for ( int j = 0; j < fieldCount; j ++ )
	{
		Field &field = fields.GetField(j);
		FieldValue &fieldvalue = pFeature->GetFieldValue(field.GetFieldName());
		int fieldType = field.GetFieldType();
		int fieldLen = field.GetFieldLength();
		char *fieldValue = new char[fieldLen+1];
		for ( int t = 0, k = dPos; k < dPos+fieldLen; k ++, t ++ )
			fieldValue[t] = pValue[k];
		fieldValue[fieldLen] = '\0';
		switch( fieldType )
		{
			case FIELD_STRING:
				fieldvalue.SetString( fieldValue );
				break;
			case FIELD_DOUBLE:
				fieldvalue.SetDouble(atof(fieldValue));
				break;
			case FIELD_INT:
				fieldvalue.SetInt( atoi(fieldValue) );
				break;
		}
		delete []fieldValue;
		dPos += fieldLen;
	}
	delete []pValue;
}

int CGISMapDoc::ReverseBytes(int n)
{
   union
   {
      BYTE a[4];
      int n;
   } u,v;

   u.n = n;
      
   v.a[0] = u.a[3];
   v.a[1] = u.a[2];
   v.a[2] = u.a[1];
   v.a[3] = u.a[0];   

   return v.n;
}

/*
void CGISMapDoc::LoadAttributeData(Feature *pFeature, FILE* fpDbf, int everyRecordLen)
{
	CString str ;

	char *pValue = new char[everyRecordLen];
	for ( i = 0; i < recordsNum; i ++ ) 
	{
		fread( pValue, everyRecordLen*sizeof(char),1,fpDbf);

		int dPos = 1;
		for ( int j = 0; j < fieldCount; j ++ )
		{
			CString strFieldName = pFields[j].m_sName;
			int fieldLen = pFields[j].m_nFieldLength;
			int fieldDecimal = pFields[j].m_nFieldDecimal;
			char *fieldValue = new char[fieldLen+1];
			for ( int t = 0, k = dPos; k < dPos+fieldLen; k ++, t ++ )
				fieldValue[t] = pValue[k];
			fieldValue[fieldLen] = '\0';
			switch( pFields[j].m_nType )
			{
				case 'C':
					{
						CString strValue( fieldValue );
						TRACE(",");
						TRACE( strValue );
						TRACE(",");
					}
					break;
				case 'F':
					{
						float floatValue = atof(fieldValue);
						str.Format(",%f,",floatValue);
						TRACE( str );
					}
					break;
				case 'N':
					{
						if ( fieldDecimal == 0 ) 
						{
							int intValue = atoi(fieldValue);
							str.Format(",%d,",intValue);
							TRACE( str );
						}
						else
						{
							double doubleValue = atof(fieldValue);
							str.Format(",%lf,",doubleValue);
							TRACE( str );
						}
					}
					break;
			}
			delete []fieldValue;
			dPos += fieldLen;
		}
		TRACE("\n");
	}
	delete []pValue;
}*/