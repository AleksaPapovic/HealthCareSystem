using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class IstorijaBolestiServis
    {
        public bool DodajIstorijuBolesti(IstorijaBolesti istorijaBolesti)
        {
            IstorijaBolestiRepozitorijum datoteka = new IstorijaBolestiRepozitorijum();
            List<IstorijaBolesti> istorijeBolesti = datoteka.DobaviSve();
            foreach (IstorijaBolesti i in istorijeBolesti)
            {
                if (i.zdravstveniKarton.Id.Equals(istorijaBolesti.GetZdravstveniKarton().Id))
                {
                    return false;
                }
            }
            istorijeBolesti.Add(istorijaBolesti);
            datoteka.Sacuvaj(istorijeBolesti);
            return true;
        }

        public bool ObrisiIstorijuBolesti(IstorijaBolesti istorijaBolesti)
        {
            IstorijaBolestiRepozitorijum datoteka = new IstorijaBolestiRepozitorijum();
            List<IstorijaBolesti> istorijeBolesti = datoteka.DobaviSve();
            foreach (IstorijaBolesti i in istorijeBolesti)
            {
                if (i.zdravstveniKarton.Id.Equals(istorijaBolesti.GetZdravstveniKarton().Id))
                {
                    istorijeBolesti.Remove(i);
                    datoteka.Sacuvaj(istorijeBolesti);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajIstorijuBolesti(IstorijaBolesti istorijaBolesti)
        {
            IstorijaBolestiRepozitorijum datoteka = new IstorijaBolestiRepozitorijum();
            List<IstorijaBolesti> istorijeBolesti = datoteka.DobaviSve();
            foreach (IstorijaBolesti i in istorijeBolesti)
            {
                if (i.zdravstveniKarton.Id.Equals(istorijaBolesti.GetZdravstveniKarton().Id))
                {
                    istorijeBolesti.Remove(i);
                    istorijeBolesti.Add(istorijaBolesti);
                    datoteka.Sacuvaj(istorijeBolesti);
                    return true;
                }
            }
            return false;
        }

        public IstorijaBolesti PregledIstorijeBolesti(String id)
        {
            IstorijaBolestiRepozitorijum datoteka = new IstorijaBolestiRepozitorijum();
            List<IstorijaBolesti> istorijeBolesti = datoteka.DobaviSve();
            foreach (IstorijaBolesti i in istorijeBolesti)
            {
                if (i.zdravstveniKarton.Id.Equals(id))
                {
                    return i;
                }
            }
            return null;
        }

        public List<IstorijaBolesti> PregledSvihIstorijaBolesti()
        {
            IstorijaBolestiRepozitorijum datoteka = new IstorijaBolestiRepozitorijum();
            List<IstorijaBolesti> istorijeBolesti = datoteka.DobaviSve();
            return istorijeBolesti;
        }

    }
}