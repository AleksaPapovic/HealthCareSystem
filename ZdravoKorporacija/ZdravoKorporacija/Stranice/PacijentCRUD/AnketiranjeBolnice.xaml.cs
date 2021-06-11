using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for AnketiranjeBolnice.xaml
    /// </summary>
    public partial class AnketiranjeBolnice : Window
    {
        private AnketaDTO anketa;
        private PacijentDTO pacijentDTO;
        private AnketaController anketaController = new AnketaController();

        public AnketiranjeBolnice(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            IEnumerable<int> ocjene = Enumerable.Range(1, 10);
            ocjenaBolnice.ItemsSource = ocjene;

            anketa = new AnketaDTO();
            this.pacijentDTO = pacijentDTO;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void potvrdi(object sender, RoutedEventArgs e)
        {
            anketa.Tip = TipAnkete.Bolnica;
            anketa.Termin = null;
            anketa.IdAutora = pacijentDTO.Jmbg;
            anketa.Ocena = (int)ocjenaBolnice.SelectedItem;
            anketa.Komentar = (new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd)).Text;
            anketa.Datum = DateTime.Parse(DateTime.Now.ToString());

            anketaController.dodajAnketuBolnice(anketa);

            this.Close();
        }
    }
}
