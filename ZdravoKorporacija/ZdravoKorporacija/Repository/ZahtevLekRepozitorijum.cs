using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ZdravoKorporacija.Repository
{
    class ZahtevLekRepozitorijum
    {

        private static ZahtevLekRepozitorijum _instance;
        public ObservableCollection<ZahtevLek> zahteviLek;
        public static ZahtevLekRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ZahtevLekRepozitorijum();

                }
                return _instance;
            }
        }

        private ZahtevLekRepozitorijum()
        {
            zahteviLek = new ObservableCollection<ZahtevLek>();
        }



        public void sacuvaj()
        {
            string lokacija = @"..\..\..\Data\zahteviZaLekove.json";
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, zahteviLek);
            jWriter.Close();
            writer.Close();
        }
        public List<ZahtevLek> dobaviSve()
        {
            string lokacija = @"..\..\..\Data\zahteviZaLekove.json";
            List<ZahtevLek> zahtevi = new List<ZahtevLek>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    zahtevi = JsonConvert.DeserializeObject<List<ZahtevLek>>(jsonText);
                }
            }
            if (zahtevi != null)
            {
                zahteviLek = new ObservableCollection<ZahtevLek>(zahtevi);
            }
            return zahtevi;
        }

    }
}
