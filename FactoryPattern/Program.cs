namespace FactoryPattern;

public class AnimalFactory
{
    public Animal Create<T>() where T : Animal, new() => new T();

    //Nie łamie reguły OCP
    //public Animal Create(string type)
    //{
    //    var actualType = Type.GetType($"FactoryPattern.{type}");

    //    return (Animal)Activator.CreateInstance(actualType!);
    //}

    //to naiwne podejście łamie regułę OCP
    //public Animal Create(string type) =>
    //    type switch
    //    {
    //        "Dog" => new Dog(),
    //        "Cat" => new Cat(),
    //        "Horse" => new Horse(),
    //        _ => throw new ArgumentOutOfRangeException()
    //    };
}

public abstract class Animal
{
    public abstract string MakeNoise();
}

public class Cat : Animal
{
    public override string MakeNoise() => "Miał";
}

public class Dog : Animal
{
    public override string MakeNoise() => "Hał";
}

public class Horse : Animal
{
    public override string MakeNoise() => "Patataj";
}

public class Monkey : Animal
{
    public override string MakeNoise() => "Uu aa";
}