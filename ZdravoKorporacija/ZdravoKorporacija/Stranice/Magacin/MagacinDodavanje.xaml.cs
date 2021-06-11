using System;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.Magacin
{
    /// <summary>
    /// Interaction logic for MagacinDodavanje.xaml
    /// </summary>
    public partial class MagacinDodavanje : Window
    {
        UpravnikController upravnikKontroler = new UpravnikController();
        ObservableCollection<InventarDTO> opremaUMagacinu = new ObservableCollection<InventarDTO>();
        public MagacinDodavanje(ObservableCollection<InventarDTO> magacinOprema)
        {
            InitializeComponent();
            opremaUMagacinu = magacinOprema;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string naziv = textboxNaziv.Text;
            int kolicina = 0;
            try
            {
                kolicina = int.Parse(textboxKolicina.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ne mozemo da pronadjemo uneti broj, molimo vas unesite ponovo", "Greska");
                return;
            }
            string proizvodjac = textboxProizvodjac.Text;

            InventarDTO opremaDTO = new InventarDTO(0, naziv, kolicina, proizvodjac, new DateTime());

            if (upravnikKontroler.DodajUMagacin(opremaDTO))
            {
                opremaUMagacinu.Add(opremaDTO);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
