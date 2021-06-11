using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for PocetnaStranica.xaml
    /// </summary>
    public partial class PocetnaStranica : Page
    {
        private PacijentDTO pacijentDTO;
        private TerminController terminKontroler = new TerminController();
        private ObservableCollection<TerminDTO> terminiDTO;

        public PocetnaStranica(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.pacijentDTO = pacijentDTO;
            terminiDTO = new ObservableCollection<TerminDTO>(terminKontroler.dobaviListuDTOtermina(pacijentDTO));
            calendarComponents();



            mjeseci.SelectionChanged += (o, e) => osvjeziPrikazKalendara();
            godine.SelectionChanged += (o, e) => osvjeziPrikazKalendara();
        }

        private void dodajNotes()
        {
            string str;
            foreach (TerminDTO  t in terminiDTO)
            {
                //str = "Lekar: " + t.Lekar.Ime + " " + t.Lekar.Prezime + "@" + "Vreme: " + t.Pocetak.ToShortTimeString() + "@";
                str = "Vreme: " + t.Pocetak.ToShortTimeString() + "@" + "Lekar: " + t.Lekar.Prezime + "@";
                str = str.Replace("@", " " + Environment.NewLine);

                string boo = t.Pocetak.ToUniversalTime().ToString("MMMM");
                int th = DateTime.ParseExact(boo, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                if (mjeseci.SelectedIndex == (th - 1))

                {
                    kalendar.Days[(int)t.Pocetak.Day + 1].Notes = str;
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

            //double width = 0;
            //foreach(ComboBoxItem item in mjeseci.Items)
            //{
            //    item.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            //    if (item.DesiredSize.Width > width)
            //        width = item.DesiredSize.Width;
            //}
            //mjeseci.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            //mjeseci.Width = mjeseci.DesiredSize.Width + width;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AnketiranjeBolnice ab = new AnketiranjeBolnice(pacijentDTO);
            //ab.Show();
            FeedbackPacijent feedbackForma = new FeedbackPacijent(pacijentDTO);
            feedbackForma.Show();
        }
    }
}
