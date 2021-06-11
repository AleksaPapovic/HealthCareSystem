using Model;
using System;

namespace ZdravoKorporacija.DTO
{
    public class KorisnikDTO
    {
        public KorisnikDTO() { }
        public KorisnikDTO(String Ime, String Prezime)
        {
            this.Ime = Ime;
            this.Prezime = Prezime;
        }

        public KorisnikDTO(Korisnik korisnik)
        {
            if (korisnik != null)
            { 
            Jmbg = korisnik.Jmbg;
            BrojTelefona = korisnik.BrojTelefona;
            Mejl = korisnik.Mejl;
            AdresaStanovanja = korisnik.AdresaStanovanja;
            Pol = korisnik.Pol;
            Username = korisnik.Username;
            Password = korisnik.Password;
            //Uloga = korisnik.Uloga;
            }
        }

        public KorisnikDTO(string Ime, string Prezime, long jmbg) : this(Ime, Prezime)
        {

        }

        public KorisnikDTO(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol) : this(ime, prezime)
        {
            Jmbg = jmbg;
            BrojTelefona = brojTelefona;
            Mejl = mejl;
            AdresaStanovanja = adresaStanovanja;
            Pol = pol;
        }

        public KorisnikDTO(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password) : this(ime, prezime)
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
        public long Jmbg { get; set; }
        public int BrojTelefona { get; set; }
        public String Mejl { get; set; }
        public String AdresaStanovanja { get; set; }
        public PolEnum Pol { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

    }
}
