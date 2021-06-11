using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.ServiceZaKonverzije;

namespace ZdravoKorporacija.Konverteri
{
    public class NotifikacijaKonverter : IKonverter<Notifikacija, NotifikacijaDTO>
    {
        private Mediator mediator;
        public NotifikacijaKonverter() {}

        public List<Notifikacija> KonvertujDTOSuEntitete(IEnumerable<NotifikacijaDTO> dtos)
            => dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();

        public Notifikacija KonvertujDTOuEntitet(NotifikacijaDTO dto)
        {
            if (dto != null)
                return new Notifikacija(mediator, dto.Id, dto.Datum, dto.Tip, dto.Sadrzaj, dto.Status);
            else return new Notifikacija();
        }

        public IEnumerable<NotifikacijaDTO> KonvertujEntiteteUDTOS(List<Notifikacija> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet));

        public NotifikacijaDTO KonvertujEntitetUDTO(Notifikacija entitet)
        {
            if (entitet != null)
            {
                return new NotifikacijaDTO(mediator,entitet.Id, entitet.Datum, entitet.Tip, entitet.Sadrzaj, entitet.Status);

            }
            else
            {
                return null;
            }
        }
    }
}
