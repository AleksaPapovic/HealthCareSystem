
using Controller;
using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for zakaziHitno.xaml
    /// </summary>
    public partial class zakaziHitniLekar : Page
    {
        private List<LekarDTO> lekariZaPrikaz = new List<LekarDTO>();
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private List<LekarDTO> lekari = new List<LekarDTO>();
        PacijentController pacijentController = new PacijentController();
        TerminController terminController = TerminController.Instance;
        LekarController lekarController = new LekarController();
        ProstorijaController prostorijaController = new ProstorijaController();

        public zakaziHitniLekar()
        {
            InitializeComponent();
            pacijenti = pacijentController.PregledSvihPacijenata2();
            cbPacijent.ItemsSource = pacijenti;
            lekari = (List<LekarDTO>)lekarController.dobaviListuDTOLekara();

            cbProstorija.ItemsSource = prostorijaController.PregledSvihProstorijaDTO();

            lekariZaPrikaz = lekari;
            lekariZaPrikaz.Remove(lekarLogin.lekar);
            Lekari.ItemsSource = lekariZaPrikaz;

        }
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {

            TerminDTO zaUpis = new TerminDTO();  
            zaUpis.hitno = true;
            zaUpis.prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;
            zaUpis.Pocetak = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30));

            PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;

            if (cbTip.SelectedIndex == 0)
            {
                zaUpis.Tip = TipTerminaEnum.Pregled;
            }

            else 
            {
                zaUpis.Tip = TipTerminaEnum.Operacija;
            }


                
             if (pac.ZdravstveniKarton != null)
                zaUpis.zdravstveniKarton = pac.ZdravstveniKarton;
             else
             {
                pac.ZdravstveniKarton = new ZdravstveniKartonDTO(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                zaUpis.zdravstveniKarton = pac.ZdravstveniKarton;
             }

            terminController.zakaziHitniLekar(zaUpis, pac);
            lekarStart.uputi.Add(zaUpis);
            
            test.prozor.Content = new Uputi();
            MessageBox.Show("Uspesno ste zakazali hitan termin");

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new Uputi();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
