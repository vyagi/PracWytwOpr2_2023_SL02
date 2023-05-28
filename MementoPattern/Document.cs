namespace MementoPattern;

public class Word
{
    private readonly Document _document;
    private readonly History _history;

    public Word(Document document, History history)
    {
        _document = document;
        _history = history;
    }

    public void SetContent(string content)
    {
        _history.Save(_document.CreateState());
        _document.SetContent(content);
    }

    public string GetContent() => _document.GetContent();

    public void RestoreState() => _document.SetContent(_history.Retrieve().GetContent());
}

public class DocumentMemento
{
    private readonly string _content;

    public DocumentMemento(string content) => _content = content;

    public string GetContent() => _content;
}

public class History
{
    private readonly Stack<DocumentMemento> _history = new();

    public void Save(DocumentMemento documentMemento) => _history.Push(documentMemento);

    public DocumentMemento Retrieve() => _history.Pop();
}

public class Document
{
    private string _content;

    public string GetContent() => _content;

    public string SetContent(string content) => _content = content;

    public DocumentMemento CreateState() => new (_content);

    public void RestoreState(DocumentMemento documentMemento) => _content = documentMemento.GetContent();
}

//This class violates SRP - refactor it (maybe use Memento pattern !)
//public class Document
//{
//    private string _content;
//    private readonly Stack<string> _history = new();

//    public string GetContent() => _content;

//    public string SetContent(string content) => _content = content;

//    public void CreateState() => _history.Push(_content);

//    public void RestoreState() => _content = _history.Pop();
//}