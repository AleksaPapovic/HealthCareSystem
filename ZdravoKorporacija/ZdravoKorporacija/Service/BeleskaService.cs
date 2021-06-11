using Model;
using Repository;
using System.Collections.Generic;

namespace ZdravoKorporacija.Service
{
    public class BeleskaService
    {
        private BeleskaRepozitorijum beleskaRepozitorijum = new BeleskaRepozitorijum();

        public void sacuvajBelesku(Beleska beleska)
        {
            List<Beleska> beleske = beleskaRepozitorijum.DobaviSve();
            beleska.Id = beleske.Count + 1;
            beleske.Add(beleska);
            beleskaRepozitorijum.Sacuvaj(beleske);
        }

        public List<Beleska> dobaviSveBeleske()
        {
            return beleskaRepozitorijum.DobaviSve();
        }

    }
}
