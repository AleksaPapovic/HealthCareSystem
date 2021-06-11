using System;

namespace ZdravoKorporacija.DTO
{
    public class IstorijaBolestiDTO
    {
        public DateTime DatumPoseteLekaru;
        public String PorodicnaIstorijaBolesti { get; set; }
        public String IstorijaBolestiPacijenta { get; set; }


        public System.Collections.ArrayList dijagnoza;
        public IstorijaBolestiDTO()
        {
        }
        public IstorijaBolestiDTO(String istorijaBolesti)
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
            foreach (DijagnozaDTO oDijagnoza in newDijagnoza)
                AddDijagnoza(oDijagnoza);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddDijagnoza(DijagnozaDTO newDijagnoza)
        {
            if (newDijagnoza == null)
                return;
            if (this.dijagnoza == null)
                this.dijagnoza = new System.Collections.ArrayList();
            if (!this.dijagnoza.Contains(newDijagnoza))
            {
                this.dijagnoza.Add(newDijagnoza);
                //    newDijagnoza.SetIstorijaBolesti(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveDijagnoza(DijagnozaDTO oldDijagnoza)
        {
            if (oldDijagnoza == null)
                return;
            if (this.dijagnoza != null)
                if (this.dijagnoza.Contains(oldDijagnoza))
                {
                    this.dijagnoza.Remove(oldDijagnoza);
                    //      oldDijagnoza.SetIstorijaBolesti((IstorijaBolestiDTO)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllDijagnoza()
        {
            if (dijagnoza != null)
            {
                System.Collections.ArrayList tmpDijagnoza = new System.Collections.ArrayList();
                foreach (DijagnozaDTO oldDijagnoza in dijagnoza)
                    tmpDijagnoza.Add(oldDijagnoza);
                dijagnoza.Clear();
                // foreach (DijagnozaDTO oldDijagnoza in tmpDijagnoza)
                //    oldDijagnoza.SetIstorijaBolesti((IstorijaBolestiDTO)null);
                tmpDijagnoza.Clear();
            }
        }
        public ZdravstveniKartonDTO zdravstveniKarton;

        /// <pdGenerated>default parent getter</pdGenerated>
        public ZdravstveniKartonDTO GetZdravstveniKarton()
        {
            return zdravstveniKarton;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newZdravstveniKarton</param>
        public void SetZdravstveniKarton(ZdravstveniKartonDTO newZdravstveniKarton)
        {
            if (this.zdravstveniKarton != newZdravstveniKarton)
            {
                if (this.zdravstveniKarton != null)
                {
                    ZdravstveniKartonDTO oldZdravstveniKarton = this.zdravstveniKarton;
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