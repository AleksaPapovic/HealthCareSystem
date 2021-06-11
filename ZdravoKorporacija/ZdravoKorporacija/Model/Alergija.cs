using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.Model
{
    class Alergija
    {
        public String Naziv { get; set; }
        public String Opis { get; set; }

        public Alergija()
        {

        }

        public Alergija(String Naziv, String Opis)
        {
            this.Naziv = Naziv;
            this.Opis = Opis;
        }
    }
}
