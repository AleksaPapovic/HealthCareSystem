using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Controller;

namespace ZdravoKorporacija.Factory
{
    interface ReceptControllerFactory
    {
        public static IReceptController Create()
        {
            return ReceptController.Instance;
            //return new ReceptController();
        }
    }
}
