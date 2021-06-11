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
    public class IstorijaBolestiRepozitorijum
    {
        private string lokacija;

        public IstorijaBolestiRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\istorijaBolesti.json";
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

        public IstorijaBolesti Dobavi()
        {
            return null;
        }

        public List<IstorijaBolesti> DobaviSve()
        {
            List<IstorijaBolesti> istorijeBolesti = new List<IstorijaBolesti>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    istorijeBolesti = JsonConvert.DeserializeObject<List<IstorijaBolesti>>(jsonText);
                }
            }
            return istorijeBolesti;
        }

        public void Sacuvaj(List<IstorijaBolesti> istorijeBolesti)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, istorijeBolesti);
            jWriter.Close();
            writer.Close();
        }

    }
}