using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Model;
using Repository;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.ServiceZaKonverzije;

namespace ZdravoKorporacija.ServiceSekretarUtility
{
    class ObavestenjaSekretarUtility
    {
        private TerminRepozitorijum datotekaTer = new TerminRepozitorijum();
        private List<Termin> termini;
        private PacijentRepozitorijum datotekaPac = new PacijentRepozitorijum();
        private List<Pacijent> pacijenti;
        private ObservableCollection<Notifikacija> not = new ObservableCollection<Notifikacija>();
        private Mediator mediator;
        public void generisiObavestenja()
        {

            termini = datotekaTer.dobaviSve();
            pacijenti = datotekaPac.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                not = p.GetNotifikacije();
                if (p.notifikacije != null)
                {
                    foreach (Notifikacija n in not.ToList())
                    {
                        if (n != null)
                            if (n.Tip == TipNotifikacije.Obavestenje)
                                p.notifikacije.Remove(n);
                    }
                }
                foreach (Termin t in termini)
                {
                    if (t != null)
                        if (p.Jmbg.Equals(t.zdravstveniKarton.Id))
                        {

                            Notifikacija obavestenje = new Notifikacija();
                            if (p.notifikacije == null)
                            {
                                p.notifikacije = new ObservableCollection<Notifikacija>();
                                obavestenje.Id = 1;
                            }
                            else
                                obavestenje.Id = (p.notifikacije.Count) + 1;

                            obavestenje.Datum = DateTime.Now;
                            obavestenje.Status = "Neprocitano";
                            obavestenje.Tip = TipNotifikacije.Obavestenje;
                            obavestenje.Sadrzaj = "Zakazan termin: " + t.Tip.ToString() + ", vreme: " + t.Pocetak.ToString();


                            p.notifikacije.Add(obavestenje);

                            datotekaPac.sacuvaj(pacijenti);
                        }
                }
            }
        }
    }
}
