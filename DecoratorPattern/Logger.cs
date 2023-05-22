using System.Security.Cryptography;

namespace DecoratorPattern;

public class SimpleLogger : ILogger
{
    public string Log(string message) => $"Information: {message}";
}

public interface ILogger
{
    string Log(string message);
}

public class TimestampingLogger : ILogger
{
    private readonly ILogger _logger;

    public TimestampingLogger(ILogger logger) => _logger = logger;

    public string Log(string message) => $"{DateTime.Now:yyyy-MM-dd:HH:mm:ss} {_logger.Log(message)}";
}

public class HashingLogger : ILogger
{
    private readonly ILogger _logger;

    public HashingLogger(ILogger logger) => _logger = logger;

    public string Log(string message) => MD5Hash.Hash.GetMD5(_logger.Log(message));
}

public class EncryptingLogger : ILogger
{
    private readonly ILogger _logger;

    public EncryptingLogger(ILogger logger) => _logger = logger;

    public string Log(string message) => $"Encrypted: {_logger.Log(message)}";
}

//This is an approach which is not scalable (new features bring more and more combinations) and totally not flexible. 
//That's why the decorator pattern was invented (above)

//public class Logger
//{
//    public virtual string Log(string message) => $"Information: {message}";
//}

//public class TimestampingLogger : Logger
//{
//    public override string Log(string message) => $"{DateTime.Now:yyyy-MM-dd:HH:mm:ss} {base.Log(message)}";
//}

//public class HashingLogger : Logger
//{
//    public override string Log(string message) => MD5Hash.Hash.GetMD5(base.Log(message));
//}

////Another requirement may be for example
//// public class EncryptingLogger : Logger
//// {
////
//// }

////and then the combinations start:

//public class HashingTimestampingLogger : TimestampingLogger
//{
//    public override string Log(string message) => MD5Hash.Hash.GetMD5(base.Log(message));
//}

////And now more and more combinations can come

