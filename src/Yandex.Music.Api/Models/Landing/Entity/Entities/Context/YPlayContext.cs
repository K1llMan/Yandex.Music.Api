using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Landing.Entity.Entities.Context
{
    public sealed class YPlayContextConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(YLandingEntity).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);

            YPlayContext context;
            try
            {
                YPlayContextType type = jObject["context"].ToObject<YPlayContextType>();

                switch (type)
                {
                    case YPlayContextType.Album:
                        context = jObject.ToObject<YPlayContextAlbum>();
                        break;
                    case YPlayContextType.Artist:
                        context = jObject.ToObject<YPlayContextArtist>();
                        break;
                    case YPlayContextType.Playlist:
                        context = jObject.ToObject<YPlayContextPlaylist>();
                        break;
                    default:
                        context = jObject.ToObject<YPlayContext>();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка десериализации типа \"{jObject["type"]}\".", ex);
            }

            return context;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public class YPlayContext
    {
        public string Client { get; set; }
        public YPlayContextType Context { get; set; }
        public string ContextItem { get; set; }
    }
}