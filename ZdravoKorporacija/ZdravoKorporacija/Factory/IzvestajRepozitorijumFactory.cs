using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Factory
{
    interface IzvestajRepozitorijumFactory
    {
        public static IIzvestajRepozitorijum Create()
        {
            return new IzvestajRepozitorijum();
        }
    }
}
