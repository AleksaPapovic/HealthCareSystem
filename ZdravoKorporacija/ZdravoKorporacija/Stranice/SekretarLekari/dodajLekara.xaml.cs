using Model;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarLekari
{
    /// <summary>
    /// Interaction logic for dodajLekara.xaml
    /// </summary>
    public partial class dodajLekara : Window
    {
        private NaloziController controller = new NaloziController();
        private TerminController controllerPregleda = new TerminController();
        private SpecijalizacijaEnum specijalizacija;
        public dodajLekara()
        {
            InitializeComponent();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            string ime = tbime.Text;
            string prezime = tbprezime.Text;
            long jmbg = long.Parse(tbjmbg.Text);
            int br = int.Parse(tbbroj.Text);
            string mejl = tbmejl.Text;
            string username = tbuser.Text;
            string password = tbpass.Text;
            PolEnum pol;
            odrediSpecijalizaciju();
            if (combo.SelectedIndex == 0)
            {
                pol = PolEnum.Muski;
            }
            else
            {
                pol = PolEnum.Zenski;
            }


            LekarDTO noviLekar = new LekarDTO(ime, prezime, jmbg, br, mejl, "", pol, username, password);
            noviLekar.Specijalizacija = specijalizacija;
            if (controller.DodajLekara(controller.DTO2ModelNapravi(noviLekar)))
            {
                controllerPregleda.PregledSvihLekara().Add(controller.DTO2ModelNapravi(noviLekar));
                this.Close();
            }
        }
        private void odrediSpecijalizaciju()
        {
            if (specCB.SelectedIndex == 0)
            {
                specijalizacija = SpecijalizacijaEnum.Oftamolog;
            }
            else if (specCB.SelectedIndex == 1)
            {
                specijalizacija = SpecijalizacijaEnum.Stomatolog;
            }
            else if (specCB.SelectedIndex == 2)
            {
                specijalizacija = SpecijalizacijaEnum.Kardiohirurg;
            }
            else if (specCB.SelectedIndex == 3)
            {
                specijalizacija = SpecijalizacijaEnum.Otorinolaringolog;
            }
            else if (specCB.SelectedIndex == 4)
            {
                specijalizacija = SpecijalizacijaEnum.Neurolog;
            }
            else
            {
                specijalizacija = SpecijalizacijaEnum.OpstaPraksa;
            }

        }
    }
}
