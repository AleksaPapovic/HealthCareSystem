using Model;
using Service;
using System;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Controller
{
    class NeodobreniLekController
    {
        NeodobreniLekService neodobreniLekService = new NeodobreniLekService();
        public bool DodajNeodobreniLek(ZahtevLek zahtevLek)
        {
            String kolicina = "" + zahtevLek.Lek.Kolicina;
            LekDTO lek = new LekDTO(zahtevLek.Lek.Id, zahtevLek.Lek.Proizvodjac, zahtevLek.Lek.Sastojci, zahtevLek.Lek.NusPojave, zahtevLek.Lek.NazivLeka, kolicina);
            ZahtevLekDTO zahtevZaNeodobreniLek = new ZahtevLekDTO(lek, zahtevLek.NeophodnihPotvrda, zahtevLek.BrojPotvrda,zahtevLek.Komentar);
            zahtevZaNeodobreniLek.lekari = zahtevLek.lekari;

            return this.neodobreniLekService.DodajNeodobreniZahtevLeka(zahtevZaNeodobreniLek);
        }

        public ObservableCollection<ZahtevLek> PregledNeodobrenihLekova()
        {
            return this.neodobreniLekService.PregledNeodobrenihLekova();
        }

        public ObservableCollection<ZahtevLekDTO> PregledNeodobrenihLekovaDTO()
        {
            return this.neodobreniLekService.PregledNeodobrenihLekovaDTO();
        }

        public bool obrisiNeodobreniLek(ZahtevLekDTO zahtev)
        {
            return this.neodobreniLekService.obrisiNeodobreniLek(zahtev);
        }
    }
}
