using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Album
{
    public sealed class YLabelConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JArray jArray = JArray.Load(reader);
            JTokenType tokenType = jArray.FirstOrDefault()?.Type ?? JTokenType.String;
            object label;

            try
            {
                label = tokenType switch {
                    JTokenType.Object => jArray.ToObject<List<YLabel>>(),
                    _ => jArray.ToObject<List<string>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка десериализации типа \"{objectType.Name}\".", ex);
            }

            return label;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public class YAlbum : YBaseModel
    {
        public YButton ActionButton { get; set; }
        public List<YArtist> Artists { get; set; }
        public bool Available { get; set; }
        public bool AvailableForMobile { get; set; }
        public List<string> AvailableForOptions { get; set; }
        public bool AvailableForPremiumUsers { get; set; }
        public bool AvailablePartially { get; set; }
        public string BackgroundImageUrl { get; set; }
        public List<string> Bests { get; set; }
        public List<string> Buy { get; set; }
        public bool ChildContent { get; set; }
        public string ContentWarning { get; set; }
        public string CoverUri { get; set; }
        public YCustomWave CustomWave { get; set; }
        public string Description { get; set; }
        public List<string> Disclaimers { get; set; }
        public List<YAlbum> Duplicates { get; set; }
        public string Genre { get; set; }
        public string Id { get; set; }
        [JsonConverter(typeof(YLabelConverter))]
        public dynamic Labels { get; set; }
        public int LikesCount { get; set; }
        public string MetaTagId { get; set; }
        public YMetaType MetaType { get; set; }
        public string OgImage { get; set; }
        public YPager Pager { get; set; }
        public List<YPrerolls> Prerolls { get; set; }
        public bool Recent { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ShortDescription { get; set; }
        public YSortOrder SortOrder { get; set; }
        public string StorageDir { get; set; }
        public string Title { get; set; }
        public int TrackCount { get; set; }
        public YTrackPosition TrackPosition { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public bool VeryImportant { get; set; }
        public List<List<YTrack>> Volumes { get; set; }
        public int Year { get; set; }
    }
}