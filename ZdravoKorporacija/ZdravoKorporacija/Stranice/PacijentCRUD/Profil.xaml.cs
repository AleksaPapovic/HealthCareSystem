using System.Windows.Controls;
using System.Windows.Media;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Page
    {
        private PacijentController pacijentController = new PacijentController();
        private PacijentDTO pacijentDTO;
        public Profil(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.pacijentDTO = pacijentDTO;


            PacijentPodaciDTO pacijentZaPrikaz = pacijentController.konvertujUPodaciDTO(pacijentDTO);
            tbIme.DataContext = pacijentZaPrikaz;
            tbPrezime.DataContext = pacijentZaPrikaz;
            tbJmbg.DataContext = pacijentZaPrikaz;
            tbAdresa.DataContext = pacijentZaPrikaz;
            tbKontakt.DataContext = pacijentZaPrikaz;
            tbMejl.DataContext = pacijentZaPrikaz;
            tbKorIme.DataContext = pacijentZaPrikaz;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tbIme.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 36, 62));
            tbPrezime.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 36, 62));
            tbJmbg.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 36, 62));
            tbAdresa.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 36, 62));
            tbKontakt.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 36, 62));
            tbMejl.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 36, 62));
            tbKorIme.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 36, 62));
            tbIme.IsReadOnly = false;
            tbPrezime.IsReadOnly = false;
            tbJmbg.IsReadOnly = false;
            tbAdresa.IsReadOnly = false;
            tbKontakt.IsReadOnly = false;
            tbMejl.IsReadOnly = false;
            tbKorIme.IsReadOnly = false;
            btnPotvrdi.IsEnabled = true;
            btnUredi.IsEnabled = false;
            btnPotvrdi.Visibility = System.Windows.Visibility.Visible;
            btnUredi.Visibility = System.Windows.Visibility.Hidden;


        }
        private void Button2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            btnPotvrdi.Visibility = System.Windows.Visibility.Hidden;
            btnUredi.Visibility = System.Windows.Visibility.Visible;
            btnPotvrdi.IsEnabled = false;
            btnUredi.IsEnabled = true;
            tbIme.IsReadOnly = true;
            tbPrezime.IsReadOnly = true;
            tbJmbg.IsReadOnly = true;
            tbAdresa.IsReadOnly = true;
            tbKontakt.IsReadOnly = true;
            tbMejl.IsReadOnly = true;
            tbKorIme.IsReadOnly = true;
            tbIme.BorderBrush = new SolidColorBrush(Color.FromArgb(00, 00, 00, 00));
            tbPrezime.BorderBrush = new SolidColorBrush(Color.FromArgb(00, 00, 00, 00));
            tbJmbg.BorderBrush = new SolidColorBrush(Color.FromArgb(00, 00, 00, 00));
            tbAdresa.BorderBrush = new SolidColorBrush(Color.FromArgb(00, 00, 00, 00));
            tbKontakt.BorderBrush = new SolidColorBrush(Color.FromArgb(00, 00, 00, 00));
            tbMejl.BorderBrush = new SolidColorBrush(Color.FromArgb(00, 00, 00, 00));
            tbKorIme.BorderBrush = new SolidColorBrush(Color.FromArgb(00, 00, 00, 00));
         
     
        }
    }
}
