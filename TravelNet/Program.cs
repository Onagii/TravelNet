using TravelNet;
using TravelNet.Verblijven;
using TravelNet.Vakanties;
try
{
    Hotel albergoNero = new("Albergo Nero", 120m, true, true, 0m);
    Hotel capella = new("Capella", 150m, false, false, null);
    Hotel hotelletFrokost = new("Hotellet Frokost", 200m, true, true, 75m);
    Hotel meniBeach = new("MeniBeach", 100m, true, true, 50m);

    Appartement casaBlanca = new("Casa Blanca", 150m, false, 20m, true);
    Appartement parcoVista = new("Parco Vista", 100m, false, 15m, true);
    Appartement hviteHus = new("Hvite Hus", 125m, false, 15m, false);
    Appartement husetSvart = new("Huset Svart", 200m, true, 20m, false);

    Vakantiehuis fioriTorre = new("Fiore Torre", 150m, false, 15m, 5m);
    Vakantiehuis gronnpark = new("Gronnpark", 120m, false, 10m, 10m);
    Vakantiehuis blomsterTarnet = new("Blomster Tarnet", 100m, false, 10m, 10m);
    Vakantiehuis visning = new("Visning", 200m, false, 20m, 10m);

    Route routeLucca = new("Lucca", "Prato", casaBlanca, Formule.Ontbijt);
    Route routePrato = new("Prato", "Bologna", albergoNero, Formule.Ontbijt);
    Route routeBologna = new("Bologna", "Arezzo", parcoVista, Formule.HalfPension);
    Route routeArezzo = new("Arezzo", "Livorno", fioriTorre, Formule.Ontbijt);
    Route routeLivorno = new("Livorno", "Firenze", capella, Formule.Ontbijt);
    Route routeStavanger = new("Stavanger", "Egersund", hviteHus, Formule.Ontbijt);
    Route routeEgersund = new("Eggersund", "Kragera", husetSvart, Formule.Ontbijt);
    Route routeKragera = new("Kragera", "Porsgrunn", gronnpark, Formule.Ontbijt);
    Route routePorsGrunn = new("Porsgrunn", "Drammen", blomsterTarnet, Formule.Ontbijt);
    Route routeDrammen = new("Drammen", "Oslo", visning, Formule.Ontbijt);
    Route routeOslo = new("Oslo", "Moss", hotelletFrokost, Formule.Ontbijt);
    Route routeAthene = new("Athene", "Kos", meniBeach, Formule.VolPension);


    MTB volwassenenFiets = new MTB
    {
        Naam = "Volwassenenfiets",
        PrijsUitrusting = 20m,
        HuurprijsFietsPerUur = 10m,
        AantalUren = 4
    };

    MTB kinderfiets = new MTB
    {
        Naam = "Kinderfiets",
        PrijsUitrusting = 15m,
        HuurprijsFietsPerUur = 7.5m,
        AantalUren = 3
    };

    Cinema volwassenenCinema = new Cinema
    {
        Naam = "Volwassenencinema",
        Inkom = 7.5m,
        Snoepgoed = 5m
    };

    Cinema kinderCinema = new Cinema
    {
        Naam = "Kindercinema",
        Inkom = 5m,
        Snoepgoed = 5.25m
    };

    Stadsbezoek stadsbezoekAthene = new Stadsbezoek
    {
        Naam = "Athene",
        PrijsGidsPer10Personen = 150m,
        AantalPersonen = 15
    };

    Stadsbezoek stadsbezoekRome = new Stadsbezoek
    {
        Naam = "Rome",
        PrijsGidsPer10Personen = 125m,
        AantalPersonen = 12
    };

    Stadsbezoek stadsbezoekOslo = new Stadsbezoek
    {
        Naam = "Oslo",
        PrijsGidsPer10Personen = 175m,
        AantalPersonen = 7
    };

    List<Vakantie> autoVakanties = new List<Vakantie>()
    {
        new Autovakantie(2, Bestemming.Italie, new DateOnly(2022, 5, 14), new DateOnly(2022, 5, 19), new List<IActiviteit> { stadsbezoekRome, volwassenenCinema, volwassenenCinema, kinderCinema },
                            new List<Route> { routeLucca, routePrato, routeBologna, routeArezzo, routeLivorno }, 500m, WagenType.Camper),

        new Autovakantie(3, Bestemming.Noorwegen, new DateOnly(2022, 8, 8), new DateOnly (2022, 8, 14), new List<IActiviteit>{stadsbezoekOslo, volwassenenFiets, kinderfiets, kinderfiets}, 
                            new List<Route> {routeStavanger, routeEgersund, routeKragera, routePorsGrunn, routeDrammen, routeOslo}, 600m, WagenType.Camper),
    };

    List<Vakantie> vliegVakanties = new List<Vakantie>()
    {
        new VliegtuigVakantie(3, Bestemming.Griekenland, new DateOnly(2022, 9, 1), new DateOnly(2022, 9, 15), new List<IActiviteit> { stadsbezoekAthene, volwassenenFiets, volwassenenFiets, kinderfiets, kinderfiets },
                            new List<Route> { routeAthene }, 800m)
    };

    List<Vakantie> cruiseVakanties = new List<Vakantie>()
    {
        new Cruise(1, Bestemming.Finland, new DateOnly(2022, 8, 12), new DateOnly(2022, 8, 20), null, "Helsinki", "Helsinki", new List<string>{"Turku", "Rauma", "Vaasa", "Oulu"}, 6800m),

    };

    Console.WriteLine("Autovakanties");
    Console.WriteLine("=============================================================");
    foreach (var vakantie in autoVakanties)
    {
        Console.WriteLine(vakantie.GegevensVakantie());
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine();
    }

    Console.WriteLine("Vliegvakanties");
    Console.WriteLine("=============================================================");
    foreach (var vakantie in vliegVakanties)
    {
        Console.WriteLine(vakantie.GegevensVakantie());
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine();
    }

    Console.WriteLine("Cruises");
    Console.WriteLine("=============================================================");
    foreach (var vakantie in cruiseVakanties)
    {
        Console.WriteLine(vakantie.GegevensVakantie());
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine();
    }





}
catch (VerblijfsformuleException ex)
{
    Console.WriteLine($"Fout {ex.Message}");
}
catch (TerugkeerdatumException ex)
{
    Console.WriteLine($"Fout {ex.Message}");
}

