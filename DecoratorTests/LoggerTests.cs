using DecoratorPattern;
using FluentAssertions;

namespace DecoratorTests;

public class LoggerTests
{
    [Fact]
    public void SimpleLogger_logs_correctly()
    {
        var logger = new SimpleLogger();

        logger.Log("Cze��").Should().Be("Information: Cze��");
    }

    [Fact]
    public void HashingTimestampingLogger_logs_correctly()
    {
        var logger = new HashingLogger(new TimeStampingLogger(new SimpleLogger()));

        logger.Log("Cze��").Should().Be("Information: Cze��");
    }

    [Fact]
    public void TimestampingHashingLogger_logs_correctly()
    {
        var logger = new TimeStampingLogger(new HashingLogger(new SimpleLogger()));

        logger.Log("Cze��").Should().Be("Information: Cze��");
    }

    [Fact]
    public void EncryptingTimestampingHashingLogger_logs_correctly()
    {
        var logger = new EncryptingLogger(new TimeStampingLogger(new HashingLogger(new SimpleLogger())));

        logger.Log("Cze��").Should().Be("Information: Cze��");
    }

    //[Fact]
    //public void Logger_logs_correctly()
    //{
    //    var logger = new Logger();

    //    logger.Log("Cze��").Should().Be("Information: Cze��");
    //}

    //[Fact]
    //public void TimestampingLogger_logs_correctly()
    //{
    //    var logger = new TimestampingLogger();

    //    logger.Log("Cze��").Should().StartWith("2023-05-28"); //Nie piszcie takich test�w. Nigdy.
    //}

    //[Fact]
    //public void HashingLogger_logs_correctly()
    //{
    //    var logger = new HashingLogger();

    //    logger.Log("Cze��").Should().NotStartWith("2023-05-28"); 
    //    logger.Log("Cze��").Should().NotContain("Information"); 
    //    logger.Log("Cze��").Should().NotContain("Cze��"); 
    //}

    //[Fact]
    //public void EncryptingLogger_logs_correctly()
    //{
    //    var logger = new EncryptingLogger();

    //    logger.Log("Cze��").Should().StartWith("Zaszyfrowane");
    //}
}