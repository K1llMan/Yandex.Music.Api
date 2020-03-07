using System;
using System.Net;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Playlist;
using Yandex.Music.Api.Requests.Track;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    public class YPlaylistAPI
    {
        #region Поля

        private readonly YandexMusicApi api;

        #endregion Поля

        #region Вспомогательные функции

        #endregion Вспомогательные функции

        #region Основные функции

        #region Стандартные плейлисты

        public async Task<YPlaylist> OfDayAsync(YAuthStorage storage)
        {
            var request = new YGetPlaylistOfDayRequest(storage.Context).Create(storage.User.Uid, storage.User.Lang);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YPlaylist>(storage.Context, response, "playlist");
            }
        }

        public YPlaylist OfDay(YAuthStorage storage)
        {
            return OfDayAsync(storage).GetAwaiter().GetResult();
        }

        public async Task<YPlaylistFavoritesResponse> FavoritesAsync(YAuthStorage storage)
        {
            var request = new YGetPlaylistFavoritesRequest(storage.Context).Create(storage.User.Login, storage.User.Lang);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YPlaylistFavoritesResponse>(storage.Context, response);
            }
        }

        public YPlaylistFavoritesResponse Favorites(YAuthStorage storage)
        {
            return FavoritesAsync(storage).GetAwaiter().GetResult();
        }

        public async Task<YPlaylist> DejaVuAsync(YAuthStorage storage)
        {
            var request = new YGetPlaylistDejaVuRequest(storage.Context).Create(storage.User.Uid, storage.User.Lang);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YPlaylist>(storage.Context, response, "playlist");
            }
        }

        public YPlaylist DejaVu(YAuthStorage storage)
        {
            return DejaVuAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Стандартные плейлисты

        #region Операции над плейлистами

        public async Task<YPlaylist> GetAsync(YAuthStorage storage, string kinds)
        {
            var request = new YGetPlaylistRequest(storage.Context).Create(kinds);

            using (var response = (HttpWebResponse) request.GetResponse()) {
                return await api.GetDataFromResponseAsync<YPlaylist>(storage.Context, response, "playlist");
            }
        }

        public YPlaylist Get(YAuthStorage storage, string kinds)
        {
            return GetAsync(storage, kinds).GetAwaiter().GetResult();
        }

        public async Task<YPlaylistChangeResponse> CreateAsync(YAuthStorage storage, string name)
        {
            var request = new YPlaylistChangeRequest(storage.Context).Create(name, storage.User.Sign, storage.User.Experiments,
                storage.User.Uid, storage.User.Login);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YPlaylistChangeResponse>(storage.Context, response);
            }
        }

        public YPlaylistChangeResponse Create(YAuthStorage storage, string name)
        {
            return CreateAsync(storage, name).GetAwaiter().GetResult();
        }

        public async Task<bool> RemoveAsync(YAuthStorage storage, long kind)
        {
            try {
                var request = new YPlaylistRemoveRequest(storage.Context).Create(kind, storage.User.Sign, storage.User.Experiments,
                    storage.User.Uid, storage.User.Login);
                await request.GetResponseAsync();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }

            return false;
        }

        public bool Remove(YAuthStorage storage, long kind)
        {
            return RemoveAsync(storage, kind).GetAwaiter().GetResult();
        }

        public async Task<YInsertTrackToPlaylistResponse> InsertTrackAsync(YAuthStorage storage, string trackId, string albumId,
            string playlistKind)
        {
            var request = new YInsertTrackToPlaylistRequest(storage.Context).Create(storage.User.Uid, 0, trackId, albumId,
                playlistKind,
                storage.User.Lang, storage.User.Sign, storage.User.Uid, storage.User.Login, storage.User.Experiments);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YInsertTrackToPlaylistResponse>(storage.Context, response);
            }
        }

        public YInsertTrackToPlaylistResponse InsertTrack(YAuthStorage storage, string trackId, string albumId, string playlistKind)
        {
            return InsertTrackAsync(storage, trackId, albumId, playlistKind).GetAwaiter().GetResult();
        }

        public async Task<YDeleteTrackFromPlaylistResponse> DeleteTrackAsync(YAuthStorage storage, int from, int to, int revision,
            string playlistKind)
        {
            var request = new YDeleteTrackFromPlaylistRequest(storage.Context).Create(storage.User.Uid, from, to, revision,
                playlistKind,
                storage.User.Lang, storage.User.Sign, storage.User.Uid, storage.User.Login, storage.User.Experiments);
            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YDeleteTrackFromPlaylistResponse>(storage.Context, response);
            }
        }

        public YDeleteTrackFromPlaylistResponse DeleteTrack(YAuthStorage storage, int from, int to, int revision, string playlistKind)
        {
            return DeleteTrackAsync(storage, from, to, revision, playlistKind).GetAwaiter().GetResult();
        }

        #endregion Операции над плейлистами

        public YPlaylistAPI(YandexMusicApi yandexApi)
        {
            api = yandexApi;
        }

        #endregion Main function
    }
}