using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.LekarCRUD;

namespace ZdravoKorporacija.Stranice.StacionarnoLecenje
{
    /// <summary>
    /// Interaction logic for uputiZaStacionarno.xaml
    /// </summary>
    public partial class uputiZaStacionarno : Page
    {
        StacionarnoLecenjeController sl = StacionarnoLecenjeController.Instance;
        public static ObservableCollection<StacionarnoLecenjeDTO> uputi = new ObservableCollection<StacionarnoLecenjeDTO>();
        PacijentDTO pac;

        public uputiZaStacionarno(PacijentDTO pacijent)
        {
            InitializeComponent();
            uputi = new ObservableCollection<StacionarnoLecenjeDTO>();
            this.DataContext = this;
            pac = pacijent;
            foreach (StacionarnoLecenjeDTO s in sl.PregledSvihStacionarnih())
            {
                if (s.Pacijent.Jmbg.Equals(pacijent.Jmbg))
                {
                    uputi.Add(s);
                }
            }
            dgUsers.ItemsSource = uputi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stacionarnoStart ss = new stacionarnoStart(pac);
            test.prozor.Content = ss;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StacionarnoLecenjeDTO stac = null;
            if (dgUsers.SelectedItem != null)
            {
                stac = (StacionarnoLecenjeDTO)dgUsers.SelectedItem;
                izmeniUputStacionarno iu = new izmeniUputStacionarno(pac, stac);
                test.prozor.Content = iu;
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StacionarnoLecenjeDTO stac = null;
            if (dgUsers.SelectedItem != null)
            {
                stac = (StacionarnoLecenjeDTO)dgUsers.SelectedItem;
                sl.ObrisiStacionarnoLecenje(stac);
                uputi.Remove(stac);
                MessageBox.Show("Uspesno ste otkazali uput za stacionarno lecenje!");
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }

        }

    }
}
