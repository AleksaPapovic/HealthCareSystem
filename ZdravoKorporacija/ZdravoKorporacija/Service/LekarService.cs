using Model;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace Service
{
    public class LekarService
    {
        public List<Lekar> PregledSvihLekara()
        {
            LekarRepozitorijum datoteka = new LekarRepozitorijum();
            List<Lekar> lekari = datoteka.dobaviSve();
            return lekari;
        }
        public bool ObrisiLekara(Lekar lekar)
        {
            LekarRepozitorijum datoteka = new LekarRepozitorijum();
            List<Lekar> lekari = datoteka.dobaviSve();
            foreach (Lekar l in lekari)
            {
                if (l.Jmbg.Equals(lekar.Jmbg))
                {
                    lekari.Remove(l);
                    datoteka.sacuvaj(lekari);
                    return true;
                }
            }
            return false;
        }

        public Lekar DTO2Model(LekarDTO dto)
        {
            if (dto != null)
                foreach (Lekar l in PregledSvihLekara())
                {
                    if (dto.Jmbg.Equals(l.Jmbg))
                        return l;
                }
            return null;
        }
        public LekarDTO Model2DTO(Lekar model)
        {
            LekarDTO dto = new LekarDTO();
            if (model != null) { 
                dto = new LekarDTO(model.Ime, model.Prezime, model.Jmbg, model.BrojTelefona, model.Mejl, model.AdresaStanovanja, model.Pol, model.Username, model.Password);
                dto.Specijalizacija = model.Specijalizacija;
            }
            return dto;
        }

        public List<Lekar> PregledSvihLekaraModel(List<LekarDTO> dtos)
        {
            List<Lekar> modeli = new List<Lekar>();
            foreach (LekarDTO ldto in dtos)
            {
                modeli.Add(DTO2Model(ldto));
            }
            return modeli;
        }

        public List<LekarDTO> PregledSvihLekaraDTO(List<Lekar> modeli)
        {
            if (modeli == null)
                modeli = PregledSvihLekara();
            List<LekarDTO> dtos = new List<LekarDTO>();
            foreach (Lekar l in modeli)
            {
                if (l != null)
                    dtos.Add(Model2DTO(l));
            }
            return dtos;
        }
        public void AzurirajLekare()
        {
            LekarRepozitorijum datoteka = new LekarRepozitorijum();
            List<Lekar> lekari = datoteka.dobaviSve();
            datoteka.sacuvaj(lekari);
        }
        public bool DodajLekara(Lekar lekar)
        {
            LekarRepozitorijum datoteka = new LekarRepozitorijum();
            List<Lekar> lekari = datoteka.dobaviSve();
            foreach (Lekar l in lekari)
            {
                if (l.Jmbg.Equals(lekar))
                {
                    return false;
                }
            }
            lekari.Add(lekar);
            datoteka.sacuvaj(lekari);
            return true;
        }

        internal bool AzurirajLekara(Lekar lekar)
        {
            LekarRepozitorijum datoteka = new LekarRepozitorijum();
            List<Lekar> lekari = datoteka.dobaviSve();
            if (lekar != null)
                foreach (Lekar l in lekari)
                {
                    if (l.Jmbg.Equals(lekar.Jmbg))
                    {
                        lekari.Remove(l);
                        lekari.Add(lekar);
                        datoteka.sacuvaj(lekari);
                        return true;
                    }
                }
            return false;
        }

        public Lekar DTO2ModelNapravi(LekarDTO dto)
        {
            Lekar model = new Lekar(dto.Ime, dto.Prezime, dto.Jmbg, dto.BrojTelefona, dto.Mejl, dto.AdresaStanovanja, dto.Pol, dto.Username, dto.Password);
            model.Specijalizacija= dto.Specijalizacija;
            return model;

        }
        public Lekar NadjiLekaraPoJMBG(long jmbg)
        {
            foreach (Lekar l in PregledSvihLekara())
            {
                if (l.Jmbg.Equals(jmbg))
                    return l;
            }
            return null;
        }
    }

}
