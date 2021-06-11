using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for zakaziHitno.xaml
    /// </summary>
    public partial class zakaziHitno : Window
    {
        private TerminService ts = new TerminService();
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private List<LekarDTO> lekari = new List<LekarDTO>();
        List<LekarDTO> slobodniLekari = new List<LekarDTO>();
        private ObservableCollection<ProstorijaDTO> slobodneProstorije;
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
        private List<TerminDTO> alternativniTermini = new List<TerminDTO>();
        private bool kardio;
        private bool neuro;
        private TerminController controller = new TerminController();
        private TerminDTO noviTermin;
        SpecijalizacijaEnum specijalizacija;
        private ZdravstveniKartonKonverter zkk = new ZdravstveniKartonKonverter();


        private TipTerminaEnum tipTermina;
        private DateTime pocetakTermina;
        private LekarDTO lekarTermina;
        private ProstorijaDTO prostorijaTermina;
        public zakaziHitno(Dictionary<int, int> ids)
        {
            InitializeComponent();
            noviTermin = new TerminDTO();

            kardio = false;
            neuro = false;
            pacijenti = controller.PregledSvihPacijenata2DTO();
            cbPacijent.ItemsSource = pacijenti;
            this.ids = ids;
            lekari = controller.PregledSvihLekaraDTO(null);
            slobodniLekari = lekari;

            specijalizacija = SpecijalizacijaEnum.OpstaPraksa;



            prostorije = controller.PregledSvihProstorijaDTO(null);

            slobodneProstorije = prostorije;
            alternative.ItemsSource = alternativniTermini;

        }
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            if (kardio == true)
                specijalizacija = SpecijalizacijaEnum.Kardiohirurg;
            else if (neuro == true)
                specijalizacija = SpecijalizacijaEnum.Neurolog;

            if (cbTip.SelectedIndex == 0)
            {
                alternativniTermini = controller.PregledSvihTermina2DTO(controller.NadjiAlternativnePreglede());
                alternative.ItemsSource = alternativniTermini;
                tipTermina = TipTerminaEnum.Pregled;
                Dodaj();

            }
            else if (cbTip.SelectedIndex == 1)
            {

                alternativniTermini = controller.PregledSvihTermina2DTO(controller.NadjiAlternativneOperacije());
                alternative.ItemsSource = alternativniTermini;
                tipTermina = TipTerminaEnum.Operacija;
                Dodaj();
            }
        }

        private void Dodaj()
        {
            slobodniLekari = controller.PregledSvihLekaraDTO(controller.DobaviSlobodneLekareHITNO(specijalizacija));

            slobodneProstorije = controller.PregledSvihProstorijaDTO(new ObservableCollection<Prostorija>(controller.DobaviSlobodneProstorijeHITNO()));

            if (slobodniLekari.Count() == 0 || slobodneProstorije.Count() == 0)
            {
                MessageBox.Show("Nema slobodnih termina ATM!!!");
                alternative.Visibility = Visibility.Visible;



            }
            else
            {
                int id = controller.MapaTermina(ids);

                PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;



                lekarTermina = slobodniLekari.ElementAt<LekarDTO>(slobodniLekari.Count() - 1);
                prostorijaTermina = slobodneProstorije.ElementAt<ProstorijaDTO>(slobodneProstorije.Count() - 1);
                pocetakTermina = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30));


                noviTermin = new TerminDTO(new ZdravstveniKartonDTO(controller.NadjiKartonID(pac.Jmbg)), prostorijaTermina, lekarTermina, tipTermina, pocetakTermina, 0.5, null);
                noviTermin.hitno = true;
                noviTermin.Id = id;
                if (controller.ZakaziTermin(controller.TerminDTO2Model(noviTermin), ids))
                {
                    controller.DodajTermin(controller.TerminDTO2Model(noviTermin));
                    controller.AzurirajLekare();
                }


                controller.DodajTermin(controller.PacijentDTO2Model(pac), controller.TerminDTO2Model(noviTermin));
                controller.AzurirajPacijenta(controller.PacijentDTO2Model(pac));
                this.Close();
            }
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void zameni(object sender, RoutedEventArgs e)
        {
            TerminDTO t = new TerminDTO();
            t = (TerminDTO)alternative.SelectedItem;
            foreach (TerminDTO term in alternativniTermini)
            {
                if (term.Id.Equals(t.Id))
                {

                    PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;
                    term.zdravstveniKarton = zkk.KonvertujEntitetUDTO(controller.NadjiKartonID(pac.Jmbg));
                    if (ts.AzurirajTermin(controller.TerminDTO2Model(term)))
                    {
                        controller.PregledSvihTermina().Remove(controller.TerminDTO2Model(t));
                        controller.PregledSvihTermina().Add(controller.TerminDTO2Model(term));
                    }
                    this.Close();
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            kardio = true;
            neuroKB.IsChecked = false;

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            neuro = true;
            kardioRB.IsChecked = false;

        }
    }
}