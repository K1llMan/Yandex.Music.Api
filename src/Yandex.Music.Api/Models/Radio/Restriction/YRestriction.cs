using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Radio.Restriction
{
    public sealed class YRestrictionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(YRestriction).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            YRestriction restriction;

            try
            {
                YRestrictionType type = jObject["type"].ToObject<YRestrictionType>();

#pragma warning disable IDE0066 // Преобразовать оператор switch в выражение
                switch (type)
                {
                    case YRestrictionType.Enum:
                        restriction = jObject.ToObject<YRestrictionEnum>();
                        break;
                    case YRestrictionType.DiscreteScale:
                        restriction = jObject.ToObject<YRestrictionDiscreteScale>();
                        break;
                    default:
                        restriction = jObject.ToObject<YRestriction>();
                        break;
                }
#pragma warning restore IDE0066 // Преобразовать оператор switch в выражение
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка десериализации типа \"{objectType.Name}\".", ex);
            }

            return restriction;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public class YRestriction
    {
        public string Name { get; set; }
        public YRestrictionType Type { get; set; }
    }
}
