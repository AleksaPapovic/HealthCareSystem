using Model;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Service
{
    public class ProstorijaService
    {
        ProstorijaRepozitorijum datoteka = ProstorijaRepozitorijum.Instance;

        private static ProstorijaService _instance;

        public static ProstorijaService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProstorijaService();
                }
                return _instance;
            }
        }

        public bool DodajProstoriju(ProstorijaDTO prostorijaDTO)
        {
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");

            Dictionary<int, int> id_map = datotekaID.dobaviSve();
            int id = nadjiSlobodanID(id_map);
            id_map[id] = 1;
            prostorijaDTO.Id = id;


            Prostorija prostorija = new Prostorija(prostorijaDTO);
            ProstorijaRepozitorijum.Instance.prostorije.Add(prostorija);

            datoteka.sacuvaj();
            datotekaID.sacuvaj(id_map);
            return true;

        }

        public bool ObrisiProstoriju(ProstorijaDTO obrisanaProstorijaDTO)
        {
            Prostorija obrisanaProstorija = new Prostorija(obrisanaProstorijaDTO);
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");
            Dictionary<int, int> id_map = datotekaID.dobaviSve();
            id_map[obrisanaProstorija.Id] = 0;



            foreach (Prostorija prostorija in ProstorijaRepozitorijum.Instance.prostorije)
            {
                if (prostorija.Id == obrisanaProstorija.Id)
                {
                    ProstorijaRepozitorijum.Instance.prostorije.Remove(prostorija);
                    datoteka.sacuvaj();
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajProstoriju(ProstorijaDTO novaProstorijaDTO, int indeks)
        {
            Prostorija novaProstorija = new Prostorija(novaProstorijaDTO);
            foreach (Prostorija prostorija in ProstorijaRepozitorijum.Instance.prostorije)
            {
                if (prostorija.Id == novaProstorija.Id)
                {
                    ProstorijaRepozitorijum.Instance.prostorije.Remove(prostorija);
                    ProstorijaRepozitorijum.Instance.prostorije.Insert(indeks, novaProstorija);
                    datoteka.sacuvaj();
                    return true;
                }
            }
            return false;
        }

        public Prostorija PregledProstorije(string id)
        {
            foreach (Prostorija pr in ProstorijaRepozitorijum.Instance.prostorije)
            {
                if (pr.Id.Equals(id))
                {
                    return pr;
                }
            }
            return null;
        }

        public ObservableCollection<Prostorija> PregledSvihProstorija()
        {
            return datoteka.dobaviSve();
        }

        public ObservableCollection<ProstorijaDTO> PregledSvihProstorijaDTO()
        {
            ObservableCollection<Prostorija> prostorije = datoteka.dobaviSve();
            ObservableCollection<ProstorijaDTO> prostorijeDTO = new ObservableCollection<ProstorijaDTO>();
            foreach (Prostorija prostorija in prostorije)
            {
                prostorijeDTO.Add(konvertujEntitetUDTO(prostorija));
            }
            return prostorijeDTO;

        }

        public ProstorijaDTO konvertujEntitetUDTO(Prostorija prostorija)
        {
            return new ProstorijaDTO(prostorija);
        }

        private int nadjiSlobodanID(Dictionary<int, int> id_map)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    return id;
                }
            }
            return id;
        }

        public List<Prostorija> PregledSvihProstorija2Model(List<ProstorijaDTO> dtos)
        {
            List<Prostorija> modeli = new List<Prostorija>();
            foreach (ProstorijaDTO pdto in dtos)
            {
                modeli.Add(DTO2Model(pdto));
            }
            return modeli;
        }

        public ObservableCollection<ProstorijaDTO> PregledSvihProstorijaDTO(ObservableCollection<Prostorija> modeli)
        {
            if (modeli == null)
                modeli = PregledSvihProstorija();
            ObservableCollection<ProstorijaDTO> dtos = new ObservableCollection<ProstorijaDTO>();
            foreach (Prostorija model in modeli)
            {
                dtos.Add(Model2DTO(model));
            }
            return dtos;
        }

        public Prostorija DTO2Model(ProstorijaDTO dto)
        {
            if (dto != null)
                foreach (Prostorija p in PregledSvihProstorija())
                {
                    if (dto.Id.Equals(p.Id))
                        return p;
                }
            return null;
        }
        public ProstorijaDTO Model2DTO(Prostorija model)
        {
            ProstorijaDTO dto = null;
            if (model != null)
            {
                dto = new ProstorijaDTO(model.Id, model.Naziv, model.Tip, model.Slobodna, model.Sprat);

            }
            return dto;
        }
        public ObservableCollection<ProstorijaDTO> PregledSvihProstorija2()
        {
            ProstorijaRepozitorijum datoteka = new ProstorijaRepozitorijum();
            ObservableCollection<Prostorija> prostorije = datoteka.dobaviSve();
            ObservableCollection<ProstorijaDTO> prostorijeDTO = new ObservableCollection<ProstorijaDTO>();
            foreach (Prostorija Prostorija in prostorije)
            {
                prostorijeDTO.Add(convertToDTO(Prostorija));
            }
            return prostorijeDTO;
        }

        public ProstorijaDTO convertToDTO(Prostorija Prostorija)
        {
            return new ProstorijaDTO(Prostorija);
        }
    }
}
