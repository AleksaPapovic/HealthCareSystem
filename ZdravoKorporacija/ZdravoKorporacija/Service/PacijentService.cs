using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;
using System;
using System.Diagnostics;
using ZdravoKorporacija.Service;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;

namespace Service
{
    public class PacijentService
    {
        private PacijentRepozitorijum pacRepo = new PacijentRepozitorijum();
        private ZdravstveniKartonServis zks = new ZdravstveniKartonServis();
        public Pacijent NadjiPacijentaPoJMBG(long jmbg)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(jmbg))
                {
                    return p;
                }
            }
            return null;
        }
    
        public void azurirajBanInfo(Pacijent pacijent, int tipAktivnosti)
        {
            Ban b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);
            switch (tipAktivnosti)
            {
                case 0:
                    b.zakazanCnt++;
                    break;
                case 1:
                    b.pomerenCnt++;
                    break;
                case 2:
                    b.otkazanCnt++;
                    break;
                default:
                    break;
            }

            BanRepozitorijum.Instance.sacuvaj(b);
        }

        public PacijentDTO NadjiPacijentaPoJMBGDTO(long jmbg)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(jmbg))
                {
                    return Model2DTO(p);
                }
            }
            return null;
        }

        private static PacijentService _instance;

        public static PacijentService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PacijentService();
                }
                return _instance;
            }
        }

        PacijentRepozitorijum pr = PacijentRepozitorijum.Instance;
        ReceptServis rs = ReceptServis.Instance;

        public bool IzdajRecept(PacijentDTO pacijent, ReceptDTO recept)
        {
            rs.DodajRecept(recept);
            Pacijent p = new Pacijent(pacijent);
            p.ZdravstveniKarton.recept.Add(new Recept(recept));
            AzurirajPacijenta(p);
            return true;
        }

        public bool ObrisiRecept(PacijentDTO pacijent, ReceptDTO recept)
        {
            Pacijent p = new Pacijent(pacijent);
            foreach (Recept rec in p.ZdravstveniKarton.recept.ToArray())
            {
                if (recept.Id.Equals(rec.Id))
                    p.ZdravstveniKarton.recept.Remove(rec);
            }
            AzurirajPacijenta(p);
            rs.ObrisiRecept(recept);
            return true;
        }

        public bool KreirajNalogPacijentu(Pacijent pacijent)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent))
                {
                    return false;
                }
            }
            pacijenti.Add(pacijent);
            datoteka.sacuvaj(pacijenti);
            return true;
        }

        public bool ObrisiNalogPacijentu(Pacijent pacijent)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent.Jmbg))
                {
                    pacijenti.Remove(p);
                    datoteka.sacuvaj(pacijenti);
                    return true;
                }
            }
            return false;
        }

        public bool ObrisiTerminPacijentu(Termin termin)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.ZdravstveniKarton == null)
                    break;
                if (termin.zdravstveniKarton == null)
                    break;
                if (p.ZdravstveniKarton.Id.Equals(termin.zdravstveniKarton.Id))
                {
                    if (p.termin == null)
                        p.termin = new List<Termin>();
                    foreach (Termin t in p.termin.ToArray())
                    {
                        if (t.Id.Equals(termin.Id))
                            p.termin.Remove(t);
                    }
                    datoteka.sacuvaj(pacijenti);
                    return true;
                }
            }
            return false;
        }

        public bool ObrisiObavestenjePacijentu(string not)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                foreach (Notifikacija n in p.notifikacije.ToList())
                {
                    if (n != null)
                        if (n.Sadrzaj.Equals(not))
                        {
                            p.notifikacije.Remove(n);
                        }
                }
                datoteka.sacuvaj(pacijenti);


            }
            return true;
        }

        public bool AzurirajPacijenta(Pacijent pacijent)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            if (pacijent != null)
                foreach (Pacijent p in pacijenti)
                {
                    if (p.Jmbg.Equals(pacijent.Jmbg))
                    {
                        pacijenti.Remove(p);
                        pacijenti.Add(pacijent);
                        datoteka.sacuvaj(pacijenti);
                        return true;
                    }
                }
            return false;
        }

        public bool AzurirajPacijenta(PacijentDTO pacijent)
        {
            List<Pacijent> pacijenti = pr.dobaviSve2();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent.Jmbg))
                {
                    pacijenti.Remove(p);
                    pacijenti.Add(new Pacijent(pacijent));
                    pr.sacuvaj(pacijenti);
                    return true;
                }
            }
            return false;
        }

        public Pacijent PregledPacijenta(long jmbg)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Ime.Equals(jmbg))
                {
                    return p;
                }
            }
            return null;
        }

        public List<PacijentDTO> PregledSvihPacijenata2()
        {
            PacijentKonverter pacijentKonverter = new PacijentKonverter();
            List<Pacijent> pacijenti = pr.dobaviSve2();
            List<PacijentDTO> pacijentiDTO = new List<PacijentDTO>();
            foreach (Pacijent pacijent in pacijenti)
            {
                pacijentiDTO.Add(pacijentKonverter.KonvertujEntitetUDTO(pacijent));
            }
            return pacijentiDTO;
        }

        public List<Pacijent> PregledSvihPacijenata()
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();

            List<Pacijent> pacijenti = datoteka.dobaviSve();
            return pacijenti;
        }

        public List<Pacijent> PregledSvihPacijenata2Model(List<PacijentDTO> dtos)
        {

            List<Pacijent> modeli = new List<Pacijent>();
            foreach (PacijentDTO pdto in dtos)
                modeli.Add(DTO2Model(pdto));
            return modeli;
        }
        public List<PacijentDTO> PregledSvihPacijenata2DTO()
        {
            List<Pacijent> modeli = new List<Pacijent>();
            modeli = PregledSvihPacijenata();
            List<PacijentDTO> dtos = new List<PacijentDTO>();
            foreach (Pacijent model in modeli)
            {
                dtos.Add(Model2DTO(model));
            }
            return dtos;
        }

        public PacijentDTO Model2DTO(Pacijent model)
        {
            ZdravstveniKartonServis zks = new ZdravstveniKartonServis();
            ZdravstveniKartonDTO kartonDTO = zks.Model2DTO(model.ZdravstveniKarton);
            PacijentDTO dto = new PacijentDTO(kartonDTO, model.Guest, model.Ime, model.Prezime, model.Jmbg, model.BrojTelefona, model.Mejl, model.AdresaStanovanja, model.Pol, model.Username, model.Password);
            return dto;
        }

        public Pacijent DTO2Model(PacijentDTO dto)
        {

            foreach (Pacijent p in PregledSvihPacijenata())
            {
                if (p.Password.Equals(dto.Password))
                    return p;
            }
            return null;
        }
        public void DodajTermin(Pacijent p, Termin t)
        {
            ZdravstveniKarton zk;
            if (p.ZdravstveniKarton == null)
            {
                zk = new ZdravstveniKarton(p, p.Jmbg, StanjePacijentaEnum.None, "", KrvnaGrupaEnum.None, "");
                p.ZdravstveniKarton = zk;
            }
            if (p.termin == null)
                p.termin = new List<Termin>();
            p.termin.Add(t);
        }
        public Pacijent DTO2ModelNapravi(PacijentDTO dto)
        {
            Pacijent model = new Pacijent(dto.Ime, dto.Prezime, dto.Jmbg, dto.BrojTelefona, dto.Mejl, dto.AdresaStanovanja, dto.Pol, dto.Username, dto.Password);
            model.ZdravstveniKarton = zks.findById(dto.Jmbg);
            return model;

        }

        public void AddTermin(PacijentDTO pacijentDTO, TerminDTO terminDTO)
        {
            TerminService ts = new TerminService();
            Termin noviTermin = ts.DTO2Model(terminDTO);
            if (terminDTO == null)
                return;
            foreach (Pacijent pacijent in PregledSvihPacijenata())
            {
                if (pacijent.Jmbg.Equals(pacijentDTO.Jmbg))
                    if (pacijent.termin == null)
                    {
                        pacijent.termin = new List<Termin>();
                        pacijent.termin.Add(noviTermin);
                    }
                if (!pacijent.termin.Contains(noviTermin))
                    pacijent.termin.Add(noviTermin);
            }
        }

        public Pacijent dobaviUlogovanog(string imeTextText, string lozinkaTextPassword)
        {
            return (Pacijent)pacRepo.dobaviSve()
                .FirstOrDefault(p => p.Username.Equals(imeTextText) && p.Password.Equals(lozinkaTextPassword));
        }

        public void provjeriStatus(Pacijent pacijent)
        {
            Ban b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);

            if (b.otkazanCnt >= 3 || b.zakazanCnt >= 3 || b.pomerenCnt >= 3)
            {
                pacijent.banovan = true;
                b.trenutakBanovanja = DateTime.Now.ToString();

                b.otkazanCnt = 0;
                b.pomerenCnt = 0;
                b.zakazanCnt = 0;
            }

            // DateTime.Compare(DateTime.Now, DateTime.Parse(b.trenutakBanovanja).AddMinutes(3)) >= 0
            if (pacijent.banovan && DateTime.Compare(DateTime.Now, DateTime.Parse(b.trenutakBanovanja).AddMinutes(3)) >= 0)
            {
                pacijent.banovan = false;
            }

            this.AzurirajPacijenta(pacijent);
            BanRepozitorijum.Instance.sacuvaj(b);

        }

        public Pacijent pronadjiEntitetZaDTO(PacijentDTO dto)
        {
            return pacRepo.dobaviSve()
                .FirstOrDefault(p => p.Username.Equals(dto.korisnickoIme) && p.Password.Equals(dto.lozinka));

        }

    }
}