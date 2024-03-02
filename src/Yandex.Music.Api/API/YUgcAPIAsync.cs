using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Web.Ugc;
using Yandex.Music.Api.Requests.Ugc;

namespace Yandex.Music.Api.API
{
    public partial class YUgcAPI : YCommonAPI
    {
        public YUgcAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        /// <summary>
        /// Получение ссылки на загрузчик трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="fileName">Название файла для загрузки</param>
        /// <param name="playlistId">Идентификатор плейлиста, куда будет загружен трек</param>
        /// <returns></returns>
        public Task<YUgcUpload> GetUgcUploadLinkAsync(AuthStorage storage, string fileName, string playlistId)
        {
            return new YUgcGetUploadLinkBuilder(api, storage)
                .Build((fileName, playlistId))
                .GetResponseAsync();
        }

        /// <summary>
        /// Загрузка трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="uploadLink">Ссылка на балансировщик для загрузки, можно получить из GetUgcUploadLinkAsync</param>
        /// <param name="file">Загружаемый трек в виде массив байтов</param>
        /// <returns></returns>
        public Task<YUgcTrackUploadResult> UploadUgcTrackAsync(AuthStorage storage, string uploadLink, byte[] file)
        {
            return new YUgcUploadBuilder(api, storage)
                .Build((uploadLink, file))
                .GetResponseAsync();
        }
    }
}