using Model;
using System;

namespace ZdravoKorporacija.DTO
{
    public class IzvestajDTO
    {
        public TerminDTO termin;

        public IzvestajDTO() { }

        public IzvestajDTO(TerminDTO termin, int id, string opis, string simptomi)
        {
            this.termin = termin;
            Id = id;
            Opis = opis;
            Simptomi = simptomi;
        }

        public IzvestajDTO(int id, string opis, string simptomi, TerminDTO termin)
        {
            Id = id;
            Opis = opis;
            Simptomi = simptomi;
            Termin = termin;
        }

        public IzvestajDTO(Izvestaj izvestaj)
        {
            if (izvestaj != null)
            {
                this.termin =  new TerminDTO(izvestaj.termin);
                Id = izvestaj.Id;
                Opis = izvestaj.Opis;
                Simptomi = izvestaj.Simptomi;
            }
        }

        public int Id { get; set; }
        public String Opis { get; set; }
        public String Simptomi { get; set; }

        public TerminDTO Termin { get; set; }

    }
}
