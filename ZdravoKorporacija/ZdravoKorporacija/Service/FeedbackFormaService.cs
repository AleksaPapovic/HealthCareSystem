using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Service
{
    class FeedbackFormaService
    {
        private FeedbackRepozitorijum repozitorijum = FeedbackRepozitorijum.Instance;

       
        public List<FeedbackForma> PregledSvihFormi()
        {
            List<FeedbackForma> forme = repozitorijum.DobaviSve();
            return forme;
        }
       
        public bool ObrisiFormu(string sadrzaj)
        {
            List<FeedbackForma> forme = repozitorijum.DobaviSve();
            bool ret = false;
            foreach(FeedbackForma ff in forme.ToList())
            {
                if (ff != null)
                    if (sadrzaj.Equals(ff.sadrzaj))
                    {
                        forme.Remove(ff);
                        repozitorijum.Sacuvaj(forme);
                        ret = true;
                    }
            }
            return ret;
        } 
        public bool DodajFormu(FeedbackFormaDTO formaDTO)
        {
            FeedbackForma forma = new FeedbackForma(formaDTO);
            List<FeedbackForma> forme = repozitorijum.DobaviSve();
            bool ret = true;
            foreach(FeedbackForma ff in forme)
            {
                if (ff != null)
                    if (forma.sadrzaj.Equals(ff.sadrzaj) && forma.uloga.Equals(ff.uloga))
                        ret = false;
            }
            forme.Add(forma);
            repozitorijum.Sacuvaj(forme);
            return ret;
        }
    }
}
