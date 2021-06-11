using Service;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Factory
{
    class IzvestajServiceFactory
    {
        public static IIzvestajService Create()
        {
            return IzvestajService.Instance;
            //return new IzvestajService();
        }
    }
}
