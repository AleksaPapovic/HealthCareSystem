using System;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Controller
{
    class StacionarnoLecenjeController
    {
        private StacionarnoLecenjeService sl = StacionarnoLecenjeService.Instance;
        private static StacionarnoLecenjeController _instance;

        public static StacionarnoLecenjeController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StacionarnoLecenjeController();
                }
                return _instance;
            }
        }

        public ObservableCollection<ProstorijaDTO> DobaviSlobodneProstorijeStacionarno(DateTime Pocetak, String trajanje)
        {
            return sl.DobaviSlobodneProstorijeStacionarno(Pocetak, trajanje);
        }
            public bool DodajStacionarnoLecenje(StacionarnoLecenjeDTO StacionarnoLecenje)
        {
            return sl.DodajStacionarnoLecenje(StacionarnoLecenje);
        }

        public bool ObrisiStacionarnoLecenje(StacionarnoLecenjeDTO StacionarnoLecenje)
        {
            return sl.ObrisiStacionarnoLecenje(StacionarnoLecenje);
        }

        public bool AzurirajStacionarnoLecenje(StacionarnoLecenjeDTO StacionarnoLecenje)
        {
            return sl.AzurirajStacionarnoLecenje(StacionarnoLecenje);
        }

        public StacionarnoLecenjeDTO PregledStacionarnoLecenje(string id)
        {
            return sl.PregledStacionarnoLecenje(id);
        }

        public ObservableCollection<StacionarnoLecenjeDTO> PregledSvihStacionarnih()
        {
            return sl.PregledSvihStacionarnih();
        }

    }
}
