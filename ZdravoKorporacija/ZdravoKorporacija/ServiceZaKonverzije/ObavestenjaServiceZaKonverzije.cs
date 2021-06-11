using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.ServiceZaKonverzije
{
    class ObavestenjaServiceZaKonverzije
    {
        private Mediator mediator;
        public Notifikacija DTO2ModelNapravi(NotifikacijaDTO dto)
        {
            Notifikacija model = new Notifikacija();
            model.Id = dto.Id;
            model.Datum = dto.Datum;
            model.Tip = dto.Tip;
            model.Sadrzaj = dto.Sadrzaj;
            model.Status = dto.Status;

            return model;
        }
        public NotifikacijaDTO model2DTO(Notifikacija model)
        {
            NotifikacijaDTO dto = new NotifikacijaDTO();
            dto.Id = model.Id;
            dto.Datum = model.Datum;
            dto.Tip = model.Tip;
            dto.Sadrzaj = model.Sadrzaj;
            dto.Status = model.Status;

            return dto;
        }
        public Notifikacija DTO2Model(NotifikacijaDTO dto)
        {
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> obavestenja = datoteka.dobaviSve();
            Notifikacija ret = null;
            foreach (Notifikacija n in obavestenja)
            {
                if (n != null)
                    if (n.Sadrzaj.Equals(dto.Sadrzaj)) ;
                ret = n;
            }
            return ret;
        }
        public List<Notifikacija> PregledSvihObavestenja2Model(List<NotifikacijaDTO> dtos)
        {
            List<Notifikacija> modeli = new List<Notifikacija>();
            foreach (NotifikacijaDTO ndto in dtos)
            {
                modeli.Add(DTO2Model(ndto));
            }
            return modeli;
        }
        public List<NotifikacijaDTO> PregledSvihObavestenja2DTO(List<Notifikacija> modeli)
        {
            List<NotifikacijaDTO> dtos = new List<NotifikacijaDTO>();
            foreach (Notifikacija model in modeli)
            {
                if (model != null)
                    dtos.Add(model2DTO(model));
            }
            return dtos;
        }

    }
}
