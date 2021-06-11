using Model;
using Repository;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for DodavanjeAlternativnihLekova.xaml
    /// </summary>
    public partial class IzmenaAlternativnihLekovaZahtev : Window
    {
        LekServis lekServis = new LekServis();
        public ObservableCollection<Lek> ostalilekovi = new ObservableCollection<Lek>();
        public ObservableCollection<Lek> alternativniLekovi = new ObservableCollection<Lek>();
        ZahtevLek zl = new ZahtevLek();


        public IzmenaAlternativnihLekovaZahtev(ObservableCollection<Lek> lekici, ZahtevLek zahtev)
        {
            InitializeComponent();
            alternativniLekovi = lekici;
            this.zl = zahtev;
            lekServis.PregledSvihLekova();
            ostalilekovi = new ObservableCollection<Lek>(LekRepozitorijum.Instance.lekovi);
            if (alternativniLekovi != null)
            {
                foreach (Lek o in ostalilekovi.ToArray<Lek>())
                {
                    foreach (Lek l in alternativniLekovi)
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
            this.zl.Lek.alternativniLekovi = new List<Lek>();
            foreach (Lek selektovaniLek in dgLekovi.SelectedItems.Cast<Lek>().ToList())
            {
                alternativniLekovi.Add(selektovaniLek);
                ostalilekovi.Remove(selektovaniLek);
            }
            foreach (Lek leki in alternativniLekovi)
            {
                this.zl.Lek.alternativniLekovi.Add(leki);
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
            this.zl.Lek.alternativniLekovi = new List<Lek>();
            foreach (Lek selektovaniLek in dgAlternativni.SelectedItems.Cast<Lek>().ToList())
            {
                alternativniLekovi.Remove(selektovaniLek);
                ostalilekovi.Add(selektovaniLek);
            }
            foreach (Lek leki in alternativniLekovi)
            {
                this.zl.Lek.alternativniLekovi.Add(leki);
            }
        }
    }
}