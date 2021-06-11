using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Zakazi.xaml
    /// </summary>
    public partial class Zakazi : Window
    {
        private PacijentDTO pacijentDTO;
        private TerminDTO terminDTO;
        private TerminController terminKontroler;
        private ObservableCollection<TerminDTO> pregledi;
        private LekarController lekarKontroler = new LekarController();
        private List<LekarDTO> ljekari;
        private BindingList<LekarDTO> dostupniLjekari;
        private bool prioritetLjekar;

        public Zakazi(ObservableCollection<TerminDTO> termini, PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            pregledi = termini;
            this.pacijentDTO = pacijentDTO;
            this.terminDTO = new TerminDTO();
            this.terminKontroler = new TerminController();
            dostupniLjekari = new BindingList<LekarDTO>();
            ljekari = (List<LekarDTO>)lekarKontroler.dobaviListuDTOLekara();
            dostupniLjekari = new BindingList<LekarDTO>();
            selektovaneVrijednosti();
        }

        private void selektovaneVrijednosti()
        {
            ljekar.SelectedItem = null;
            time.SelectedItem = null;
            date.SelectedDate = null;
            if (dostupniLjekari != null)
                dostupniLjekari.Clear();

            foreach (LekarDTO dostupanLjekar in ljekari)
                dostupniLjekari.Add(dostupanLjekar);

            ljekar.ItemsSource = dostupniLjekari;

            time.Items.Clear();
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());

            }
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(kalendar);

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            datumValidan();
            vriejemValidno();
            ljekarValidan();

            if (datumValidan() && vriejemValidno() && ljekarValidan()) { 
                terminDTO.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
                terminDTO.Lekar = (LekarDTO)ljekar.SelectedItem;
                terminDTO.zdravstveniKarton = pacijentDTO.ZdravstveniKarton;
                terminDTO.Tip = TipTerminaEnum.Pregled;
                terminKontroler.zakaziTermin(terminDTO);
                this.pregledi.Add(terminDTO);
                this.Close();
            }
        }

        private void VremeChecked(object sender, RoutedEventArgs e)
        {
            btnPotvrdi.IsEnabled = true;
            selektovaneVrijednosti();
        }

        private void LekarChecked(object sender, RoutedEventArgs e)
        {
            btnPotvrdi.IsEnabled = true;
            selektovaneVrijednosti();
        }

        private void time_changed(object sender, SelectionChangedEventArgs e)
        {
            if (prioritetLjekar)
            {
                if (ljekar.SelectedItem != null && date.SelectedDate != null)
                {
                    foreach (TerminDTO td in nedostupniTermini())
                    {
                        if (td != null) time.Items.Remove(td.Pocetak.ToShortTimeString());

                    }
                }
            }
            else
            {
                if (time.SelectedIndex != -1 && date.SelectedDate != null)
                {
                    DateTime terminPregleda = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());

                    if (nedostupanLjekar(terminPregleda) != null) dostupniLjekari.Remove(nedostupanLjekar(terminPregleda));
                }
            }

        }

        private void date_changed(object sender, SelectionChangedEventArgs e)
        {
            if (prioritetLjekar)
            {
                if (ljekar.SelectedIndex != -1 && date.SelectedDate != null)
                {
                    foreach (TerminDTO td in nedostupniTermini())
                    {
                        if (td != null) time.Items.Remove(td.Pocetak.ToShortTimeString());
                    }
                }
            }
            else //prioritet vrijeme
            {
                if (time.SelectedIndex != -1 && date.SelectedDate != null)
                {
                    DateTime terminPregleda = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
                    if (nedostupanLjekar(terminPregleda) != null) dostupniLjekari.Remove(nedostupanLjekar(terminPregleda));
                }
            }

        }

        private void ljekar_changed(object sender, SelectionChangedEventArgs e)
        {
            if (prioritetLjekar)
            {
                if (date.SelectedDate != null && ljekar.SelectedItem != null)
                {
                    foreach (TerminDTO td in nedostupniTermini())
                    {
                        if(td != null) time.Items.Remove(td.Pocetak.ToShortTimeString());
                    }
                }
            }
            else
            {
                if (time.SelectedIndex != -1 && date.SelectedDate != null)
                {
                    DateTime terminPregleda = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());

                    if (nedostupanLjekar(terminPregleda) != null) dostupniLjekari.Remove(nedostupanLjekar(terminPregleda));
                }               
            }
        }


        private LekarDTO nedostupanLjekar(DateTime terminPregleda)
        {
            foreach (TerminDTO t in pregledi)
            {
                if (t.Pocetak.Equals(terminPregleda))
                {
                    foreach (LekarDTO l in ljekari.ToArray())
                    {
                        if (l.Jmbg.Equals(t.Lekar.Jmbg))
                        {
                            return l;
                        }
                    }
                }
            }
            return null;
        }

        private List<TerminDTO> nedostupniTermini()
        {
            List<TerminDTO> termini = new List<TerminDTO>();

            foreach (TerminDTO t in pregledi)
            {
                if (t.Lekar.Jmbg.Equals(((LekarDTO)ljekar.SelectedItem).Jmbg))
                {
                    if (t.Pocetak.Date.Equals(((DateTime)date.SelectedDate).Date))
                    {
                        termini.Add(t);
                    }
                }
            }
            return termini;
        }


        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public bool ljekarValidan()
        {
            if (ljekar.SelectedItem == null)
            {
                tbLjekar.Text = "Morate izabrati lekara za pregled!";
                return false;
            }
            else
            {
                tbLjekar.Text = "";
                return true;
            }
        }

        public bool datumValidan()
        {
            if (date.SelectedDate == null)
            {
                tbDate.Text = "Morate izabrati datum pregleda!";
                return false;
            }
            else
            {
                tbDate.Text = "";
                return true;
            }
        }

        public bool vriejemValidno()
        {
            if (time.SelectedItem == null)
            {
                tbTime.Text = "Morate izabrati vreme pregleda!";
                return false;
            }
            else
            {
                tbTime.Text = "";
                return true;
            }
        }

    }
}
