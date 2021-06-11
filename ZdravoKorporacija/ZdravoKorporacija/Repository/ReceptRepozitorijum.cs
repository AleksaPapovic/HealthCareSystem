// File:    Doctor.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:16 PM
// Purpose: Definition of Class Doctor


using Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using ZdravoKorporacija.Repository;

namespace Repository
{
    class ReceptRepozitorijum : IReceptRepozitorijum
    {
        private string lokacija;

        private static ReceptRepozitorijum _instance;
        public ObservableCollection<Recept> recepti;

        public static ReceptRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceptRepozitorijum();
                }
                return _instance;
            }
        }
        public ReceptRepozitorijum()
        {
            lokacija = @"..\..\..\Data\recept.json";
        }



        public ObservableCollection<Recept> DobaviSve()
        {
            ObservableCollection<Recept> recepti = new ObservableCollection<Recept>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    recepti = JsonConvert.DeserializeObject<ObservableCollection<Recept>>(jsonText);
                }
            }
            if (recepti != null)
            {
                this.recepti = new ObservableCollection<Recept>(recepti);
            }
            return recepti;
        }

        public void Sacuvaj(ObservableCollection<Recept> recepti)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, recepti);
            jWriter.Close();
            writer.Close();
        }

    }
}
