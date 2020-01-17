using System;
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
            
            Console.WriteLine("123");
        }

        public async Task GetOfDayAsync()
        {
            var response = await _api.GetPlaylistOfDayAsync();
            Console.WriteLine("123");
        }

        public async Task GetDejaVuAsync()
        {
            var response = await _api.GetPlaylistDejaVuAsync();
            
            Console.WriteLine("123");
        }

        public async Task Search(string text, int page = 0)
        {
            var response = await _api.SearchPlaylistAsync(text, page);
            Console.WriteLine("123");
        }
    }
}