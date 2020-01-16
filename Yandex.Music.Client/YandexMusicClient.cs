using System.Threading.Tasks;
using Yandex.Music.Api;
using Yandex.Music.Client.Endpints;

namespace Yandex.Music.Client
{
    public class YandexMusicClient
    {
        public YandexTrackEndpoint Track { get; set; }
        public YandexPlaylistEndpoint Playlist { get; set; }
        public IYandexMusicApi Api { get; set; }
        public YandexMusicClient()
        {
            Api = new YandexMusicApi();
            Track = new YandexTrackEndpoint(Api);
            Playlist = new YandexPlaylistEndpoint(Api);
        }

        public async Task AuthorizeAsync(string login, string password)
        {
            var user = await Api.AuthorizeAsync(login, password, false);
            
            
        }
    }
}