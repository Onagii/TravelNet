using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet;
public class Stadsbezoek : IActiviteit
{
    public string Naam {  get; set; }
    public decimal PrijsGidsPer10Personen { get; set; }
    public int AantalPersonen { get; set; }

    public Stadsbezoek() { }

    public decimal BerekenPrijs()
    {
        int aantalGidsen = (int)Math.Ceiling((decimal)AantalPersonen / 10);

        decimal prijs = aantalGidsen * PrijsGidsPer10Personen;

        return prijs;
    }

    public override string ToString()
    {
        return $"Stadsbezoek - {Naam}";
    }

}
