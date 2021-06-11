using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ZdravoKorporacija.Repository
{
    public interface IReceptRepozitorijum
    {
        public ObservableCollection<Recept> DobaviSve();

        public void Sacuvaj(ObservableCollection<Recept> recepti);    
    }
}