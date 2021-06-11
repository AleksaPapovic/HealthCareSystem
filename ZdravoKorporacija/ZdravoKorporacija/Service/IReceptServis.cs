using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Repository
{
    interface IReceptServis
    {
        public bool DodajRecept(ReceptDTO recept);

        public bool ObrisiRecept(ReceptDTO recept);

        public bool AzurirajRecept(ReceptDTO recept);

        public ReceptDTO PregledRecept(string id);

        public ObservableCollection<ReceptDTO> PregledSvihRecepata();

        public ReceptDTO ConvertToDTO(Recept recept);

        public Recept ConvertToModel(ReceptDTO recept);
    }
}
