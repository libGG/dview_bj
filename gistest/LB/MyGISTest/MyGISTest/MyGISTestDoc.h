// MyGISTestDoc.h : CMyGISTestDoc ��Ľӿ�
//


#pragma once


class CMyGISTestDoc : public CDocument
{
protected: // �������л�����
	CMyGISTestDoc();
	DECLARE_DYNCREATE(CMyGISTestDoc)

// ����
public:

// ����
public:

// ��д
public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// ʵ��
public:
	virtual ~CMyGISTestDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// ���ɵ���Ϣӳ�亯��
protected:
	DECLARE_MESSAGE_MAP()
};


