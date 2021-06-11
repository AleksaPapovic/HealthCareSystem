
using Repository;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.LekoviCRUD;
using ZdravoKorporacija.Stranice.Uput;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for lekarStart.xaml
    /// </summary>
    public partial class lekarStart : Page
    {
        private TerminController terminController = TerminController.Instance;
        private ObservableCollection<TerminDTO> terminiSvi = new ObservableCollection<TerminDTO>();
        public static ObservableCollection<TerminDTO> termini = new ObservableCollection<TerminDTO>();
        public static ObservableCollection<TerminDTO> uputi = new ObservableCollection<TerminDTO>();
        public static ObservableCollection<TerminDTO> terminiDTO = new ObservableCollection<TerminDTO>();

        public lekarStart(LekarDTO lekar)
        {
            InitializeComponent();
            termini = new ObservableCollection<TerminDTO>();
            uputi = new ObservableCollection<TerminDTO>();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");

            terminiSvi = new ObservableCollection<TerminDTO>(terminController.PregledSvihTermina2());

            foreach (TerminDTO t in terminiSvi)
            {
                if (t.Lekar != null)
                {
                    if (t.Lekar.Jmbg.Equals(lekar.Jmbg))
                    {
                        if (!termini.Contains(t))
                        {
                            termini.Add(t);
                        }
                    }
                    else
                    {
                        if (!uputi.Contains(t))
                        {
                            uputi.Add(t);
                        }
                    }
                }
            }

            dgUsers.ItemsSource = termini;
            this.DataContext = this;
        }

        private void textBox1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var filtered = termini.Where(termin => termin.Pocetak.ToString().StartsWith(searchBar.Text));
            dgUsers.ItemsSource = filtered;
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da izmenite.", "Greška");
            else
            {
                test.prozor.Content = new izmeniPregledLekar((TerminDTO)dgUsers.SelectedItem);
            }
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new zakaziPregledLekar();
        }

        private void prikaziKarton(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new zdravstveniKartonPrikaz((TerminDTO)dgUsers.SelectedItem);
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                oktaziPregledLekar op = new oktaziPregledLekar((TerminDTO)dgUsers.SelectedItem);
                op.Show();
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            pregledPacijenata pp = new pregledPacijenata();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Uputi u = new Uputi();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            LekarZahteviZaDodavanjeLekaStart l = new LekarZahteviZaDodavanjeLekaStart();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }


        private void Label_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
