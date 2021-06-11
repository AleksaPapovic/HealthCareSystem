using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Pregledi.xaml
    /// </summary>
    public partial class Pregledi : Page
    {
        private TerminController terminKontroler;
        private PacijentDTO pacijentDTO;
        private PacijentController pacijentKontroler;
        private AnketaController anketaController;
        private ObservableCollection<TerminDTO> terminiDTO;

        public Pregledi(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.terminKontroler = new TerminController();
            this.pacijentDTO = pacijentDTO;
            this.pacijentKontroler = new PacijentController();
            anketaController = new AnketaController();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += timer_Tick;
            timer.Start();

            terminiDTO = new ObservableCollection<TerminDTO>(terminKontroler.dobaviListuDTOtermina(pacijentDTO));

            dgTermini.ItemsSource = terminiDTO;
            dgTermini.Loaded += PostaviSirinuKolonaDGT;

            this.DataContext = this;
        }

    

        public void PostaviSirinuKolonaDGT(object source, EventArgs e)
        {
            foreach (var column in dgTermini.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pacijentKontroler.provjeriStatus(pacijentDTO);

        }

        private void ZakaziPregledClick(object sender, RoutedEventArgs e)
        {
            if (pacijentKontroler.pacijentJeBanovan(pacijentDTO))
            {
                MessageBox.Show("Trenutno nije moguće zakazati pregled. Molimo pokušajte kasnije.", "Banovani ste");
            }
            else
            {
                Zakazi zakaziDijalog = new Zakazi(terminiDTO, pacijentDTO);
                zakaziDijalog.Show();
            }
        }
        private void IzmeniPregledClick(object sender, RoutedEventArgs e)
        {
            if (dgTermini.SelectedItem == null)
                System.Windows.MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da izmenite.", "Greška");
            else
            {
                //Termin t = (Termin)dgTermini.SelectedItem;
                //if (t.Pocetak.Date <= DateTime.Today.AddDays(1).Date)
                //{
                //    MessageBox.Show("Nije moguće izmeniti pregled koji je zakazan u predstojećih 24h", "Greška");
                //}
                //else
                //{
                if (pacijentKontroler.pacijentJeBanovan(pacijentDTO))
                {

                    MessageBox.Show("Trenutno nije moguće izmeniti pregled. Molimo pokušajte kasnije.", "Banovani ste");

                    MessageBox.Show("Trenutno nije moguce izmeniti pregled. Molimo pokusajte kasnije.", "Banovani ste");

                }
                else
                {
                    Izmeni ip = new Izmeni((TerminDTO)dgTermini.SelectedItem, terminiDTO, pacijentDTO);
                    ip.Show();
                }
                //}
            }
        }

        private void OtkaziPregledClick(object sender, RoutedEventArgs e)
        {
            if (dgTermini.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da otkažete.", "Greška");
            else
            {
                if (pacijentKontroler.pacijentJeBanovan(pacijentDTO))
                {
                    MessageBox.Show("Trenutno nije moguće otkazati pregled. Molimo pokušajte kasnije.", "Banovani ste");
                }
                else
                {
                    if (MessageBox.Show("Da li ste sigurni da želite da otkažete pregled?", "Otkaži pregled",
                                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        TerminDTO selektovani = (TerminDTO)dgTermini.SelectedItem;
                        terminKontroler.otkaziPregled(selektovani, pacijentDTO);
                        terminiDTO.Remove(selektovani);
                    }
                }
            }
        }


        private void oceniTerminBtn_Click(object sender, RoutedEventArgs e)

        {
            if (dgTermini.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da ocenite.", "Greška");
            else if (anketaController.vecOcijenjen((TerminDTO)dgTermini.SelectedItem))
            {
                MessageBox.Show("Već ste popunili anketu za ovaj pregled.", "Greška");
            }
            else


            {
                AnketiranjeLjekara anketaDijalog =
                    new AnketiranjeLjekara((TerminDTO)dgTermini.SelectedItem, pacijentDTO);
                anketaDijalog.Show();
            }
        }



        private void AnamnezaBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AnamnezaProzor anamneza = new AnamnezaProzor((TerminDTO)dgTermini.SelectedItem, pacijentDTO);
            anamneza.Show();
        }


        private void IstorijaTerminaClick(object sender, RoutedEventArgs e)
        {
            terminiDTO.Clear();
            List<TerminDTO> sviTermini = (List<TerminDTO>)terminKontroler.dobaviListuDTOProslihtermina(pacijentDTO);
            foreach (TerminDTO t in sviTermini)

            {
                AnketiranjeLjekara anketaDijalog =
                    new AnketiranjeLjekara((TerminDTO)dgTermini.SelectedItem, pacijentDTO);
                anketaDijalog.Show();
            }
        }

    }
}
