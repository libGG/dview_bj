using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ReportDemo
{
    /// <summary>
    /// XML�ĵ���д
    /// </summary>
    public class XmlCommon
    {
        #region ���ݳ�Ա

        //�ĵ�
        XmlDocument _xmlDoc = null;

        //�ĵ�·��
        string _xmlPath = "";

        #endregion

        #region ����

        /// <summary>
        /// �жϽڵ��Ƿ����������ί��
        /// </summary>
        /// <param name="xn"></param>
        /// <returns></returns>
        public delegate bool delegateCheckNode(XmlNode xn);

        /// <summary>
        /// XML�ĵ�
        /// </summary>
        protected XmlDocument XmlDoc
        {
            get
            {
                if (_xmlDoc == null)
                {
                    if (string.IsNullOrEmpty(_xmlPath))
                        throw new Exception("��������XML�ĵ�·����");
                    _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(_xmlPath);//�����ĵ�
                }
                return _xmlDoc;
            }
            set
            {
                _xmlDoc = value;
            }
        }

        /// <summary>
        /// �ĵ�·��
        /// </summary>
        public string XmlPath
        {
            get { return _xmlPath; }
            set
            {
                _xmlPath = value;

                _xmlDoc = null;//�����ĵ�
            }
        }

        #endregion

        #region ���캯��

        /// <summary>
        /// XML�ĵ���ȡ��
        /// </summary>
        public XmlCommon()
        { }

        /// <summary>
        /// XML�ĵ���ȡ��
        /// </summary>
        /// <param name="xml_Path">XML�ĵ�·��</param>
        public XmlCommon(string xml_Path)
        {
            _xmlPath = xml_Path;
        }

        #endregion

        #region �ڲ�����

        /// <summary>
        /// �ر�
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
        /// �������нڵ�
        /// </summary>
        /// <param name="xnList"></param>
        /// <param name="delcn"></param>
        protected void checkAllNode(List<XmlNode> xnList, delegateCheckNode delcn, XmlNode xn)
        {
            //�ݹ�
            if (xn.HasChildNodes)
            {
                foreach (XmlNode cxn in xn.ChildNodes)
                {
                    if (delcn != null && delcn(cxn)) //ί�в�Ϊ������������
                        xnList.Add(cxn);

                    checkAllNode(xnList, delcn, cxn);//������ӽڵ�������ӽڵ�
                }
            }
        }

        /// <summary>
        /// ��ȡ�ڵ�ͨ��ί��
        /// </summary>
        /// <param name="delcn"></param>
        /// <param name="xn"></param>
        /// <returns></returns>
        protected XmlNode getXmlNodeByDelegate(delegateCheckNode delcn, XmlNode xn)
        {
            if (delcn != null && delcn(xn)) //ί�в�Ϊ������������
                return xn;
            //�ݹ�
            if (xn.HasChildNodes)
            {
                foreach (XmlNode cxn in xn.ChildNodes)
                {

                    XmlNode ccxn = getXmlNodeByDelegate(delcn, cxn);//������ӽڵ�������ӽڵ�
                    if (ccxn != null) return ccxn;
                }
            }

            return null;
        }
        #endregion

        #region public����

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
        /// ͨ��ί�л�ȡ�����ڵ�
        /// </summary>
        /// <param name="delcn">��ȡ�ڵ��ί��</param>
        /// <returns></returns>
        public XmlNode GetNodeByDelegate(delegateCheckNode delcn)
        {
            //ѭ�����ж����ڵ�
            foreach (XmlNode xn in XmlDoc.ChildNodes)
            {
                if (delcn != null && delcn(xn)) //ί�в�Ϊ������������
                    return xn;

                if (xn.HasChildNodes)
                {
                    XmlNode cxn = getXmlNodeByDelegate(delcn, xn);//������ӽڵ�������ӽڵ�
                    if (cxn != null) return cxn;
                }
            }
            return null;
        }

        /// <summary>
        /// �������з��������Ľڵ�
        /// </summary>
        /// <param name="delcn">����ί��</param>
        /// <returns></returns>
        public List<XmlNode> getNodeListByDelegate(delegateCheckNode delcn)
        {
            List<XmlNode> xnList = new List<XmlNode>();

            //ѭ�����ж����ڵ�
            foreach (XmlNode xn in XmlDoc.ChildNodes)
            {
                if (delcn != null && delcn(xn)) //ί�в�Ϊ������������
                    xnList.Add(xn);
                if (xn.HasChildNodes)
                {
                    checkAllNode(xnList, delcn, xn);//������ӽڵ�������ӽڵ�
                }
            }

            return xnList;

        }


        /// <summary>
        /// ͨ��·����ȡ�ڵ�
        /// </summary>
        /// <param name="nodePath">�ڵ�·�����磺application/appsetting��</param>
        /// <returns></returns>
        public XmlNode GetNodeByPath(string nodePath)
        {
            if (string.IsNullOrEmpty(nodePath)) throw new Exception("�ڵ��·������Ϊ�գ�");

            //ͨ��·����ýڵ�
            XmlNode xn = XmlDoc.SelectSingleNode(nodePath);

            return xn;
        }

        /// <summary>
        /// ͨ���ڵ����ƶ�ȡ��ֵ
        /// </summary>
        /// <param name="nodePath">�ڵ�·�����磺application/appsetting��</param>
        /// <returns></returns>
        public string ReadValueByPath(string nodePath)
        {
            if (string.IsNullOrEmpty(nodePath)) throw new Exception("�ڵ��·������Ϊ�գ�");

            XmlNode xn = GetNodeByPath(nodePath);//ͨ��·����ȡ�ڵ�

            if (xn != null) return xn.Value;

            return string.Empty;//���ؿ�ֵ
        }

        /// <summary>
        /// ͨ������ȡֵ
        /// </summary>
        /// <param name="AttributeName">������</param>
        /// <param name="AttributeValue">����ֵ</param>
        /// <returns></returns>
        public string ReadValueByAttribute(string AttributeName, string AttributeValue)
        {

            XmlNode xn = GetNodeByAttribute(AttributeName, AttributeValue);//ͨ�����Ի�ȡ�ڵ�

            if (xn != null) //���ڴ˽ڵ�
                return xn.Value;

            return string.Empty;//���ؿ�ֵ
        }

        /// <summary>
        /// ͨ�����Ի�ȡ�ڵ�
        /// </summary>
        /// <param name="AttributeName">������</param>
        /// <param name="AttributeValue">����ֵ</param>
        /// <returns></returns>
        public XmlNode GetNodeByAttribute(string AttributeName, string AttributeValue)
        {
            if (string.IsNullOrEmpty(AttributeName)) throw new Exception("�ڵ������������Ϊ�գ�");

            //�½�ί��
            delegateCheckNode delcn = new delegateCheckNode(delegate(XmlNode xn)
            {
                return (xn.Attributes != null && xn.Attributes[AttributeName] != null && xn.Attributes[AttributeName].Value == AttributeValue);
            });

            return GetNodeByDelegate(delcn);//ͨ��ί�л�ȡ�ڵ�
        }

        /// <summary>
        /// ��ȡ�������Է��������Ľڵ㼯��
        /// </summary>
        /// <param name="AttributeName">������</param>
        /// <param name="AttributeValue">����ֵ</param>
        /// <returns></returns>
        public List<XmlNode> GetNodeListByAttribute(string AttributeName, string AttributeValue)
        {
            if (string.IsNullOrEmpty(AttributeName)) throw new Exception("�ڵ������������Ϊ�գ�");

            //�½�ί��
            delegateCheckNode delcn = new delegateCheckNode(delegate(XmlNode xn)
            {
                return (xn.Attributes != null && xn.Attributes[AttributeName] != null && xn.Attributes[AttributeName].Value == AttributeValue);
            });

            return getNodeListByDelegate(delcn);//�������з��������Ľڵ�
        }

        #endregion
    }
}
