using System;

namespace ZdravoKorporacija.DTO
{
    class RadniDanDTO
    {
        public RadniDanDTO()
        {
            odmor = false;
            prvaSmena = false;
        }

        public RadniDanDTO(DateTime dan, double jmbg, bool odmor, bool prvaSmena)
        {
            this.dan = dan;
            this.lekar = jmbg;
            this.odmor = odmor;
            this.prvaSmena = prvaSmena;
        }



        public DateTime dan { get; set; }
        public double lekar { get; set; }
        public bool odmor { get; set; }
        public bool prvaSmena { get; set; }
    }
}
