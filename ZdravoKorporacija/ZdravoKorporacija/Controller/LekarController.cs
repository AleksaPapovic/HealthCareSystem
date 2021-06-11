using Model;
using Service;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;

namespace ZdravoKorporacija.Controller
{
    public class LekarController
    {
        private LekarService servis = new LekarService();
        private LekarKonverter lekarKonverter;

        private static LekarController _instance;

        public static LekarController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LekarController();
                }
                return _instance;
            }
        }


        public LekarController()
        {
            this.lekarKonverter = new LekarKonverter();
            this.servis = new LekarService();
        }


        public IEnumerable<LekarDTO> dobaviListuDTOLekara()
            => servis.PregledSvihLekara().Select(entitet => lekarKonverter.KonvertujEntitetUDTO(entitet)).ToList();


        public List<LekarDTO> PregledSvihLekara()
        {
            List<Lekar> lekari = servis.PregledSvihLekara();
            List<LekarDTO> lekarDTOs = new List<LekarDTO>();
            foreach (Lekar l in lekari)
            {
                lekarDTOs.Add(new LekarDTO(l));
            }
            return lekarDTOs;
        }
        //public LekarDTO konvertujEntitetUDTO(Lekar entitet)
        //{
        //    return new LekarDTO(entitet);
        //}
    }


}