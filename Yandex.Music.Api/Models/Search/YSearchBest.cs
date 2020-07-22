using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search.Album;
using Yandex.Music.Api.Models.Search.Artist;
using Yandex.Music.Api.Models.Search.Playlist;
using Yandex.Music.Api.Models.Search.Track;
using Yandex.Music.Api.Models.Search.Video;

namespace Yandex.Music.Api.Models.Search
{
    /// <summary>
    /// Конвертер для поля Result
    /// </summary>
    internal class YSearchBestConverter : JsonConverter
    {
        #region Поля

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var obj = JObject.Load(reader);
            var contract = (JsonObjectContract) serializer.ContractResolver.ResolveContract(objectType);
            var best = existingValue as YSearchBest ?? (YSearchBest) contract.DefaultCreator();

            best.Type = (YSearchType) Enum.Parse(typeof(YSearchType), obj["type"].ToString(), true);

            switch (best.Type) {
                case YSearchType.Track:
                    best.Result = JsonConvert.DeserializeObject<YSearchTrackModel>(obj["result"].ToString());
                    break;
                case YSearchType.Album:
                    best.Result = JsonConvert.DeserializeObject<YSearchAlbumModel>(obj["result"].ToString());
                    break;
                case YSearchType.Artist:
                    best.Result = JsonConvert.DeserializeObject<YSearchArtistModel>(obj["result"].ToString());
                    break;
                case YSearchType.Playlist:
                    best.Result = JsonConvert.DeserializeObject<YSearchPlaylistModel>(obj["result"].ToString());
                    break;
                case YSearchType.Video:
                    best.Result = JsonConvert.DeserializeObject<YSearchVideoModel>(obj["result"].ToString());
                    break;
            }

            return best;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Свойства

        public override bool CanWrite => false;

        #endregion
    }

    [JsonConverter(typeof(YSearchBestConverter))]
    public class YSearchBest
    {
        #region Свойства

        public dynamic Result { get; set; }
        public YSearchType Type { get; set; }

        #endregion
    }
}