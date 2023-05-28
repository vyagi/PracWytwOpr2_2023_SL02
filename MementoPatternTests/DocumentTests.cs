using FluentAssertions;
using MementoPattern;

namespace MementoPatternTests;

public class DocumentTests
{
    [Fact]
    public void Word_works_correctly()
    {
        var word = new Word(new Document(), new History());

        word.SetContent("Wsiz");
        word.GetContent().Should().Be("Wsiz");

        word.SetContent("Wsiz w Rzeszowie");
        word.GetContent().Should().Be("Wsiz w Rzeszowie");

        word.RestoreState();
        word.GetContent().Should().Be("Wsiz");
    }

    [Fact]
    public void Can_get_and_set_content()
    {
        var document = new Document();

        document.SetContent("Wsiz");

        document.GetContent().Should().Be("Wsiz");
    }

    [Fact]
    public void Can_save_and_retrieve_state()
    {
        var history = new History();

        var document = new Document();

        document.SetContent("Wsiz");

        document.GetContent().Should().Be("Wsiz");

        history.Save(document.CreateState());

        document.SetContent("Wsiz w Rzeszowie");
        document.GetContent().Should().Be("Wsiz w Rzeszowie");

        document.RestoreState(history.Retrieve());
        document.GetContent().Should().Be("Wsiz");
    }

    //[Fact]
    //public void Document_works_correctly()
    //{
    //    var document = new Document();

    //    document.SetContent("Wsiz");

    //    document.GetContent().Should().Be("Wsiz");

    //    document.CreateState();

    //    document.SetContent("Wsiz w Rzeszowie");
    //    document.GetContent().Should().Be("Wsiz w Rzeszowie");

    //    document.RestoreState();
    //    document.GetContent().Should().Be("Wsiz");
    //}
}