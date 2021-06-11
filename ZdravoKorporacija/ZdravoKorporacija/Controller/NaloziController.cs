using Model;
using Service;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    class NaloziController
    {
        private PacijentService pacijentServis = new PacijentService();
        private LekarService lekarServis = new LekarService();
        private TerminService terminServis = new TerminService();
        private ZdravstveniKartonServis kartonSerivs = new ZdravstveniKartonServis();

        public bool KreirajNalogPacijentu(Pacijent pacijent)
        {
            return pacijentServis.KreirajNalogPacijentu(pacijent);
        }

        public Pacijent DTO2Model(PacijentDTO dto)
        {
            return pacijentServis.DTO2Model(dto);
        }
        public Pacijent DTO2ModelNapravi(PacijentDTO dto)
        {
            return pacijentServis.DTO2ModelNapravi(dto);
        }
        public bool AzurirajPacijenta(Pacijent pacijent)
        {
            return pacijentServis.AzurirajPacijenta(pacijent);
        }
        public bool DodajLekara(Lekar lekar)
        {
            return lekarServis.DodajLekara(lekar);
        }
        public Lekar DTO2ModelNapravi(LekarDTO dto)
        {
            return lekarServis.DTO2ModelNapravi(dto);
        }
    }
}
