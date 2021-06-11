using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Repository;
using Service;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.ServiceSekretarUtility
{
    class RadniDanSekretarUtility
    {
        private RadniDanRepozitorijum datoteka = new RadniDanRepozitorijum();
        private RadniDanService service = new RadniDanService();
        public void DodajSlobodneDane(DateTime Od, DateTime Do, double lekar)
        {
            List<RadniDan> dani = service.PregledSvihRadnihDana();
            foreach (RadniDan rd in dani.ToArray())
            {
                if (rd.dan.CompareTo(Od) >= 0 && rd.dan.CompareTo(Do) <= 0 && rd.lekar.Equals(lekar))
                {
                    RadniDan novi = rd;
                    novi.odmor = true;
                    if (service.AzurirajRadniDan(novi))
                    {
                        dani.Remove(rd);
                        dani.Add(novi);
                        datoteka.sacuvaj(dani);
                    }
                }

            }
        }

        public void PromeniSmenu(PromeniSmenuDTO smenaDTO)
        {
            List<RadniDan> dani = service.PregledSvihRadnihDana();
            foreach (RadniDan rd in dani.ToArray())
            {
                if (rd.dan.Date.CompareTo(smenaDTO.Od.Date) >= 0 && rd.dan.Date.CompareTo(smenaDTO.Do.Date) <= 0 && rd.lekar.Equals(smenaDTO.idLekara))
                {
                    RadniDan novi = rd;
                    if (smenaDTO.prvaSmena == false)
                        novi.prvaSmena = false;
                    else
                        novi.prvaSmena = true;
                    if (service.AzurirajRadniDan(novi))
                    {
                        dani.Remove(rd);
                        dani.Add(novi);
                        datoteka.sacuvaj(dani);
                    }
                }
            }
        }
        public List<RadniDan> PregledOdDo(DateTime Od, DateTime Do, double lekar)
        {
            List<RadniDan> dani = new List<RadniDan>();
            foreach (RadniDan rd in service.PregledSvihRadnihDana())
            {
                if (rd.dan.Date >= Od.Date && rd.dan.Date <= Do.Date && rd.lekar.Equals(lekar))
                {
                    dani.Add(rd);
                }
            }
            return dani;
        }
    }
}
