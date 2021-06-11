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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Pomoc.xaml
    /// </summary>
    public partial class Pomoc : Page
    {
        private PacijentDTO pacijent;
        public Pomoc(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            pacijent = pacijentDTO;
        }

        private void wizard_Click(object sender, RoutedEventArgs e)
        {
            Wizard1 wizardWindow = new Wizard1();
            wizardWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Wizard1 w = new Wizard1();
            w.ShowDialog();
        }
    }
}
