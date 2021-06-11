using Model;
using System;

namespace ZdravoKorporacija.DTO
{
    public class DinamickaOpremaDTO : InventarDTO
    {

        public int Kolicina { get; set; }

        public ProstorijaDTO Prostorija { get; set; }

        public DinamickaOpremaDTO() { }

        public DinamickaOpremaDTO(int kolicina, int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke) : base(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke)
        {
            Kolicina = kolicina;
        }

        public DinamickaOpremaDTO(InventarDTO inv, int kolicina) : base(inv.Id, inv.Naziv, inv.UkupnaKolicina, inv.Proizvodjac, inv.DatumNabavke)
        {
            Kolicina = kolicina;
        }

        public DinamickaOpremaDTO(DinamickaOprema dinamickaOprema)
        {
            Kolicina = dinamickaOprema.Kolicina;
            Prostorija = new ProstorijaDTO(dinamickaOprema.Prostorija);
            InventarDTO oprema = new InventarDTO(dinamickaOprema.Id, dinamickaOprema.Naziv, dinamickaOprema.UkupnaKolicina, dinamickaOprema.Proizvodjac, dinamickaOprema.DatumNabavke);
            this.Id = dinamickaOprema.Id;
            this.Naziv = dinamickaOprema.Naziv;
            this.UkupnaKolicina = dinamickaOprema.UkupnaKolicina;
            this.Proizvodjac = dinamickaOprema.Proizvodjac;
            this.DatumNabavke = dinamickaOprema.DatumNabavke;
        }

    }
}
