// File:    Appointment.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:13 PM
// Purpose: Definition of Class Appointment

using System;
using ZdravoKorporacija.DTO;

namespace Model
{

    public class Termin
    {

        public Termin() { }

        public Termin(int id, Lekar lekar, TipTerminaEnum tip, DateTime pocetak, double trajanje, ZdravstveniKarton zdravstveniKarton, Izvestaj izvestaj)
        {
            this.Id = id;
            this.Lekar = lekar;
            this.Tip = tip;
            this.Pocetak = pocetak;
            this.Trajanje = 30;
            this.zdravstveniKarton = zdravstveniKarton;
            this.prostorija = null;
            this.izvestaj = izvestaj;
        }


        public Termin(ZdravstveniKarton zdravstveniKarton, Prostorija prostorija, Lekar Lekar, TipTerminaEnum tip, DateTime pocetak, double trajanje, Izvestaj izvestaj)
        {
            this.izvestaj = izvestaj;
            this.zdravstveniKarton = zdravstveniKarton;
            this.prostorija = prostorija;
            this.Lekar = Lekar;
            Tip = tip;
            Pocetak = pocetak;
            Trajanje = trajanje;
        }
        public Termin(int id, Lekar lekar, TipTerminaEnum tip, DateTime pocetak, double trajanje)
        {
            Id = id;
            Lekar = lekar;
            Tip = tip;
            Pocetak = pocetak;
            Trajanje = trajanje;
        }

        public Termin(TerminDTO termin)
        {
            if(termin!=null)
            { 
            if(termin.izvestaj!=null)
            this.izvestaj = new Izvestaj(termin.izvestaj);
            this.zdravstveniKarton = new ZdravstveniKarton(termin.zdravstveniKarton);
            this.prostorija = new Prostorija(termin.prostorija);
            Lekar = new Lekar(termin.Lekar);
            Id = termin.Id;
            Tip = termin.Tip;
            Pocetak = termin.Pocetak;
            Trajanje = termin.Trajanje;
            this.hitno = termin.hitno;
            }
        }

        public Izvestaj izvestaj;
        public ZdravstveniKarton zdravstveniKarton;

        /// <pdGenerated>default parent getter</pdGenerated>
        public ZdravstveniKarton GetZdravstveniKarton()
        {
            return zdravstveniKarton;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newZdravstveniKarton</param>
        public void SetZdravstveniKarton(ZdravstveniKarton newZdravstveniKarton)
        {
            if (this.zdravstveniKarton != newZdravstveniKarton)
            {
                if (this.zdravstveniKarton != null)
                {
                    ZdravstveniKarton oldZdravstveniKarton = this.zdravstveniKarton;
                    this.zdravstveniKarton = null;
                    oldZdravstveniKarton.RemoveTermin(this);
                }
                if (newZdravstveniKarton != null)
                {
                    this.zdravstveniKarton = newZdravstveniKarton;
                    this.zdravstveniKarton.AddTermin(this);
                }
            }
        }
        public Prostorija prostorija { get; set; }
        public Lekar Lekar { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Lekar GetLekar()
        {
            return Lekar;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newLekar</param>
        public void SetLekar(Lekar newLekar)
        {
            if (this.Lekar != newLekar)
            {
                if (this.Lekar != null)
                {
                    Lekar oldLekar = this.Lekar;
                    this.Lekar = null;
                    oldLekar.RemoveTermin(this);
                }
                if (newLekar != null)
                {
                    this.Lekar = newLekar;
                    this.Lekar.AddTermin(this);
                }
            }
        }
        public int Id { get; set; }
        public TipTerminaEnum Tip { get; set; }
        public DateTime Pocetak { get; set; }
        public double Trajanje { get; set; }
        public bool hitno { get; set; }

    }
}