using Xunit;
using Xunit.Abstractions;

//Optional
[assembly: CollectionBehavior(DisableTestParallelization = true)]
//Optional
[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]
//Optional
[assembly: TestCollectionOrderer("Xunit.Extensions.Ordering.CollectionOrderer", "Xunit.Extensions.Ordering")]

[assembly: TestFramework("Xunit.Extensions.Ordering.TestFramework", "Xunit.Extensions.Ordering")]

namespace Yandex.Music.Client.Tests
{
    [CollectionDefinition("Yandex Test Harness")]
    public class YandexTestCollection : ICollectionFixture<YandexTestHarness>
    {
    }

    public class YandexTest
    {
        public YandexTest(YandexTestHarness fixture, ITestOutputHelper output)
        {
            Fixture = fixture;
            Output = output;
        }

        public YandexTestHarness Fixture { get; set; }

        public ITestOutputHelper Output { get; set; }
    }
}