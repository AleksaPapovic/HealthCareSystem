using Controller;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.DinamickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for dinamickaOpremaPremestanjeIzMagacina.xaml
    /// </summary>
    public partial class dinamickaOpremaPremestanjeIzMagacina : Window
    {

        private DinamickaOpremaController dinamickaOpremaKontroler = new DinamickaOpremaController();
        private ProstorijaController prostorijeKontroler = new ProstorijaController();
        private MagacinController magacinKontroler = new MagacinController();
        ObservableCollection<DinamickaOpremaDTO> dinamickaOpremaDTO;
        public dinamickaOpremaPremestanjeIzMagacina(ObservableCollection<DinamickaOpremaDTO> dinamickaOprema)
        {
            InitializeComponent();
            dinamickaOpremaDTO = dinamickaOprema;
            cbMagacin.ItemsSource = magacinKontroler.PregledSveOpremeDTO();
            cbProstorija.ItemsSource = prostorijeKontroler.PregledSvihProstorijaDTO();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            InventarDTO inv = (InventarDTO)cbMagacin.SelectedItem;
            int kolicina;
            try
            {
                kolicina = int.Parse(textboxKolicina.Text);
            }
            catch (FormatException)
            {
                return;
            }

            DinamickaOpremaDTO opremaDTO = new DinamickaOpremaDTO(inv, kolicina);
            opremaDTO.Prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;


            if(dinamickaOpremaKontroler.DodajOpremu(opremaDTO)){
                Double novaKolicina = Double.Parse(textboxKolicina.Text);
                dinamickaOpremaDTO.Add(opremaDTO);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbMagacin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbProstorija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
