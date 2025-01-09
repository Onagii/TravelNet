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

    public Vakantie(int boekingsNr, Bestemming bestemming, DateOnly vertrekDatum, DateOnly terugkeerDatum, List<IActiviteit>? activiteiten = null)
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

        var activiteitenDetails = Activiteiten
            .Select(activiteit => $"{activiteit}\t({activiteit.BerekenPrijs():f2} euro)")
            .ToList();

        return string.Join(Environment.NewLine, activiteitenDetails);
    }

    public virtual string GegevensVakantie()
    {
        return $"Boekingsnr: {BoekingsNr}   Bestemming: {Bestemming}   Vertrekdatum : {VertrekDatum}    Terugkeerdatum: {TerugkeerDatum}";
    }

}
