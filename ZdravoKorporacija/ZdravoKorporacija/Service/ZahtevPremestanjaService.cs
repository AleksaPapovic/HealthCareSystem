using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Service
{
    class ZahtevPremestanjaService
    {
        ZahtevPremestanjaRepozitorijum datoteka = ZahtevPremestanjaRepozitorijum.Instance;
        public bool ZakaziPremestanje(InventarDTO inventarDTO, ZahtevPremestanjaDTO zahtevPremestanjaDTO, string sati, string trajanje)
        {
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZahtevPremestanja");
            Dictionary<int, int> ids = datotekaID.dobaviSve();

            int id = nadjiSlobodanID(ids);
            ids[id] = 1;

            ZahtevPremestanja zahtevPremestanja = new ZahtevPremestanja(zahtevPremestanjaDTO);
            Inventar inventar = new Inventar(inventarDTO);

            zahtevPremestanja.Id = id;
            zahtevPremestanja.StatickaOprema = new StatickaOprema(inventar);
            StatickaOprema stat = new StatickaOprema(inventar);
            zahtevPremestanja.prostorija.statickaOprema = new List<StatickaOprema>();
            zahtevPremestanja.prostorija.statickaOprema.Add(stat);

            String s = zahtevPremestanjaDTO.Pocetak.ToString();
            String date = s.Split(" ")[0];

            DateTime datum = DateTime.Parse(date + " " + sati);
            zahtevPremestanja.Pocetak = datum;
            int minuta = 0;
            try { minuta = int.Parse(trajanje); }
            catch (Exception)
            {
            }
            zahtevPremestanja.Kraj = zahtevPremestanja.Pocetak.AddMinutes(minuta);

            ZahtevPremestanjaRepozitorijum.Instance.zahtevi.Add(zahtevPremestanja);
            datoteka.sacuvaj();
            datotekaID.sacuvaj(ids);

            return true;
        }

        public ObservableCollection<ZahtevPremestanja> PregledSveOpreme()
        {
            ZahtevPremestanjaRepozitorijum zpr = ZahtevPremestanjaRepozitorijum.Instance;
            return zpr.dobaviSve();
        }

        public ObservableCollection<ZahtevPremestanjaDTO> PregledSveOpremeDTO()
        {
            ObservableCollection<ZahtevPremestanja> zahteviLek = datoteka.dobaviSve();
            ObservableCollection<ZahtevPremestanjaDTO> zahteviLekDTO = new ObservableCollection<ZahtevPremestanjaDTO>();
            foreach (ZahtevPremestanja zahtev in zahteviLek)
            {
                zahteviLekDTO.Add(konvertujEntitetUDTO(zahtev));
            }
            return zahteviLekDTO;

        }

        public ZahtevPremestanjaDTO konvertujEntitetUDTO(ZahtevPremestanja zahtevPremestanja)
        {
            return new ZahtevPremestanjaDTO(zahtevPremestanja);
        }

        private int nadjiSlobodanID(Dictionary<int, int> id_map)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    return id;
                }
            }
            return id;
        }

        public bool ObrisiZahtevPremestanja(ZahtevPremestanjaDTO zahtevPremestanjaDTO)
        {
            ZahtevPremestanja zahtevPremestanja = new ZahtevPremestanja(zahtevPremestanjaDTO);
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZahtevPremestanja");
            Dictionary<int, int> id_map = datotekaID.dobaviSve();
            id_map[zahtevPremestanja.Id] = 0;



            foreach (ZahtevPremestanja zahtev in datoteka.dobaviSve())
            {
                if (zahtev.Id == zahtevPremestanja.Id)
                {
                    ZahtevPremestanjaRepozitorijum.Instance.zahtevi.Remove(zahtev);
                    datoteka.sacuvaj();
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }
    }
}
