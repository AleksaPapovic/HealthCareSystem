using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Participanti;

namespace ZdravoKorporacija.ServiceZaKonverzije
{
   public  abstract class Mediator
    {
        public abstract NotifikacijaDTO Model2DTO(NotifikacijaDTO p1, ObavestenjaParticipant p2);
        public abstract Notifikacija DTO2Model(ObavestenjaParticipant p1);

    }
}
