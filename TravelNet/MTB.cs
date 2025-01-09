using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties;
public class MTB : IActiviteit
{
    public string Naam { get; set; }
    public  decimal HuurprijsFietsPerUur {  get; set; }
    public decimal PrijsUitrusting {  get; set; }
    public int AantalUren {  get; set; }

    public MTB() { }

    public decimal BerekenPrijs()
    {
        decimal prijs = PrijsUitrusting + HuurprijsFietsPerUur * AantalUren;

        return prijs;
    }

    public override string ToString()
    {
        return $"Mountainbike - {Naam}";
    }
}
