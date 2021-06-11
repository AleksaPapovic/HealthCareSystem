using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for izdajRecept.xaml
    /// </summary>
    public partial class izdajRecept : Page
    {
        private PacijentController pacijentController = PacijentController.Instance;
        private LekController lekController = LekController.Instance;
        private ObservableCollection<LekDTO> lekovi;
        PacijentDTO pac;
        TerminDTO ter;
        ReceptDTO r = new ReceptDTO();

        public izdajRecept(PacijentDTO selektovani)
        {
            bool ne = false;
            InitializeComponent();
            this.DataContext = this;
            lekovi = new ObservableCollection<LekDTO>();
            pac = selektovani;
            if (pac.ZdravstveniKarton.Alergije != null)
            {

                foreach (LekDTO lek in lekController.PregledSvihLekova())
                {
                    if (lek.Alergeni != null)
                    {
                        foreach (String st in lek.Alergeni.Split(","))
                        {
                            foreach (String s in pac.ZdravstveniKarton.Alergije.Split(","))
                            {

                                if (s.Equals(st))
                                {
                                    ne = true;
                                }
                            }

                        }

                    }

                    if (!ne)
                    {
                        lekovi.Add(lek);
                    }
                }
            }
            else { lekovi = new ObservableCollection<LekDTO>(lekController.PregledSvihLekova()); }
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            Date.BlackoutDates.Add(cdr);

            lekNaziv.ItemsSource = lekovi;

        }

        public izdajRecept(TerminDTO selektovani)
        {
            InitializeComponent();
            bool ne = false;
            this.DataContext = this;
            lekovi = new ObservableCollection<LekDTO>();

            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            Date.BlackoutDates.Add(cdr);
            ter = selektovani;

            foreach (PacijentDTO p in pacijentController.PregledSvihPacijenata2())
            {
                if (p.ZdravstveniKarton != null)
                    if (p.ZdravstveniKarton.Id.Equals(ter.zdravstveniKarton.Id))
                        pac = p;
            }
            if (pac.ZdravstveniKarton.Alergije != null)
            {

                foreach (LekDTO lek in lekController.PregledSvihLekova())
                {
                    if (lek.Alergeni != null)
                    {
                        foreach (String st in lek.Alergeni.Split(","))
                        {
                            foreach (String s in pac.ZdravstveniKarton.Alergije.Split(","))
                            {

                                if (s.Equals(st))
                                {
                                    ne = true;
                                }
                            }

                        }

                    }

                    if (!ne)
                    {
                        lekovi.Add(lek);
                    }
                }



            }
            else { lekovi = new ObservableCollection<LekDTO>(lekController.PregledSvihLekova()); }

            lekNaziv.ItemsSource = lekovi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LekDTO l = (LekDTO)lekNaziv.SelectedItem;
            if (string.IsNullOrEmpty(NoviLek.Text))
            {
                r.NazivLeka = l.NazivLeka;
            }
            else
            {
                r.NazivLeka = NoviLek.Text;
            }
            r.Doziranje = Doza.Text;
            r.Trajanje = Int32.Parse(Trajanje.Text);
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String t = null;
            if (cboItem != null)
            {
                t = cboItem.Content.ToString();
            }


            try
            {
                r.Pocetak = DateTime.Parse(Date.Text + " " + t);
            }
            catch (InvalidCastException)
            { }

            if(pacijentController.IzdajRecept(pac, r))
            {
               
                zdravstveniKartonPrikaz.recepti.Add(r);
            }


            if (zdravstveniKartonPrikaz.tab == 1)
            {
                test.prozor.Content = new zdravstveniKartonPrikaz(pac);
            }
            else
            {
                test.prozor.Content = new zdravstveniKartonPrikaz(ter);
            }
            MessageBox.Show("Uspesno ste izdali recept!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (zdravstveniKartonPrikaz.tab == 1)
            {
                test.prozor.Content = new zdravstveniKartonPrikaz(pac);
            }
            else
            {
                test.prozor.Content = new zdravstveniKartonPrikaz(ter);
            }
        }

        private void NoviLek_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NoviLek.Text))
            {
                lekNaziv.IsEnabled = false;
            }
        }


    }
}
