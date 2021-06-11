using Model;
using Repository;
using Service;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for DodavanjeAlternativnihLekova.xaml
    /// </summary>
    public partial class DodavanjeAlternativnihLekova : Window
    {
        LekServis lekServis = new LekServis();
        public ObservableCollection<LekDTO> ostalilekovi = new ObservableCollection<LekDTO>();
        public ObservableCollection<LekDTO> alternativniLekovi = new ObservableCollection<LekDTO>();
        ZahtevLek zl = new ZahtevLek();


        public DodavanjeAlternativnihLekova(ObservableCollection<LekDTO> lekici)
        {
            InitializeComponent();
            alternativniLekovi = lekici;
            lekServis.PregledSvihLekova();
            ostalilekovi = new ObservableCollection<LekDTO>(LekRepozitorijum.Instance.lekoviDTO);
            if (alternativniLekovi != null)
            {
                foreach (LekDTO o in ostalilekovi.ToArray<LekDTO>())
                {
                    foreach (LekDTO l in alternativniLekovi)
                    {
                        if (o.Id == l.Id)
                        {
                            ostalilekovi.Remove(o);
                        }
                    }
                }

            }

            dgLekovi.ItemsSource = ostalilekovi;

            dgAlternativni.ItemsSource = alternativniLekovi;


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (LekDTO selektovaniLek in dgLekovi.SelectedItems.Cast<LekDTO>().ToList())
            {
                alternativniLekovi.Add(selektovaniLek);
                ostalilekovi.Remove(selektovaniLek);
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
            foreach (LekDTO selektovaniLek in dgAlternativni.SelectedItems.Cast<LekDTO>().ToList())
            {
                alternativniLekovi.Remove(selektovaniLek);
                ostalilekovi.Add(selektovaniLek);
            }
        }
    }
}
