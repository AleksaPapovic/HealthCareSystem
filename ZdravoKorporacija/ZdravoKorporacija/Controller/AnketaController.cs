using Model;
using Service;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Controller
{
    public class AnketaController
    {
        private AnketaKonverter anketaKonverter = new AnketaKonverter();
        private AnketaService anketaService = new AnketaService();
        private PacijentService pacijentService = new PacijentService();
        private TerminService terminService = new TerminService();

        public void dodajAnketuBolnice(AnketaDTO anketaDTO)
        {
            Anketa anketa = anketaKonverter.KonvertujDTOuEntitet(anketaDTO);
            anketaService.dodajAnketu(anketa);
        }

        public bool vecOcijenjen(TerminDTO terminDTO)
        {
            Termin termin = terminService.pronadjiEntitetZaDTO(terminDTO);
            return anketaService.vecOcijenjen(termin);

        }

        public AnketaDTO dobaviPosljednjuAnketuBolnice(PacijentDTO pacijentDTO)
        {
            Pacijent pacijent = pacijentService.pronadjiEntitetZaDTO(pacijentDTO);
            Anketa anketa = anketaService.dobaviPosljednjuAnketuBolnice(pacijent);
            return anketaKonverter.KonvertujEntitetUDTO(anketa);
        }

        public void dodajAnketuLjekara(AnketaDTO anketaDTO)
        {
            Anketa anketa = anketaKonverter.KonvertujDTOuEntitet(anketaDTO);
            anketaService.dodajAnketu(anketa);
        }

    }
}
