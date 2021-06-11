using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using ZdravoKorporacija.DTO;

namespace Repository
{
    public class KorisnikRepozitorijum
    {


        private static KorisnikRepozitorijum _instance;
        public ObservableCollection<Korisnik> korisnici;
        public ObservableCollection<KorisnikDTO> korisniciDTO;
        public static KorisnikRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KorisnikRepozitorijum();

                }
                return _instance;
            }
        }

        private KorisnikRepozitorijum()
        {
            korisnici = new ObservableCollection<Korisnik>();
        }
        public bool Kreiraj(Korisnik k)
        {
            // TODO: implement
            return false;
        }

        public bool Obrisi(int id)
        {
            // TODO: implement
            return false;
        }

        public Korisnik Dobavi()
        {
            // TODO: implement
            return null;
        }

        public List<Korisnik> DobaviSve()
        {
            string lokacija = @"..\..\..\Data\korisnici.json";
            List<Korisnik> ucitaniKorisnici = new List<Korisnik>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    ucitaniKorisnici = JsonConvert.DeserializeObject<List<Korisnik>>(jsonText);
                }
            }
            if (ucitaniKorisnici != null)
            {
                korisnici = new ObservableCollection<Korisnik>(ucitaniKorisnici);
            }
            return ucitaniKorisnici;
        }


        public List<KorisnikDTO> DobaviSveDTO()
        {
            string lokacija = @"..\..\..\Data\korisnici.json";
            List<KorisnikDTO> ucitaniKorisnici = new List<KorisnikDTO>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    ucitaniKorisnici = JsonConvert.DeserializeObject<List<KorisnikDTO>>(jsonText);
                }
            }
            if (ucitaniKorisnici != null)
            {
                korisniciDTO = new ObservableCollection<KorisnikDTO>(ucitaniKorisnici);
            }
            return ucitaniKorisnici;
        }



        public bool Sacuvaj()
        {
            string lokacija = @"..\..\..\Data\korisnici.json";
            JsonSerializer serializer = new JsonSerializer();
            //serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, korisnici);
            jWriter.Close();
            writer.Close();
            return true;
        }

    }
}
