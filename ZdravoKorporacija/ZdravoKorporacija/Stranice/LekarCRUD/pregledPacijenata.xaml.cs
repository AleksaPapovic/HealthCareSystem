using Service;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.StacionarnoLecenje;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for pregledPacijenata.xaml
    /// </summary>
    public partial class pregledPacijenata : Page
    {
        private PacijentService pacijentServis = PacijentService.Instance;
        private ObservableCollection<PacijentDTO> pacijentiPrikaz = new ObservableCollection<PacijentDTO>();

        public pregledPacijenata()
        {
            InitializeComponent();

            try
            {
                foreach (PacijentDTO p in pacijentServis.PregledSvihPacijenata2())
                {
                    foreach (TerminDTO t in lekarStart.termini)
                    {
                        if (t.zdravstveniKarton != null)
                        {
                            if (t.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                            {
                                if (!pacijentiPrikaz.Contains(p))
                                {
                                    pacijentiPrikaz.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                }
                dgUsers.ItemsSource = pacijentiPrikaz;
                this.DataContext = this;
            }
            catch (NullReferenceException)
            {
                return;
            }

        }
        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void textBox1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var filtered = pacijentiPrikaz.Where(pacijent => pacijent.Ime.StartsWith(searchBar.Text));
            dgUsers.ItemsSource = filtered;
        }
        private void prikazKartona(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                test.prozor.Content = new zdravstveniKartonPrikaz((PacijentDTO)dgUsers.SelectedItem);
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }
        }

        private void stacionarnoLecenje(object sender, RoutedEventArgs e)
        {
            stacionarnoStart ss = null;
            if (dgUsers.SelectedItem != null)
            {
                ss = new stacionarnoStart((PacijentDTO)dgUsers.SelectedItem);
                test.prozor.Content = ss;
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }
        }
        private void uputiZaStacionarno(object sender, RoutedEventArgs e)
        {
            uputiZaStacionarno ss = null;
            if (dgUsers.SelectedItem != null)
            {
                ss = new uputiZaStacionarno((PacijentDTO)dgUsers.SelectedItem);
                test.prozor.Content = ss;
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }
        }


       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog _printDialog = new PrintDialog();
            _printDialog.PrintVisual(this, "Izvestaj o trenutnom stanju lekova");
            MessageBox.Show("Uspesno ste izgenerisali izvestaj!");
        }
    }
}
