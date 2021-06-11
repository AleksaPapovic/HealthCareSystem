using Model;
using Repository;
using System;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Repository;

namespace Service
{
    class ZahtevIzbacivanjaService
    {
        public bool ZakaziIzbacivanje(InventarDTO inventarDTO, ZahtevIzbacivanja zahtevIzabacivanja, string sati, string trajanje)
        {
            ZahtevIzbacivanjaRepozitorijum datoteka = ZahtevIzbacivanjaRepozitorijum.Instance;
            List<ZahtevIzbacivanja> zahtevi = datoteka.dobaviSve();
            IDRepozitorijum datotekaIDIzbacivanja = new IDRepozitorijum("iDMapZahtevIzbacivanja");
            Dictionary<int, int> id_map = datotekaIDIzbacivanja.dobaviSve();
            DateTime dt = zahtevIzabacivanja.Pocetak;
            int id = nadjiSlobodanID(id_map);
            id_map[id] = 1;


            zahtevIzabacivanja.Id = id;
            Inventar inventar = new Inventar(inventarDTO);

            zahtevIzabacivanja.StatickaOprema = new StatickaOprema(inventar);
            StatickaOprema stat = new StatickaOprema(inventar);
            zahtevIzabacivanja.prostorija.statickaOprema = new List<StatickaOprema>();
            zahtevIzabacivanja.prostorija.statickaOprema.Add(stat);

            String s = dt.ToString();
            String date = s.Split(" ")[0];

            DateTime datum = DateTime.Parse(date + " " + sati);
            zahtevIzabacivanja.Pocetak = datum;
            int minuta = 0;
            try { minuta = int.Parse(trajanje); }
            catch (Exception)
            {
            }
            zahtevIzabacivanja.Kraj = zahtevIzabacivanja.Pocetak.AddMinutes(minuta);

            zahtevi.Add(zahtevIzabacivanja);
            datoteka.sacuvaj(zahtevi);
            datotekaIDIzbacivanja.sacuvaj(id_map);

            return true;
        }



        public List<ZahtevIzbacivanja> PregledSvihZahtevaIzbacivanja()
        {
            ZahtevIzbacivanjaRepozitorijum zpr = ZahtevIzbacivanjaRepozitorijum.Instance;
            return zpr.dobaviSve();
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
    }
}
