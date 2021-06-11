// File:    Patient.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:17 PM
// Purpose: Definition of Class Patient

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Model
{
    public class Pacijent : Korisnik
    {
        public Pacijent() : base() { }

        public Pacijent(String username, String password)
        {
            this.Username = username;
            this.Password = password;
        }

        public Pacijent(String username, String password, ZdravstveniKarton zk, Int64 jmbg)
        {
            this.Username = username;
            this.Password = password;
            this.ZdravstveniKarton = zk;
            this.Jmbg = jmbg;
        }

        public Pacijent(ZdravstveniKarton zdravstveniKarton, bool guest, string ime, string prezime, int jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password)
        {
            this.termin = new List<Termin>();
            ZdravstveniKarton = zdravstveniKarton;
            Guest = guest;
        }

        public List<Termin> termin;

        public Pacijent(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password)
        {
        }

        public Pacijent(PacijentDTO pacijent)
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
            this.termin = terminDTOToTermin(pacijent.termin);
            ZdravstveniKarton = new ZdravstveniKarton(pacijent.ZdravstveniKarton);
            Guest = pacijent.Guest;
            //this.notifikacije = pacijent.notifikacije;
            this.banovan = pacijent.banovan;
        }

        public List<Termin> terminDTOToTermin(List<TerminDTO> terminiDTO)
        {
            if (terminiDTO != null)
            {
                List<Termin> termini = new List<Termin>();
                foreach (TerminDTO termin in terminiDTO)
                {
                    termini.Add(new Termin(termin));
                }

                return termini;
            }
            else
            {
                return new List<Termin>();
            }
        }

        /// <pdGenerated>default getter</pdGenerated>
        public List<Termin> GetTermin()
        {
            if (termin == null)
                termin = new List<Termin>();
            return termin;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetTermin(System.Collections.ArrayList newTermin)
        {
            RemoveAllTermin();
            foreach (Termin oTermin in newTermin)
                AddTermin(oTermin);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTermin(Termin newTermin)
        {
            if (newTermin == null)
                return;
            if (this.termin == null)
                this.termin = new List<Termin>();
            if (!this.termin.Contains(newTermin))
                this.termin.Add(newTermin);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTermin(Termin oldTermin)
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
        public ZdravstveniKarton ZdravstveniKarton { get; set; }

        public bool Guest { get; set; }


        public long GetJmbg()
        {
            return this.Jmbg;
        }

        //  public ObservableCollection<Notifikacija> Notifikacije { get => notifikacije; set => notifikacije = value; }

        public ObservableCollection<Notifikacija> notifikacije;


        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<Notifikacija> GetNotifikacije()
        {
            if (notifikacije == null)
                notifikacije = new ObservableCollection<Notifikacija>();
            return notifikacije;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetNotifikacije(ObservableCollection<Notifikacija> newNotifikacije)
        {
            RemoveAllNotifikacije();
            foreach (Notifikacija oNotifikacije in newNotifikacije)
                AddNotifikacije(oNotifikacije);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddNotifikacije(Notifikacija newNotifikacije)
        {
            if (newNotifikacije == null)
                return;
            if (this.notifikacije == null)
                this.notifikacije = new ObservableCollection<Notifikacija>();
            if (!this.notifikacije.Contains(newNotifikacije))
                this.notifikacije.Add(newNotifikacije);
        }

        public void RemoveAllNotifikacije()
        {
            if (notifikacije != null)
                notifikacije.Clear();
        }

        public Boolean banovan { get; set; }


    }
}