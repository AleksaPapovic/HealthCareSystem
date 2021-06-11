using Model;
using Repository;
using Service;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.SekretarPREGLEDI;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for sekretarStart.xaml
    /// </summary>
    public partial class sekretarStart : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService storagePacijent = new PacijentService();

        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();
        public sekretarStart()
        {
            InitializeComponent();
            PacijentRepozitorijum dat = new PacijentRepozitorijum();
            pacijenti = new ObservableCollection<Pacijent>(dat.dobaviSve());


            termini = new ObservableCollection<Termin>(storage.PregledSvihTermina());

            this.DataContext = this;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fr.Content = new sekretarNALOZI();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fr.Content = new sekretarPREGLEDI();
        }

        private void fr_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            fr.Content = new sekretarObavestenja.sekretarObavestenja();
        }

        private void lekari(object sender, RoutedEventArgs e)
        {
            fr.Content = new SekretarLekari.SekretarLekari();
        }
    }
}
