using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven;
public class Hotel : Verblijfstype
{
    public bool Internet {  get; set; }
    public decimal WellnessPrijsPerDag { get; set; }
    public string Wellness { get; set; } = null!;

    public Hotel(string naam, decimal prijs, bool single, bool internet, decimal? wellnessPrijs = null)
        :base(naam, prijs, single, new List<Formule> { Formule.Ontbijt, Formule.HalfPension, Formule.VolPension})
    {
        this.Internet = internet;

        if (wellnessPrijs == null )
        {
            Wellness = "Wellness is niet inbegrepen";
            WellnessPrijsPerDag = 0;
        }
        else if (wellnessPrijs == 0 )
        {
            Wellness = "Wellness is inbegrepen in de prijs";
            WellnessPrijsPerDag = 0;
        }
        else
        {
            this.WellnessPrijsPerDag = wellnessPrijs.Value;
        }
    }

    public override decimal BerekenPrijsPerDag()
    {
        decimal prijs = base.BerekenPrijsPerDag();
        prijs += WellnessPrijsPerDag;

        return prijs;
    }

}
