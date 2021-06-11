using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using ZdravoKorporacija.Stranice.LekoviCRUD;

namespace Repository
{
    public class IzvestajLekoviRepozitorijumPDF : IIzvestajLekoviRepozitorijum
    {
        private readonly IzvestajLekoviRepozitorijum _izvestajAdaptiran;

        public IzvestajLekoviRepozitorijumPDF(IzvestajLekoviRepozitorijum adaptiranIzvestaj)
        {
            this._izvestajAdaptiran = adaptiranIzvestaj;
        }
       

        public bool generisiIzvestaj(IzvestajLekovi izvestajLekovi)
        {
            this._izvestajAdaptiran.generisiIzvestaj(izvestajLekovi.sortiraniLekovi);
            PrintDialog _printDialog = new PrintDialog();
            _printDialog.PrintVisual(izvestajLekovi, "Izvestaj o trenutnom stanju lekova");
            return true;
        }
    }
}
