using FactoryPattern;
using FluentAssertions;

namespace FactoryPatternTests;

public class AnimalFactoryTests
{
    [Fact]
    public void Can_create_any_type_of_animal()
    {
        var factory = new AnimalFactory();

        //factory.Create("Cat").Should().BeOfType<Cat>();
        //factory.Create("Dog").Should().BeOfType<Dog>();
        //factory.Create("Horse").Should().BeOfType<Horse>();

        factory.Create<Cat>().Should().BeOfType<Cat>();
        factory.Create<Dog>().Should().BeOfType<Dog>();
        factory.Create<Horse>().Should().BeOfType<Horse>();
        factory.Create<Monkey>().Should().BeOfType<Monkey>();
    }
}