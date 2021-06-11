using Model;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Factory;
using ZdravoKorporacija.Repository;

namespace Service
{
    public class ReceptServis: IReceptServis
    {
        public static ObservableCollection<Recept> recepti;
        IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRecept");
        Dictionary<int, int> id_map = new Dictionary<int, int>();

        private static ReceptServis _instance;

        private static IReceptRepozitorijum _receptRepozitorijum;


        public static ReceptServis Instance
        {
            get
            {
                if (_instance == null)
                {
                    _receptRepozitorijum = ReceptRepozitorijumFactory.Create();
                    _instance = new ReceptServis();
                    recepti = _receptRepozitorijum.DobaviSve();
                }
                return _instance;
            }
        }

        public bool DodajRecept(ReceptDTO recept)
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
            recept.Id = id;

            foreach (Recept r in _receptRepozitorijum.DobaviSve())
            {
                if (r.Id.Equals(recept.Id))
                {
                    return false;
                }
            }

            recepti.Add(ConvertToModel(recept));
            _receptRepozitorijum.Sacuvaj(recepti);
            datotekaID.sacuvaj(id_map);
            return true;
        }

        public bool ObrisiRecept(ReceptDTO recept)
        {
            id_map = datotekaID.dobaviSve();
            foreach (Recept r in recepti)
            {
                //Trace.WriteLine(recept.Id + r.Id);
                if (r.Id.Equals(recept.Id))
                {
                    recepti.Remove(r);
                    _receptRepozitorijum.Sacuvaj(recepti);
                    id_map[recept.Id] = 0;
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajRecept(ReceptDTO recept)
        {
            foreach (Recept r in recepti)
            {
                if (r.Id.Equals(recept.Id))
                {
                    recepti.Remove(r);
                    recepti.Add(new Recept(recept));
                    _receptRepozitorijum.Sacuvaj(recepti);
                    return true;
                }
            }
            return false;
        }

        public ReceptDTO PregledRecept(string id)
        {
            foreach (Recept r in recepti)
            {
                if (r.Id.Equals(id))
                {
                    return new ReceptDTO(r);
                }
            }
            return null;
        }

        public ObservableCollection<ReceptDTO> PregledSvihRecepata()
        {
            ObservableCollection<Recept> recepti = _receptRepozitorijum.DobaviSve();
            ObservableCollection<ReceptDTO> receptDTOs = new ObservableCollection<ReceptDTO>();
            foreach (Recept r in recepti)
            {
                receptDTOs.Add(new ReceptDTO(r));
            }
            return receptDTOs;
        }

        public ReceptDTO ConvertToDTO(Recept recept)
        {
            return new ReceptDTO(recept);
        }

        public Recept ConvertToModel(ReceptDTO recept)
        {
            return new Recept(recept);
        }

    }
}