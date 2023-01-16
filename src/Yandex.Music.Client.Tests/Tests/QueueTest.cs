using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Queue;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(9)]
    [TestBeforeAfter]
    public class QueueTest : YandexTest
    {
        [Fact]
        [Order(0)]
        public void CreateQueue_ValidData_True()
        {
            Fixture.NewQueue = Fixture.Client.CreateQueue(new YQueue {
                Context = new YContext {
                    Description = "Сироп",
                    Id = "track:819992702",
                    Type = "radio"
                },
                Tracks = new List<YTrackId> {
                    new() {
                        TrackId = "109253661",
                        AlbumId = "24174855",
                        From = "desktop_win-radio-radio_track_81999270-default"
                    }
                },
                CurrentIndex = null,
                From = "desktop_win-radio-radio_track_81999270-default",
                IsInteractive = true
            });
            
            Fixture.NewQueue.Id.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        [Order(1)]
        public void GetQueue_ValidData_True()
        {
            YQueue queue = Fixture.Client.GetQueue(Fixture.NewQueue.Id);

            queue.Id.Should().NotBeNullOrWhiteSpace();
        }
        
        [Fact]
        [Order(2)]
        public void QueuesList_ValidData_True()
        {
            YQueueItemsContainer queueItemsContainer = Fixture.Client.QueuesList();

            queueItemsContainer.Queues.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(3)]
        public void QueueUpdatePosition_ValidData_True()
        {
            YUpdatedQueue updatedQueue = Fixture.Client.QueueUpdatePosition(Fixture.NewQueue.Id, 0, true);

            updatedQueue.Status.Should().Be("ok");
        }

        public QueueTest(YandexTestHarness fixture, ITestOutputHelper output, ITestOutputHelper testOutputHelper) : base(fixture, output)
        {
        }
    }
}
