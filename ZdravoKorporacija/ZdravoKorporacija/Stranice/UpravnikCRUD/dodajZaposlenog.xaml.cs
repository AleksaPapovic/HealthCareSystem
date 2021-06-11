using Model;
using System.Windows;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for dodajZaposlenog.xaml
    /// </summary>
    public partial class dodajZaposlenog : Window
    {

        public dodajZaposlenog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Korisnik osoba = new Korisnik(textBoxIme.Text, textBoxPrezime.Text);
            Registracija registracija = new Registracija(textBoxIme.Text, textBoxPrezime.Text, osoba);
            registracija.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
