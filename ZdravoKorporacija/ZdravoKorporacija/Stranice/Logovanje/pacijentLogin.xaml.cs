using Model;
using Repository;
using Service;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.Logovanje
{
    /// <summary>
    /// Interaction logic for pacijentLogin.xaml
    /// </summary>
    public partial class pacijentLogin : Window
    {
        private KorisnikService ks = new KorisnikService();
        private KorisnikDTO ulogovan;
        private PacijentRepozitorijum pacRepo = new PacijentRepozitorijum();
        private Pacijent pacijent = new Pacijent();
        private UlogaEnum uloga;

        public pacijentLogin(UlogaEnum uloga)
        {
            InitializeComponent();
            this.uloga = uloga;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ulogovan = ks.Uloguj(uloga, imeText.Text, lozinkaText.Password);
            if (ulogovan != null)
            {
                foreach (Pacijent p in pacRepo.dobaviSve())
                {
                    if (p.Username.Equals(imeText.Text) && p.Password.Equals(lozinkaText.Password))
                    {
                        pacijentStart ps = new pacijentStart(p);
                        pacijent = p;
                        ps.Show();
                        this.Close();
                        return;
                    }
                }
            }
        }
    }
}
