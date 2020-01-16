using Yandex.Music.Api;

namespace Yandex.Music.Client.Endpints
{
    public class YandexTrackEndpoint
    {
        private IYandexMusicApi _api;
        public YandexTrackEndpoint(IYandexMusicApi api)
        {
            _api = api;
        }
    }
}