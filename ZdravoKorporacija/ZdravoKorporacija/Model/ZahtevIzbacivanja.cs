using System;

namespace Model
{
    class ZahtevIzbacivanja
    {
        public ZahtevIzbacivanja() { }

        public ZahtevIzbacivanja(int id, StatickaOprema staticka, DateTime pocetak, DateTime kraj, double trajanje, int indeks)
        {
            this.Id = id;
            this.Pocetak = pocetak;
            this.prostorija = null;
            this.Kraj = kraj;
            this.StatickaOprema = staticka;
            this.IndeksProstorije = indeks;
        }


        public ZahtevIzbacivanja(int id, StatickaOprema staticka, DateTime pocetak, DateTime kraj, int indeks, Prostorija prostorija)
        {
            this.Id = id;
            this.prostorija = prostorija;
            this.Pocetak = pocetak;
            this.Kraj = kraj;
            this.StatickaOprema = staticka;
            this.IndeksProstorije = indeks;
        }

        public Prostorija prostorija { get; set; }

        public int IndeksProstorije { get; set; }
        public StatickaOprema StatickaOprema { get; set; }
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

    }
}

