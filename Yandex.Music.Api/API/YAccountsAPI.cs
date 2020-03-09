using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Account;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с аккаунтами
    /// </summary>
    public class YAccountsAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение списка аккаунтов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YAccountResponse> GetAsync(YAuthStorage storage)
        {
            return await new YGetAccountRequest(storage)
                .Create()
                .GetResponseAsync<YAccountResponse>();
        }

        /// <summary>
        /// Получение списка аккаунтов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YAccountResponse Get(YAuthStorage storage)
        {
            return GetAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}