using Model;
using System;
using System.Collections.Generic;
using System.Text;
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

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Page
    {
        private FeedbackFormaController kontroler = new FeedbackFormaController();
        FeedbackFormaDTO feedbackDTO;
        KorisnikDTO upravnik;
        public Feedback(KorisnikDTO ulogovaniUpravnik)
        {
            InitializeComponent();
            upravnik = ulogovaniUpravnik;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            FeedbackFormaDTO feedbackDTO = new FeedbackFormaDTO((new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd)).Text, UlogaEnum.Upravnik);
            kontroler.DodajFormu(feedbackDTO);
            test2.f.Content = new upravnikPocetna(upravnik);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new upravnikPocetna(upravnik);
        }
    }
}
