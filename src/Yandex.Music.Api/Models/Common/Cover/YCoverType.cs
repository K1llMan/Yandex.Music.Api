using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yandex.Music.Api.Models.Common.Cover
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum YCoverType
    {
        Error,
        [EnumMember(Value = "from-artist-photos")]
        FromArtistPhotos,
        [EnumMember(Value = "from-album-cover")]
        FromAlbumCover,
        Mosaic,
        Pic
    }
}