using Model;
using System;
using System.Collections.Generic;

namespace ZdravoKorporacija.DTO
{
    public class ZahtevRenoviranjeDTO
    {
        public int Id { get; set; }
        public ProstorijaDTO Prostorija { get; set; }

        public DateTime PocetakDan { get; set; }

        public String PocetakSati { get; set; }
        public String Trajanje { get; set; }

        public DateTime Kraj { get; set; }
        public String Spajanje { get; set; }

        public String Razdvajanje { get; set; }

        public List<ProstorijaDTO> prostorije;

        public List<ProstorijaDTO> Getprostorije()
        {
            if (prostorije == null)
                prostorije = new List<ProstorijaDTO>();
            return prostorije;
        }

        public void Setprostorije(List<ProstorijaDTO> newProstorije)
        {
            RemoveAllprostorije();
            foreach (ProstorijaDTO oProstorija in newProstorije)
                Addprostorije(oProstorija);
        }

        public void Addprostorije(ProstorijaDTO newProstorija)
        {
            if (newProstorija == null)
                return;
            if (this.prostorije == null)
                this.prostorije = new List<ProstorijaDTO>();
            if (!this.prostorije.Contains(newProstorija))
                this.prostorije.Add(newProstorija);
        }

        public void Removeprostorije(ProstorijaDTO oldProstorija)
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



        public ZahtevRenoviranjeDTO() { }
        public ZahtevRenoviranjeDTO(int id, ProstorijaDTO prostorija, DateTime pocetakD,String pocetakS, String trajanje,String spajanje,String razdvajanje)
        {
            Id = id;
            Prostorija = prostorija;
            PocetakDan = pocetakD;
            PocetakSati = pocetakS;
            Trajanje = trajanje;
            Spajanje = spajanje;
            Razdvajanje = razdvajanje;
            prostorije = new List<ProstorijaDTO>();
        }

        public ZahtevRenoviranjeDTO(ZahtevRenoviranja zahtevRenoviranja ) 
        {
            Id = zahtevRenoviranja.Id;
            Prostorija = new ProstorijaDTO(zahtevRenoviranja.Prostorija);
            PocetakDan = zahtevRenoviranja.Pocetak;
            PocetakSati = zahtevRenoviranja.PocetakSati;
            Trajanje = zahtevRenoviranja.Trajanje;
            Kraj = zahtevRenoviranja.Kraj;
            Spajanje = zahtevRenoviranja.Spajanje;
            Razdvajanje = zahtevRenoviranja.Razdvajanje;
            prostorije = konvertujListuProstorijaUListuDTO(zahtevRenoviranja.prostorije);
        }

        public List<ZahtevRenoviranjeDTO> konvertujListuEntitetaUListuDTO(List<ZahtevRenoviranja> zahtevi)
        {
            List<ZahtevRenoviranjeDTO> zahteviDTO = new List<ZahtevRenoviranjeDTO>();
            if (zahtevi != null)
            {

                foreach (ZahtevRenoviranja zahtev in zahtevi)
                {
                    zahteviDTO.Add(new ZahtevRenoviranjeDTO(zahtev));
                }

            }
            return zahteviDTO;
        }

        public List<ProstorijaDTO> konvertujListuProstorijaUListuDTO(List<Prostorija> prostorije)
        {
            List<ProstorijaDTO> prostorijeDTO = new List<ProstorijaDTO>();
            if (prostorije != null)
            {

                foreach (Prostorija prostorija in prostorije)
                {
                    prostorijeDTO.Add(new ProstorijaDTO(prostorija));
                }

            }
            return prostorijeDTO;
        }




    }
}
