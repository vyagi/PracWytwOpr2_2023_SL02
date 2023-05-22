namespace FactoryPattern;

public class AnimalFactory
{
    //perfect generic factory 
    public Animal Create<T>() where T : Animal, new() => new T();

    //reflection approach
    //public Animal Create(string type)
    //{
    //    var actualType = Type.GetType($"FactoryPattern.{type}");

    //    return (Animal)Activator.CreateInstance(actualType);
    //}


    //Do not use this naive approach - it violates OCP 

    //public Animal Create(string type) => //very naive !
    //    type.ToUpperInvariant() switch
    //    {
    //        "DOG" => new Dog(),
    //        "CAT" => new Cat(),
    //        "FISH" => new Fish(),
    //        _ => throw  new ArgumentOutOfRangeException(nameof(type), "Not recognized Animal type")
    //    };
}

public abstract class Animal
{
    public abstract string MakeNoise();
}

public class Cat : Animal
{
    public override string MakeNoise() => "Miau, miau";
}

public class Dog : Animal
{
    public override string MakeNoise() => "Hau, hau";
}

public class Fish : Animal
{
    public override string MakeNoise() => string.Empty;
}

public class Monkey : Animal
{
    public override string MakeNoise() => "Uuu, aaa";
}

public class Horse : Animal
{
    public override string MakeNoise() => "Ihaa, ihaa";
}