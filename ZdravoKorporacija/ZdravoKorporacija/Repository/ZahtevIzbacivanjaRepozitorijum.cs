using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ZdravoKorporacija.Repository
{
    class ZahtevIzbacivanjaRepozitorijum
    {
        private string lokacija;

        private static ZahtevIzbacivanjaRepozitorijum _instance;
        public ObservableCollection<ZahtevIzbacivanja> zahtevi;
        public static ZahtevIzbacivanjaRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ZahtevIzbacivanjaRepozitorijum();

                }
                return _instance;
            }
        }

        private ZahtevIzbacivanjaRepozitorijum()
        {
            zahtevi = new ObservableCollection<ZahtevIzbacivanja>();
            this.lokacija = @"..\..\..\Data\zahteviIzbacivanja.json";
        }

        public void sacuvaj(List<ZahtevIzbacivanja> zahtevi)
        {
            JsonSerializer serializer = new JsonSerializer();
            //serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, zahtevi);
            jWriter.Close();
            writer.Close();
        }


        public List<ZahtevIzbacivanja> dobaviSve()
        {
            List<ZahtevIzbacivanja> premestani = new List<ZahtevIzbacivanja>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    premestani = JsonConvert.DeserializeObject<List<ZahtevIzbacivanja>>(jsonText);
                }
            }
            if (premestani != null)
            {
                this.zahtevi = new ObservableCollection<ZahtevIzbacivanja>(premestani);
            }
            return premestani;
        }

    }
}

