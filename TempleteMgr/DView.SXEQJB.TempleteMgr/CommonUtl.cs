//created by lib
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DView.SXEQJB.TempleteMgr
{
    /// <summary>
    /// 通用工具类
    /// </summary>
    public class CommonUtl
    {
        /// <summary>
        /// 判断当前系统是否有word进程存在
        /// </summary>
        /// <returns></returns>
        public static bool CheckProcessHasWord()
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process var in ps)
            {
                if (var.ProcessName.ToLower().Contains("winword"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
