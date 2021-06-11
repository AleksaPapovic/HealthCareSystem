using Model;
using Repository;
using System.Collections.Generic;

namespace Service
{
    public class TerapijaServis
    {
        public bool DodajTerapiju(Terapija terapija)
        {
            TerapijaRepozitorijum datoteka = new TerapijaRepozitorijum();
            List<Terapija> terapije = datoteka.DobaviSve();
            foreach (Terapija t in terapije)
            {
                if (t.Equals(terapija))
                {
                    return false;
                }
            }
            terapije.Add(terapija);
            datoteka.Sacuvaj(terapije);
            return true;
        }

        public bool ObrisiTerapiju(Terapija terapija)
        {
            TerapijaRepozitorijum datoteka = new TerapijaRepozitorijum();
            List<Terapija> terapije = datoteka.DobaviSve();
            foreach (Terapija t in terapije)
            {
                if (t.Equals(terapija))
                {
                    terapije.Remove(t);
                    datoteka.Sacuvaj(terapije);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajTerapiju(Terapija terapija)
        {
            TerapijaRepozitorijum datoteka = new TerapijaRepozitorijum();
            List<Terapija> terapije = datoteka.DobaviSve();
            foreach (Terapija t in terapije)
            {
                if (t.Equals(terapija))
                {
                    terapije.Remove(t);
                    terapije.Add(terapija);
                    datoteka.Sacuvaj(terapije);
                    return true;
                }
            }
            return false;
        }

        public Terapija PregledTerapije(Terapija terapija)
        {
            TerapijaRepozitorijum datoteka = new TerapijaRepozitorijum();
            List<Terapija> terapije = datoteka.DobaviSve();
            foreach (Terapija t in terapije)
            {
                if (t.Equals(terapija))
                {
                    return t;
                }
            }
            return null;
        }

        public List<Terapija> PregledSvihTerapija()
        {
            TerapijaRepozitorijum datoteka = new TerapijaRepozitorijum();
            List<Terapija> terapije = datoteka.DobaviSve();
            return terapije;
        }

    }
}