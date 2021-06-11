using Model;
using Service;
using System.Windows;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.LekarCRUD;

namespace ZdravoKorporacija.Stranice.Logovanje
{
    /// <summary>
    /// Interaction logic for lekarLogin.xaml
    /// </summary>
    public partial class lekarLogin : Page
    {
        LekarController lc = new LekarController();
        KorisnikService ks = new KorisnikService();
        KorisnikDTO ulogovan;
        public static LekarDTO lekar = new LekarDTO();
        public static long jmbg;
        UlogaEnum uloga;
        public lekarLogin(UlogaEnum uloga)
        {
            InitializeComponent();
            this.uloga = uloga;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ulogovan = ks.Uloguj2(uloga, imeText.Text, lozinkaText.Password);
            if (ulogovan != null)
            {
                foreach (LekarDTO l in lc.PregledSvihLekara())
                {
                    //Trace.WriteLine(l.Username);
                    if (l.Username.Equals(imeText.Text) && l.Password.Equals(lozinkaText.Password))
                    {
                        lekar = l;
                        test t = new test();
                        imeText.Clear();
                        lozinkaText.Clear();
                        t.Show();
                        MainWindow.mw.Hide();
                        return;
                    }
                }
            }
        }
    }
}
