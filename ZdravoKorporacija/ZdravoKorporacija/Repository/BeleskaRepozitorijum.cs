using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
    public class BeleskaRepozitorijum
    {
        private string lokacija;

        public BeleskaRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\beleska.json";
        }

        public List<Beleska> DobaviSve()
        {
            List<Beleska> beleske = new List<Beleska>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    beleske = JsonConvert.DeserializeObject<List<Beleska>>(jsonText);
                }
            }
            return beleske;
        }

        public void Sacuvaj(List<Beleska> beleske)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, beleske);
            jWriter.Close();
            writer.Close();
        }

    }
}