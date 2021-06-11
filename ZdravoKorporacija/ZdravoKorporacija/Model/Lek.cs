// File:    Medicine.cs
// Author:  User
// Created: Wednesday, March 24, 2021 12:50:18 AM
// Purpose: Definition of Class Medicine

using System;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;

namespace Model
{
    public class Lek
    {
        public int Id { get; set; }
        public String Proizvodjac { get; set; }
        public String Sastojci { get; set; }
        public String NusPojave { get; set; }
        public String NazivLeka { get; set; }

        public double Kolicina { get; set; }
        public String Alergeni { get; set; }

        public List<Lek> alternativniLekovi;

        /// <pdGenerated>default getter</pdGenerated>
        public List<Lek> GetalternativniLekovi()
        {
            if (alternativniLekovi == null)
                alternativniLekovi = new List<Lek>();
            return alternativniLekovi;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetalternativniLekovi(List<Lek> newalternativniLekovi)
        {
            RemoveAllalternativniLekovi();
            foreach (Lek oLek in newalternativniLekovi)
                AddalternativniLekovi(oLek);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddalternativniLekovi(Lek newLek)
        {
            if (newLek == null)
                return;
            if (this.alternativniLekovi == null)
                this.alternativniLekovi = new List<Lek>();
            if (!this.alternativniLekovi.Contains(newLek))
                this.alternativniLekovi.Add(newLek);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemovealternativniLekovi(Lek oldLek)
        {
            if (oldLek == null)
                return;
            if (this.alternativniLekovi != null)
                if (this.alternativniLekovi.Contains(oldLek))
                    this.alternativniLekovi.Remove(oldLek);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllalternativniLekovi()
        {
            if (alternativniLekovi != null)
                alternativniLekovi.Clear();
        }
        public Lek() { }
        public Lek(int  ID, String pr, String sas, String np, String nl,double kolicina)
        {
            Id = ID;
            Proizvodjac = pr;
            Sastojci = sas;
            NusPojave = np;
            NazivLeka = nl;
            Kolicina = kolicina;
            this.alternativniLekovi = new List<Lek>();
        }
        public Lek(LekDTO lekDTO)
        {
            Id = lekDTO.Id;
            Proizvodjac = lekDTO.Proizvodjac;
            Sastojci = lekDTO.Sastojci;
            NusPojave = lekDTO.NusPojave;
            NazivLeka = lekDTO.NazivLeka;
            Kolicina = Double.Parse(lekDTO.Kolicina);
            this.alternativniLekovi = konvertujListuEntitetaUListuDTO(lekDTO.alternativniLekovi);

        }
        public List<Lek> konvertujListuEntitetaUListuDTO(List<LekDTO> lekovi)
        {
            if (lekovi != null)
            {
                List<Lek> lekoviDTO = new List<Lek>();
                foreach (LekDTO lekDTO in lekovi)
                {
                    lekoviDTO.Add(new Lek(lekDTO));
                }

                return lekoviDTO;
            }
            else
            {
                return new List<Lek>();
            }
        }

    }
}