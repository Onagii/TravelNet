using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties;
public class Cruise : Vakantie
{
    public string Vertekpunt {  get; set; }
    public string EindPunt { get; set; }
    public List<string> Aanlegplaatsen { get; set; } = new List<string>();
    public decimal Allinprijs { get; set; }

    public Cruise (int boekingsNr, Bestemming bestemming, DateOnly vertrekDatum, DateOnly terugkeerDatum, List<IActiviteit> activiteiten, string vertrekpunt, string eindpunt, List<string> aanlegplaatsen, decimal allInPrijs)
        :base(boekingsNr, bestemming, vertrekDatum, terugkeerDatum, activiteiten)
    {
        this.Vertekpunt = vertrekpunt;
        this.EindPunt = eindpunt;
        this.Aanlegplaatsen = aanlegplaatsen;
        this.Allinprijs = allInPrijs;
    }

    public override decimal BerekenVakantiePrijs()
    {
        return Allinprijs;
    }

    public override string GegevensVakantie()
    {
        string aanlegplaatsenVerbinden = string.Join(" - ", Aanlegplaatsen);
        return $"{base.GegevensVakantie()}\n" +
               $"Aanlegplaatsen: {aanlegplaatsenVerbinden}\n\n" +
               $"Totale vakantieprijs {BerekenVakantiePrijs():f1}";

    }
}
