using Model;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.PacijentCRUD.Onscreen_Keyboard;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private KorisnikController korisnikController = new KorisnikController();
        private PacijentController pacijentController = new PacijentController();
        private UlogaEnum uloga;
        public static bool wizard;

        public Login(UlogaEnum uloga)
        {
            InitializeComponent();
            this.uloga = uloga;
            wizard = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PacijentDTO ulogovani =
                pacijentController.ulogovaniPacijent(imeText.Text, lozinkaText.Password);
            if (ulogovani != null)
            {
                Pocetna pocetna = new Pocetna(ulogovani);
                pocetna.Show();
                this.Close();
            }
            else
            {
                pogresniKred.Text = "Pogrešno uneseno korisničko ime/lozinka.";
            }


        }

        private void wizardCb_Checked(object sender, RoutedEventArgs e)
        {
            wizard = true;
        }

        private void tastIme_Click(object sender, RoutedEventArgs e)
        {
            Keyboard k = new Keyboard(imeText, tastIme);
            k.Top = 343;
            k.Left = 860;
            k.ShowDialog();
        }

        private void tastLoz_Click(object sender, RoutedEventArgs e)
        {
            Keyboard k = new Keyboard(imeText, tastIme);
            k.Top = 430;
            k.Left = 860;
            k.ShowDialog();
        }
    }
}
