using Controller;
using Model;
using Service;
using System.Collections.ObjectModel;
using System.Windows;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for obrisiZahtevZaLek.xaml
    /// </summary>
    public partial class obrisiZahtevZaLek : Window
    {
        LekServis lekServis = new LekServis();
        private ObservableCollection<ZahtevLek> zahteviPrikaz;
        private ZahtevLek zahtev;

        public obrisiZahtevZaLek(ObservableCollection<ZahtevLek> zahteviPrikaz, ZahtevLek zahtevLek)
        {
            InitializeComponent();
            this.zahteviPrikaz = zahteviPrikaz;
            this.zahtev = zahtevLek;
        }
        private void da(object sender, RoutedEventArgs e)
        {
            if (lekServis.ObrisiZahtevZaLek(zahtev))
            {
                zahteviPrikaz.Remove(zahtev);
            }
            //this.zahtev.Komentar = textBoxKomentar.Text;
            NeodobreniLekController neodobreniLekoviController = new NeodobreniLekController();
            neodobreniLekoviController.DodajNeodobreniLek(this.zahtev);
            this.Close();
            MessageBox.Show("Uspesno ste obrisali zahtev!");

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
