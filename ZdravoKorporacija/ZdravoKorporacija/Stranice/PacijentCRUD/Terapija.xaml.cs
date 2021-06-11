using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Terapija.xaml
    /// </summary>
    public partial class Terapija : Page
    {
        private PacijentDTO pacijentDTO;
        private PrintDialog _printDialog = new PrintDialog();

        public Terapija(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.pacijentDTO = pacijentDTO;
            calendarComponents();

            mjeseci.SelectionChanged += (o, e) => osvjeziPrikazKalendara();
            godine.SelectionChanged += (o, e) => osvjeziPrikazKalendara();
            
        }

        private void dodajNotes()
        {
            string str;
            foreach (ReceptDTO r in pacijentDTO.ZdravstveniKarton.recept)
            {
                str = "Lek: " + r.NazivLeka + "@" + "Vreme: " + r.Pocetak.ToShortTimeString() + "@";
                str = str.Replace("@", " " + Environment.NewLine);

                string boo = r.Pocetak.ToUniversalTime().ToString("MMMM");
                int th = DateTime.ParseExact(boo, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                if (mjeseci.SelectedIndex == (th - 1))
                
                {
                    kalendar.Days[(int)r.Pocetak.Day + 1].Notes = str;
                }
                
            }
        }
        private void osvjeziPrikazKalendara()
        {
            if (godine.SelectedItem == null) return;
            if (mjeseci.SelectedItem == null) return;

            int year = (int)godine.SelectedItem;

            int month = mjeseci.SelectedIndex + 1;

            DateTime targetDate = new DateTime(year, month, 1);

            kalendar.BuildCalendar(targetDate);

            dodajNotes();

        }

        public void calendarComponents()
        {
            List<string> mjesec = new List<string> { "Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust",
                                                                        "Septembar", "Oktobar", "Novembar", "Decembar" };
            mjeseci.ItemsSource = mjesec;

            for (int i = -50; i < 50; i++)
            {
                godine.Items.Add(DateTime.Today.AddYears(i).Year);
            }

            godine.SelectedItem = DateTime.Today.Year;

            string startMonth = DateTime.Now.ToUniversalTime().ToString("MMMM");
            int newmnths = DateTime.ParseExact(startMonth, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
            mjeseci.SelectedIndex = newmnths - 1;

            dodajNotes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnGenerisi.Visibility = Visibility.Hidden;
            _printDialog.PrintVisual(this, "Izveštaj o rasporedu uzimanja terapije");
            btnGenerisi.Visibility = Visibility.Visible;


        }
    }
}
