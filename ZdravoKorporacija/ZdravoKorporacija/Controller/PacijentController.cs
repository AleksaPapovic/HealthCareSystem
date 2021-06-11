using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;

namespace ZdravoKorporacija.Controller
{
    public class PacijentController
    {
        private PacijentService servis;
        private PacijentKonverter pacijentKonverter = new PacijentKonverter();
        private NotifikacijaKonverter notifikacijaKonverter = new NotifikacijaKonverter();
        private static PacijentController _instance;
        PacijentService pacijentServis = PacijentService.Instance;
        public static PacijentController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PacijentController();
                }
                return _instance;
            }
        }

        public PacijentController()
        {
            this.servis = new PacijentService();
        }

        public PacijentDTO ulogovaniPacijent(string korisnickoIme, string lozinka)
        {
            Pacijent ulogovani = pacijentServis.dobaviUlogovanog(korisnickoIme, lozinka);
            return pacijentKonverter.KonvertujEntitetUDTO(ulogovani);
        }

        public void azurirajBanInfo(PacijentDTO pacijentDTO, int tipAktivnosti)
        {
            Pacijent pacijent = pacijentServis.pronadjiEntitetZaDTO(pacijentDTO);
            servis.azurirajBanInfo(pacijent, tipAktivnosti);
        }

        public Pacijent konvertujDTOuEntitet(PacijentDTO pDTO)
        {
            return (Pacijent)servis.PregledSvihPacijenata().FirstOrDefault(p =>
                p.Username.Equals(pDTO.korisnickoIme) && p.Password.Equals(pDTO.lozinka));
        }

        public Boolean pacijentJeBanovan(PacijentDTO pDTO)
        {
            return konvertujDTOuEntitet(pDTO).banovan;
        }

        public void provjeriStatus(PacijentDTO ulogovaniPacijent)
        {
            Pacijent pacijent = (Pacijent)servis.PregledSvihPacijenata()
                .FirstOrDefault(s => ulogovaniPacijent.korisnickoIme.Equals(s.Username));
            servis.provjeriStatus(pacijent);
        }

        public void dodajNotifikaciju(PacijentDTO ulogovaniPacijent)
        {
            Pacijent pacijent = (Pacijent)servis.PregledSvihPacijenata()
                .FirstOrDefault(s => ulogovaniPacijent.korisnickoIme.Equals(s.Username));

            pacijent.notifikacije.Clear();
            foreach (NotifikacijaDTO nDTO in ulogovaniPacijent.notifikacije)
                pacijent.notifikacije.Add(notifikacijaKonverter.KonvertujDTOuEntitet(nDTO));

            servis.AzurirajPacijenta(pacijent);
        }

        public PacijentPodaciDTO konvertujUPodaciDTO(PacijentDTO pacijentDTO)
        {
            Pacijent pacijent = servis.PregledSvihPacijenata().FirstOrDefault(p =>
                p.Username.Equals(pacijentDTO.korisnickoIme) && p.Password.Equals(pacijentDTO.lozinka));

            return new PacijentPodaciDTO(pacijent.Ime, pacijent.Prezime, pacijent.Jmbg, pacijent.BrojTelefona,
                pacijent.Mejl, pacijent.AdresaStanovanja, pacijent.Pol);
        }


        public bool IzdajRecept(PacijentDTO pacijent, ReceptDTO recept)
        {
            return pacijentServis.IzdajRecept(pacijent, recept);
        }
        public bool ObrisiRecept(PacijentDTO pacijent, ReceptDTO recept)
        {
            return pacijentServis.ObrisiRecept(pacijent, recept);
        }
        public List<PacijentDTO> PregledSvihPacijenata2()
        {
            return pacijentServis.PregledSvihPacijenata2();
        }
        public bool AzurirajPacijenta(PacijentDTO pacijent)
        {
            return pacijentServis.AzurirajPacijenta(pacijent);
        }
    }
}
