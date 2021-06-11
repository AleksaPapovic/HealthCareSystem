using Repository;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.LekoviCRUD;

namespace Repository
{
    public class IzvestajLekoviRepozitorijumXML : IIzvestajLekoviRepozitorijum
    {
        private readonly IzvestajLekoviRepozitorijum _izvestajAdaptiran;

        public IzvestajLekoviRepozitorijumXML(IzvestajLekoviRepozitorijum adaptiranIzvestaj)
        {
            this._izvestajAdaptiran = adaptiranIzvestaj;
        }


        public bool generisiIzvestaj(IzvestajLekovi izvestajLekovi)
        {
            this._izvestajAdaptiran.generisiIzvestaj(izvestajLekovi.sortiraniLekovi);
            Stream s = File.OpenWrite(@"..\..\..\Data\izvestajLekovi.txt");
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<LekDTO>));
            xmlSer.Serialize(s,izvestajLekovi.sortiraniLekovi);
            return true;
        }
    }
}