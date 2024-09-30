using System;
using System.Threading;

using FluentAssertions;

using Xunit.Extensions.Ordering;
using Xunit;
using Xunit.Abstractions;

using Yandex.Music.Api.Tests.Traits;
using Yandex.Music.Api.Common.Ynison;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(12)]
    [TestBeforeAfter]
    public class YnisonAPITest: YandexTest
    {
        [Fact, YandexTrait(TraitGroup.YnisonAPI)]
        [Order(0)]
        public async void Connect_ValidData_True()
        {
            using YnisonListener listener = await Fixture.API.Ynison.Connect(Fixture.Storage);
            listener.OnReceive += args => {
                Output.WriteLine(args.State);
            };

            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Output.WriteLine(listener.State);
            }

            listener.Disconnect();

            listener.State.Should().NotBeNullOrEmpty();
        }

        public YnisonAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}