#pragma once
#include "ProgressBase.h"

/**
* @brief 控制台进度条类
*
* 提供控制台程序的进度条类接口，来反映当前算法的进度值
*/
class CConsoleProcess : public CProcessBase
{
public:
	/**
	* @brief 构造函数
	*/
	CConsoleProcess() 
	{
		m_dPosition = 0.0;
		m_iStepCount = 100;
		m_iCurStep = 0;
	};

	/**
	* @brief 析构函数
	*/
	~CConsoleProcess() 
	{
		//remove(m_pszFile);
	};

	/**
	* @brief 设置进度信息
	* @param pszMsg			进度信息
	*/
	void SetMessage(const char* pszMsg)
	{
		m_strMessage = pszMsg;
		printf("%s\n", pszMsg);
	}

	/**
	* @brief 设置进度值
	* @param dPosition		进度值
	* @return 返回是否取消的状态，true为不取消，false为取消
	*/
	bool SetPosition(double dPosition)
	{
		m_dPosition = dPosition;
		TermProgress(m_dPosition);
		m_bIsContinue = true;
		return true;
	}

	/**
	* @brief 进度条前进一步
	* @return 返回是否取消的状态，true为不取消，false为取消
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