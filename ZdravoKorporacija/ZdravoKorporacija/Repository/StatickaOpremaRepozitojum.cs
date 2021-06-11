using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
    public class StatickaOpremaRepozitorijum
    {

        private static StatickaOpremaRepozitorijum _instance;
        public ObservableCollection<StatickaOprema> magacinStatickaOprema;
        public static StatickaOpremaRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StatickaOpremaRepozitorijum();

                }
                return _instance;
            }
        }

        private StatickaOpremaRepozitorijum()
        {
            magacinStatickaOprema = new ObservableCollection<StatickaOprema>();
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

        public StatickaOprema Dobavi()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<StatickaOprema> DobaviSve()
        {
            string lokacija = @"..\..\..\Data\statickaOprema.json";
            List<StatickaOprema> oprema = new List<StatickaOprema>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    oprema = JsonConvert.DeserializeObject<List<StatickaOprema>>(jsonText);
                }
            }
            if (oprema != null)
            {
                magacinStatickaOprema = new ObservableCollection<StatickaOprema>(oprema);
            }
            return magacinStatickaOprema;
        }

        public int Sacuvaj()
        {

            string lokacija = @"..\..\..\Data\statickaOprema.json";
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, magacinStatickaOprema);
            jWriter.Close();
            writer.Close();
            return 1;
        }

    }
}
