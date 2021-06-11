// File:    Doctor.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:16 PM
// Purpose: Definition of Class Doctor

using System;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;

namespace Model
{
    public class Lekar : Korisnik
    {

        public Lekar() : base() { }
        public Lekar(String Ime, String Prezime) : base(Ime, Prezime)
        {
        }

        public Lekar(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password)
        {
        }

        public Lekar(LekarDTO lekarEntitet)
        {
            if (lekarEntitet != null)
            {
                this.Jmbg = lekarEntitet.Jmbg;
                this.Ime = lekarEntitet.Ime;
                this.Prezime = lekarEntitet.Prezime;
                this.Specijalizacija = lekarEntitet.Specijalizacija;
                this.Username = lekarEntitet.Username;
                this.Specijalizacija = lekarEntitet.Specijalizacija;
                this.AdresaStanovanja = lekarEntitet.AdresaStanovanja;
                this.BrojTelefona = lekarEntitet.BrojTelefona;
                this.Password = lekarEntitet.Password;
                this.Mejl = lekarEntitet.Mejl;
                //this.Uloga = lekarEntitet.Uloga;
                this.radniDani = lekarEntitet.radniDani;
                this.Pol = lekarEntitet.Pol;
                //this.termini = new ArrayList(lekarEntitet.termin);
            }
        }

        public Lekar(string Ime, string Prezime, Int64 jmbg) : base(Ime, Prezime)
        {
            this.Jmbg = jmbg;
        }

        public System.Collections.ArrayList termin;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetTermin()
        {
            if (termin == null)
                termin = new System.Collections.ArrayList();
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
                this.termin = new System.Collections.ArrayList();
            if (!this.termin.Contains(newTermin))
            {
                this.termin.Add(newTermin);
                newTermin.SetLekar(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTermin(Termin oldTermin)
        {
            if (oldTermin == null)
                return;
            if (this.termin != null)
                if (this.termin.Contains(oldTermin))
                {
                    this.termin.Remove(oldTermin);
                    oldTermin.SetLekar((Lekar)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTermin()
        {
            if (termin != null)
            {
                System.Collections.ArrayList tmpTermin = new System.Collections.ArrayList();
                foreach (Termin oldTermin in termin)
                    tmpTermin.Add(oldTermin);
                termin.Clear();
                foreach (Termin oldTermin in tmpTermin)
                    oldTermin.SetLekar((Lekar)null);
                tmpTermin.Clear();
            }
        }
        public SpecijalizacijaEnum Specijalizacija { get; set; }
        public List<RadniDan> radniDani { get; set; }

    }
}