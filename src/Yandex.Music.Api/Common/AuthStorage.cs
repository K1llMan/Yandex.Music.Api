using System.Net;

using Yandex.Music.Api.Common.Debug;
using Yandex.Music.Api.Common.Providers;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;

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
        /// Аккаунт
        /// </summary>
        public YAccount User { get; set; }

        /// <summary>
        /// Провайдер запросов
        /// </summary>
        public IRequestProvider Provider { get; }

        /// <summary>
        /// Токен доступа
        /// </summary>
        public YAccessToken AccessToken { get; set; }

        internal YAuthToken AuthToken { get; set; }

        #endregion Свойства

        #region Основные функции

        /// <summary>
        /// Конструктор
        /// </summary>
        public AuthStorage(DebugSettings settings = null)
        {
            User = new YAccount();
            Context = new HttpContext();
            Debug = settings;
            Provider = new DefaultRequestProvider(this);

            if (Debug is { ClearDirectory: true })
            {
                Debug.Clear();
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public AuthStorage(IRequestProvider provider, DebugSettings settings = null)
        {
            User = new YAccount();
            Context = new HttpContext();
            Debug = settings;
            Provider = provider;

            if (Debug is { ClearDirectory: true })
            {
                Debug.Clear();
            }
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