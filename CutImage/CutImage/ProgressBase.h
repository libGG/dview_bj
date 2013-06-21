#pragma once

#include "gdal.h"
using namespace std;
/**
* @brief ����������
*
* �ṩ����������ӿڣ�����ӳ��ǰ�㷨�Ľ���ֵ
*/
class  CProcessBase //IMGALG_API
{
public:
	/**
	* @brief ���캯��
	*/
	CProcessBase() 
	{
		m_dPosition = 0.0;
		m_iStepCount = 100;
		m_iCurStep = 0;
		m_bIsContinue = true;
	}

	/**
	* @brief ��������
	*/
	virtual ~CProcessBase() {}

	/**
	* @brief ���ý�����Ϣ
	* @param pszMsg			������Ϣ
	*/
	virtual void SetMessage(const char* pszMsg) = 0;

	/**
	* @brief ���ý���ֵ
	* @param dPosition		����ֵ
	* @return �����Ƿ�ȡ����״̬��trueΪ��ȡ����falseΪȡ��
	*/
	virtual bool SetPosition(double dPosition) = 0;

	/**
	* @brief ������ǰ��һ��������true��ʾ������false��ʾȡ��
	* @return �����Ƿ�ȡ����״̬��trueΪ��ȡ����falseΪȡ��
	*/
	virtual bool StepIt() = 0;

	/**
	* @brief ���ý��ȸ���
	* @param iStepCount		���ȸ���
	*/
	virtual void SetStepCount(int iStepCount)
	{
		ReSetProcess();	
		m_iStepCount = iStepCount;
	}

	/**
	* @brief ��ȡ������Ϣ
	* @return ���ص�ǰ������Ϣ
	*/
	string GetMessage()
	{
		return m_strMessage;
	}

	/**
	* @brief ��ȡ����ֵ
	* @return ���ص�ǰ����ֵ
	*/
	double GetPosition()
	{
		return m_dPosition;
	}

	/**
	* @brief ���ý�����
	*/
	void ReSetProcess()
	{
		m_dPosition = 0.0;
		m_iStepCount = 100;
		m_iCurStep = 0;
		m_bIsContinue = true;
	}

	/*! ������Ϣ */
	string m_strMessage;
	/*! ����ֵ */
	double m_dPosition;		
	/*! ���ȸ��� */
	int m_iStepCount;		
	/*! ���ȵ�ǰ���� */
	int m_iCurStep;			
	/*! �Ƿ�ȡ����ֵΪfalseʱ��ʾ����ȡ�� */
	bool m_bIsContinue;			
};		
