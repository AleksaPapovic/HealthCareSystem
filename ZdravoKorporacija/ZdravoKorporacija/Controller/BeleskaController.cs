using Model;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Controller
{
    public class BeleskaController
    {
        private BeleskaKonverter beleskaKonverter = new BeleskaKonverter();
        private BeleskaService beleskaServis = new BeleskaService();
        private ObavestenjaService obavestenjaServis = new ObavestenjaService();

        public void sacuvajBelesku(BeleskaDTO beleskaDto)
        {
            Beleska beleska = beleskaKonverter.KonvertujDTOuEntitet(beleskaDto);
            beleskaServis.sacuvajBelesku(beleska);
        }

        public List<BeleskaDTO> dobaviBeleskaDTOs()
        {
            return (List<BeleskaDTO>)beleskaKonverter.KonvertujEntiteteUDTOS(beleskaServis.dobaviSveBeleske());
        }

    }
}
