using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Landing
{
    public enum YLandingBlockType
    {
        Chart,
        Mixes,
        [EnumMember(Value = "personal-playlists")]
        PersonalPlaylists,
        [EnumMember(Value = "play-contexts")]
        PlayContexts,
        Playlists,
        Podcasts,
        Promotions,
        [EnumMember(Value = "new-releases")]
        NewReleases,
        [EnumMember(Value = "new-playlists")]
        NewPlaylists
    }
}