using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;


namespace PPLTest.ClassLib
{
    public class XmlHelper
    {
        #region Declare the global variables
        XmlDocument xmldoc;
        XmlElement xmlelem;
        Log mylog=new Log();
        #endregion

        public XmlHelper()
        {
            xmldoc = new XmlDocument();
        }

        #region Creat xml file

        /// <summary>
        /// creat a Xml file with the root node and xslsheet
        /// </summary>
        /// <param name="FullFileName">The full name of the xml file</param>
        /// <param name="rootName">root node name</param>
        /// <param name="Encode">the encoding of the xml (gb2312,UTF-8...)</param>
        public void CreateXmlDocument(string FullFileName, string rootName, string Encode,string State)
        {
            try
            {
                //add version info
                XmlDeclaration declare = xmldoc.CreateXmlDeclaration("1.0", Encode, null);
                xmldoc.AppendChild(declare);
                //add xslsheet to control the report style on IE
                XmlNode xslsheet = xmldoc.CreateNode(XmlNodeType.ProcessingInstruction, "xml-stylesheet", "");
                xslsheet.Value = "type=\"text/xsl\" href=\"ReportStyle\\ResultReportxslt_" + State + ".xsl\"";
                xmldoc.AppendChild(xslsheet);
                //add the root node
                XmlElement Root = xmldoc.CreateElement(rootName);
                xmldoc.AppendChild(Root);
                //save the info to the file
                xmldoc.Save(FullFileName);
            }
            catch (Exception e)
            {
                mylog.WriteLog(e.Message+e.StackTrace);
            }
        }

        #endregion

        #region common operate on xml files
        /// <summary>
        /// creat a new node and add its' attributes
        /// </summary>
        /// <param name="FullXmlFileName">the full name of the xml file</param>
        /// <param name="NodeName">the name of the new node</param>
        /// <param name="Attribute">the attributes of new node(Key is the attribute name, Value is the attribute )</param>
        /// <param name="fatherNodeXpath">parent node</param>
        public void InsertNode(string FullXmlFileName, string NewNodeName, Hashtable NewNodeAttributes, string fatherNodeXpath)
        {
            try
            {
                xmldoc.Load(FullXmlFileName);
                XmlNode root = xmldoc.SelectSingleNode(fatherNodeXpath);
                xmlelem = xmldoc.CreateElement(NewNodeName);
                if (NewNodeAttributes != null )//if the attributes is not null, add the attributes first
                {
                    foreach (DictionaryEntry de in NewNodeAttributes)
                    {
                        xmlelem.SetAttribute(de.Key.ToString(), de.Value.ToString());
                    }
                }
                root.AppendChild(xmlelem);
                xmldoc.Save(FullXmlFileName);
            }
            catch (Exception e)
            {
                mylog.WriteLog(fatherNodeXpath + "\r\n" + e.Message + e.StackTrace);
            }
        }


        /// <summary>
        /// creat a new node and add its' children node
        /// </summary>
        /// <param name="FullXmlFileName">the full name of the xml file</param>
        /// <param name="fatherNodeXpath">the parent node which new node will insert in</param>
        /// <param name="NewNodeName">the name of new node</param>
        /// <param name="NewNodeAttributes">the attributes of new node</param>
        /// <param name="ChildNodeName">the name of new node's child node</param>
        /// <param name="ChildNodeAttribute">he attributes of new node's child node</param>
        public void InsertNode(string FullXmlFileName, string fatherNodeXpath, string NewNodeName, Hashtable NewNodeAttributes, string ChildNodeName, Hashtable ChildNodeAttribute)
        {
            try
            {
                xmldoc.Load(FullXmlFileName);
                XmlNode root = xmldoc.SelectSingleNode(fatherNodeXpath);
                xmlelem = xmldoc.CreateElement(NewNodeName);
                if (NewNodeAttributes != null)
                {
                    //add new node's attributes
                    foreach (DictionaryEntry de in NewNodeAttributes)
                    {
                        xmlelem.SetAttribute(de.Key.ToString(), de.Value.ToString());
                    }
                }
                //add child node and its' attributes
                XmlElement child = xmldoc.CreateElement(ChildNodeName);
                if (ChildNodeAttribute != null)
                {
                    foreach (DictionaryEntry de in ChildNodeAttribute)
                    {
                        child.SetAttribute(de.Key.ToString(), de.Value.ToString());
                    }
                }
                xmlelem.AppendChild(child);
                root.AppendChild(xmlelem);
                xmldoc.Save(FullXmlFileName);
            }
            catch (Exception e)
            {
                mylog.WriteLog(fatherNodeXpath+"\r\n"+e.Message + e.StackTrace);
            }
        }

