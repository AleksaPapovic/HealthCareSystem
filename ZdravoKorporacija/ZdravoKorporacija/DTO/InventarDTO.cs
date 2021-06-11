using Model;
using System;

namespace ZdravoKorporacija.DTO
{
    public class InventarDTO
    {
        public InventarDTO() { }


        public InventarDTO(int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke)
        {
            Id = id;
            Naziv = naziv;
            UkupnaKolicina = ukupnaKolicina;
            Proizvodjac = proizvodjac;
            DatumNabavke = datumNabavke;
        }

        public InventarDTO(Inventar inventar)
        {
            Id = inventar.Id;
            Naziv = inventar.Naziv;
            UkupnaKolicina = inventar.UkupnaKolicina;
            Proizvodjac = inventar.Proizvodjac;
            DatumNabavke = inventar.DatumNabavke;
        }



        public int Id { get; set; }
        public String Naziv { get; set; }
        public int UkupnaKolicina { get; set; }
        public String Proizvodjac { get; set; }
        public DateTime DatumNabavke { get; set; }
    }
}
