using System;
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

        /// <summary>
        /// Параметры отладки
        /// </summary>
        public DebugSettings Debug { get; }

        /// <summary>
        /// Флаг авторизации
        /// </summary>
        public bool IsAuthorized { get; internal set; }

        /// <summary>
        /// Идентификатор устройства
        /// </summary>
        public string DeviceId { get; set; } = "csharp";

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

        /// <summary>
        /// Язык
        /// </summary>
        public string Language { get; set; } = "ru";

        /// <summary>
        /// Отображаемый язык
        /// </summary>
        public string DisplayLanguage { get; set; } = "ru";

        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; } = "ru";

        internal YAuthToken AuthToken { get; set; }
        
        internal Guid ProcessUuid { get; }

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

            ProcessUuid = Guid.NewGuid();
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

            ProcessUuid = Guid.NewGuid();
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