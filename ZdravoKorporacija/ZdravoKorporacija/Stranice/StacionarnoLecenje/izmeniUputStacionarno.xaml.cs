using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.LekarCRUD;

namespace ZdravoKorporacija.Stranice.StacionarnoLecenje
{
    /// <summary>
    /// Interaction logic for izmeniUputStacionarno.xaml

    public partial class izmeniUputStacionarno : Page
    {
        private TerminController terminController = TerminController.Instance;
        private ProstorijaController prostorijeController = new ProstorijaController();
        private StacionarnoLecenjeController sl = StacionarnoLecenjeController.Instance;
        private List<TerminDTO> termini = new List<TerminDTO>();
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
        private StacionarnoLecenjeDTO stacionarnoLecenje = new StacionarnoLecenjeDTO();
        private StacionarnoLecenjeDTO stacionarno;



        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;



        public izmeniUputStacionarno(PacijentDTO pacijent, StacionarnoLecenjeDTO stacionarno)
        {
            InitializeComponent();

            stacionarnoLecenje.Pacijent = pacijent;
            this.stacionarno = stacionarno;


            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);


            prostorije = prostorijeController.PregledSvihProstorija2();
            cbProstorija.ItemsSource = prostorije;
            date.SelectedDate = stacionarno.Pocetak;
            time.SelectedValue = stacionarno.Pocetak.ToString("HH:mm");
            trajanjeText.Text = stacionarno.Trajanje;
            foreach (ProstorijaDTO p in prostorijeController.PregledSvihProstorija2())
            {
                if (stacionarno.Prostorija == null)
                {
                    break;
                }
                if (p.Id == stacionarno.Prostorija.Id)
                {
                    cbProstorija.SelectedItem = p;
                }
            }
            cbProstorija.SelectedItem = stacionarno.Prostorija.Naziv;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            termini = terminController.PregledSvihTermina2();

            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            stacionarnoLecenje.Trajanje = trajanjeText.Text;
            String d = date.Text;
            String t = null;
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;
            if (!date.SelectedDate.HasValue || time.SelectedIndex == -1
                || cbProstorija.SelectedIndex == -1)
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
            stacionarnoLecenje.Prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;
            try
            {
                stacionarnoLecenje.Pocetak = DateTime.Parse(d + " " + t);
            }
            catch (InvalidCastException)
            { }
            foreach (TerminDTO ter in termini)
            {
                if (ter.Pocetak.Equals(stacionarnoLecenje.Pocetak) && ter.prostorija.Id.Equals(stacionarnoLecenje.Prostorija.Id))
                {
                    MessageBox.Show("Postoji termin u izabranom vremenu", "Greska");
                    return;
                }
            }
            uputiZaStacionarno.uputi.Remove(stacionarno);
            sl.AzurirajStacionarnoLecenje(stacionarnoLecenje);



            test.prozor.Content = new uputiZaStacionarno(stacionarnoLecenje.Pacijent);
            MessageBox.Show("Uspesno ste izmenili uput za stacionarno lecenje!");
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new uputiZaStacionarno(stacionarnoLecenje.Pacijent);
        }
    }
}
