using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ZdravoKorporacija.Stranice.LekoviCRUD;

namespace Repository
{
    public class IzvestajLekoviRepozitorijumCSV : IIzvestajLekoviRepozitorijum
    {
        private readonly IzvestajLekoviRepozitorijum _izvestajAdaptiran;

        public IzvestajLekoviRepozitorijumCSV(IzvestajLekoviRepozitorijum adaptiranIzvestaj)
        {
            this._izvestajAdaptiran = adaptiranIzvestaj;
        }


        public bool generisiIzvestaj(IzvestajLekovi izvestajLekovi)
        {
            this._izvestajAdaptiran.generisiIzvestaj(izvestajLekovi.sortiraniLekovi);
            var izvestajXML = izvestajLekovi.sortiraniLekovi;
            WriteCSV(izvestajXML, @"..\..\..\Data\izvestajLekovi.csv");
            return true;
        }

        public void WriteCSV<T>(IEnumerable<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                }
            }
        }

    }
}
