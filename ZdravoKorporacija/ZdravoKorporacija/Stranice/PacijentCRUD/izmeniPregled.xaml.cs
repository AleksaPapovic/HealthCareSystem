using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for izmeniPregled.xaml
    /// </summary>
    public partial class izmeniPregled : Window
    {
        private TerminService storage = new TerminService();
        private LekarRepozitorijum ljekariDat = new LekarRepozitorijum();
        private List<Lekar> ljekari;
        private BindingList<LekarDTO> dostupniLjekari;
        private ObservableCollection<Termin> pregledi;
        private Termin p;
        private Termin s;
        String datumSelekt;
        String vrijemeSelekt;
        private PacijentDTO pacijent;
        private List<LekarDTO> lekari = new List<LekarDTO>();
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
        private TerminDTO t1;
        private TerminDTO t2;
        private TerminController controller = new TerminController();
        private ZdravstveniKartonKonverter zkk = new ZdravstveniKartonKonverter();

        public izmeniPregled(Termin selektovani, ObservableCollection<Termin> termini, Pacijent pacijent)
        {

            InitializeComponent();
            dostupniLjekari = new BindingList<LekarDTO>();
            ljekari = ljekariDat.dobaviSve();
            this.pacijent = controller.NadjiPacijentaPoJMBGDTO(pacijent.Jmbg);
            pacijenti = controller.PregledSvihPacijenata2DTO();
            prostorije = controller.PregledSvihProstorijaDTO(null);
            lekari = controller.PregledSvihLekaraDTO(null);


            t1 = controller.Model2DTO(selektovani);
            t2 = t1;




            t1.zdravstveniKarton = zkk.KonvertujEntitetUDTO(selektovani.zdravstveniKarton);
            t1.Tip = selektovani.Tip;
            t1.Trajanje = 0.5;
            t1.Id = t2.Id;
            ////// **********************
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, selektovani.Pocetak.AddDays(-3));
            CalendarDateRange kalendar1 = new CalendarDateRange(selektovani.Pocetak.AddDays(3), DateTime.MaxValue);
            date.BlackoutDates.Add(kalendar);
            date.BlackoutDates.Add(kalendar1);

            date.SelectedDate = selektovani.Pocetak;
            DateTime danas = DateTime.Today;
            List<String> source = new List<String>();
            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());
            }

        }

        private void azurirajDostupne()
        {
            if (dostupniLjekari != null)
            {
                dostupniLjekari.Clear();
            }

            foreach (LekarDTO lll in lekari)
            {
                dostupniLjekari.Add(lll);
            }

            ljekar.ItemsSource = dostupniLjekari;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            t1.Lekar = (LekarDTO)ljekar.SelectedItem;
            t1.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            t1.zdravstveniKarton = zkk.KonvertujEntitetUDTO(controller.NadjiKartonID(pacijent.Jmbg));



            if (controller.AzurirajTerminPacijent(controller.TerminDTO2Model(t1), controller.PacijentDTO2Model(pacijent)))
            {
                controller.PregledSvihTermina().Remove(controller.DTO2ModelNadji(t2));
                controller.PregledSvihTermina().Add(controller.DTO2ModelNadji(t1));


            }
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


        private void timeChanged(object sender, SelectionChangedEventArgs e)
        {
            azurirajDostupne();

            t1.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem);

            if (!(t1.Pocetak.ToShortTimeString().Equals(vrijemeSelekt)))
            {

                if (!((t1.Pocetak.ToShortDateString().Equals(datumSelekt)) && t1.Pocetak.ToShortTimeString().Equals(vrijemeSelekt)))
                {

                    controller.PregledSvihTermina2DTO(null).Remove(t1);
                    foreach (TerminDTO term in controller.PregledSvihTermina2DTO(null))
                    {
                        if (term.Pocetak.Equals(t1.Pocetak))
                        {
                            foreach (LekarDTO l in lekari.ToArray())
                            {
                                if (l.Jmbg.Equals(term.Lekar.Jmbg))
                                {
                                    dostupniLjekari.Remove(l);
                                    ljekar.SelectedItem = null;
                                }
                            }
                        }
                    }
                }

            }

        }
        private void dateChanged(object sender, SelectionChangedEventArgs e)
        {
            azurirajDostupne();

            t1.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem);

            if (!(t1.Pocetak.ToShortDateString().Equals(datumSelekt)))
            {
                if (!((t1.Pocetak.ToShortDateString().Equals(datumSelekt)))) //&& p.Pocetak.ToShortTimeString().Equals(vrijemeSelekt)))
                {
                    controller.PregledSvihTermina2DTO(null).Remove(t1);

                    foreach (TerminDTO term in controller.PregledSvihTermina2DTO(null))
                    {


                        if (term.Pocetak.ToString().Equals(t1.Pocetak.ToString()))
                        {
                            foreach (LekarDTO l in lekari.ToArray())
                            {
                                if (l.Jmbg.Equals(term.Lekar.Jmbg))
                                {
                                    dostupniLjekari.Remove(l);
                                    ljekar.SelectedItem = null;
                                }
                            }
                        }
                    }
                }
            }





        }

    }
}
