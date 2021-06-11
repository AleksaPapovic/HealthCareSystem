/***********************************************************************
 * Module:  Notifikacija.cs
 * Author:  User
 * Purpose: Definition of the Class Notifikacija
 ***********************************************************************/

using System;

namespace Model
{
    public class Anketa
    {
        public Anketa() { }

        public Anketa(int id, long idAutora, DateTime datum, TipAnkete tip, int ocena, string komentar, Termin termin)
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
        public Termin Termin { get; set; }
    }
}