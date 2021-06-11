/***********************************************************************
 * Module:  Upravnik.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Upravnik
 ***********************************************************************/

using System;
namespace Model
{
    public class Upravnik : Korisnik
    {
        public Upravnik(String Ime, String Prezime) : base(Ime, Prezime)
        {

        }

        public Upravnik(string ime, string prezime, long jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password)
        {

        }
    }
}