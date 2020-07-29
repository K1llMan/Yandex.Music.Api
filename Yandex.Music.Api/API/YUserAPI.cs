using System;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Auth;

namespace Yandex.Music.Api.API
{
    public class YUserAPI
    {
        #region Поля

        private YandexMusicApi api;

        #endregion Поля

        #region Вспомогательные функции

        private async Task<YAuth> AuthPassport(AuthStorage storage, string login, string password)
        {
            return await new YAuthorizeRequest(api, storage)
                .Create(login, password)
                .GetResponseAsync<YAuth>();
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public YUserAPI(YandexMusicApi yandex)
        {
            api = yandex;
        }

        public async Task AuthorizeAsync(AuthStorage storage, string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new Exception("Задан пустой токен авторизации.");

            storage.Token = token;


            // Пытаемся получить информацию о пользователе
            YResponse<YAccountResult> authInfo = await GetUserAuthAsync(storage);

            // Если не авторизован, то авторизуем
            if (string.IsNullOrEmpty(authInfo.Result.Account.Uid))
                throw new Exception("Пользователь незалогинен.");

            // Флаг авторизации
            storage.IsAuthorized = true;
            //var authUserDetails = await GetUserAuthDetailsAsync(storage);
            //var authUser = authUserDetails.User;

            storage.User = authInfo.Result.Account;
        }

        public async Task AuthorizeAsync(AuthStorage storage, string login, string password)
        {
            YAuth result = await AuthPassport(storage, login, password);

            await AuthorizeAsync(storage, result.AccessToken);
        }

        public void Authorize(AuthStorage storage, string token)
        {
            AuthorizeAsync(storage, token).GetAwaiter().GetResult();
        }

        public void Authorize(AuthStorage storage, string login, string password)
        {
            AuthorizeAsync(storage, login, password).GetAwaiter().GetResult();
        }

        public async Task<YResponse<YAccountResult>> GetUserAuthAsync(AuthStorage storage)
        {
            return await new YGetAuthInfoRequest(api, storage)
                .Create()
                .GetResponseAsync<YResponse<YAccountResult>>();
        }

        public YResponse<YAccountResult> GetUserAuth(AuthStorage storage)
        {
            return GetUserAuthAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}