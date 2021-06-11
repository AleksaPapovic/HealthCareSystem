/***********************************************************************
 * Module:  Inventar.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Inventar
 ***********************************************************************/

using System;
using ZdravoKorporacija.DTO;

namespace Model
{
    public class DinamickaOprema : InventarDTO
    {
        public int Kolicina { get; set; }

        public Prostorija Prostorija { get; set; }

        public DinamickaOprema() { }

        public DinamickaOprema(int kolicina, int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke) : base(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke)
        {
            Kolicina = kolicina;
        }

        public DinamickaOprema(InventarDTO inv, int kolicina) : base(inv.Id, inv.Naziv, inv.UkupnaKolicina, inv.Proizvodjac, inv.DatumNabavke)
        {
            Kolicina = kolicina;
        }

        public DinamickaOprema(DinamickaOpremaDTO dinamickaOpremaDTO, InventarDTO inventarDTO)
        {
            Kolicina = dinamickaOpremaDTO.Kolicina;
            Prostorija = new Prostorija(dinamickaOpremaDTO.Prostorija);
            Inventar oprema = new Inventar(inventarDTO);
            this.Id = oprema.Id;
            this.Naziv = oprema.Naziv;
            this.UkupnaKolicina = oprema.UkupnaKolicina;
            this.Proizvodjac = oprema.Proizvodjac;
            this.DatumNabavke = oprema.DatumNabavke;
        }


    }
}