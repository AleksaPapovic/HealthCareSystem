using Model;

using Repository;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice;
using ZdravoKorporacija.Stranice.Logovanje;
using ZdravoKorporacija.Stranice.PacijentCRUD;
using ZdravoKorporacija.Stranice.SekretarCRUD;

namespace ZdravoKorporacija
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ContentControl cc = new ContentControl();
        public static List<Specijalista> spec = new List<Specijalista>();
        public static MainWindow mw = new MainWindow();
        private string CurrentLanguage { get; set; }
        UlogaEnum uloga;

        public MainWindow() 
        { 
            InitializeComponent();


            cc.Content = this.Content;
            Specijalista s1 = new Specijalista("Veljko", "Vukovic");
            s1.Specijalizacija = SpecijalizacijaEnum.Kardiohirurg;
            spec.Add(s1);

            Specijalista s2 = new Specijalista("Milos", "Zivic");
            s2.Specijalizacija = SpecijalizacijaEnum.Neurolog;
            spec.Add(s2);
            mw = this;
        }



        private void AutoColumns_Click(object sender, RoutedEventArgs e)
        {
            LekarRepozitorijum LekarJSON = new LekarRepozitorijum();
            List<Lekar> lekari = new List<Lekar>();
            Lekar dr1 = new Lekar("Veljko", "Vukovic", 2334567890213, 066393345, "vuksivuk@gmail.com", "Beograd", PolEnum.Muski, "veksi", "vukovic");
            Pacijent p1 = new Pacijent("Dusan", "Markovic", 1234567890123, 069000333, "dusanmarkovic@gmail.com", "Smederevska tvrdjava", PolEnum.Muski, "dukikidu", "markovic99");
            ZdravstveniKarton zd1 = new ZdravstveniKarton(p1, 1, StanjePacijentaEnum.Kriticno, "pcele", KrvnaGrupaEnum.APozitivna, "nevekcinisan");
            Prostorija pr1 = new Prostorija(1, "soba za pregled", TipProstorijeEnum.Soba, true, 2);
            //dr1.AddTermin(new Termin(zd1, pr1, dr1, TipTerminaEnum.Pregled, new DateTime(2020, 5, 1, 8, 30, 52), 90));
            Lekar dr2 = new Lekar("Milos", "Zivic", 2234567890113, 069393334, "zivko99@gmail.com", "Becej", PolEnum.Muski, "milos", "zivic");
            lekari.Add(dr1);
            lekari.Add(dr2);

            LekarJSON.sacuvaj(lekari);
        }

        private void ManualColumns_Click(object sender, RoutedEventArgs e)
        {
            PacijentRepozitorijum pacijentJSON = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = new List<Pacijent>();
            Prostorija pr1 = new Prostorija(1, "soba za pregled", TipProstorijeEnum.Soba, true, 2);
            Prostorija pr2 = new Prostorija(2, "soba za operaciju", TipProstorijeEnum.OperacionaSala, true, 1);
            Pacijent p1 = new Pacijent("Dusan", "Markovic", 1234567890123, 069000333, "dusanmarkovic@gmail.com", "Smederevska tvrdjava", PolEnum.Muski, "dukikidu", "markovic99");
            Pacijent p2 = new Pacijent("Dusan", "Lekic", 3214567890122, 066333999, "dusanlekic@gmail.com", "Rokijev potok", PolEnum.Muski, "leka", "leka99");
            Pacijent p3 = new Pacijent("Aleksa", "Papovic", 2134567890213, 066393654, "aleksapapovic@gmail.com", "Grbavica", PolEnum.Muski, "pape", "pape99");
            Lekar dr1 = new Lekar("Veljko", "Vukovic", 2334567890213, 066393345, "vuksivuk@gmail.com", "Beograd", PolEnum.Muski, "veksi", "vukovic");
            ZdravstveniKarton zd1 = new ZdravstveniKarton(p1, 1, StanjePacijentaEnum.Kriticno, "pcele", KrvnaGrupaEnum.APozitivna, "nevekcinisan");
            ZdravstveniKarton zd2 = new ZdravstveniKarton(p2, 2, StanjePacijentaEnum.Stabilno, "nema", KrvnaGrupaEnum.ABNegativna, "sinovac");
            //Termin tr1 = new Termin(zd1, pr1, dr1, TipTerminaEnum.Pregled, new DateTime(2020, 5, 1, 8, 30, 52), 90);
            //Termin tr2 = new Termin(zd1, pr1, dr1, TipTerminaEnum.Pregled, new DateTime(2020, 6, 6, 6, 30, 52), 90);
            TerminRepozitorijum terminiJSON = new TerminRepozitorijum();
            List<Termin> termini = new List<Termin>();
            ProstorijaRepozitorijum prostorijeJSON = ProstorijaRepozitorijum.Instance;
            List<Prostorija> prostorije = new List<Prostorija>();
            //termini.Add(tr1);
            //termini.Add(tr2);
            //p1.AddTermin(tr1);
            pacijenti.Add(p1);
            pacijenti.Add(p2);
            pacijenti.Add(p3);
            ProstorijaRepozitorijum.Instance.prostorije.Add(pr1);
            ProstorijaRepozitorijum.Instance.prostorije.Add(pr2);
            pacijentJSON.sacuvaj(pacijenti);
            terminiJSON.sacuvaj(termini);
            prostorijeJSON.sacuvaj();
        }

        private void Binding_Click(object sender, RoutedEventArgs e)
        {
            SekretarRepozitorijum sekretarJSON = new SekretarRepozitorijum();
            List<Sekretar> sekretari = new List<Sekretar>();
            Sekretar s1 = new Sekretar("Stefan", "Mitrovic", 4444567890123, 0621100333, "mitrovic@gmail.com", "Kragujevac", PolEnum.Muski, "mitros", "mitrovic99");
            Sekretar s2 = new Sekretar("Aleksandra", "Petrovic", 5554567890123, 063123333, "saska@gmail.com", "Sombor", PolEnum.Zenski, "saska", "petrovic99");
            sekretari.Add(s1);
            sekretari.Add(s2);
            sekretarJSON.sacuvaj(sekretari);
        }





        private void openUpravnikFrame(object sender, RoutedEventArgs e)
        {
            //upravnikPocetna s = new upravnikPocetna();
            //s.Show();
            uloga = UlogaEnum.Upravnik;
            upavnikLogin l = new upavnikLogin(uloga);
            l.Show();

        }
        private void openLekarFrame(object sender, RoutedEventArgs e)
        {
            this.Content = new lekarLogin(UlogaEnum.Lekar);

        }
        private void openSekretarFrame(object sender, RoutedEventArgs e)
        {
            sekretarStart s = new sekretarStart();
            s.Show();
        }
        private void openPacijentFrame(object sender, RoutedEventArgs e)
        {
            Login pl = new Login(UlogaEnum.Pacijent);
            pl.Show();
        }

        private void ffBTN_Click(object sender, RoutedEventArgs e)
        {
            Feedback ff = new Feedback();
            ff.Show();
        }
    }
}
