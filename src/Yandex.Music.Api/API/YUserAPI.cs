using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для пользователя
    /// </summary>
    public partial class YUserAPI : YCommonAPI
    {
        #region Основные функции

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
        /// Получение информации об аккаунте
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
        public YAuthTypes CreateAuthSession(AuthStorage storage, string userName)
        {
            return CreateAuthSessionAsync(storage, userName).GetAwaiter().GetResult();
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
        public YAuthQRStatus AuthorizeByQR(AuthStorage storage)
        {
            return AuthorizeByQRAsync(storage).GetAwaiter().GetResult();
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
        public YAuthBase AuthorizeByCaptcha(AuthStorage storage, string captchaValue)
        {
            return AuthorizeByCaptchaAsync(storage, captchaValue).GetAwaiter().GetResult();
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
        public YAuthBase AuthorizeByAppPassword(AuthStorage storage, string password)
        {
            return AuthorizeByAppPasswordAsync(storage, password).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение <see cref="YAccessToken"/> после авторизации с помощью QR, e-mail, пароля из приложения
        /// </summary>
        public YAccessToken GetAccessToken(AuthStorage storage)
        {
            return GetAccessTokenAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение информации о пользователе через логин Яндекса
        /// </summary>
        public YLoginInfo GetLoginInfo(AuthStorage storage)
        {
            return GetLoginInfoAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}
