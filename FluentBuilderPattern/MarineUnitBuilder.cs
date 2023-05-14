namespace FluentBuilderPattern;

public class MarineUnitBuilder : 
    INameSetter, 
    IIntendedUseSetter, 
    IDimensionsSetter, 
    IMechanicalInstallationSetter, 
    IVersatileInstallationSetter, 
    IElectricalInstallationSetter,
    IBrandAndModelSetter,
    IMarineBuilder
{
    private readonly MarineUnit _unit = new ();

    private readonly List<ElectricalInstallation> _electricalInstallations = new();

    public static INameSetter Initialize() => 
        new MarineUnitBuilder();

    public IIntendedUseSetter WithName(string name)
    {
        //checks
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Name cannot be empty");

        _unit.UnitName = name;

        return this;
    }

    public IDimensionsSetter WithUnitIntendedUse(UnitIntendedUse unitIntendedUse)
    {
        //check ....

        _unit.UnitIntendedUse = unitIntendedUse;
        return this;
    }

    public IMechanicalInstallationSetter WithDimensions(Dimensions dimensions)
    {
        //check

        _unit.Dimensions = dimensions;
        return this;
    }

    public IVersatileInstallationSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation)
    {
        //check

        _unit.MechanicalInstallation = mechanicalInstallation;

        return this;
    }

    public IElectricalInstallationSetter WithVersatileInstallation(VersatileInstallation versatileInstallation)
    {
        //check

        _unit.VersatileInstallation = versatileInstallation;

        return this;
    }

    public IElectricalInstallationSetter WithElectricalInstallation(ElectricalInstallation electricalInstallation)
    {
        //check...

        _electricalInstallations.Add(electricalInstallation);
        return this;
    }

    public IBrandAndModelSetter WithNoMoreElectricalInstallation()
    {
        _unit.ElectricalInstallation = _electricalInstallations.ToArray();

        return this;
    }

    public IMarineBuilder WithBrandAndModel(string brand, string model)
    {
        //checks...

        _unit.Brand = brand;
        _unit.Model = model;

        return this;
    }

    public MarineUnit Build() => _unit;
}

public interface IMarineBuilder
{
    MarineUnit Build();
}

public interface IBrandAndModelSetter
{
    IMarineBuilder WithBrandAndModel(string brand, string model);
}

public interface IElectricalInstallationSetter
{
    IElectricalInstallationSetter WithElectricalInstallation(ElectricalInstallation electricalInstallation);
    IBrandAndModelSetter WithNoMoreElectricalInstallation();
}

public interface IVersatileInstallationSetter
{
    IElectricalInstallationSetter WithVersatileInstallation(VersatileInstallation versatileInstallation);
}

public interface IMechanicalInstallationSetter
{
    IVersatileInstallationSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation);
}

public interface IDimensionsSetter
{
    IMechanicalInstallationSetter WithDimensions(Dimensions dimensions);
}

public interface IIntendedUseSetter
{
    IDimensionsSetter WithUnitIntendedUse(UnitIntendedUse unitIntendedUse);
}

public interface INameSetter
{
    IIntendedUseSetter WithName(string name);
}