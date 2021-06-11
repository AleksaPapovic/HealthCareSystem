// File:    TerminServis.cs
// Author:  User
// Created: Wednesday, June 9, 2021 11:47:17 PM
// Purpose: Definition of Class TerminKontekst

using Model;
using System;

public class TerminKontekst
{
    private ITerminStrategija strategija;
    public TerminKontekst(ITerminStrategija strategija)
    {
        this.strategija = strategija;
    }

    public Termin zakaziTermin(Termin termin)
    {
       return strategija.ZakaziTermin(termin); 
    }
}
