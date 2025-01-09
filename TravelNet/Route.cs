using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet;
public class Route
{
    public string Vertrekpunt { get; set; }
    public string Eindpunt { get; set; }
    public Verblijfstype GekozenVerblijfstype { get; set; }
    public Formule GekozenFormule { get; set; }

    public Route(string vertrekpunt, string eindpunt, Verblijfstype gekozenVerblijfstype, Formule formule)
    {
        this.Vertrekpunt = vertrekpunt;
        this.Eindpunt = eindpunt;
        this.GekozenVerblijfstype = gekozenVerblijfstype;
        
        if (!GekozenVerblijfstype.BeschikbareVerblijfsFormules.Contains(formule))
        {
            throw new VerblijfsformuleException($"De formule {formule} is niet beschikbaar voor dit verblijfstype, kies één van de beschikbare formules.");
        }
        this.GekozenFormule = formule;
    }

    public decimal BerekenVerblijfsPrijsPerDag()
    {
        

        decimal prijsPerDag = GekozenVerblijfstype.BerekenPrijsPerDag();

        decimal formuleKosten = (decimal)GekozenFormule;

        prijsPerDag += formuleKosten;

        return prijsPerDag;
    }

    public override string ToString()
    {
        return $"{Vertrekpunt}\t {Eindpunt}\t {GekozenFormule}\t {GekozenVerblijfstype.NaamVerblijf}\t {BerekenVerblijfsPrijsPerDag()}\n";
    }
}
