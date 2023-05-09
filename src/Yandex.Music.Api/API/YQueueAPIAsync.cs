using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Requests.Queue;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с очередями
    /// </summary>
    public partial class YQueueAPI : YCommonAPI
    {
        public YQueueAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        /// <summary>
        /// Получение всех очередей треков с разных устройств для синхронизации между ними
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public Task<YResponse<YQueueItemsContainer>> ListAsync(AuthStorage storage, string device = null)
        {
            return new YQueuesListBuilder(api, storage)
                .Build(device)
                .GetResponseAsync();
        }
        
        /// <summary>
        /// Получение очереди
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="queueId">Идентификатор очереди</param>
        /// <returns></returns>
        public Task<YResponse<YQueue>> GetAsync(AuthStorage storage, string queueId)
        {
            return new YGetQueueBuilder(api, storage)
                .Build(queueId)
                .GetResponseAsync();
        }

        /// <summary>
        /// Создание новой очереди треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="queue">Очередь треков</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public Task<YResponse<YNewQueue>> CreateAsync(AuthStorage storage, YQueue queue, string device = null)
        {
            return new YQueueCreateBuilder(api, storage, device)
                .Build(queue)
                .GetResponseAsync();
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
        public Task<YResponse<YUpdatedQueue>> UpdatePositionAsync(AuthStorage storage, string queueId, int currentIndex, bool isInteractive, string device = null)
        {
            return new YQueueUpdatePositionBuilder(api, storage, device)
                .Build((queueId, currentIndex, isInteractive))
                .GetResponseAsync();
        }
    }
}
