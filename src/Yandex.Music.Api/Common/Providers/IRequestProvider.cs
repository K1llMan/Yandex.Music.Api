using System.Net.Http;
using System.Threading.Tasks;

namespace Yandex.Music.Api.Common.Providers
{
    /// <summary>
    /// Интерфейс для провайдеров обработки запросов
    /// </summary>
    public interface IRequestProvider
    {
        /// <summary>
        /// Функция получения ответа
        /// </summary>
        /// <param name="message">Запрос</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetWebResponseAsync(HttpRequestMessage message);

        /// <summary>
        /// Функция формирования ответа
        /// </summary>
        /// <typeparam name="T">Тип объекта с ответом</typeparam>
        /// <param name="api">API</param>
        /// <param name="response">Ответ</param>
        /// <returns></returns>
        Task<T> GetDataFromResponseAsync<T>(YandexMusicApi api, HttpResponseMessage response);
    }
}