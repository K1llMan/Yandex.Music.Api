using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Models.Search.Playlist
{
    public class YSearchPlaylistModel
    {
        public int? Revision { get; set; }
        public string Kind { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DescriptionFormatted { get; set; }
        public int? TrackCount { get; set; }
        public YCover Cover { get; set; }
        public YOwner Owner { get; set; }
        public List<string> Tags { get; set; }
        public long? LikesCount { get; set; }

        internal static YSearchPlaylistModel FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YSearchPlaylistModel
            {
                Revision = json.SelectToken("revision")?.ToObject<int?>(),
                Kind = json.SelectToken("kind")?.ToObject<string>(),
                Title = json.SelectToken("title")?.ToObject<string>(),
                Description = json.SelectToken("description")?.ToObject<string>(),
                DescriptionFormatted = json.SelectToken("descriptionFormatted")?.ToObject<string>(),
                TrackCount = json.SelectToken("trackCount")?.ToObject<int>(),
                Cover = YCover.FromJson(json.SelectToken("cover")),
                Owner = YOwner.FromJson(json["owner"]),
                Tags = json.SelectToken("tags")?.Select(x => x.ToObject<string>()).ToList(),
                LikesCount = json.SelectToken("likesCount")?.ToObject<long>(),
            };
        }
    }
}