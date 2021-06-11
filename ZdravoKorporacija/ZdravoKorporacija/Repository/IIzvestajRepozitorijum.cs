using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ZdravoKorporacija.Repository
{
    interface IIzvestajRepozitorijum
    {
        public ObservableCollection<Izvestaj> DobaviSve();

        public void Sacuvaj(ObservableCollection<Izvestaj> izvestaji);
    }
}
