using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Konverteri
{
    public class TerminKonverter : IKonverter<Termin, TerminDTO>
    {

        public TerminKonverter()
        {
        }

        public List<Termin> KonvertujDTOSuEntitete(IEnumerable<TerminDTO> dtos)
            => dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();

        public Termin KonvertujDTOuEntitet(TerminDTO dto)
        {
            LekarKonverter lekarKonverter = new LekarKonverter();
            IzvestajKonverter izvestajKonverter = new IzvestajKonverter();
            ZdravstveniKartonKonverter zdravstveniKartonKonverter = new ZdravstveniKartonKonverter();

            if (dto != null)
                return new Termin(dto.Id, lekarKonverter.KonvertujDTOuEntitet(dto.Lekar), dto.Tip, dto.Pocetak,
                    dto.Trajanje, zdravstveniKartonKonverter.KonvertujDTOuEntitet(dto.zdravstveniKarton), izvestajKonverter.KonvertujDTOuEntitet(dto.izvestaj));
            else return null;
        }

        public IEnumerable<TerminDTO> KonvertujEntiteteUDTOS(List<Termin> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet)).ToList();

        public TerminDTO KonvertujEntitetUDTO(Termin entitet)
        {
            ProstorijaKonverter prostorijaKonverter = new ProstorijaKonverter();
            ZdravstveniKartonKonverter zdravstveniKartonKonverter = new ZdravstveniKartonKonverter();
            LekarKonverter lekarKonverter = new LekarKonverter();
            IzvestajKonverter izvestajKonverter = new IzvestajKonverter();
            if (entitet != null)
                return new TerminDTO(entitet.Id, entitet.Tip, entitet.Pocetak, entitet.Trajanje,
                    prostorijaKonverter.KonvertujEntitetUDTO(entitet.prostorija),
                    lekarKonverter.KonvertujEntitetUDTO(entitet.Lekar),
                    zdravstveniKartonKonverter.KonvertujEntitetUDTO(entitet.zdravstveniKarton), izvestajKonverter.KonvertujEntitetUDTO(entitet.izvestaj));
            else return null;

        }


    }
}
