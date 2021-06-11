using Controller;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for upravnikStart.xaml
    /// </summary>
    public partial class prostorijeStart : Page
    {
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
        ProstorijaController prostorijaController = new ProstorijaController();

        public prostorijeStart()
        {
            InitializeComponent();
            prostorije = prostorijaController.PregledSvihProstorijaDTO();
            dgUsers.ItemsSource = prostorije;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            dodajProstorijuUpravnik dp = new dodajProstorijuUpravnik(prostorije);
            dp.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izbrisiProstorijuUpravnik ip = new izbrisiProstorijuUpravnik(prostorije, (ProstorijaDTO)dgUsers.SelectedItem);
                ip.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izmeniProstorijuUpravnik ip = new izmeniProstorijuUpravnik(prostorije, (ProstorijaDTO)dgUsers.SelectedItem, dgUsers.SelectedIndex);
                ip.Show();
            }
        }

        private void zakaziRenoviranje(object sender, RoutedEventArgs e)
        {
            Renoviranje r = new Renoviranje(dgUsers.SelectedIndex);
            r.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
