/***********************************************************************
 * Module:  Sekretar.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Sekretar
 ***********************************************************************/

using System;
namespace Model
{
    public class Sekretar : Korisnik
    {

        public Sekretar(String Ime, String Prezime) : base(Ime, Prezime)
        {

        }

        public Sekretar(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password)
        {
        }

    }
}