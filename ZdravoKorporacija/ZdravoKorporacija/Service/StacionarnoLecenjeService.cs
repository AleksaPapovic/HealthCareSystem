using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;
using ZdravoKorporacija.Stranice.StacionarnoLecenje;

namespace ZdravoKorporacija.Service
{
    class StacionarnoLecenjeService
    {

        StacionarnoLecenjeRepozitorijum rr = StacionarnoLecenjeRepozitorijum.Instance;
        ProstorijaService ps = ProstorijaService.Instance;
        public static ObservableCollection<StacionarnoLecenje> StacionarnaLecenja = StacionarnoLecenjeRepozitorijum.Instance.DobaviSve();
        IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapStacionarnoLecenje");
        Dictionary<int, int> id_map = new Dictionary<int, int>();

        private static StacionarnoLecenjeService _instance;

        public static StacionarnoLecenjeService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StacionarnoLecenjeService();
                }
                return _instance;
            }
        }
        public bool DodajStacionarnoLecenje(StacionarnoLecenjeDTO StacionarnoLecenje)
        {

            id_map = datotekaID.dobaviSve();
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    break;
                }
            }
            StacionarnoLecenje.Id = id;

            foreach (StacionarnoLecenje r in rr.DobaviSve())
            {
                if (r.Id.Equals(StacionarnoLecenje.Id))
                {
                    return false;
                }
            }

            StacionarnaLecenja.Add(ConvertToModel(StacionarnoLecenje));
            rr.Sacuvaj(StacionarnaLecenja);
            datotekaID.sacuvaj(id_map);
            return true;
        }

        public ObservableCollection<ProstorijaDTO> DobaviSlobodneProstorijeStacionarno(DateTime Pocetak, String trajanje)
        {
            ObservableCollection<ProstorijaDTO> slobodneProstorije = ps.PregledSvihProstorija2();


            foreach (StacionarnoLecenjeDTO s in PregledSvihStacionarnih())
            {
                if (Pocetak != null && trajanje.Length!=0)
                    if (s.Pocetak.AddDays(Double.Parse(s.Trajanje))>=(Pocetak.AddDays(Double.Parse(trajanje))) && Pocetak>=s.Pocetak)
                    {
                        foreach (ProstorijaDTO p in slobodneProstorije)
                        {
                            if (s.Prostorija.Id.Equals(p.Id))
                            {
                                slobodneProstorije.Remove(p);
                                return slobodneProstorije;
                            }
                        }
                    }
            }
            return slobodneProstorije;
        }

        public bool ObrisiStacionarnoLecenje(StacionarnoLecenjeDTO StacionarnoLecenje)
        {
            foreach (StacionarnoLecenje r in StacionarnaLecenja)
            {
                if (r.Id.Equals(StacionarnoLecenje.Id))
                {
                    StacionarnaLecenja.Remove(r);
                    rr.Sacuvaj(StacionarnaLecenja);
                    id_map = datotekaID.dobaviSve();
                    id_map[StacionarnoLecenje.Id] = 0;
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajStacionarnoLecenje(StacionarnoLecenjeDTO StacionarnoLecenje)
        {
            foreach (StacionarnoLecenje r in StacionarnaLecenja)
            {
                if (r.Id.Equals(StacionarnoLecenje.Id))
                {
                    StacionarnaLecenja.Remove(r);
                    StacionarnaLecenja.Add(new StacionarnoLecenje(StacionarnoLecenje));
                    rr.Sacuvaj(StacionarnaLecenja);
                    uputiZaStacionarno.uputi.Add(StacionarnoLecenje);
                    return true;
                }
            }
            return false;
        }

        public StacionarnoLecenjeDTO PregledStacionarnoLecenje(string id)
        {
            foreach (StacionarnoLecenje r in StacionarnaLecenja)
            {
                if (r.Id.Equals(id))
                {
                    return new StacionarnoLecenjeDTO(r);
                }
            }
            return null;
        }

        public ObservableCollection<StacionarnoLecenjeDTO> PregledSvihStacionarnih()
        {
            ObservableCollection<StacionarnoLecenje> StacionarnaLecenja = rr.DobaviSve();
            ObservableCollection<StacionarnoLecenjeDTO> StacionarnoLecenjeDTOs = new ObservableCollection<StacionarnoLecenjeDTO>();
            foreach (StacionarnoLecenje r in StacionarnaLecenja)
            {
                StacionarnoLecenjeDTOs.Add(new StacionarnoLecenjeDTO(r));
            }
            return StacionarnoLecenjeDTOs;
        }

        public StacionarnoLecenjeDTO ConvertToDTO(StacionarnoLecenje StacionarnoLecenje)
        {
            return new StacionarnoLecenjeDTO(StacionarnoLecenje);
        }

        public StacionarnoLecenje ConvertToModel(StacionarnoLecenjeDTO StacionarnoLecenje)
        {
            return new StacionarnoLecenje(StacionarnoLecenje);
        }

    }
}
