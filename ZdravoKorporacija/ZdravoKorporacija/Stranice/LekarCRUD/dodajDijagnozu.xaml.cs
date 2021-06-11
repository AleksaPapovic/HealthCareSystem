using Model;
using Repository;
using Service;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{



    public partial class dodajDijagnozu : Page
    {
        private ZdravstveniKartonServis kartonServis = new ZdravstveniKartonServis();
        private ZdravstveniKartonRepozitorijum kartonDat = new ZdravstveniKartonRepozitorijum();
        ZdravstveniKarton zk;
        //private List<Lekar> ljekari;
        Dijagnoza d;
        public dodajDijagnozu(ObservableCollection<Dijagnoza> dijagnoze, ZdravstveniKarton zk)
        {
            InitializeComponent();
            d = new Dijagnoza();
            this.zk = zk;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            d.Oboljenje = oboljenjeText.Text;
            d.Opis = new TextRange(opisText.Document.ContentStart, opisText.Document.ContentEnd).Text;

            // foreach (IstorijaBolesti i in selektovani.ZdravstveniKarton.GetIstorijaBolesti())
            //   dgUsers.ItemsSource = i.GetDijagnoza();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
