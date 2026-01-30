﻿using System.Net.Http;
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
        /// Функция получения ответа с опциями завершения
        /// </summary>
        /// <param name="message">Запрос</param>
        /// <param name="completionOption">Опция завершения запроса</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetWebResponseAsync(HttpRequestMessage message, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead);

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