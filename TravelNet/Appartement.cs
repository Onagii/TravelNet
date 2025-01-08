﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet;
public class Appartement : Verblijfstype
{
    public decimal SchoonmaakPrijsPerDag {  get; set; }
    public bool Lift {  get; set; }

    public Appartement(string naam, decimal prijs, bool single, decimal schoonmaakPrijs, bool lift)
        :base(naam, prijs, single, new List<Formule> { Formule.Ontbijt, Formule.HalfPension})
    {
        this.SchoonmaakPrijsPerDag = schoonmaakPrijs;
        this.Lift = lift;

    }
    public override decimal BerekenPrijsPerDag()
    {
        decimal prijs = base.BerekenPrijsPerDag();
        prijs += SchoonmaakPrijsPerDag;

        decimal formuleKosten  = BeschikbareVerblijfsFormules.Sum(f => (decimal)f);
        prijs += formuleKosten;

        return prijs;
    }

}

