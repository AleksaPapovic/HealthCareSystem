using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
    public class MagacinRepozitorijum
    {
        private static MagacinRepozitorijum _instance;
        public ObservableCollection<Inventar> magacinOprema;

        public static MagacinRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MagacinRepozitorijum();

                }
                return _instance;
            }
        }

        private MagacinRepozitorijum()
        {
            magacinOprema = new ObservableCollection<Inventar>();
        }

        public ObservableCollection<Inventar> DobaviSve()
        {
            string lokacija = @"..\..\..\Data\inventar.json";
            List<Inventar> oprema = new List<Inventar>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    oprema = JsonConvert.DeserializeObject<List<Inventar>>(jsonText);
                }
            }
            if (oprema != null)
            {
                magacinOprema = new ObservableCollection<Inventar>(oprema);
            }
            return magacinOprema;

        }

        public int Sacuvaj(Inventar inventar)
        {

            magacinOprema.Add(inventar);

            string lokacija = @"..\..\..\Data\inventar.json";
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, magacinOprema);
            jWriter.Close();
            writer.Close();
            return 1;
        }
    }
}
