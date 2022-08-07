using System;

using Newtonsoft.Json;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Models.Common
{
    public sealed class YExecutionContextConverter : JsonConverter
    {
        #region Поля

        private YandexMusicApi api;
        private AuthStorage storage;

        #endregion Поля

        public override bool CanConvert(Type objectType)
        {
            return typeof(YBaseModel).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try {
                YBaseModel obj = (YBaseModel)Activator.CreateInstance(objectType);
                serializer.Populate(reader, obj);

                obj.Context = new YExecutionContext {
                    API = api,
                    Storage = storage
                };

                return obj;
            }
            catch (Exception ex) {
                throw new Exception($"Ошибка десериализации типа \"{objectType.Name}\".", ex);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public YExecutionContextConverter(YandexMusicApi yandex, AuthStorage auth)
        {
            api = yandex;
            storage = auth;
        }
    }

    public class YExecutionContext
    {
        public YandexMusicApi API { get; internal set; }
        public AuthStorage Storage { get; internal set; }
    }
}
