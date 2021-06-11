using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Factory;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Controller
{
    class IzvestajController:IIzvestajController
    {
        
        private static IzvestajController _instance;
        private static IIzvestajService _izvestajServis;
        public static IzvestajController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _izvestajServis = IzvestajServiceFactory.Create();
                    _instance = new IzvestajController();
                }
                return _instance;
            }
        }

        public bool DodajIzvestaj(IzvestajDTO izvestaj, Dictionary<int, int> id_map)
        {

            return _izvestajServis.DodajIzvestaj(izvestaj, id_map);
        }

        public bool ObrisiIzvestaj(IzvestajDTO izvestaj, Dictionary<int, int> id_map)
        {
            return  _izvestajServis.ObrisiIzvestaj(izvestaj, id_map);
        }

        public bool AzurirajIzvestaj(IzvestajDTO izvestaj)
        {
            return  _izvestajServis.AzurirajIzvestaj(izvestaj);
        }

        public IzvestajDTO PregledIzvestaj(string id)
        {
            return  _izvestajServis.PregledIzvestaj(id);
        }

        public ObservableCollection<IzvestajDTO> PregledSvihIzvestaja()
        {
            return _izvestajServis.PregledSvihIzvestaja();
        }
    }
}
