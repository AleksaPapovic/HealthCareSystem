using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Konverteri
{
    public class IzvestajKonverter : IKonverter<Izvestaj, IzvestajDTO>
    {
        public List<Izvestaj> KonvertujDTOSuEntitete(IEnumerable<IzvestajDTO> dtos)
            => dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();

        public Izvestaj KonvertujDTOuEntitet(IzvestajDTO dto)
        {
            TerminKonverter terminKonverter = new TerminKonverter();
            if (dto != null)
                return new Izvestaj(terminKonverter.KonvertujDTOuEntitet(dto.Termin), dto.Id, dto.Opis, dto.Simptomi);
            else return new Izvestaj();
        }

        public IEnumerable<IzvestajDTO> KonvertujEntiteteUDTOS(List<Izvestaj> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet)).ToList();

        public IzvestajDTO KonvertujEntitetUDTO(Izvestaj entitet)
        {
            TerminKonverter terminKonverter = new TerminKonverter();
            if (entitet != null)
            {
                return new IzvestajDTO(entitet.Id, entitet.Opis, entitet.Simptomi, terminKonverter.KonvertujEntitetUDTO(entitet.termin));
            }
            else
            {
                return new IzvestajDTO();
            }
        }


    }
}