//created by lib
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DView.SXEQJB.TempleteMgr
{
    /// <summary>
    /// ͨ�ù�����
    /// </summary>
    public class CommonUtl
    {
        /// <summary>
        /// �жϵ�ǰϵͳ�Ƿ���word���̴���
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
