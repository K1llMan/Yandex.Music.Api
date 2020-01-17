using System.Threading.Tasks;
using Xunit;

namespace Yandex.Music.Client.Tests.Tests.Playlist
{
    public class PlaylistFavoritesTests : YandexTests
    {
        [Fact]
        public async Task PlaylistFavorites_GetAllTrecks_ReturnSuccess()
        {
            await Client.AuthorizeAsync(AppSettings.Login, AppSettings.Password);

//            var playlistFavorites = 
                await Client.Playlist.GetFavoritesAsync();
        }
        
        [Fact]
        public async Task PlaylistOfDay_GetAllTrecks_ReturnSuccess()
        {
            await Client.AuthorizeAsync(AppSettings.Login, AppSettings.Password);

//            var playlistFavorites = 
                await Client.Playlist.GetOfDayAsync();
        }
        
        [Fact]
        public async Task PlaylistDejaVu_GetAllTrecks_ReturnSuccess()
        {
            await Client.AuthorizeAsync(AppSettings.Login, AppSettings.Password);

//            var playlistFavorites = 
                await Client.Playlist.GetDejaVuAsync();
        }
        
        [Fact]
        public async Task PlaylistSearch_GetAllTrecks_ReturnSuccess()
        {
            await Client.AuthorizeAsync(AppSettings.Login, AppSettings.Password);

//            var playlistFavorites = 
                await Client.Playlist.Search("1");
        }
    }
}