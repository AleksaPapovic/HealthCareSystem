using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;


using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Repository
{
    class StacionarnoLecenjeRepozitorijum
    {
        private string lokacija;

        private static StacionarnoLecenjeRepozitorijum _instance;
        public ObservableCollection<StacionarnoLecenje> StacionarnaLecenja;

        public static StacionarnoLecenjeRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StacionarnoLecenjeRepozitorijum();
                }
                return _instance;
            }
        }
        public StacionarnoLecenjeRepozitorijum()
        {
            lokacija = @"..\..\..\Data\StacionarnoLecenje.json";
        }


        public bool Kreiraj()
        {
            // TODO: implement
            return false;
        }

        public bool Obrisi(StacionarnoLecenje StacionarnoLecenje)
        {
            StacionarnaLecenja.Remove(StacionarnoLecenje);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, StacionarnaLecenja);
            jWriter.Close();
            writer.Close();
            return true;
        }

        public StacionarnoLecenje Dobavi()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<StacionarnoLecenje> DobaviSve()
        {
            ObservableCollection<StacionarnoLecenje> StacionarnaLecenja = new ObservableCollection<StacionarnoLecenje>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    StacionarnaLecenja = JsonConvert.DeserializeObject<ObservableCollection<StacionarnoLecenje>>(jsonText);
                }
            }
            if (StacionarnaLecenja != null)
            {
                this.StacionarnaLecenja = new ObservableCollection<StacionarnoLecenje>(StacionarnaLecenja);
            }
            return StacionarnaLecenja;
        }

        public void Sacuvaj(ObservableCollection<StacionarnoLecenje> StacionarnaLecenja)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, StacionarnaLecenja);
            jWriter.Close();
            writer.Close();
        }

    }
}
