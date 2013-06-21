using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace ReportDemo
{
    /// <summary>
    /// XML≈‰÷√Œƒº˛∑√Œ 
    /// </summary>
    public class XmlConfig
    {
        public static string GetNodeValue(string nodeName)
        {
            try
            {
                return ConfigurationManager.AppSettings[nodeName];
            }
            catch (Exception ex)
            {
                //Debug.Assert(false,ex.Message);

                return null;
            }
        }

        public static bool SetNodeValue(string nodeName, string nodeValue)
        {
            try
            {
                //DEqGIS.exe.config
                Configuration cf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                AppSettingsSection ass = cf.AppSettings;

                if (nodeValue == null)
                    nodeValue = "";

                ass.Settings[nodeName].Value = nodeValue;
                System.Configuration.ConfigurationManager.AppSettings.Set(nodeName, nodeValue);
                cf.Save();

                return true;
            }
            catch (Exception ex)
            {
                //Debug.Assert(false,ex.Message);

                return false;
            }
        }
    }
}
