using System;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for pocetna2.xaml
    /// </summary>
    public partial class pocetna2 : Window
    {
        private PacijentDTO pacijentDTO;
        private AnketaController anketaController = new AnketaController();

        public pocetna2(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.pacijentDTO = pacijentDTO;

            podesiVidljivostDugmeta();
        }

        private void podesiVidljivostDugmeta()
        {
            AnketaDTO poslednja = anketaController.dobaviPosljednjuAnketuBolnice(pacijentDTO);

            if (poslednja != null && DateTime.Compare(poslednja.Datum, DateTime.Parse(DateTime.Now.AddDays(-30).ToString())) <= 0)
            {
                oceniBolnicuBtn.Visibility = Visibility.Visible;
            }
        }

        private void preglediBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pregledi(pacijentDTO);
        }

        private void obavjestenjaBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Obavestenja(pacijentDTO);
        }

        private void pocetnaBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
        }

        private void odjavaBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void oceniBolnicuBtn_Click(object sender, RoutedEventArgs e)
        {
            AnketiranjeBolnice ab = new AnketiranjeBolnice(pacijentDTO);
            ab.Show();
            oceniBolnicuBtn.Visibility = Visibility.Hidden;
        }

        private void kartonBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ZKPacijent(pacijentDTO);
        }
    }
}
