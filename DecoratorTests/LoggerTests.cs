using DecoratorPattern;
using FluentAssertions;

namespace DecoratorTests;

public class LoggerTests
{
    [Fact]
    public void SimpleLogger_logs_correctly()
    {
        var logger = new SimpleLogger();

        logger.Log("Czeœæ").Should().Be("Information: Czeœæ");
    }

    [Fact]
    public void HashingTimestampingLogger_logs_correctly()
    {
        var logger = new HashingLogger(new TimeStampingLogger(new SimpleLogger()));

        logger.Log("Czeœæ").Should().Be("Information: Czeœæ");
    }

    [Fact]
    public void TimestampingHashingLogger_logs_correctly()
    {
        var logger = new TimeStampingLogger(new HashingLogger(new SimpleLogger()));

        logger.Log("Czeœæ").Should().Be("Information: Czeœæ");
    }

    [Fact]
    public void EncryptingTimestampingHashingLogger_logs_correctly()
    {
        var logger = new EncryptingLogger(new TimeStampingLogger(new HashingLogger(new SimpleLogger())));

        logger.Log("Czeœæ").Should().Be("Information: Czeœæ");
    }

    //[Fact]
    //public void Logger_logs_correctly()
    //{
    //    var logger = new Logger();

    //    logger.Log("Czeœæ").Should().Be("Information: Czeœæ");
    //}

    //[Fact]
    //public void TimestampingLogger_logs_correctly()
    //{
    //    var logger = new TimestampingLogger();

    //    logger.Log("Czeœæ").Should().StartWith("2023-05-28"); //Nie piszcie takich testów. Nigdy.
    //}

    //[Fact]
    //public void HashingLogger_logs_correctly()
    //{
    //    var logger = new HashingLogger();

    //    logger.Log("Czeœæ").Should().NotStartWith("2023-05-28"); 
    //    logger.Log("Czeœæ").Should().NotContain("Information"); 
    //    logger.Log("Czeœæ").Should().NotContain("Czeœæ"); 
    //}

    //[Fact]
    //public void EncryptingLogger_logs_correctly()
    //{
    //    var logger = new EncryptingLogger();

    //    logger.Log("Czeœæ").Should().StartWith("Zaszyfrowane");
    //}
}