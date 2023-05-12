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
    /// <summary>
    /// API для пользователя
    /// </summary>
    public partial class YUserAPI : YCommonAPI
    {
        #region Вспомогательные функции

        private async Task<bool> GetCsrfTokenAsync(AuthStorage storage)
        {
            using HttpResponseMessage authMethodsResponse = await new YGetAuthMethodsBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            if (!authMethodsResponse.IsSuccessStatusCode)
                throw new HttpRequestException("Невозможно получить CFRF-токен.");

            string responseString = await authMethodsResponse.Content
                .ReadAsStringAsync();
            Match match = Regex.Match(responseString, "\"csrf_token\" value=\"([^\"]+)\"");

            if (!match.Success || match.Groups.Count < 2)
                return false;

            storage.AuthToken = new YAuthToken {
                CsfrToken = match.Groups[1].Value
            };

            return true;
        }

        private async Task<bool> LoginByCookiesAsync(AuthStorage storage)
        {
            if (storage.AuthToken == null)
                throw new AuthenticationException("Невозможно инициализировать сессию входа.");

            YAccessToken accessToken = await new YGetAuthCookiesBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            storage.IsAuthorized = !string.IsNullOrEmpty(accessToken.AccessToken);

            storage.AccessToken = accessToken;
            storage.Token = accessToken.AccessToken;

            YShortAccountInfo validateTokenResponse = await new YGetShortAccountInifoBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            if (validateTokenResponse.Status != YAuthStatus.Ok)
                throw new Exception("Вход в аккаунт не выполнен.");

            storage.IsAuthorized = !string.IsNullOrWhiteSpace(validateTokenResponse.Uid);

            return storage.IsAuthorized;
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
            storage.User = authInfo.Result.Account;
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
        /// Создание сеанса и получение доступных методов авторизации
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        public async Task<YAuthTypes> CreateAuthSessionAsync(AuthStorage storage, string userName)
        {
            if (!await GetCsrfTokenAsync(storage))
                throw new Exception("Невозможно инициализировать сессию входа.");

            YAuthTypes types = await new YGetAuthLoginUserBuilder(api, storage)
                .Build((storage.AuthToken.CsfrToken, userName))
                .GetResponseAsync();

            storage.AuthToken.TrackId = types.TrackId;

            return types;
        }

        /// <summary>
        /// Получение ссылки на QR-код
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<string> GetAuthQRLinkAsync(AuthStorage storage)
        {
            if (!await GetCsrfTokenAsync(storage))
                throw new Exception("Невозможно инициализировать сессию входа.");

            YAuthQR result = await new YGetAuthQRBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            if (result.Status != YAuthStatus.Ok)
                return string.Empty;

            storage.AuthToken = new YAuthToken {
                TrackId = result.TrackId,
                CsfrToken = result.CsrfToken
            };

            return $"https://passport.yandex.ru/auth/magic/code/?track_id={result.TrackId}";
        }

        /// <summary>
        /// Авторизация по QR-коду
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YAuthQRStatus> AuthorizeByQRAsync(AuthStorage storage)
        {
            if (storage.AuthToken == null)
                throw new Exception("Не выполнен запрос на авторизацию по QR.");

            try
            {
                YAuthQRStatus qrStatus = await new YGetAuthLoginQRBuilder(api, storage)
                    .Build(null)
                    .GetResponseAsync();
                        if (qrStatus.Status != YAuthStatus.Ok)
                            return qrStatus;

                bool ok = await LoginByCookiesAsync(storage);
                if (!ok)
                    throw new AuthenticationException("Ошибка авторизации по QR.");

                return qrStatus;
            }
            catch (Exception ex)
            {
                throw new AuthenticationException("Ошибка авторизации по QR.", ex);
            }
        }

        /// <summary>
        /// Получение <see cref="YAuthCaptcha"/>
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YAuthCaptcha> GetCaptchaAsync(AuthStorage storage)
        {
            if (storage.AuthToken == null || string.IsNullOrWhiteSpace(storage.AuthToken.CsfrToken))
                throw new AuthenticationException($"Не найдена сессия входа. Выполните {nameof(CreateAuthSessionAsync)} перед использованием.");

            return new YGetAuthCaptchaBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Авторизация по captcha
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="captchaValue">Значение captcha</param>
        /// <returns></returns>
        public Task<YAuthBase> AuthorizeByCaptchaAsync(AuthStorage storage, string captchaValue)
        {
            if (storage.AuthToken == null || string.IsNullOrWhiteSpace(storage.AuthToken.CsfrToken))
                throw new AuthenticationException($"Не найдена сессия входа. Выполните {nameof(CreateAuthSessionAsync)} перед использованием.");

            return new YGetAuthLoginCaptchaBuilder(api, storage)
                .Build(captchaValue)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение письма авторизации на почту пользователя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YAuthLetter> GetAuthLetterAsync(AuthStorage storage)
        {
            return new YGetAuthLetterBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Авторизация после подтверждения входа через письмо
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<bool> AuthorizeByLetterAsync(AuthStorage storage)
        {
            YAuthLetterStatus status = await new YGetAuthLoginLetterBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            if (status.Status == YAuthStatus.Ok && !status.MagicLinkConfirmed)
                throw new Exception("Не подтвержден вход посредством e-mail.");

            return await LoginByCookiesAsync(storage);
        }

        /// <summary>
        /// Авторизация с помощью пароля из приложения Яндекс
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<YAuthBase> AuthorizeByAppPasswordAsync(AuthStorage storage, string password)
        {
            if (storage.AuthToken == null || string.IsNullOrWhiteSpace(storage.AuthToken.CsfrToken))
                throw new AuthenticationException($"Не найдена сессия входа. Выполните {nameof(CreateAuthSessionAsync)} перед использованием.");

            YAuthBase response = await new YGetAuthAppPasswordBuilder(api, storage)
                .Build(password)
                .GetResponseAsync();

            if (response.Status == YAuthStatus.Ok)
            {
                bool ok = await LoginByCookiesAsync(storage);
                if (!ok)
                    throw new AuthenticationException("Ошибка авторизации.");
            }

            return response;
        }

        /// <summary>
        /// Получение <see cref="YAccessToken"/> после авторизации с помощью QR, e-mail, пароля из приложения
        /// </summary>
        public async Task<YAccessToken> GetAccessTokenAsync(AuthStorage storage)
        {
            if (storage.AuthToken == null)
                throw new Exception("Не найдена сессия входа.");

            YAccessToken accessToken = await new YGetMusicTokenBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            storage.Token = accessToken.AccessToken;

            return accessToken;
        }

        /// <summary>
        /// Получение информации о пользователе через логин Яндекса
        /// </summary>
        public Task<YLoginInfo> GetLoginInfoAsync(AuthStorage storage)
        {
            return new YGetLoginInfoBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        #endregion Основные функции
    }
}
