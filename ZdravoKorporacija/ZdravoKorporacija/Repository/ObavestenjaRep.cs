using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ZdravoKorporacija.Repository
{
    public class ObavestenjaRep
    {
        private string lokacija;

        public ObavestenjaRep()
        {
            this.lokacija = @"..\..\..\Data\obavestenja.json";
        }

        public void sacuvaj(List<Notifikacija> notifikacije)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, notifikacije);
            jWriter.Close();
            writer.Close();
        }

        public List<Notifikacija> dobaviSve()
        {
            List<Notifikacija> notifikacije = new List<Notifikacija>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    notifikacije = JsonConvert.DeserializeObject<List<Notifikacija>>(jsonText);
                }
            }
            return notifikacije;
        }
    }
}

