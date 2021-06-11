// File:    Report.cs
// Author:  User
// Created: Wednesday, March 24, 2021 8:38:47 AM
// Purpose: Definition of Class Report

using System;
using ZdravoKorporacija.DTO;

namespace Model
{
    public class Izvestaj
    {
        public Termin termin;

        public Izvestaj() { }

        public Izvestaj(Termin termin, int id, string opis, string simptomi)
        {
            this.termin = termin;
            Id = id;
            Opis = opis;
            Simptomi = simptomi;
        }

        public Izvestaj(IzvestajDTO izvestaj)
        {
            this.termin = null;
            Id = izvestaj.Id;
            Opis = izvestaj.Opis;
            Simptomi = izvestaj.Simptomi;
        }

        public int Id { get; set; }
        public String Opis { get; set; }
        public String Simptomi { get; set; }

    }
}