using System.Windows;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for AnamnezaProzor.xaml
    /// </summary>
    public partial class AnamnezaProzor : Window
    {
        private PacijentDTO pacijentDTO;
        public AnamnezaProzor(TerminDTO selektovaniTermin, PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.pacijentDTO = pacijentDTO;
            tbSimptomi.DataContext = selektovaniTermin.izvestaj;
            tbOpis.DataContext = selektovaniTermin.izvestaj;
            labelaTip.DataContext = selektovaniTermin;
            labelaDatum.DataContext = selektovaniTermin;
            labelaLekar.DataContext = selektovaniTermin;
        }

        private void dodajBeleskuBtn_Click(object sender, RoutedEventArgs e)
        {
            dodajBeleskuBtn.Visibility = Visibility.Hidden;
            Beleske.Content = new BeleskeStranica(pacijentDTO);
        }

        private void nazadBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}