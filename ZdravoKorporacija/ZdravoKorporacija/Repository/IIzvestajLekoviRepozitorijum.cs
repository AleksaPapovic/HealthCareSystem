using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Stranice.LekoviCRUD;

namespace Repository
{
    public interface IIzvestajLekoviRepozitorijum
    {
       public bool generisiIzvestaj(IzvestajLekovi izvestajLekovi);
    }
}
