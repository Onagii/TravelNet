using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet;
public abstract class Vakantie
{
    public int BoekingsNr { get; set; }
    public Bestemming Bestemming { get; set; }
    public DateOnly VertrekDatum { get; set; }
    public DateOnly TerugkeerDatum { get; set; }
    public List<IActiviteit> Activiteiten {  get; set; } = new List<IActiviteit>();

    public Vakantie(int boekingsNr, Bestemming bestemming, DateOnly vertrekDatum, DateOnly terugkeerDatum, List<IActiviteit> activiteiten)
    {
        this.BoekingsNr = boekingsNr;
        this.Bestemming = bestemming;
        this.VertrekDatum = vertrekDatum;
        this.Activiteiten = activiteiten;

        if(terugkeerDatum <= vertrekDatum)
        {
            throw new TerugkeerdatumException($"Reis met boekingsnr {BoekingsNr}: terugkeerdatum ({terugkeerDatum.ToString("dd-MM-yyyy")}) " +
                $"moet later zijn dan vertrekdatum ({vertrekDatum.ToString("dd-MM-yyyy")})!");
        }
        this.TerugkeerDatum = terugkeerDatum;
    }

    public abstract decimal BerekenVakantiePrijs();

    public string GegevensActiviteiten()
    {
        decimal totaalActiviteitenPrijs = 0;
        StringBuilder activiteitenDetails = new StringBuilder();

        foreach(var activiteit in Activiteiten)
        {
            decimal prijs = activiteit.BerekenPrijs();
            activiteitenDetails.AppendLine($"{activiteit}");
            totaalActiviteitenPrijs += prijs;
        }

        activiteitenDetails.AppendLine($"Totaal bedrag activiteiten: {totaalActiviteitenPrijs:f1} euro");

        return activiteitenDetails.ToString();
    }

    public virtual string GegevensVakantie()
    {
        return $"Boekingsnr: {BoekingsNr}   Bestemming: {Bestemming}   Vertrekdatum :{VertrekDatum}    Terugkeerdatum: {TerugkeerDatum}";
    }

}
