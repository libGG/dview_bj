// GISTryDoc.h : CGISTryDoc ��Ľӿ�
//


#pragma once


class CGISTryDoc : public CDocument
{
protected: // �������л�����
	CGISTryDoc();
	DECLARE_DYNCREATE(CGISTryDoc)

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
	virtual ~CGISTryDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// ���ɵ���Ϣӳ�亯��
protected:
	DECLARE_MESSAGE_MAP()
};


