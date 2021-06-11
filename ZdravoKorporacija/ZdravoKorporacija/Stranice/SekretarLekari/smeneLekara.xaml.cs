using System;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarLekari
{
    /// <summary>
    /// Interaction logic for smeneLekara.xaml
    /// </summary>
    public partial class smeneLekara : Window
    {
        private RadniDaniController controller = new RadniDaniController();
        private DateTime Od;
        private DateTime Do;
        private double id;
        private bool prva; 
        private PromeniSmenuDTO smenaDTO;
        public smeneLekara(LekarDTO lekar1)
        {
            InitializeComponent();
            id = lekar1.Jmbg;
            prva = false;

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            if (smenaCB.SelectedIndex == 0)
                prva = true;
            else
                prva = false;
            Od = DateTime.Parse(odDP.Text);
            Do = DateTime.Parse(doDP.Text);

            smenaDTO = new PromeniSmenuDTO(Od, Do, id, prva);
            controller.PromeniSmenu(smenaDTO);
            this.Close();

        }
    }
}
