using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
    class PacijentRepozitorijum
    {

        private string lokacija;

        private static PacijentRepozitorijum _instance;
        public ObservableCollection<Pacijent> pacijenti;
        public static PacijentRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PacijentRepozitorijum();
                }
                return _instance;
            }
        }

        public PacijentRepozitorijum()

        {
            this.lokacija = @"..\..\..\Data\pacijent.json";
        }

        public void sacuvaj(List<Pacijent> pacijenti)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, pacijenti);
            jWriter.Close();
            writer.Close();
        }

        public List<Pacijent> dobaviSve()
        {
            List<Pacijent> pacijenti = new List<Pacijent>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                        pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(jsonText);
                }
            }
            return pacijenti;
        }

        public List<Pacijent> dobaviSve2()
        {
            List<Pacijent> pacijenti = new List<Pacijent>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(jsonText);
                }
            }
            if (pacijenti != null)
            {
                this.pacijenti = new ObservableCollection<Pacijent>(pacijenti);
            }
            return pacijenti;
        }
    }
}
