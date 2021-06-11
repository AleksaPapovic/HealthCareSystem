using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for otkaziPregled.xaml
    /// </summary>
    public partial class otkaziPregled : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini;
        Termin termin;
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private Pacijent pacijent;


        public otkaziPregled(ObservableCollection<Termin> ts, Termin t, Dictionary<int, int> ids, Pacijent pacijent)
        {
            InitializeComponent();
            termini = ts;
            termin = t;
            this.ids = ids;
            this.pacijent = pacijent;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            this.ids[this.termin.Id] = 0;
            // storage.OtkaziTerminPacijent(termin, ids, pacijent);
            termini.Remove(termin);
            //termin.Lekar.RemoveTermin(termin); // provjeri je l ovo radi okej

            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
