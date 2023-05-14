namespace FluentBuilderPattern;
public class MarineUnit
{
    internal MarineUnit() { }

    public string UnitName { get; internal set; }

    public UnitIntendedUse UnitIntendedUse { get; internal set; }

    public Dimensions Dimensions { get; internal set; }

    public MechanicalInstallation MechanicalInstallation { get; internal set; }

    public VersatileInstallation VersatileInstallation { get; internal set; }

    public ElectricalInstallation[] ElectricalInstallation { get; internal set; }

    public string Brand { get; internal set; }

    public string Model { get; internal set; }

    //Other methods...
}

public class UnitIntendedUse
{
    public UnitIntendedUse(TypeOfUse typeOfUse, string lineOfBusiness, string unitPurpose)
    {
        TypeOfUse = typeOfUse;
        LineOfBusiness = lineOfBusiness;
        UnitPurpose = unitPurpose;
    }

    public TypeOfUse TypeOfUse { get; internal set; }
    public string LineOfBusiness { get; internal set; }
    public string UnitPurpose { get; internal set; }
}

public enum TypeOfUse
{
    MarineCommercial,
    MarineLeisure
}

public struct Dimensions
{
    public Dimensions(int length, int width, int weight)
    {
        Length = length;
        Width = width;
        Weight = weight;
    }
    public int Length { get; internal set; }
    public int Width { get; internal set; }
    public int Weight { get; internal set; }
}

public class MechanicalInstallation : Installation { }

public class ElectricalInstallation : Installation { }

public class VersatileInstallation : Installation { }

public abstract class Installation
{
    public IList<Driveline> Drivelines { get; internal set; }
}

public class Driveline
{
    public Engine Engine { get; set; }
}

public class Engine { }