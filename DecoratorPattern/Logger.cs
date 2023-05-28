namespace DecoratorPattern;

public interface ILogger
{
    string Log(string message);
}

public class SimpleLogger : ILogger
{
    public string Log(string message) => $"Information: {message}";
}

public class TimeStampingLogger : ILogger
{
    private readonly ILogger _logger;

    public TimeStampingLogger(ILogger logger) => _logger = logger;

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

    public string Log(string message) => _logger.Log($"Zaszyfrowane: {message}");
}

//to rozwiązanie nie jest skalowalne - kombinacji jest bardzo dużo, a będzie jeszcze więcej z każdym pomysłem "managera"

//public class Logger
//{
//    public virtual string Log(string message) => $"Information: {message}";
//}

//public class TimestampingLogger : Logger
//{
//    public override string Log(string message) => 
//        $"{DateTime.Now:yyyy-MM-dd:HH:mm:ss} {base.Log(message)}";
//}

//public class HashingLogger : Logger
//{
//    public override string Log(string message) => 
//        MD5Hash.Hash.GetMD5(base.Log(message));
//}

//public class EncryptingLogger : Logger
//{
//    public override string Log(string message) =>
//        $"Zaszyfrowane : {base.Log(message)}";
//}

//public class HashingTimestampingLogger : TimestampingLogger
//{
//    public override string Log(string message) =>
//        MD5Hash.Hash.GetMD5(base.Log(message));
//}

//public class TimestampingHashingLogger : HashingLogger
//{
//    public override string Log(string message) =>
//        $"{DateTime.Now:yyyy-MM-dd:HH:mm:ss} {base.Log(message)}";
//}