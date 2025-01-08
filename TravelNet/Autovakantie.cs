using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet;
public class Autovakantie : Vakantie
{
    public List<Route> Routes { get; set; } = new List<Route>();
    public decimal Huurprijs { get; set; }
    public WagenType WagenType { get; set; }

    public Autovakantie(int boekingsNr, Bestemming bestemming, DateOnly vertrekDatum, DateOnly terugkeerDatum, List<IActiviteit> activiteiten, List<Route> routes, decimal huurprijs, WagenType wagenType)
        :base(boekingsNr, bestemming, vertrekDatum, terugkeerDatum, activiteiten)
    {
        this.Routes = routes;
        this.Huurprijs = huurprijs;
        this.WagenType = wagenType;
    }

    public override decimal BerekenVakantiePrijs()
    {
        decimal totaalActiviteitenPrijs = 0;
        decimal totaalPrijs = Routes.Sum(route => route.BerekenVerblijfsPrijsPerDag());

        if(WagenType != WagenType.EigenWagen)
        {
            totaalPrijs += Huurprijs;
        }

        foreach (var activiteit in Activiteiten)
        {
            decimal prijs = activiteit.BerekenPrijs();
            totaalActiviteitenPrijs += prijs;
        }

        totaalPrijs += totaalActiviteitenPrijs;

        return totaalPrijs;
    }

    public override string GegevensVakantie()
    {
        StringBuilder gegevens = new StringBuilder();

        decimal totaalPrijsRoutes = 0;
        decimal totaalActiviteitenPrijs = 0;

        gegevens.AppendLine($"{base.GegevensVakantie()}");
        gegevens.AppendLine($"  Routes:");

        foreach(var route in Routes)
        {
            gegevens.AppendLine(route.ToString());
            totaalPrijsRoutes += route.BerekenVerblijfsPrijsPerDag();
        }

        gegevens.AppendLine($"Totale verblijfprijs: {totaalPrijsRoutes}");
        gegevens.AppendLine($"Huurprijs: {Huurprijs}");

        foreach (var activiteit in Activiteiten)
        {
            totaalActiviteitenPrijs += activiteit.BerekenPrijs();
        }
        gegevens.AppendLine($"{GegevensActiviteiten()}");

        gegevens.AppendLine($"Totaal bedrag activiteiten: {totaalActiviteitenPrijs:f1} euro");
        gegevens.AppendLine($"\n");
        gegevens.AppendLine($"Totale vakantieprijs: {BerekenVakantiePrijs()}");

        return gegevens.ToString();
        
    }
}
