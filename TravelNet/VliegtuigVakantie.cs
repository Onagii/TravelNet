using System.Text;

namespace TravelNet.Vakanties;
public class VliegtuigVakantie : Vakantie
{
    public List<Route> Route { get; set; } = new List<Route>();
    public decimal VliegticketPrijs { get; set; }

    public VliegtuigVakantie(int boekingsNr, Bestemming bestemming, DateOnly vertrekDatum, DateOnly terugkeerDatum, List<IActiviteit> activiteiten, List<Route> routes, decimal vliegticketPrijs)
        : base(boekingsNr, bestemming, vertrekDatum, terugkeerDatum, activiteiten)
    {
        this.Route = routes;
        this.VliegticketPrijs = vliegticketPrijs;
    }

    public override decimal BerekenVakantiePrijs()
    {
        DateTime vertrekDatum = VertrekDatum.ToDateTime(TimeOnly.MinValue);
        DateTime terugkeerDatum = TerugkeerDatum.ToDateTime(TimeOnly.MinValue);
        int aantalDagen = (terugkeerDatum - vertrekDatum).Days;

        decimal totaalPrijsVerblijf = Route.Sum(route => route.BerekenVerblijfsPrijsPerDag() * aantalDagen);

        decimal totaalActiviteitenPrijs = 0;
        foreach (var activiteit in Activiteiten)
        {
            totaalActiviteitenPrijs += activiteit.BerekenPrijs();
        }

        
        decimal totaalPrijs = totaalPrijsVerblijf + VliegticketPrijs + totaalActiviteitenPrijs;

        return totaalPrijs;
    }

    public override string GegevensVakantie()
    {
        StringBuilder gegevens = new StringBuilder();

        decimal totaalPrijsRoutes = Route.Sum(route => route.BerekenVerblijfsPrijsPerDag());
        decimal totaalActiviteitenPrijs = Activiteiten.Sum(activiteit => activiteit.BerekenPrijs());

        gegevens.AppendLine($"{base.GegevensVakantie()}");
        gegevens.AppendLine($"  Routes:");

        Route.ForEach(route => gegevens.AppendLine(route.ToString()));

        gegevens.AppendLine($"Totale verblijfprijs: {totaalPrijsRoutes}");
        gegevens.AppendLine($"Vliegticketprijs: {VliegticketPrijs}");
        gegevens.AppendLine($"{GegevensActiviteiten()}");
        gegevens.AppendLine($"Totaal bedrag activiteiten: {totaalActiviteitenPrijs:f1} euro");
        gegevens.AppendLine($"\n");
        gegevens.AppendLine($"Totale vakantieprijs: {BerekenVakantiePrijs()}");

        return gegevens.ToString();

    }
}
