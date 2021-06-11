using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Repository
{
    public class XMLAPI
    {
        public object CustomerDataProvider { get; private set; }
        string xml = System.IO.File.ReadAllText(@"..\..\..\Data\prostorije.txt");
        public XElement GetXML()
		{
       
            XElement doc = XDocument.Parse(xml).Root;
            return doc;
        }
	}
}
