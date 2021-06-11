using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Konverteri
{
    public class BeleskaKonverter : IKonverter<Beleska, BeleskaDTO>
    {
        public List<Beleska> KonvertujDTOSuEntitete(IEnumerable<BeleskaDTO> dtos)
            => dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();

        public Beleska KonvertujDTOuEntitet(BeleskaDTO dto)
            => new Beleska(dto.Id, dto.Sadrzaj, dto.Datum);

        public IEnumerable<BeleskaDTO> KonvertujEntiteteUDTOS(List<Beleska> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet)).ToList();

        public BeleskaDTO KonvertujEntitetUDTO(Beleska entitet)
        {
            if (entitet != null)
            {
                return new BeleskaDTO(entitet.Id, entitet.Sadrzaj, entitet.Datum);
            }
            else
            {
                return new BeleskaDTO();
            }
        }
    }
}
