/***********************************************************************
 * Module:  Prostorija.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Prostorija
 ***********************************************************************/


using System;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;

namespace Model
{

    public class Prostorija
    {
        public System.Collections.ArrayList inventar;

        public Prostorija() { }
        public Prostorija(int id, string naziv, TipProstorijeEnum tip, bool slobodna, int sprat)
        {
            this.inventar = new System.Collections.ArrayList();
            this.statickaOprema = new List<StatickaOprema>();
            this.dinamickaOprema = new System.Collections.ArrayList();
            Id = id;
            Naziv = naziv;
            Tip = tip;
            Slobodna = slobodna;
            Sprat = sprat;
        }

        public Prostorija(ProstorijaDTO prostorija)
        {
            if (prostorija != null)
            {
                this.inventar = prostorija.inventar;
                this.statickaOprema = konvertujListuEntitetaUListuDTO(prostorija.statickaOprema);
                this.dinamickaOprema = prostorija.dinamickaOprema;
                Id = prostorija.Id;
                Naziv = prostorija.Naziv;
                Tip = prostorija.Tip;
                Slobodna = prostorija.Slobodna;
                Sprat = prostorija.Sprat;
            }
        }

        public List<StatickaOprema> konvertujListuEntitetaUListuDTO(List<StatickaOpremaDTO> statickaOpremaDTO)
        {
            if (statickaOpremaDTO != null)
            {
                List<StatickaOprema> staticka = new List<StatickaOprema>();
                foreach (StatickaOpremaDTO opremaDTO in statickaOpremaDTO)
                {
                    staticka.Add(new StatickaOprema(opremaDTO));
                }

                return staticka;
            }
            else
            {
                return new List<StatickaOprema>();
            }
        }

        public List<StatickaOprema> statickaOprema;

        /// <pdGenerated>default getter</pdGenerated>
        public List<StatickaOprema> GetStatickaOprema()
        {
            if (statickaOprema == null)
                statickaOprema = new List<StatickaOprema>();
            return statickaOprema;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetStatickaOprema(List<StatickaOprema> newStatickaOprema)
        {
            RemoveAllStatickaOprema();
            foreach (StatickaOprema oStatickaOprema in newStatickaOprema)
                AddStatickaOprema(oStatickaOprema);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddStatickaOprema(StatickaOprema newStatickaOprema)
        {
            if (newStatickaOprema == null)
                return;
            if (this.statickaOprema == null)
                this.statickaOprema = new List<StatickaOprema>();
            if (!this.statickaOprema.Contains(newStatickaOprema))
                this.statickaOprema.Add(newStatickaOprema);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveStatickaOprema(StatickaOprema oldStatickaOprema)
        {
            if (oldStatickaOprema == null)
                return;
            if (this.statickaOprema != null)
                if (this.statickaOprema.Contains(oldStatickaOprema))
                    this.statickaOprema.Remove(oldStatickaOprema);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllStatickaOprema()
        {
            if (statickaOprema != null)
                statickaOprema.Clear();
        }
        public System.Collections.ArrayList dinamickaOprema;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetDinamickaOprema()
        {
            if (dinamickaOprema == null)
                dinamickaOprema = new System.Collections.ArrayList();
            return dinamickaOprema;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetDinamickaOprema(System.Collections.ArrayList newDinamickaOprema)
        {
            RemoveAllDinamickaOprema();
            foreach (DinamickaOprema oDinamickaOprema in newDinamickaOprema)
                AddDinamickaOprema(oDinamickaOprema);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddDinamickaOprema(DinamickaOprema newDinamickaOprema)
        {
            if (newDinamickaOprema == null)
                return;
            if (this.dinamickaOprema == null)
                this.dinamickaOprema = new System.Collections.ArrayList();
            if (!this.dinamickaOprema.Contains(newDinamickaOprema))
                this.dinamickaOprema.Add(newDinamickaOprema);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveDinamickaOprema(DinamickaOprema oldDinamickaOprema)
        {
            if (oldDinamickaOprema == null)
                return;
            if (this.dinamickaOprema != null)
                if (this.dinamickaOprema.Contains(oldDinamickaOprema))
                    this.dinamickaOprema.Remove(oldDinamickaOprema);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllDinamickaOprema()
        {
            if (dinamickaOprema != null)
                dinamickaOprema.Clear();
        }

        public int Id { get; set; }
        public String Naziv { get; set; }
        public TipProstorijeEnum Tip { get; set; }
        public bool Slobodna { get; set; }
        public int Sprat { get; set; }

    }
}