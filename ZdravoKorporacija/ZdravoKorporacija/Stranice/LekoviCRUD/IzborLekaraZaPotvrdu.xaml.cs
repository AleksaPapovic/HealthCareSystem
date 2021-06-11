using Model;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for IzborLekaraZaPotvrdu.xaml
    /// </summary>
    public partial class IzborLekaraZaPotvrdu : Window
    {
        LekarService lekarServis = new LekarService();
        public ObservableCollection<Lekar> sviLekari = new ObservableCollection<Lekar>();
        public ObservableCollection<Lekar> izabraniLekari = new ObservableCollection<Lekar>();
        ZahtevLek zl = new ZahtevLek();
        public IzborLekaraZaPotvrdu(ObservableCollection<Lekar> lekari, ZahtevLek zahtev)
        {
            InitializeComponent();
            izabraniLekari = lekari;
            this.zl = zahtev;
            sviLekari = new ObservableCollection<Lekar>(lekarServis.PregledSvihLekara());
            if (izabraniLekari != null)
            {
                foreach (Lekar s in sviLekari.ToArray<Lekar>())
                {
                    foreach (Lekar i in izabraniLekari)
                    {
                        if (s.Jmbg == i.Jmbg)
                        {
                            sviLekari.Remove(s);
                        }
                    }
                }

            }

            dgLekari.ItemsSource = sviLekari;

            dgIzbraniLekari.ItemsSource = izabraniLekari;
        }

        private void dgLekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgIzabraniLekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.zl.lekari = new List<Lekar>();
            foreach (Lekar selektovaniLekar in dgLekari.SelectedItems.Cast<Lekar>().ToList())
            {
                izabraniLekari.Add(selektovaniLekar);
                this.zl.lekari.Add(selektovaniLekar);
                sviLekari.Remove(selektovaniLekar);
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.zl.lekari = new List<Lekar>();
            foreach (Lekar selektovaniLekar in dgIzbraniLekari.SelectedItems.Cast<Lekar>().ToList())
            {
                izabraniLekari.Remove(selektovaniLekar);
                sviLekari.Add(selektovaniLekar);
            }
            foreach (Lekar selektovaniLekar in izabraniLekari)
            {
                this.zl.lekari.Add(selektovaniLekar);
            }
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void odustani(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
