using Model;
using System;
using System.Collections.Generic;

namespace ZdravoKorporacija.DTO
{
    public class ReceptDTO
    {
        public int Id { get; set; }
        public String Doziranje { get; set; }
        public int Trajanje { get; set; }
        public String NazivLeka { get; set; }
        public DateTime Pocetak { get; set; }

        public List<LekDTO> lek;
        public ReceptDTO()
        { }

        /// <pdGenerated>default getter</pdGenerated>
        public List<LekDTO> GetLek()
        {
            if (lek == null)
                lek = new List<LekDTO>();
            return lek;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetLek(List<LekDTO> newLek)
        {
            RemoveAllLek();
            foreach (LekDTO oLek in newLek)
                AddLek(oLek);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddLek(LekDTO newLek)
        {
            if (newLek == null)
                return;
            if (this.lek == null)
                this.lek = new List<LekDTO>();
            if (!this.lek.Contains(newLek))
                this.lek.Add(newLek);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveLek(LekDTO oldLek)
        {
            if (oldLek == null)
                return;
            if (this.lek != null)
                if (this.lek.Contains(oldLek))
                    this.lek.Remove(oldLek);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllLek()
        {
            if (lek != null)
                lek.Clear();
        }
        public LekarDTO Lekar;
        public ZdravstveniKartonDTO zdravstveniKarton;

        public ReceptDTO(int id, string doziranje, int trajanje, string nazivLeka, DateTime pocetak, LekarDTO lekar)
        {
            Id = id;
            Doziranje = doziranje;
            Trajanje = trajanje;
            NazivLeka = nazivLeka;
            Pocetak = pocetak;
            this.Lekar = lekar;
        }

        public ReceptDTO(int id, string doziranje, int trajanje, string nazivLeka, DateTime pocetak, LekarDTO lekar, ZdravstveniKartonDTO zdravstveniKarton)
        {
            Id = id;
            Doziranje = doziranje;
            Trajanje = trajanje;
            NazivLeka = nazivLeka;
            Pocetak = pocetak;
            Lekar = lekar;
            this.zdravstveniKarton = zdravstveniKarton;
        }

        public ReceptDTO(Recept recept)
        {
            Id = recept.Id;
            Doziranje = recept.Doziranje;
            Trajanje = recept.Trajanje;
            NazivLeka = recept.NazivLeka;
            Pocetak = recept.Pocetak;
            this.Lekar = new LekarDTO(recept.lekar);
        }

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
                    oldZdravstveniKarton.RemoveRecept(this);
                }
                if (newZdravstveniKarton != null)
                {
                    this.zdravstveniKarton = newZdravstveniKarton;
                    this.zdravstveniKarton.AddRecept(this);
                }
            }
        }
    }
}
