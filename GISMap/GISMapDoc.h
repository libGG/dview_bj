// GISMapDoc.h : interface of the CGISMapDoc class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_GISMAPDOC_H__096E1567_827A_41C5_A68F_BA3261AE2481__INCLUDED_)
#define AFX_GISMAPDOC_H__096E1567_827A_41C5_A68F_BA3261AE2481__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class DataSource ;
class FeatureClass;
class Feature;
class CGISMapDoc : public CDocument
{
protected: // create from serialization only
	CGISMapDoc();
	DECLARE_DYNCREATE(CGISMapDoc)


private:
	CString layerName ;
	DataSource *m_pDataSource ;

	FeatureClass* ImportShapeFileData( FILE* fpShp, FILE* fpDbf );
	void LoadAttributeData(Feature *pFeature, FILE* fpDbf, int everyRecordLen);
	int ReverseBytes(int n) ;
// Attributes
public:

// Operations
public:
	DataSource& GetDataSource();

	FeatureClass* OnShapeFileOpen();
// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CGISMapDoc)
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CGISMapDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CGISMapDoc)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_GISMAPDOC_H__096E1567_827A_41C5_A68F_BA3261AE2481__INCLUDED_)
