using Controller;
using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for dodajProstorijuUpravnik.xaml
    /// </summary>
    public partial class dodajProstorijuUpravnik : Window
    {
        private ProstorijaController prostorijaKontroler = new ProstorijaController();
        private ObservableCollection<ProstorijaDTO> prostorije;
        public dodajProstorijuUpravnik(ObservableCollection<ProstorijaDTO> prostorijeDTO)
        {
            InitializeComponent();
            this.prostorije = prostorijeDTO;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboBoxTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBoxSprat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            string ime = textboxNaziv.Text;

            if (ime.Trim() == "")
            {
                MessageBox.Show("Ne možemo da pronadjemo naziv prostorije, molimo vas unesite ponovo naziv", "Greška");
                return;
            }


            TipProstorijeEnum tip;
            int sprat;
            if (comboBoxTip.SelectedIndex == 0)
            {
                tip = TipProstorijeEnum.OperacionaSala;
            }
            else if (comboBoxTip.SelectedIndex == 1)
            {
                tip = TipProstorijeEnum.Soba;
            }
            else if (comboBoxTip.SelectedIndex == 2)
            {
                tip = TipProstorijeEnum.Ordinacija;
            }
            else
            {
                MessageBox.Show("Ne možemo da pronadjemo tip prostorije, molimo vas izaberite tip prostorije", "Greška");
                return;
            }

            if (comboBoxSprat.SelectedIndex == -1)
            {
                MessageBox.Show("Ne možemo da pronadjemo sprat, molimo vas izaberite sprat na kom se nalazi prostorija", "Greška");
                return;
            }
            else
            {
                sprat = comboBoxSprat.SelectedIndex;
            }


            ProstorijaDTO prostorija = new ProstorijaDTO(0, ime, tip, false, sprat);

            if (prostorijaKontroler.DodajProstoriju(prostorija))
            {
                prostorije.Add(prostorija);
                this.Close();
            }


        }
    }
}
