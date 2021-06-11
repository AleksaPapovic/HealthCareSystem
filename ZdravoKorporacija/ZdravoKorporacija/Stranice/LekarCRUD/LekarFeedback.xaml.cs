using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for LekarFeedback.xaml
    /// </summary>
    public partial class LekarFeedback : Page
    {
        private FeedbackFormaController kontroler = new FeedbackFormaController();
        public LekarFeedback()
        {
            InitializeComponent();
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            FeedbackFormaDTO feedbackDTO = new FeedbackFormaDTO((new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd)).Text, UlogaEnum.Lekar);
            kontroler.DodajFormu(feedbackDTO);
            test.prozor.Content = new lekarStart(lekarLogin.lekar); ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new lekarStart(lekarLogin.lekar);
        }
    }
}
