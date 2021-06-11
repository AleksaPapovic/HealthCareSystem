/***********************************************************************
 * Module:  Korisnik.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Korisnik
 ***********************************************************************/

using System;

namespace Model
{
    public class Korisnik
    {

        public Korisnik() { }
        public Korisnik(String Ime, String Prezime)
        {
            this.Ime = Ime;
            this.Prezime = Prezime;
        }

        public Korisnik(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol) : this(ime, prezime)
        {
            Jmbg = jmbg;
            BrojTelefona = brojTelefona;
            Mejl = mejl;
            AdresaStanovanja = adresaStanovanja;
            Pol = pol;
        }

        public Korisnik(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password) : this(ime, prezime)
        {
            Jmbg = jmbg;
            BrojTelefona = brojTelefona;
            Mejl = mejl;
            AdresaStanovanja = adresaStanovanja;
            Pol = pol;
            Username = username;
            Password = password;
        }

        public String Ime { get; set; }
        public String Prezime { get; set; }
        public Int64 Jmbg { get; set; }
        public int BrojTelefona { get; set; }
        public String Mejl { get; set; }
        public String AdresaStanovanja { get; set; }
        public PolEnum Pol { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

    }
}