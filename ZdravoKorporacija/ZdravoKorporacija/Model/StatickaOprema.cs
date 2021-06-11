/***********************************************************************
 * Module:  Inventar.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Inventar
 ***********************************************************************/

using System;
using ZdravoKorporacija.DTO;

namespace Model
{
    public class StatickaOprema : InventarDTO
    {
        public Termin termin { get; set; }

        public Prostorija Prostorija { get; set; }

        public StatickaOprema() { }
        public StatickaOprema(Inventar inv) : base(inv.Id, inv.Naziv, inv.UkupnaKolicina, inv.Proizvodjac, inv.DatumNabavke)
        {
        }

        public StatickaOprema(Termin termin, int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke) : base(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke)
        {
            this.termin = termin;
        }

        public StatickaOprema(Termin termin, InventarDTO inv) : base(inv.Id, inv.Naziv, inv.UkupnaKolicina, inv.Proizvodjac, inv.DatumNabavke)
        {
            this.termin = termin;
        }

        public StatickaOprema(StatickaOpremaDTO statickaOpremaDTO) {
            if (statickaOpremaDTO != null)
            {
                this.termin = new Termin(statickaOpremaDTO.termin);
            }
        }

    }
}