using Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.ServiceZaKonverzije;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Obavestenja.xaml
    /// </summary>
    public partial class Obavestenja : Page
    {
        private Mediator mediator;
        private PacijentDTO pacijent;
        private Boolean prikaziNotifikaciju;
        private Boolean prikaziBelesku;
        private PacijentController pacijentController = new PacijentController();
        private BeleskaController beleskaController = new BeleskaController();
        private List<BeleskaDTO> beleske = new List<BeleskaDTO>();

        public Obavestenja(PacijentDTO pacijent)
        {
            InitializeComponent();
            this.pacijent = pacijent;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            this.prikaziNotifikaciju = false;
            this.prikaziBelesku = false;
            beleske = beleskaController.dobaviBeleskaDTOs();

            dgObavjestenja.ItemsSource = this.pacijent.notifikacije;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (ReceptDTO r in pacijent.ZdravstveniKarton.recept)
            {
                //System.Diagnostics.Debug.WriteLine("pocetak: " + r.Pocetak + "; sad-3: " + DateTime.Now.AddDays(-3));

                if (r.Pocetak < DateTime.Now.AddDays(-3)) continue;

                DateTime ter = r.Pocetak;

                //System.Diagnostics.Debug.WriteLine("now: " + DateTime.Now + "; ter: " + r.Pocetak);
                //System.Diagnostics.Debug.WriteLine("prikazi should be true at " + ter.AddMinutes(-1));

                // if (DateTime.Now.ToString().Equals(ter.AddMinutes(1).ToString()))
                if (DateTime.Now.ToString().Equals(ter.AddMinutes(-1).ToString())) // upravo otkucalo da je prikažem, >= ispunjeno za sve pa ih sve ispisuje
                {
                    // System.Diagnostics.Debug.WriteLine("'prikazi = true! '");
                    this.prikaziNotifikaciju = true;
                }
                int res = DateTime.Compare(DateTime.Now, ter.AddMinutes(-1));
                // System.Diagnostics.Debug.WriteLine("res je " + res);


                if (this.prikaziNotifikaciju == true && res >= 0)
                {
                    this.prikaziNotifikaciju = false;
                    NotifikacijaDTO n = new NotifikacijaDTO();

                    n.Id = pacijent.notifikacije.Count + 1;
                    n.Datum = ter.AddMinutes(-30);
                    n.Status = "Neprocitano";
                    n.Tip = TipNotifikacije.Podsetnik;
                    n.Sadrzaj = "Popijte lek: " + r.NazivLeka;

                    pacijent.notifikacije.Add(n);
                    pacijentController.dodajNotifikaciju(pacijent);

                }
            }

            foreach (BeleskaDTO beleska in beleske)
            {
                // TODO: provjera autora 
                DateTime ter = beleska.Datum;
                if (DateTime.Now.ToString().Equals(ter.AddMinutes(-1).ToString()))
                {
                    // System.Diagnostics.Debug.WriteLine("'prikazi = true! '");
                    this.prikaziBelesku = true;
                }

                int res = DateTime.Compare(DateTime.Now, ter.AddMinutes(-1));
                // System.Diagnostics.Debug.WriteLine("res je " + res);


                if (this.prikaziBelesku == true && res >= 0)
                {
                    this.prikaziBelesku = false;

                    pacijent.notifikacije.Add(new NotifikacijaDTO(mediator, pacijent.notifikacije.Count + 1, beleska.Datum,
                        TipNotifikacije.Podsetnik, beleska.Sadrzaj, "Neprocitano"));
                    pacijentController.dodajNotifikaciju(pacijent);
                }
            }
        }
    }
}