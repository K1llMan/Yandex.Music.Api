using System;
using System.Threading;

using FluentAssertions;

using Newtonsoft.Json;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(12)]
    [TestBeforeAfter]
    public class YnisonTest : YandexTest
    {
        public YnisonTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        [Order(0)]
        public void Connect_ValidData_True()
        {
            Fixture.Client.ConnectToYnison();

            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Output.WriteLine(JsonConvert.SerializeObject(Fixture.Client.Ynison.Current));
            }

            Fixture.Client.Ynison.Disconnect();

            Fixture.Client.Ynison.State.Should().NotBeNull();
        }
    }
}