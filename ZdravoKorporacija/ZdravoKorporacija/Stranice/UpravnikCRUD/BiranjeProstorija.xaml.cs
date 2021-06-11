using Controller;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for BiranjeProstorija.xaml
    /// </summary>
    public partial class BiranjeProstorija : Window
    {
        ProstorijaController prostorijakontroler = new ProstorijaController();
        public ObservableCollection<ProstorijaDTO> sveProstorije = new ObservableCollection<ProstorijaDTO>();
        public ObservableCollection<ProstorijaDTO> izabraneProstorije = new ObservableCollection<ProstorijaDTO>();
        ZahtevRenoviranjeDTO zahtevRenoviranjaDTO = new ZahtevRenoviranjeDTO();


        public BiranjeProstorija(ObservableCollection<ProstorijaDTO> prostorije)
        {
            InitializeComponent();
            izabraneProstorije = prostorije;
            prostorijakontroler.PregledSvihProstorija();
            sveProstorije = prostorijakontroler.PregledSvihProstorijaDTO();
            if (izabraneProstorije != null)
            {
                foreach (ProstorijaDTO prostorija in sveProstorije.ToArray<ProstorijaDTO>())
                {
                    foreach (ProstorijaDTO izabranaProstorija in izabraneProstorije)
                    {
                        if (izabranaProstorija.Id == prostorija.Id)
                        {
                            sveProstorije.Remove(prostorija);
                        }
                    }
                }

            }

            dgProstorije.ItemsSource = sveProstorije;

            dgIzabraneProstorije.ItemsSource = izabraneProstorije;


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.zahtevRenoviranjaDTO.prostorije = new List<ProstorijaDTO>();
            foreach (ProstorijaDTO selektovanaProstorija in dgProstorije.SelectedItems.Cast<ProstorijaDTO>().ToList())
            {
                izabraneProstorije.Add(selektovanaProstorija);
                sveProstorije.Remove(selektovanaProstorija);
            }
            foreach (ProstorijaDTO novaProstorija in izabraneProstorije)
            {
                this.zahtevRenoviranjaDTO.prostorije.Add(novaProstorija);
            }


        }

        private void dgLekovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgAlternativni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {



        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (ProstorijaDTO selektovanaProstorija in dgIzabraneProstorije.SelectedItems.Cast<ProstorijaDTO>().ToList())
            {
                izabraneProstorije.Remove(selektovanaProstorija);
                sveProstorije.Add(selektovanaProstorija);
            }
        }

        private void dgLekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgIzabraniLekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
