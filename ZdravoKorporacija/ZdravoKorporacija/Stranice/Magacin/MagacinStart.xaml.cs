using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;


namespace ZdravoKorporacija.Stranice.Magacin
{
    /// <summary>
    /// Interaction logic for MagacinStart.xaml
    /// </summary>
    public partial class MagacinStart : Page
    {
        UpravnikController upravnikKontroler = new UpravnikController();
        ObservableCollection<InventarDTO> filtrirana_oprema = new ObservableCollection<InventarDTO>();
        ObservableCollection<InventarDTO> magacinOprema = new ObservableCollection<InventarDTO>();

        public MagacinStart()
        {
            InitializeComponent();
            magacinOprema = upravnikKontroler.DodajIzMagacinaDTO();
            dgMagacinOprema.ItemsSource = magacinOprema;
        }


        private void dodaj(object sender, RoutedEventArgs e)
        {
            MagacinDodavanje mc = new MagacinDodavanje(magacinOprema);
            mc.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            provera();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (filtrirana_oprema != null)
            {
                dgMagacinOprema.ItemsSource = this.filtrirana_oprema;
            }
        }

        private void slValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.filtrirana_oprema = new ObservableCollection<InventarDTO>();
            foreach (InventarDTO inv in magacinOprema)
            {

                if (inv.UkupnaKolicina <= (int)slValue.Value)
                {
                    filtrirana_oprema.Add(inv);
                }
            }
        }

        private void provera()
        {
            List<RadioButton> radioButtons = magacin.Children.OfType<RadioButton>().ToList();
            RadioButton rbTarget = radioButtons
                  .Where(r => r.GroupName == "Group1" && (bool)r.IsChecked)
                  .SingleOrDefault();

            this.filtrirana_oprema = new ObservableCollection<InventarDTO>();
            foreach (InventarDTO inv in magacinOprema)
            {
                if (rbTarget == r2)
                {
                    if (inv.Proizvodjac.Contains(searchBox.Text))
                    {
                        filtrirana_oprema.Add(inv);

                    }
                }
                else if (rbTarget == r1)
                {
                    if (inv.Naziv.Contains(searchBox.Text))
                    {
                        filtrirana_oprema.Add(inv);
                    }
                }
                else
                {
                    filtrirana_oprema.Add(inv);
                }
            }

        }

        private void r1_Checked(object sender, RoutedEventArgs e)
        {
            provera();
        }

        private void r2_Checked(object sender, RoutedEventArgs e)
        {
            provera();
        }

        private void ponisti_Click(object sender, RoutedEventArgs e)
        {
            slValue.Value = 0;
            this.filtrirana_oprema = new ObservableCollection<InventarDTO>();
            dgMagacinOprema.ItemsSource = MagacinRepozitorijum.Instance.magacinOprema;
            r1.IsChecked = false;
            r2.IsChecked = false;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void dgMagacinOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

    }
}
