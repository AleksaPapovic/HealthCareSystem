// File:    Therapy.cs
// Author:  User
// Created: Tuesday, March 23, 2021 11:45:41 PM
// Purpose: Definition of Class Therapy

using System;

namespace Model
{
    public class Terapija
    {
        public int TipTerapije;
        public String Doziranje;
        public int Trajanje;

        public System.Collections.ArrayList recept;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetRecept()
        {
            if (recept == null)
                recept = new System.Collections.ArrayList();
            return recept;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetRecept(System.Collections.ArrayList newRecept)
        {
            RemoveAllRecept();
            foreach (Recept oRecept in newRecept)
                AddRecept(oRecept);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddRecept(Recept newRecept)
        {
            if (newRecept == null)
                return;
            if (this.recept == null)
                this.recept = new System.Collections.ArrayList();
            if (!this.recept.Contains(newRecept))
                this.recept.Add(newRecept);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveRecept(Recept oldRecept)
        {
            if (oldRecept == null)
                return;
            if (this.recept != null)
                if (this.recept.Contains(oldRecept))
                    this.recept.Remove(oldRecept);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllRecept()
        {
            if (recept != null)
                recept.Clear();
        }

    }
}