using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
    class IDRepozitorijum
    {

        private string lokacija;
        public IDRepozitorijum(string nazivID)
        {
            this.lokacija = @"..\..\..\Data\" + nazivID + ".json";
        }

        public void sacuvaj(Dictionary<int, int> id_map)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, id_map);
            jWriter.Close();
            writer.Close();
        }
        public Dictionary<int, int> dobaviSve()
        {
            Dictionary<int, int> id_map = new Dictionary<int, int>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    id_map = JsonConvert.DeserializeObject<Dictionary<int, int>>(jsonText);
                }
            }
            return id_map;
        }
    }
}
