using System;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarLekari
{
    /// <summary>
    /// Interaction logic for slobodniDani.xaml
    /// </summary>
    public partial class slobodniDani : Window
    {
        private RadniDaniController controller = new RadniDaniController();
        private DateTime Od;
        private DateTime Do;
        private double id;
        public slobodniDani(LekarDTO lekar)
        {
            InitializeComponent();
            id = lekar.Jmbg;

        }



        private void dodaj(object sender, RoutedEventArgs e)
        {
            Od = DateTime.Parse(odDP.Text);
            Do = DateTime.Parse(doDP.Text);

            controller.DodajSlobodneDane(Od, Do, id);
            this.Close();
        }
    }
}
