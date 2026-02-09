using System;
using System.Linq;
using System.Threading;

using FluentAssertions;

using Xunit.Extensions.Ordering;
using Xunit;
using Xunit.Abstractions;

using Yandex.Music.Api.Tests.Traits;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(12)]
    [TestBeforeAfter]
    public class YnisonAPITest : YandexTest
    {
        [Fact, YandexTrait(TraitGroup.YnisonAPI)]
        [Order(0)]
        public void Connect_ValidData_True()
        {
            Fixture.Player = Fixture.API.Ynison.GetPlayer(Fixture.Storage);
            Fixture.Player.OnClose += (player, args) =>
            {
                Output.WriteLine($"{args.Status}: {args.Description}.");
            };

            Fixture.Player.Connect();
            /*
            listener.OnReceive += args => {
                Output.WriteLine(args.State);
            };
            */

            for (int i = 0; i < 1; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                YTrack track = Fixture.Player.Current;
                if (track != null)
                    Output.WriteLine($"{string.Join(", ", track.Artists.Select(a => a.Name))} - {track.Title}");
            }

            Fixture.Player.State.Should().NotBeNull();
        }

        /*
        [Fact, YandexTrait(TraitGroup.YnisonAPI)]
        [Order(1)]
        public void PlayerNext_ValidData_True()
        {
            YTrack startTrack = Fixture.Player.Current;

            for (int i = 0; i < 2; i++)
            {
                YTrack track = Fixture.Player.Current;
                Output.WriteLine($"{string.Join(", ", track.Artists.Select(a => a.Name))} - {track.Title}");

                Fixture.Player.Next();
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }

            YTrack endTrack = Fixture.Player.Current;

            endTrack.Id.Should().NotBeEquivalentTo(startTrack.Id);
        }
        */

        [Fact, YandexTrait(TraitGroup.YnisonAPI)]
        [Order(2)]
        public void Disconnect_ValidData_True()
        {
            Fixture.Player.Disconnect();
        }

        public YnisonAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}
