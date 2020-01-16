using System.Threading.Tasks;
using Yandex.Music.Api;

namespace Yandex.Music.Client.Endpints
{
    public class YandexPlaylistEndpoint
    {
        private IYandexMusicApi _api;
        public YandexPlaylistEndpoint(IYandexMusicApi api)
        {
            _api = api;
        }

        public async Task GetFavoritesAsync()
        {
            var response = await _api.GetPlaylistFavoritesAsync();
        }
    }
}