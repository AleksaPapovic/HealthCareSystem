using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;

namespace Service
{
    class RadniDanService
    {
        private PacijentService pacijentServis = new PacijentService();
        private RadniDanRepozitorijum datoteka = new RadniDanRepozitorijum();
        private LekarService lekarServis = new LekarService();
        public RadniDan NadjiDanZaLekara(DateTime dan, double lekar)
        {

            foreach (RadniDan rd in datoteka.dobaviSve())
            {
                if (rd.dan.Date.CompareTo(dan.Date) == 0 && rd.lekar == lekar)
                {
                    return rd;
                }

            }
            return null;
        }
        public List<RadniDan> NadjiSveDaneZaLekara(double lekar)
        {
            List<RadniDan> dani = new List<RadniDan>();
            foreach (RadniDan rd in PregledSvihRadnihDana())
            {
                if (rd.lekar.Equals(lekar))
                    dani.Add(rd);
            }
            return dani;
        }

        public void InicijalizujRadneDane()
        {
            List<RadniDan> sviDani = PregledSvihRadnihDana();
            foreach (Lekar l in lekarServis.PregledSvihLekara())
            {
                List<RadniDan> dani = new List<RadniDan>();
                foreach (RadniDan rd in PregledSvihRadnihDana())
                {
                    if (rd.lekar.Equals(l.Jmbg))
                        dani.Add(rd);
                }
                if (dani.Count() == 0)
                {
                    for (DateTime date = DateTime.Now.Date; date <= DateTime.Now.AddDays(150); date = date.AddDays(1))
                    {

                        //l.radniDani.Add(new RadniDan(date, l.Jmbg, false, true));
                        dani.Add(new RadniDan(date.Date, l.Jmbg, false, true));

                    }
                    foreach (RadniDan dan in dani)
                    {
                        sviDani.Add(dan);
                        datoteka.sacuvaj(sviDani);
                    }
                }
            }
        }

        public bool AzurirajRadniDan(RadniDan dan)
        {
            List<RadniDan> dani = datoteka.dobaviSve();
            if (dan != null)
                foreach (RadniDan rd in dani)
                {
                    if (rd.dan.Date.Equals(dan.dan.Date) && rd.lekar.Equals(dan.lekar))
                    {
                        dani.Remove(rd);
                        dani.Add(dan);
                        datoteka.sacuvaj(dani);
                        return true;
                    }
                }
            return false;
        }
       
        public List<RadniDan> PregledSvihRadnihDana()
        {
            List<RadniDan> dani = datoteka.dobaviSve();
            return dani;
        }
       
    }
}
