using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.DinamickaOpremaCRUD;
using ZdravoKorporacija.Stranice.LekoviCRUD;
using ZdravoKorporacija.Stranice.Magacin;
using ZdravoKorporacija.Stranice.StatickaOpremaCRUD;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for upravnikPocetna.xaml
    /// </summary>
    public partial class upravnikPocetna : Page
    {
        KorisnikDTO upravnik;
        public upravnikPocetna(KorisnikDTO ulogovaniUpravnik)
        {
            InitializeComponent();
            upravnik = ulogovaniUpravnik;
            labelKorisnik.Content = ulogovaniUpravnik.Ime + "  " + ulogovaniUpravnik.Prezime;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new prostorijeStart();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new statickaOpremaStart();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new MagacinStart();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new dinamickaOpremaStart();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Zaposleni(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new ZaposleniPocetna();
        }

        private void button_Click_5(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new LekStart();
        }

        private void renoviraj_Click(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new RenoviranjeStart();
        }

        private void profil(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void feedback(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new Feedback(upravnik);
        }
    }
}