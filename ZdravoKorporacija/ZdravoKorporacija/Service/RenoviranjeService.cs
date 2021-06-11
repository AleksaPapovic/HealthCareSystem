using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Service;
using ZdravoKorporacija.Stranice.UpravnikCRUD;

namespace Service
{
    class RenoviranjeService
    {
        RenoviranjeRepozitorijum renoviranjeRepozitorijum = RenoviranjeRepozitorijum.Instance;
        ZahtevPremestanjaService zahtevP = new ZahtevPremestanjaService();
        ZahtevIzbacivanjaService zahtevI = new ZahtevIzbacivanjaService();
        public Boolean ZakaziRenoviranje(ZahtevRenoviranjeDTO zahtevRenoviranjaDTO)
        {


            String s = zahtevRenoviranjaDTO.PocetakDan.ToString();
            String date = s.Split(" ")[0];

            DateTime pocetak = DateTime.Parse(date + " " + zahtevRenoviranjaDTO.PocetakSati);

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRenoviranje");
            Dictionary<int, int> ids = datotekaID.dobaviSve();
            int zahtevId = nadjiSlobodanID(ids);
            ids[zahtevId] = 1;


            int minuta = 0;
            try { minuta = int.Parse(zahtevRenoviranjaDTO.Trajanje); }
            catch (Exception)
            {
            }
            zahtevRenoviranjaDTO.PocetakDan = pocetak;
            DateTime kraj = pocetak.AddMinutes(minuta);

            zahtevRenoviranjaDTO.Id = zahtevId;
            zahtevRenoviranjaDTO.Kraj = kraj;
            ZahtevRenoviranja zahtev = new ZahtevRenoviranja(zahtevRenoviranjaDTO);
            List<StatickaOprema> oprema = zahtev.Prostorija.statickaOprema;

            if (oprema != null)
            {
                foreach (StatickaOprema statickaOprema in oprema)
                {
                    InventarDTO inventar = (InventarDTO)statickaOprema;
                    ZahtevPremestanjaDTO zp = new ZahtevPremestanjaDTO();
                    zp.prostorija = new ProstorijaDTO(zahtev.Prostorija);
                    ZahtevIzbacivanja zi = new ZahtevIzbacivanja();
                    zi.prostorija = zahtev.Prostorija;
                    zp.Pocetak = zahtevRenoviranjaDTO.PocetakDan;
                    zi.Pocetak = zahtevRenoviranjaDTO.PocetakDan;

                    zahtevI.ZakaziIzbacivanje(inventar, zi, zahtevRenoviranjaDTO.PocetakSati, zahtevRenoviranjaDTO.Trajanje);
                    zahtevP.ZakaziPremestanje(inventar, zp, zahtevRenoviranjaDTO.PocetakSati, zahtevRenoviranjaDTO.Trajanje);
                }
            }

            renoviranjeRepozitorijum.zahteviRenoviranja.Add(zahtev);
            renoviranjeRepozitorijum.Sacuvaj();
            datotekaID.sacuvaj(ids);

            return true;
        }

        public bool ObrisiZahtevRenoviranja(ZahtevRenoviranjeDTO renoviranjeZahtevDTO)
        {
            ZahtevRenoviranja zahtevRenoviranja = new ZahtevRenoviranja(renoviranjeZahtevDTO);
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRenoviranja");
            Dictionary<int, int> id_map = datotekaID.dobaviSve();
            id_map[renoviranjeZahtevDTO.Id] = 0;



            foreach (ZahtevRenoviranja zahtev in renoviranjeRepozitorijum.dobaviSve())
            {
                if (zahtev.Id == zahtevRenoviranja.Id)
                {
                    RenoviranjeRepozitorijum.Instance.zahteviRenoviranja.Remove(zahtev);
                    renoviranjeRepozitorijum.Sacuvaj();
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
    } 
    

        public ObservableCollection<ZahtevRenoviranjeDTO> pregledSvihZahtevaRenoviranjaDTO()
        {
          
                ObservableCollection<ZahtevRenoviranja> zahteviRenoviranja = renoviranjeRepozitorijum.dobaviSve();
                ObservableCollection<ZahtevRenoviranjeDTO> zahteviRenoviranjaDTO = new ObservableCollection<ZahtevRenoviranjeDTO>();
                foreach (ZahtevRenoviranja zahtev in zahteviRenoviranja)
                {
                zahteviRenoviranjaDTO.Add(konvertujEntitetUDTO(zahtev));
                }
                return zahteviRenoviranjaDTO;
        }

        public ZahtevRenoviranjeDTO konvertujEntitetUDTO(ZahtevRenoviranja zahtevPremestanja)
        {
            return new ZahtevRenoviranjeDTO(zahtevPremestanja);
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

        public List<Prostorija> konvertujListuProstorijaDTOUListuProstorija(List<ProstorijaDTO> prostorijeDTO)
        {
            List<Prostorija> prostorije = new List<Prostorija>();
            if (prostorijeDTO != null)
            {

                foreach (ProstorijaDTO prostorijaDTO in prostorijeDTO)
                {
                    prostorije.Add(new Prostorija(prostorijaDTO));
                }

            }
            return prostorije;
        }

    }
}
