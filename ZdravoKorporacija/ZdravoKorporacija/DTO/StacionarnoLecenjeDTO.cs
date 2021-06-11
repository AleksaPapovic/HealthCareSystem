using System;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.DTO
{
    public class StacionarnoLecenjeDTO
    {
        public int Id { get; set; }
        public ProstorijaDTO Prostorija { get; set; }

        public DateTime Pocetak { get; set; }

        public DateTime Kraj { get; set; }
        public String Trajanje { get; set; }

        public PacijentDTO Pacijent { get; set; }
        public StacionarnoLecenjeDTO()
        {
        }
        public StacionarnoLecenjeDTO(int id, ProstorijaDTO prostorija, DateTime pocetak, DateTime kraj, String trajanje, PacijentDTO pacijent)
        {
            Id = id;
            Prostorija = prostorija;
            Pocetak = pocetak;
            Kraj = kraj;
            Trajanje = trajanje;
            Pacijent = pacijent;
        }

        public StacionarnoLecenjeDTO(StacionarnoLecenje stacionarnoLecenje)
        {
            Id = stacionarnoLecenje.Id;
            Prostorija = new ProstorijaDTO(stacionarnoLecenje.Prostorija);
            Pocetak = stacionarnoLecenje.Pocetak;
            Kraj = stacionarnoLecenje.Kraj;
            Trajanje = stacionarnoLecenje.Trajanje;
            Pacijent = new PacijentDTO(stacionarnoLecenje.Pacijent);
        }


    }
}
