using Model;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace ZdravoKorporacija.Service
{
    public class AnketaService
    {
        private AnketaRepozitorijum anketaRepozitorijum = new AnketaRepozitorijum();
        public void dodajAnketu(Anketa anketa)
        {
            List<Anketa> ankete = anketaRepozitorijum.DobaviSve();
            anketa.Id = ankete.Count + 1;
            ankete.Add(anketa);
            anketaRepozitorijum.Sacuvaj(ankete);
        }

        public bool vecOcijenjen(Termin termin)
        {
            Anketa a = anketaRepozitorijum.DobaviSve().FirstOrDefault(a => a.Termin != null && a.Termin.Id.Equals(termin.Id));
            return a != null;
        }

        public Anketa dobaviPosljednjuAnketuBolnice(Pacijent pacijent)
        {
            List<Anketa> ankete = anketaRepozitorijum.DobaviSve();
            Anketa poslednja = (Anketa)ankete.LastOrDefault(s => s.IdAutora.Equals(pacijent.Jmbg) && s.Termin == null);
            return poslednja;
        }


    }
}
