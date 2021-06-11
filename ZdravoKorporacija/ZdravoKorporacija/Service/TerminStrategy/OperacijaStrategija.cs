// File:    OperacijaStrategija.cs
// Author:  User
// Created: Wednesday, June 9, 2021 11:47:14 PM
// Purpose: Definition of Class OperacijaStrategija

using Model;
using System;

public class OperacijaStrategija : ITerminStrategija
{
    public Termin ZakaziTermin(Termin noviTermin)
    {
        noviTermin.Trajanje = 120;
        return noviTermin;
    }
}