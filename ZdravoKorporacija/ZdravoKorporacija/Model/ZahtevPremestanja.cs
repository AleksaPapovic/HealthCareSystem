using System;
using ZdravoKorporacija.DTO;

namespace Model
{
    class ZahtevPremestanja
    {
        public ZahtevPremestanja() { }

        public ZahtevPremestanja(int id, StatickaOprema staticka, DateTime pocetak, DateTime kraj, double trajanje)
        {
            this.Id = id;
            this.Pocetak = pocetak;
            this.prostorija = null;
            this.Kraj = kraj;
            this.StatickaOprema = staticka;
        }


        public ZahtevPremestanja(int id, StatickaOprema staticka, DateTime pocetak, DateTime kraj, Prostorija prostorija)
        {
            this.Id = id;
            this.prostorija = prostorija;
            this.Pocetak = pocetak;
            this.Kraj = kraj;
            this.StatickaOprema = staticka;
        }

        public ZahtevPremestanja(ZahtevPremestanjaDTO zahtevPremestanjaDTO)
        {
            this.Id = zahtevPremestanjaDTO.Id;
            this.prostorija = new Prostorija(zahtevPremestanjaDTO.prostorija);
            this.Pocetak = zahtevPremestanjaDTO.Pocetak;
            this.Kraj = zahtevPremestanjaDTO.Kraj;
            this.StatickaOprema = new StatickaOprema(zahtevPremestanjaDTO.StatickaOprema);
        }

        public Prostorija prostorija { get; set; }
        public StatickaOprema StatickaOprema { get; set; }
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

    }
}
