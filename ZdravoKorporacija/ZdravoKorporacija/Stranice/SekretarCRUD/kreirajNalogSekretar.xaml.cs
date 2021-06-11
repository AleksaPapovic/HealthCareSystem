using Model;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for kreirajNalogSekretar.xaml
    /// </summary>
    public partial class kreirajNalogSekretar : Window
    {

        private TerminController tc = new TerminController();
        private NaloziController nc = new NaloziController();


        public kreirajNalogSekretar()
        {
            InitializeComponent();


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
            if (combo.SelectedIndex == 0)
            {
                pol = PolEnum.Muski;
            }
            else
            {
                pol = PolEnum.Zenski;
            }

            PacijentDTO nalog = new PacijentDTO(new ZdravstveniKartonDTO(jmbg), false, ime, prezime, (int)jmbg, br, mejl, "", pol, username, password) ;

            if (nc.KreirajNalogPacijentu(nc.DTO2ModelNapravi(nalog)))
            {
                tc.PregledSvihPacijenata().Add(nc.DTO2ModelNapravi(nalog));
                this.Close();
            }

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
