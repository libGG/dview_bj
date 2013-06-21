#pragma once
#include "ProgressBase.h"

/**
* @brief ����̨��������
*
* �ṩ����̨����Ľ�������ӿڣ�����ӳ��ǰ�㷨�Ľ���ֵ
*/
class CConsoleProcess : public CProcessBase
{
public:
	/**
	* @brief ���캯��
	*/
	CConsoleProcess() 
	{
		m_dPosition = 0.0;
		m_iStepCount = 100;
		m_iCurStep = 0;
	};

	/**
	* @brief ��������
	*/
	~CConsoleProcess() 
	{
		//remove(m_pszFile);
	};

	/**
	* @brief ���ý�����Ϣ
	* @param pszMsg			������Ϣ
	*/
	void SetMessage(const char* pszMsg)
	{
		m_strMessage = pszMsg;
		printf("%s\n", pszMsg);
	}

	/**
	* @brief ���ý���ֵ
	* @param dPosition		����ֵ
	* @return �����Ƿ�ȡ����״̬��trueΪ��ȡ����falseΪȡ��
	*/
	bool SetPosition(double dPosition)
	{
		m_dPosition = dPosition;
		TermProgress(m_dPosition);
		m_bIsContinue = true;
		return true;
	}

	/**
	* @brief ������ǰ��һ��
	* @return �����Ƿ�ȡ����״̬��trueΪ��ȡ����falseΪȡ��
	*/
	bool StepIt()
	{
		m_iCurStep ++;
		m_dPosition = m_iCurStep*1.0 / m_iStepCount;

		TermProgress(m_dPosition);
		m_bIsContinue = true;
		return true;
	}

private:
	void TermProgress(double dfComplete)
	{
		static int nLastTick = -1;
		int nThisTick = (int) (dfComplete * 40.0);

		nThisTick = MIN(40,MAX(0,nThisTick));

		// Have we started a new progress run?  
		if( nThisTick < nLastTick && nLastTick >= 39 )
			nLastTick = -1;

		if( nThisTick <= nLastTick )
			return ;

		while( nThisTick > nLastTick )
		{
			nLastTick++;
			if( nLastTick % 4 == 0 )
				fprintf( stdout, "%d", (nLastTick / 4) * 10 );
			else
				fprintf( stdout, "." );
		}

		if( nThisTick == 40 )
			fprintf( stdout, " - done.\n" );
		else
			fflush( stdout );
	}
};