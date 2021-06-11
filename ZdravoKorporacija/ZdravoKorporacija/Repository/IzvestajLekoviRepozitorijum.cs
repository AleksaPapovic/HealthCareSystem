using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZdravoKorporacija.DTO;

namespace Repository
{
    public class IzvestajLekoviRepozitorijum
    {
        public bool generisiIzvestaj(List<LekDTO> lista)
        {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                StreamWriter writer = new StreamWriter(@"..\..\..\Data\izvestajLekovi.json");
                JsonWriter jWriter = new JsonTextWriter(writer);
                serializer.Serialize(jWriter, lista);
                jWriter.Close();
                writer.Close();
                return true;
        }
    }
}
