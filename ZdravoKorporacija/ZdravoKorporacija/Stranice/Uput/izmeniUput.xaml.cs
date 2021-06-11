using Controller;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for izmeniPregledLekar.xaml
    /// </summary>
    public partial class izmeniUput : Page
    {
        private TerminController tc = TerminController.Instance;
        private ProstorijaController pc = ProstorijaController.Instance;
        private LekarController lekarController = LekarController.Instance;
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private List<LekarDTO> lekari = new List<LekarDTO>();
        private PacijentController pacijentController = PacijentController.Instance;
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
        private TerminDTO p;
        private TerminDTO s; // selektovani, za ukloniti
        private List<TerminDTO> termini;
        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;
        public izmeniUput(TerminDTO selektovani)
        {
            InitializeComponent();
            pacijenti = pacijentController.PregledSvihPacijenata2();
            p = selektovani;
            s = selektovani;
            cbPacijent.ItemsSource = pacijenti;
            try
            {

                // if(pacijent.ZdravstveniKarton.Id== selektovani.GetZdravstveniKarton().Id)

                foreach (PacijentDTO pacijent in pacijenti)
                {
                    if (pacijent.ZdravstveniKarton != null)
                    {
                        if (pacijent.ZdravstveniKarton.Id == selektovani.GetZdravstveniKarton().Id)
                            cbPacijent.SelectedItem = pacijent;
                    }
                }

            }
            catch (NullReferenceException) { }

            lekari = (List<LekarDTO>)lekarController.dobaviListuDTOLekara();
            lekari.Remove(lekarLogin.lekar);
            Lekari.ItemsSource = lekari;
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);

            try
            {
                date.SelectedDate = selektovani.Pocetak;
                time.SelectedValue = selektovani.Pocetak.ToString("HH:mm");
            }
            catch (Exception) { }
            prostorije = pc.PregledSvihProstorija2();
            cbProstorija.ItemsSource = prostorije;
            foreach (ProstorijaDTO p in prostorije)
            {
                if (selektovani.prostorija == null)
                {
                    break;
                }
                if (p.Id == selektovani.prostorija.Id)
                {
                    cbProstorija.SelectedItem = p;
                }
            }


            foreach (PacijentDTO p in pacijenti)
            {
                if (p.ZdravstveniKarton == selektovani.zdravstveniKarton)
                {
                    cbPacijent.SelectedItem = p;
                }
            }

            foreach (LekarDTO l in lekari)
            {
                if (selektovani.Lekar == null)
                {
                    break;
                }
                if (l.Jmbg == selektovani.Lekar.Jmbg)
                {
                    Lekari.SelectedItem = l;
                }
            }

            if (s.Tip == TipTerminaEnum.Pregled)
            {
                cbTip.SelectedIndex = 0;
            }
            else if (s.Tip == TipTerminaEnum.Operacija)
            {
                cbTip.SelectedIndex = 1;
            }

            p.Trajanje = 30;
            p.Id = s.Id;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new Uputi();
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            termini = tc.PregledSvihTermina2();
            String t = null;
            String d = date.Text;
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;

            if (!date.SelectedDate.HasValue || time.SelectedIndex == -1 || cbTip.SelectedIndex == -1
               || cbProstorija.SelectedIndex == -1 || cbPacijent.SelectedIndex == -1)
            {
                MessageBox.Show("Niste popunili sva polja", "Greska");
                return;
            }

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
            p.Pocetak = DateTime.Parse(d + " " + t);
            if (cbTip.SelectedIndex == 0)
            {
                p.Tip = TipTerminaEnum.Pregled;
            }
            else if (cbTip.SelectedIndex == 1)
            {
                p.Tip = TipTerminaEnum.Operacija;
            }

            p.Lekar = lekarLogin.lekar;
            p.prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;

            foreach (TerminDTO ter in termini)
            {
                if (ter.Pocetak.Equals(p.Pocetak) && ter.prostorija.Equals(p.prostorija))
                {
                    MessageBox.Show("Postoji termin u izabranom vremenu", "Greska");
                    return;
                }
            }
            if (tc.AzurirajTermin(p))
            {
                lekarStart.uputi.Remove(s);
                lekarStart.uputi.Add(p);
            }
            test.prozor.Content = new Uputi();
            MessageBox.Show("Uspesno ste izmenili uput!");

        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            if (time.SelectedIndex != -1 && date.SelectedDate.HasValue)
            {
                String t = cboItem.Content.ToString();
                prostorije = tc.DobaviSlobodneProstorije3(this.p, DateTime.Parse(date.Text + " " + t), (ProstorijaDTO)cbProstorija.SelectedItem);
                cbProstorija.ItemsSource = prostorije;
                foreach (ProstorijaDTO p in prostorije)
                {
                    if (this.p.prostorija == null)
                    {
                        break;
                    }
                    if (p.Id == this.p.prostorija.Id)
                    {
                        cbProstorija.SelectedItem = p;
                    }
                }
            }
        }

        private void date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            if (time.SelectedIndex != -1 && date.SelectedDate.HasValue)
            {
                String t = cboItem.Content.ToString();
                prostorije = tc.DobaviSlobodneProstorije3(this.p, DateTime.Parse(date.Text + " " + t), (ProstorijaDTO)cbProstorija.SelectedItem);
                cbProstorija.ItemsSource = prostorije;
                foreach (ProstorijaDTO p in prostorije)
                {
                    if (this.p.prostorija == null)
                    {
                        break;
                    }
                    if (p.Id == this.p.prostorija.Id)
                    {
                        cbProstorija.SelectedItem = p;
                    }
                }
            }
        }

    }
}