using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class TerminRepozitorijum
    {
        private string lokacija;

        private static TerminRepozitorijum _instance;
        public ObservableCollection<Termin> termini;
        public static TerminRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TerminRepozitorijum();

                }
                return _instance;
            }
        }

        public TerminRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\termini.json";
            termini = new ObservableCollection<Termin>();
        }

        public void sacuvaj(List<Termin> termini)
        {
            JsonSerializer serializer = new JsonSerializer();
            //serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, termini);
            jWriter.Close();
            writer.Close();

            // Serijalizacija(termini);

            //Serijalizacija(termini);

        }

        public void sacuvaj2(ObservableCollection<Termin> termini)
        {

            JsonSerializer serializer = new JsonSerializer();
            //serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, termini);
            jWriter.Close();
            writer.Close();

            // Serijalizacija(termini);

            //Serijalizacija(termini);

        }

        string SerializeObjectByJObject(List<Termin> ter)
        {
            string s = "";

            var joa = JArray.FromObject(ter);
           
            //int i = 0;

            //foreach ( JObject z in joa) {

            //    joa[i]["prostorija"]["inventar"].Parent.Remove();
            //    joa[i]["prostorija"]["statickaOprema"].Parent.Remove();
            //    joa[i]["prostorija"]["dinamickaOprema"].Parent.Remove();
            //    joa[i]["prostorija"]["Naziv"].Parent.Remove();
            //    joa[i]["prostorija"]["Tip"].Parent.Remove();
            //    joa[i]["prostorija"]["Slobodna"].Parent.Remove();
            //    joa[i]["prostorija"]["Sprat"].Parent.Remove();

            //    i++;
            //}

            //jo.Remove("prostorija");
            //jo.Add("prostorija", new JObject());
            //jo["prostorija"].AddAnnotation("Id") ;
            // jo["prostorija"]["Id"] = t.prostorija.Id;
            // s += jo.ToString();
            //}
            return joa.ToString();
        }

        public void Serijalizacija(List<Termin> termini)
        {
            string json = SerializeObjectByJObject(termini);
            File.WriteAllText(@"..\..\..\Data\termini2.json", json);
        }


        public List<Termin> dobaviSve()
        {
            List<Termin> termini = new List<Termin>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    termini = JsonConvert.DeserializeObject<List<Termin>>(jsonText);
                }
            }
            if (termini != null)
            {
                this.termini = new ObservableCollection<Termin>(termini);
            }
            return termini;
        }
    }
}
