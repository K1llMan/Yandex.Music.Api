using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Landing
{
    public enum YLandingBlockType
    {
        Chart,
        [EnumMember(Value = "client-widget")]
        ClientWidget,
        [EnumMember(Value = "categories-tab")]
        CategoriesTab,
        [EnumMember(Value = "editorial-playlists")]
        EditorialPlaylists,
        Menu,
        Mixes,
        [EnumMember(Value = "new-releases")]
        NewReleases,
        [EnumMember(Value = "new-playlists")]
        NewPlaylists,
        [EnumMember(Value = "personal-playlists")]
        PersonalPlaylists,
        [EnumMember(Value = "play-contexts")]
        PlayContexts,
        Playlists,
        Podcasts,
        Promotions,
        Radio
    }
}
