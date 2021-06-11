using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Service
{
    class NeodobreniLekService
    {
        private NeodobreniLekRepository datoteka = NeodobreniLekRepository.Instance;
        public bool DodajNeodobreniZahtevLeka(ZahtevLekDTO zahtevLek)
        {
            ObservableCollection<ZahtevLek> zahteviNeodobreniLekovi = NeodobreniLekRepository.Instance.neodobreniLekovi;
            IDRepozitorijum datotekaNeodobreniId = new IDRepozitorijum("iDMapNeodobreniLek");
            Dictionary<int, int> id_map = datotekaNeodobreniId.dobaviSve();

            int id = nadjiSlobodanID(id_map);
            id_map[id] = 1;

            Double kolicina = Double.Parse(zahtevLek.Lek.Kolicina);
            Lek lek = new Lek(zahtevLek.Lek.Id, zahtevLek.Lek.Proizvodjac, zahtevLek.Lek.Sastojci, zahtevLek.Lek.NusPojave, zahtevLek.Lek.NazivLeka,kolicina);
            ZahtevLek zahtevZaNeodobreniLek = new ZahtevLek(lek, zahtevLek.NeophodnihPotvrda, zahtevLek.BrojPotvrda,zahtevLek.Komentar);

            foreach (LekDTO lekD in zahtevLek.Lek.alternativniLekovi)
            {
                Double kolicinaAlternativnih = Double.Parse(zahtevLek.Lek.Kolicina);
                Lek l = new Lek(lekD.Id, lekD.NusPojave, lekD.Sastojci, lekD.NusPojave, lekD.NazivLeka,kolicina);
                zahtevZaNeodobreniLek.Lek.alternativniLekovi.Add(l);
            }

            zahtevZaNeodobreniLek.Setlekari(zahtevLek.lekari);
            zahtevZaNeodobreniLek.Id = id;

            NeodobreniLekRepository.Instance.neodobreniLekovi.Add(zahtevZaNeodobreniLek);
            this.datoteka.sacuvaj();
            datotekaNeodobreniId.sacuvaj(id_map);
            return true;
        }

        public bool obrisiNeodobreniLek(ZahtevLekDTO selektovaniZahtevDTO)
        {
            ZahtevLek selektovaniZahtevLek = new ZahtevLek(selektovaniZahtevDTO);
            NeodobreniLekRepository datoteka = NeodobreniLekRepository.Instance;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapNeodobreniLek");
            Dictionary<int, int> id_map = datotekaID.dobaviSve();
            id_map[selektovaniZahtevLek.Id] = 0;

            foreach (ZahtevLek zahtev in NeodobreniLekRepository.Instance.neodobreniLekovi)
            {
                if (zahtev.Id == selektovaniZahtevLek.Id)
                {
                    NeodobreniLekRepository.Instance.neodobreniLekovi.Remove(zahtev);
                    datoteka.sacuvaj();
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }

        public ObservableCollection<ZahtevLek> PregledNeodobrenihLekova()
        {
            return this.datoteka.dobaviSve();
        }

        public ObservableCollection<ZahtevLekDTO> PregledNeodobrenihLekovaDTO()
        {
            ObservableCollection<ZahtevLek> zahteviLek = datoteka.dobaviSve();
            ObservableCollection<ZahtevLekDTO> zahteviLekDTO = new ObservableCollection<ZahtevLekDTO>();
            foreach (ZahtevLek zahtev in zahteviLek)
            {
                zahteviLekDTO.Add(konvertujEntitetUDTO(zahtev));
            }
            return zahteviLekDTO;

        }

        public ZahtevLekDTO konvertujEntitetUDTO(ZahtevLek zahtevLek)
        {
            return new ZahtevLekDTO(zahtevLek);
        }

        public bool AzurirajZahtev(int indeks, ZahtevLekDTO zahtevLekDTO)
        {
            ZahtevLek zahtevLek = new ZahtevLek(zahtevLekDTO);

            NeodobreniLekRepository datoteka = NeodobreniLekRepository.Instance;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapNeodobreniLek");

            foreach (ZahtevLek zahtevNeodobreniLek in NeodobreniLekRepository.Instance.neodobreniLekovi)
            {
                if (zahtevNeodobreniLek.Id.Equals(zahtevLek.Id))
                {
                    NeodobreniLekRepository.Instance.neodobreniLekovi.RemoveAt(indeks);
                    NeodobreniLekRepository.Instance.neodobreniLekovi.Insert(indeks, zahtevLek);
                    datoteka.sacuvaj();
                    return true;
                }
            }
            return false;
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
