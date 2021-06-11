using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for RenoviranjeStart.xaml
    /// </summary>
    public partial class RenoviranjeStart : Page
    {
        RenoviranjeController renoviranjeController = new RenoviranjeController();
        ProstorijaController prostorijaController = new ProstorijaController();
        UpravnikController magacinController = new UpravnikController();
        ObservableCollection<ZahtevRenoviranjeDTO> renoviranja;
        private Boolean imaZahtev = true;
        public RenoviranjeStart()
        {
            InitializeComponent();
            timer();
            renoviranja = renoviranjeController.pregledSvihZahtevaRenoviranjaDTO();
            dgZahteviRenoviranjaOprema.ItemsSource = renoviranja;
        }


        private void dgZahteviRenoviranja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            Renoviranje r = new Renoviranje(-1);
            r.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }


        public void timer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += ProveraZahteva;
            timer.Start();
        }

        public void ProveraZahteva(object sender, EventArgs e)
        {
            ZahtevRenoviranjeDTO renoviranjeZahtevDTO = new ZahtevRenoviranjeDTO();

            if (renoviranjeController.pregledSvihZahtevaRenoviranjaDTO() != null)
            {
                renoviranjeZahtevDTO= renoviranjeController.pregledSvihZahtevaRenoviranjaDTO().FirstOrDefault(s => s.Kraj <= DateTime.Now && s.Kraj >= DateTime.Now.AddMinutes(-5));
                if (renoviranjeZahtevDTO == null)
                {
                    imaZahtev = false;
                }
                else { imaZahtev = true; }

            }
            if (renoviranjeZahtevDTO != null && imaZahtev == true)
            {

                if (renoviranjeZahtevDTO.Spajanje.Equals("Spajanje"))
                {
                    foreach (ProstorijaDTO prostorijaDTO in renoviranjeZahtevDTO.prostorije)
                    {
                        foreach (StatickaOpremaDTO statickaDTO in prostorijaDTO.statickaOprema)
                        {
                            InventarDTO inventarDTO = new InventarDTO(statickaDTO.Id, statickaDTO.Naziv, statickaDTO.Id, statickaDTO.Proizvodjac, statickaDTO.DatumNabavke);
                            magacinController.DodajUMagacin(inventarDTO);
                        }
                        prostorijaDTO.statickaOprema = new List<StatickaOpremaDTO>();
                        prostorijaController.AzurirajProstoriju(prostorijaDTO, prostorijaDTO.Id);
                    }
                    int i = 0;
                    foreach (ProstorijaDTO DTOprostorija in renoviranjeZahtevDTO.prostorije)
                    {
                        i = renoviranjeZahtevDTO.prostorije.Count;
                        prostorijaController.ObrisiProstoriju(DTOprostorija);
                    }
                    renoviranjeZahtevDTO.Prostorija.Naziv = renoviranjeZahtevDTO.Prostorija.Naziv + "" + i;
                    prostorijaController.AzurirajProstoriju(renoviranjeZahtevDTO.Prostorija, renoviranjeZahtevDTO.Prostorija.Id);


                }

                if (renoviranjeZahtevDTO.Razdvajanje.Equals("Razdvajanje"))
                {

                    foreach (StatickaOpremaDTO statickaDTO in renoviranjeZahtevDTO.Prostorija.statickaOprema)
                    {
                        InventarDTO inventarDTO = new InventarDTO(statickaDTO.Id, statickaDTO.Naziv, statickaDTO.Id, statickaDTO.Proizvodjac, statickaDTO.DatumNabavke);
                        magacinController.DodajUMagacin(inventarDTO);
                    }

                    renoviranjeZahtevDTO.Prostorija.statickaOprema = new List<StatickaOpremaDTO>();
                    prostorijaController.AzurirajProstoriju(renoviranjeZahtevDTO.Prostorija, renoviranjeZahtevDTO.Prostorija.Id);


                    ProstorijaDTO novaProstorijaDTO = new ProstorijaDTO(0, renoviranjeZahtevDTO.Prostorija.Naziv+""+1, renoviranjeZahtevDTO.Prostorija.Tip, renoviranjeZahtevDTO.Prostorija.Slobodna, renoviranjeZahtevDTO.Prostorija.Sprat);
                    prostorijaController.DodajProstoriju(novaProstorijaDTO);


                }


                if (renoviranjeController.ObrisiZahtevRenoviranja(renoviranjeZahtevDTO))
                {
                    renoviranja.Remove(renoviranjeZahtevDTO);
                }
            }


        }


    }
}
