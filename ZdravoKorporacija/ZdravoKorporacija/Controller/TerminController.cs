
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    public class TerminController
    {
        private TerminService terminServis = new TerminService();
        private ProstorijaService prostorijaServis = new ProstorijaService();
        private LekarService lekarServis = new LekarService();
        private PacijentService pacijentServis = new PacijentService();
        private ZdravstveniKartonServis kartonServis = new ZdravstveniKartonServis();


        public bool zakaziHitniLekar(TerminDTO termin, PacijentDTO pacijent)
        {
            return terminServis.zakaziHitniLekar(termin, pacijent);
        }

            public ObservableCollection<ProstorijaDTO> DobaviSlobodneProstorije2(DateTime pocetak)
        {
            return terminServis.DobaviSlobodneProstorije2(pocetak);
        }

        public ObservableCollection<ProstorijaDTO> DobaviSlobodneProstorije3(TerminDTO termin, DateTime pocetak, ProstorijaDTO prostorija)
        {
            return terminServis.DobaviSlobodneProstorije3(termin,pocetak,prostorija);
        }
        // THIS WILL BE THE ONE  ///////////////////////////////
        public void zakaziTermin(TerminDTO noviTermin)
        {
            Termin termin = terminKonverter.KonvertujDTOuEntitet(noviTermin);
            terminServis.zakaziTermin(termin);
        }

        public bool ObrisiLekara(Lekar lekar)
        {
            return lekarServis.ObrisiLekara(lekar);
        }
        public ZdravstveniKarton NadjiKartonID(long id)
        {
            return kartonServis.findById(id);
        }
        public LekarDTO NadjiLekaraPoJMBG(long lekar)
        {
            return Model2DTO(lekarServis.NadjiLekaraPoJMBG(lekar));
        }
        public Pacijent NadjiPacijentaPoJMBG(long jmbg)
        {
            return pacijentServis.NadjiPacijentaPoJMBG(jmbg);
        }
        public bool AzurirajPacijenta(Pacijent pacijent)
        {
            return pacijentServis.AzurirajPacijenta(pacijent);
        }
        public PacijentDTO NadjiPacijentaPoJMBGDTO(long jmbg)
        {
            return pacijentServis.NadjiPacijentaPoJMBGDTO(jmbg);
        }
        public bool AzurirajTerminPacijent(Termin termin, Pacijent pacijent)
        {
            return terminServis.AzurirajTerminPacijent(termin, pacijent);
        }

        public List<Lekar> PregledSvihLekara()
        {
            return lekarServis.PregledSvihLekara();
        }
        public List<Lekar> PregledSvihLekaraModel(List<LekarDTO> dtos)
        {
            return lekarServis.PregledSvihLekaraModel(dtos);
        }
        public List<LekarDTO> PregledSvihLekaraDTO(List<Lekar> modeli)
        {
            return lekarServis.PregledSvihLekaraDTO(modeli);
        }
        public bool AzurirajTermin(Termin termin)
        {
            return terminServis.AzurirajTermin(termin);
        }

        public bool AzurirajTermin(TerminDTO termin)
        {
            return terminServis.AzurirajTermin(termin);
        } 
        public Termin DTO2ModelNadji(TerminDTO dto)
        {
            return terminServis.DTO2ModelNadji(dto);
        }
        public ProstorijaDTO Model2DTO(Prostorija model)
        {
            return prostorijaServis.Model2DTO(model);
        }
        public LekarDTO Model2DTO(Lekar model)
        {
            return lekarServis.Model2DTO(model);
        }
        public TerminDTO Model2DTO(Termin model)
        {
            return terminServis.Model2DTO(model);
        }

        internal bool AzurirajLekara(Lekar lekar)
        {
            return lekarServis.AzurirajLekara(lekar);
        }

        public bool ObrisiNalogPacijentu(Pacijent pacijent)
        {
            return pacijentServis.ObrisiNalogPacijentu(pacijent);
        }
        public Lekar LekarDTO2Model(LekarDTO dto)
        {
            return lekarServis.DTO2Model(dto);
        }

        public ObservableCollection<ProstorijaDTO> PregledSvihProstorijaDTO(ObservableCollection<Prostorija> modeli)
        {
            return prostorijaServis.PregledSvihProstorijaDTO(modeli);
        }
        public ObservableCollection<Prostorija> PregledSvihProstorija()
        {
            return prostorijaServis.PregledSvihProstorija();
        }
        public List<Prostorija> PregledSvihProstorija2Model(List<ProstorijaDTO> dtos)
        {
            return prostorijaServis.PregledSvihProstorija2Model(dtos);
        }
        
        public ObservableCollection<Prostorija> DobaviSlobodneProstorije(  Termin termin)

        {
            return terminServis.DobaviSlobodneProstorije(termin);
        }
        public bool OtkaziTermin(Termin termin, Dictionary<int, int> ids)
        {
            return terminServis.OtkaziTermin(termin, ids);
        }

        public bool OtkaziTermin(TerminDTO termin)
        {
            return terminServis.OtkaziTermin(termin);
        }

        public bool ObrisiTerminPacijentu(Termin termin)
        {
            return pacijentServis.ObrisiTerminPacijentu(termin);
        }
        public List<Lekar> DobaviSlobodneLekare(DateTime pocetakTermina, SpecijalizacijaEnum specijalizacija)
        {
            return terminServis.DobaviSlobodneLekare(pocetakTermina, specijalizacija);
        }
        public int MapaTermina(Dictionary<int, int> ids)
        {
            return terminServis.MapaTermina(ids);
        }
        public bool ZakaziTermin(Termin termin, Dictionary<int, int> ids)
        {
            return terminServis.ZakaziTermin(termin, ids);
        }
        public Termin TerminDTO2Model(TerminDTO dto)
        {
            return terminServis.DTO2Model(dto);
        }
        public void AzurirajLekare()
        {
            lekarServis.AzurirajLekare();
        }
        public List<TerminDTO> PregledSvihTermina2DTO(List<Termin> modeli)
        {
            return terminServis.PregledSvihTermina2DTO(modeli);
        }
        public List<PacijentDTO> PregledSvihPacijenata2DTO()
        {
            return pacijentServis.PregledSvihPacijenata2DTO();
        }
        public List<Pacijent> PregledSvihPacijenata2Model(List<PacijentDTO> dtos)
        {
            return pacijentServis.PregledSvihPacijenata2Model(dtos);
        }
        public List<Pacijent> PregledSvihPacijenata()
        {
            return pacijentServis.PregledSvihPacijenata();
        }
        public Pacijent PacijentDTO2Model(PacijentDTO dto)
        {
            return pacijentServis.DTO2Model(dto);
        }
        public void DodajTermin(Pacijent p, Termin t)
        {
            pacijentServis.DodajTermin(p, t);
        }
        public Pacijent PregledPacijenta(long jmbg)
        {
            return pacijentServis.PregledPacijenta(jmbg);
        }
        public void DodajTermin(Termin t)
        {
            terminServis.DodajTermin(t);
        }
        public Pacijent DTO2ModelNapravi(PacijentDTO dto)
        {
            return pacijentServis.DTO2ModelNapravi(dto);
        }
        public List<Termin> PregledSvihTermina()
        {
            return terminServis.PregledSvihTermina();
        }
        public List<Lekar> DobaviSlobodneLekareHITNO(SpecijalizacijaEnum specijalizacija)
        {
            return terminServis.DobaviSlobodneLekareHITNO(specijalizacija);
        }
        public ObservableCollection<Prostorija> DobaviSlobodneProstorijeHITNO()
        {
            return terminServis.DobaviSlobodneProstorijeHITNO();
        }
        public List<Termin> NadjiAlternativneOperacije()
        {
            return terminServis.NadjiAlternativneOperacije();
        }
        public List<Termin> NadjiAlternativnePreglede()
        {
            return terminServis.NadjiAlternativnePreglede();
        }
        public Lekar DTO2ModelNapravi(LekarDTO dto)
        {
            return lekarServis.DTO2ModelNapravi(dto);
        }
        private PacijentController pacijentKontroler = new PacijentController();
        private TerminKonverter terminKonverter = new TerminKonverter();
        private PacijentKonverter pacijentKonverter = new PacijentKonverter();


        public IEnumerable<TerminDTO> dobaviListuDTOtermina(PacijentDTO pacijentDTO)
            => terminServis.PregledSvihTerminaPacijenta(pacijentKontroler.konvertujDTOuEntitet(pacijentDTO)).Select(entitet
                => terminKonverter.KonvertujEntitetUDTO(entitet)).ToList();
        public IEnumerable<TerminDTO> dobaviListuDTOProslihtermina(PacijentDTO pacijentDTO)
            => terminServis.PregledIstorijeTerminaPacijenta(pacijentKontroler.konvertujDTOuEntitet(pacijentDTO)).Select(entitet
                => terminKonverter.KonvertujEntitetUDTO(entitet)).ToList();

        public void otkaziPregled(TerminDTO terminDTO, PacijentDTO pacijentDTO)
        {
            Termin t = terminKonverter.KonvertujDTOuEntitet(terminDTO);
            Pacijent p = pacijentServis.pronadjiEntitetZaDTO(pacijentDTO);

            terminServis.OtkaziTerminPacijent(t, p);
        }

        public bool pomeriPregled(TerminDTO noviTermindDTO, PacijentDTO pacijentDTO)
        {
            Termin t = terminKonverter.KonvertujDTOuEntitet(noviTermindDTO);
            Pacijent p = pacijentServis.pronadjiEntitetZaDTO(pacijentDTO);
            return terminServis.AzurirajTerminPacijent(t, p);
        }

        TerminService ts = TerminService.Instance;
        private static TerminController _instance;

        public static TerminController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TerminController();
                }
                return _instance;
            }
        }

        public bool izdajUput(PacijentDTO pac, TerminDTO termin)
        {
            return ts.izdajUput(pac, termin);
        }
        public bool IzdajAnamnezu(IzvestajDTO izvestaj, TerminDTO termin)
        {
            return ts.IzdajAnamnezu(izvestaj, termin);
        }
        public bool ObrisiAnamnezu(IzvestajDTO izvestaj, TerminDTO termin)
        {
            return ts.ObrisiAnamnezu(izvestaj, termin);
        }
        public Termin FindOpByPocetak(DateTime poc)
        {
            return ts.FindOpByPocetak(poc);
        }
        public List<Termin> FindPrByPocetak(DateTime poc)
        {
            return ts.FindPrByPocetak(poc);
        }

        public bool ZakaziTermin(TerminDTO termin, PacijentDTO pacijent)
        {
            ts.ZakaziTermin(termin, pacijent);
            return true;
        }

        public Termin PregledTermina(int id)
        {
            return ts.PregledTermina(id);
        }

        public List<TerminDTO> PregledSvihTermina2()
        {
            return ts.PregledSvihTermina2();
        }
    }
}
