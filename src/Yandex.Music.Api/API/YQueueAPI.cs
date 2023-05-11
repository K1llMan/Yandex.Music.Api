using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Queue;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с очередями
    /// </summary>
    public partial class YQueueAPI
    {
        /// <summary>
        /// Получение всех очередей треков с разных устройств для синхронизации между ними
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public YResponse<YQueueItemsContainer> List(AuthStorage storage, string device = null)
        {
            return ListAsync(storage, device).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение очереди
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="queueId">Идентификатор очереди</param>
        /// <returns></returns>
        public YResponse<YQueue> Get(AuthStorage storage, string queueId)
        {
            return GetAsync(storage, queueId).GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Создание новой очереди треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="queue">Очередь треков</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public YResponse<YNewQueue> Create(AuthStorage storage, YQueue queue, string device = null)
        {
            return CreateAsync(storage, queue, device).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Установка текущего индекса проигрываемого трека в очереди треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="queueId">Идентификатор очереди</param>
        /// <param name="currentIndex">Текущий индекс</param>
        /// <param name="isInteractive">Флаг интерактивности</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public YResponse<YUpdatedQueue> UpdatePosition(AuthStorage storage, string queueId, int currentIndex, bool isInteractive, string device = null)
        {
            return UpdatePositionAsync(storage, queueId, currentIndex, isInteractive, device).GetAwaiter().GetResult();
        }
    }
}
