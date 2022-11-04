using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Feed;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(4)]
    [TestBeforeAfter]
    public class LandingAPITest : YandexTest
    {
        [Fact]
        [Order(0)]
        public void Get_ValidData_True()
        {
            YFeed feed = Fixture.Client.Feed();
            feed.Should().NotBe(null);
        }
        public LandingAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}