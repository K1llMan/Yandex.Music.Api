using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Playlist;
using Yandex.Music.Api.Requests.Track;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    public class YPlaylistAPI
    {
        #region Вспомогательные функции

        #endregion Вспомогательные функции

        #region Основные функции

        #region Список с главной

        public async Task<List<YPlaylist>> MainPagePersonalAsync(YAuthStorage storage)
        {
            return await new YGetPlaylistMainPageRequest(storage)
                .Create()
                .GetResponseAsyncList<YPlaylist>("$..[?(@.type == 'personal-playlist')].data.data");
        }

        public List<YPlaylist> MainPagePersonal(YAuthStorage storage)
        {
            return MainPagePersonalAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Список с главной

        #region Стандартные плейлисты

        public async Task<YPlaylistFavoritesResponse> FavoritesAsync(YAuthStorage storage)
        {
            return await new YGetPlaylistFavoritesRequest(storage)
                .Create()
                .GetResponseAsync<YPlaylistFavoritesResponse>();
        }

        public YPlaylistFavoritesResponse Favorites(YAuthStorage storage)
        {
            return FavoritesAsync(storage).GetAwaiter().GetResult();
        }

        public async Task<YPlaylist> OfTheDayAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistOfDayRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        public YPlaylist OfTheDay(YAuthStorage storage, string kinds)
        {
            return OfTheDayAsync(storage, kinds).GetAwaiter().GetResult();
        }

        public async Task<YPlaylist> DejaVuAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistDejaVuRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        public YPlaylist DejaVu(YAuthStorage storage, string kinds)
        {
            return DejaVuAsync(storage, kinds).GetAwaiter().GetResult();
        }

        public async Task<YPlaylist> PremiereAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistPremiereRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        public YPlaylist Premiere(YAuthStorage storage, string kinds)
        {
            return PremiereAsync(storage, kinds).GetAwaiter().GetResult();
        }

        public async Task<YPlaylist> MissedAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistMissedRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        public YPlaylist Missed(YAuthStorage storage, string kinds)
        {
            return MissedAsync(storage, kinds).GetAwaiter().GetResult();
        }

        #endregion Стандартные плейлисты

        #region Операции над плейлистами

        public async Task<YPlaylist> GetAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        public YPlaylist Get(YAuthStorage storage, string kinds)
        {
            return GetAsync(storage, kinds).GetAwaiter().GetResult();
        }

        public async Task<YPlaylistChangeResponse> CreateAsync(YAuthStorage storage, string name)
        {
            return await new YPlaylistChangeRequest(storage)
                .Create(name)
                .GetResponseAsync<YPlaylistChangeResponse>();
        }

        public YPlaylistChangeResponse Create(YAuthStorage storage, string name)
        {
            return CreateAsync(storage, name).GetAwaiter().GetResult();
        }

        public async Task<bool> RemoveAsync(YAuthStorage storage, string kind)
        {
            try {
                await new YPlaylistRemoveRequest(storage)
                    .Create(kind)
                    .GetResponseAsync();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }

            return false;
        }

        public bool Remove(YAuthStorage storage, string kind)
        {
            return RemoveAsync(storage, kind).GetAwaiter().GetResult();
        }

        public async Task<YInsertTrackToPlaylistResponse> InsertTrackAsync(YAuthStorage storage, string trackId, string albumId,
            string playlistKind)
        {
            return await new YInsertTrackToPlaylistRequest(storage)
                .Create(0, trackId, albumId, playlistKind)
                .GetResponseAsync<YInsertTrackToPlaylistResponse>();
        }

        public YInsertTrackToPlaylistResponse InsertTrack(YAuthStorage storage, string trackId, string albumId, string playlistKind)
        {
            return InsertTrackAsync(storage, trackId, albumId, playlistKind).GetAwaiter().GetResult();
        }

        public async Task<YDeleteTrackFromPlaylistResponse> DeleteTrackAsync(YAuthStorage storage, int from, int to, int revision,
            string playlistKind)
        {
            return await new YDeleteTrackFromPlaylistRequest(storage)
                .Create(from, to, revision, playlistKind)
                .GetResponseAsync<YDeleteTrackFromPlaylistResponse>();
        }

        public YDeleteTrackFromPlaylistResponse DeleteTrack(YAuthStorage storage, int from, int to, int revision, string playlistKind)
        {
            return DeleteTrackAsync(storage, from, to, revision, playlistKind).GetAwaiter().GetResult();
        }

        #endregion Операции над плейлистами

        #endregion Main function
    }
}