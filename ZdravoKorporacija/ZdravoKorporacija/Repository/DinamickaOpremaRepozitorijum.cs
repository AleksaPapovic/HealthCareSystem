using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{

    public class DinamickaOpremaRepozitorijum
    {
        private static DinamickaOpremaRepozitorijum _instance;
        public ObservableCollection<DinamickaOprema> magacinDinamickaOprema;
        public static DinamickaOpremaRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DinamickaOpremaRepozitorijum();

                }
                return _instance;
            }
        }

        private DinamickaOpremaRepozitorijum()
        {
            magacinDinamickaOprema = new ObservableCollection<DinamickaOprema>();
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

        public DinamickaOprema Dobavi()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<DinamickaOprema> DobaviSve()
        {
            string lokacija = @"..\..\..\Data\dinamickaOprema.json";
            List<DinamickaOprema> oprema = new List<DinamickaOprema>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    oprema = JsonConvert.DeserializeObject<List<DinamickaOprema>>(jsonText);
                }
            }
            if (oprema != null)
            {
                magacinDinamickaOprema = new ObservableCollection<DinamickaOprema>(oprema);
            }
            return magacinDinamickaOprema;
        }

        public int Sacuvaj()
        {
            string lokacija = @"..\..\..\Data\dinamickaOprema.json";
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, magacinDinamickaOprema);
            jWriter.Close();
            writer.Close();
            return 1;
        }

    }
}
