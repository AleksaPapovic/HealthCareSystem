using Model;
using System;

namespace ZdravoKorporacija.DTO
{
    public class StatickaOpremaDTO : InventarDTO
    {
        public TerminDTO termin { get; set; }

        public ProstorijaDTO Prostorija { get; set; }

        public StatickaOpremaDTO() { }
        public StatickaOpremaDTO(InventarDTO inv) : base(inv.Id, inv.Naziv, inv.UkupnaKolicina, inv.Proizvodjac, inv.DatumNabavke)
        {
            this.termin = new TerminDTO();
        }

        public StatickaOpremaDTO(TerminDTO termin, int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke) : base(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke)
        {
            this.termin = termin;
        }

        public StatickaOpremaDTO(TerminDTO termin, InventarDTO inv) : base(inv.Id, inv.Naziv, inv.UkupnaKolicina, inv.Proizvodjac, inv.DatumNabavke)
        {
            this.termin = termin;
        }

        public StatickaOpremaDTO(StatickaOprema statickaOprema)
        {
            this.termin = new TerminDTO(statickaOprema.termin);
            Prostorija = new ProstorijaDTO(statickaOprema.Prostorija);
        }

    }
}
