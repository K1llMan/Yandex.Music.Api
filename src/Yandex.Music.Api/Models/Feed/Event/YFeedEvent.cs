using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public sealed class YFeedEventConverter : JsonConverter
    {
        private YFeedEvent GetEvent(JToken jObject)
        {
            YFeedEvent feedEvent;

            try
            {
                YFeedEventType type = jObject["typeForFrom"].ToObject<YFeedEventType>();

                switch (type)
                {
                    case YFeedEventType.GenreTop:
                        feedEvent = jObject.ToObject<YFeedEventGenreTracksTop>();
                        break;

                    case YFeedEventType.NewAlbums:
                        feedEvent = jObject.ToObject<YFeedEventAlbums>();
                        break;

                    case YFeedEventType.NewAlbumsOfFavoriteGenre:
                        feedEvent = jObject.ToObject<YFeedEventGenreAlbums>();
                        break;

                    case YFeedEventType.RecentTrackLikeToTracks:
                        feedEvent = jObject.ToObject<YFeedEventLikeTrack>();
                        break;

                    case YFeedEventType.RecommendedArtistsWithArtistsFromHistory:
                        feedEvent = jObject.ToObject<YFeedEventArtistWithArtists>();
                        break;

                    case YFeedEventType.RecommendedSimilarArtists:
                        feedEvent = jObject.ToObject<YFeedEventSimilarArtists>();
                        break;

                    case YFeedEventType.RecommendedSimilarGenre:
                        feedEvent = jObject.ToObject<YFeedEventSimilarGenre>();
                        break;

                    case YFeedEventType.MissedTracksByArtist:
                    case YFeedEventType.RareArtist:
                    case YFeedEventType.RecommendedTracksByArtistFromHistory:
                        feedEvent = jObject.ToObject<YFeedEventArtist>();
                        break;

                    case YFeedEventType.NewTracksOfFavoriteGenre:
                    case YFeedEventType.TracksByGenre:
                        feedEvent = jObject.ToObject<YFeedEventGenreTracks>();
                        break;

                    case YFeedEventType.WellForgottenOldArtists:
                        feedEvent = jObject.ToObject<YFeedEventArtists>();
                        break;

                    case YFeedEventType.WellForgottenOldTracks:
                        feedEvent = jObject.ToObject<YFeedEventTracks>();
                        break;

                    default:
                        feedEvent = jObject.ToObject<YFeedEvent>();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка десериализации типа \"{jObject["typeForFrom"]}\".", ex);
            }

            return feedEvent;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(YFeedEvent).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            return JArray.Load(reader)
                .Select(GetEvent)
                .ToList();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public class YFeedEvent
    {
        public string Id { get; set; }
        public List<YFeedEventTitle> Title { get; set; }
        public YFeedEventType TypeForFrom { get; set; }
        public YFeedEventType Type { get; set; }
    }
}