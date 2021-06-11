using Controller;
using Service;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for posaljiZahtevZaLek.xaml
    /// </summary>
    public partial class posaljiZahtevZaLek : Window
    {
        LekServis lekServis = new LekServis();
        private ObservableCollection<ZahtevLekDTO> zahteviPrikaz;
        private ZahtevLekDTO zahtev;

        public posaljiZahtevZaLek(ObservableCollection<ZahtevLekDTO> zahteviPrikaz, ZahtevLekDTO zahtevLek)
        {
            InitializeComponent();
            this.zahteviPrikaz = zahteviPrikaz;
            this.zahtev = zahtevLek;
        }
        private void da(object sender, RoutedEventArgs e)
        {
            lekServis.DodajZahtevLeka(zahtev);
            NeodobreniLekController neodobreniLekoviController = new NeodobreniLekController();
            if (neodobreniLekoviController.obrisiNeodobreniLek(this.zahtev))
            {
                zahteviPrikaz.Remove(zahtev);
            }
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
