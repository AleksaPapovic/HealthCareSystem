using System;

namespace Model
{
    public class RadniDan
    {
        public RadniDan()
        {
            odmor = false;
            prvaSmena = false;
        }

        public RadniDan(DateTime dan, double jmbgLekara, bool odmor, bool prvaSmena)
        {
            this.dan = dan;
            this.lekar = jmbgLekara;
            this.odmor = odmor;
            this.prvaSmena = prvaSmena;
        }

        public DateTime dan { get; set; }
        public double lekar { get; set; }
        public bool odmor { get; set; }
        public bool prvaSmena { get; set; }
    }
}
