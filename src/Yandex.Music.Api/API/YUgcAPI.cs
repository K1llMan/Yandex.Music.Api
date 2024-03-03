using System.IO;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Ugc;

namespace Yandex.Music.Api.API
{
    public partial class YUgcAPI
    {
        /// <summary>
        /// Получение ссылки на загрузчик трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист, куда будет загружен трек</param>
        /// <param name="fileName">Название файла для загрузки</param>
        public YUgcUpload GetUgcUploadLink(AuthStorage storage, YPlaylist playlist, string fileName)
        {
            return GetUgcUploadLinkAsync(storage, playlist, fileName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Загрузка трека из файла
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="uploadLink">Ссылка на балансировщик для загрузки, можно получить из GetUgcUploadLinkAsync</param>
        /// <param name="filePath">Загружаемый файл</param>
        public YResponse<string> UploadUgcTrack(AuthStorage storage, string uploadLink, string filePath)
        {
            return UploadUgcTrackAsync(storage, uploadLink, filePath).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Загрузка трека из потока
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="uploadLink">Ссылка на балансировщик для загрузки, можно получить из GetUgcUploadLinkAsync</param>
        /// <param name="stream">Поток с данными для загрузки</param>
        public YResponse<string> UploadUgcTrack(AuthStorage storage, string uploadLink, Stream stream)
        {
            return UploadUgcTrackAsync(storage, uploadLink, stream).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Загрузка трека из массива
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="uploadLink">Ссылка на балансировщик для загрузки, можно получить из GetUgcUploadLinkAsync</param>
        /// <param name="file">Загружаемый трек в виде массив байтов</param>
        public YResponse<string> UploadUgcTrack(AuthStorage storage, string uploadLink, byte[] file)
        {
            return UploadUgcTrackAsync(storage, uploadLink, file).GetAwaiter().GetResult();
        }
    }
}