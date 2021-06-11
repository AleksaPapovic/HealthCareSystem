using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
    class RenoviranjeRepozitorijum
    {
        private static RenoviranjeRepozitorijum _instance;
        public ObservableCollection<ZahtevRenoviranja> zahteviRenoviranja;
        string lokacija = @"..\..\..\Data\zahteviRenoviranja.json";
        public static RenoviranjeRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RenoviranjeRepozitorijum();

                }
                return _instance;
            }
        }

        private RenoviranjeRepozitorijum()
        {
            zahteviRenoviranja = new ObservableCollection<ZahtevRenoviranja>();
        }

        public int Sacuvaj()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, zahteviRenoviranja);
            jWriter.Close();
            writer.Close();
            return 1;
        }

        public ObservableCollection<ZahtevRenoviranja> dobaviSve()
        {
            List<ZahtevRenoviranja> renovirani= new List<ZahtevRenoviranja>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                   renovirani = JsonConvert.DeserializeObject<List<ZahtevRenoviranja>>(jsonText);
                }
            }
            if (renovirani != null)
            {
                this.zahteviRenoviranja = new ObservableCollection<ZahtevRenoviranja>(renovirani);
            }
            return this.zahteviRenoviranja;
        }

    }
}
