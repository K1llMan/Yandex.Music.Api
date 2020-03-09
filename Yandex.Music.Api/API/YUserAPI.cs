using System;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests;
using Yandex.Music.Api.Requests.Auth;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    public class YUserAPI
    {
        #region Вспомогательные функции

        private async Task<YAuthorizeResponse> AuthPassport(YAuthStorage storage)
        {
            var request = new YAuthorizeRequest(storage).Create();

            try {
                using (var response = await request.GetResponseAsync()) {
                    storage.Context.Cookies.Add(response.Cookies);

                    if (response.ResponseUri.AbsoluteUri.Contains(YEndpoints.Passport))
                        return new YAuthorizeResponse {
                            IsAuthorized = false,
                            User = null
                        };

                    return new YAuthorizeResponse {
                        IsAuthorized = true,
                        User = null
                    };
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);

                return new YAuthorizeResponse {
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
            var authInfo = await GetUserAuthAsync(storage);

            // Если не авторизован, то авторизуем
            if (!authInfo.Logged) {
                var result = await AuthPassport(storage);
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
            return await new YGetAuthInfoRequest(storage)
                .Create()
                .GetResponseAsync<YAuthInfoResponse>();
        }

        public YAuthInfoResponse GetUserAuth(YAuthStorage storage)
        {
            return GetUserAuthAsync(storage).GetAwaiter().GetResult();
        }

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

        #endregion Основные функции
    }
}