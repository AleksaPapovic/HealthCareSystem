// File:    PregledStrategija.cs
// Author:  User
// Created: Wednesday, June 9, 2021 11:47:14 PM
// Purpose: Definition of Class PregledStrategija

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.Model;

public class PregledStrategija : ITerminStrategija
{
    public Termin ZakaziTermin(Termin noviTermin)
    {
        noviTermin.prostorija = TerminService.Instance.DobaviSlobodneProstorije(noviTermin).FirstOrDefault();
        noviTermin.Trajanje = 30;
        return noviTermin;
    }
}
