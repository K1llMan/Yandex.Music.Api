using System;
using System.Net;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests;
using Yandex.Music.Api.Requests.Auth;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    public class YUserAPI
    {
        #region Поля

        private readonly YandexMusicApi api;

        #endregion Поля

        #region Вспомогательные функции

        private async Task<YAuthorizeResponse> AuthPassport(YAuthStorage storage)
        {
            var request = new YAuthorizeRequest(storage.Context).Create(storage.User.Login, storage.User.Password);

            try
            {
                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    storage.Context.Cookies.Add(response.Cookies);

                    if (response.ResponseUri.AbsoluteUri.Contains(YEndpoints.Passport))
                        return new YAuthorizeResponse
                        {
                            IsAuthorized = false,
                            User = null
                        };

                    return new YAuthorizeResponse
                    {
                        IsAuthorized = true,
                        User = null
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return new YAuthorizeResponse
                {
                    IsAuthorized = false,
                    User = null
                };
            }
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public async Task AuthorizeAsync(YAuthStorage storage)
        {
            // Пытаемся получить информацию о пользователе
            YAuthInfoResponse authInfo = await GetUserAuthAsync(storage);

            // Если не авторизован, то авторизуем
            if (!authInfo.Logged) {
                YAuthorizeResponse result = await AuthPassport(storage);
                if (!result.IsAuthorized)
                    return;

                authInfo = await GetUserAuthAsync(storage);
            }

            // Флаг авторизации
            storage.IsAuthorized = authInfo.Logged;

            var authUserDetails = await GetUserAuthDetailsAsync(storage);
            var authUser = authUserDetails.User;

            storage.User = new YUser {
                Uid = authUser.Uid,
                Login = authUser.Login,
                Password = storage.User.Password,
                Name = authUser.Name,
                Sign = authUser.Sign,
                DeviceId = authUser.DeviceId,
                FirstName = authUser.FirstName,
                LastName = authUser.LastName,
                Experiments = authUserDetails.Experiments,
                Lang = authInfo.Lang,
                Timestamp = authInfo.Timestamp,
                YandexId = authInfo.YandexuId
            };
        }

        public void Authorize(YAuthStorage storage)
        {
            AuthorizeAsync(storage).GetAwaiter().GetResult();
        }

        public async Task<YAuthInfoResponse> GetUserAuthAsync(YAuthStorage storage)
        {
            var request = new YGetAuthInfoRequest(storage.Context).Create(storage.User.Login, storage.Context.GetTimeInterval());

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YAuthInfoResponse>(storage.Context, response);
            }
        }

        public YAuthInfoResponse GetUserAuth(YAuthStorage storage)
        {
            return GetUserAuthAsync(storage).GetAwaiter().GetResult();
        }

        public async Task<YAuthInfoUserResponse> GetUserAuthDetailsAsync(YAuthStorage storage)
        {
            var request = new YGetAuthInfoUserRequest(storage.Context).Create(storage.User.Uid, storage.User.Login, storage.User.Lang);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YAuthInfoUserResponse>(storage.Context, response);
            }
        }

        public YAuthInfoUserResponse GetUserAuthDetails(YAuthStorage storage)
        {
            return GetUserAuthDetailsAsync(storage).GetAwaiter().GetResult();
        }

        public YUserAPI(YandexMusicApi yandexApi)
        {
            api = yandexApi;
        }

        #endregion Основные функции
    }
}