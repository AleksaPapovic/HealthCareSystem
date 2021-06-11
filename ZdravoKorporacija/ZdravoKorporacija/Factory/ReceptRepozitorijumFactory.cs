using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Factory
{
    public class ReceptRepozitorijumFactory
    {
        public static IReceptRepozitorijum Create()
        {
            return new ReceptRepozitorijum();
        }
    }
}
