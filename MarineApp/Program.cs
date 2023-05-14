using FluentBuilderPattern;

var unit = MarineUnitBuilder
    .Initialize()
    .WithName("Marina")
    .WithUnitIntendedUse(new UnitIntendedUse(TypeOfUse.MarineCommercial, "Fishing", "Shark hunting"))
    .WithDimensions(new Dimensions(100, 100, 100))
    .WithMechanicalInstallation(new MechanicalInstallation())
    .WithVersatileInstallation(new VersatileInstallation())
    .WithElectricalInstallation(new ElectricalInstallation())
    .WithElectricalInstallation(new ElectricalInstallation())
    .WithNoMoreElectricalInstallation()
    .WithBrandAndModel("Volvo", "Penta")
    .Build();

Console.WriteLine(unit.UnitIntendedUse.TypeOfUse);