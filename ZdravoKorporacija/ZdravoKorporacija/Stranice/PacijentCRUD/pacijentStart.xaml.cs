using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.ServiceSekretarUtility;
using ZdravoKorporacija.ServiceZaKonverzije;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for pacijentStart.xaml
    /// </summary>
    public partial class pacijentStart : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        private Pacijent pacijent = new Pacijent();
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private Boolean prikazi;
        private ObavestenjaSekretarUtility os = new ObavestenjaSekretarUtility();
        private TerminController controller = new TerminController();
        private Mediator mediator;
        private AnketaRepozitorijum arepo = new AnketaRepozitorijum();
        private KorisnikService korisnikServis = new KorisnikService();

        public pacijentStart(Pacijent pacijent)
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            this.prikazi = false;
            os.generisiObavestenja();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            ids = datotekaID.dobaviSve();

            ObservableCollection<Termin> sviTermini = new ObservableCollection<Termin>(storage.PregledSvihTermina());
            foreach (Termin t in sviTermini)
            {
                if (t != null)
                    if (t.zdravstveniKarton != null && t.zdravstveniKarton.Id.Equals(pacijent.ZdravstveniKarton.Id))
                    {
                        termini.Add(t);
                    }
            }
            dgUsers.ItemsSource = termini;
            this.DataContext = this;
            this.pacijent = pacijent;
            dgObavjestenja.ItemsSource = pacijent.notifikacije;

            List<Anketa> ankete = arepo.DobaviSve();

            Anketa poslednja = (Anketa)ankete.LastOrDefault(s => s.IdAutora.Equals(pacijent.Jmbg) && s.Termin == null);


            if (poslednja != null && DateTime.Compare(poslednja.Datum, DateTime.Parse(DateTime.Now.AddMinutes(-9).ToString())) <= 0)
            {
                anketaB.Visibility = Visibility.Visible;
            }
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            korisnikServis.provjeriStatus(pacijent);

            foreach (Recept r in pacijent.ZdravstveniKarton.recept)
            {
                DateTime ter = r.Pocetak;

                //    Debug.WriteLine("termin: " + ter.ToString() + ", sad je: " + DateTime.Now.ToString()); //*

                //if (DateTime.Compare(DateTime.Now, ter.AddMinutes(-1)) == 0) // ovo i za jednake vraca 1, nikad 0 ....
                //{
                //    this.prikazi = true;
                //}
                //Debug.WriteLine("prikazi " + this.prikazi); //*

                if (DateTime.Now.ToString().Equals(ter.AddMinutes(1).ToString()))
                {
                    this.prikazi = true;
                }


                int res = DateTime.Compare(DateTime.Now, ter.AddMinutes(1));

                // Debug.WriteLine("res je " + res); //*

                if (this.prikazi == true && res >= 0)
                {
                    this.prikazi = false;
                    Notifikacija n = new Notifikacija();

                    n.Id = pacijent.notifikacije.Count + 1;
                    n.Datum = ter.AddMinutes(-30);
                    n.Status = "Neprocitano";
                    n.Tip = TipNotifikacije.Podsetnik;
                    n.Sadrzaj = "Popijte lek: " + r.NazivLeka;

                    pacijent.notifikacije.Add(n);
                    storagePacijent.AzurirajPacijenta(pacijent);

                }
            }
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {

            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da izmenite.", "Greška");
            else
            {
                Termin t = (Termin)dgUsers.SelectedItem;
                // Debug.WriteLine("Danas je " + DateTime.Today.ToString());
                if (t.Pocetak.Date <= DateTime.Today.AddDays(1).Date)
                {
                    MessageBox.Show("Nije moguće izmeniti pregled koji je zakazan u predstojećih 24h", "Greška");
                }
                else
                {
                    if (pacijent.banovan)
                    {
                        MessageBox.Show("Trenutno nije moguce izmeniti pregled. Molimo pokusajte kasnije.", "Banovani ste");
                    }
                    else
                    {
                        izmeniPregled ip = new izmeniPregled((Termin)dgUsers.SelectedItem, termini, pacijent);
                        ip.Show();
                    }
                }
            }
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            if (pacijent.banovan)
            {
                MessageBox.Show("Trenutno nije moguce zakazati pregled. Molimo pokusajte kasnije.", "Banovani ste");
            }
            else
            {
                zakaziPregled zp = new zakaziPregled(ids, pacijent.Jmbg);
                zp.Show();
            }
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        {

            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da otkažete.", "Greška");
            else
            {
                if (pacijent.banovan)
                {
                    MessageBox.Show("Trenutno nije moguce otkazati pregled. Molimo pokusajte kasnije.", "Banovani ste");
                }
                else
                {
                    LekarCRUD.oktaziPregledLekar op = new LekarCRUD.oktaziPregledLekar(controller.Model2DTO((Termin)dgUsers.SelectedItem));
                    op.Show();
                }
            }


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void anketiranjeLjekara(object sender, RoutedEventArgs e)
        {
            Termin sel = (Termin)dgUsers.SelectedItem;
            if (DateTime.Compare(DateTime.Now, sel.Pocetak.AddMinutes(sel.Trajanje)) >= 0)
            {
                List<Anketa> ankete = arepo.DobaviSve();
                List<Anketa> anketeSaTerminima = new List<Anketa>();
                foreach (Anketa an in ankete)
                {
                    if (an.Termin != null) anketeSaTerminima.Add(an);
                }

                Anketa a = (Anketa)anketeSaTerminima.FirstOrDefault(s => s.Termin.Id.Equals(sel.Id) && s.IdAutora.Equals(pacijent.Jmbg));

                if (a != null)
                {
                    MessageBox.Show("Već ste popunili anketu za ovaj pregled.", "Greška");
                }
                else
                {
                    //AnketiranjeLjekara ak = new AnketiranjeLjekara(sel, pacijent);
                    //ak.Show();
                }

            }
            else
            {
                MessageBox.Show("Nije moguće popuniti anketu za neobavljeni pregled.", "Greška");
            }
        }

        private void popuniAnketu(object sender, RoutedEventArgs e)
        {
            //AnketiranjeBolnice ab = new AnketiranjeBolnice(pacijent);
            //ab.Show();
            //anketaB.Visibility = Visibility.Hidden;

        }
    }
}
