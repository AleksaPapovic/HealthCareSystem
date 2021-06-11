using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
    public class BanRepozitorijum
    {
        private static BanRepozitorijum _instance;
        public ObservableCollection<Ban> bans;
        public Ban ban;
        private PacijentRepozitorijum pacRepo = new PacijentRepozitorijum();

        public static BanRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BanRepozitorijum();
                }
                return _instance;
            }
        }

        private BanRepozitorijum()
        {
            bans = new ObservableCollection<Ban>();
            ban = new Ban();
        }


        public void sacuvaj(Ban noviBan)
        {
            List<Ban> x = new List<Ban>(bans);
            foreach (Ban b in x)
            {
                if (b.idKorisnika.Equals(noviBan.idKorisnika))
                {
                    bans.Remove(b);
                    bans.Add(noviBan);
                }
            }

            string lokacija = @"..\..\..\Data\banInfo.json";
            JsonSerializer serializer = new JsonSerializer();
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, bans);
            jWriter.Close();
            writer.Close();
        }

        public Ban dobavi(long id)
        {
            Ban retBan = new Ban();
            foreach (Ban b in bans)
            {
                if (b.idKorisnika.Equals(id))
                {
                    retBan = b;
                }
            }
            return retBan;
        }

        public List<Ban> dobaviSve()
        {
            string lokacija = @"..\..\..\Data\banInfo.json";
            List<Ban> banovi = new List<Ban>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    banovi = JsonConvert.DeserializeObject<List<Ban>>(jsonText);
                }
            }
            if (banovi != null)
            {
                bans = new ObservableCollection<Ban>(banovi);
            }
            return banovi;
        }
    }
}
