/***********************************************************************
 * Module:  Inventar.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Inventar
 ***********************************************************************/

using System;
using ZdravoKorporacija.DTO;

namespace Model
{
    public class Inventar
    {

        public Inventar() { }


        public Inventar(int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke)
        {
            Id = id;
            Naziv = naziv;
            UkupnaKolicina = ukupnaKolicina;
            Proizvodjac = proizvodjac;
            DatumNabavke = datumNabavke;
        }

        public Inventar(InventarDTO inventarDTO)
        {
            Id = inventarDTO.Id;
            Naziv = inventarDTO.Naziv;
            UkupnaKolicina = inventarDTO.UkupnaKolicina;
            Proizvodjac = inventarDTO.Proizvodjac;
            DatumNabavke = inventarDTO.DatumNabavke;

        }



        public int Id { get; set; }
        public String Naziv { get; set; }
        public int UkupnaKolicina { get; set; }
        public String Proizvodjac { get; set; }
        public DateTime DatumNabavke { get; set; }

    }

}