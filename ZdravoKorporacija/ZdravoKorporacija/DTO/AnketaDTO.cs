using Model;
using System;

namespace ZdravoKorporacija.DTO
{
    public class AnketaDTO
    {
        public AnketaDTO() { }

        public AnketaDTO(int id, long idAutora, DateTime datum, TipAnkete tip, int ocena, string komentar, TerminDTO termin)
        {
            Id = id;
            IdAutora = idAutora;
            Datum = datum;
            Tip = tip;
            Ocena = ocena;
            Komentar = komentar;
            Termin = termin;
        }

        public int Id { get; set; }
        public long IdAutora { get; set; }
        public DateTime Datum { get; set; }
        public TipAnkete Tip { get; set; }
        public int Ocena { get; set; }
        public String Komentar { get; set; }
        public TerminDTO Termin { get; set; }
    }
}
