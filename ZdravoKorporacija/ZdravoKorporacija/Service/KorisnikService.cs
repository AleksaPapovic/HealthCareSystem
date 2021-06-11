using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using ZdravoKorporacija.DTO;

namespace Service
{
    class KorisnikService
    {
        KorisnikRepozitorijum kr = KorisnikRepozitorijum.Instance;
        private PacijentService pacServis = new PacijentService();
        public Ban b;
        List<Ban> nepotrebna = BanRepozitorijum.Instance.dobaviSve(); //set bans

        //public bool DodajKorisnika(string ime, string sifra, UlogaEnum uloga)
        public bool DodajKorisnika(string ime, string sifra)
        {
            Korisnik k = new Korisnik();
            k.Username = ime;
            k.Password = sifra;
            //default pacijent !!! test samo
            //k.Uloga = UlogaEnum.Pacijent;
            //  ObservableCollection<Korisnik> korisnici = KorisnikRepozitorijum.Instance.korisnici;
            //  korisnici.Add(k);
            //  kr.Sacuvaj()

            kr.korisnici.Add(k);
            kr.Sacuvaj();

            return false;
        }
            public KorisnikDTO Uloguj(UlogaEnum uloga, string ime, string sifra)
        {
         
            KorisnikDTO unos = new KorisnikDTO();
            unos.Username = ime;
            unos.Password = sifra;


            if (uloga == UlogaEnum.Upravnik)
            {
                ObservableCollection<KorisnikDTO> lista = new ObservableCollection<KorisnikDTO>(kr.DobaviSveDTO());
                KorisnikDTO upravnik = (KorisnikDTO)lista.FirstOrDefault(s => s.Username.Equals(unos.Username));
                if (upravnik != null)
                {
                    KorisnikDTO ulogovani = (KorisnikDTO)lista.FirstOrDefault(s => (s.Username.Equals(unos.Username) && s.Password.Equals(unos.Password)));
                    if (ulogovani != null)
                    {
                        return ulogovani;
                    }
                    else
                    {
                        MessageBox.Show("Pogrešna šifra", "Greška");
                        return null;
                    }


                }
                else
                {
                    MessageBox.Show("Pogrešno korisničko ime", "Greška");
                    return null;
                }
            }

            if (uloga == UlogaEnum.Pacijent)
            {
                ObservableCollection<KorisnikDTO> lista = new ObservableCollection<KorisnikDTO>(kr.DobaviSveDTO());
                KorisnikDTO pacijent = (KorisnikDTO)lista.FirstOrDefault(s => s.Username.Equals(unos.Username));
                if (pacijent != null)
                {
                    return pacijent;
                }
            }

            if (uloga == UlogaEnum.Lekar)
            {
                ObservableCollection<KorisnikDTO> lista = new ObservableCollection<KorisnikDTO>(kr.DobaviSveDTO());
                KorisnikDTO lekar = (KorisnikDTO)lista.FirstOrDefault(s => s.Username.Equals(unos.Username));
                if (lekar != null)
                {
                    KorisnikDTO ulogovani = (KorisnikDTO)lista.FirstOrDefault(s => (s.Username.Equals(unos.Username) && s.Password.Equals(unos.Password)));
                    if (ulogovani != null)
                    {
                        return ulogovani;
                    }
                    else
                    {
                        MessageBox.Show("Pogresna sifra", "Greska");
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show("Pogresno korisnicko ime", "Greska");
                    return null;
                }
            }

            if (uloga == UlogaEnum.Sekretar)
            {
                ObservableCollection<KorisnikDTO> lista = new ObservableCollection<KorisnikDTO>(kr.DobaviSveDTO());
                KorisnikDTO sekretar = (KorisnikDTO)lista.FirstOrDefault(s => s.Username.Equals(unos.Username));
                if (sekretar != null)
                {
                    return sekretar;
                }
            }



            return null;
        }

        public KorisnikDTO Uloguj2(UlogaEnum uloga, string ime, string sifra)
        {

            KorisnikDTO unos = new KorisnikDTO();
            unos.Username = ime;
            unos.Password = sifra;


            if (uloga == UlogaEnum.Upravnik)
            {
                List<Korisnik> lista = new List<Korisnik>(kr.DobaviSve());
                KorisnikDTO upravnik = new KorisnikDTO(lista.FirstOrDefault(s => s.Username.Equals(unos.Username)));
                if (upravnik != null)
                {
                    KorisnikDTO ulogovani = new KorisnikDTO(lista.FirstOrDefault(s => (s.Username.Equals(unos.Username) && s.Password.Equals(unos.Password))));
                    if (ulogovani != null)
                    {
                        return ulogovani;
                    }
                    else
                    {
                        MessageBox.Show("Pogrešna šifra", "Greška");
                        return null;
                    }


                }
                else
                {
                    MessageBox.Show("Pogrešno korisničko ime", "Greška");
                    return null;
                }
            }

            if (uloga == UlogaEnum.Pacijent)
            {
                List<Korisnik> lista = new List<Korisnik>(kr.DobaviSve());
                KorisnikDTO pacijent = new KorisnikDTO(lista.FirstOrDefault(s => s.Username.Equals(unos.Username)));
                if (pacijent != null)
                {
                    return pacijent;
                }
            }

            if (uloga == UlogaEnum.Lekar)
            {
                List<Korisnik> lista = new List<Korisnik>(kr.DobaviSve());
                KorisnikDTO lekar = new KorisnikDTO(lista.FirstOrDefault(s => s.Username.Equals(unos.Username)));
                 if (lekar != null)
                {
                    Korisnik ulogovani = (Korisnik)lista.FirstOrDefault(s => (s.Username.Equals(unos.Username) && s.Password.Equals(unos.Password)));
                    KorisnikDTO k = new KorisnikDTO(ulogovani);
                    if (ulogovani != null)
                    {
                        return k;
                    }
                    else
                    {
                        MessageBox.Show("Pogresna sifra", "Greska");
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show("Pogresno korisnicko ime", "Greska");
                    return null;
                }
            }

            if (uloga == UlogaEnum.Sekretar)
            {
                List<Korisnik> lista = new List<Korisnik>(kr.DobaviSve());
                KorisnikDTO sekretar = new KorisnikDTO(lista.FirstOrDefault(s => s.Username.Equals(unos.Username)));
                if (sekretar != null)
                {
                    return sekretar;
                }
            }



            return null;
        }

        public Boolean DodajKorisnika(Korisnik registrovani)
        {
            kr.korisnici.Add(registrovani);
            kr.Sacuvaj();
            return true;
        }


        public void provjeriStatus(Pacijent pacijent)
        {
            b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);

            if (b.otkazanCnt >= 3 || b.zakazanCnt >= 3 || b.pomerenCnt >= 3)
            {
                banKorisnika(pacijent);
                b.trenutakBanovanja = DateTime.Now.ToString();

                b.otkazanCnt = 0;
                b.pomerenCnt = 0;
                b.zakazanCnt = 0;
            }

            // DateTime.Compare(DateTime.Now, DateTime.Parse(b.trenutakBanovanja).AddMinutes(3)) >= 0
            if (pacijent.banovan && DateTime.Compare(DateTime.Now, DateTime.Parse(b.trenutakBanovanja).AddMinutes(3)) >= 0)
            {
                unbanKorisnika(pacijent);
            }

            pacServis.AzurirajPacijenta(pacijent);
            BanRepozitorijum.Instance.sacuvaj(b);

        }

        private void unbanKorisnika(Pacijent pacijent)
        {
            pacijent.banovan = false;
        }

        private void banKorisnika(Pacijent pacijent)
        {
            pacijent.banovan = true;
        }

    }
}
