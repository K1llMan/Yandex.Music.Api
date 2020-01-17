using System.Threading.Tasks;
using Xunit;

namespace Yandex.Music.Client.Tests.Tests.User
{
    public class SearchUserTests : YandexTests
    {
        [Fact]
        public async Task SearchUser_GetAllTrecks_ReturnSuccess()
        {
            await Client.AuthorizeAsync(AppSettings.Login, AppSettings.Password);

//            var playlistFavorites = 
                await Client.User.SearchAsync("Winster332");
        }
    }
}