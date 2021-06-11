using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Konverteri
{
    public class AnketaKonverter : IKonverter<Anketa, AnketaDTO>
    {

        public AnketaKonverter() { }

        public List<Anketa> KonvertujDTOSuEntitete(IEnumerable<AnketaDTO> dtos)
            => dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();

        public Anketa KonvertujDTOuEntitet(AnketaDTO dto)
        {
            TerminKonverter terminKonverter = new TerminKonverter();
            if (dto != null)
                return new Anketa(dto.Id, dto.IdAutora, dto.Datum, dto.Tip, dto.Ocena, dto.Komentar, terminKonverter.KonvertujDTOuEntitet(dto.Termin));
            else return new Anketa();
        }
        //public Anketa(int id, long idAutora, DateTime datum, TipAnkete tip, int ocena, string komentar, Termin termin)

        public IEnumerable<AnketaDTO> KonvertujEntiteteUDTOS(List<Anketa> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet));

        public AnketaDTO KonvertujEntitetUDTO(Anketa entitet)
        {
            TerminKonverter terminKonverter = new TerminKonverter();

            if (entitet != null)
            {
                return new AnketaDTO(entitet.Id, entitet.IdAutora, entitet.Datum, entitet.Tip,
                    entitet.Ocena, entitet.Komentar, terminKonverter.KonvertujEntitetUDTO(entitet.Termin));
            }
            else
            {
                return null;
            }
        }
    }
}
