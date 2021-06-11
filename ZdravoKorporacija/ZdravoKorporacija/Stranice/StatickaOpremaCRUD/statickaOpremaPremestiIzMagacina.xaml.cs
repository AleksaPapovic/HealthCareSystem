using Controller;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for statickaOpremaPremestiIzMagacina.xaml
    /// </summary>
    public partial class statickaOpremaPremestiIzMagacina : Window
    {
        private UpravnikController upravnikKontroler = new UpravnikController();
        private StatickaOpremaService statickaopremaStorage = new StatickaOpremaService();
        private ZahtevPremestanjaController zahteviController = new ZahtevPremestanjaController();
        private ProstorijaController prostorijeController = new ProstorijaController();
        private MagacinController magacineController = new MagacinController();

        private ObservableCollection<TerminDTO> pregledi;
        private Boolean selected;

        private ObservableCollection<ZahtevPremestanjaDTO> listaZahteva = new ObservableCollection<ZahtevPremestanjaDTO>();
        private int indeks;
        private Boolean imaZahtev = true;


        DatePicker izborDatuma;
        ComboBox comboBoxSati;

        public statickaOpremaPremestiIzMagacina()
        {
            InitializeComponent();
            upravnikKontroler.DodajIzMagacinaDTO();
            listaZahteva = zahteviController.PregledSveOpremeDTO();
            cbMagacin.ItemsSource = magacineController.PregledSveOpremeDTO();
            cbProstorija.ItemsSource = prostorijeController.PregledSvihProstorijaDTO();
            pregledi = new ObservableCollection<TerminDTO>(upravnikKontroler.PregledSvihTerminaDTO());


            comboBoxSati = sati;
            izborDatuma = timePicker;

            kalendarInicijalizacija();
            timer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            InventarDTO inventar = (InventarDTO)cbMagacin.SelectedItem;
            TerminDTO termin = new TerminDTO();
            StatickaOpremaDTO staticka = new StatickaOpremaDTO(termin, inventar);
            ZahtevPremestanjaDTO zahtevPremestanjaDTO = new ZahtevPremestanjaDTO();
            zahtevPremestanjaDTO.StatickaOprema = staticka;
            this.indeks = (int)cbProstorija.SelectedIndex;

            zahtevPremestanjaDTO.prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;
            zahtevPremestanjaDTO.Pocetak = (DateTime)timePicker.SelectedDate;
            zahteviController.ZakaziPremestanje((InventarDTO)cbMagacin.SelectedItem, zahtevPremestanjaDTO, (String)sati.SelectedItem, textBoxTrajanje.Text);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void cbProstorija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbMagacin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void date_changed(object sender, SelectionChangedEventArgs e)
        {
            ProveraTermina();
        }



        private void sati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProveraTermina();
        }


        public void ProveraTermina()
        {
            if (cbProstorija.SelectedIndex != -1)
            {
                selected = true;
            }

            if (selected)
            {
                ProstorijaDTO prost = (ProstorijaDTO)cbProstorija.SelectedItem;

                foreach (TerminDTO terminDTO in pregledi)
                {
                    if (terminDTO.prostorija != null && terminDTO.prostorija.Id.Equals(prost.Id))
                    {
                        if (terminDTO.Pocetak.Date.Equals(((DateTime)timePicker.SelectedDate).Date))
                        {
                            sati.Items.Remove(terminDTO.Pocetak.ToShortTimeString());
                        }
                    }
                }
                foreach (ZahtevPremestanjaDTO za in this.listaZahteva)
                {
                    if (za.prostorija.Id.Equals(prost.Id))
                    {
                        DateTime pocetak = za.Pocetak;

                        for (; pocetak < za.Kraj;)
                        {

                            Debug.WriteLine(pocetak.ToShortTimeString());
                            sati.Items.Remove(pocetak.ToShortTimeString());
                            pocetak = pocetak.AddMinutes(30);
                        }
                    }
                }
                sati.IsEnabled = true;
            }
        }

        public void timer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += ProveraZahteva;
            timer.Start();
        }

        public void ProveraZahteva(object sender, EventArgs e)
        {
            ZahtevPremestanjaDTO premastanjeZahtevDTO = new ZahtevPremestanjaDTO();

            if (zahteviController.PregledSveOpremeDTO() != null)
            {
                premastanjeZahtevDTO = zahteviController.PregledSveOpremeDTO().FirstOrDefault(s => s.Kraj <= DateTime.Now && s.Kraj >= DateTime.Now.AddMinutes(-5));
                if (premastanjeZahtevDTO == null)
                {
                    imaZahtev = false;
                }
                else { imaZahtev = true; }

            }
            if (premastanjeZahtevDTO != null && imaZahtev == true)
            {

                zahteviController.ObrisiZahtevPremestanja(premastanjeZahtevDTO);
                TerminDTO terminDTO = new TerminDTO(premastanjeZahtevDTO.prostorija, premastanjeZahtevDTO.Pocetak);
                statickaopremaStorage.DodajOpremu(premastanjeZahtevDTO.StatickaOprema, terminDTO, "10");
                MessageBox.Show("zavrsen termin");
                ProstorijaDTO p = premastanjeZahtevDTO.prostorija;
                StatickaOpremaDTO stat = new StatickaOpremaDTO((InventarDTO)premastanjeZahtevDTO.StatickaOprema);
                p.statickaOprema = new List<StatickaOpremaDTO>();
                p.statickaOprema.Add(stat);
                prostorijeController.AzurirajProstoriju(p, this.indeks);
                imaZahtev = false;
            }


        }




        public void kalendarInicijalizacija()
        {
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                comboBoxSati.Items.Add(tm.ToShortTimeString());

            }

            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            izborDatuma.BlackoutDates.Add(kalendar);
        }



    }
}