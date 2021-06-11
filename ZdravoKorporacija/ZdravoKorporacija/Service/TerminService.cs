using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Stranice.LekarCRUD;

namespace ZdravoKorporacija.Model
{

    public class TerminService
    {
        public static int TA_ZAKAZIVANJE = 0;
        public static int TA_POMJERANJE = 1;
        public static int TA_OTKAZIVANJE = 2;


        private TerminRepozitorijum terminRepozitorijum = new TerminRepozitorijum();
        private IDRepozitorijum idRepozitorijum = new IDRepozitorijum("iDMapTermin");


        private LekarService lekarServis = new LekarService();
        private ProstorijaService prostorijaServis = new ProstorijaService();
        private RadniDanService daniServis = new RadniDanService();

        TerminRepozitorijum tr = TerminRepozitorijum.Instance;
        IzvestajService iz = IzvestajService.Instance;
        PacijentService pacijentServis = PacijentService.Instance;
        LekarRepozitorijum lekariDat = LekarRepozitorijum.Instance;
        List<Lekar> lekari = LekarRepozitorijum.Instance.dobaviSve();
        IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapIzvestaj");
        Dictionary<int, int> id_map = new Dictionary<int, int>();
        TerminKonverter terminKonverter = new TerminKonverter();

        IDRepozitorijum uputDat = new IDRepozitorijum("iDMapTermin");
        Dictionary<int, int> id_uput = new Dictionary<int, int>();


        private static TerminService _instance;

