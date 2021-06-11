// File:    Diagnosis.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:52 PM
// Purpose: Definition of Class Diagnosis

using System;
using System.Collections;

namespace Model
{
    public class Dijagnoza : Izvestaj
    {
        public String Oboljenje;
        public new String Opis;

        public System.Collections.ArrayList terapija;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetTerapija()
        {
            if (terapija == null)
                terapija = new System.Collections.ArrayList();
            return terapija;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetTerapija(System.Collections.ArrayList newTerapija)
        {
            RemoveAllTerapija();
            foreach (Terapija oTerapija in newTerapija)
                AddTerapija(oTerapija);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTerapija(Terapija newTerapija)
        {
            if (newTerapija == null)
                return;
            if (this.terapija == null)
                this.terapija = new System.Collections.ArrayList();
            if (!this.terapija.Contains(newTerapija))
                this.terapija.Add(newTerapija);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTerapija(Terapija oldTerapija)
        {
            if (oldTerapija == null)
                return;
            if (this.terapija != null)
                if (this.terapija.Contains(oldTerapija))
                    this.terapija.Remove(oldTerapija);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTerapija()
        {
            if (terapija != null)
                terapija.Clear();
        }
        public IstorijaBolesti istorijaBolesti;
        public Dijagnoza() : base()
        {

        }
        public Dijagnoza(string oboljenje, string opis, ArrayList terapija, IstorijaBolesti istorijaBolesti, Termin termin, int id, string simptomi) : base(termin, id, opis, simptomi)
        {
            Oboljenje = oboljenje;
            Opis = opis;
            this.terapija = terapija;
            this.istorijaBolesti = istorijaBolesti;
        }



        /// <pdGenerated>default parent getter</pdGenerated>
        public IstorijaBolesti GetIstorijaBolesti()
        {
            return istorijaBolesti;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newIstorijaBolesti</param>
        public void SetIstorijaBolesti(IstorijaBolesti newIstorijaBolesti)
        {
            if (this.istorijaBolesti != newIstorijaBolesti)
            {
                if (this.istorijaBolesti != null)
                {
                    IstorijaBolesti oldIstorijaBolesti = this.istorijaBolesti;
                    this.istorijaBolesti = null;
                    oldIstorijaBolesti.RemoveDijagnoza(this);
                }
                if (newIstorijaBolesti != null)
                {
                    this.istorijaBolesti = newIstorijaBolesti;
                    this.istorijaBolesti.AddDijagnoza(this);
                }
            }
        }

    }
}