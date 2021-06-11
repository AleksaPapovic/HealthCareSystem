// File:    Doctor.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:16 PM
// Purpose: Definition of Class Doctor

using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ZdravoKorporacija.DTO;

namespace Repository
{
    public class LekRepozitorijum
    {
        private static LekRepozitorijum _instance;
        public ObservableCollection<Lek> lekovi;
        public ObservableCollection<LekDTO> lekoviDTO;
        public string lokacija = @"..\..\..\Data\lek.json";
        public static LekRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LekRepozitorijum();

                }
                return _instance;
            }
        }

        private LekRepozitorijum()
        {
            lekovi = new ObservableCollection<Lek>();
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

        public Lek Dobavi()
        {
            // TODO: implement
            return null;
        }

        public List<Lek> DobaviSve()
        {
            List<Lek> ucitaniLekovi = new List<Lek>();
            List<LekDTO> ucitani = new List<LekDTO>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    ucitaniLekovi = JsonConvert.DeserializeObject<List<Lek>>(jsonText);
                    ucitani = JsonConvert.DeserializeObject<List<LekDTO>>(jsonText);
                }
                if (ucitaniLekovi != null)
                {
                    lekovi = new ObservableCollection<Lek>(ucitaniLekovi);
                }
                if (ucitani != null)
                {
                    lekoviDTO = new ObservableCollection<LekDTO>(ucitani);
                }
            }
            return ucitaniLekovi;
        }

        public void Sacuvaj()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, lekovi);
            jWriter.Close();
            writer.Close();
        }

    }
}