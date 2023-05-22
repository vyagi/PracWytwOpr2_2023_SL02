using FluentAssertions;
using MementoPattern;

namespace MementoPatternTests;

public class DocumentTests
{
    //In fact we should now create three separate test classes for three classes we created DocumentMemento, History, Document

    [Fact]
    public void Can_set_and_read_content()
    {
        var document = new Document();

        document.SetContent("Marcin");

        document.GetContent().Should().Be("Marcin");
    }

    [Fact]
    public void Can_save_and_retrieve_state()
    {
        var history = new History();

        var document = new Document();
        document.SetContent("Marcin");

        document.GetContent().Should().Be("Marcin");
        
        history.Save(document.CreateState());

        document.SetContent("Jagie³a");
        document.GetContent().Should().Be("Jagie³a");

        document.RestoreState(history.Retrieve());
        document.GetContent().Should().Be("Marcin");
    }

    //Not a good test but it's just to show you how the document works
    //[Fact]
    //public void Document_and_history_works_correctly()
    //{
    //    var document = new Document();

    //    document.SetContent("Marcin");

    //    document.GetContent().Should().Be("Marcin");

    //    document.CreateState();

    //    document.SetContent("Something invalid");
    //    document.GetContent().Should().Be("Something invalid");

    //    document.RestoreState();
    //    document.GetContent().Should().Be("Marcin");
    //}
}