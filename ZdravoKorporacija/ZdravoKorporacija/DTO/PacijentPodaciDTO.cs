using Model;
using System;

namespace ZdravoKorporacija.DTO
{
    public class PacijentPodaciDTO
    {
        public PacijentPodaciDTO(string ime, string prezime, long jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol)
        {
            Ime = ime;
            Prezime = prezime;
            Jmbg = jmbg;
            BrojTelefona = brojTelefona;
            Mejl = mejl;
            AdresaStanovanja = adresaStanovanja;
            Pol = pol;
        }

        public String Ime { get; set; }
        public String Prezime { get; set; }
        public Int64 Jmbg { get; set; }
        public int BrojTelefona { get; set; }
        public String Mejl { get; set; }
        public String AdresaStanovanja { get; set; }
        public PolEnum Pol { get; set; }


    }
}
