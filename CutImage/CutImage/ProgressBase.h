#pragma once

#include "gdal.h"
using namespace std;
/**
* @brief 进度条基类
*
* 提供进度条基类接口，来反映当前算法的进度值
*/
class  CProcessBase //IMGALG_API
{
public:
	/**
	* @brief 构造函数
	*/
	CProcessBase() 
	{
		m_dPosition = 0.0;
		m_iStepCount = 100;
		m_iCurStep = 0;
		m_bIsContinue = true;
	}

	/**
	* @brief 析构函数
	*/
	virtual ~CProcessBase() {}

	/**
	* @brief 设置进度信息
	* @param pszMsg			进度信息
	*/
	virtual void SetMessage(const char* pszMsg) = 0;

	/**
	* @brief 设置进度值
	* @param dPosition		进度值
	* @return 返回是否取消的状态，true为不取消，false为取消
	*/
	virtual bool SetPosition(double dPosition) = 0;

	/**
	* @brief 进度条前进一步，返回true表示继续，false表示取消
	* @return 返回是否取消的状态，true为不取消，false为取消
	*/
	virtual bool StepIt() = 0;

	/**
	* @brief 设置进度个数
	* @param iStepCount		进度个数
	*/
	virtual void SetStepCount(int iStepCount)
	{
		ReSetProcess();	
		m_iStepCount = iStepCount;
	}

	/**
	* @brief 获取进度信息
	* @return 返回当前进度信息
	*/
	string GetMessage()
	{
		return m_strMessage;
	}

	/**
	* @brief 获取进度值
	* @return 返回当前进度值
	*/
	double GetPosition()
	{
		return m_dPosition;
	}

	/**
	* @brief 重置进度条
	*/
	void ReSetProcess()
	{
		m_dPosition = 0.0;
		m_iStepCount = 100;
		m_iCurStep = 0;
		m_bIsContinue = true;
	}

	/*! 进度信息 */
	string m_strMessage;
	/*! 进度值 */
	double m_dPosition;		
	/*! 进度个数 */
	int m_iStepCount;		
	/*! 进度当前个数 */
	int m_iCurStep;			
	/*! 是否取消，值为false时表示计算取消 */
	bool m_bIsContinue;			
};		
