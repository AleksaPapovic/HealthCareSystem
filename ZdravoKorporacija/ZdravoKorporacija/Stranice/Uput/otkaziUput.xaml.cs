using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.LekarCRUD;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for oktaziPregledLekar.xaml
    /// </summary>
    public partial class otkaziUput : Window
    {
        private TerminController tc = TerminController.Instance;

        TerminDTO termin;

        public otkaziUput(TerminDTO t)
        {
            InitializeComponent();
            termin = t;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            tc.OtkaziTermin(termin);
            lekarStart.uputi.Remove(termin);
            this.Close();
            MessageBox.Show("Uspesno ste otkazali uput!");
        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}

