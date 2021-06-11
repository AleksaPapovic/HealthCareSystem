using Service;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Factory;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Controller
{
    public class ReceptController: IReceptController
    {
        private static ReceptController _instance;
        private static IReceptServis _receptServis;
        public static ReceptController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _receptServis = ReceptServisFactory.Create();
                    _instance = new ReceptController();
                }
                return _instance;
            }
        }
        public ObservableCollection<ReceptDTO> PregledSvihRecepata()
        {
            return _receptServis.PregledSvihRecepata();
        }

        public bool DodajRecept(ReceptDTO recept)
        {
            return _receptServis.DodajRecept(recept);
        }

        public bool ObrisiRecept(ReceptDTO recept)
        {
            return _receptServis.ObrisiRecept(recept);
        }

        public bool AzurirajRecept(ReceptDTO recept)
        {
            return _receptServis.AzurirajRecept(recept);
        }

        public ReceptDTO PregledRecept(string id)
        {
            return _receptServis.PregledRecept(id);
        }
    }
}
