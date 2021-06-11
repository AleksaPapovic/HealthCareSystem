using System;

namespace ZdravoKorporacija.DTO
{
    public class BeleskaDTO
    {
        public int Id { get; set; }
        public String Sadrzaj { get; set; }
        public DateTime Datum { get; set; }
        public BeleskaDTO() { }

        public BeleskaDTO(int id, string sadrzaj, DateTime datum)
        {
            Id = id;
            Sadrzaj = sadrzaj;
            Datum = datum;
        }
    }
}
