using Controller;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for NeodobreniZahteviZaLek.xaml
    /// </summary>
    public partial class NeodobreniZahteviZaLek : Page
    {
        ObservableCollection<ZahtevLekDTO> neodobreniZahtevi;
        public NeodobreniZahteviZaLek()
        {
            InitializeComponent();
            NeodobreniLekController neodobreniLekController = new NeodobreniLekController();
            neodobreniZahtevi = neodobreniLekController.PregledNeodobrenihLekovaDTO();
            dgNeodobreniLek.ItemsSource = neodobreniZahtevi;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            if (dgNeodobreniLek.SelectedItem != null)
            {

                posaljiZahtevZaLek posaljiZahtev = new posaljiZahtevZaLek(neodobreniZahtevi, (ZahtevLekDTO)dgNeodobreniLek.SelectedItem);
                posaljiZahtev.Show();
            }
            else
            {
                MessageBox.Show("Gre[ka", "Morate selektovati zahtev koji želite ponovo da prosledite");
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgNeodobreniLek.SelectedItem != null)
            {
                IzmenaZahtevaZaLek izmenaZahtevaZaLek = new IzmenaZahtevaZaLek((int)dgNeodobreniLek.SelectedIndex, (ZahtevLekDTO)dgNeodobreniLek.SelectedItem, neodobreniZahtevi);
                izmenaZahtevaZaLek.Show();
            }
            else
            {
                MessageBox.Show("Morate selektovati zahtev da bi ste izmenili", "Greška");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dgNeodobreniLek.SelectedItem != null)
            {
                obrisiNeodobreniLek obrisiNeodobreniZahtevLek = new obrisiNeodobreniLek(neodobreniZahtevi, (ZahtevLekDTO)dgNeodobreniLek.SelectedItem);
                obrisiNeodobreniZahtevLek.Show();
            }
            else
            {
                MessageBox.Show("Morate selektovati zahtev da bi ste izmenili", "Greška");
            }
        }

        private void izmenaAlternativnihLekova(object sender, RoutedEventArgs e)
        {

        }

    }
}
