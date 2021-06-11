using Model;
using System;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Model
{
    public class StacionarnoLecenje
    {
        public int Id { get; set; }
        public Prostorija Prostorija { get; set; }

        public DateTime Pocetak { get; set; }

        public DateTime Kraj { get; set; }
        public String Trajanje { get; set; }

        public Pacijent Pacijent { get; set; }
        public StacionarnoLecenje() { }
        public StacionarnoLecenje(int id, Prostorija prostorija, DateTime pocetak, DateTime kraj, String trajanje, Pacijent pacijent)
        {
            Id = id;
            Prostorija = prostorija;
            Pocetak = pocetak;
            Kraj = kraj;
            Trajanje = trajanje;
            Pacijent = pacijent;
        }

        public StacionarnoLecenje(StacionarnoLecenjeDTO stacionarnoLecenje)
        {
            Id = stacionarnoLecenje.Id;
            Prostorija = new Prostorija(stacionarnoLecenje.Prostorija);
            Pocetak = stacionarnoLecenje.Pocetak;
            Kraj = stacionarnoLecenje.Kraj;
            Trajanje = stacionarnoLecenje.Trajanje;
            Pacijent = new Pacijent(stacionarnoLecenje.Pacijent);
        }
    }
}
