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
using System.Windows.Shapes;
using Model;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Window
    {
        private FeedbackFormaController controller = new FeedbackFormaController();
        private FeedbackFormaDTO feedbackDTO;
        private UlogaEnum uloga;
        public Feedback()
        {
            InitializeComponent();
            grid.ItemsSource = controller.PregledSvihFormi2DTO(controller.PregledSvihFormi());
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            feedbackDTO = new FeedbackFormaDTO(sadrzajTB.Text, ProveriUlogu());
            controller.DodajFormu(feedbackDTO);
            grid.ItemsSource = controller.PregledSvihFormi2DTO(controller.PregledSvihFormi());

        }
        private UlogaEnum ProveriUlogu()
        {
            if(ulogaCB.SelectedIndex == 0)
            {
                uloga = UlogaEnum.Lekar;
            }else if (ulogaCB.SelectedIndex == 1)
            {
                uloga = UlogaEnum.Sekretar;
            }
            else if (ulogaCB.SelectedIndex == 2)
            {
                uloga = UlogaEnum.Pacijent;
            }
            else if (ulogaCB.SelectedIndex == 3)
            {
                uloga = UlogaEnum.Upravnik;
            }
            return uloga;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FeedbackFormaDTO izabraniDTO = (FeedbackFormaDTO)grid.SelectedItem;
            controller.ObrisiFormu(controller.DTO2ModelNadji(izabraniDTO).sadrzaj);
            grid.ItemsSource = controller.PregledSvihFormi2DTO(controller.PregledSvihFormi());
        }
    }
    }

