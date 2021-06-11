using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Service
{

    class ObavestenjaService
    {
       

        public List<Notifikacija> PregledSvihObavestenja()
        {
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> obavestenja = datoteka.dobaviSve();
            return obavestenja;
        }
   
        
        public bool dodajObavestenje(Notifikacija not)
        {
            PacijentRepozitorijum pr = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = pr.dobaviSve();
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> notifikacije = datoteka.dobaviSve();
            bool ret = true;
            foreach (Notifikacija n in notifikacije)
            {
                if(n!=null)
                if (not.Id.Equals(n.Id))
                    ret = false;
            }
            notifikacije.Add(not);
            datoteka.sacuvaj(notifikacije);
            foreach (Pacijent p in pacijenti)
            {
                if(p.notifikacije == null)
                {
                    p.notifikacije = new ObservableCollection<Notifikacija>();
                }
                p.notifikacije.Add(not);
                pr.sacuvaj(pacijenti);
            }
            return ret;

        }


        
        public bool obrisiObavestenje(String  not)
        {
            PacijentRepozitorijum pr = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = pr.dobaviSve();
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> notifikacije = datoteka.dobaviSve();
            PacijentService pc = new PacijentService();
            bool ret = false;
                foreach (Notifikacija n in notifikacije)
                {
                if(n!=null)
                    if (not.Equals(n.Sadrzaj))
                    {
                    pc.ObrisiObavestenjePacijentu(not);
                    notifikacije.Remove(n);
                    datoteka.sacuvaj(notifikacije);
                   
                    ret =  true;
                    }
                }
           
            return ret;
        }


  

      
    }
}




