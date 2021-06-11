using Model;
using System;

namespace ZdravoKorporacija.DTO
{
    class ZahtevPremestanjaDTO
    {
        public ZahtevPremestanjaDTO() { }

        public ZahtevPremestanjaDTO(int id, StatickaOpremaDTO staticka, DateTime pocetak, DateTime kraj, double trajanje)
        {
            this.Id = id;
            this.Pocetak = pocetak;
            this.prostorija = null;
            this.Kraj = kraj;
            this.StatickaOprema = staticka;
        }


        public ZahtevPremestanjaDTO(int id, StatickaOpremaDTO staticka, DateTime pocetak, DateTime kraj, ProstorijaDTO prostorija)
        {
            this.Id = id;
            this.prostorija = prostorija;
            this.Pocetak = pocetak;
            this.Kraj = kraj;
            this.StatickaOprema = staticka;
        }

        public ZahtevPremestanjaDTO(ZahtevPremestanja zahtevPremestanja)
        {
            this.Id = zahtevPremestanja.Id;
            this.prostorija = new ProstorijaDTO(zahtevPremestanja.prostorija);
            this.Pocetak = zahtevPremestanja.Pocetak;
            this.Kraj = zahtevPremestanja.Kraj;
            this.StatickaOprema = new StatickaOpremaDTO(zahtevPremestanja.StatickaOprema);
        }



        public ProstorijaDTO prostorija { get; set; }
        public StatickaOpremaDTO StatickaOprema { get; set; }
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

    }
}
