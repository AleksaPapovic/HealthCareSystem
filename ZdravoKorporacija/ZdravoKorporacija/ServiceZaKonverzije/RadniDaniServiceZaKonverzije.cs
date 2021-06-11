using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Repository;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.ServiceZaKonverzije
{
    class RadniDaniServiceZaKonverzije
    {
        public List<RadniDanDTO> PregledSvihRadnihDana2DTO(List<RadniDan> modeli)
        {
            
            List<RadniDanDTO> dtos = new List<RadniDanDTO>();
            foreach (RadniDan model in modeli)
            {
                dtos.Add(Model2DTO(model));
            }
            return dtos;
        }
        public List<RadniDan> PregledSvihRadnihDana2Model(List<RadniDanDTO> dtos)
        {
            List<RadniDan> modeli = new List<RadniDan>();
            foreach (RadniDanDTO rddto in dtos)
            {
                modeli.Add(DTO2Model(rddto));
            }
            return modeli;
        }

        public RadniDan DTO2Model(RadniDanDTO dto)
        {
            RadniDanRepozitorijum rep = new RadniDanRepozitorijum();
            List<RadniDan> dani = rep.dobaviSve();
            foreach (RadniDan rd in dani)
            {
                if (rd.dan.Date.Equals(dto.dan.Date) && rd.lekar.Equals(dto.lekar))
                {
                    return rd;
                }
            }
            return null;
        }
        public RadniDanDTO Model2DTO(RadniDan model)
        {
            RadniDanDTO dto = new RadniDanDTO(model.dan, model.lekar, model.odmor, model.prvaSmena);
            return dto;
        }
    }
}
