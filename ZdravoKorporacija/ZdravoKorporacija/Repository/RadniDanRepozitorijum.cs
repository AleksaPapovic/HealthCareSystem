using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
namespace Repository
{
    class RadniDanRepozitorijum
    {
        private string lokacija;

        public RadniDanRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\radniDan.json";
        }

        public void sacuvaj(List<RadniDan> dani)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, dani);
            jWriter.Close();
            writer.Close();
        }
        public List<RadniDan> dobaviSve()
        {
            List<RadniDan> dani = new List<RadniDan>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    dani = JsonConvert.DeserializeObject<List<RadniDan>>(jsonText);
                }
            }
            return dani;
        }
    }
}
