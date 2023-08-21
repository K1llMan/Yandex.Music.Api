using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Common.Cover;

namespace Yandex.Music.Api.Models.Artist
{
    public class YArtist : YBaseModel
    {
        public YButton ActionButton { get; set; }
        public bool Available { get; set; }
        public bool Composer { get; set; }
        public List<string> Countries { get; set; }
        public YArtistCounts Counts { get; set; }
        [JsonConverter(typeof(YCoverConverter))]
        public YCover Cover { get; set; }
        public List<string> DbAliases { get; set; }
        #warning Непонятная коллекция с содержимым разных типов
        public List<object> Decomposed { get; set; }
        public YDescription Description { get; set; }
        public YDeprecation Deprecation { get; set; }
        public List<string> Disclaimers { get; set; }
        public string EndDate { get; set; }
        public string EnWikipediaLink { get; set; }
        public List<string> Genres { get; set; }
        public string Id { get; set; }
        public string InitDate { get; set; }
        public int LikesCount { get; set; }
        public List<YLink> Links { get; set; }
        public string Name { get; set; }
        public bool NoPicturesFromSearch { get; set; }
        public string OgImage { get; set; }
        public YArtistRatings Ratings { get; set; }
        public bool TicketsAvailable { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Various { get; set; }
        public string YaMoneyId { get; set; }
    }
}