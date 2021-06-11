using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Service;
using ZdravoKorporacija.ServiceZaKonverzije;

namespace ZdravoKorporacija.Controller
{
    class FeedbackFormaController
    {
        private FeedbackFormaService servis = new FeedbackFormaService();
        private FeedbackServiceZaKonverzije feedbackKonverzije = new FeedbackServiceZaKonverzije();

        public FeedbackFormaDTO Model2DTO(FeedbackForma model)
        {
            return feedbackKonverzije.Model2DTO(model);
        }
        public FeedbackForma DTO2ModelNapravi(FeedbackFormaDTO dto)
        {
            return feedbackKonverzije.DTO2ModelNapravi(dto);
        }
        public FeedbackForma DTO2ModelNadji(FeedbackFormaDTO dto)
        {
            return feedbackKonverzije.DTO2ModelNadji(dto);
        }
        public List<FeedbackForma> PregledSvihFormi()
        {
            return servis.PregledSvihFormi();
        }
        public List<FeedbackForma> PregledSvihFormi2Model(List<FeedbackFormaDTO> dtos)
        {
            return feedbackKonverzije.PregledSvihFormi2Model(dtos);
        }
        public List<FeedbackFormaDTO> PregledSvihFormi2DTO(List<FeedbackForma> modeli)
        {
            return feedbackKonverzije.PregledSvihFormi2DTO(modeli);
        }
        public bool ObrisiFormu(string sadrzaj)
        {
            return servis.ObrisiFormu(sadrzaj);
        }
        public bool DodajFormu(FeedbackFormaDTO forma)
        {
            return servis.DodajFormu(forma);
        }
    }
}
