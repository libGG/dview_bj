// GISDataShowDoc.h : CGISDataShowDoc ��Ľӿ�
//


#pragma once


class CGISDataShowDoc : public CDocument
{
protected: // �������л�����
	CGISDataShowDoc();
	DECLARE_DYNCREATE(CGISDataShowDoc)

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
	virtual ~CGISDataShowDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// ���ɵ���Ϣӳ�亯��
protected:
	DECLARE_MESSAGE_MAP()
};


