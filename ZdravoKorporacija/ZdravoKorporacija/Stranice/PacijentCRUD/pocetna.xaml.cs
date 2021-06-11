using System;
using System.Windows;
using System.Windows.Input;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Pocetna.xaml
    /// </summary>
    public partial class Pocetna : Window
    {
        private PacijentDTO pacijentDTO;
        private AnketaController anketaController = new AnketaController();

        public Pocetna(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.pacijentDTO = pacijentDTO;
            lblUlogovani.Content = pacijentDTO.Ime + " " + pacijentDTO.Prezime + " ";
            CentrirajProzor();
            prikaziWizard();
            Main.Content = new PocetnaStranica(pacijentDTO);

        }

        private void prikaziWizard()
        {
            if (Login.wizard)
            {
                Wizard1 wizardDialog = new Wizard1();
                this.Show();
                wizardDialog.Show();
            }
        }

        private void CentrirajProzor()
        {
            this.Left = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (this.Width / 2);
            this.Top = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (this.Height / 2);
        }

        public void preglediBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pregledi(pacijentDTO);
        }

        public void obavjestenjaBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Obavestenja(pacijentDTO);
        }

        public void pocetnaBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PocetnaStranica(pacijentDTO);
        }

        public void odjavaBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void kartonBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ZKPacijent(pacijentDTO);
        }

        public void pomocBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pomoc(pacijentDTO);
        }

        public void profilBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Profil(pacijentDTO);
        }

        public void terapijaBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Terapija(pacijentDTO);
        }


    


    }
}
