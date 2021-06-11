using Model;
using Service;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;

namespace ZdravoKorporacija.Controller
{
    public class KorisnikController
    {
        private KorisnikService ks = new KorisnikService();
        private PacijentService pacijentService = new PacijentService();
        private PacijentKonverter pacijentKonverter = new PacijentKonverter();

        public PacijentDTO ulogovaniPacijent(UlogaEnum uloga, string korisnickoIme, string lozinka)
        {
            //Korisnik ulogovan = ks.Uloguj(uloga, korisnickoIme, lozinka);

            Pacijent ulogovani = pacijentService.dobaviUlogovanog(korisnickoIme, lozinka);
            return pacijentKonverter.KonvertujEntitetUDTO(ulogovani);
        }
       

    }



}

