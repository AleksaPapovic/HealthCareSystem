using Service;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.LekoviCRUD;

namespace Controller
{
    public class IzvestajLekoviController
    {
        IzvestajLekoviService izvestajLekoviService = new IzvestajLekoviService();
        public bool generisiIzvestajPDF(IzvestajLekovi izvestajLekovi, List<LekDTO> sortiraniLekovi)
        {
            return izvestajLekoviService.generisiIzvestajPDF(izvestajLekovi,sortiraniLekovi);
        }

       public bool generisiIzvestajXML(IzvestajLekovi izvestajLekovi, List<LekDTO> sortiraniLekovi)
        {
            return izvestajLekoviService.generisiIzvestajXML(izvestajLekovi, sortiraniLekovi);
        }

        public bool generisiIzvestajCSV(IzvestajLekovi izvestajLekovi, List<LekDTO> sortiraniLekovi)
        {
            return izvestajLekoviService.generisiIzvestajCSV(izvestajLekovi, sortiraniLekovi);
        }
    }
}
