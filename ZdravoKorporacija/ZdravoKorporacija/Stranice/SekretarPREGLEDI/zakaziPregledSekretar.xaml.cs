using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for zakaziPregledSekretar.xaml
    /// </summary>
    public partial class zakaziPregledSekretar : Window
    {


        private List<LekarDTO> lekari = new List<LekarDTO>();
        private List<LekarDTO> slobodniLekari;
        private ObservableCollection<ProstorijaDTO> slobodneProstorije;
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();

        private int idTermina;
        private TipTerminaEnum tipTermina;
        private DateTime pocetakTermina;
        private LekarDTO lekarTermina;
        private ProstorijaDTO prostorijaTermina;

        private TerminDTO noviTermin;
        private TerminController tc = new TerminController();

        private Dictionary<int, int> ids = new Dictionary<int, int>();

        DateTime dateTime = DateTime.Now;
        public zakaziPregledSekretar(Dictionary<int, int> ids)
        {
            InitializeComponent();

            noviTermin = new TerminDTO();



            cbPacijent.ItemsSource = tc.PregledSvihPacijenata2DTO();

            lekari = tc.PregledSvihLekaraDTO(tc.PregledSvihLekara());

            slobodniLekari = lekari;
            Lekari.ItemsSource = slobodniLekari;

            prostorije = tc.PregledSvihProstorijaDTO(tc.PregledSvihProstorija());
            cbProstorija.ItemsSource = prostorije;

            slobodneProstorije = prostorije;
            cbProstorija.ItemsSource = slobodneProstorije;

            this.ids = ids;
            DateTime danas = DateTime.Today;
            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());
            }
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);

            cbPacijent.IsEnabled = false;
            cbProstorija.IsEnabled = false;
            Lekari.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cbPacijent.IsEnabled = true;
            cbProstorija.IsEnabled = true;
            Lekari.IsEnabled = true;

            slobodniLekari = tc.PregledSvihLekaraDTO(tc.DobaviSlobodneLekare(pocetakTermina, SpecijalizacijaEnum.OpstaPraksa));
            Lekari.ItemsSource = slobodniLekari;
            slobodneProstorije = tc.PregledSvihProstorijaDTO(new ObservableCollection<Prostorija>(tc.DobaviSlobodneProstorije(tc.TerminDTO2Model(noviTermin))));
            cbProstorija.ItemsSource = slobodneProstorije;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            int id = tc.MapaTermina(ids);
            PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;


            idTermina = id;
            pocetakTermina = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            prostorijaTermina = (ProstorijaDTO)cbProstorija.SelectedItem;
            lekarTermina = (LekarDTO)Lekari.SelectedItem;

            if (cbTip.SelectedIndex == 0)
                tipTermina = TipTerminaEnum.Pregled;
            else if (cbTip.SelectedIndex == 1)
                tipTermina = TipTerminaEnum.Operacija;

            noviTermin = new TerminDTO(new ZdravstveniKartonDTO(tc.NadjiKartonID(pac.Jmbg)), prostorijaTermina, lekarTermina, tipTermina, pocetakTermina, 0.5, null);
            noviTermin.Id = idTermina;

            TerminDTO zaLekara = new TerminDTO();
            zaLekara.Id = noviTermin.Id;

            if (tc.ZakaziTermin(tc.TerminDTO2Model(noviTermin), ids))
            {
                tc.DodajTermin(tc.TerminDTO2Model(noviTermin));
                tc.AzurirajLekare();
            }


            tc.DodajTermin(tc.PacijentDTO2Model(pac), tc.TerminDTO2Model(noviTermin));
            tc.AzurirajPacijenta(tc.PacijentDTO2Model(pac));
            this.Close();
        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void time_changed(object sender, SelectionChangedEventArgs e)
        {
            if (time.SelectedIndex != -1)
            {
                pocetakTermina = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            }
        }
    }
}