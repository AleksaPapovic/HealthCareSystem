using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Controller
{
    public interface IReceptController
    {
        public ObservableCollection<ReceptDTO> PregledSvihRecepata();

        public bool DodajRecept(ReceptDTO recept);

        public bool ObrisiRecept(ReceptDTO recept);

        public bool AzurirajRecept(ReceptDTO recept);

        public ReceptDTO PregledRecept(string id);
    }
}
