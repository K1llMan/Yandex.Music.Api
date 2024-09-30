using System;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.Ynison;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API Ynison
    /// </summary>
    public partial class YYnisonAPI : YCommonAPI
    {
        #region Основные функции

        public YYnisonAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        public Task<YnisonListener> Connect(AuthStorage storage)
        {
            if (string.IsNullOrEmpty(storage.Token))
                throw new Exception("Токен пользователя не задан.");

            YnisonListener listener = new(storage);
            listener.Connect();
            return Task.FromResult(listener);
        }

        #endregion Основные функции
    }
}
