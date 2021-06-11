using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarLekari
{
    /// <summary>
    /// Interaction logic for radniDani.xaml
    /// </summary>
    public partial class radniDani : Window
    {
        private RadniDaniController controller = new RadniDaniController();
        public radniDani(LekarDTO izabrani)
        {
            InitializeComponent();
            controller.InicijalizujRadneDane();
            dgDani.ItemsSource = controller.PregledSvihRadnihDana2DTO(controller.NadjiSveDaneZaLekara(izabrani.Jmbg));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
