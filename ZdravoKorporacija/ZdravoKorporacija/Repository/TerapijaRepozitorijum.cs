// File:    Doctor.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:16 PM
// Purpose: Definition of Class Doctor

using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace Repository
{
    public class TerapijaRepozitorijum
    {
        private string lokacija;

        public TerapijaRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\terapija.json";
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

        public Model.Terapija Dobavi()
        {
            // TODO: implement
            return null;
        }

        public List<Terapija> DobaviSve()
        {
            List<Terapija> terapije = new List<Terapija>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    terapije = JsonConvert.DeserializeObject<List<Terapija>>(jsonText);
                }
            }
            return terapije;
        }

        public void Sacuvaj(List<Terapija> terapije)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, terapije);
            jWriter.Close();
            writer.Close();
        }

    }
}