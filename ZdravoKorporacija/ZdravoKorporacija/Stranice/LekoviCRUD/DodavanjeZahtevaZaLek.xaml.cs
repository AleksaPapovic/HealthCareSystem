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
    /// Interaction logic for DodavanjeZahtevaZaLek.xaml
    /// </summary>
    public partial class DodavanjeZahtevaZaLek : Window
    {
        LekServis lekServis = new LekServis();
        DodavanjeAlternativnihLekova dodavanjeAlternativnih;
        IzborLekaraZaPotvrdu izborLekaraZaPotvrdu;
        public ObservableCollection<LekDTO> lekici;
        public ObservableCollection<Lekar> lekari;

        public DodavanjeZahtevaZaLek()
        {
            InitializeComponent();
            lekici = new ObservableCollection<LekDTO>();
            lekari = new ObservableCollection<Lekar>();
            List<int> potvrda = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                potvrda.Add(i);
            }
            comboBoxBrojPotvrda.ItemsSource = potvrda;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ObservableCollection<LekDTO> alterantivni = dodavanjeAlternativnih.alternativniLekovi;

          
            LekDTO lek = new LekDTO(0,textBoxProizvodjac.Text,textBoxSastojci.Text,textBoxPojave.Text,textBoxNazivLeka.Text, textBoxKolicina.Text);

            int neophodno = (int)comboBoxBrojPotvrda.SelectedItem;

            List<LekDTO> alekoviDTO = new List<LekDTO>();




            ObservableCollection<Lekar> izabrani = izborLekaraZaPotvrdu.izabraniLekari;
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

            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    id = i;
                    ids[i] = 1;
                    break;
                }
            }

            int zahtevId = id;

            zahtevLekDTO.Id = zahtevId;

            lekServis.DodajZahtevLeka(zahtevLekDTO);


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
