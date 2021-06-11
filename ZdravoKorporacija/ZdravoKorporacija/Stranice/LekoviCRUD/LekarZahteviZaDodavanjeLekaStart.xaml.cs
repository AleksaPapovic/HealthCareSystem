using Model;
using Repository;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Stranice.LekarCRUD;
using ZdravoKorporacija.Stranice.Logovanje;
using ZdravoKorporacija.Stranice.Uput;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for LekarZahteviZaDodavanjeLekaStart.xaml
    /// </summary>
    public partial class LekarZahteviZaDodavanjeLekaStart : Page
    {
        LekServis lekServis = new LekServis();
        public ObservableCollection<Lek> lekici;
        public ObservableCollection<Lekar> lekari;
        public ObservableCollection<ZahtevLek> zahteviPrikaz = new ObservableCollection<ZahtevLek>();

        public LekarZahteviZaDodavanjeLekaStart()
        {
            InitializeComponent();
            lekici = new ObservableCollection<Lek>();
            lekari = new ObservableCollection<Lekar>();
            foreach (ZahtevLek z in lekServis.PregledSvihZahtevaLek())
            {
                foreach (Lekar l in z.lekari)
                {
                    if (l.Jmbg.Equals(lekarLogin.lekar.Jmbg))
                    {
                        zahteviPrikaz.Add(z);
                    }
                }
            }
            dgZahtevi.ItemsSource = zahteviPrikaz;
        }

        private void dgZahtevi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            if (dgZahtevi.SelectedItem != null)
            {
                IDRepozitorijum datoteka = new IDRepozitorijum("iDMapLekova");
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


                ZahtevLek zahtev = (ZahtevLek)dgZahtevi.SelectedItem;
                Lek l = new Lek(id, zahtev.Lek.Proizvodjac, zahtev.Lek.Sastojci, zahtev.Lek.NusPojave, zahtev.Lek.NazivLeka,zahtev.Lek.Kolicina);
                l.alternativniLekovi = zahtev.Lek.alternativniLekovi;
                lekServis.DodajLek(l, ids);
                Debug.WriteLine(zahtev.Id);
                zahtev.BrojPotvrda++;
                foreach (Lekar lekar in zahtev.lekari.ToArray())
                {
                    if (lekar.Jmbg.Equals(lekarLogin.lekar.Jmbg))
                        zahtev.lekari.Remove(lekar);
                }
                zahteviPrikaz.Remove(zahtev);
                lekServis.AzurirajZahtevLeka(zahtev);
                if (zahtev.BrojPotvrda.Equals(zahtev.NeophodnihPotvrda))
                    lekServis.ObrisiZahtevZaLek(zahtev);
            }
        }

        private void izmenaAlternativnihLekova(object sender, RoutedEventArgs e)
        {
            ZahtevLek zahtev = (ZahtevLek)dgZahtevi.SelectedItem;
            IzmenaAlternativnihLekovaZahtev izmenaAlternativnih = new IzmenaAlternativnihLekovaZahtev(new ObservableCollection<Lek>(zahtev.Lek.alternativniLekovi), zahtev);
            izmenaAlternativnih.Show();
        }

        private void lekariZaDodavanjeLeka(object sender, RoutedEventArgs e)
        {
            ZahtevLek zahtev = (ZahtevLek)dgZahtevi.SelectedItem;
            lekari = new ObservableCollection<Lekar>(zahtev.lekari);
            IzborLekaraZaPotvrdu izborLekara = new IzborLekaraZaPotvrdu(lekari, zahtev);
            izborLekara.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgZahtevi.SelectedItem == null)
            {
                MessageBox.Show("Zahtev nije izabran.", "Greška");
            }
            else
            {
                test.prozor.Content = new izmeniZahtevZaLek((ZahtevLek)dgZahtevi.SelectedItem);
                MessageBox.Show("Uspesno ste odobrili zahtev!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dgZahtevi.SelectedItem == null)
            {
                MessageBox.Show("Zahtev nije izabran.", "Greška");
            }
            else
            {
                IDRepozitorijum datoteka = new IDRepozitorijum("iDMapLekova");
                Dictionary<int, int> ids = datoteka.dobaviSve();
                obrisiZahtevZaLek oz = new obrisiZahtevZaLek(zahteviPrikaz, (ZahtevLek)dgZahtevi.SelectedItem);
                oz.Show();
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            lekarStart ls = new lekarStart(lekarLogin.lekar);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Uputi u = new Uputi();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            pregledPacijenata pp = new pregledPacijenata();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
