using Service;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Factory
{
    class ReceptServisFactory
    {
        public static IReceptServis Create()
        {
            return ReceptServis.Instance;
            //return new ReceptServis();
        }
    }
}
