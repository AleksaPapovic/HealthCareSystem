using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Xml;
using ZdravoKorporacija.DTO;

namespace Repository
{
    public class ProstorijaRepozitorijum
    {
        private static ProstorijaRepozitorijum _instance;
        public ObservableCollection<Prostorija> prostorije;
        public ObservableCollection<ProstorijaDTO> prostorijeDTO;
        public static ProstorijaRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProstorijaRepozitorijum();

                }
                return _instance;
            }
        }

        public ProstorijaRepozitorijum()
        {
            prostorije = new ObservableCollection<Prostorija>();
        }

        public string lokacija = @"..\..\..\Data\prostorije.json";
        public void sacuvaj()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, prostorije);
            jWriter.Close();
            writer.Close();
        }

        private string GetXmlString(string strFile)
        {
            //string strFile = HttpContext.Current.Server.MapPath("~/YourFile.xml");	//if you want to use server.mappath use this and change your path accordingly
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFile);

            // Use StringWriter object to get data from xml-document.
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlDoc.WriteTo(xw);
            return sw.ToString();
        }

        public ObservableCollection<Prostorija> dobaviSve()
        {
            string lokacija = @"..\..\..\Data\prostorije.json";
            List<Prostorija> ucitaneProstorije = new List<Prostorija>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);

              

                //string xml = "<Test><Name>Test class</Name><X>100</X><Y>200</Y></Test>";
                string s = GetXmlString(@"..\..\..\Data\prostorije.txt");
                Debug.WriteLine(s);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(s);
                //string jsonText2 = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
                
                XMLAPI xmlAPI = new XMLAPI();
                XMLToJSONAdapter xmlAdapter = new XMLToJSONAdapter(xmlAPI);
                string jsonText2 = xmlAdapter.ConvertXmlToJson();
                string jsonheader = jsonText2.Substring(1, 139);
                string jsonend = jsonText2.Substring(jsonText2.Length-50, 48);
                string jsonText3 = jsonText2.Substring(140, jsonText2.Length - 142);
                Debug.WriteLine(jsonText3);

                if (!string.IsNullOrEmpty(jsonText))
                {
                    ucitaneProstorije = JsonConvert.DeserializeObject<List<Prostorija>>(jsonText);
                }
            }
            if (ucitaneProstorije != null)
            {
                prostorije = new ObservableCollection<Prostorija>(ucitaneProstorije);
            }
            return prostorije;
        }


    }
}
