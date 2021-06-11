using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;

namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for statickaOpremaStart.xaml
    /// </summary>
    public partial class statickaOpremaStart : Page
    {

        private UpravnikController upravnikKontroler = new UpravnikController();
        public statickaOpremaStart()
        {
            InitializeComponent();
            dgStatickaOprema.ItemsSource = upravnikKontroler.PregledMagacinaStatickeDTO();
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            statickaOpremaPremestiIzMagacina statickaPremestanjeiIzMagacina = new statickaOpremaPremestiIzMagacina();
            statickaPremestanjeiIzMagacina.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void dgStatickaOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            StatickaPremestanjeProstorijaUProstoriju statickaPremstanje = new StatickaPremestanjeProstorijaUProstoriju();
            statickaPremstanje.Show();
        }
    }
}
