using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
    public class DijagnozaRepozitorijum
    {
        private string lokacija;

        public DijagnozaRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\dijagnoza.json";
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

        public Dijagnoza Dobavi()
        {
            // TODO: implement
            return null;
        }

        public List<Dijagnoza> DobaviSve()
        {
            List<Dijagnoza> dijagnoze = new List<Dijagnoza>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    dijagnoze = JsonConvert.DeserializeObject<List<Dijagnoza>>(jsonText);
                }
            }
            return dijagnoze;
        }

        public void Sacuvaj(List<Dijagnoza> dijagnoze)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, dijagnoze);
            jWriter.Close();
            writer.Close();
        }

    }
}