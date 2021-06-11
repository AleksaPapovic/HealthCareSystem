using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Konverteri
{
    public class ProstorijaKonverter : IKonverter<Prostorija, ProstorijaDTO>
    {
        public List<Prostorija> KonvertujDTOSuEntitete(IEnumerable<ProstorijaDTO> dtos)
            => dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();

        public Prostorija KonvertujDTOuEntitet(ProstorijaDTO dto)
            => new Prostorija(dto.Id, dto.Naziv, dto.Tip, dto.Slobodna, dto.Sprat);

        public IEnumerable<ProstorijaDTO> KonvertujEntiteteUDTOS(List<Prostorija> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet)).ToList();

        public ProstorijaDTO KonvertujEntitetUDTO(Prostorija entitet)
        {
            if (entitet != null)
            {
                return new ProstorijaDTO(entitet.Id, entitet.Naziv, entitet.Tip, entitet.Slobodna, entitet.Sprat);
            }
            else
            {
                return new ProstorijaDTO();
            }
        }

        List<Prostorija> IKonverter<Prostorija, ProstorijaDTO>.KonvertujDTOSuEntitete(IEnumerable<ProstorijaDTO> dtos)
        {
            throw new NotImplementedException();
        }

        Prostorija IKonverter<Prostorija, ProstorijaDTO>.KonvertujDTOuEntitet(ProstorijaDTO dto)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ProstorijaDTO> IKonverter<Prostorija, ProstorijaDTO>.KonvertujEntiteteUDTOS(List<Prostorija> entiteti)
        {
            throw new NotImplementedException();
        }

        ProstorijaDTO IKonverter<Prostorija, ProstorijaDTO>.KonvertujEntitetUDTO(Prostorija entitet)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 *
 * try
                {
                    return new ProstorijaDTO(entitet.Id, entitet.Naziv, entitet.Tip, entitet.Slobodna, entitet.Sprat);
                }
                catch (System.NullReferenceException)
                {
                    return new ProstorijaDTO();
                }
 */