using Model;
using System;
using System.Collections.Generic;

namespace ZdravoKorporacija.DTO
{
    public class ZdravstveniKartonDTO
    {
        public System.Collections.ArrayList izvestajOHospitalizaciji;


        public ZdravstveniKartonDTO(Pacijent patient, long id, StanjePacijentaEnum zdravstvenoStanje, string alergije, KrvnaGrupaEnum krvnaGrupa, string vakcine)
        {
            this.izvestajOHospitalizaciji = new System.Collections.ArrayList();
            this.istorijaBolesti = new List<IstorijaBolestiDTO>();
            this.recept = new List<ReceptDTO>();
            this.termin = new List<TerminDTO>();
            this.patient = patient;
            Id = id;
            ZdravstvenoStanje = zdravstvenoStanje;
            Alergije = alergije;
            KrvnaGrupa = krvnaGrupa;
            Vakcine = vakcine;
        }

        public ZdravstveniKartonDTO(ZdravstveniKarton zdravstveniKarton)
        {
            if (zdravstveniKarton != null)
            {
                this.izvestajOHospitalizaciji = zdravstveniKarton.izvestajOHospitalizaciji;
                this.istorijaBolesti = new List<IstorijaBolestiDTO>();
                this.recept = konvertujListuEntitetaUListuDTO(zdravstveniKarton.recept);
                this.termin = konvertujListuEntitetaUListuDTO(zdravstveniKarton.termin);
                this.patient = zdravstveniKarton.patient;
                Id = zdravstveniKarton.Id;
                ZdravstvenoStanje = zdravstveniKarton.ZdravstvenoStanje;
                Alergije = zdravstveniKarton.Alergije;
                KrvnaGrupa = zdravstveniKarton.KrvnaGrupa;
                Vakcine = zdravstveniKarton.Vakcine;
            }
        }

        public List<ReceptDTO> konvertujListuEntitetaUListuDTO(List<Recept> recepti)
        {
            List<ReceptDTO> receptiDTO = new List<ReceptDTO>();
            if (recepti != null)
            {

                foreach (Recept recept in recepti)
                {
                    receptiDTO.Add(new ReceptDTO(recept));
                }

            }
            return receptiDTO;
        }

        public ZdravstveniKartonDTO() { }
        public PacijentDTO pacijent { get; set; }
        public long Id { get; set; }

        public List<ReceptDTO> recept;

        //public List<IstorijaBolesti> istorijaBolesti;
        public ZdravstveniKartonDTO(long id)
        {
            this.Id = id;
        }
        public ZdravstveniKartonDTO(IEnumerable<ReceptDTO> recept, List<IstorijaBolesti> istorijaBolesti, PacijentDTO pacijent, long id)
        {
           if(this.recept != null)
            {
                this.recept = new List<ReceptDTO>(recept);
            }
            else
            {
                this.recept = new List<ReceptDTO>();
            }
            //this.istorijaBolesti = istorijaBolesti;
            this.pacijent = pacijent;
            Id = id;
        }


        public List<TerminDTO> konvertujListuEntitetaUListuDTO(List<Termin> termini)
        {
            if (termini != null)
            {
                List<TerminDTO> terminiDTO = new List<TerminDTO>();
                foreach (Termin termin in termini)
                {
                    terminiDTO.Add(new TerminDTO(termin));
                }

                return terminiDTO;
            }
            else
            {
                return new List<TerminDTO>();
            }
        }

        public List<IstorijaBolestiDTO> istorijaBolesti;

