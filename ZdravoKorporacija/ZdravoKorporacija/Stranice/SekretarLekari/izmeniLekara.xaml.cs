using Model;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarLekari
{
    /// <summary>
    /// Interaction logic for izmeniLekara.xaml
    /// </summary>
    public partial class izmeniLekara : Window
    {
        private SpecijalizacijaEnum specijalizacija;
        private PolEnum pol;

        private LekarDTO l1;
        private TerminController controller = new TerminController();

        public izmeniLekara(LekarDTO izabrani)
        {
            InitializeComponent();
            l1 = izabrani;
            tbime.Text = izabrani.Ime;
            tbprezime.Text = izabrani.Prezime;
            tbjmbg.Text = izabrani.Jmbg.ToString();
            tbbr.Text = izabrani.BrojTelefona.ToString();
            tbmejl.Text = izabrani.Mejl;
            tbuser.Text = izabrani.Username;
            tbpass.Text = izabrani.Password;
            odrediInicijalniPol();
            odrediInicijalnuSpecijalizaciju(l1);
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            controller.PregledSvihLekara().Remove(controller.LekarDTO2Model(l1));
            string ime = tbime.Text;
            string prezime = tbprezime.Text;
            long jmbg = long.Parse(tbjmbg.Text);
            int br = int.Parse(tbbr.Text);
            string mejl = tbmejl.Text;
            string username = tbuser.Text;
            string password = tbpass.Text;
            odrediPol();
            odrediSpecijalizaciju();

            LekarDTO novi = new LekarDTO(ime, prezime, jmbg, br, mejl, "", pol, username, password);
            novi.Specijalizacija = specijalizacija;

            if (controller.AzurirajLekara(controller.DTO2ModelNapravi(novi)))
            {
                controller.PregledSvihLekara().Add(controller.LekarDTO2Model(novi));
                this.Close();
            }

        }
        public void odrediInicijalniPol()
        {
            if (l1.Pol == PolEnum.Muski)
            {
                combo.SelectedIndex = 0;
            }
            else
            {
                combo.SelectedIndex = 1;
            }

        }
        public void odrediPol()
        {
            if (combo.SelectedIndex == 0)
            {
                pol = PolEnum.Muski;
            }
            else
            {
                pol = PolEnum.Zenski;
            }
        }
        public void odrediInicijalnuSpecijalizaciju(LekarDTO lekar)
        {
            if (lekar.Specijalizacija == SpecijalizacijaEnum.Oftamolog)
            {
                specCB.SelectedIndex = 0;
            }
            else if (lekar.Specijalizacija == SpecijalizacijaEnum.Stomatolog)
            {
                specCB.SelectedIndex = 1;
            }
            else if (lekar.Specijalizacija == SpecijalizacijaEnum.Kardiohirurg)
            {
                specCB.SelectedIndex = 2;
            }
            else if (lekar.Specijalizacija == SpecijalizacijaEnum.Otorinolaringolog)
            {
                specCB.SelectedIndex = 3;
            }
            else if (lekar.Specijalizacija == SpecijalizacijaEnum.Neurolog)
            {
                specCB.SelectedIndex = 4;
            }
            else
            {
                specCB.SelectedIndex = -1;
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

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
