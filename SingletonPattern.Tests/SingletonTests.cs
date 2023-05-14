using FluentAssertions;

namespace SingletonPattern.Tests;

public class SingletonTests
{
    [Fact]
    public void Singleton_instance_can_be_created_and_date_is_correct()
    {
        var s = Singleton.GetInstance();

        s.Should().NotBeNull();
        s.CreatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(100));
    }

    [Fact]
    public void There_can_be_only_one_instance()
    {
        var s1 = Singleton.GetInstance();
        var s2 = Singleton.GetInstance();

        ReferenceEquals(s1,s2).Should().BeTrue();
    }

    [Fact]
    public void There_can_be_only_one_instance_in_multithreaded_environment()
    {
        Singleton s1 = null;
        Singleton s2 = null;

        Task task1 = Task.Factory.StartNew(() => s1 = Singleton.GetInstance());
        Task task2 = Task.Factory.StartNew(() => s2 = Singleton.GetInstance());

        Task.WaitAll(task1, task2);

        ReferenceEquals(s1, s2).Should().BeTrue();
    }
}