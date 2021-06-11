using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ZdravoKorporacija.DTO
{
    public class PacijentDTO : KorisnikDTO
    {
        public PacijentDTO() : base() { }
        public String korisnickoIme { get; set; }
        public String lozinka { get; set; }
        public ZdravstveniKartonDTO ZdravstveniKarton { get; set; }
        public Int64 Jmbg { get; set; }

        public List<TerminDTO> termin;
        public bool Guest { get; set; }


        public ObservableCollection<NotifikacijaDTO> notifikacije;

        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<NotifikacijaDTO> GetNotifikacije()
        {
            if (notifikacije == null)
                notifikacije = new ObservableCollection<NotifikacijaDTO>();
            return notifikacije;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetNotifikacije(ObservableCollection<NotifikacijaDTO> newNotifikacije)
        {
            RemoveAllNotifikacije();
            foreach (NotifikacijaDTO oNotifikacije in newNotifikacije)
                AddNotifikacije(oNotifikacije);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddNotifikacije(NotifikacijaDTO newNotifikacije)
        {
            if (newNotifikacije == null)
                return;
            if (this.notifikacije == null)
                this.notifikacije = new ObservableCollection<NotifikacijaDTO>();
            if (!this.notifikacije.Contains(newNotifikacije))
                this.notifikacije.Add(newNotifikacije);
        }

        public void RemoveAllNotifikacije()
        {
            if (notifikacije != null)
                notifikacije.Clear();
        }

        public PacijentDTO(String ime, String prezime, String korisnickoIme, String lozinka, ZdravstveniKartonDTO zdravstveniKarton, Int64 jmbg)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.ZdravstveniKarton = zdravstveniKarton;
            this.notifikacije = new ObservableCollection<NotifikacijaDTO>();
            this.Jmbg = jmbg;
        }

        public PacijentDTO(ZdravstveniKartonDTO zdravstveniKarton, bool guest, string ime, string prezime, long jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password)
        {
            this.termin = new List<TerminDTO>();
            ZdravstveniKarton = zdravstveniKarton;
            Guest = guest;
        }

        public PacijentDTO(Pacijent pacijent)
        {
            this.Ime = pacijent.Ime;
            this.Prezime = pacijent.Prezime;
            Jmbg = pacijent.Jmbg;
            BrojTelefona = pacijent.BrojTelefona;
            Mejl = pacijent.Mejl;
            AdresaStanovanja = pacijent.AdresaStanovanja;
            Pol = pacijent.Pol;
            Username = pacijent.Username;
            Password = pacijent.Password;
            this.termin = terminToTerminDTO(pacijent.termin);
            ZdravstveniKarton = new ZdravstveniKartonDTO(pacijent.ZdravstveniKarton);
            Guest = pacijent.Guest;
            //this.notifikacije = new NotifikacijaDTO(pacijent.notifikacije;
            this.banovan = pacijent.banovan;
        }

        public List<TerminDTO> terminToTerminDTO(List<Termin> termini)
        {
            if (termini != null)
            {
                List<TerminDTO> terminiDTO = new List<TerminDTO>();
                foreach (Termin termin in termini)
                {
                    terminiDTO.Add(new TerminDTO(termin));
                }

                return terminiDTO;
            }
            else
            {
                return new List<TerminDTO>();
            }
        }


        /// <pdGenerated>default getter</pdGenerated>
        public List<TerminDTO> GetTermin()
        {
            if (termin == null)
                termin = new List<TerminDTO>();
            return termin;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetTermin(System.Collections.ArrayList newTermin)
        {
            RemoveAllTermin();
            foreach (TerminDTO oTermin in newTermin)
                AddTermin(oTermin);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTermin(TerminDTO newTermin)
        {
            if (newTermin == null)
                return;
            if (this.termin == null)
                this.termin = new List<TerminDTO>();
            if (!this.termin.Contains(newTermin))
                this.termin.Add(newTermin);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTermin(TerminDTO oldTermin)
        {
            if (oldTermin == null)
                return;
            if (this.termin != null)
            {
                this.termin.Remove(oldTermin);
                System.Diagnostics.Debug.WriteLine("Izbrisalo");
            }
        }
        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTermin()
        {
            if (termin != null)
                termin.Clear();
        }

        public long GetJmbg()
        {
            return this.Jmbg;
        }

        //  public ObservableCollection<Notifikacija> Notifikacije { get => notifikacije; set => notifikacije = value; }

        public Boolean banovan { get; set; }


    }
}
