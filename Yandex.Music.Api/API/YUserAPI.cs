using System;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests;
using Yandex.Music.Api.Requests.Auth;
using Yandex.Music.Api.Requests.Yandex;
using Yandex.Music.Api.Responses;

using YAccount = Yandex.Music.Api.Common.YAccount;

namespace Yandex.Music.Api.API
{
    public class YUserAPI
    {
        #region Вспомогательные функции

        private async Task<YAuthResponse> AuthPassport(YAuthStorage storage, string login, string password)
        {
            return await new YAuthorizeRequest(storage)
                .Create(login, password)
                .GetResponseAsync<YAuthResponse>();
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public async Task AuthorizeAsync(YAuthStorage storage, string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new Exception("Задан пустой токен авторизации.");

            storage.Token = token;
            // Пытаемся получить информацию о пользователе
            YAccount authInfo = await GetUserAuthAsync(storage);

            // Если не авторизован, то авторизуем
            if (string.IsNullOrEmpty(authInfo.Uid))
                throw new Exception("Пользователь незалогинен.");

            // Флаг авторизации
            storage.IsAuthorized = true;

            //var authUserDetails = await GetUserAuthDetailsAsync(storage);
            //var authUser = authUserDetails.User;

            storage.User = new YUser {
                Uid = authInfo.Uid,
                Login = authInfo.Login,
                Name = authInfo.FullName,
                //DeviceId = authUser.DeviceId,
                FirstName = authInfo.FirstName,
                SecondName = authInfo.SecondName,
                //Experiments = authUserDetails.Experiments,
                //Lang = authInfo.Lang,
                //Timestamp = authInfo.Timestamp,
                //YandexId = authInfo.YandexuId
            };
        }

        public async Task AuthorizeAsync(YAuthStorage storage, string login, string password)
        {
            YAuthResponse result = await AuthPassport(storage, login, password);

            await AuthorizeAsync(storage, result.AccessToken);
        }

        public void Authorize(YAuthStorage storage, string token)
        {
            AuthorizeAsync(storage, token).GetAwaiter().GetResult();
        }

        public void Authorize(YAuthStorage storage, string login, string password)
        {
            AuthorizeAsync(storage, login, password).GetAwaiter().GetResult();
        }

        public async Task<YAccount> GetUserAuthAsync(YAuthStorage storage)
        {
            return await new YGetAuthInfoRequest(storage)
                .Create()
                .GetResponseAsync<YAccount>("account");
        }

        public YAccount GetUserAuth(YAuthStorage storage)
        {
            return GetUserAuthAsync(storage).GetAwaiter().GetResult();
        }

        /*
        public async Task<YAuthInfoUserResponse> GetUserAuthDetailsAsync(YAuthStorage storage)
        {
            return await new YGetAuthInfoUserRequest(storage)
                .Create()
                .GetResponseAsync<YAuthInfoUserResponse>();
        }

        public YAuthInfoUserResponse GetUserAuthDetails(YAuthStorage storage)
        {
            return GetUserAuthDetailsAsync(storage).GetAwaiter().GetResult();
        }

        public async Task<YGetCookieResponse> GetYandexCookieAsync(YAuthStorage storage)
        {
            return await new YGetCookieRequest(storage)
                .Create()
                .GetResponseAsync<YGetCookieResponse>();
        }

        public YGetCookieResponse GetYandexCookie(YAuthStorage storage)
        {
            return GetYandexCookieAsync(storage).GetAwaiter().GetResult();
        }
        */

        #endregion Основные функции
    }
}