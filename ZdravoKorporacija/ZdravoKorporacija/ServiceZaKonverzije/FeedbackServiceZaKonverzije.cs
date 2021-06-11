using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.ServiceZaKonverzije
{
    class FeedbackServiceZaKonverzije
    {
        public FeedbackFormaDTO Model2DTO(FeedbackForma model)
        {
            FeedbackFormaDTO dto = new FeedbackFormaDTO(model.sadrzaj, model.uloga);
            return dto;
        }
        public FeedbackForma DTO2ModelNapravi(FeedbackFormaDTO dto)
        {
            FeedbackForma model = new FeedbackForma(dto.sadrzaj, dto.uloga);
            return model;
        }
        public FeedbackForma DTO2ModelNadji(FeedbackFormaDTO dto)
        {
            FeedbackRepozitorijum repozitorijum = new FeedbackRepozitorijum();
            List<FeedbackForma> forme = repozitorijum.DobaviSve();
            FeedbackForma ret = null;
            foreach (FeedbackForma ff in forme)
            {
                if (ff != null)
                    if (ff.sadrzaj.Equals(dto.sadrzaj) && ff.uloga.Equals(dto.uloga))
                        ret = ff;
            }
            return ret;
        }
        public List<FeedbackForma> PregledSvihFormi2Model(List<FeedbackFormaDTO> dtos)
        {
            List<FeedbackForma> modeli = new List<FeedbackForma>();
            foreach (FeedbackFormaDTO dto in dtos)
            {
                modeli.Add(DTO2ModelNadji(dto));
            }
            return modeli;
        }
        public List<FeedbackFormaDTO> PregledSvihFormi2DTO(List<FeedbackForma> modeli)
        {
            List<FeedbackFormaDTO> dtos = new List<FeedbackFormaDTO>();
            foreach (FeedbackForma ff in modeli)
            {
                dtos.Add(Model2DTO(ff));
            }
            return dtos;
        }
    }
}
