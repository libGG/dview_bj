using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ReportDemo
{
    /// <summary>
    /// XML文档读写
    /// </summary>
    public class XmlCommon
    {
        #region 数据成员

        //文档
        XmlDocument _xmlDoc = null;

        //文档路径
        string _xmlPath = "";

        #endregion

        #region 属性

        /// <summary>
        /// 判断节点是否符合条件的委托
        /// </summary>
        /// <param name="xn"></param>
        /// <returns></returns>
        public delegate bool delegateCheckNode(XmlNode xn);

        /// <summary>
        /// XML文档
        /// </summary>
        protected XmlDocument XmlDoc
        {
            get
            {
                if (_xmlDoc == null)
                {
                    if (string.IsNullOrEmpty(_xmlPath))
                        throw new Exception("请先设置XML文档路径！");
                    _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(_xmlPath);//加载文档
                }
                return _xmlDoc;
            }
            set
            {
                _xmlDoc = value;
            }
        }

        /// <summary>
        /// 文档路径
        /// </summary>
        public string XmlPath
        {
            get { return _xmlPath; }
            set
            {
                _xmlPath = value;

                _xmlDoc = null;//重置文档
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// XML文档读取器
        /// </summary>
        public XmlCommon()
        { }

        /// <summary>
        /// XML文档读取器
        /// </summary>
        /// <param name="xml_Path">XML文档路径</param>
        public XmlCommon(string xml_Path)
        {
            _xmlPath = xml_Path;
        }

        #endregion

        #region 内部函数

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            if (XmlDoc != null)
            {
                XmlDoc.Save(XmlPath);
                XmlDoc = null;
            }
        }
        public XmlElement CreatElement(string name)
        {
            if (XmlDoc != null)
            {
                return XmlDoc.CreateElement(name);
            }
            return null;
        }

        /// <summary>
        /// 遍历所有节点
        /// </summary>
        /// <param name="xnList"></param>
        /// <param name="delcn"></param>
        protected void checkAllNode(List<XmlNode> xnList, delegateCheckNode delcn, XmlNode xn)
        {
            //递归
            if (xn.HasChildNodes)
            {
                foreach (XmlNode cxn in xn.ChildNodes)
                {
                    if (delcn != null && delcn(cxn)) //委托不为空且条件符合
                        xnList.Add(cxn);

                    checkAllNode(xnList, delcn, cxn);//如果有子节点则遍历子节点
                }
            }
        }

        /// <summary>
        /// 获取节点通过委托
        /// </summary>
        /// <param name="delcn"></param>
        /// <param name="xn"></param>
        /// <returns></returns>
        protected XmlNode getXmlNodeByDelegate(delegateCheckNode delcn, XmlNode xn)
        {
            if (delcn != null && delcn(xn)) //委托不为空且条件符合
                return xn;
            //递归
            if (xn.HasChildNodes)
            {
                foreach (XmlNode cxn in xn.ChildNodes)
                {

                    XmlNode ccxn = getXmlNodeByDelegate(delcn, cxn);//如果有子节点则遍历子节点
                    if (ccxn != null) return ccxn;
                }
            }

            return null;
        }
        #endregion

        #region public函数

        public bool RemoveNodeByID(XmlNode nd, bool isDeleteF,string idstr)
        {
            foreach (XmlNode node in nd.ChildNodes)
            {
                if (node.Attributes["id"].Value == idstr)
                {
                    nd.RemoveChild(node);
                }
               
            }
            foreach (XmlNode node in nd.ChildNodes)
            {
               
                if (isDeleteF && (node.Attributes["fid"].Value == idstr))
                {
                    nd.RemoveChild(node);
                }
            }
            return true;
        }

        /// <summary>
        /// 通过委托获取单个节点
        /// </summary>
        /// <param name="delcn">获取节点的委托</param>
        /// <returns></returns>
        public XmlNode GetNodeByDelegate(delegateCheckNode delcn)
        {
            //循环所有顶级节点
            foreach (XmlNode xn in XmlDoc.ChildNodes)
            {
                if (delcn != null && delcn(xn)) //委托不为空且条件符合
                    return xn;

                if (xn.HasChildNodes)
                {
                    XmlNode cxn = getXmlNodeByDelegate(delcn, xn);//如果有子节点则遍历子节点
                    if (cxn != null) return cxn;
                }
            }
            return null;
        }

        /// <summary>
        /// 查找所有符合条件的节点
        /// </summary>
        /// <param name="delcn">条件委托</param>
        /// <returns></returns>
        public List<XmlNode> getNodeListByDelegate(delegateCheckNode delcn)
        {
            List<XmlNode> xnList = new List<XmlNode>();

            //循环所有顶级节点
            foreach (XmlNode xn in XmlDoc.ChildNodes)
            {
                if (delcn != null && delcn(xn)) //委托不为空且条件符合
                    xnList.Add(xn);
                if (xn.HasChildNodes)
                {
                    checkAllNode(xnList, delcn, xn);//如果有子节点则遍历子节点
                }
            }

            return xnList;

        }


        /// <summary>
        /// 通过路径获取节点
        /// </summary>
        /// <param name="nodePath">节点路径（如：application/appsetting）</param>
        /// <returns></returns>
        public XmlNode GetNodeByPath(string nodePath)
        {
            if (string.IsNullOrEmpty(nodePath)) throw new Exception("节点的路径不可为空！");

            //通过路径查得节点
            XmlNode xn = XmlDoc.SelectSingleNode(nodePath);

            return xn;
        }

        /// <summary>
        /// 通过节点名称读取其值
        /// </summary>
        /// <param name="nodePath">节点路径（如：application/appsetting）</param>
        /// <returns></returns>
        public string ReadValueByPath(string nodePath)
        {
            if (string.IsNullOrEmpty(nodePath)) throw new Exception("节点的路径不可为空！");

            XmlNode xn = GetNodeByPath(nodePath);//通过路径获取节点

            if (xn != null) return xn.Value;

            return string.Empty;//返回空值
        }

        /// <summary>
        /// 通过属读取值
        /// </summary>
        /// <param name="AttributeName">属性名</param>
        /// <param name="AttributeValue">属性值</param>
        /// <returns></returns>
        public string ReadValueByAttribute(string AttributeName, string AttributeValue)
        {

            XmlNode xn = GetNodeByAttribute(AttributeName, AttributeValue);//通过属性获取节点

            if (xn != null) //存在此节点
                return xn.Value;

            return string.Empty;//返回空值
        }

        /// <summary>
        /// 通过属性获取节点
        /// </summary>
        /// <param name="AttributeName">属性名</param>
        /// <param name="AttributeValue">属性值</param>
        /// <returns></returns>
        public XmlNode GetNodeByAttribute(string AttributeName, string AttributeValue)
        {
            if (string.IsNullOrEmpty(AttributeName)) throw new Exception("节点的属性名不可为空！");

            //新建委托
            delegateCheckNode delcn = new delegateCheckNode(delegate(XmlNode xn)
            {
                return (xn.Attributes != null && xn.Attributes[AttributeName] != null && xn.Attributes[AttributeName].Value == AttributeValue);
            });

            return GetNodeByDelegate(delcn);//通过委托获取节点
        }

        /// <summary>
        /// 获取所有属性符合条件的节点集合
        /// </summary>
        /// <param name="AttributeName">属性名</param>
        /// <param name="AttributeValue">属性值</param>
        /// <returns></returns>
        public List<XmlNode> GetNodeListByAttribute(string AttributeName, string AttributeValue)
        {
            if (string.IsNullOrEmpty(AttributeName)) throw new Exception("节点的属性名不可为空！");

            //新建委托
            delegateCheckNode delcn = new delegateCheckNode(delegate(XmlNode xn)
            {
                return (xn.Attributes != null && xn.Attributes[AttributeName] != null && xn.Attributes[AttributeName].Value == AttributeValue);
            });

            return getNodeListByDelegate(delcn);//返回所有符合条件的节点
        }

        #endregion
    }
}
