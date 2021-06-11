using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Konverteri
{
    public class PacijentKonverter : IKonverter<Pacijent, PacijentDTO>
    {

        public PacijentKonverter()
        {
        }

        public List<Pacijent> KonvertujDTOSuEntitete(IEnumerable<PacijentDTO> dtos)
            => dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();

        public Pacijent KonvertujDTOuEntitet(PacijentDTO dto)
        {
            ZdravstveniKartonKonverter zdravstveniKartonKonverter = new ZdravstveniKartonKonverter();
            if (dto != null)
                return new Pacijent(dto.korisnickoIme, dto.lozinka,
                    zdravstveniKartonKonverter.KonvertujDTOuEntitet(dto.ZdravstveniKarton), dto.Jmbg);
            else return new Pacijent();
        }

        public IEnumerable<PacijentDTO> KonvertujEntiteteUDTOS(List<Pacijent> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet)).ToList();

        public PacijentDTO KonvertujEntitetUDTO(Pacijent entitet)
        {
            ZdravstveniKartonKonverter zdravstveniKartonKonverter = new ZdravstveniKartonKonverter();
            NotifikacijaKonverter notifikacijaKonverter = new NotifikacijaKonverter();
            if (entitet != null)
            {
                PacijentDTO pdto = new PacijentDTO(entitet.Ime, entitet.Prezime, entitet.Username, entitet.Password,
                    zdravstveniKartonKonverter.KonvertujEntitetUDTO(entitet.ZdravstveniKarton), entitet.Jmbg);
                if(entitet.notifikacije != null)
                {
                    foreach (Notifikacija n in entitet.notifikacije)
                    {
                        pdto.notifikacije.Add(notifikacijaKonverter.KonvertujEntitetUDTO(n));
                    }
                }

                return pdto;
            }
            else
            {
                return null;
            }
        }

    }
}
