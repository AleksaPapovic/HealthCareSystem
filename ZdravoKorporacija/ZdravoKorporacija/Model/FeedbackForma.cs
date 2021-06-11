using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Model
{
    class FeedbackForma
    {

        public FeedbackForma() { }

        public FeedbackForma(FeedbackFormaDTO formaDTO)
        {
            this.sadrzaj = formaDTO.sadrzaj;
            this.uloga = formaDTO.uloga;
        }

        public FeedbackForma(string sadrzaj, UlogaEnum uloga)
        {
            this.sadrzaj = sadrzaj;
            this.uloga = uloga;
        }



        public UlogaEnum uloga { get; set; }
        public string sadrzaj { get; set; }
    }
}
