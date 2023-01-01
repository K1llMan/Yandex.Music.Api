using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Account;

namespace Yandex.Music.Api.API
{
    public class YUserAPI : YCommonAPI
    {
        #region Вспомогательные функции

        private Task<YAccessToken> AuthPassport(AuthStorage storage, string login, string password)
        {
            return new YAuthorizeBuilder(api, storage)
                .Build((login, password))
                .GetResponseAsync();
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public YUserAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="token">Токен авторизации</param>
        /// <returns></returns>
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

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="token">Токен авторизации</param>
        /// <returns></returns>
        public void Authorize(AuthStorage storage, string token)
        {
            AuthorizeAsync(storage, token).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task AuthorizeAsync(AuthStorage storage, string login, string password)
        {
            YAccessToken result = await AuthPassport(storage, login, password);

            storage.AccessToken = result;

            await AuthorizeAsync(storage, result.AccessToken);
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public void Authorize(AuthStorage storage, string login, string password)
        {
            AuthorizeAsync(storage, login, password).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение информации об авторизации
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YAccountResult>> GetUserAuthAsync(AuthStorage storage)
        {
            return new YGetAuthInfoBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение информации об авторизации
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YAccountResult> GetUserAuth(AuthStorage storage)
        {
            return GetUserAuthAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create login session and return supported auth methods.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="userName">Name of the user.</param>
        public async Task<YAuthTypes> LoginUserAsync(AuthStorage storage, string userName)
        {
            if (!await GetCsrfTokenAsync(storage))
            {
                throw new Exception("Unable to get csrf token.");
            }

            var response = await new YAuthLoginUserBuilder(api, storage)
                .Build((storage.AuthToken.CsfrToken, userName))
                .GetResponseAsync();

            storage.AuthToken.TrackId = response.TrackId;

            return response;
        }

        /// <summary>
        /// Get link to QR-code auth.
        /// </summary>
        public async Task<string> GetAuthQRLinkAsync(AuthStorage storage)
        {
            if (!await GetCsrfTokenAsync(storage))
            {
                throw new Exception("Unable to get csrf token.");
            }

            var response = await new YAuthQRBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            if (response.Status.Equals("ok"))
            {
                storage.AuthToken = new YAuthToken
                {
                    TrackId = response.TrackId,
                    CsfrToken = response.CsrfToken
                };

                return $"https://passport.yandex.ru/auth/magic/code/?track_id={response.TrackId}";
            }

            return string.Empty;
        }

        /// <summary>
        /// Выполнить вход после подтверждения QR кода.
        /// </summary>
        public async Task<bool> LoginQRAsync(AuthStorage storage)
        {
            if (storage.AuthToken == null)
            {
                throw new Exception("Не выполнен запрос на авторизацию по QR.");
            }

            using var response = await new YAuthLoginQRBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            var responseData = await storage.Provider.GetDataFromResponseAsync<YAuthQRStatus>(api, response);

            if (responseData == null || !responseData.Status.Equals("ok"))
            {
                throw new Exception("Не выполнен запрос на авторизация по QR.");
            }

            await LoginByCookiesAsync(storage);

            return true;
        }

        /// <summary>
        /// Gets the captcha.
        /// </summary>
        public Task<YAuthCaptcha> GetCaptchaAsync(AuthStorage storage)
        {
            if (storage.AuthToken == null ||
                string.IsNullOrWhiteSpace(storage.AuthToken.CsfrToken))
            {
                throw new AuthenticationException($"Need login first. Execute {nameof(LoginUserAsync)} before using.");
            }

            return new Requests.Account.YAuthCaptchaBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Logins the by captcha.
        /// </summary>
        public Task<YAuthBase> LoginByCaptchaAsync(AuthStorage storage, string captchaValue)
        {
            if (storage.AuthToken == null ||
                string.IsNullOrWhiteSpace(storage.AuthToken.CsfrToken))
            {
                throw new AuthenticationException($"Need login first. Execute {nameof(LoginUserAsync)} before it.");
            }

            return new YAuthLoginCaptchaBuilder(api, storage)
                .Build(captchaValue)
                .GetResponseAsync();
        }

        /// <summary>
        /// Gets the authentication letter.
        /// </summary>
        public Task<YAuthLetter> GetAuthLetterAsync(AuthStorage storage)
        {
            return new YAuthLetterBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Authentications by the letter.
        /// </summary>
        public async Task<YAccessToken> AuthLetterAsync(AuthStorage storage)
        {
            var status = await new YAuthLoginLetterBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            if (status.Status.Equals("ok") && !status.MagicLinkConfirmed)
            {
                throw new Exception("Не подтвержден вход посредством mail.");
            }

            return await LoginByCookiesAsync(storage);
        }

        /// <summary>
        /// Authenticate by the application password.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="password">The password from yandex key application.</param>
        public async Task<YAccessToken> AuthAppPassword(AuthStorage storage, string password)
        {
            if (storage.AuthToken == null || string.IsNullOrWhiteSpace(storage.AuthToken.CsfrToken))
            {
                throw new AuthenticationException($"Need login first. Execute {nameof(LoginUserAsync)} before using.");
            }

            var response = await new YAuthAppPasswordBuilder(api, storage)
                .Build(password)
                .GetResponseAsync();

            if (!response.Status.Equals("ok") || !string.IsNullOrWhiteSpace(response.RedirectUrl))
            {
                throw new Exception("Ошибка авторизации.");
            }

            return await LoginByCookiesAsync(storage);
        }

        private async Task<YAccessToken> LoginByCookiesAsync(AuthStorage storage)
        {
            if (storage.AuthToken == null)
            {
                throw new Exception("Не выполнен запрос на авторизацию.");
            }

            var auth = await new YAuthCookiesBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            storage.IsAuthorized = !string.IsNullOrEmpty(auth.AccessToken);

            storage.AccessToken = auth;
            storage.Token = auth.AccessToken;

            return auth;
        }

        private async Task<bool> GetCsrfTokenAsync(AuthStorage storage)
        {
            using var authMethodsResponse = await new YGetAuthMethodsBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            if (!authMethodsResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Invalid request");
            }

            var responseString = await authMethodsResponse.Content.ReadAsStringAsync();
            var match = Regex.Match(responseString, "\"csrf_token\" value=\"([^\"]+)\"");

            if (!match.Success || match.Groups.Count < 2)
            {
                return false;
            }

            storage.AuthToken = new YAuthToken
            {
                CsfrToken = match.Groups[1].Value
            };

            return true;
        }

        #endregion Основные функции
    }
}