using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarLekari
{
    /// <summary>
    /// Interaction logic for SekretarLekari.xaml
    /// </summary>
    public partial class SekretarLekari : Page
    {
        private TerminController controllerPrikaz = new TerminController();
        public SekretarLekari()
        {
            InitializeComponent();
            dgUsers.ItemsSource = controllerPrikaz.PregledSvihLekaraDTO(controllerPrikaz.PregledSvihLekara());
        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {
            dodajLekara dl = new dodajLekara();
            dl.Show();
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            izmeniLekara il = new izmeniLekara((LekarDTO)dgUsers.SelectedItem);
            il.Show();
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            if (controllerPrikaz.ObrisiLekara(controllerPrikaz.LekarDTO2Model((LekarDTO)dgUsers.SelectedItem)))
                controllerPrikaz.PregledSvihLekara().Remove(controllerPrikaz.LekarDTO2Model((LekarDTO)dgUsers.SelectedItem));

        }

        private void radniDani(object sender, RoutedEventArgs e)
        {
            radniDani rd = new radniDani((LekarDTO)dgUsers.SelectedItem);
            rd.Show();
        }

        private void slobodniDani(object sender, RoutedEventArgs e)
        {
            slobodniDani sd = new slobodniDani((LekarDTO)dgUsers.SelectedItem);
            sd.Show();
        }

        private void smene(object sender, RoutedEventArgs e)
        {
            smeneLekara sl = new smeneLekara((LekarDTO)dgUsers.SelectedItem);
            sl.Show();
        }
    }
}
