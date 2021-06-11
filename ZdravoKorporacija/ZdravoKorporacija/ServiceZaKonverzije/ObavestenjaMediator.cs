using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Participanti;

namespace ZdravoKorporacija.ServiceZaKonverzije
{
    public class ObavestenjaMediator : Mediator
    {

        public void postaviParticipanta(NotifikacijaDTO p1)
        {
            this._participant1 = p1;
            this._participant2 = new Notifikacija();
            p1.mediator = this;
            
        }
        public override NotifikacijaDTO Model2DTO(NotifikacijaDTO p1, ObavestenjaParticipant p2)
        {
            NotifikacijaDTO ret = null;
            if(p2 == _participant2)
            {
                p1.Datum = p2.Datum;
                p1.Tip = p2.Tip;
                p1.Sadrzaj = p2.Sadrzaj;
                p1.Status = p2.Status;
                p1.Id = p2.Id;

                ret = p1;
            }
            this._participant1 = p1;
            return ret;
        }

        public override Notifikacija DTO2Model(ObavestenjaParticipant p1)
        {
            Notifikacija ret = null;
            if (p1 == _participant1)
            {
                ret = new Notifikacija();

                ret.Sadrzaj = p1.Sadrzaj;
                ret.Tip = p1.Tip;
                ret.Datum = p1.Datum;
                ret.Id = p1.Id;
                ret.Status = p1.Status;

               
            }
            this._participant2 = ret;
            return ret;
        }

        public NotifikacijaDTO _participant1 { get; set; }
        public Notifikacija _participant2 { get; set; }
    }
}
