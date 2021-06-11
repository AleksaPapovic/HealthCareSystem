using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Factory;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zdravstveniKartonPrikaz.xaml
    /// </summary>
    public partial class zdravstveniKartonPrikaz : Page
    {
        private static IReceptController _receptController = ReceptControllerFactory.Create();
        private static IIzvestajController _izvestajController = IzvestajControllerFactory.Create();
        private TerminController terminController = TerminController.Instance;
        private PacijentController pacijentController = PacijentController.Instance;
        private ObservableCollection<TerminDTO> termini = new ObservableCollection<TerminDTO>();
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private ZdravstveniKartonDTO zk = new ZdravstveniKartonDTO();
        private ZdravstveniKartonDTO zkt = new ZdravstveniKartonDTO();

        public static ObservableCollection<ReceptDTO> recepti = new ObservableCollection<ReceptDTO>();
        public static ObservableCollection<IzvestajDTO> izvestaji = new ObservableCollection<IzvestajDTO>();
        PacijentDTO pac = new PacijentDTO();
        TerminDTO sel = new TerminDTO();

        public static int tab = 0;

        public zdravstveniKartonPrikaz(PacijentDTO selektovani)
        {
            _receptController = ReceptControllerFactory.Create();
            _izvestajController = IzvestajControllerFactory.Create();
            InitializeComponent();
            recepti = new ObservableCollection<ReceptDTO>();
            izvestaji = new ObservableCollection<IzvestajDTO>();
            this.DataContext = this;
            pacijenti = pacijentController.PregledSvihPacijenata2();
            foreach (PacijentDTO p in pacijenti)
            {
                if (p.Jmbg.Equals(selektovani.Jmbg))
                    pac = p;
            }
            zk = pac.ZdravstveniKarton;
            tab = 1;

            foreach (IzvestajDTO iz in _izvestajController.PregledSvihIzvestaja())
            {
                if(pac.termin!=null)
                foreach (TerminDTO ter in pac.termin)
                {
                    if (ter.izvestaj.Id.Equals(iz.Id) && !izvestaji.Contains(iz))
                    {
                        izvestaji.Add(iz);
                        break;
                    }
                }
            }

            izvestajGrid.ItemsSource = izvestaji;
            dodajAnamnezu.Visibility = Visibility.Hidden;

            try
            {
                if (zk.Alergije != null)
                    AlergijeListBox.ItemsSource = zk.Alergije.Split(",");
            }
            catch (NullReferenceException) { }
            //Trace.WriteLine(pac.ZdravstveniKarton.recept[0]);
            foreach (ReceptDTO r in _receptController.PregledSvihRecepata())
            {
                foreach (ReceptDTO rec in pac.ZdravstveniKarton.recept)
                {
                    if (r.Id.Equals(rec.Id))
                    {

                        recepti.Add(r);
                        break;
                    }
                }
            }
            //recepti = new ObservableCollection<ReceptDTO>(pac.ZdravstveniKarton.recept);
            terapijaGrid.ItemsSource = recepti;

            this.DataContext = this;

            ImeLabel.Content = selektovani.Ime;
            PrezimeLabel.Content = selektovani.Prezime;
            BrojTelefonaLabel.Content = selektovani.BrojTelefona;
            JMBGLabel.Content = selektovani.Jmbg;
            PolLabel.Content = selektovani.Pol;

            try { KrvnaGrupaLabel.Content = zk.KrvnaGrupa; }
            catch (NullReferenceException)
            { }
        }

        public zdravstveniKartonPrikaz(TerminDTO t)
        {
            InitializeComponent();
            _receptController = ReceptControllerFactory.Create();
            _izvestajController = IzvestajControllerFactory.Create();
            recepti = new ObservableCollection<ReceptDTO>();
            izvestaji = new ObservableCollection<IzvestajDTO>();
            pacijenti = pacijentController.PregledSvihPacijenata2();

            zkt = t.zdravstveniKarton;
            tab = 2;
            sel = t;

            foreach (PacijentDTO pacijent in pacijentController.PregledSvihPacijenata2())
            {
                if (pacijent.ZdravstveniKarton.Id.Equals(zkt.Id))
                {
                    pac = pacijent;
                    break;
                }
            }
            foreach (IzvestajDTO iz in _izvestajController.PregledSvihIzvestaja())
            {
                if (pac != null && (pac.termin!=null))
                {
                    foreach (TerminDTO ter in pac.termin)
                    {
                        if (ter.izvestaj.Id.Equals(iz.Id))
                        {
                            izvestaji.Add(iz);
                            break;
                        }
                    }
                }
            }


            izvestajGrid.ItemsSource = izvestaji;
            try
            {
                if (zkt.Alergije != null)
                    AlergijeListBox.ItemsSource = zkt.Alergije.Split(",");
            }
            catch (NullReferenceException) { }


            foreach (ReceptDTO r in _receptController.PregledSvihRecepata())
            {
                if (pac.ZdravstveniKarton!=null)
                foreach (ReceptDTO rec in pac.ZdravstveniKarton.recept)
                {
                    if (r.Id.Equals(rec.Id))
                    {
                        recepti.Add(r);
                        break;
                    }
                }
            }

            ImeLabel.Content = pac.Ime;
            PrezimeLabel.Content = pac.Prezime;
            BrojTelefonaLabel.Content = pac.BrojTelefona;
            JMBGLabel.Content = pac.Jmbg;
            PolLabel.Content = pac.Pol;
            terapijaGrid.ItemsSource = recepti;

            try { KrvnaGrupaLabel.Content = pac.ZdravstveniKarton.KrvnaGrupa; }
            catch (NullReferenceException) { }

            this.DataContext = this;

        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            izdajRecept izdaj = null;
            if (tab == 1)
            {
                izdaj = new izdajRecept(pac);

            }
            else if (tab == 2)
            {
                izdaj = new izdajRecept(sel);
            }
            test.prozor.Content = izdaj;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ReceptDTO r = (ReceptDTO)terapijaGrid.SelectedItem;

            pacijentController.ObrisiRecept(pac, r);
            recepti.Remove(r);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dodajAnamnezu anamneza = new dodajAnamnezu(sel);
            test.prozor.Content = anamneza;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IzvestajDTO iz = (IzvestajDTO)izvestajGrid.SelectedItem;

            if (tab == 1)
            {
                foreach (TerminDTO t in termini)
                {
                    if (t.izvestaj != null)
                        if (t.izvestaj.Id.Equals(iz.Id))
                        {
                            sel = t;
                        }
                }
            }
            else if (tab == 2)
            {
                foreach (PacijentDTO p in pacijenti)
                {
                    if (sel.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                        pac = p;
                }
            }

            terminController.ObrisiAnamnezu(iz, sel);
            izvestaji.Remove(iz);
        }
    }
}
