using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Feed;
using Yandex.Music.Api.Models.Landing;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(10)]
    [TestBeforeAfter]
    public class LandingAPITest : YandexTest
    {
        [Fact]
        [Order(0)]
        public void GetLanding_ValidData_True()
        {
            YLanding landing = Fixture.Client.GetLanding(YLandingBlockType.Chart);
            landing.Should().NotBe(null);
        }

        [Fact]
        [Order(1)]
        public void Feed_ValidData_True()
        {
            YFeed feed = Fixture.Client.Feed();
            feed.Should().NotBe(null);
        }
        
        [Fact]
        [Order(2)]
        public void ChildrenLanding_ValidData_True()
        {
            YChildrenLanding landing = Fixture.Client.ChildrenLanding();
            landing.Should().NotBeNull();
            landing.Blocks.Should().NotBeNullOrEmpty();
            landing.Blocks.All(x => x.Entities?.Count > 0).Should().BeTrue();
        }
        
        public LandingAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}