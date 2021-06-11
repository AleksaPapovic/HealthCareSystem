using Model;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for izmeniNalogSekretar.xaml
    /// </summary>
    /// 


    public partial class izmeniNalogSekretar : Window
    {

        private PacijentDTO p1;
        private TerminController tc = new TerminController();

        public izmeniNalogSekretar(PacijentDTO izabrani)
        {
            InitializeComponent();
            p1 = izabrani;

            tbime.Text = izabrani.Ime;
            tbprezime.Text = izabrani.Prezime;
            tbjmbg.Text = izabrani.Jmbg.ToString();
            tbbr.Text = izabrani.BrojTelefona.ToString();
            tbmejl.Text = izabrani.Mejl;
            if (p1.Pol == PolEnum.Muski)
            {
                combo.SelectedIndex = 0;
            }
            else
            {
                combo.SelectedIndex = 1;
            }
            tbuser.Text = izabrani.Username;
            tbpass.Text = izabrani.Password;


        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            tc.PregledSvihPacijenata().Remove(tc.PacijentDTO2Model(p1));
            string ime = tbime.Text;
            string prezime = tbprezime.Text;
            long jmbg = long.Parse(tbjmbg.Text);
            int br = int.Parse(tbbr.Text);
            string mejl = tbmejl.Text;
            string username = tbuser.Text;
            string password = tbpass.Text;
            PolEnum pol;
            if (combo.SelectedIndex == 0)
            {
                pol = PolEnum.Muski;
            }
            else
            {
                pol = PolEnum.Zenski;
            }
            
            PacijentDTO novi = new PacijentDTO(p1.ZdravstveniKarton,p1.Guest,ime, prezime, jmbg, br, mejl, "", pol, username, password);
            if (tc.AzurirajPacijenta(tc.DTO2ModelNapravi(novi)))
            {
                tc.PregledSvihPacijenata().Add(tc.PacijentDTO2Model(novi));
                this.Close();

            }


        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
