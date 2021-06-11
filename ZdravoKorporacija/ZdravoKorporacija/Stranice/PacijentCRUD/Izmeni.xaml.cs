using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Izmeni.xaml
    /// </summary>
    public partial class Izmeni : Window
    {
        private PacijentDTO pacijentDTO;
        private TerminDTO selektovanidto;
        private TerminDTO noviTermindDTO;
        private ObservableCollection<TerminDTO> mojiPregledi;
        private BindingList<LekarDTO> dostupniLjekaridto;
        private List<LekarDTO> ljekaridto;
        private LekarController lekarKontroler = new LekarController();
        private TerminController terminKontroler = new TerminController();
        private PacijentController pacijentKontroler = new PacijentController();

        public Izmeni(TerminDTO selektovani, ObservableCollection<TerminDTO> termini, PacijentDTO pacijentDTO)
        {
            InitializeComponent();

            this.pacijentDTO = pacijentDTO;
            this.selektovanidto = selektovani;
            this.noviTermindDTO = new TerminDTO();
            this.mojiPregledi = termini; //pregledi
            this.dostupniLjekaridto = new BindingList<LekarDTO>();
            this.ljekaridto = (List<LekarDTO>)lekarKontroler.dobaviListuDTOLekara();
            dostupniLjekaridto = new BindingList<LekarDTO>(ljekaridto);
            ljekar.ItemsSource = dostupniLjekaridto;
            inicijalizujKomponente();
        //    azurirajDostupne();


        }

        private void inicijalizujKomponente()
        {


            ////// **********************
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(kalendar);

            date.SelectedDate = selektovanidto.Pocetak;
            DateTime danas = DateTime.Today;
            List<String> source = new List<String>();
            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());
            }

            time.SelectedItem = selektovanidto.Pocetak.ToShortTimeString();

            foreach (LekarDTO l in dostupniLjekaridto)
            {
                if (l.Jmbg == selektovanidto.Lekar.Jmbg)
                {
                    ljekar.SelectedItem = l;
                }
            }

        }

        private void azurirajDostupne()
        {

            if (dostupniLjekaridto != null)
            {
                dostupniLjekaridto.Clear();
            }

            foreach (LekarDTO lll in ljekaridto)
            {
                dostupniLjekaridto.Add(lll);
                

            }

            ljekar.ItemsSource = dostupniLjekaridto;

            foreach (LekarDTO l in dostupniLjekaridto)
            {
                if (l.Jmbg == selektovanidto.Lekar.Jmbg)
                {
                    ljekar.SelectedItem = l;
                }
            }
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            noviTermindDTO.Lekar = (LekarDTO)ljekar.SelectedItem;
            noviTermindDTO.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            noviTermindDTO.zdravstveniKarton = pacijentDTO.ZdravstveniKarton;

            terminKontroler.pomeriPregled(noviTermindDTO, pacijentDTO);
            pacijentKontroler.azurirajBanInfo(pacijentDTO, 1);
            this.mojiPregledi.Remove(selektovanidto);
            this.mojiPregledi.Add(noviTermindDTO);
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void timeChanged(object sender, SelectionChangedEventArgs e)
        {
            noviTermindDTO.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem);

                if(!noviTermindDTO.Pocetak.ToString().Equals(selektovanidto.Pocetak.ToString()))
                {
                System.Diagnostics.Debug.WriteLine("u time");
                //azurirajDostupne();
                if (!(noviTermindDTO.Pocetak.ToShortTimeString().Equals(selektovanidto.Pocetak.ToShortTimeString())))
                    {

                        if (!((noviTermindDTO.Pocetak.ToShortDateString().Equals(selektovanidto.Pocetak.ToShortDateString())) && noviTermindDTO.Pocetak.ToShortTimeString().Equals(selektovanidto.Pocetak.ToShortTimeString())))
                        {

                            mojiPregledi.Remove(noviTermindDTO);
                            foreach (TerminDTO term in mojiPregledi)
                            {
                                if (term.Pocetak.Equals(noviTermindDTO.Pocetak))
                                {
                                    foreach (LekarDTO l in ljekaridto.ToArray())
                                    {
                                        if (l.Jmbg.Equals(term.Lekar.Jmbg))
                                        {
                                            dostupniLjekaridto.Remove(l);
                                            ljekar.SelectedItem = null;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

        }
        private void dateChanged(object sender, SelectionChangedEventArgs e)
        {
            

            noviTermindDTO.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem);

            if(!noviTermindDTO.Pocetak.ToShortDateString().Equals(selektovanidto.Pocetak.ToShortDateString()))
            {
                System.Diagnostics.Debug.WriteLine("u date");
               // azurirajDostupne();

                if (!(noviTermindDTO.Pocetak.ToShortDateString().Equals(selektovanidto.Pocetak.ToShortDateString())))
                {
                    if (!((noviTermindDTO.Pocetak.ToShortDateString().Equals(selektovanidto.Pocetak.ToShortDateString())))) //&& p.Pocetak.ToShortTimeString().Equals(vrijemeSelekt)))
                    {
                        mojiPregledi.Remove(noviTermindDTO);

                        foreach (TerminDTO term in mojiPregledi)
                        {


                            if (term.Pocetak.ToString().Equals(noviTermindDTO.Pocetak.ToString()))
                            {
                                foreach (LekarDTO l in ljekaridto.ToArray())
                                {
                                    if (l.Jmbg.Equals(term.Lekar.Jmbg))
                                    {
                                        dostupniLjekaridto.Remove(l);
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
}
