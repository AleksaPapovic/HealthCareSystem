using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using Model;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for FeedbackPacijent.xaml
    /// </summary>
    public partial class FeedbackPacijent : Window
    {
        private FeedbackFormaDTO feedbackDTO;
        private PacijentDTO pacijentDTO;
        private FeedbackFormaController kontroler = new FeedbackFormaController();

        public FeedbackPacijent(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.pacijentDTO = pacijentDTO;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            feedbackDTO = new FeedbackFormaDTO((new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd)).Text, UlogaEnum.Pacijent);
            kontroler.DodajFormu(feedbackDTO);
            this.Close();
        }
    }
}
