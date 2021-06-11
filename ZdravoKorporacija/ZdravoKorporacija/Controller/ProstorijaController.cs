using Model;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Controller
{
    public class ProstorijaController
    {
        ProstorijaService prostorijaService = new ProstorijaService();

        private static ProstorijaController _instance;

        public static ProstorijaController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProstorijaController();
                }
                return _instance;
            }
        }

        public bool DodajProstoriju(ProstorijaDTO prostorijaDTO)
        {
            return prostorijaService.DodajProstoriju(prostorijaDTO);
        }

        public bool AzurirajProstoriju(ProstorijaDTO novaProstorijaDTO, int indeks)
        {
            return prostorijaService.AzurirajProstoriju(novaProstorijaDTO, indeks);
        }

        public ObservableCollection<Prostorija> PregledSvihProstorija()
        {
            return prostorijaService.PregledSvihProstorija();
        }

        public ObservableCollection<ProstorijaDTO> PregledSvihProstorijaDTO()
        {
            return prostorijaService.PregledSvihProstorijaDTO();
        }

        public bool ObrisiProstoriju(ProstorijaDTO prostorijaZaBrisanje)
        {
            return prostorijaService.ObrisiProstoriju(prostorijaZaBrisanje);
        }

        public ObservableCollection<ProstorijaDTO> PregledSvihProstorija2()
        {
            return prostorijaService.PregledSvihProstorija2();
        }
    }
}
