using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven;
public class Vakantiehuis : Verblijfstype
{
    public decimal SchoonmaakPrijsPerDag {  get; set; }
    public decimal LinnengoedprijsPerDag { get; set; }
    public Vakantiehuis(string naam, decimal prijs, bool single, decimal schoonmaakPrijs, decimal linnengoedprijs)
        : base(naam, prijs, single, new List<Formule> { Formule.Ontbijt})
    {
        this.SchoonmaakPrijsPerDag = schoonmaakPrijs;
        this.LinnengoedprijsPerDag = linnengoedprijs;

    }

    public override decimal BerekenPrijsPerDag()
    {
        decimal prijs = base.BerekenPrijsPerDag();

        prijs += SchoonmaakPrijsPerDag;
        prijs += LinnengoedprijsPerDag;

        return prijs;
    }
}

