// File:    Beleska.cs
// Author:  User
// Created: Wednesday, March 24, 2021 8:38:47 AM
// Purpose: Definition of Class Report

using System;

namespace Model
{
    public class Beleska
    {
        public int Id { get; set; }
        public String Sadrzaj { get; set; }
        public DateTime Datum { get; set; }
        public Beleska() { }

        public Beleska(int id, string sadrzaj, DateTime datum)
        {
            Id = id;
            Sadrzaj = sadrzaj;
            Datum = datum;
        }
    }
}