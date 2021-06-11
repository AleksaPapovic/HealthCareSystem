using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.LekoviCRUD;

namespace Service
{
    public class IzvestajLekoviService
    {
        IzvestajLekoviRepozitorijum izvestajLekoviRepozitorijum = new IzvestajLekoviRepozitorijum();
       public bool generisiIzvestajPDF(IzvestajLekovi izvestajLekovi, List<LekDTO> sortiraniLekovi)
        {
            IzvestajLekoviRepozitorijum izvestaj = new IzvestajLekoviRepozitorijum();
            IIzvestajLekoviRepozitorijum izvestajPDF = new IzvestajLekoviRepozitorijumPDF(izvestaj);
            izvestajPDF.generisiIzvestaj(izvestajLekovi);
            return true;
        }

        public bool generisiIzvestajXML(IzvestajLekovi izvestajLekovi, List<LekDTO> sortiraniLekovi)
        {
            IzvestajLekoviRepozitorijum izvestaj = new IzvestajLekoviRepozitorijum();
            IIzvestajLekoviRepozitorijum izvestajXML = new IzvestajLekoviRepozitorijumXML(izvestaj);
            izvestajXML.generisiIzvestaj(izvestajLekovi);
            return true;
        }

       public bool generisiIzvestajCSV(IzvestajLekovi izvestajLekovi, List<LekDTO> sortiraniLekovi)
        {
            IzvestajLekoviRepozitorijum izvestaj = new IzvestajLekoviRepozitorijum();
            IIzvestajLekoviRepozitorijum izvestajCSV = new IzvestajLekoviRepozitorijumCSV(izvestaj);
            izvestajCSV.generisiIzvestaj(izvestajLekovi);
            return true;
        }
    }
}
