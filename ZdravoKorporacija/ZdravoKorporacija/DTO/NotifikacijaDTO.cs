using System;
using Model;
using ZdravoKorporacija.Participanti;
using ZdravoKorporacija.ServiceZaKonverzije;

namespace ZdravoKorporacija.DTO
{
    public class NotifikacijaDTO : ObavestenjaParticipant
    {
        public NotifikacijaDTO( ) : base() { }

        public NotifikacijaDTO(Mediator mediator, int id, DateTime datum, TipNotifikacije tip, string sadrzaj, string status) : base( mediator,  id,  datum,  tip,  sadrzaj,  status)
        {
         
        }
   

    }
}
