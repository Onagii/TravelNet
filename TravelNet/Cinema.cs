using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties;
public class Cinema : IActiviteit
{
    public string Naam { get; set; }
    public decimal Inkom {  get; set; }
    public decimal Snoepgoed { get; set; }

    public Cinema() { }

    public decimal BerekenPrijs()
    {
        decimal prijs = Inkom + Snoepgoed;

        return prijs;
    }

    public override string ToString()
    {
        return $"Cinema - {Naam}";
    }
}
