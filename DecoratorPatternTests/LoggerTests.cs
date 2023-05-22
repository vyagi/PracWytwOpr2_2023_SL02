using DecoratorPattern;
using FluentAssertions;

namespace DecoratorPatternTests;

public class LoggerTests
{
    //Decorator pattern tests

    [Fact]
    public void Logger_logs_correctly()
    {
        var logger = new SimpleLogger();

        logger.Log("File saved").Should().Be("Information: File saved");
    }

    [Fact]
    public void TimestampingLogger_logs_correctly()
    {
        var logger = new TimestampingLogger(new SimpleLogger());

        logger.Log("File saved").Should().StartWith(DateTime.Now.Year.ToString());
        logger.Log("File saved").Should().EndWith("Information: File saved");
    }

    [Fact]
    public void HashingLogger_logs_correctly()
    {
        var logger = new HashingLogger(new SimpleLogger());

        logger.Log("File saved").Should().NotStartWith(DateTime.Now.Year.ToString());
        logger.Log("File saved").Should().NotStartWith("Information: File saved");
    }

    [Fact]
    public void HashingTimestampingLogger_logs_correctly()
    {
        var logger = new HashingLogger(new TimestampingLogger(new SimpleLogger()));

        //Some tests to test it
    }

    [Fact]
    public void TimestampingHashingLogger_logs_correctly()
    {
        var logger = new TimestampingLogger(new HashingLogger(new SimpleLogger()));

        //Some tests to test it
    }

    [Fact]
    public void EncryptingTimestampingHashingLogger_logs_correctly()
    {
        var logger = new EncryptingLogger(new TimestampingLogger(new HashingLogger(new SimpleLogger())));

        //Some tests to test it
    }

    [Fact]
    public void TimestampingEncryptingLogger_logs_correctly()
    {
        var logger = new TimestampingLogger(new EncryptingLogger(new SimpleLogger()));

        //Some tests to test it
    }

    //Old implementation tests

    //[Fact]
    //public void Logger_logs_correctly()
    //{
    //    var logger = new Logger();

    //    logger.Log("File saved").Should().Be("Information: File saved");
    //}

    //[Fact]
    //public void TimestampingLogger_logs_correctly()
    //{
    //    var logger = new TimestampingLogger();

    //    logger.Log("File saved").Should().StartWith(DateTime.Now.Year.ToString());
    //    logger.Log("File saved").Should().EndWith("Information: File saved");
    //}

    //[Fact]
    //public void HashingLogger_logs_correctly()
    //{
    //    var logger = new HashingLogger();

    //    logger.Log("File saved").Should().NotStartWith(DateTime.Now.Year.ToString());
    //    logger.Log("File saved").Should().NotStartWith("Information: File saved");
    //}
}