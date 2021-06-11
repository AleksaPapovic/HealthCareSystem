using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.ServiceZaKonverzije;

namespace ZdravoKorporacija.Participanti
{
    public abstract class ObavestenjaParticipant
    {
        public ObavestenjaParticipant() { }
        public ObavestenjaParticipant(Mediator mediator,int id, DateTime datum, TipNotifikacije tip, string sadrzaj, string status)
        {
            Id = id;
            Datum = datum;
            Tip = tip;
            Sadrzaj = sadrzaj;
            Status = status;
            this.mediator = mediator;
        }
        public Notifikacija DTO2Model()
        {
            return mediator.DTO2Model(this);
        }
        public NotifikacijaDTO Model2DTO()
        {
            return mediator.Model2DTO(null, this);
        }
        public Mediator mediator { get; set; }
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public TipNotifikacije Tip { get; set; }
        public String Sadrzaj { get; set; }
        public String Status { get; set; }
       

    }
}
