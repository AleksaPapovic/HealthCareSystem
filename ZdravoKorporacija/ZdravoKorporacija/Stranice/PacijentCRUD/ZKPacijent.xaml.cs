using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for ZKPacijent.xaml
    /// </summary>
    public partial class ZKPacijent : Page
    {
        private PacijentController pacijentController = new PacijentController();
        private TerminController terminKontroler = new TerminController();

        BindingList<Alergija> alergije = new BindingList<Alergija>();
        public ZKPacijent(PacijentDTO pacijentDTO)
        {
            InitializeComponent();

            ObservableCollection<TerminDTO> terminiDTO = new ObservableCollection<TerminDTO>(terminKontroler.dobaviListuDTOProslihtermina(pacijentDTO));
            dgt.ItemsSource = terminiDTO;

            List<string> opisi = new List<string>();
            List<string> simptomi = new List<string>();

            foreach (TerminDTO t in terminiDTO)
            {
                opisi.Add(t.izvestaj.Opis);
                simptomi.Add(t.izvestaj.Simptomi);
            }
            alergije.Add(new Alergija("Penicilin", "Izaziva mučninu, povraćanje, proliv, bolove u trbuhu, neretko i koprivnjaču i angioedem, bronhospazam i hipotenziju."));
            alergije.Add(new Alergija("Jod", "Izaziva bolove u stomaku, konfuziju i vrtoglavicu. Često je izmenjen nivo svesti, puls ubrzan, a krvni pritisak nizak."));
            alergije.Add(new Alergija("Gluten", "Izaziva osip po koži, koprivnjaču, svrab, povišenu temperaturu, a u težim slučajevima i otok i gušenje."));
            alergije.Add(new Alergija("Polen", "Pojačano crvenilo i nadražaj očiju, kijanje, začepljen nos, suv kašalj, otežano disanje."));
            dg.ItemsSource = alergije;


            PacijentPodaciDTO pacijentZaPrikaz = pacijentController.konvertujUPodaciDTO(pacijentDTO);
            tbIme.DataContext = pacijentZaPrikaz;
            tbPrezime.DataContext = pacijentZaPrikaz;
            tbJmbg.DataContext = pacijentZaPrikaz;
            tbAdresa.DataContext = pacijentZaPrikaz;
            tbKontakt.DataContext = pacijentZaPrikaz;
            tbMejl.DataContext = pacijentZaPrikaz;
            BindingList<String> status = new BindingList<String>();
            status.Add("Neoženjen");
            cbstatus.ItemsSource = status;
            cbstatus.SelectedItem = status[0];
            BindingList<String> pol = new BindingList<String>();
            pol.Add("Muški");
            cbPol.ItemsSource = pol;
            cbPol.SelectedItem = pol[0];

        }

     
    }
}
