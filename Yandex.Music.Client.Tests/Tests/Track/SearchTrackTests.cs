using System.Threading.Tasks;
using Xunit;

namespace Yandex.Music.Client.Tests.Tests.Track
{
    public class SearchTrackTests : YandexTests
    {
        [Fact]
        public async Task SearchTrack_GetAllTrecks_ReturnSuccess()
        {
            await Client.AuthorizeAsync(AppSettings.Login, AppSettings.Password);

//            var playlistFavorites = 
                await Client.Track.SearchTrackAsync("Damn That Valley");
        }
    }
}