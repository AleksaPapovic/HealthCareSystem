using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Service
{
    interface IIzvestajService
    {
        public bool DodajIzvestaj(IzvestajDTO izvestaj, Dictionary<int, int> id_map);

        public bool ObrisiIzvestaj(IzvestajDTO izvestaj, Dictionary<int, int> id_map);

        public bool AzurirajIzvestaj(IzvestajDTO izvestaj);

        public IzvestajDTO PregledIzvestaj(string id);

        public ObservableCollection<IzvestajDTO> PregledSvihIzvestaja();
    }
}
