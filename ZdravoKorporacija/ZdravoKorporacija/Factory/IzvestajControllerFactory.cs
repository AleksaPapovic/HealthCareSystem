using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Controller;

namespace ZdravoKorporacija.Factory
{
    class IzvestajControllerFactory
    {
        public static IIzvestajController Create()
        {
            return IzvestajController.Instance;
            //return new IzvestajController();
        }
    }
}
