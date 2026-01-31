using System;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Pins.Items
{
    public sealed class YPinConverter : JsonConverter
    {
        private YPin GetEvent(JToken jObject)
        {
            YPin pin;

            YPinType type = jObject["type"]
                .ToObject<YPinType>();

            switch (type)
            {
                case YPinType.Album:
                    pin = jObject.ToObject<YPin<YPinAlbumData>>();
                    break;

                case YPinType.Artist:
                    pin = jObject.ToObject<YPin<YPinArtistData>>();
                    break;

                case YPinType.Playlist:
                    pin = jObject.ToObject<YPin<YPinPlaylistData>>();
                    break;

                case YPinType.Wave:
                    pin = jObject.ToObject<YPin<YPinWaveData>>();
                    break;

                default:
                    pin = jObject.ToObject<YPin>();
                    break;
            }

            return pin;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(YPin).IsAssignableFrom(objectType);
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

    public abstract class YPin
    {
        public YPinType Type { get; set; }
    }

    public class YPin<T> : YPin
    {
        public T Data { get; set; }
    }
}