using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarNode
{
    public static class Parser
    {
        public static List<Node> Parse()
        {
            try
            {
                //linq to xml Xdocument read file
                XDocument xDoc = XDocument.Load("graph.xml");

                //convert to list of Node
                List<Node> nodes = (from x in xDoc.Root.Elements("node")
                                    select new Node()
                                    {
                                        id = (int)x.Attribute("id"),
                                        reference = (int)x.Element("link").Attribute("ref"),
                                        weight = (int)x.Element("link").Attribute("weight")
                                    }).ToList();                
                return nodes;
            }
            catch
            {
                //incorrect format
                Reporter.Report("Error: XML File Incorrect\nPress any key to exit...");
            }
            return null;
        }
    }
}