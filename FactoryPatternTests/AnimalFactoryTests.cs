using FactoryPattern;
using FluentAssertions;

namespace FactoryPatternTests;

public class AnimalFactoryTests
{
    [Fact]
    public void Can_create_any_type_of_animal()
    {
        var factory = new AnimalFactory();

        factory.Create<Dog>().Should().BeOfType<Dog>();
        factory.Create<Cat>().Should().BeOfType<Cat>();
        factory.Create<Fish>().Should().BeOfType<Fish>();
        factory.Create<Monkey>().Should().BeOfType<Monkey>();
        factory.Create<Horse>().Should().BeOfType<Horse>();
    }

    [Fact]
    public void Animal_instances_are_correct()
    {
        var factory = new AnimalFactory();

        var dog = factory.Create<Dog>();
        var cat = factory.Create<Cat>();
        var fish = factory.Create<Fish>();
        var monkey = factory.Create<Monkey>();
        var horse = factory.Create<Horse>();

        dog.MakeNoise().Should().Be("Hau, hau");
        cat.MakeNoise().Should().Be("Miau, miau");
        fish.MakeNoise().Should().Be(string.Empty);
        monkey.MakeNoise().Should().Be("Uuu, aaa");
        horse.MakeNoise().Should().Be("Ihaa, ihaa");
    }

    //[Fact]
    //public void Can_create_any_type_of_animal()
    //{
    //    var factory = new AnimalFactory();

    //    factory.Create("Dog").Should().BeOfType<Dog>();
    //    factory.Create("Cat").Should().BeOfType<Cat>();
    //    factory.Create("Fish").Should().BeOfType<Fish>();
    //    factory.Create("Monkey").Should().BeOfType<Monkey>();
    //    factory.Create("Horse").Should().BeOfType<Horse>();

    //    Action action = () => factory.Create("unknown");
    //    action.Should().Throw<Exception>();
    //}

    //[Fact]
    //public void Animal_instances_are_correct()
    //{
    //    var factory = new AnimalFactory();

    //    var dog = factory.Create("Dog");
    //    var cat = factory.Create("Cat");
    //    var fish = factory.Create("Fish");
    //    var monkey = factory.Create("Monkey");
    //    var horse = factory.Create("Horse");

    //    dog.MakeNoise().Should().Be("Hau, hau");
    //    cat.MakeNoise().Should().Be("Miau, miau");
    //    fish.MakeNoise().Should().Be(string.Empty);
    //    monkey.MakeNoise().Should().Be("Uuu, aaa");
    //    horse.MakeNoise().Should().Be("Ihaa, ihaa");
    //}
}