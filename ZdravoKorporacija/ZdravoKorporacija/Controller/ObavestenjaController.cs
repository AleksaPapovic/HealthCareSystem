using Model;
using System;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Service;
using ZdravoKorporacija.ServiceSekretarUtility;
using ZdravoKorporacija.ServiceZaKonverzije;

namespace ZdravoKorporacija.Controller
{
    class ObavestenjaController
    {
        private ObavestenjaService obavestenjaServis = new ObavestenjaService();
        private ObavestenjaServiceZaKonverzije obavestenjaKonverzije = new ObavestenjaServiceZaKonverzije();
        private ObavestenjaSekretarUtility obavestenjaSekretar = new ObavestenjaSekretarUtility();
        public void generisiObavestenja()
        {
            obavestenjaSekretar.generisiObavestenja();
        }
        public List<Notifikacija> pregled()
        {
           return obavestenjaServis.PregledSvihObavestenja();
        }
        public bool dodajObavestenje(Notifikacija not)
        {
            return obavestenjaServis.dodajObavestenje(not);
        }
        public bool obrisiObavestenje(String not)
        {
            return obavestenjaServis.obrisiObavestenje(not);
        }
        public Notifikacija DTO2ModelNapravi(NotifikacijaDTO dto)
        {
            return obavestenjaKonverzije.DTO2ModelNapravi(dto);
        }
        public NotifikacijaDTO model2DTO(Notifikacija model)
        {
            return obavestenjaKonverzije.model2DTO(model);
        }
        public Notifikacija DTO2Model(NotifikacijaDTO dto)
        {
            return obavestenjaKonverzije.DTO2Model(dto);
        }
        public List<Notifikacija> PregledSvihObavestenja()
        {
            return obavestenjaServis.PregledSvihObavestenja();
        }
        public List<Notifikacija> PregledSvihObavestenja2Model(List<NotifikacijaDTO> dtos)
        {
            return obavestenjaKonverzije.PregledSvihObavestenja2Model(dtos);
        }
        public List<NotifikacijaDTO> PregledSvihObavestenja2DTO(List<Notifikacija> modeli)
        {
            return obavestenjaKonverzije.PregledSvihObavestenja2DTO(modeli);
        }

    }
}
