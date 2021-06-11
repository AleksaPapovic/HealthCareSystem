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
    /// Interaction logic for AnketiranjeLjekara.xaml
    /// </summary>
    public partial class AnketiranjeLjekara : Window
    {

        private LekarController lekarKontroler = new LekarController();
        private AnketaController anketaController = new AnketaController();

        private AnketaDTO anketa;
        private PacijentDTO pacijent;
        private TerminDTO termin;
        private List<LekarDTO> ljekari;

        public AnketiranjeLjekara(TerminDTO termin, PacijentDTO pacijent)
        {
            InitializeComponent();
            ljekari = (List<LekarDTO>)lekarKontroler.dobaviListuDTOLekara();
            ljekar.ItemsSource = ljekari;

            foreach (LekarDTO l in ljekari)
            {
                if (l.Jmbg == termin.Lekar.Jmbg)
                {
                    ljekar.SelectedItem = l;
                }
            }
            this.pacijent = pacijent;
            this.termin = termin;

            IEnumerable<int> ocjene = Enumerable.Range(1, 10);
            ocjenaLjekara.ItemsSource = ocjene;

            anketa = new AnketaDTO();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void potvrdi(object sender, RoutedEventArgs e)
        {
            anketa.IdAutora = pacijent.Jmbg;
            anketa.Datum = DateTime.Parse(DateTime.Now.ToString());
            anketa.Tip = TipAnkete.Ljekar;
            anketa.Ocena = (int)ocjenaLjekara.SelectedItem;
            anketa.Komentar = (new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd)).Text;
            anketa.Termin = termin;

            anketaController.dodajAnketuLjekara(anketa);

            this.Close();
        }
    }
}
