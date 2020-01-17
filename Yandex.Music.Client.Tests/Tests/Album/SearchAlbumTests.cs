using System.Threading.Tasks;
using Xunit;

namespace Yandex.Music.Client.Tests.Tests.Album
{
    public class SearchAlbumTests : YandexTests
    {
        [Fact]
        public async Task SearchAlbum_GetAllTrecks_ReturnSuccess()
        {
            await Client.AuthorizeAsync(AppSettings.Login, AppSettings.Password);

            await Client.Album.SearchAsync("U.S. Girls");
        }
    }
}