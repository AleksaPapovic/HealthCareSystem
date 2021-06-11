using Service;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Controller
{
    class LekController
    {
        LekServis lekServis = new LekServis();
        private static LekController _instance;
        public static LekController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LekController();
                }
                return _instance;
            }
        }
        public List<LekDTO> PregledSvihLekova()
        {
            return lekServis.PregledSvihLekova2();
        }
    }
}
