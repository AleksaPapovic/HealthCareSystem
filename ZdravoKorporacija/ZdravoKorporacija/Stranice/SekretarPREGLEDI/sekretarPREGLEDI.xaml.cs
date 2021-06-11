using Model;
using Repository;
using Service;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;
using ZdravoKorporacija.Stranice.SekretarCRUD;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for sekretarPREGLEDI.xaml
    /// </summary>
    public partial class sekretarPREGLEDI : Page
    {
        private TerminService storage = new TerminService();
        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private TerminController controller = new TerminController();
        public sekretarPREGLEDI()
        {
            InitializeComponent();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            ids = datotekaID.dobaviSve();

            dgUsers.ItemsSource = controller.PregledSvihTermina2DTO(null);
            this.DataContext = this;
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                test.prozor.Content = new izmeniPregledLekar((TerminDTO)dgUsers.SelectedItem);
            }
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregledSekretar zp = new zakaziPregledSekretar(ids);
            zp.Show();
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        {
            /*  if (dgUsers.SelectedItem == null)
                  MessageBox.Show("Niste selektovali red", "Greska");
              else
              {
                  if (dgUsers.SelectedItem != null)
                  {
                      MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da otkažete ovaj termin?", "Potvrda brisanja", MessageBoxButton.YesNo);
                      if (result == MessageBoxResult.Yes)
                      {
                          pac.RemoveTermin((Termin)dgUsers.SelectedItem);
                          storagePacijent.AzurirajPacijenta(pac);
                          storage.OtkaziTermin((Termin)dgUsers.SelectedItem);
                          termini.Remove((Termin)dgUsers.SelectedItem);
                      }
                  }*/
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da otkažete.", "Greška");
            else
            {
                oktaziPregledLekar op = new oktaziPregledLekar((TerminDTO)dgUsers.SelectedItem);
                op.Show();
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sekretarStart s = new sekretarStart();

            s.Show();
        }

        private void hitno(object sender, RoutedEventArgs e)
        {
            zakaziHitno zh = new zakaziHitno(ids);
            zh.Show();
        }
    }
}