        /// <pdGenerated>default getter</pdGenerated>
        public List<IstorijaBolestiDTO> GetIstorijaBolesti()
        {
            if (istorijaBolesti == null)
                istorijaBolesti = new List<IstorijaBolestiDTO>();
            return istorijaBolesti;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetIstorijaBolesti(System.Collections.ArrayList newIstorijaBolesti)
        {
            RemoveAllIstorijaBolesti();
            foreach (IstorijaBolestiDTO oIstorijaBolesti in newIstorijaBolesti)
                AddIstorijaBolesti(oIstorijaBolesti);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddIstorijaBolesti(IstorijaBolestiDTO newIstorijaBolesti)
        {
            if (newIstorijaBolesti == null)
                return;
            if (this.istorijaBolesti == null)
                this.istorijaBolesti = new List<IstorijaBolestiDTO>();
            if (!this.istorijaBolesti.Contains(newIstorijaBolesti))
            {
                this.istorijaBolesti.Add(newIstorijaBolesti);
                newIstorijaBolesti.SetZdravstveniKarton(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveIstorijaBolesti(IstorijaBolestiDTO oldIstorijaBolesti)
        {
            if (oldIstorijaBolesti == null)
                return;
            if (this.istorijaBolesti != null)
                if (this.istorijaBolesti.Contains(oldIstorijaBolesti))
                {
                    this.istorijaBolesti.Remove(oldIstorijaBolesti);
                    oldIstorijaBolesti.SetZdravstveniKarton((ZdravstveniKartonDTO)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllIstorijaBolesti()
        {
            if (istorijaBolesti != null)
            {
                System.Collections.ArrayList tmpIstorijaBolesti = new System.Collections.ArrayList();
                foreach (IstorijaBolestiDTO oldIstorijaBolesti in istorijaBolesti)
                    tmpIstorijaBolesti.Add(oldIstorijaBolesti);
                istorijaBolesti.Clear();
                foreach (IstorijaBolestiDTO oldIstorijaBolesti in tmpIstorijaBolesti)
                    oldIstorijaBolesti.SetZdravstveniKarton((ZdravstveniKartonDTO)null);
                tmpIstorijaBolesti.Clear();
            }
        }

        /// <pdGenerated>default getter</pdGenerated>
        public List<ReceptDTO> GetRecept()
        {
            if (recept == null)
                recept = new List<ReceptDTO>();
            return recept;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetRecept(System.Collections.ArrayList newRecept)
        {
            RemoveAllRecept();
            foreach (ReceptDTO oRecept in newRecept)
                AddRecept(oRecept);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddRecept(ReceptDTO newRecept)
        {
            if (newRecept == null)
                return;
            if (this.recept == null)
                this.recept = new List<ReceptDTO>();
            if (!this.recept.Contains(newRecept))
            {
                this.recept.Add(newRecept);
                newRecept.SetZdravstveniKarton(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveRecept(ReceptDTO oldRecept)
        {
            if (oldRecept == null)
                return;
            if (this.recept != null)
                if (this.recept.Contains(oldRecept))
                {
                    this.recept.Remove(oldRecept);
                    oldRecept.SetZdravstveniKarton((ZdravstveniKartonDTO)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllRecept()
        {
            if (recept != null)
            {
                System.Collections.ArrayList tmpRecept = new System.Collections.ArrayList();
                foreach (ReceptDTO oldRecept in recept)
                    tmpRecept.Add(oldRecept);
                recept.Clear();
                foreach (ReceptDTO oldRecept in tmpRecept)
                    oldRecept.SetZdravstveniKarton((ZdravstveniKartonDTO)null);
                tmpRecept.Clear();
            }
        }
        public List<TerminDTO> termin;

        /// <pdGenerated>default getter</pdGenerated>
        public List<TerminDTO> GetTermin()
        {
            if (termin == null)
                termin = new List<TerminDTO>();
            return termin;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetTermin(System.Collections.ArrayList newTermin)
        {
            RemoveAllTermin();
            foreach (TerminDTO oTermin in newTermin)
                AddTermin(oTermin);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTermin(TerminDTO newTermin)
        {
            if (newTermin == null)
                return;
            if (this.termin == null)
                this.termin = new List<TerminDTO>();
            if (!this.termin.Contains(newTermin))
            {
                this.termin.Add(newTermin);
                newTermin.SetZdravstveniKarton(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTermin(TerminDTO oldTermin)
        {
            if (oldTermin == null)
                return;
            if (this.termin != null)
                if (this.termin.Contains(oldTermin))
                {
                    this.termin.Remove(oldTermin);
                    oldTermin.SetZdravstveniKarton((ZdravstveniKartonDTO)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTermin()
        {
            if (termin != null)
            {
                System.Collections.ArrayList tmpTermin = new System.Collections.ArrayList();
                foreach (TerminDTO oldTermin in termin)
                    tmpTermin.Add(oldTermin);
                termin.Clear();
                foreach (TerminDTO oldTermin in tmpTermin)
                    oldTermin.SetZdravstveniKarton((ZdravstveniKartonDTO)null);
                tmpTermin.Clear();
            }
        }
        public Pacijent patient { get; set; }

        public StanjePacijentaEnum ZdravstvenoStanje { get; set; }
        public String Alergije { get; set; }
        public KrvnaGrupaEnum KrvnaGrupa { get; set; }
        public String Vakcine { get; set; }
        public void dodajAlergije(string dodaj)
        {
            this.Alergije = dodaj;
        }
    }
}
