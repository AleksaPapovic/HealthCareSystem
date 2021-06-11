using Model;
using Service;
using System.Collections.ObjectModel;
using System.Windows;


namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for prikaziKarton.xaml
    /// </summary>
    public partial class prikaziKarton : Window
    {
        private ZdravstveniKartonServis kr = new ZdravstveniKartonServis();
        private ObservableCollection<ZdravstveniKarton> kartoni = new ObservableCollection<ZdravstveniKarton>();
        private ZdravstveniKarton karton = new ZdravstveniKarton();
        private Pacijent pacijent = new Pacijent();
        public prikaziKarton(Pacijent izabrani)
        {
            InitializeComponent();
            pacijent = izabrani;
            karton = kr.findById(izabrani.Jmbg);

            if (karton == null)
            {
                dgKarton.ItemsSource = null;
                nemaText.Visibility = Visibility.Visible;
                nemaButt.Visibility = Visibility.Visible;

            }
            else
            {
                ZdravstveniKarton temp = kr.findById(izabrani.Jmbg);
                kartoni.Add(temp);
                dgKarton.ItemsSource = kartoni;

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nemaButt_Click(object sender, RoutedEventArgs e)
        {
            ZdravstveniKarton zk = new ZdravstveniKarton(pacijent, pacijent.GetJmbg(), StanjePacijentaEnum.None, "", KrvnaGrupaEnum.None, "");
            if (kr.KreirajZdravstveniKartonJMBG(zk))
                pacijent.ZdravstveniKarton = zk;
            this.Close();

        }
    }
}
