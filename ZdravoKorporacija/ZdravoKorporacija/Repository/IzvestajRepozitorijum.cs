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
    public class IzvestajRepozitorijum : IIzvestajRepozitorijum
    {
        private string lokacija;

        private static IzvestajRepozitorijum _instance;
        public ObservableCollection<Izvestaj> izvestaji;

        public static IzvestajRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IzvestajRepozitorijum();
                }
                return _instance;
            }
        }

        public IzvestajRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\izvestaj.json";
        }
        public bool Kreiraj()
        {
            // TODO: implement
            return false;
        }

        public bool Obrisi(Izvestaj izvestaj)
        {
            izvestaji.Remove(izvestaj);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, izvestaji);
            jWriter.Close();
            writer.Close();
            return true;
        }

        public Recept Dobavi()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Izvestaj> DobaviSve()
        {
            ObservableCollection<Izvestaj> izvestaji = new ObservableCollection<Izvestaj>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    izvestaji = JsonConvert.DeserializeObject<ObservableCollection<Izvestaj>>(jsonText);
                }
            }
            if (izvestaji != null)
            {
                this.izvestaji = new ObservableCollection<Izvestaj>(izvestaji);
            }
            return izvestaji;
        }

        public void Sacuvaj(ObservableCollection<Izvestaj> izvestaji)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, izvestaji);
            jWriter.Close();
            writer.Close();
        }

    }
}