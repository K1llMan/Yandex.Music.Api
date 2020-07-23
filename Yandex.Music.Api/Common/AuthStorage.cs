using System.Net;

using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests;

namespace Yandex.Music.Api.Common
{
    /// <summary>
    /// Хранилище данных пользователя
    /// </summary>
    public class AuthStorage
    {
        #region Свойства

        /// <summary>
        /// Http-контекст
        /// </summary>
        public HttpContext Context { get; }

        public DebugSettings Debug { get; set; }

        /// <summary>
        /// Флаг авторизации
        /// </summary>
        public bool IsAuthorized { get; internal set; }

        /// <summary>
        /// Токен авторизации
        /// </summary>
        public string Token { get; internal set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public YAccount User { get; set; }

        #endregion

        #region Вспомогательные функции

        #endregion Вспомогательные функции

        #region Основные функции

        public void SetHeaders(HttpWebRequest request)
        {
            if (!string.IsNullOrEmpty(Token))
                request.Headers.Add("Authorization", $"OAuth {Token}");
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public AuthStorage(DebugSettings settings = null)
        {
            User = new YAccount();
            Context = new HttpContext();
            Debug = settings;

            if (Debug != null && Debug.ClearDirectory)
                Debug.Clear();
        }

        /// <summary>
        /// Установка прокси для пользователия
        /// </summary>
        /// <param name="proxy">Прокси</param>
        public void SetProxy(IWebProxy proxy)
        {
            Context.WebProxy = proxy;
        }

        #endregion Основные функции
    }
}