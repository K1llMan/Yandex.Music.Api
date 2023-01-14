using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(9)]
    [TestBeforeAfter]
    public class QueueAPITest : YandexTest
    {
        [Fact, YandexTrait(TraitGroup.QueueAPI)]
        [Order(0)]
        public void Create_ValidData_True()
        {
            YResponse<YNewQueue> newQueue = Fixture.API.Queue.Create(Fixture.Storage, new YQueue
            {
                Context = new YContext
                {
                    Description = "Сироп",
                    Id = "track:819992702",
                    Type = "radio"
                },
                Tracks = new List<YTrackId>
                {
                    new()
                    {
                        TrackId = "109253661",
                        AlbumId = "24174855",
                        From = "desktop_win-radio-radio_track_81999270-default"
                    }
                },
                CurrentIndex = null,
                From = "desktop_win-radio-radio_track_81999270-default",
                IsInteractive = true
            });

            Fixture.NewQueue = newQueue.Result;

            Fixture.NewQueue.Id.Should().NotBeNullOrWhiteSpace();
        }
        
        [Fact, YandexTrait(TraitGroup.QueueAPI)]
        [Order(1)]
        public void Get_ValidData_True()
        {
            YResponse<YQueue> queue = Fixture.API.Queue.Get(Fixture.Storage, Fixture.NewQueue.Id);

            queue.Result.Id.Should().NotBeNullOrWhiteSpace();
        }
        
        [Fact, YandexTrait(TraitGroup.QueueAPI)]
        [Order(2)]
        public void List_ValidData_True()
        {
            YResponse<YQueueItemsContainer> queueItemsContainer = Fixture.API.Queue.List(Fixture.Storage);

            queueItemsContainer.Result.Queues.Count.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.QueueAPI)]
        [Order(3)]
        public void UpdatePosition_ValidData_True()
        {
            YResponse<YUpdatedQueue> updatedQueue = Fixture.API.Queue.UpdatePosition(Fixture.Storage, Fixture.NewQueue.Id, 0, true);

            updatedQueue.Result.Status.Should().Be("ok");
        }
        
        public QueueAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}
