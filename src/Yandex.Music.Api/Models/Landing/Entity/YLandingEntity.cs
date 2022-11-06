using System;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Yandex.Music.Api.Models.Landing.Entity.Entities;

namespace Yandex.Music.Api.Models.Landing.Entity
{
    public sealed class YLandingEntityConverter : JsonConverter
    {
        private YLandingEntity GetEntity(JToken jObject)
        {
            YLandingEntity entity;

            try
            {
                YLandingEntityType type = jObject["type"].ToObject<YLandingEntityType>();

                switch (type)
                {
                    case YLandingEntityType.Album:
                        entity = jObject.ToObject<YLandingEntityAlbum>();
                        break;
                    case YLandingEntityType.ChartItem:
                        entity = jObject.ToObject<YLandingEntityChart>();
                        break;
                    case YLandingEntityType.PersonalPlaylist:
                        entity = jObject.ToObject<YLandingEntityPersonalPlaylist>();
                        break;
                    case YLandingEntityType.PlayContext:
                        entity = jObject.ToObject<YLandingEntityPlayContext>();
                        break;
                    case YLandingEntityType.Playlist:
                        entity = jObject.ToObject<YLandingEntityPlaylist>();
                        break;
                    case YLandingEntityType.Podcast:
                        entity = jObject.ToObject<YLandingEntityPodcast>();
                        break;
                    case YLandingEntityType.Promotion:
                        entity = jObject.ToObject<YLandingEntityPromotion>();
                        break;
                    default:
                        entity = jObject.ToObject<YLandingEntity>();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка десериализации типа \"{jObject["type"]}\".", ex);
            }

            return entity;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(YLandingEntity).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            return JArray.Load(reader)
                .Select(GetEntity)
                .ToList();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class YLandingEntity
    {
        public string Id { get; set; }
        public YLandingEntityType Type { get; set; }
    }
}