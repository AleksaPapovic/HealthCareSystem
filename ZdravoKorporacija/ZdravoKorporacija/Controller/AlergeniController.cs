using Model;
using Service;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Controller
{
    class AlergeniController

    {
        private ZdravstveniKartonServis kartonServis = new ZdravstveniKartonServis();
        public bool KreirajZdravstveniKartonJMBG(ZdravstveniKarton ZdravstveniKarton)
        {
            return kartonServis.KreirajZdravstveniKartonJMBG(ZdravstveniKarton);
        }
        public bool ObrisiZdravstveniKarton(ZdravstveniKarton zdravstveniKarton, Dictionary<int, int> id_map)
        {
            return kartonServis.ObrisiZdravstveniKarton(zdravstveniKarton, id_map);
        }
        public ZdravstveniKarton findById(long id)
        {
            return kartonServis.findById(id);
        }
        public bool AzurirajZdravstveniKarton(ZdravstveniKarton zdravstveniKarton)
        {
            return kartonServis.AzurirajZdravstveniKarton(zdravstveniKarton);
        }
        public List<ZdravstveniKarton> PregledSvihZdravstvenihKartona()
        {
            return kartonServis.PregledSvihZdravstvenihKartona();
        }
        public ZdravstveniKartonDTO Model2DTO(ZdravstveniKarton model)
        {
            return kartonServis.Model2DTO(model);
        }
        public ZdravstveniKarton DTO2Model(ZdravstveniKartonDTO dto)
        {
            return kartonServis.DTO2Model(dto);
        }
        public void DodajAlergen(ZdravstveniKartonDTO k1DTO, ZdravstveniKartonDTO k2DTO, string alergija, Pacijent pacijent)
        {
            kartonServis.DodajAlergen(k1DTO, k2DTO, alergija, pacijent);
        }
    }
}
