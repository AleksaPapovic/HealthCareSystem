using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zakaziPregledLekar.xaml
    /// </summary>
    public partial class zakaziPregledLekar : Page
    {
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();

        private TerminController tc = new TerminController();
        private ProstorijaController pc = new ProstorijaController();
        private PacijentController pacc = PacijentController.Instance;


        private TerminDTO termin = new TerminDTO();
        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;

        public zakaziPregledLekar()
        {
            InitializeComponent();

            cbPacijent.ItemsSource = pacc.PregledSvihPacijenata2();


            prostorije = pc.PregledSvihProstorija2();

            cbProstorija.ItemsSource = prostorije;

            DateTime danas = DateTime.Today;
            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());
            }
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);
            termin.Trajanje = 30;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            if (!date.SelectedDate.HasValue || time.SelectedIndex == -1 || cbTip.SelectedIndex == -1
                || cbProstorija.SelectedIndex == -1 || cbPacijent.SelectedIndex == -1)
            {
                MessageBox.Show("Niste popunili sva polja", "Greska");
                return;
            }
            PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;


            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String t = cboItem.Content.ToString();
            termin.Pocetak = DateTime.Parse(date.Text + " " + t);
            termin.prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;

            String d = date.Text;
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;
            if (cboItem != null)
            {
                t = cboItem.Content.ToString();
                if (d.Equals(today.ToString("dd.M.yyyy.")))
                {
                    if (Int32.Parse(t.Substring(0, 2)) < (now.Substring(9, 8).Equals("po podne") ? popodne : prepodne))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");

                        return;
                    }
                    else if ((Int32.Parse(t.Substring(0, 2)) == prepodne || Int32.Parse(t.Substring(0, 2)) == popodne) && Int32.Parse(t.Substring(3, 2)) < Int32.Parse(now.Substring(3, 2)))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");
                        return;
                    }
                }
            }
            foreach (TerminDTO ter in lekarStart.termini)
            {
                if (ter.Pocetak.Equals(termin.Pocetak) && ter.prostorija.Id.Equals(termin.prostorija.Id))
                {
                    MessageBox.Show("Postoji termin u izabranom vremenu", "Greska");
                    return;
                }
            }
            termin.zdravstveniKarton = new ZdravstveniKartonDTO(tc.NadjiKartonID(pac.Jmbg));

            if (cbTip.SelectedIndex == 0)
                termin.Tip = TipTerminaEnum.Pregled;
            else if (cbTip.SelectedIndex == 1)
                termin.Tip = TipTerminaEnum.Operacija;

            termin.Lekar = tc.NadjiLekaraPoJMBG(lekarLogin.lekar.Jmbg);


            if (tc.ZakaziTermin(termin, pac))
            {
                //this.pregledi.Add(termin);
            }

            test.prozor.Content = new lekarStart(lekarLogin.lekar);
            MessageBox.Show("Uspesno ste zakazali pregled!");
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new lekarStart(lekarLogin.lekar);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            if (time.SelectedIndex != -1 && date.SelectedDate.HasValue)
            {
                String t = cboItem.Content.ToString();
            prostorije = tc.DobaviSlobodneProstorije2(DateTime.Parse(date.Text + " " + t));
            cbProstorija.ItemsSource = prostorije;
            }
        }

        private void date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            if (time.SelectedIndex != -1 && date.SelectedDate.HasValue)
            {
                String t = cboItem.Content.ToString();
                prostorije = tc.DobaviSlobodneProstorije2(DateTime.Parse(date.Text + " " + t));
                cbProstorija.ItemsSource = prostorije;
            }
        }
    }
}
