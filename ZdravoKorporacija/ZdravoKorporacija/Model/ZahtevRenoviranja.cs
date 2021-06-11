using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;

namespace Model
{
    public class ZahtevRenoviranja
    {
        public int Id { get; set; }
        public Prostorija Prostorija { get; set; }

        public DateTime Pocetak { get; set; }

        public String PocetakSati { get; set; }

        public DateTime Kraj { get; set; }
        public String Trajanje { get; set; }

        public String Spajanje { get; set; }

        public String Razdvajanje { get; set; }

        public List<Prostorija> prostorije;

        public List<Prostorija> Getprostorije()
        {
            if (prostorije == null)
                prostorije = new List<Prostorija>();
            return prostorije;
        }

        public void Setprostorije(List<Prostorija> newProstorije)
        {
            RemoveAllprostorije();
            foreach (Prostorija oProstorija in newProstorije)
                Addprostorije(oProstorija);
        }

        public void Addprostorije(Prostorija newProstorija)
        {
            if (newProstorija == null)
                return;
            if (this.prostorije == null)
                this.prostorije = new List<Prostorija>();
            if (!this.prostorije.Contains(newProstorija))
                this.prostorije.Add(newProstorija);
        }

        public void Removeprostorije(Prostorija oldProstorija)
        {
            if (oldProstorija == null)
                return;
            if (this.prostorije != null)
                if (this.prostorije.Contains(oldProstorija))
                    this.prostorije.Remove(oldProstorija);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllprostorije()
        {
            if (prostorije != null)
                prostorije.Clear();
        }

        public ZahtevRenoviranja() { }


        public ZahtevRenoviranja(int id, Prostorija prostorija, DateTime pocetak, DateTime kraj, String trajanje, String pocetakSati, String spajanje, String razdvajanje)
        {
            Id = id;
            Prostorija = prostorija;
            Pocetak = pocetak;
            PocetakSati = pocetakSati;
            Kraj = kraj;
            Trajanje = trajanje;
            Spajanje = spajanje;
            Razdvajanje = razdvajanje;
            prostorije = new List<Prostorija>();
        }

        public ZahtevRenoviranja(ZahtevRenoviranjeDTO zahtevRenoviranjaDTO)
        {
            Id = zahtevRenoviranjaDTO.Id;
            Prostorija = new Prostorija(zahtevRenoviranjaDTO.Prostorija);
            Pocetak = zahtevRenoviranjaDTO.PocetakDan;
            PocetakSati = zahtevRenoviranjaDTO.PocetakSati;
            Trajanje = zahtevRenoviranjaDTO.Trajanje;
            Spajanje = zahtevRenoviranjaDTO.Spajanje;
            Razdvajanje = zahtevRenoviranjaDTO.Razdvajanje;
            Kraj = zahtevRenoviranjaDTO.Kraj;
            prostorije = konvertujListuProstorijaDTOUListuProstorija(zahtevRenoviranjaDTO.prostorije);
        }

        public List<Prostorija> konvertujListuProstorijaDTOUListuProstorija(List<ProstorijaDTO> prostorijeDTO)
        {
            List<Prostorija> prostorije = new List<Prostorija>();
            if (prostorijeDTO != null)
            {

                foreach (ProstorijaDTO prostorijaDTO in prostorijeDTO)
                {
                    prostorije.Add(new Prostorija(prostorijaDTO));
                }

            }
            return prostorije;
        }

    }
}
