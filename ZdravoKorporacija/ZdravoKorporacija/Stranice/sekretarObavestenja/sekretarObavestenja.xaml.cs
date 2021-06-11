using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Service;
using ZdravoKorporacija.ServiceZaKonverzije;

namespace ZdravoKorporacija.Stranice.sekretarObavestenja
{
    /// <summary>
    /// Interaction logic for sekretarObavestenja.xaml
    /// </summary>
    public partial class sekretarObavestenja : Page
    {
        private ObavestenjaController controller = new ObavestenjaController();
        private List<NotifikacijaDTO> obavestenja;
        private Mediator mediator;
        public sekretarObavestenja()
        {
            InitializeComponent();
            obavestenja = controller.PregledSvihObavestenja2DTO(controller.PregledSvihObavestenja());
            globalna.ItemsSource = obavestenja;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kreirajObavestenje ko = new kreirajObavestenje();
            ko.Show();
        }

        private void globalna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            NotifikacijaDTO n = new NotifikacijaDTO();
            n = (NotifikacijaDTO)globalna.SelectedItem;
            controller.obrisiObavestenje(n.Sadrzaj);
            globalna.ItemsSource = controller.pregled();
        }
    }
}
