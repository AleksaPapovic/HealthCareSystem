using Model;
using Repository;
using System.Collections.Generic;

namespace Service
{
    public class DijagnozaServis
    {
        public bool DodajDijagnozu(Dijagnoza Dijagnoza)
        {
            DijagnozaRepozitorijum datoteka = new DijagnozaRepozitorijum();
            List<Dijagnoza> dijagnoze = datoteka.DobaviSve();
            foreach (Dijagnoza t in dijagnoze)
            {
                if (t.Equals(Dijagnoza))
                {
                    return false;
                }
            }
            dijagnoze.Add(Dijagnoza);
            datoteka.Sacuvaj(dijagnoze);
            return true;
        }

        public bool ObrisiDijagnozu(Dijagnoza Dijagnoza)
        {
            DijagnozaRepozitorijum datoteka = new DijagnozaRepozitorijum();
            List<Dijagnoza> dijagnoze = datoteka.DobaviSve();
            foreach (Dijagnoza t in dijagnoze)
            {
                if (t.Equals(Dijagnoza))
                {
                    dijagnoze.Remove(t);
                    datoteka.Sacuvaj(dijagnoze);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajDijagnozu(Dijagnoza dijagnoza)
        {
            DijagnozaRepozitorijum datoteka = new DijagnozaRepozitorijum();
            List<Dijagnoza> dijagnoze = datoteka.DobaviSve();
            foreach (Dijagnoza d in dijagnoze)
            {
                if (d.Equals(dijagnoza))
                {
                    dijagnoze.Remove(d);
                    dijagnoze.Add(dijagnoza);
                    datoteka.Sacuvaj(dijagnoze);
                    return true;
                }
            }
            return false;
        }

        public Dijagnoza PregledDijagnoze(Dijagnoza dijagnoza)
        {
            DijagnozaRepozitorijum datoteka = new DijagnozaRepozitorijum();
            List<Dijagnoza> dijagnoze = datoteka.DobaviSve();
            foreach (Dijagnoza d in dijagnoze)
            {
                if (d.Equals(dijagnoza))
                {
                    return d;
                }
            }
            return null;
        }

        public List<Dijagnoza> PregledSvihDijagnoza()
        {
            DijagnozaRepozitorijum datoteka = new DijagnozaRepozitorijum();
            List<Dijagnoza> dijagnoze = datoteka.DobaviSve();
            return dijagnoze;
        }

    }
}