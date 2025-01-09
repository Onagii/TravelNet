namespace TravelNet;
public abstract class Verblijfstype
{
    public string NaamVerblijf { get; set; }
    public decimal BasisPrijsPerDag { get; set; }
    public bool ToeslagSingle { get; set; }
    public List<Formule> BeschikbareVerblijfsFormules { get; set; }
    public Verblijfstype(string naam, decimal prijs, bool single, List<Formule> formule)
    {
        this.NaamVerblijf = naam;
        this.BasisPrijsPerDag = prijs;
        this.ToeslagSingle = single;
        this.BeschikbareVerblijfsFormules = formule;
    }

    public virtual decimal BerekenPrijsPerDag()
    {
        decimal prijs = BasisPrijsPerDag;
        if (ToeslagSingle)
        {
            prijs += 5m;
        }

        return prijs;
    }
}
