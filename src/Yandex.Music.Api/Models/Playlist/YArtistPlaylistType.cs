using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Playlist
{
    public enum YArtistPlaylistType
    {
        [EnumMember(Value = "TOP")]
        Top,
        [EnumMember(Value = "SIMILAR")]
        Similar
    }
}
