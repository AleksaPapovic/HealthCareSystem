using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class LekarRepozitorijum
    {
        private string lokacija;

        private static LekarRepozitorijum _instance;

        public static LekarRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LekarRepozitorijum();

                }
                return _instance;
            }
        }

        public LekarRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\lekar.json";
        }

        public void sacuvaj(List<Lekar> lekari)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, lekari);
            jWriter.Close();
            writer.Close();
        }
        public List<Lekar> dobaviSve()
        {
            List<Lekar> lekari = new List<Lekar>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    lekari = JsonConvert.DeserializeObject<List<Lekar>>(jsonText);
                }
            }
            return lekari;
        }
    }
}
