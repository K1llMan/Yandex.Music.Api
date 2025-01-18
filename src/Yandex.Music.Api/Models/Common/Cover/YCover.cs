using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Common.Cover
{
    public sealed class YCoverConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(YCover).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            YCover cover;

            try {
                // Фиктивный тип, т.к. у такой обложки нет поля с типом
                if (jObject["type"] == null)
                    jObject.Add("type", "color");

                YCoverType type = jObject["error"] != null
                    ? YCoverType.Error
                    : jObject["type"].ToObject<YCoverType>();

                switch (type) {
                    case YCoverType.Error:
                        cover = jObject.ToObject<YCoverError>();
                        break;
                    case YCoverType.Color:
                        cover = jObject.ToObject<YCoverColor>();
                        break;
                    case YCoverType.FromAlbumCover:
                    case YCoverType.FromArtistPhotos:
                        cover = jObject.ToObject<YCoverImage>();
                        break;
                    case YCoverType.Pic:
                        cover = jObject.ToObject<YCoverPic>();
                        break;
                    case YCoverType.Mosaic:
                        cover = jObject.ToObject<YCoverMosaic>();
                        break;
                    default:
                        cover = jObject.ToObject<YCover>();
                        break;
                }
            }
            catch (Exception ex) {
                throw new Exception($"Ошибка десериализации типа \"{objectType.Name}\".", ex);
            }

            return cover;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject cover = JObject.FromObject(value, serializer);

            cover.WriteTo(writer);
        }
    }

    public class YCover
    {
        public YCoverType Type { get; set; }
    }
}