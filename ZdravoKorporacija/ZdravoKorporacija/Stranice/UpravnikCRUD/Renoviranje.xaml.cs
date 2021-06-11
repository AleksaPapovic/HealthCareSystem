using Controller;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;
using System.Linq;
using System.Collections.ObjectModel;
using Controller;
using System.Diagnostics;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for Renoviranje.xaml
    /// </summary>
    public partial class Renoviranje : Window
    {
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
        private ProstorijaController prostorijeKontroler = new ProstorijaController();
        RenoviranjeController renoviranjeKontroler = new RenoviranjeController();

        public ObservableCollection<ProstorijaDTO> izabraneProstorije;
        ComboBox satiCombobox;
        String spajanje;
        String razdvajanje;


        public Renoviranje(int index)
        {
            InitializeComponent();
            izabraneProstorije = new ObservableCollection<ProstorijaDTO>();
            prostorije = prostorijeKontroler.PregledSvihProstorijaDTO();
            cbProstorija.ItemsSource = prostorije;
            cbProstorija.SelectedIndex = index;
            satiCombobox = sati;
            kalendarInit();
        }

        public void kalendarInit()
        {
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                satiCombobox.Items.Add(tm.ToShortTimeString());

            }
        }

        private void cbProstorija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            ZahtevRenoviranjeDTO zahtevRenoviranje = new ZahtevRenoviranjeDTO(0, (ProstorijaDTO)cbProstorija.SelectedItem, (DateTime)timePicker.SelectedDate, (String)sati.SelectedItem, textBoxTrajanje.Text, spajanje, razdvajanje);
            zahtevRenoviranje.prostorije = izabraneProstorije.ToList<ProstorijaDTO>();
           
            renoviranjeKontroler.ZakaziRenoviranje(zahtevRenoviranje);
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void date_changed(object sender, SelectionChangedEventArgs e)
        {

        }
        private void sati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            BiranjeProstorija biranjeProstorija = new BiranjeProstorija(izabraneProstorije);
            biranjeProstorija.Show();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            spajanje = "Spajanje";
            razdvajanje = "";
            Debug.WriteLine(spajanje);
            Debug.WriteLine(razdvajanje);


        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            spajanje = "";
            razdvajanje = "Razdvajanje";
            Debug.WriteLine(spajanje);
            Debug.WriteLine(razdvajanje);
        }
    }
}
