using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Web.Ugc;

namespace Yandex.Music.Api.API
{
    public partial class YUgcAPI : YCommonAPI
    {
        /// <summary>
        /// Получение ссылки на загрузчик трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="fileName">Название файла для загрузки</param>
        /// <param name="playlistId">Идентификатор плейлиста, куда будет загружен трек</param>
        /// <returns></returns>
        public YUgcUpload GetUgcUploadLink(AuthStorage storage, string fileName, string playlistId)
        {
            return GetUgcUploadLinkAsync(storage, fileName, playlistId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Загрузка трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="uploadLink">Ссылка на балансировщик для загрузки, можно получить из GetUgcUploadLinkAsync</param>
        /// <param name="file">Загружаемый трек в виде массив байтов</param>
        /// <returns></returns>
        public YResponse<string> UploadUgcTrack(AuthStorage storage, string uploadLink, byte[] file)
        {
            return UploadUgcTrackAsync(storage, uploadLink, file).GetAwaiter().GetResult();
        }
    }
}