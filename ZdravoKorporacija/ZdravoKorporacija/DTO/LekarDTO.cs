using Model;
using System;
using System.Collections.Generic;

namespace ZdravoKorporacija.DTO
{
    public class LekarDTO : KorisnikDTO
    {
        public LekarDTO() : base() { }

        public LekarDTO(Lekar lekarEntitet)
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
               // this.Uloga = lekarEntitet.Uloga;
                this.radniDani = lekarEntitet.radniDani;
                this.Pol = lekarEntitet.Pol;
                //this.termini = new ArrayList(lekarEntitet.termin);
            }
        }

        public LekarDTO(String Ime, String Prezime) : base(Ime, Prezime)
        {
        }

        public LekarDTO(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password)
        {
        }

        public LekarDTO(string ime, string prezime, Int64 jmbg) : base(ime, prezime, jmbg)
        {
            this.Ime = ime;
            this.Prezime = prezime;
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
            foreach (TerminDTO oTermin in newTermin)
                AddTermin(oTermin);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTermin(TerminDTO newTermin)
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
        public void RemoveTermin(TerminDTO oldTermin)
        {
            if (oldTermin == null)
                return;
            if (this.termin != null)
                if (this.termin.Contains(oldTermin))
                {
                    this.termin.Remove(oldTermin);
                    oldTermin.SetLekar((LekarDTO)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTermin()
        {
            if (termin != null)
            {
                System.Collections.ArrayList tmpTermin = new System.Collections.ArrayList();
                foreach (TerminDTO oldTermin in termin)
                    tmpTermin.Add(oldTermin);
                termin.Clear();
                foreach (TerminDTO oldTermin in tmpTermin)
                    oldTermin.SetLekar((LekarDTO)null);
                tmpTermin.Clear();
            }
        }

        public SpecijalizacijaEnum Specijalizacija { get; set; }
        public List<RadniDan> radniDani { get; set; }
    }

}
