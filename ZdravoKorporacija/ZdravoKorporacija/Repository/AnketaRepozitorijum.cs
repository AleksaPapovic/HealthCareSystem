using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
    public class AnketaRepozitorijum
    {
        private string lokacija;

        private static AnketaRepozitorijum _instance;

        public static AnketaRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AnketaRepozitorijum();
                }
                return _instance;
            }
        }

        public AnketaRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\anketa.json";
        }
        public bool Kreiraj()
        {
            // TODO: implement
            return false;
        }

        public bool Obrisi(int id)
        {
            // TODO: implement
            return false;
        }

        public Anketa Dobavi()
        {
            // TODO: implement
            return null;
        }

        public List<Anketa> DobaviSve()
        {
            List<Anketa> ankete = new List<Anketa>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    ankete = JsonConvert.DeserializeObject<List<Anketa>>(jsonText);
                }
            }
            return ankete;
        }

        public void Sacuvaj(List<Anketa> ankete)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, ankete);
            jWriter.Close();
            writer.Close();
        }

    }
}