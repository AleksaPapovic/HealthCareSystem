using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
    class NeodobreniLekRepository
    {
        private static NeodobreniLekRepository _instance;
        public ObservableCollection<ZahtevLek> neodobreniLekovi;
        public static NeodobreniLekRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NeodobreniLekRepository();

                }
                return _instance;
            }
        }

        private NeodobreniLekRepository()
        {
            neodobreniLekovi = new ObservableCollection<ZahtevLek>();
        }

        public string lokacija = @"..\..\..\Data\neodobreniLekovi.json";
        public void sacuvaj()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, neodobreniLekovi);
            jWriter.Close();
            writer.Close();
        }
        public ObservableCollection<ZahtevLek> dobaviSve()
        {
            string lokacija = @"..\..\..\Data\neodobreniLekovi.json";
            List<ZahtevLek> ucitaniNeodobreniLekovi = new List<ZahtevLek>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    ucitaniNeodobreniLekovi = JsonConvert.DeserializeObject<List<ZahtevLek>>(jsonText);
                }
            }
            if (ucitaniNeodobreniLekovi != null)
            {
                neodobreniLekovi = new ObservableCollection<ZahtevLek>(ucitaniNeodobreniLekovi);
            }
            return neodobreniLekovi;
        }

    }
}
