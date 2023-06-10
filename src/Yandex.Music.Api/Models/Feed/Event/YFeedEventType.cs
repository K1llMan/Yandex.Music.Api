using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public enum YFeedEventType
    {
        [EnumMember(Value = "genre-top")]
        GenreTop,

        [EnumMember(Value = "missed-tracks-by-artist")]
        MissedTracksByArtist,

        [EnumMember(Value = "never-heard-from-library")]
        NeverHeardFromLibrary,

        [EnumMember(Value = "new-albums")]
        NewAlbums,

        [EnumMember(Value = "new-albums-of-favorite-genre")]
        NewAlbumsOfFavoriteGenre,

        [EnumMember(Value = "new-tracks-of-favorite-genre")]
        NewTracksOfFavoriteGenre,

        Notification,

        [EnumMember(Value = "rare-artist")]
        RareArtist,

        [EnumMember(Value = "recent-track-like-to-tracks")]
        RecentTrackLikeToTracks,

        [EnumMember(Value = "recommended-artists-with-artists-from-history")]
        RecommendedArtistsWithArtistsFromHistory,

        [EnumMember(Value = "recommended-similar-artists")]
        RecommendedSimilarArtists,

        [EnumMember(Value = "recommended-similar-genre")]
        RecommendedSimilarGenre,

        [EnumMember(Value = "recommended-tracks-by-artist-from-history")]
        RecommendedTracksByArtistFromHistory,

        [EnumMember(Value = "similar-tracks-from-history")]
        SimilarTracksFromHistory,

        [EnumMember(Value = "tracks-by-genre")]
        TracksByGenre,

        [EnumMember(Value = "well-forgotten-old-artists")]
        WellForgottenOldArtists,

        [EnumMember(Value = "well-forgotten-old-tracks")]
        WellForgottenOldTracks
    }
}