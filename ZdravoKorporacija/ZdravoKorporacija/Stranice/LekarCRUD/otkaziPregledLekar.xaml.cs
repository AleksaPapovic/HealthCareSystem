using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for oktaziPregledLekar.xaml
    /// </summary>
    public partial class oktaziPregledLekar : Window
    {
        TerminDTO termin;
        private TerminController controller = new TerminController();

        public oktaziPregledLekar(TerminDTO t)
        {
            InitializeComponent();
            termin = t;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            controller.OtkaziTermin(termin);

            lekarStart.termini.Remove(termin);

            this.Close();
            MessageBox.Show("Uspesno ste otkazali pregled!");
        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
