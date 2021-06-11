using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
    class ZahtevPremestanjaRepozitorijum
    {
        private string lokacija;

        private static ZahtevPremestanjaRepozitorijum _instance;
        public ObservableCollection<ZahtevPremestanja> zahtevi;
        public static ZahtevPremestanjaRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ZahtevPremestanjaRepozitorijum();
                }
                return _instance;
            }
        }

        private ZahtevPremestanjaRepozitorijum()
        {
            zahtevi = new ObservableCollection<ZahtevPremestanja>();
            this.lokacija = @"..\..\..\Data\zahteviPremestanje.json";
        }

        public void sacuvaj()
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


        public ObservableCollection<ZahtevPremestanja> dobaviSve()
        {
            List<ZahtevPremestanja> premestani = new List<ZahtevPremestanja>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    premestani = JsonConvert.DeserializeObject<List<ZahtevPremestanja>>(jsonText);
                }
            }
            if (premestani != null)
            {
                this.zahtevi = new ObservableCollection<ZahtevPremestanja>(premestani);
            }
            return this.zahtevi;
        }

    }
}
