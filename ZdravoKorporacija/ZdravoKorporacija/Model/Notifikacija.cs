/***********************************************************************
 * Module:  Notifikacija.cs
 * Author:  User
 * Purpose: Definition of the Class Notifikacija
 ***********************************************************************/

using System;
using System.Collections;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Participanti;
using ZdravoKorporacija.ServiceZaKonverzije;

namespace Model
{ 
    public class Notifikacija : ObavestenjaParticipant
    {
    
        public Notifikacija() : base() { }
      

        public Notifikacija(Mediator mediator, int id, DateTime datum, TipNotifikacije tip, string sadrzaj, string status) : base(mediator, id, datum, tip, sadrzaj, status)
        {

        }
    

    }
}