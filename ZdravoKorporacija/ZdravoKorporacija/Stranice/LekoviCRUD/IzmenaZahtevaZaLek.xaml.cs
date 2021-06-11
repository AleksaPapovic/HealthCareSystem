using Model;
using Repository;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for IzmenaZahtevaZaLek.xaml
    /// </summary>
    public partial class IzmenaZahtevaZaLek : Window
    {
        LekServis lekServis = new LekServis();
        NeodobreniLekService neodobreniLekController = new NeodobreniLekService();
        DodavanjeAlternativnihLekova dodavanjeAlternativnih;
        IzborLekaraZaPotvrdu izborLekaraZaPotvrdu;
        public ObservableCollection<LekDTO> lekici;
        public ObservableCollection<Lekar> lekari;
        ZahtevLekDTO selektovaniZahtev;
        int indeksZahteva;
        ObservableCollection<ZahtevLekDTO> zahteviLekNeodobreni;

        public IzmenaZahtevaZaLek(int selektovaniIndex, ZahtevLekDTO selektovaniZahtevLekDTO, ObservableCollection<ZahtevLekDTO> neodobreniZahtevi)
        {
            InitializeComponent();
            lekici = new ObservableCollection<LekDTO>(selektovaniZahtevLekDTO.Lek.alternativniLekovi);
            lekari = new ObservableCollection<Lekar>(selektovaniZahtevLekDTO.lekari);
            List<int> potvrda = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                potvrda.Add(i);
            }
            comboBoxBrojPotvrda.ItemsSource = potvrda;
            selektovaniZahtev = selektovaniZahtevLekDTO;
            zahteviLekNeodobreni = neodobreniZahtevi;
            textBoxNazivLeka.Text = selektovaniZahtevLekDTO.Lek.NazivLeka;
            indeksZahteva = selektovaniIndex;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<LekDTO> alterantivni;
            if (dodavanjeAlternativnih == null)
            {
                alterantivni = new ObservableCollection<LekDTO>();
            }
            else
            {
                alterantivni = new ObservableCollection<LekDTO>(selektovaniZahtev.Lek.alternativniLekovi);
            }
            LekDTO lek = new LekDTO(0, textBoxProizvodjac.Text, textBoxSastojci.Text, textBoxPojave.Text, textBoxNazivLeka.Text, textBoxKolicina.Text);
            int neophodno;
            if (comboBoxBrojPotvrda.SelectedItem == null)
            {
                MessageBox.Show("Greška", "Morate selektovati broj potvrda");
                return;
            }
            else
            {
                neophodno = (int)comboBoxBrojPotvrda.SelectedItem;
            }
            List<LekDTO> alekoviDTO = new List<LekDTO>();

            ObservableCollection<Lekar> izabrani = new ObservableCollection<Lekar>();

            if (izborLekaraZaPotvrdu != null)
            {
                izabrani = izborLekaraZaPotvrdu.izabraniLekari;
            }
            else
            {
                izabrani = new ObservableCollection<Lekar>(selektovaniZahtev.lekari);
            }


            List<Lekar> lekariIzabrani = new List<Lekar>();
            foreach (Lekar lekarS in izabrani)
            {
                lekariIzabrani.Add(lekarS);
            }


            ZahtevLekDTO zahtevLekDTO = new ZahtevLekDTO(lek, neophodno, 0);
            zahtevLekDTO.Lek.SetalternativniLekovi(alekoviDTO);
            zahtevLekDTO.lekari = lekariIzabrani;
            IDRepozitorijum datoteka = new IDRepozitorijum("iDMapZahtevZaLek");
            Dictionary<int, int> ids = datoteka.dobaviSve();

            zahtevLekDTO.Id = selektovaniZahtev.Id;

            if (neodobreniLekController.AzurirajZahtev(indeksZahteva, zahtevLekDTO))
            {
                zahteviLekNeodobreni.RemoveAt(indeksZahteva);
                zahteviLekNeodobreni.Insert(indeksZahteva, zahtevLekDTO);
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {

            dodavanjeAlternativnih = new DodavanjeAlternativnihLekova(lekici);
            dodavanjeAlternativnih.Show();

        }

        private void comboBoxBrojPotvrda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            izborLekaraZaPotvrdu = new IzborLekaraZaPotvrdu(lekari, new ZahtevLek());
            izborLekaraZaPotvrdu.Show();
        }
    }
}
