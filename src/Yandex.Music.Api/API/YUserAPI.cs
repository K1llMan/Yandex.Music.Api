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

        private bool GetCsrfTokenAsync(AuthStorage storage)
        {
            using HttpResponseMessage authMethodsResponse = new YGetAuthMethodsBuilder(api, storage)
                .Build(null)
                .GetResponseAsync()
                .GetAwaiter()
                .GetResult();

            if (!authMethodsResponse.IsSuccessStatusCode)
                throw new HttpRequestException("Невозможно получить CFRF-токен.");

            string responseString = authMethodsResponse.Content
                .ReadAsStringAsync()
                .GetAwaiter()
                .GetResult();
            Match match = Regex.Match(responseString, "\"csrf_token\" value=\"([^\"]+)\"");

            if (!match.Success || match.Groups.Count < 2)
                return false;

            storage.AuthToken = new YAuthToken {
                CsfrToken = match.Groups[1].Value
            };

            return true;
        }

        private Task<bool> LoginByCookiesAsync(AuthStorage storage)
        {
            if (storage.AuthToken == null)
                throw new AuthenticationException("Невозможно инициализировать сессию входа.");

            return new YAuthCookiesBuilder(api, storage)
                .Build(null)
                .GetResponseAsync()
                .ContinueWith(task => {
                    YAccessToken accessToken = task.Result;

                    storage.IsAuthorized = !string.IsNullOrEmpty(accessToken.AccessToken);

                    storage.AccessToken = accessToken;
                    storage.Token = accessToken.AccessToken;
                })
                .ContinueWith(_ => {
                    YShortInfo validateTokenResponse = new YValidateTokenBuilder(api, storage)
                        .Build(null)
                        .GetResponseAsync()
                        .GetAwaiter()
                        .GetResult();

                    if (validateTokenResponse.Status != YAuthStatus.Ok)
                        throw new Exception("Вход в аккаунт не выполнен.");

                    storage.IsAuthorized = !string.IsNullOrWhiteSpace(validateTokenResponse.Uid);

                    return storage.IsAuthorized;
                });
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
        [Obsolete("Работает лишь на малом количестве аккаунтов, рекомендуется авторизация по токену.")]
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
        [Obsolete("Работает лишь на малом количестве аккаунтов, рекомендуется авторизация по токену.")]
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
        /// Создание сеанса и получение доступных методов авторизации
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        public Task<YAuthTypes> CreateAuthSessionAsync(AuthStorage storage, string userName)
        {
            if (!GetCsrfTokenAsync(storage))
                throw new Exception("Невозможно инициализировать сессию входа.");

            return new YAuthLoginUserBuilder(api, storage)
                .Build((storage.AuthToken.CsfrToken, userName))
                .GetResponseAsync()
                .ContinueWith(task => {
                    YAuthTypes types = task.Result;
                    storage.AuthToken.TrackId = types.TrackId;

                    return types;
                });
        }

        /// <summary>
        /// Создание сеанса и получение доступных методов авторизации
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        public YAuthTypes CreateAuthSession(AuthStorage storage, string userName)
        {
            return CreateAuthSessionAsync(storage, userName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение ссылки на QR-код
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<string> GetAuthQRLinkAsync(AuthStorage storage)
        {
            if (!GetCsrfTokenAsync(storage))
                throw new Exception("Невозможно инициализировать сессию входа.");

            return new YAuthQRBuilder(api, storage)
                .Build(null)
                .GetResponseAsync()
                .ContinueWith(task => {
                    YAuthQR result = task.Result;

                    if (result.Status != YAuthStatus.Ok)
                        return string.Empty;

                    storage.AuthToken = new YAuthToken {
                        TrackId = result.TrackId,
                        CsfrToken = result.CsrfToken
                    };

                    return $"https://passport.yandex.ru/auth/magic/code/?track_id={result.TrackId}";
                });
        }

        /// <summary>
        /// Получение ссылки на QR-код
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public string GetAuthQRLink(AuthStorage storage)
        {
            return GetAuthQRLinkAsync(storage).GetAwaiter().GetResult();
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
                return await new YAuthLoginQRBuilder(api, storage)
                    .Build(null)
                    .GetResponseAsync()
                    .ContinueWith(task => {
                        YAuthQRStatus qrStatus = task.Result;
                        if (qrStatus.Status != YAuthStatus.Ok)
                            return qrStatus;

                        bool ok = LoginByCookiesAsync(storage).GetAwaiter().GetResult();
                        if (!ok)
                            throw new AuthenticationException("Ошибка авторизации по QR.");

                        return qrStatus;
                    });
            }
            catch (Exception ex)
            {
                throw new AuthenticationException("Ошибка авторизации по QR.", ex);
            }
        }

        /// <summary>
        /// Авторизация по QR-коду
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YAuthQRStatus AuthorizeByQR(AuthStorage storage)
        {
            return AuthorizeByQRAsync(storage).GetAwaiter().GetResult();
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

            return new YAuthCaptchaBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение <see cref="YAuthCaptcha"/>
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YAuthCaptcha GetCaptcha(AuthStorage storage)
        {
            return GetCaptchaAsync(storage).GetAwaiter().GetResult();
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

            return new YAuthLoginCaptchaBuilder(api, storage)
                .Build(captchaValue)
                .GetResponseAsync();
        }

        /// <summary>
        /// Авторизация по captcha
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="captchaValue">Значение captcha</param>
        /// <returns></returns>
        public YAuthBase AuthorizeByCaptcha(AuthStorage storage, string captchaValue)
        {
            return AuthorizeByCaptchaAsync(storage, captchaValue).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение письма авторизации на почту пользователя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YAuthLetter> GetAuthLetterAsync(AuthStorage storage)
        {
            return new YAuthLetterBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение письма авторизации на почту пользователя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YAuthLetter GetAuthLetter(AuthStorage storage)
        {
            return GetAuthLetterAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Авторизация после подтверждения входа через письмо
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<bool> AuthorizeByLetterAsync(AuthStorage storage)
        {
            YAuthLetterStatus status = new YAuthLoginLetterBuilder(api, storage)
                .Build(null)
                .GetResponseAsync()
                .GetAwaiter()
                .GetResult();

            if (status.Status == YAuthStatus.Ok && !status.MagicLinkConfirmed)
                throw new Exception("Не подтвержден вход посредством e-mail.");

            return LoginByCookiesAsync(storage);
        }

        /// <summary>
        /// Авторизация после подтверждения входа через письмо
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public bool AuthorizeByLetter(AuthStorage storage)
        {
            return AuthorizeByLetterAsync(storage).GetAwaiter().GetResult();
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

            YAuthBase response = await new YAuthAppPasswordBuilder(api, storage)
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
        /// Авторизация с помощью пароля из приложения Яндекс
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public YAuthBase AuthorizeByAppPassword(AuthStorage storage, string password)
        {
            return AuthorizeByAppPasswordAsync(storage, password).GetAwaiter().GetResult();
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
        /// Получение <see cref="YAccessToken"/> после авторизации с помощью QR, e-mail, пароля из приложения
        /// </summary>
        public YAccessToken GetAccessToken(AuthStorage storage)
        {
            return GetAccessTokenAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}