        /// <summary>
        /// add a exist node to the xml file 
        /// </summary>
        /// <param name="FullXmlFileName">the full name of the xml file</param>
        /// <param name="NewNode">the list of new nodes</param>
        /// <param name="fatherNodeXpath">the father node</param>
        public void InsertNode(string FullXmlFileName, List<XmlNode> NewNode, string fatherNodeXpath)
        {
            try
            {
                xmldoc.Load(FullXmlFileName);
                XmlNode root = xmldoc.SelectSingleNode(fatherNodeXpath);
                foreach (XmlNode xn in NewNode)
                {
                    //add new nodes
                    root.AppendChild(xn);
                }
                xmldoc.Save(FullXmlFileName);
            }
            catch (Exception ex)
            {
                mylog.WriteLog(fatherNodeXpath+"\r\n"+ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// update node's atrributes
        /// </summary>
        /// <param name="FullXmlFileName">the full name of the xml file</param>
        /// <param name="NodeXpath">the change node</param>
        /// <param name="NewAttributes">the attributes</param>
        public void UpdateNode(string FullXmlFileName, string NodeXpath, Hashtable NewAttributes)
        {
            xmldoc.Load(FullXmlFileName);
            XmlElement xmlelem = (XmlElement)xmldoc.SelectSingleNode(NodeXpath);
            if (NewAttributes != null)
            {
                foreach (DictionaryEntry de in NewAttributes)
                {
                    xmlelem.SetAttribute(de.Key.ToString(), de.Value.ToString());
                }
            }
            xmldoc.Save(FullXmlFileName); 
        }
        /// <summary>
        /// 复制节点到新的文件
        /// </summary>
        /// <param name="SourceXmlFile">源文件</param>
        /// <param name="DestinationXmlFile">目标文件</param>
        /// <param name="CopyNodes">源文件节点</param>
        /// <param name="fatherNodeXpath">目标文件父节点</param>
        
        /// <summary>
        /// copy node from source xml file to another
        /// </summary>
        /// <param name="SourceXmlFile">the full name of the source xml file</param>
        /// <param name="DestinationXmlFile">the full name of the destination xml file</param>
        /// <param name="CopyNodesPath">the list of the copy nodes in source xml file</param>
        /// <param name="fatherNodeXpath">the father node in destination xml file</param>
        public void CopyNode(string SourceXmlFile, string DestinationXmlFile, List<string> CopyNodesPath, string fatherNodeXpath)
        {
            try
            {
                xmldoc.Load(SourceXmlFile);
                List<XmlNode> myNodes = new List<XmlNode>();
                foreach (string nodePath in CopyNodesPath)
                {
                    //add the node to the list
                    myNodes.Add(xmldoc.SelectSingleNode(nodePath).CloneNode(false));
                }
                this.InsertNode(DestinationXmlFile, myNodes, fatherNodeXpath);
            }
            catch (Exception ex)
            {
                mylog.WriteLog(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// get the attribute value of the node
        /// </summary>
        /// <param name="FullXmlFileName">the full name of the xml file</param>
        /// <param name="NodeXPath">the node name</param>
        /// <param name="AttributeName">the attribute name of the name</param>
        /// <returns></returns>
        public string GetNodeAttribute(string FullXmlFileName, string NodeXPath, string AttributeName)
        {
            string value="";
            xmldoc.Load(FullXmlFileName);
            value= xmldoc.SelectSingleNode(NodeXPath).Attributes[AttributeName].Value.ToString().Trim();
            xmldoc.Save(FullXmlFileName);
            return value;
        }

        public string GetNodeValue(string FullXmlFileName, string NodeXPath)
        {
            XmlDocument xd = new XmlDocument();
            string value = "";
            xd.Load(FullXmlFileName);
            value = xd.SelectSingleNode(NodeXPath).InnerText.Trim();
            xd.Save(FullXmlFileName);

            return value;
        }


        #endregion        
    }
}