        public static TerminService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TerminService();
                }
                return _instance;
            }
        }

        public ITerminStrategija dobaviStrategiju(Termin termin)
        {
            if (termin.Tip == TipTerminaEnum.Pregled)
            {
                return new PregledStrategija();
            }
            else if (termin.Tip == TipTerminaEnum.Operacija)
            {
                return new OperacijaStrategija();
            }
            else if (termin.Tip == TipTerminaEnum.Renoviranje)
            {
                return new RenoviranjeStrategija();
            }
            else //if (termin.Tip == TipTerminaEnum.PremestanjeOpreme)
            {
                return new PremjestanjeOpremeStrategija();
            }
        }
        public void zakaziTermin(Termin noviTermin)
        {
            TerminKontekst kontekst = new TerminKontekst(dobaviStrategiju(noviTermin));
            noviTermin.Id = dodijeliID(); 
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            termini.Add(kontekst.zakaziTermin(noviTermin)); 
            terminRepozitorijum.sacuvaj(termini);
        }

        public bool zakaziHitniLekar(TerminDTO termin,PacijentDTO pacijent)
        {
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            Boolean slobodan = false;
            TerminDTO t = FindTerminToMove(termin);
            
           
        if (t != null)
            {
            for (int i = 30; i < 300; i += 30)
            {
                foreach (Termin ter in termini)
                {
                    if (ter.hitno == false)
                    {
                        if (ter.Pocetak != RoundUp(DateTime.Now, TimeSpan.FromMinutes(i)))
                        {
                            slobodan = true;
                            break;
                        }
                        else
                        {
                            slobodan = false;
                        }
                    }
                }
                if (slobodan)
                {
                        foreach (TerminDTO termin1 in lekarStart.uputi)
                        {
                            if(termin1.Id.Equals(t.Id))
                            {
                                lekarStart.uputi.Remove(termin1);
                                break;
                            }
                        }
                        t.Pocetak = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)).AddMinutes(i);
                        AzurirajTermin(t);
                        lekarStart.uputi.Add(t);
                        Trace.WriteLine(t.Id+" "+t.Pocetak);
                        break;
                }
               }
             }
            
            ZakaziTermin(termin,pacijent);
            return true;
        }
        public bool izdajUput(PacijentDTO pac, TerminDTO termin)
        {
            id_uput = uputDat.dobaviSve();

            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_uput[i] == 0)
                {
                    id = i;
                    id_uput[i] = 1;
                    break;
                }
            }
            termin.Id = id;
            if (ZakaziTermin(termin, pac))
            {
                lekariDat.sacuvaj(lekari);
            }
            pac.AddTermin(termin);
            pacijentServis.AzurirajPacijenta(pac);

            return true;
        }

        public bool IzdajAnamnezu(IzvestajDTO izvestaj, TerminDTO termin)
        {
            List<PacijentDTO> pacijenti = new List<PacijentDTO>(pacijentServis.PregledSvihPacijenata2());
            id_map = datotekaID.dobaviSve();

            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    break;
                }
            }
            izvestaj.Id = id;
            foreach (PacijentDTO p in pacijenti)
            {
                if (termin.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                {
                    foreach (TerminDTO t in p.termin)
                    {
                        if (t.Id.Equals(termin.Id))
                        {

                            t.izvestaj = izvestaj;
                        }
                    }
                    pacijentServis.AzurirajPacijenta(p);
                    break;
                }

            }
            iz.DodajIzvestaj(izvestaj, id_map);
            termin.izvestaj = izvestaj;
            AzurirajTermin(termin);
            return true;
        }

        public bool ObrisiAnamnezu(IzvestajDTO izvestaj, TerminDTO termin)
        {
            List<PacijentDTO> pacijenti = new List<PacijentDTO>(pacijentServis.PregledSvihPacijenata2());
            PacijentDTO pac = new PacijentDTO();
            foreach (PacijentDTO p in pacijenti)
            {
                if (termin.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                {
                    foreach (TerminDTO t in p.termin)
                    {
                        if (t.Id.Equals(termin.Id))
                        {
                            t.izvestaj = null;
                            id_map = datotekaID.dobaviSve();
                            id_map[izvestaj.Id] = 0;
                            datotekaID.sacuvaj(id_map);
                            break;
                        }
                    }
                }
            }

            termin.izvestaj = null;
            AzurirajTermin(termin);
            pacijentServis.AzurirajPacijenta(pac);
            iz.ObrisiIzvestaj(izvestaj, id_map);
            return true;
        }
        public Termin FindOpByPocetak(DateTime poc)
        {
           terminRepozitorijum  = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum .dobaviSve();
            Termin temp = null;
            foreach (Termin t in termini)
            {
                if (t.Pocetak == poc && t.Tip == TipTerminaEnum.Operacija)
                    temp = t;
            }
            return temp;
        }

        public TerminDTO FindOpByPocetak2(DateTime poc)
        {
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            foreach (Termin t in termini)
            {
                if (t.Pocetak == poc && t.Tip == TipTerminaEnum.Operacija)
                    return new TerminDTO(t);
            }

            return null;
        }

        public TerminDTO FindTerminToMove(TerminDTO termin)
        {
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            foreach (Termin t in termini)
            {
                if (t.Pocetak.Equals(termin.Pocetak) && t.prostorija.Id.Equals(termin.prostorija.Id) && t.hitno==false)
                    return new TerminDTO(t);
            }

            return null;
        }

        public List<Termin> FindPrByPocetak(DateTime poc)
        {
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            List<Termin> povratna = new List<Termin>();
            foreach (Termin t in termini)
            {
                if (t.Pocetak == poc && t.Tip == TipTerminaEnum.Pregled)
                    povratna.Add(t);
            }

            return povratna;
        }
        public List<TerminDTO> FindPrByPocetak2(DateTime poc)
        {
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            List<TerminDTO> povratna = new List<TerminDTO>();
            foreach (Termin t in termini)
            {
                if (t.Pocetak == poc && t.Tip == TipTerminaEnum.Pregled)
                    povratna.Add(new TerminDTO(t));
            }

            return povratna;
        }

        public void DodajTermin(TerminDTO dto)
        {
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            termini.Add(DTO2Model(dto));

        }

        public bool ZakaziTermin(Termin termin, Dictionary<int, int> ids)
        {
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");

            termini.Add(termin);
            terminRepozitorijum.sacuvaj(termini);
            datotekaID.sacuvaj(ids);

            return true;
        }

        public bool ZakaziTerminDTO(TerminDTO terminDTO, Dictionary<int, int> ids)
        {
            Termin termin = new Termin(terminDTO);
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");

            termini.Add(termin);
            terminRepozitorijum.sacuvaj(termini);
            datotekaID.sacuvaj(ids);

            return true;
        }

        public bool ZakaziTermin(TerminDTO termin, PacijentDTO pacijent)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            id_map = datotekaID.dobaviSve();

            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    break;
                }
            }
            termin.Id = id;
            foreach (Termin t in datoteka.dobaviSve())
            {
                if (termin.Id.Equals(t.Id))
                {
                    return false;
                }
            }


            termini.Add(new Termin(termin));
            datoteka.sacuvaj(termini);
            datotekaID.sacuvaj(id_map);
            pacijent.AddTermin(new TerminDTO(termin.Id));
            pacijentServis.AzurirajPacijenta(pacijent);
            return true;
        }

        public bool OtkaziTermin(TerminDTO termin)
        {
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            IDRepozitorijum datotekaId = new IDRepozitorijum("iDMapTermin");
            PacijentDTO pacijent = new PacijentDTO();
            Dictionary<int, int> ids = datotekaId.dobaviSve();
            foreach (PacijentDTO pac in pacijentServis.PregledSvihPacijenata2())
            {
                if (termin.zdravstveniKarton.Id.Equals(pac.ZdravstveniKarton.Id))
                {
                    pacijent = pac;
                }
            }
            foreach (Termin t in termini)
            {
                if (t != null)
                {
                    if (t.Id.Equals(termin.Id))
                    {
                        ids[termin.Id] = 0;
                        termini.Remove(t);
                        terminRepozitorijum.sacuvaj(termini);
                        datotekaId.sacuvaj(ids);
                        if (pacijent.termin != null)
                            pacijent.termin.Remove(termin);
                        pacijentServis.AzurirajPacijenta(pacijent);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AzurirajTermin(Termin termin)
        {
           terminRepozitorijum  = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum .dobaviSve();
            bool ret = false;
            foreach (Termin t in termini.ToList())
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    termini.Add(termin);
                    terminRepozitorijum .sacuvaj(termini);
                    ret = true;
                }
            }

            return ret;
        }

        public bool AzurirajTermin(TerminDTO termin)
        {
            List<Termin> termini = tr.dobaviSve();
            bool ret = false;
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    termini.Add(new Termin(termin));
                    tr.sacuvaj(termini);
                    ret =  true;
                    break;
                }
            }
            return ret;
        }

        public bool OtkaziTermin(Termin termin, Dictionary<int, int> ids)
        {
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            bool ret = false;
            foreach (Termin t in termini.ToList())
            {
                if (t != null)
                {
                    if (t.Id.Equals(termin.Id))
                    {
                        termini.Remove(t);
                        terminRepozitorijum.sacuvaj(termini);
                        datotekaID.sacuvaj(ids);

                        ret = true;
                    }
                }
            }

            return ret;
        }

        public Termin PregledTermina(int id)
        {
            terminRepozitorijum = new TerminRepozitorijum();
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            Termin ret = null;
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(id))
                {
                    ret =  t;
                }
            }

            return ret;
        }
             DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }

        public List<Termin> PregledSvihTermina()
        {
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            return termini;
        }
        public ObservableCollection<TerminDTO> PregledSvihTerminaDTO()
        {
            ObservableCollection<Termin> termini = new ObservableCollection<Termin>(terminRepozitorijum.dobaviSve());
            ObservableCollection<TerminDTO> terminiDTO = new ObservableCollection<TerminDTO>();
            foreach (Termin termin in termini)
            {
                terminiDTO.Add(konvertujEntitetUDTO(termin));
            }
            return terminiDTO;

        }

        public TerminDTO konvertujEntitetUDTO(Termin termin)
        {
            return new TerminDTO(termin);
        }

        public List<TerminDTO> PregledSvihTermina2DTO(List<Termin> modeli)
        {
            List<TerminDTO> dtos = new List<TerminDTO>();
            if (modeli == null)
                modeli = PregledSvihTermina();
            foreach (Termin model in modeli)
            {
                if (model != null)
                    dtos.Add(Model2DTO(model));
            }

            return dtos;
        }

        public List<Termin> PregledSvihTerminaPacijenta(Pacijent p)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> sviTermini = datoteka.dobaviSve();
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in sviTermini)
            {
                if (termin.zdravstveniKarton != null && termin.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id) &&
                    termin.Pocetak > DateTime.Parse(DateTime.Now.ToString()))
                {
                    termini.Add(termin);
                }
            }
            return termini;
        }

        public List<Termin> PregledIstorijeTerminaPacijenta(Pacijent p)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> sviTermini = datoteka.dobaviSve();
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in sviTermini)
            {
                if (termin.zdravstveniKarton != null && termin.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id) &&
                    termin.Pocetak < DateTime.Parse(DateTime.Now.ToString()))
                {
                    termini.Add(termin);
                }
            }
            return termini;
        }
        public List<TerminDTO> PregledSvihTermina2()
        {
            List<Termin> termini = tr.dobaviSve();
            List<TerminDTO> terminiDTO = new List<TerminDTO>();
            foreach (Termin termin in termini)
            {
                terminiDTO.Add(terminKonverter.KonvertujEntitetUDTO(termin));
            }
            return terminiDTO;
        }


        public int MapaTermina(Dictionary<int, int> ids)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    id = i;
                    ids[i] = 1;
                    break;
                }
            }

            return id;
        }



        public List<Lekar> ProveriDaLiJeNaOdmoru(DateTime pocetakTermina)
        {
            List<Lekar> slobodniLekari = lekarServis.PregledSvihLekara();
            foreach (RadniDan rd in daniServis.PregledSvihRadnihDana())
            {
                if (rd.dan.Date.Equals(pocetakTermina.Date) && rd.odmor == true)
                {
                    slobodniLekari.Remove(lekarServis.NadjiLekaraPoJMBG((long)rd.lekar));
                }
            }

            return slobodniLekari;
        }


        public ObservableCollection<Prostorija> DobaviSlobodneProstorije(Termin termin)
        {
            ObservableCollection<Prostorija> slobodneProstorije = prostorijaServis.PregledSvihProstorija();
            return slobodneProstorije;
        }

        public ObservableCollection<Prostorija> DobaviSlobodneProstorije(ObservableCollection<Prostorija> prostorije, ObservableCollection<Termin> pregledi, Termin termin)
        {
            ObservableCollection<Prostorija> slobodneProstorije = prostorije;


            foreach (Termin t in PregledSvihTermina().ToArray())
            {
                if (t.Pocetak.Equals(termin.Pocetak))
                {

                    foreach (Prostorija p in prostorijaServis.PregledSvihProstorija().ToArray())

                    {
                        if (t.prostorija.Id.Equals(p.Id))
                        {
                            slobodneProstorije.Remove(p);
                        }
                    }
                }
            }

            return slobodneProstorije;
        }

        public ObservableCollection<ProstorijaDTO> DobaviSlobodneProstorije2(DateTime Pocetak)
        {
            ObservableCollection<ProstorijaDTO> slobodneProstorije = prostorijaServis.PregledSvihProstorija2();


            foreach (TerminDTO t in PregledSvihTermina2().ToArray())
            {
                if(Pocetak!=null)
                if (t.Pocetak.Equals(Pocetak))
                {

                    foreach (ProstorijaDTO p in slobodneProstorije)

                    {
                        if (t.prostorija.Id.Equals(p.Id))
                        {
                            slobodneProstorije.Remove(p);
                            return slobodneProstorije;
                        }
                    }
                }
            }
            return slobodneProstorije;
        }

        public ObservableCollection<ProstorijaDTO> DobaviSlobodneProstorije3(TerminDTO termin,DateTime Pocetak,ProstorijaDTO prostorija)
        {
            ObservableCollection<ProstorijaDTO> slobodneProstorije = prostorijaServis.PregledSvihProstorija2();
            List<TerminDTO> terminDTOs = PregledSvihTermina2();
            foreach(TerminDTO t in terminDTOs)
            {
                if (t.Id.Equals(termin.Id))
                {
                    terminDTOs.Remove(t);
                    break;
                }
                
            }

            foreach (TerminDTO t in terminDTOs)
            {
                if (Pocetak != null)
                    if (t.Pocetak.Equals(Pocetak))
                    {

                        foreach (ProstorijaDTO p in slobodneProstorije)
                        {
                            if (t.prostorija.Id.Equals(p.Id))
                            {
                                Trace.WriteLine(!(t.prostorija.Id.Equals(prostorija.Id)));
                                slobodneProstorije.Remove(p);
                                return slobodneProstorije;
                            }
                        }
                    }
            }
            return slobodneProstorije;
        }


        public void InicijalizujTerminLekaru(Termin t)
        {
            Termin terminZaLekara = new Termin();
            terminZaLekara.Id = t.Id;
            t.Lekar.AddTermin(terminZaLekara);
        }

        public ZdravstveniKarton ProveriKartonKodZakazivanja(Pacijent pacijent)
        {
            ZdravstveniKarton kartonTermina = new ZdravstveniKarton();

            if (pacijent.ZdravstveniKarton != null)
                kartonTermina = pacijent.ZdravstveniKarton;
            else
            {
                kartonTermina = new ZdravstveniKarton(null, pacijent.GetJmbg(), StanjePacijentaEnum.None, null,
                    KrvnaGrupaEnum.None, null);
                pacijent.ZdravstveniKarton = kartonTermina;
            }

            return kartonTermina;
        }


        public bool ZakaziTerminPacijent(Termin termin, Dictionary<int, int> ids, Pacijent pacijent)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            bool ret = true;
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    ret =  false;
                }
            }

            if(ret == true) { 
            termini.Add(termin);
            datoteka.sacuvaj(termini);
            datotekaID.sacuvaj(ids);
            Ban b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);
            b.zakazanCnt++;
            BanRepozitorijum.Instance.sacuvaj(b);
            }
            return  ret;
        }
      

        public bool AzurirajTerminPacijent(Termin termin, Pacijent pacijent)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            bool ret = false;
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    termini.Add(termin);
                    datoteka.sacuvaj(termini);
                    azurirajBanInfo(pacijent, TA_POMJERANJE);
                    ret =  true;
                }
            }

            return ret;
        }

        public bool OtkaziTerminPacijent(Termin termin, Pacijent pacijent)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            Dictionary<int, int> ids = datotekaID.dobaviSve();

            PacijentRepozitorijum pr = new PacijentRepozitorijum();
            bool ret = false;
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    ids[termin.Id] = 0;
                    termini.Remove(t);
                    datoteka.sacuvaj(termini);
                    datotekaID.sacuvaj(ids);
                    azurirajBanInfo(pacijent, TA_OTKAZIVANJE);

                    ret =  true;
                }
            }

            return ret;
        }

        public Termin DTO2Model(TerminDTO dto)
        {
            ZdravstveniKartonKonverter zkk = new ZdravstveniKartonKonverter();
            Termin model = new Termin(dto.Id, lekarServis.DTO2Model(dto.Lekar), dto.Tip, dto.Pocetak, dto.Trajanje);
            model.prostorija = prostorijaServis.DTO2Model(dto.prostorija);
            model.zdravstveniKarton = zkk.KonvertujDTOuEntitet(dto.zdravstveniKarton);
            model.hitno = dto.hitno;

            return model;
        }

        public Termin DTO2ModelNadji(TerminDTO dto)
        {
            Termin ret = null;
            foreach (Termin t in PregledSvihTermina())
            {
                if (dto.Id.Equals(t.Id))
                    ret = t;
            }

            return ret;
        }

        public void DodajTermin(Termin t)
        {
            TerminRepozitorijum tr = new TerminRepozitorijum();
            List<Termin> termini = tr.dobaviSve();
            termini.Add(t);
        }

        public TerminDTO Model2DTO(Termin model)
        {
            TerminDTO dto = new TerminDTO(new ZdravstveniKartonDTO(model.zdravstveniKarton), prostorijaServis.Model2DTO(model.prostorija),
                lekarServis.Model2DTO(model.Lekar), model.Tip, model.Pocetak, 0.5, new IzvestajDTO(model.izvestaj));
            dto.Id = model.Id;
            return dto;
        }

        public List<Termin> NadjiAlternativnePreglede()
        {
            List<Termin> alternative = new List<Termin>();
            foreach (Termin t in PregledSvihTermina())
            {
                if ((t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)) ||
                     t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(60)) ||
                     t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(90))) && t.Tip == TipTerminaEnum.Pregled &&
                    t.hitno == false)
                {
                    alternative.Add(t);
                }
            }

            return alternative;
        }

        public List<Termin> NadjiAlternativneOperacije()
        {
            List<Termin> alternative = new List<Termin>();
            foreach (Termin t in PregledSvihTermina())
            {
                if ((t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)) ||
                     t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(60)) ||
                     t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(90))) &&
                    t.Tip == TipTerminaEnum.Operacija && t.hitno == false)
                {
                    alternative.Add(t);
                }
            }

            return alternative;
        }

        public List<Lekar> DobaviSlobodneLekareHITNO(SpecijalizacijaEnum specijalizacija)
        {
            List<Lekar> slobodniLekari = new List<Lekar>();
            List<Lekar> lekari = lekarServis.PregledSvihLekara();
            slobodniLekari = lekari;

            foreach (Termin t in PregledSvihTermina())
            {
                string dateString = DateTime.Now.ToString();
                if (t.Pocetak.Equals(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30))))
                {
                    foreach (Lekar l in lekari.ToArray())
                    {
                        if (l.Jmbg.Equals(t.Lekar.Jmbg))
                        {
                            slobodniLekari.Remove(l);

                        }

                    }
                }
                else
                    foreach (Lekar l in lekari.ToArray())
                    {
                        if (l.Specijalizacija != specijalizacija)
                        {

                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).odmor == true)
                        {
                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).prvaSmena == true &&
                                 dateString.Contains('P'))
                        {
                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).prvaSmena == false &&
                                 dateString.Contains('A'))
                        {
                            slobodniLekari.Remove(l);
                        }
                    }

            }

            return slobodniLekari;
        }

        public List<Lekar> DobaviSlobodneLekare(DateTime pocetakTermina, SpecijalizacijaEnum specijalizacija)
        {
            List<Lekar> slobodniLekari = new List<Lekar>();
            List<Lekar> lekari = lekarServis.PregledSvihLekara();
            slobodniLekari = lekari;
            string dateString = pocetakTermina.ToString();
            foreach (Termin t in PregledSvihTermina())
            {
                if (t.Pocetak.Equals(pocetakTermina))
                {
                    foreach (Lekar l in lekari.ToArray())
                    {
                        if (l.Jmbg.Equals(t.Lekar.Jmbg))
                        {
                            slobodniLekari.Remove(l);

                        }

                    }
                }
                else
                    foreach (Lekar l in lekari.ToArray())
                    {
                        if (l.Specijalizacija != specijalizacija)
                        {

                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).odmor == true)
                        {
                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).prvaSmena == true &&
                                 dateString.Contains('P'))
                        {
                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).prvaSmena == false &&
                                 dateString.Contains('A'))
                        {
                            slobodniLekari.Remove(l);
                        }
                    }

            }

            return slobodniLekari;
        }

        public ObservableCollection<Prostorija> DobaviSlobodneProstorijeHITNO()
        {
            ObservableCollection<Prostorija> slobodneProstorije = new ObservableCollection<Prostorija>();
            ObservableCollection<Prostorija> prostorije = prostorijaServis.PregledSvihProstorija();
            slobodneProstorije = prostorije;

            foreach (Termin t in PregledSvihTermina())
            {
                if (t.Pocetak.Equals(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30))))
                {
                    foreach (Prostorija p in prostorije.ToArray())
                    {
                        if (t.prostorija.Id.Equals(p.Id))
                        {
                            slobodneProstorije.Remove(p);
                        }
                    }
                }
            }

            return slobodneProstorije;
        }

    

     
        private void azurirajBanInfo(Pacijent pacijent, int tipAktivnosti)
        {
            Ban b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);
            switch (tipAktivnosti)
            {
                case 0:
                    b.zakazanCnt++;
                    break;
                case 1:
                    b.pomerenCnt++;
                    break;
                case 2:
                    b.otkazanCnt++;
                    break;
                default:
                    break;
            }

            BanRepozitorijum.Instance.sacuvaj(b);
        }

        private int dodijeliID()
        {
            Dictionary<int, int> ids = idRepozitorijum.dobaviSve();

            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    id = i;
                    ids[i] = 1;
                    break;
                }
            }

            idRepozitorijum.sacuvaj(ids);
            return id;
        }

        public Termin pronadjiEntitetZaDTO(TerminDTO dto)
        {
            return terminRepozitorijum.dobaviSve()
                .FirstOrDefault(t => dto.Id.Equals(t.Id));
        }
    }
}



