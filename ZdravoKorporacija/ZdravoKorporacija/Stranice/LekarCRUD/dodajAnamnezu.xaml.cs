using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for dodajAnamnezu.xaml
    /// </summary>
    public partial class dodajAnamnezu : Page
    {
        private TerminController terminController = TerminController.Instance;
        private IzvestajDTO izvestaj = new IzvestajDTO();

        TerminDTO termin = new TerminDTO();


        public dodajAnamnezu(TerminDTO selektovani)
        {
            InitializeComponent();
            termin = selektovani;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            izvestaj.Simptomi = simptomiText.Text;
            TextRange textRange = new TextRange(opisTxt.Document.ContentStart, opisTxt.Document.ContentEnd);
            izvestaj.Opis = textRange.Text;


            terminController.IzdajAnamnezu(izvestaj, termin) ;
          
            //zdravstveniKartonPrikaz.izvestaji.Add(izvestaj);
            test.prozor.Content = new zdravstveniKartonPrikaz(termin);
            MessageBox.Show("Uspesno ste izdali anamnezu!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new zdravstveniKartonPrikaz(termin);
        }
    }
}
