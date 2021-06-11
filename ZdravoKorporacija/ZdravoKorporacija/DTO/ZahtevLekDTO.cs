using Model;
using System;
using System.Collections.Generic;

namespace ZdravoKorporacija.DTO
{
    public class ZahtevLekDTO
    {
        public int Id { get; set; }
        public LekDTO Lek { get; set; }

        public String Komentar { get; set; }

        public List<Lekar> lekari;

        public List<Lekar> Getlekari()
        {
            if (lekari == null)
                lekari = new List<Lekar>();
            return lekari;
        }

        public void Setlekari(List<Lekar> newlekari)
        {
            RemoveAlllekari();
            foreach (Lekar oLekar in newlekari)
                Addlekari(oLekar);
        }

        public void Addlekari(Lekar newLekar)
        {
            if (newLekar == null)
                return;
            if (this.lekari == null)
                this.lekari = new List<Lekar>();
            if (!this.lekari.Contains(newLekar))
                this.lekari.Add(newLekar);
        }

        public void Removelekari(Lekar oldLekar)
        {
            if (oldLekar == null)
                return;
            if (this.lekari != null)
                if (this.lekari.Contains(oldLekar))
                    this.lekari.Remove(oldLekar);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAlllekari()
        {
            if (lekari != null)
                lekari.Clear();
        }

        public int NeophodnihPotvrda { get; set; }

        public int BrojPotvrda { get; set; }

        public ZahtevLekDTO(LekDTO lek, int neophodnihPotvrda, int brojTrenutnihPotvrda)
        {
            this.Lek = lek;
            this.NeophodnihPotvrda = neophodnihPotvrda;
            this.BrojPotvrda = brojTrenutnihPotvrda;
            this.lekari = new List<Lekar>();
            this.Lek.alternativniLekovi = new List<LekDTO>();
        }

        public ZahtevLekDTO(LekDTO lek, int neophodnihPotvrda, int brojTrenutnihPotvrda, String komentar)
        {
            this.Lek = lek;
            this.NeophodnihPotvrda = neophodnihPotvrda;
            this.BrojPotvrda = brojTrenutnihPotvrda;
            this.lekari = new List<Lekar>();
            this.Lek.alternativniLekovi = new List<LekDTO>();
            this.Komentar = komentar;
        }

        public ZahtevLekDTO(ZahtevLek zahtevLek)
        {
            this.Id = zahtevLek.Id;
            this.Lek = new LekDTO(zahtevLek.Lek);
            this.NeophodnihPotvrda = zahtevLek.NeophodnihPotvrda;
            this.BrojPotvrda = zahtevLek.BrojPotvrda;
            this.lekari = zahtevLek.lekari;
            this.Komentar = zahtevLek.Komentar;
        }

    }
}
