using Serilog;
using Serilog.Events;

using Xunit;
using Xunit.Abstractions;

//Optional
[assembly: CollectionBehavior(DisableTestParallelization = true)]
//Optional
[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]
//Optional
[assembly: TestCollectionOrderer("Xunit.Extensions.Ordering.CollectionOrderer", "Xunit.Extensions.Ordering")]

namespace Yandex.Music.Api.Tests
{
    [CollectionDefinition("Yandex Test Harness")]
    public class YandexTestCollection : ICollectionFixture<YandexTestHarness>
    {
    }

    public class YandexTest
    {
        public YandexTest(YandexTestHarness fixture, ITestOutputHelper output = null)
        {
            Fixture = fixture;

            if (output != null)
                Log.Logger = new LoggerConfiguration()
                    .WriteTo
                    .TestOutput(output, LogEventLevel.Verbose)
                    .CreateLogger();
        }

        public YandexTestHarness Fixture { get; set; }
    }
}