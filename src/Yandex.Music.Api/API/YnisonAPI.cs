using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.Ynison;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Account;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API Ynison
    /// </summary>
    public partial class YnisonAPI : YCommonAPI
    {
        #region Основные функции

        public YnisonAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        public Task<YnisonListener> Connect(AuthStorage storage)
        {
            if (string.IsNullOrEmpty(storage.Token))
                throw new Exception("Токен пользователя не задан.");

            YnisonListener listener = new();
            listener.Connect(storage.Token);
            return Task.FromResult(listener);
        }

        #endregion Основные функции
    }
}
