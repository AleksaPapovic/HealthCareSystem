using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Service;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for pocetna.xaml
    /// </summary>
    public partial class pocetna : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        private Pacijent pacijent = new Pacijent();
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private Boolean prikazi;
        private ObavestenjaService os = new ObavestenjaService();
        private AnketaRepozitorijum arepo = new AnketaRepozitorijum();
        private KorisnikService korisnikServis = new KorisnikService();
        public pocetna()
        {
            InitializeComponent();

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pacijentLogin pl = new pacijentLogin(UlogaEnum.Pacijent);
            pl.Show();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {

        }

    }   
}
