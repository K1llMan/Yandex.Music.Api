using System.Threading.Tasks;
using Xunit;

namespace Yandex.Music.Client.Tests.Tests.Artists
{
    public class SearchArtistTests : YandexTests
    {
        [Fact]
        public async Task SearchTrack_GetAllTrecks_ReturnSuccess()
        {
            await Client.AuthorizeAsync(AppSettings.Login, AppSettings.Password);

            await Client.Artist.SearchAsync("U.S. Girls");
        }
    }
}