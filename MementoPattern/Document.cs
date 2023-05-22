namespace MementoPattern;

//No complains about SRP violation from Senior developers in your team
public class DocumentMemento
{
    private readonly string _content;

    public DocumentMemento(string content) => _content = content;

    public string GetContent() => _content;
}

public class History
{
    private readonly Stack<DocumentMemento> _states = new();

    public void Save(DocumentMemento documentMemento) => _states.Push(documentMemento);

    public DocumentMemento Retrieve() => _states.Pop();
}

public class Document
{
    private string _content = string.Empty;

    public void SetContent(string newContent) =>
        _content = newContent;

    public string GetContent() => _content;

    public DocumentMemento CreateState()
        => new (_content);

    public void RestoreState(DocumentMemento documentMemento) =>
        _content = documentMemento.GetContent();
}

//This class violates SRP
//public class Document
//{
//    private readonly Stack<string> _history = new();

//    private string _content;

//    public void SetContent(string newContent) => 
//        _content = newContent;

//    public string GetContent() => _content;

//    public void CreateState()
//        => _history.Push(_content);

//    public void RestoreState() =>
//        _content = _history.Pop();
//}