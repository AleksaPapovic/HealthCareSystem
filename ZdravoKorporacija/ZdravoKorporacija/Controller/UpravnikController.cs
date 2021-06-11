using Model;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    public class UpravnikController
    {
        MagacinService magacinServis = new MagacinService();
        DinamickaOpremaService dinamickaOpremaServis = new DinamickaOpremaService();
        StatickaOpremaService statickaOpremaServis = new StatickaOpremaService();
        TerminService terminServis = new TerminService();
        public bool DodajUMagacin(InventarDTO opremaDTO)
        {
            return magacinServis.DodajOpremu(opremaDTO);
        }
        public bool DodajIzMagacina()
        {
            magacinServis.PregledSveOpreme();
            return true;
        }

        public ObservableCollection<InventarDTO> DodajIzMagacinaDTO()
        {
            return magacinServis.PregledSveOpremeDTO();
        }
        public ObservableCollection<StatickaOprema> PregledMagacinaStaticke()
        {
            return statickaOpremaServis.PregledSveOpreme();
        }

        public ObservableCollection<StatickaOpremaDTO> PregledMagacinaStatickeDTO()
        {
            return statickaOpremaServis.PregledSveOpremeDTO();
        }


        public ObservableCollection<DinamickaOprema> PregledMagacinaDinamcike()
        {
            return dinamickaOpremaServis.PregledSveOpreme();
        }

        public ObservableCollection<DinamickaOpremaDTO> PregledMagacinaDinamcikeDTO()
        {
            return dinamickaOpremaServis.PregledSveOpremeDTO();
        }
        public List<Termin> PregledSvihTermina()
        {

            return terminServis.PregledSvihTermina();

        }

        public ObservableCollection<TerminDTO> PregledSvihTerminaDTO()
        {
            return terminServis.PregledSvihTerminaDTO();

        }

        public bool Registruj(string ime, string prezime, UlogaEnum uloga)
        {
            KorisnikService ks = new KorisnikService();
           // ks.DodajKorisnika(ime,prezime,uloga);
            ks.DodajKorisnika(ime,prezime);
            return false;
        }

    }
}
