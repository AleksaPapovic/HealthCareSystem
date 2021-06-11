using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Konverteri
{
    public class LekarKonverter : IKonverter<Lekar, LekarDTO>
    {
        public List<Lekar> KonvertujDTOSuEntitete(IEnumerable<LekarDTO> dtos)
            => dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();

        public Lekar KonvertujDTOuEntitet(LekarDTO dto)
            => new Lekar(dto.Ime, dto.Prezime, dto.Jmbg);

        public IEnumerable<LekarDTO> KonvertujEntiteteUDTOS(List<Lekar> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet)).ToList();

        public LekarDTO KonvertujEntitetUDTO(Lekar entitet)
        {
            if (entitet != null)
            {
                return new LekarDTO(entitet.Ime, entitet.Prezime, entitet.Jmbg);
            }
            else
            {
                return new LekarDTO();
            }
        }
    }
}
