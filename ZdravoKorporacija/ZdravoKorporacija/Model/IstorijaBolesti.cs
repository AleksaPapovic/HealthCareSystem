using System;
using ZdravoKorporacija.DTO;

namespace Model
{
    public class IstorijaBolesti
    {
        public DateTime DatumPoseteLekaru;
        public String PorodicnaIstorijaBolesti { get; set; }
        public String IstorijaBolestiPacijenta { get; set; }


        public System.Collections.ArrayList dijagnoza;
        public IstorijaBolesti()
        {
        }
        public IstorijaBolesti(String istorijaBolesti)
        {
            IstorijaBolestiPacijenta = istorijaBolesti;
        }
        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetDijagnoza()
        {
            if (dijagnoza == null)
                dijagnoza = new System.Collections.ArrayList();
            return dijagnoza;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetDijagnoza(System.Collections.ArrayList newDijagnoza)
        {
            RemoveAllDijagnoza();
            foreach (Dijagnoza oDijagnoza in newDijagnoza)
                AddDijagnoza(oDijagnoza);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddDijagnoza(Dijagnoza newDijagnoza)
        {
            if (newDijagnoza == null)
                return;
            if (this.dijagnoza == null)
                this.dijagnoza = new System.Collections.ArrayList();
            if (!this.dijagnoza.Contains(newDijagnoza))
            {
                this.dijagnoza.Add(newDijagnoza);
                newDijagnoza.SetIstorijaBolesti(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveDijagnoza(Dijagnoza oldDijagnoza)
        {
            if (oldDijagnoza == null)
                return;
            if (this.dijagnoza != null)
                if (this.dijagnoza.Contains(oldDijagnoza))
                {
                    this.dijagnoza.Remove(oldDijagnoza);
                    oldDijagnoza.SetIstorijaBolesti((IstorijaBolesti)null);
                }
        }

        internal void SetZdravstveniKarton(ZdravstveniKartonDTO zdravstveniKartonDTO)
        {
            throw new NotImplementedException();
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllDijagnoza()
        {
            if (dijagnoza != null)
            {
                System.Collections.ArrayList tmpDijagnoza = new System.Collections.ArrayList();
                foreach (Dijagnoza oldDijagnoza in dijagnoza)
                    tmpDijagnoza.Add(oldDijagnoza);
                dijagnoza.Clear();
                foreach (Dijagnoza oldDijagnoza in tmpDijagnoza)
                    oldDijagnoza.SetIstorijaBolesti((IstorijaBolesti)null);
                tmpDijagnoza.Clear();
            }
        }
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
                    oldZdravstveniKarton.RemoveIstorijaBolesti(this);
                }
                if (newZdravstveniKarton != null)
                {
                    this.zdravstveniKarton = newZdravstveniKarton;
                    this.zdravstveniKarton.AddIstorijaBolesti(this);
                }
            }
        }

    }
}