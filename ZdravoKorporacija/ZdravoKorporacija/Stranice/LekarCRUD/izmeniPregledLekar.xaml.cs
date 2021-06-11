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
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for izmeniPregledLekar.xaml
    /// </summary>
    public partial class izmeniPregledLekar : Page
    {
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private ProstorijaController pc = ProstorijaController.Instance;
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
        private List<TerminDTO> termini = new List<TerminDTO>();
        private TerminDTO t1;
        private TerminDTO t2;
        private ZdravstveniKartonKonverter zkk = new ZdravstveniKartonKonverter();

        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;
        private TerminController controller = TerminController.Instance;
        public izmeniPregledLekar(TerminDTO selektovani)
        {
            InitializeComponent();
            pacijenti = controller.PregledSvihPacijenata2DTO();
            prostorije = pc.PregledSvihProstorija2();
            termini = TerminController.Instance.PregledSvihTermina2();
            t1 = selektovani;
            t2 = selektovani;
            cbPacijent.ItemsSource = pacijenti;

            foreach (PacijentDTO p in pacijenti)
            {
                if (selektovani.zdravstveniKarton == null)
                    break;
                if (p.ZdravstveniKarton.Id == selektovani.zdravstveniKarton.Id)
                {
                    cbPacijent.SelectedItem = p;
                }
            }
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
            date.SelectedDate = selektovani.Pocetak;
            time.SelectedValue = selektovani.Pocetak.ToString("HH:mm");

            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            try { date.BlackoutDates.Add(cdr); }

            catch (Exception e) { }

            if (t1.Tip == TipTerminaEnum.Pregled)
            {
                cbTip.SelectedIndex = 0;
            }
            else if (t1.Tip == TipTerminaEnum.Operacija)
            {
                cbTip.SelectedIndex = 1;
            }

            t1.Trajanje = 30;
            t1.Id = t2.Id;

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new lekarStart(lekarLogin.lekar);
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String t = null;
            String d = date.Text;
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;
            PacijentDTO pacijent = (PacijentDTO)cbPacijent.SelectedItem;
            t1.prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;
            t1.Pocetak = DateTime.Parse(d + " " + t);
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
            foreach (TerminDTO ter in termini)
            {
                if (ter.Pocetak.Equals(t1.Pocetak) && ter.prostorija.Equals(t1.prostorija))
                {
                    MessageBox.Show("Postoji termin u izabranom vremenu", "Greska");
                    return;
                }
            }

            if (cbTip.SelectedIndex == 0)
            {
                t1.Tip = TipTerminaEnum.Pregled;
            }
            else if (cbTip.SelectedIndex == 1)
            {
                t1.Tip = TipTerminaEnum.Operacija;
            }

            t1.Lekar = controller.NadjiLekaraPoJMBG(lekarLogin.lekar.Jmbg);

            t1.zdravstveniKarton = zkk.KonvertujEntitetUDTO(controller.NadjiKartonID(pacijent.Jmbg));
            if (controller.AzurirajTermin(controller.TerminDTO2Model(t1)))
            {
                controller.PregledSvihTermina().Remove(controller.DTO2ModelNadji(t2));
                controller.PregledSvihTermina().Add(controller.DTO2ModelNadji(t1));
            }
            test.prozor.Content = new lekarStart(lekarLogin.lekar);
            MessageBox.Show("Uspesno ste izmenili pregled!");

        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            if (time.SelectedIndex != -1 && date.SelectedDate.HasValue)
            {
                String t = cboItem.Content.ToString();
                prostorije = controller.DobaviSlobodneProstorije3(t1,DateTime.Parse(date.Text + " " + t),(ProstorijaDTO)cbProstorija.SelectedItem);
                cbProstorija.ItemsSource = prostorije;
                foreach (ProstorijaDTO p in prostorije)
                {
                    if (t1.prostorija == null)
                    {
                        break;
                    }
                    if (p.Id == t1.prostorija.Id)
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
                prostorije = controller.DobaviSlobodneProstorije3(t1,DateTime.Parse(date.Text + " " + t), (ProstorijaDTO)cbProstorija.SelectedItem);
                cbProstorija.ItemsSource = prostorije;
                foreach (ProstorijaDTO p in prostorije)
                {
                    if (t1.prostorija == null)
                    {
                        break;
                    }
                    if (p.Id == t1.prostorija.Id)
                    {
                        cbProstorija.SelectedItem = p;
                    }
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}