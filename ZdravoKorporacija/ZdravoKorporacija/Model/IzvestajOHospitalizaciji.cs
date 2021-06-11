/***********************************************************************
 * Module:  IzvestajOHospitalizaciji.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class IzvestajOHospitalizaciji
 ***********************************************************************/

using System;
namespace Model
{
    public class IzvestajOHospitalizaciji
    {
        public ZdravstveniKarton zdravstveniKarton;

        public IzvestajOHospitalizaciji(ZdravstveniKarton zdravstveniKarton, int idIzvestaja, string nazivUstanove, int idUstanove, int brojDanaProvedenihUUstanovi, DateTime datumOtpusta, OtpustEnum vrstaOtpusta)
        {
            this.zdravstveniKarton = zdravstveniKarton;
            IdIzvestaja = idIzvestaja;
            NazivUstanove = nazivUstanove;
            IdUstanove = idUstanove;
            BrojDanaProvedenihUUstanovi = brojDanaProvedenihUUstanovi;
            DatumOtpusta = datumOtpusta;
            VrstaOtpusta = vrstaOtpusta;
        }


        /// <pdGenerated>default parent getter</pdGenerated>
        public ZdravstveniKarton GetZdravstveniKarton()
        {
            return zdravstveniKarton;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newZdravstveniKarton</param>
        public void SetZdravstveniKarton(ZdravstveniKarton newZdravstveniKarton)
        {
            if (this.zdravstveniKarton != newZdravstveniKarton)
            {
                if (this.zdravstveniKarton != null)
                {
                    ZdravstveniKarton oldZdravstveniKarton = this.zdravstveniKarton;
                    this.zdravstveniKarton = null;
                    oldZdravstveniKarton.RemoveIzvestajOHospitalizaciji(this);
                }
                if (newZdravstveniKarton != null)
                {
                    this.zdravstveniKarton = newZdravstveniKarton;
                    this.zdravstveniKarton.AddIzvestajOHospitalizaciji(this);
                }
            }
        }

        public int IdIzvestaja { get; set; }
        public String NazivUstanove { get; set; }
        public int IdUstanove { get; set; }
        public int BrojDanaProvedenihUUstanovi { get; set; }
        public DateTime DatumOtpusta { get; set; }
        public OtpustEnum VrstaOtpusta { get; set; }

    }
}