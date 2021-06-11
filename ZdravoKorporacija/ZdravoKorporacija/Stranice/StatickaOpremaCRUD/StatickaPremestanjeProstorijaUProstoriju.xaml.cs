using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for StatickaPremestanjeProstorijaUProstoriju.xaml
    /// </summary>
    public partial class StatickaPremestanjeProstorijaUProstoriju : Window
    {
        ProstorijaController prostorijaController = new ProstorijaController();
        ObservableCollection<Prostorija> prostorije1;
        ObservableCollection<ProstorijaDTO> prostorije2;
        public StatickaPremestanjeProstorijaUProstoriju()
        {
            InitializeComponent();
            prostorije1 = prostorijaController.PregledSvihProstorija();
            prostorije2 = prostorijaController.PregledSvihProstorijaDTO();
            prostorija1.ItemsSource = prostorije1;
            prostorija2.ItemsSource = prostorije2;


            Stream s = File.OpenWrite(@"..\..\..\Data\prostorije.txt");
            XmlSerializer xmlSer = new XmlSerializer(typeof(ObservableCollection<Prostorija>));
            xmlSer.Serialize(s, prostorije1);

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {

        }

        private void odustani(object sender, RoutedEventArgs e)
        {

        }

        private void dgProstorija1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgProstorija2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void prostorija1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProstorijaDTO selektovanaProstorija = (ProstorijaDTO)prostorija1.SelectedItem;
            prostorije2.Remove(selektovanaProstorija);
            dgProstorija1.ItemsSource = selektovanaProstorija.statickaOprema;
            dgProstorija1.Items.Refresh();
            foreach (StatickaOpremaDTO staticka in selektovanaProstorija.statickaOprema)
            {
                Debug.WriteLine(staticka.Naziv);
            }

        }

        private void prostorija2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProstorijaDTO selektovanaProstorija = (ProstorijaDTO)prostorija2.SelectedItem;
            dgProstorija2.ItemsSource = selektovanaProstorija.statickaOprema;

        }
    }
}
