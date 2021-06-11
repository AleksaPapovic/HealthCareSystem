using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ZdravoKorporacija.DTO
{
    class FeedbackFormaDTO
    {
        public FeedbackFormaDTO() { }
        public FeedbackFormaDTO(string sadrzaj, UlogaEnum uloga) {
            this.sadrzaj = sadrzaj;
            this.uloga = uloga;
        }

        public string sadrzaj { get; set; }
        public UlogaEnum uloga { get; set; }
    }
}
